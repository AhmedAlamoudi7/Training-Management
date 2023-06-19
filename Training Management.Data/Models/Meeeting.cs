namespace Training_Management.Data
{
	public class Meeeting :BaseEntity
	{
		public int Id { get; set; }
		public int TraineeId { get; set; }
		public Trainee Trainee { get; set; }
		public int AdvisorId { get; set; }
		public Advisor Advisor { get; set; }
		public DateTime Date { get; set; }
		public DateTime StartSession { get; set; }
		public DateTime EndSession { get; set; }
		public string Title { get; set; }
		public string ShortDescription { get; set; }
		public bool Status { get; set; }

		public Meeeting()
		{
			Status = false;
		}
	}
}
