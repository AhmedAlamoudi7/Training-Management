using Training_Management.Dtos;
using Training_Management.Models;
using Training_Management.ViewModels;
using TrainingManagement.Dtos;

namespace TrainingManagement.Services
{
    public interface IAdviserService
    {
        Task<List<AdvisorViewModel>> GetAll(string? GeneralSearch);
        Task<AdvisorViewModel> Detailes(int? id);
        AdvisorViewModel Detailes(string? UserId);

		Task<int> Create(CreateAdviserDto dto, string? userId);
        Task<int> Update(Advisor dto);
        Task<string> Delete(int Id);
        Task<UpdateAdviserDto> Get(int Id);
        Task<Advisor> FindById(int Id);
    }
}
