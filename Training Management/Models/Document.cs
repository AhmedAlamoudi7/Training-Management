﻿namespace Training_Management.Models
{
    public class Document : BaseEntity
    {
        public string Id { get; set; }
        public string FileName { get; set; }
         // Add other necessary properties for document information

        public int TraineeId { get; set; }
     }
}
