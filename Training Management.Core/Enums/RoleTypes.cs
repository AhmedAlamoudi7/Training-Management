
using System.ComponentModel.DataAnnotations;

namespace TrainingManagement.Core.Enums
{
    public enum RoleTypes
    {
        [Display(Name = "Trainee")]
        Trainee = 0,
        [Display(Name = "مدير نظام")]
        SuperAdmin = 1,
        [Display(Name = "Manager")]
        Manager = 2,
		[Display(Name = "Advisor")]
		Advisor = 3,
	}
}
