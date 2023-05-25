namespace Training_Management.Models
{
    public class Document : BaseEntity
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string Content { get; set; }
        // Add other necessary properties for document information

        public int TraineeId { get; set; }
        public Trainee Trainee { get; set; }
    }
}
