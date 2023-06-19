using Firebase.Auth;
using FirebaseAdmin.Messaging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Training_Management.Dtos;
using TrainingManagement.Constants;
using TrainingManagement.Services;

namespace Training_Management.Areas.ProfileAccount.Controllers
{
    public class AccountProfileTrainingProgrammesRequestController : BaseController
    {
        private readonly ITrainingProgrammeService _trainingProgrammeService;
        private readonly ITrainingProgrammeRequestService trainingProgrammeRequestService;
        protected readonly FirebaseAuthProvider auth;

        public AccountProfileTrainingProgrammesRequestController(IUserService userService, IAdviserService adviserService, ITraineeService traineeService, IManagerService managerService, ITrainingProgrammeService trainingProgrammeService, ITrainingProgrammeRequestService trainingProgrammeRequestService) : base(userService, adviserService, traineeService, managerService)
		{
            _trainingProgrammeService = trainingProgrammeService;
            this.trainingProgrammeRequestService = trainingProgrammeRequestService;

            this.auth = new FirebaseAuthProvider(
        new FirebaseConfig("AIzaSyCjg6D59I1Qwlx0jLZp4_oppWTxC4vmCwM"));
        }
   
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewData["Trainees"] = new SelectList(await traineeService.GetAll(null), "Id", "Email");
            ViewData["TrainingPrograms"] = new SelectList(await _trainingProgrammeService.GetAll(null), "Id", "Title");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateTrainingProgrammRequestDto dto)
        {
            dto.status = false;
            ViewData["Trainees"] = new SelectList(await traineeService.GetAll(null), "Id", "Name");
            ViewData["TrainingPrograms"] = new SelectList(await _trainingProgrammeService.GetAll(null), "Id", "Title");
            await trainingProgrammeRequestService.Create(dto);
            var token = HttpContext.Session.GetString("_UserToken");
            // Construct the message payload
            var message = new FirebaseAdmin.Messaging.Message()
            {
                Notification = new Notification
                {
                    Title = "Test Notification",
                    Body = "This is a test notification"
                },
                Token = token
            };

            // Send the message
            var response = await FirebaseMessaging.DefaultInstance.SendAsync(message);
            Console.WriteLine($"Successfully sent message: {response}");
            return Redirect(Constant.Links.ProfileHomeTrainingProgrammesRequest);
        }
        [HttpGet]
        public async Task<IActionResult> ChangeActive(int id)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            await trainingProgrammeRequestService.ChangeActive(id);
            return Redirect(Constant.Links.ProfileHomeTrainingProgrammesRequest);
        }
    }
}
