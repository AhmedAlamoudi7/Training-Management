﻿using Training_Management.ViewModels;

namespace Training_Management.Models
{
    public class DocumentViewModel  
    { 
        public string Id { get; set; }
        public string FileName { get; set; }
        public string Content { get; set; }
        // Add other necessary properties for document information

         public TraineeViewModel Trainee { get; set; }
    }
}
