using TrainingManagement.Core.Models;
using TrainingManagement.Core.Enums;
using TrainingManagement.Core.ViewModels;

namespace Training_Management.ViewModels
{
	public class TrainingProgrammeRequestViewModel
    {
        public int Id { get; set; }
         public TraineeViewModel Trainee { get; set; }
         public TrainingProgrammeViewModel TrainingProgram { get; set; }
        //public List<WeekDays> WeekDays { get; set; }
        public bool status { get; set; }


    }
}
