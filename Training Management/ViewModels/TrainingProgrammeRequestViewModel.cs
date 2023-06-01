using Training_Management.Models;
using TrainingManagement.Enums;
using TrainingManagement.ViewModels;

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
