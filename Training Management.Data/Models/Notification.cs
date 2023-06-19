 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingManagement.Constants;
using TrainingManagement.Enums;

namespace Training_Management.Data
{
	public class Notification : BaseEntity
    {
        public Notification()
        {
            Status = NotificationStatus.New;
        }

        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string Title { get; set; }
         public string Body { get; set; }
         public NotificationType Action { get; set; }
        public string? ActionId { get; set; }
        public NotificationStatus Status { get; set; }
        public UserType NotificationUserType { get; set; }
    }
}
