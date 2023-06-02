using AutoMapper;
using DocumentFormat.OpenXml.Spreadsheet;
using LockKeyNew.Core.Exceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TrainingManagement.ViewModels;
using TrainingManagement.Dtos;
using System.Collections.Generic;
using Training_Management.Data;
using Training_Management.Models;
using TrainingManagement.Dtos.LoginDto;
 using TrainingManagement.Exceptions;
using TrainingManagement.Helpers;
using Training_Management.ViewModels;
using Training_Management.Dtos;
using DocumentFormat.OpenXml.Math;
using Microsoft.Extensions.Hosting;
using DocumentFormat.OpenXml.InkML;
using FirebaseAdmin.Messaging;
using TrainingManagement.Enums;

namespace TrainingManagement.Services
{
    public class TrainingProgrammeRequestService : ITrainingProgrammeRequestService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public readonly IUserService _userService;
        private readonly IWebHostEnvironment _env;
        private readonly IFcmService fcmService;
        private readonly INotificationService _notificationService;

        public TrainingProgrammeRequestService(IWebHostEnvironment env, IUserService userService,ApplicationDbContext db, IMapper mapper, IFcmService fcmService, INotificationService notificationService)
        {
            _db = db;
            _mapper = mapper;
              _userService = userService;
            _env = env;
            this.fcmService= fcmService;
            _notificationService = notificationService;
        }
        public async Task<List<TrainingProgrammeRequestViewModel>> GetAll(string? GeneralSearch)
        {
            var data = await _db.TraingProgrameTrainees.Include(x=>x.TrainingProgram).Include(x => x.Trainee)
                .Where(x =>  
            (x.Trainee.Email.Contains(GeneralSearch)
            || string.IsNullOrWhiteSpace(GeneralSearch)))
             .OrderByDescending(x => x.CreatedAt).ToListAsync();
            var model = _mapper.Map<List<TrainingProgrammeRequestViewModel>>(data);
            return model;
        }
 		public async Task<int> Create(CreateTrainingProgrammRequestDto dto)
        {
            var emailOrPhoneIsExist = _db.TraingProgrameTrainees
                .Any(x => !x.IsDelete == true);

             var model = _mapper.Map<TraingProgrameTrainee>(dto);

            if (model == null)
            {
                throw new EntityNotFoundException();
            }
            await _db.TraingProgrameTrainees.AddAsync(model);
            await _db.SaveChangesAsync();
            
            return model.Id;
        }
        public async Task ChangeActive(int Id)
        {
            var model = _db.TraingProgrameTrainees.Include(x => x.Trainee).Include(x => x.TrainingProgram).SingleOrDefault(x => x.Id == Id && (bool)!x.IsDelete);
            if (model == null)
            {
                throw new EntityNotFoundException();
            }
            // means if active set not and if not set active
            model.status = !model.status;
            var notification = new Training_Management.Models.Notification
            {
                 Title = "Trainee Programme Request",
                 Body = "Trainee Programme Request Change Status",
                 Action = NotificationType.Test
            };
            await _notificationService.SendNotification(model.Trainee.ApplicationUserId, notification);
            _db.TraingProgrameTrainees.Update(model);
            await _db.SaveChangesAsync();
        }
        public async Task<string> Delete(int Id)
        {
            var model = await _db.TraingProgrameTrainees.SingleOrDefaultAsync(x => x.Id == Id && !(bool)x.IsDelete);
            if (model == null)
            {
                throw new EntityNotFoundException();
            }
            model.IsDelete = true;
            _db.TraingProgrameTrainees.Update(model);
             await _db.SaveChangesAsync();
            return model.Id.ToString();
        }      
    }
}
