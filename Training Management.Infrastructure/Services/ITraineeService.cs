 using Training_Management.Dtos;
using Training_Management.Models;
using Training_Management.ViewModels;
using TrainingManagement.Dtos;

namespace TrainingManagement.Services
{
    public interface ITraineeService
	{
        Task<List<TraineeViewModel>> GetAll(string? GeneralSearch);
        Task<TraineeViewModel> Detailes(int? id);
		TraineeViewModel Detailes(string? UserId);

		Task<int> Create(CreateTraineeDto dto, string? userId);
        Task<int> Update(Trainee dto);
        Task<string> Delete(int Id);
        Task<UpdateTraineeDto> Get(int Id);
        Task<TraineeViewModel> SearchByTraineeId(string traineeId);
        Task<Trainee> FindById(int Id);

    }
}
