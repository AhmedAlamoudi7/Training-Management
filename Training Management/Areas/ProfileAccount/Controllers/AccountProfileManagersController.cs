using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Training_Management.Dtos;
using Training_Management.Models;
using TrainingManagement.Constants;
using TrainingManagement.Enums;
using TrainingManagement.Services;

namespace Training_Management.Areas.ProfileAccount.Controllers
{
    public class AccountProfileManagersController : BaseController
	{
        private readonly UserManager<ApplicationUser> userManager;
		public AccountProfileManagersController(IUserService userService, IAdviserService adviserService, ITraineeService traineeService, IManagerService managerService, UserManager<ApplicationUser> userManager) : base(userService, adviserService, traineeService, managerService)
		{
            this.userManager = userManager;
		}
		[HttpGet]
		public async Task<IActionResult> EditManager(int Id)
		{
			var adviser = await managerService.FindById(Id);

			if (adviser == null)
				return NotFound();
			var updateTraineeDto = new UpdateManagerDto
			{
				Id = adviser.Id,
				Email = adviser.ApplicationUser.Email,
				Name = adviser.Name,
				ApplicationUserId = adviser.ApplicationUserId,
			};
			return View(updateTraineeDto);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> EditManager(UpdateManagerDto dto)
		{
			var user = await managerService.FindById(dto.Id);

			if (user == null)
				return NotFound();
			var userWithSameEmail = await userManager.FindByEmailAsync(dto.Email);
			if (userWithSameEmail != null && userWithSameEmail.Id != dto.ApplicationUserId)
			{
				ModelState.AddModelError(Constant.Email, Constant.Response.EmailIsExist);
				return View(dto);
			}
			if (await userManager.FindByEmailAsync(dto.Email) != null && userWithSameEmail.Email != dto.Email)
			{
				ModelState.AddModelError(Constant.Email, Constant.Response.EmailIsExist);
				return View(dto);
			}
			user.Name = dto.Name;
			user.ApplicationUserId = dto.ApplicationUserId;
			await managerService.Update(user);
			return Redirect(Constant.Links.ProfileUsersEditManager + user.Id);
		}
		[HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            await managerService.Delete(id);
            return Redirect(Constant.Links.ProfileHomeManagers);
        }
    }
}
