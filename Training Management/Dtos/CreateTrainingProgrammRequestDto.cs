using Training_Management.Models;

namespace Training_Management.Dtos
{
    public class CreateTrainingProgrammRequestDto
    {
        public int Id { get; set; }
        public int TraineeId { get; set; }
        public int TrainingProgramId { get; set; }
         //public List<WeekDays> WeekDays { get; set; }
        public bool status { get; set; }
    }
}
