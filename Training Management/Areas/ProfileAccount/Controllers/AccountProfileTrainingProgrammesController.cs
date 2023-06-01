using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Training_Management.Dtos;
using TrainingManagement.Constants;
using TrainingManagement.Services;

namespace Training_Management.Areas.ProfileAccount.Controllers
{
    public class AccountProfileTrainingProgrammesController : BaseController
    {
        private readonly ITrainingProgrammeService _trainingProgrammeService;

        public AccountProfileTrainingProgrammesController(IUserService userService, IAdviserService adviserService, ITraineeService traineeService, IManagerService managerService, ITrainingProgrammeService trainingProgrammeService) : base(userService, adviserService, traineeService, managerService)
		{
            _trainingProgrammeService = trainingProgrammeService;

        }

		public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewData["Advisors"] = new SelectList(await adviserService.GetAll(null) , "Id", "Name");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateTrainigProgrameDto dto)
        {
            ViewData["Advisors"] = new SelectList(await adviserService.GetAll(null), "Id", "Name");
            await _trainingProgrammeService.Create(dto);
            return Redirect(Constant.Links.ProfileHomeTrainingProgrammes);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            await _trainingProgrammeService.Delete(id);
            return Redirect(Constant.Links.ProfileHomeTrainingProgrammes);
        }
    }
}
