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
    public class ManagerService : IManagerService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public readonly IUserService _userService;
        private readonly IWebHostEnvironment _env;
        public ManagerService(IWebHostEnvironment env, IUserService userService,/*IEmailService emailService,*/ ApplicationDbContext db, IMapper mapper, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _mapper = mapper;
            _userManager = userManager;
            //_emailService = emailService;
            _roleManager = roleManager;
            _userService = userService;
            _env = env;
        }



        public async Task<List<ManagerViewModel>> GetAll(string? GeneralSearch)
        {
            var advisers = await _db.Managers.Include(u => u.ApplicationUser)
                 .Include(u => u.Trainees)
                .Where(x => (x.IsDelete == false)
            && (x.Name.Contains(GeneralSearch)
            || string.IsNullOrWhiteSpace(GeneralSearch)
            || x.ApplicationUser.Email.Contains(GeneralSearch)
            || x.ApplicationUser.PhoneNumber.Contains(GeneralSearch)))
            .OrderByDescending(x => x.CreatedAt).Include(u => u.ApplicationUser).Select(adviser => new ManagerViewModel
            {
                Id = adviser.Id,
                Name = adviser.Name,
                Email = adviser.ApplicationUser.Email,
                CreatedAt = adviser.CreatedAt,
             }).ToListAsync();
            return advisers;
        }
        public async Task<ManagerViewModel> Detailes(int? id)
        {
            if (id is null)
            {
                var adviserId = await _db.Managers.
                    Include(u => u.ApplicationUser)
                  .Include(u => u.Trainees)
                     .OrderByDescending(x => x.CreatedAt)
                     .FirstOrDefaultAsync(x => !x.IsDelete == true);
                id = adviserId.Id;
            }
            var adviser = await _db.Managers.
                    Include(u => u.ApplicationUser)
                  .Include(u => u.Trainees)

                .SingleOrDefaultAsync(x => x.Id == id &&
                !x.IsDelete == true);
            if (adviser == null)
            {
                throw new EntityNotFoundException();
            }
            var AdviserViewModel = new ManagerViewModel()
            {
                Id = adviser.Id,
                Name = adviser.Name,
                Email = adviser.ApplicationUser.Email,
                CreatedAt = adviser.CreatedAt,
            };
            return AdviserViewModel;
        }

		public ManagerViewModel Detailes(string? UserId)
		{
			if (UserId is null)
			{
				return null;
			}
			if (UserId is not null)
			{
				var adviserId = _db.Managers.
					Include(u => u.ApplicationUser)
				  .Include(u => u.Trainees)
					 .OrderByDescending(x => x.CreatedAt)
					 .FirstOrDefault(x => !x.IsDelete == true);
				if (adviserId == null)
				{
					throw new Exception();
				}
				UserId = adviserId.ApplicationUserId;
			}
			var adviser = _db.Managers.Include(u => u.ApplicationUser).Include(u => u.Trainees)

				.SingleOrDefault(x => x.ApplicationUserId == UserId &&
				!x.IsDelete == true);
			if (adviser == null)
			{
				throw new EntityNotFoundException();
			}
			var AdviserViewModel = new ManagerViewModel()
			{
				Id = adviser.Id,
				Name = adviser.Name,
				Email = adviser.ApplicationUser.Email,
				CreatedAt = adviser.CreatedAt,
			};
			return AdviserViewModel;
		}

		public async Task<int> Create(CreateManagerDto dto, string? userId)
        {
            var emailOrPhoneIsExist = _db.Managers.Include(u => u.ApplicationUser).Include(u => u.Trainees)
                .Any(x => !x.IsDelete == true);

            var adviser = _mapper.Map<Manager>(dto);
            if (adviser == null)
            {
                throw new EntityNotFoundException();
            }
            await _db.Managers.AddAsync(adviser);
            await _db.SaveChangesAsync();
            try
            {
                adviser.ApplicationUserId = userId;
                _db.Managers.Update(adviser);
                _db.SaveChanges();

            }
            catch (Exception e)
            {
            }


            //await _emailService.Send(user.Email, "New Account !", $"Username is : {user.Email} and Password is { password }");
            return adviser.Id;
        }
        public async Task<int> Update(Manager dto)
        {
            var emailOrPhoneIsExist = _db.Managers.Include(u => u.ApplicationUser).Include(u => u.Trainees)
                .Any(x => !(bool)x.IsDelete
            && (x.ApplicationUser.Email == dto.ApplicationUser.Email ||
            x.ApplicationUser.PhoneNumber == dto.ApplicationUser.PhoneNumber &&
            x.Id == dto.Id)
            && x.Id != dto.Id);
            if (emailOrPhoneIsExist)
            {
                throw new DuplicateEmailOrPhoneException();
            }
            _db.Managers.Update(dto);
            await _db.SaveChangesAsync();
            return dto.Id;
        }
        public async Task<string> Delete(int Id)
        {
            var adviser = await _db.Managers.SingleOrDefaultAsync(x => x.Id == Id && !(bool)x.IsDelete);
            if (adviser == null)
            {
                throw new EntityNotFoundException();
            }
            adviser.IsDelete = true;
            _db.Managers.Update(adviser);
             await _db.SaveChangesAsync();
            return adviser.Id.ToString();


        }
        public async Task<UpdateManagerDto> Get(int Id)
        {
            var adviser = await _db.Managers.Include(x => x.ApplicationUser).SingleOrDefaultAsync(x => x.Id == Id && !(bool)x.IsDelete);
            if (adviser == null)
            {
                throw new EntityNotFoundException();
            }
            var mapper = _mapper.Map<UpdateManagerDto>(adviser);
            return mapper;
        }
        public async Task<Manager> FindById(int Id)
        {
            var adviser = await _db.Managers.SingleOrDefaultAsync(x => x.Id == Id && !(bool)x.IsDelete);
            if (adviser == null)
            {
                throw new EntityNotFoundException();
            }
            return adviser;
        }



    }
}
