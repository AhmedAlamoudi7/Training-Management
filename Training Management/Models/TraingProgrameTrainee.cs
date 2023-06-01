using Training_Management.Enums;

namespace Training_Management.Models
{
	public class TraingProgrameTrainee :BaseEntity
	{
		public int Id { get; set; }
		public int TraineeId { get; set; }
		public Trainee Trainee { get; set; }
		public int TrainingProgramId { get; set; }
		public TrainingProgram TrainingProgram { get; set; }
		//public List<WeekDays> WeekDays { get; set; }
		public bool status { get; set; }

	}
}
