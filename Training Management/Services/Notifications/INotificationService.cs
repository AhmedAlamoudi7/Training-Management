 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training_Management.Models;
using Training_Management.ViewModels;

namespace TrainingManagement.Services
{
    public interface INotificationService
    {
        Task<List<NotificationViewModel>> GetLastNotifications(string userId);
        Task<string> SendNotification(string userId
            , Notification schoolNotification);
    }
}
