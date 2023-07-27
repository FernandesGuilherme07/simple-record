
using simple_record.service.InputModels;
using simple_record.service.Models;
using simple_record.service.ViewModels;

namespace simple_record.service.Services.Contracts
{
    public interface IPersonServices
    {
        Task<GenericServiceResult> CreatePerson(CreatePersonInputModel model);
        Task<GenericServiceResult> GetAllPeoples(GetAllPeoplesInputModel model);
        Task<GenericServiceResult> GetPersonById(GetPersonByIdInputModel model);
        Task<GenericServiceResult> UpdatePerson(UpdatePersonInputModel model);
        Task<GenericServiceResult> DeletePerson(DeletePersonInputModel model);
    }
}
