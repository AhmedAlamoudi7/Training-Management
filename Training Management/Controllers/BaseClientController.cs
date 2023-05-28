using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
 using Training_Management.ViewModels;
using TrainingManagement.Constants;
using TrainingManagement.Services;

namespace Training_Management.Controllers
{
	public class BaseClientController : Controller
    {
		private readonly IUserService userService;
		private readonly IAdviserService adviserService;
		private readonly ITraineeService traineeService;
		private readonly IManagerService managerService;

		public BaseClientController(IUserService userService, IAdviserService adviserService, ITraineeService traineeService, IManagerService managerService)
		{
			this.userService = userService;
			this.adviserService = adviserService;
			this.managerService = managerService;
			this.traineeService = traineeService;
		}

		public override async void OnActionExecuting(ActionExecutingContext context)
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
						ViewBag.TraineeId = trainee.Id;
						ViewBag.GenderType = trainee.GenderType;
						ViewBag.FirstName = trainee.FirstName;
						ViewBag.LastName = trainee.LastName;
                        ViewBag.FullName = string.Concat(trainee.FirstName," ", trainee.LastName);

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


