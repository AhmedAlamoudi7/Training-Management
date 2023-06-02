using AutoMapper;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingManagement.Services
{
    public class FcmService : IFcmService
    {
        private readonly FirebaseMessaging messaging;

        public FcmService()
        {
            var app = FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile("trainee-cloud-firebase-adminsdk-qzzyq-6ef986b79d.json")
                .CreateScoped("https://www.googleapis.com/auth/firebase.messaging")
            });
            messaging = FirebaseMessaging.GetMessaging(app);
        }

        public async Task<string> SendNotification(string title, string body, string token)
        {
            var notification = CreateNotification(title, body, token);
            var result = await messaging.SendAsync(notification);
            return result;
        }

        private Message CreateNotification(string title, string body, string token)
        {
            return new Message()
            {
                Notification = new Notification()
                {
                    Title = title,
                    Body = body
                },
                Token = token
            };
        }

    }
}
