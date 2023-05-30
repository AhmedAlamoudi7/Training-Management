using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrainingManagement.Services;
using Training_Management.Areas.ProfileAccount.Controllers;
using TrainingManagement.Constants;

namespace ShawrneyClientWeb.Areas.ProfileAccount.Controllers
{
     public class AccountProfileHomeController : BaseController
    {
		public AccountProfileHomeController(IUserService userService, IAdviserService adviserService, ITraineeService traineeService, IManagerService managerService) : base(userService, adviserService, traineeService, managerService)
		{
		}

		public async Task<IActionResult> Index()
		{
			return View();
        }
		public async Task<IActionResult> Advisors(string? GeneralSearch)
        {
                var data = await adviserService.GetAll(GeneralSearch);
                return View(data);           
        }
		public async Task<IActionResult> TrainingProgrammes()
		{
			return View();
		}
		public async Task<IActionResult> Trainees(string? GeneralSearch)
		{
            var data = await traineeService.GetAll(GeneralSearch);
            return View(data);
        }
        public async Task<IActionResult> Managers(string? GeneralSearch)
        {
            var data = await managerService.GetAll(GeneralSearch);
            return View(data);
        }
        public async Task<IActionResult> TrainingProgrammesRequest()
		{
			return View();
		}
		public async Task<IActionResult> Notifications()
		{
			return View();
		}
		public async Task<IActionResult> Emails()
		{
			return View();
		}
	}
}
