using Training_Management.Dtos;
using Training_Management.Models;
using Training_Management.ViewModels;
using TrainingManagement.Dtos;

namespace TrainingManagement.Services
{
    public interface ITrainingProgrammeService
    {
        Task<List<TrainingProgrammeViewModel>> GetAll(string? GeneralSearch);
		Task<int> Create(CreateTrainigProgrameDto dto);
        Task<string> Delete(int Id);
     }
}
