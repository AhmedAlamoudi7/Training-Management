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

namespace TrainingManagement.Services
{
    public class TrainingProgrammeService : ITrainingProgrammeService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public readonly IUserService _userService;
        private readonly IWebHostEnvironment _env;
        public TrainingProgrammeService(IWebHostEnvironment env, IUserService userService,/*IEmailService emailService,*/ ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
             //_emailService = emailService;
             _userService = userService;
            _env = env;
        }
        public async Task<List<TrainingProgrammeViewModel>> GetAll(string? GeneralSearch)
        {
            var data = await _db.TrainingPrograms.Include(x=>x.Advisor)
                .Where(x => (x.IsDelete == false)
            && (x.Title.Contains(GeneralSearch)
            || string.IsNullOrWhiteSpace(GeneralSearch)))
             .OrderByDescending(x => x.CreatedAt).ToListAsync();

            var model = _mapper.Map<List<TrainingProgrammeViewModel>>(data);
            return model;
        }
 		public async Task<int> Create(CreateTrainigProgrameDto dto)
        {
            var emailOrPhoneIsExist = _db.TrainingPrograms
                .Any(x => !x.IsDelete == true);

             var model = _mapper.Map<TrainingProgram>(dto);

            if (model == null)
            {
                throw new EntityNotFoundException();
            }
            await _db.TrainingPrograms.AddAsync(model);
            await _db.SaveChangesAsync();
            
            return model.Id;
        }     
        public async Task<string> Delete(int Id)
        {
            var model = await _db.TrainingPrograms.SingleOrDefaultAsync(x => x.Id == Id && !(bool)x.IsDelete);
            if (model == null)
            {
                throw new EntityNotFoundException();
            }
            model.IsDelete = true;
            _db.TrainingPrograms.Update(model);
             await _db.SaveChangesAsync();
            return model.Id.ToString();
        }      
    }
}
