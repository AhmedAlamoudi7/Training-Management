using Microsoft.AspNetCore.Mvc;
using TrainingManagement.Services;
using System.Diagnostics;
using Training_Management.Areas.ProfileAccount.Controllers;
using Training_Management.Models;

namespace Training_Management.Controllers
{
    public class HomeController : BaseClientController
	{
		public HomeController(IUserService userService, IAdviserService adviserService, ITraineeService traineeService, IManagerService managerService) : base(userService, adviserService, traineeService, managerService)
		{
		}

		public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}