using AutoMapper;
using LockKeyNew.Core.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using Training_Management.Data;
using Training_Management.Models;
using TrainingManagement.Constants;
using TrainingManagement.Dtos;
using TrainingManagement.Enums;
using TrainingManagement.Exceptions;
using TrainingManagement.Helpers;
using TrainingManagement.ViewModels;

namespace TrainingManagement.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserService(ApplicationDbContext db, IMapper mapper, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<List<UserViewModel>> GetAll(string? GeneralSearch)
        {
            var users = await _userManager.Users.Where(x =>
             (x.IsDelete == false)
            || string.IsNullOrWhiteSpace(GeneralSearch)
            || x.Email.Contains(GeneralSearch)
            || x.PhoneNumber.Contains(GeneralSearch))
            .OrderByDescending(x => x.CreatedAt).Select(user => new UserViewModel
            {
                Id = user.Id,
                Username = user.UserName,
                Email = user.Email,
                CreatedAt = user.CreatedAt,
                Phone = user.PhoneNumber,
                Roles = _userManager.GetRolesAsync(user).Result
            }).ToListAsync();
            return users;
        }
        public async Task<List<UserViewModel>> GetBasicinfo(string? GeneralSearch)
        {
            //	List<string> roles = await _roleManager.Roles.Where(x => x.Name == "Adviser").Select(x => x.Name).ToListAsync();
            var users = await _userManager.Users.Where(x =>
           (x.IsDelete == false)
            || string.IsNullOrWhiteSpace(GeneralSearch)
            || x.Email.Contains(GeneralSearch)
            || x.PhoneNumber.Contains(GeneralSearch))
            .OrderByDescending(x => x.CreatedAt).ToListAsync();
            return _mapper.Map<List<UserViewModel>>(users);
        }
        public async Task<UserViewModel> Detailes(string? id)
        {
            if (id is null)
            {
                var userId = await _db.Users.OrderByDescending(x => x.CreatedAt).FirstOrDefaultAsync(x => !x.IsDelete == true);
                id = userId.Id;
            }
            var user = await _db.Users.SingleOrDefaultAsync(x => x.Id == id && !x.IsDelete == true);
            if (user == null)
            {
                throw new EntityNotFoundException();
            }
            return _mapper.Map<UserViewModel>(user);
        }    
        public async Task<string> Create(CreateApplicationUserDto dto)
        {
            var emailOrPhoneIsExist = _db.Users.Any(x => !x.IsDelete == true && (x.Email == dto.Email || x.PhoneNumber == dto.Phone));
            if (emailOrPhoneIsExist)
            {
                throw new DuplicateEmailOrPhoneException();
            }
            var user = _mapper.Map<ApplicationUser>(dto);
            if (user == null)
            {
                throw new EntityNotFoundException();
            }
            user.UserName = dto.Email;
            try
            {
                var result = await _userManager.CreateAsync(user, dto.Password);
                if (!result.Succeeded)
                {
                    throw new OperationFailedException();
                }
              }
            catch (Exception e)
            {
            }
            //await _emailService.Send(user.Email, "New Account !", $"Username is : {user.Email} and Password is { password }");
            return user.Id;
        }
        public async Task<string> Update(UpdateApplicationUserDto dto)
        {
            var emailOrPhoneIsExist = _db.Users.Any(x => !(bool)x.IsDelete
            && (x.Email == dto.Email || x.PhoneNumber == dto.Phone && x.Id == dto.Id)
            && x.Id != dto.Id);
            if (emailOrPhoneIsExist)
            {
                throw new DuplicateEmailOrPhoneException();
            }
            var user = await _db.Users.FindAsync(dto.Id);
            var updatedUser = _mapper.Map<UpdateApplicationUserDto, ApplicationUser>(dto, user);
            _db.Users.Update(updatedUser);
            await _db.SaveChangesAsync();
            return user.Id;
        }
        public async Task<string> Delete(string Id)
        {
            var user = await _db.Users.SingleOrDefaultAsync(x => x.Id == Id && !(bool)x.IsDelete);
            if (user == null)
            {
                throw new EntityNotFoundException();
            }
            user.IsDelete = true;
            _db.Users.Update(user);

            return null;
        }
        public async Task<UpdateApplicationUserDto> Get(string Id)
        {
            var user = await _db.Users.SingleOrDefaultAsync(x => x.Id == Id && !(bool)x.IsDelete);
            if (user == null)
            {
                throw new EntityNotFoundException();
            }
            return _mapper.Map<UpdateApplicationUserDto>(user);
        }    
        public UserViewModel GetUserByName(string UserName)
        {
            var user = _db.Users.SingleOrDefault(x => (x.UserName == UserName || x.Email == UserName) && x.IsDelete == false);
            if (user == null)
            {
                return null;
            }
            var mapper = _mapper.Map<UserViewModel>(user);
            mapper.Roles = _userManager.GetRolesAsync(user).Result;
            return mapper;
        }
        public UserViewModel GetUserByEmailAllUsers(string email)
        {
            var user = _db.Users.SingleOrDefault(x => (x.UserName == new MailAddress(email).User || x.Email == email ));
            if (user == null)
            {
                return null;
            }
            var mapper = _mapper.Map<UserViewModel>(user);
            mapper.Roles = _userManager.GetRolesAsync(user).Result;
            return mapper;
        }
        public async Task<UserViewModel> GetUserByNameAsync(string UserName)
        {
            var user =await  _db.Users.SingleOrDefaultAsync(x => (x.UserName == UserName || x.Email == UserName) && x.IsDelete != true);
            if (user == null)
            {
                return null;
            }
            var mapper = _mapper.Map<UserViewModel>(user);
            mapper.Roles = _userManager.GetRolesAsync(user).Result;
            return mapper;
        }  
        public async Task<IEnumerable<UserViewModel>> GetBasicinfo(Querys querys)
        {
            var users = await _db.Users.Where(x => (x.IsDelete == false)
            || string.IsNullOrWhiteSpace(querys.GeneralSearch)
            || x.Email.Contains(querys.GeneralSearch)
            || x.PhoneNumber.Contains(querys.GeneralSearch))
            .OrderByDescending(x => x.CreatedAt).ToListAsync();
            var model = _mapper.Map<IEnumerable<UserViewModel>>(users);
            if (querys.RoleTypes == RoleTypes.Advisor)
            {
                var user = await _userManager.GetUsersInRoleAsync("Advisor");
                var userss = user.Where(x => x.IsDelete == false);
                model = _mapper.Map<IEnumerable<UserViewModel>>(userss);
                return model;
            }
            else if (querys.RoleTypes == RoleTypes.SuperAdmin)
            {
                var user = await _userManager.GetUsersInRoleAsync("SuperAdmin");
                var userss = user.Where(x => x.IsDelete == false);
                model = _mapper.Map<IEnumerable<UserViewModel>>(userss);
                return model;
			}
			else if (querys.RoleTypes == RoleTypes.Manager)
			{
				var user = await _userManager.GetUsersInRoleAsync("Manager");
				var userss = user.Where(x => x.IsDelete == false);
				model = _mapper.Map<IEnumerable<UserViewModel>>(userss);
				return model;
			}
			else if (querys.RoleTypes == RoleTypes.Trainee)
            {
                var user = await _userManager.GetUsersInRoleAsync("Trainee");
                var userss = user.Where(x => x.IsDelete == false);
                model = _mapper.Map<IEnumerable<UserViewModel>>(userss);
                return model;
            }
            return model;
        }
        public async Task<SignInResult> Login(string UserName, string Password)
        {
            var user = await _db.Users.SingleOrDefaultAsync(x => (x.UserName == UserName || x.Email == UserName) && x.IsDelete != true);
            if (user == null)
            {
                return SignInResult.Failed;
            }
            var result = await _userManager.CheckPasswordAsync(user, Password);
            if (!result)
            {
                return SignInResult.Failed;
            }
            return SignInResult.Success;
        }
    }
}
