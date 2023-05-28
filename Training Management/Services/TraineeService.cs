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

namespace TrainingManagement.Services
{
    public class TraineeService : ITraineeService
	{
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public readonly IUserService _userService;
        private readonly IWebHostEnvironment _env;
        public TraineeService(IWebHostEnvironment env, IUserService userService,/*IEmailService emailService,*/ ApplicationDbContext db, IMapper mapper, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _mapper = mapper;
            _userManager = userManager;
            //_emailService = emailService;
            _roleManager = roleManager;
            _userService = userService;
            _env = env;
        }
        public async Task<List<TraineeViewModel>> GetAll(string? GeneralSearch)
        {
            var advisers = await _db.Trainees
                .Include(u => u.ApplicationUser)
                 .Include(u => u.Meeeting).Include(u => u.Documents).Include(u => u.TraingProgrameTrainee)
				.Where(x => (x.IsDelete == false)
            && (x.FirstName.Contains(GeneralSearch)
            || string.IsNullOrWhiteSpace(GeneralSearch)
            || x.ApplicationUser.Email.Contains(GeneralSearch)
            || x.ApplicationUser.PhoneNumber.Contains(GeneralSearch)))
            .OrderByDescending(x => x.CreatedAt).Include(u => u.ApplicationUser).Select(t => new TraineeViewModel
            {
                Id = t.Id,
                FirstName = t.FirstName,
				LastName = t.LastName,
				TraineeId = t.TraineeId,
				GenderType = t.GenderType,            
				Email = t.ApplicationUser.Email,
                CreatedAt = t.CreatedAt,
             }).ToListAsync();
            return advisers;
        }
        public async Task<TraineeViewModel> Detailes(int? id)
        {
            if (id is null)
            {
                var modelId = await _db.Trainees
								  .Include(u => u.ApplicationUser)
				 .Include(u => u.Meeeting).Include(u => u.Documents).Include(u => u.TraingProgrameTrainee)
					 .OrderByDescending(x => x.CreatedAt)
                     .FirstOrDefaultAsync(x => !x.IsDelete == true);
                id = modelId.Id;
            }
            var model = await _db.Trainees
				   .Include(u => u.ApplicationUser)
				 .Include(u => u.Meeeting).Include(u => u.Documents).Include(u => u.TraingProgrameTrainee)

				.SingleOrDefaultAsync(x => x.Id == id &&
                !x.IsDelete == true);
            if (model == null)
            {
                throw new EntityNotFoundException();
            }
            var traineeViewModel = new TraineeViewModel()
            {
				Id = model.Id,
				FirstName = model.FirstName,
				LastName = model.LastName,
				TraineeId = model.TraineeId,
				GenderType = model.GenderType,
				Email = model.ApplicationUser.Email,
				CreatedAt = model.CreatedAt,
			};
            return traineeViewModel;
        }
		public TraineeViewModel Detailes(string? UserId)
		{
			if (UserId is null)
			{
				return null;
			}
			if (UserId is not null)
			{
				var modelId =  _db.Trainees
				   .Include(u => u.ApplicationUser)
				 .Include(u => u.Meeeting).Include(u => u.Documents).Include(u => u.TraingProgrameTrainee)
					 .OrderByDescending(x => x.CreatedAt)
					 .FirstOrDefault(x => !x.IsDelete == true);
				if (modelId == null)
				{
					throw new Exception();
				}
				UserId = modelId.ApplicationUserId;
			}
			var model =  _db.Trainees
				   .Include(u => u.ApplicationUser)
				 .Include(u => u.Meeeting).Include(u => u.Documents).Include(u => u.TraingProgrameTrainee)
				.SingleOrDefault(x => x.ApplicationUserId == UserId &&
				!x.IsDelete == true);
			if (model == null)
			{
				throw new EntityNotFoundException();
			}
			var traineeViewModel = new TraineeViewModel()
			{
				Id = model.Id,
				FirstName = model.FirstName,
				LastName = model.LastName,
				TraineeId = model.TraineeId,
				GenderType = model.GenderType,
				Email = model.ApplicationUser.Email,
				CreatedAt = model.CreatedAt,
			};
			return traineeViewModel;
		}
		public async Task<int> Create(CreateTraineeDto dto, string? userId)
        {
            var emailOrPhoneIsExist = _db.Trainees.Include(u => u.ApplicationUser).Include(u => u.Meeeting).Include(u => u.Documents).Include(u => u.TraingProgrameTrainee)
                .Any(x => !x.IsDelete == true);
            dto.TraineeId = "Trainng" + Guid.NewGuid().ToString().Substring(0, 6);
            var model = _mapper.Map<Trainee>(dto);
            if (model == null)
            {
                throw new EntityNotFoundException();
            }
            await _db.Trainees.AddAsync(model);
            await _db.SaveChangesAsync();
            try
            {
				model.ApplicationUserId = userId;
                _db.Trainees.Update(model);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
            }
            //await _emailService.Send(user.Email, "New Account !", $"Username is : {user.Email} and Password is { password }");
            return model.Id;
        }
        public async Task<int> Update(Trainee dto)
        {
            var emailOrPhoneIsExist = _db.Trainees
                .Any(x => !(bool)x.IsDelete
            && (x.ApplicationUser.Email == dto.ApplicationUser.Email ||
            x.ApplicationUser.PhoneNumber == dto.ApplicationUser.PhoneNumber &&
            x.Id == dto.Id)
            && x.Id != dto.Id);
            if (emailOrPhoneIsExist)
            {
                throw new DuplicateEmailOrPhoneException();
            }
            _db.Trainees.Update(dto);
            await _db.SaveChangesAsync();
            return dto.Id;
        }
        public async Task<string> Delete(int Id)
        {
            var model = await _db.Trainees.SingleOrDefaultAsync(x => x.Id == Id && !(bool)x.IsDelete);
            if (model == null)
            {
                throw new EntityNotFoundException();
            }
			model.IsDelete = true;
            _db.Trainees.Update(model);
             await _db.SaveChangesAsync();
            return model.Id.ToString();


        }
        public async Task<UpdateTraineeDto> Get(int Id)
        {
            var model = await _db.Trainees.Include(x => x.ApplicationUser).SingleOrDefaultAsync(x => x.Id == Id && !(bool)x.IsDelete);
            if (model == null)
            {
                throw new EntityNotFoundException();
            }
            var mapper = _mapper.Map<UpdateTraineeDto>(model);
            return mapper;
        }
		public async Task<TraineeViewModel> SearchByTraineeId(string traineeId)
		{
			var model = await _db.Trainees.Include(x => x.ApplicationUser).SingleOrDefaultAsync(x => x.TraineeId == traineeId && !(bool)x.IsDelete);
			if (model == null)
			{
				throw new EntityNotFoundException();
			}
			var mapper = _mapper.Map<TraineeViewModel>(model);
			return mapper;
		}

        public async Task<Trainee> FindById(int Id)
        {
            var adviser = await _db.Trainees.SingleOrDefaultAsync(x => x.Id == Id && !(bool)x.IsDelete);
            if (adviser == null)
            {
                throw new EntityNotFoundException();
            }
            return adviser;
        }
    }
}
