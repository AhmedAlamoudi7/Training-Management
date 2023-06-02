using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using FireSharp.Response;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Training_Management.Dtos;
using Training_Management.Models;
using Training_Management.Services;
using TrainingManagement.Constants;
using TrainingManagement.Enums;
using TrainingManagement.Services;

namespace Training_Management.Areas.ProfileAccount.Controllers
{
    public class AccountProfileTraineesController : BaseController
	{
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IDocumentService documentService;

        public AccountProfileTraineesController(IUserService userService, IAdviserService adviserService, ITraineeService traineeService, IManagerService managerService, UserManager<ApplicationUser> userManager, IDocumentService documentService) : base(userService, adviserService, traineeService, managerService)
		{
            this.userManager = userManager;
            this.documentService = documentService;
		}

        [HttpGet]
        public async Task<IActionResult> EditTrainee(int Id)
        {
            var adviser = await traineeService.FindById(Id);

            if (adviser == null)
                return NotFound();
            var updateTraineeDto = new UpdateTraineeDto
            {
                Id = adviser.Id,
                Email = adviser.ApplicationUser.Email,
                FirstName = adviser.FirstName,
                LastName = adviser.LastName,
                GenderType = adviser.GenderType,
                TraineeId = adviser.TraineeId,
                ApplicationUserId = adviser.ApplicationUserId,
            };
            return View(updateTraineeDto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTrainee(UpdateTraineeDto dto)
        {
            var user = await traineeService.FindById(dto.Id);

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
            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.GenderType = dto.GenderType;
            user.TraineeId = dto.TraineeId;
            user.ApplicationUserId = dto.ApplicationUserId;
            await traineeService.Update(user);
            return Redirect(Constant.Links.ProfileUsersEditTrainee + user.Id);
        }


        [HttpGet]
        public async Task<IActionResult> AddDocumnt(int Id)
        {
            var adviser = await traineeService.FindById(Id);
            if (adviser == null)
                return NotFound();

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddDocumnt(CreateDocumentDto dto)
        {
            var user = await traineeService.FindById(dto.TraineeId);

            if (user == null)
                return NotFound();
  
            await documentService.Create(dto);
            return Redirect(Constant.Links.ProgileHomeIndex);
        }
        [HttpGet]
        public async Task<IActionResult> Document(int id)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            var model = await documentService.GetAll(ViewBag.TraineeIdKey);
            return View(model);
        }
        public ActionResult Delete(string id)
        {
              documentService.Delete(id);
            return Redirect("~/ProfileAccount/AccountProfileTrainees/Document/"+ViewBag.TraineeIdKey);
        }
    }
}
