﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrainingManagement.Services;
using Training_Management.Areas.ProfileAccount.Controllers;
using TrainingManagement.Constants;
using Firebase.Auth;
using static Google.Rpc.Context.AttributeContext.Types;
using Training_Management.Controllers;

namespace ShawrneyClientWeb.Areas.ProfileAccount.Controllers
{
     public class AccountProfileHomeController : BaseController
    {
		private readonly ITrainingProgrammeService _trainingProgrammeService;
        private readonly ITrainingProgrammeRequestService trainingProgrammeRequestService;

        public AccountProfileHomeController(IUserService userService, IAdviserService adviserService, ITraineeService traineeService, IManagerService managerService, ITrainingProgrammeService trainingProgrammeService, ITrainingProgrammeRequestService trainingProgrammeRequestService) : base(userService, adviserService, traineeService, managerService)
		{
            _trainingProgrammeService = trainingProgrammeService;
            this.trainingProgrammeRequestService = trainingProgrammeRequestService; 
        }
  
 
        public async Task<IActionResult> Index()
        {
            //var token = HttpContext.Session.GetString("_UserToken");

            //if (token != null)
            //{
                return View();
            //}
            //else
            //{
            //    return Redirect("/Identity/Account/Login");
            //}
         }
		public async Task<IActionResult> Advisors(string? GeneralSearch)
        {
                var data = await adviserService.GetAll(GeneralSearch);
                return View(data);           
        }
		public async Task<IActionResult> TrainingProgrammes(string? GeneralSearch)
        {
            var data = await _trainingProgrammeService.GetAll(GeneralSearch);
            return View(data);
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
        public async Task<IActionResult> TrainingProgrammesRequest(string? GeneralSearch)
        {
            var data = await trainingProgrammeRequestService.GetAll(GeneralSearch);
            return View(data);
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
