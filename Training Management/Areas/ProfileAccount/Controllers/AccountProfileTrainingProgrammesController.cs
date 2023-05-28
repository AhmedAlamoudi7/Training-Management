using Microsoft.AspNetCore.Mvc;
using TrainingManagement.Services;

namespace Training_Management.Areas.ProfileAccount.Controllers
{
    public class AccountProfileTrainingProgrammesController : BaseController
	{
		public AccountProfileTrainingProgrammesController(IUserService userService, IAdviserService adviserService, ITraineeService traineeService, IManagerService managerService) : base(userService, adviserService, traineeService, managerService)
		{
		}

		public IActionResult Index()
        {
            return View();
        }
    }
}
