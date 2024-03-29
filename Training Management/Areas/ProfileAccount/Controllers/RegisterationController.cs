﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Mail;
using Training_Management.Models;
using Training_Management.Dtos;
using Training_Management.ViewModels;
using TrainingManagement.Dtos;
using TrainingManagement.ViewModels;
using TrainingManagement.Services;
using Training_Management.Data;
using Microsoft.AspNetCore.Identity;
using TrainingManagement.Constants;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using DocumentFormat.OpenXml.Spreadsheet;
using Newtonsoft.Json;
using static Google.Rpc.Context.AttributeContext.Types;
using Firebase.Auth;

namespace Training_Management.Areas.ProfileAccount.Controllers
{
	public class RegisterationController : BaseController
	{
        private readonly ApplicationDbContext _db;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
        public readonly IUserService _userService;
        protected readonly FirebaseAuthProvider auth;

        public RegisterationController(IUserService userService, IAdviserService adviserService,
			ITraineeService traineeService, IManagerService managerService, ApplicationDbContext db,
			UserManager<ApplicationUser> userManager,RoleManager<IdentityRole> roleManager,
			SignInManager<ApplicationUser> signInManager) : base(userService, adviserService, traineeService, managerService)
		{
				_db = db;
				_userManager = userManager;
				_roleManager = roleManager;
				_signInManager = signInManager;

            this.auth = new FirebaseAuthProvider(
        new FirebaseConfig("AIzaSyCjg6D59I1Qwlx0jLZp4_oppWTxC4vmCwM"));
        }

		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> RegisterAdvisor()
		{
			return View();
		}
		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> RegisterAdvisor(CreateAdviserDto dto)
		{
            //firebase
            //create the user
            await auth.CreateUserWithEmailAndPasswordAsync(dto.Email, dto.Password);
            //log in the new user	
            var fbAuthLink = await auth
                            .SignInWithEmailAndPasswordAsync(dto.Email, dto.Password);
            string token = fbAuthLink.FirebaseToken;
			//saving the token in a session variable
			if (token != null)
			{
				HttpContext.Session.SetString("_UserToken", token);


				dto.Roles = _db.Roles.Select(x => new RoleViewModel() { RoleName = x.Name, RoleId = x.Id, IsSelected = true }).Where(x => x.RoleName == Constant.Adviser).ToList();

				// default roles
				if (await _userManager.FindByEmailAsync(dto.Email) != null)
				{
					return Json(new { success = false, responseText = Constant.Response.EmailIsExist });

				}
				if (await _userManager.FindByNameAsync(dto.Email) != null)
				{
					return Json(new { success = false, responseText = Constant.Response.EmailIsExist });

				}
				var user = new ApplicationUser
				{
					UserName = new MailAddress(dto.Email).User,
					Email = dto.Email,
					EmailConfirmed = false
				};

				var result = await _userManager.CreateAsync(user, dto.Password);

				if (!result.Succeeded)
				{
					foreach (var error in result.Errors)
					{
						return Json(new { success = false, responseText = error.Description });

					}
				}
				await _userManager.AddToRoleAsync(user, Constant.Adviser);
				await adviserService.Create(dto, user.Id);
				var returnUrl = Constant.Links.ProgileHomeIndex;
				if (result.Succeeded)
				{
					var userId = await _userManager.GetUserIdAsync(user);
					var resultlogin = await _signInManager.PasswordSignInAsync(user, dto.Password, false, lockoutOnFailure: false);
					if (resultlogin.Succeeded)
					{
						return Json(new { success = true, responseText = Constant.Response.Success, link = Constant.Links.ProgileHomeIndex });
					}
					return Json(new { success = false, responseText = Constant.Response.Error });
				}
			}
			return Json(new { success = true, responseText = Constant.Response.Error });
		}
		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> RegisterTrainee()
		{
			return View();
		}
		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> RegisterTrainee(CreateTraineeDto dto)
		{
 
                //firebase
                //create the user
                await auth.CreateUserWithEmailAndPasswordAsync(dto.Email, dto.Password);
                //log in the new user	
                var fbAuthLink = await auth
                                .SignInWithEmailAndPasswordAsync(dto.Email, dto.Password);
                string token = fbAuthLink.FirebaseToken;
				//saving the token in a session variable
				if (token != null)
				{
					HttpContext.Session.SetString("_UserToken", token);



					dto.Roles = _db.Roles.Select(x => new RoleViewModel() { RoleName = x.Name, RoleId = x.Id, IsSelected = true }).Where(x => x.RoleName == Constant.RolesFilter.Trainee).ToList();

					// default roles
					if (await _userManager.FindByEmailAsync(dto.Email) != null)
					{
						return Json(new { success = false, responseText = Constant.Response.EmailIsExist });

					}
					if (await _userManager.FindByNameAsync(dto.Email) != null)
					{
						return Json(new { success = false, responseText = Constant.Response.EmailIsExist });

					}
					var user = new ApplicationUser
					{
						UserName = new MailAddress(dto.Email).User,
						Email = dto.Email,
						EmailConfirmed = false
					};

					var result = await _userManager.CreateAsync(user, dto.Password);

					if (!result.Succeeded)
					{
						foreach (var error in result.Errors)
						{
							return Json(new { success = false, responseText = error.Description });

						}
					}
					await _userManager.AddToRoleAsync(user, Constant.RolesFilter.Trainee);

					await traineeService.Create(dto, user.Id);
					var returnUrl = Constant.Links.ProgileHomeIndex;
					if (result.Succeeded)
					{
						var userId = await _userManager.GetUserIdAsync(user);
						var resultlogin = await _signInManager.PasswordSignInAsync(user, dto.Password, false, lockoutOnFailure: false);
						if (resultlogin.Succeeded)
						{
							return Json(new { success = true, responseText = Constant.Response.Success, link = Constant.Links.ProgileHomeIndex });
						}
						return Json(new { success = false, responseText = Constant.Response.Error });
					}
					return Json(new { success = true, responseText = Constant.Response.Error });

                }
                return Json(new { success = true, responseText = Constant.Response.Error });

            }
        [HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> RegisterManager()
        {
            return View();
        }
        [HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> RegisterManager(CreateManagerDto dto)
		{
			try
			{
				//firebase
				//create the user
                await auth.CreateUserWithEmailAndPasswordAsync(dto.Email, dto.Password);
				//log in the new user	
                var fbAuthLink = await auth
                                .SignInWithEmailAndPasswordAsync(dto.Email, dto.Password);
                string token = fbAuthLink.FirebaseToken;
                //saving the token in a session variable
                if (token != null)
                {
                    HttpContext.Session.SetString("_UserToken", token);

					
					
					
					
					
					//user 



                    dto.Roles = _db.Roles.Select(x => new RoleViewModel() { RoleName = x.Name, RoleId = x.Id, IsSelected = true }).Where(x => x.RoleName == Constant.RolesFilter.Manager).ToList();

                    // default roles
                    if (await _userManager.FindByEmailAsync(dto.Email) != null)
                    {
                        return Json(new { success = false, responseText = Constant.Response.EmailIsExist });

                    }
                    if (await _userManager.FindByNameAsync(dto.Email) != null)
                    {
                        return Json(new { success = false, responseText = Constant.Response.EmailIsExist });

                    }
                    var user = new ApplicationUser
                    {
                        UserName = new MailAddress(dto.Email).User,
                        Email = dto.Email,
                        EmailConfirmed = false
                    };

                    var result = await _userManager.CreateAsync(user, dto.Password);

                    if (!result.Succeeded)
                    {
                        foreach (var error in result.Errors)
                        {
                            return Json(new { success = false, responseText = error.Description });

                        }
                    }
                    await _userManager.AddToRoleAsync(user, Constant.RolesFilter.Manager);
                    await managerService.Create(dto, user.Id);
                    var returnUrl = Constant.Links.ProgileHomeIndex;
                    if (result.Succeeded)
                    {
                        var userId = await _userManager.GetUserIdAsync(user);
                        var resultlogin = await _signInManager.PasswordSignInAsync(user, dto.Password, false, lockoutOnFailure: false);
                        if (resultlogin.Succeeded)
                        {
                            return Json(new { success = true, responseText = Constant.Response.Success, link = Constant.Links.ProgileHomeIndex });
                        }
                        return Json(new { success = false, responseText = Constant.Response.Error });
                    }
                    return Json(new { success = true, responseText = Constant.Response.Error });
                }
            }
            catch (Exception ex)
            {

             }
            return Json(new { success = false, responseText = Constant.Response.Error });



        }
        [HttpPost]
        public async Task<IActionResult> SaveFcmToken(DeviceTokenRequest dto)
		{
            await userService.SaveFcmToken(dto, ViewBag.UserId);
            return View();
        }
    }
}

