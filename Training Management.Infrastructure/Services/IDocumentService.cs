using Training_Management.Dtos;
using Training_Management.Models;

namespace Training_Management.Services
{
    public interface IDocumentService
    {
        void Delete(string Id);
        Task<int> Create(CreateDocumentDto dto);
        Task<List<DocumentViewModel>> GetAll(int id);
    }
}
