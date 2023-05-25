using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Mail;
using Training_Management.Models;

namespace Training_Management.Controllers
{
	public class RegisterationController : Controller
	{

		//[HttpGet]
		//[AllowAnonymous]
		//public async Task<IActionResult> RegisterAdvisor()
		//{
 	//		return View();
		//}
		//[HttpPost]
		//[AllowAnonymous]
		//public async Task<JsonResult> RegisterAdvisor(CreateAdviserDto dto)
		//{
		//	// default image
		//	using var dataStream = new MemoryStream();
		 
		//	// default roles
		//	dto.Roles = _interfaceServices.db.Roles.Select(x => new RoleViewModel() { RoleName = x.Name, RoleId = x.Id, IsSelected = true }).Where(x => x.RoleName == Constant.Adviser).ToList();
		//	if (await _interfaceServices.userManager.FindByEmailAsync(dto.Email) != null)
		//	{
		//		return Json(new { success = false, responseText = Constant.Response.EmailIsExist });
		//	}
		//	if (await _interfaceServices.userManager.FindByNameAsync(dto.Email) != null)
		//	{
		//		return Json(new { success = false, responseText = Constant.Response.UserIsExist });
		//	}
		//	if (!_allowedExtenstionsImages.Contains(Path.GetExtension(dto.Image.FileName).ToLower()))
		//	{
		//		return Json(new { success = false, responseText = Constant.Response.MaxLimit1MB });
		//	}
		//	if (!_allowedExtenstionsFiles.Contains(Path.GetExtension(dto.CV.FileName).ToLower()))
		//	{
		//		return Json(new { success = false, responseText = Constant.Response.FileDenied });
		//	}
		//	if ((dto.Image.Length | dto.CV.Length) > _maxAllowedPosterSize)
		//	{
		//		return Json(new { success = false, responseText = Constant.Response.MaxLimit1MB });
		//	}
		//	var user = new ApplicationUser
		//	{
		//		UserName = new MailAddress(dto.Email).User,
		//		Email = dto.Email,
		//		FirstName = dto.FirstName,
		//		LastName = dto.LastName,
		//		PhoneNumber = dto.Phone,
		//		Country = dto.Country,
		//		AcceptTerms = dto.Accept_terms,
		//		IsActive = true,
		//		EmailConfirmed = false
		//	};
		//	user.ImageUrl = dataStream.ToArray();

		//	var result = await _interfaceServices.userManager.CreateAsync(user, dto.Password);

		//	if (!result.Succeeded)
		//	{
		//		foreach (var error in result.Errors)
		//		{
		//			return Json(new { success = false, responseText = error.Description });
		//		}
		//	}
		//	await _interfaceServices.userManager.AddToRoleAsync(user, Constant.Adviser);
		//	await _interfaceServices.adviserService.Create(dto, user.Id);
		//	var returnUrl = Constant.Links.ProgileHomeIndex;
		//	if (result.Succeeded)
		//	{
		//		var userId = await _interfaceServices.userManager.GetUserIdAsync(user);
		//		var resultlogin = await _interfaceServices.signInManager.PasswordSignInAsync(user, dto.Password, false, lockoutOnFailure: false);
		//		//	return Json(new { success = true, responseText = Constant.Response.Success, link = Constant.Links.ProgileHomeAdvisors });
		//		if (resultlogin.Succeeded)
		//		{
		//			await _interfaceServices.loggingService.Create(user.UserName, Constant.Response.LoginSucsess);
		//			return Json(new { success = true, responseText = Constant.Response.Success, link = Constant.Links.ConfirmEmailWithUserIdParameter + userId });
		//		}
		//		return Json(new { success = true, responseText = Constant.Response.Success, link = Constant.Links.ConfirmEmailWithUserIdParameter + userId });
		//	}
		//	return Json(new { success = true, responseText = Constant.Response.Error });
		//}
		//[HttpGet]
		//[Authorize(Roles = Constant.RolesFilter.UserAndAdvisor)]
		//public async Task<IActionResult> Logout(string returnUrl = null)
		//{
		//	await _interfaceServices.signInManager.SignOutAsync();
		//	foreach (var cookie in Request.Cookies.Keys)
		//	{
		//		Response.Cookies.Delete(cookie);
		//	}
		//	if (returnUrl != null)
		//	{
		//		return LocalRedirect(returnUrl);
		//	}
		//	else
		//	{
		//		await _interfaceServices.loggingService.Create(ViewBag.UserName, Constant.Response.LogoutSucsess + ViewBag.FirstName + " " + ViewBag.LastName);
		//		return Redirect(Constant.Links.Login);
		//	}
		}
 	}

