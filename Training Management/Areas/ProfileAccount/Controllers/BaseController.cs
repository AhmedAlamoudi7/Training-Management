using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TrainingManagement.Services;
using TrainingManagement.Constants;
using Firebase.Auth;

namespace Training_Management.Areas.ProfileAccount.Controllers
{
	[Area("ProfileAccount")]
    [Authorize]
     public class BaseController : Controller
    {
		protected readonly IUserService userService;
        protected readonly IAdviserService adviserService;
        protected readonly ITraineeService traineeService;
        protected readonly IManagerService managerService;
        

        public BaseController(IUserService userService, IAdviserService adviserService, ITraineeService traineeService, IManagerService managerService)
		{
			this.userService = userService;
			this.adviserService = adviserService;
			this.managerService = managerService;
			this.traineeService= traineeService;

        }
        protected readonly FirebaseAuthProvider auth;
        public BaseController() {

            this.auth = new FirebaseAuthProvider(
        new FirebaseConfig("AIzaSyCjg6D59I1Qwlx0jLZp4_oppWTxC4vmCwM"));

        }


        public override void OnActionExecuting(ActionExecutingContext context)
		{
			base.OnActionExecuting(context);
			if (User.Identity.IsAuthenticated)
			{
				var userName = User.Identity.Name;
				var user = userService.GetUserByName(userName);
				ViewBag.user = user;
				ViewBag.UserName = user.Username;
				ViewBag.UserId = user.Id;
				ViewBag.Roles = user.Roles;
				ViewBag.Email = user.Email;
                 foreach (var item in ViewBag.Roles)
                {
                    if (item == Constant.RolesFilter.Adviser)
                    {
                        var advisor = adviserService.Detailes(user.Id);
                        ViewBag.AdvisorId = advisor.Id;
                        ViewBag.DesciplineType = advisor.DesciplineType;
                        ViewBag.Name = advisor.Name;

                    }
                    else if (item == Constant.RolesFilter.Trainee)
                    {
                        var trainee = traineeService.Detailes(user.Id);
                        ViewBag.TraineeId = trainee.TraineeId;
                        ViewBag.TraineeIdKey = trainee.Id;

                        ViewBag.GenderType = trainee.GenderType.ToString();
                        ViewBag.FirstName = trainee.FirstName;
                        ViewBag.LastName = trainee.LastName;
                        ViewBag.FullName = string.Concat(trainee.FirstName, " ", trainee.LastName);

                    }
                    else if (item == Constant.RolesFilter.Manager)
                    {
                        var manager = managerService.Detailes(user.Id);
                        ViewBag.managerId = manager.Id;
                        ViewBag.Name = manager.Name;

                    }

                    //if (item == Constant.RolesFilter.Trainee)
                    //{
                    //	var advisor = adviserService.Detailes(user.Id);
                    //	ViewBag.AdvisorId = advisor.Id;
                    //	ViewBag.DesciplineType = advisor.DesciplineType;
                    //}
                    //if (item == Constant.RolesFilter.Manager)
                    //{
                    //	var advisor = adviserService.Detailes(user.Id);
                    //	ViewBag.AdvisorId = advisor.Id;
                    //	ViewBag.DesciplineType = advisor.DesciplineType;
                    //}
                }
            }
		}
	}
}


