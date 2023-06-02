using AutoMapper;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google;
using Google.Apis.Auth.OAuth2;
using LockKeyNew.Core.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training_Management.Data;
using Training_Management.ViewModels;
using TrainingManagement.Constants;

namespace TrainingManagement.Services
{
    public class NotificationService : INotificationService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly IFcmService _fcmService;

        public NotificationService(ApplicationDbContext db, IMapper mapper
            , IFcmService fcmService)
        {
            _db = db;
            _mapper = mapper;
            _fcmService = fcmService;
        }


        public async Task<List<NotificationViewModel>> GetLastNotifications(string userId)
        {
            var notifications = await _db.Notifications
                .Where(x => x.ApplicationUserId.Equals(userId))
                .OrderByDescending(x => x.CreatedAt)
                .Take(5)
                .ToListAsync();
            var notificationVms = _mapper.Map<List<NotificationViewModel>>(notifications);
            return notificationVms;
        }

        public async Task<string> SendNotification(string userId
            , Training_Management.Models.Notification schoolNotification)
        {
            var user = await _db.Users.SingleOrDefaultAsync(x => x.Id.Equals(userId));
            if (user == null)
            {
                throw new EntityNotFoundException();
            }

            string result = null;
            if (user.FCMToken != null)
            {
                result = await _fcmService.SendNotification(schoolNotification.Title
               , schoolNotification.Body, user.FCMToken);
            }

            schoolNotification.ApplicationUserId = user.Id;
            schoolNotification.NotificationUserType = UserType.test;
            _db.Notifications.Add(schoolNotification);
            await _db.SaveChangesAsync();

            return result;
        }

    }
}
