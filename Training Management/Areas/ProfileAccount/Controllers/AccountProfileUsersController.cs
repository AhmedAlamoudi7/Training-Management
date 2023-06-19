using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TrainingManagement.Services;
using Training_Management.Models;
using TrainingManagement.Constants;
using Training_Management.Dtos;
using TrainingManagement.Dtos;
using TrainingManagement.ViewModels;

namespace Training_Management.Areas.ProfileAccount.Controllers
{

	public class AccountProfileUsersController : BaseController
    {
         private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> userManager;

        public AccountProfileUsersController(IUserService userService, IAdviserService adviserService, ITraineeService traineeService, IManagerService managerService, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager) : base(userService, adviserService, traineeService, managerService)
		{
            _signInManager = signInManager;
            this.userManager = userManager;
		}
	
		[HttpGet]
         public async Task<IActionResult> Logout(string returnUrl = null)
        {
            HttpContext.Session.Remove("_UserToken");
            await _signInManager.SignOutAsync();
            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                 return Redirect(Constant.Links.Login);
            }
        }
    }
}
