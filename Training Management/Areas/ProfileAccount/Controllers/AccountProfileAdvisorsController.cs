using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TrainingManagement.Services;
using Training_Management.Dtos;
using Training_Management.Enums;
using Training_Management.Models;
using TrainingManagement.Constants;

namespace Training_Management.Areas.ProfileAccount.Controllers
{
    public class AccountProfileAdvisorsController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;

        public AccountProfileAdvisorsController(IUserService userService, IAdviserService adviserService, ITraineeService traineeService, IManagerService managerService, UserManager<ApplicationUser> userManager) : base(userService, adviserService, traineeService, managerService)
        {
            this.userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> EditAdvisor(int Id)
        {
            var adviser = await adviserService.FindById(Id);

            if (adviser == null)
                return NotFound();
            var updateAdviser = new UpdateAdviserDto
            {
                Id = adviser.Id,
                Email = adviser.ApplicationUser.Email,
                DesciplineType = adviser.DesciplineType,
                Name = adviser.Name,
                ApplicationUserId = adviser.ApplicationUserId,
            };
            return View(updateAdviser);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAdvisor(UpdateAdviserDto dto)
        {
            var user = await adviserService.FindById(dto.Id);

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
                return RedirectToAction(Constant.Actions.Edit, dto);
            }
            user.Name = dto.Name;
            user.Email = dto.Email;
            user.DesciplineType = dto.DesciplineType;
            user.Name = dto.Name;
            user.ApplicationUserId = dto.ApplicationUserId;
            await adviserService.Update(user);
            return Redirect(Constant.Links.ProfileUsersEditAdvisor + user.Id);
        }



    }
}
