using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShawrneyClientWeb.Web.Areas.ProfileAccount.Controllers;
using TrainingManagement.Constants;

namespace ShawrneyClientWeb.Areas.ProfileAccount.Controllers
{
     public class AccountProfileHomeController : BaseController
    {
        public AccountProfileHomeController( ) : base( )
        {
        }

        public async Task<IActionResult> Index()
		{
			return View();
        }
		public async Task<IActionResult> Advisors()
		{
			return View();
		}
		public async Task<IActionResult> TrainingProgrammes()
		{
			return View();
		}
		public async Task<IActionResult> Trainees()
		{
			return View();
		}
		public async Task<IActionResult> TrainingProgrammesRequest()
		{
			return View();
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
