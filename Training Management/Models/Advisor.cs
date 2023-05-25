﻿
using Training_Management.Enums;

namespace Training_Management.Models
{
    public class Advisor :BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        // Add other necessary properties for advisor information
        public DesciplineType DesciplineType { get; set; }
        public string? ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        // Navigation properties
        public List<Trainee> Trainees { get; set; }
		public List<Meeeting> Meeeting { get; set; }

	}
}