using Microsoft.AspNetCore.Identity;
using Training_Management.Dtos;
using TrainingManagement.Dtos;
using TrainingManagement.Helpers;
using TrainingManagement.ViewModels;

namespace TrainingManagement.Services
{
    public interface IUserService
    {
        Task<List<UserViewModel>> GetAll(string? GeneralSearch);
        Task<List<UserViewModel>> GetBasicinfo(string? GeneralSearch);
        Task<UserViewModel> Detailes(string? id);
        Task<string> Create(CreateApplicationUserDto dto);
        Task<string> Update(UpdateApplicationUserDto dto);
        Task<string> Delete(string Id);
        Task<UpdateApplicationUserDto> Get(string Id);
        UserViewModel GetUserByName(string UserName);
        UserViewModel GetUserByEmailAllUsers(string UserName);
        Task<IEnumerable<UserViewModel>> GetBasicinfo(Querys querys);
        Task<SignInResult> Login(string UserName, string Password);
        Task<UserViewModel> GetUserByNameAsync(string UserName);
        Task SaveFcmToken(DeviceTokenRequest dto, string userId);
    }
}
