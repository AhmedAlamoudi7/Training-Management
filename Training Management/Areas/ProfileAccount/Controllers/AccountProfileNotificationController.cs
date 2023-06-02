using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Training_Management.Areas.ProfileAccount.Controllers;
using Training_Management.Models;
using Training_Management.ViewModels;
using TrainingManagement.Services;

namespace School.Web.Controllers
{
    public class AccountProfileNotificationController : BaseController
    {
        private readonly INotificationService _notificationService;

        public AccountProfileNotificationController(IUserService userService, IAdviserService adviserService, ITraineeService traineeService, IManagerService managerService, INotificationService notificationService) : base(userService, adviserService, traineeService, managerService)
        {
            _notificationService = notificationService;

        }
        public IActionResult Index()
        {
            return View();
        }


        public async Task<List<NotificationViewModel>> GetLastNotifications()
        {
            var notificationVms = await _notificationService.GetLastNotifications(ViewBag.UserId);
            return notificationVms;
        }
    }
}
