using simple_record.service.InputModels;
using simple_record.service.ViewModels;

namespace simple_record.service.Repositories
{
    public interface IPersonRepository
    {
        Task CreatePersonAsync(CreatePersonInputModel model);
        Task<List<GetAllPeoplesViewModel>> GetAllPeoplesAsync(GetAllPeoplesInputModel model);
        Task<GetPersonByIdViewModel> GetPersonByIdAsync(GetPersonByIdInputModel model);
        Task UpdatePersonAsync(UpdatePersonInputModel model);
        Task DeletePersonAsync(DeletePersonInputModel model);
    }
}
