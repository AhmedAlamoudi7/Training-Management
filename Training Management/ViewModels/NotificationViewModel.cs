
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingManagement.Enums;

namespace Training_Management.ViewModels
{
    public class NotificationViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public NotificationType Action { get; set; }
        public string? ActionId { get; set; }
        public string CreatedAt { get; set; }
    }
}
