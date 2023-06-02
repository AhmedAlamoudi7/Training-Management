using Microsoft.AspNetCore.Mvc;
using TrainingManagement.Services;
using System.Diagnostics;
using Training_Management.Areas.ProfileAccount.Controllers;
using Training_Management.Models;
using Firebase.Auth;
using static Google.Rpc.Context.AttributeContext.Types;

namespace Training_Management.Controllers
{
    public class HomeController : BaseClientController
	{

        public HomeController(IUserService userService, IAdviserService adviserService, ITraineeService traineeService, IManagerService managerService) : base(userService, adviserService, traineeService, managerService)
        {

        }
   
     
        public async Task<IActionResult> Index()
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