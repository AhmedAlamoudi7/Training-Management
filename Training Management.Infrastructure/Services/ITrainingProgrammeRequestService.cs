using Training_Management.Dtos;
using Training_Management.Models;
using Training_Management.ViewModels;
using TrainingManagement.Dtos;

namespace TrainingManagement.Services
{
    public interface ITrainingProgrammeRequestService
    {
        Task<List<TrainingProgrammeRequestViewModel>> GetAll(string? GeneralSearch);
		Task<int> Create(CreateTrainingProgrammRequestDto dto);
        Task<string> Delete(int Id);
        Task ChangeActive(int Id);
     }
}
