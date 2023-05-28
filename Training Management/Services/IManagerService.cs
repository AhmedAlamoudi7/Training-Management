 using Training_Management.Dtos;
using Training_Management.Models;
using Training_Management.ViewModels;
using TrainingManagement.Dtos;

namespace TrainingManagement.Services
{
    public interface IManagerService
    {
        Task<List<ManagerViewModel>> GetAll(string? GeneralSearch);
        Task<ManagerViewModel> Detailes(int? id);
        ManagerViewModel Detailes(string? UserId);
        Task<Manager> FindById(int Id);
        Task<int> Create(CreateManagerDto dto, string? userId);
        Task<int> Update(Manager dto);
        Task<string> Delete(int Id);
        Task<UpdateManagerDto> Get(int Id);
    }
}
