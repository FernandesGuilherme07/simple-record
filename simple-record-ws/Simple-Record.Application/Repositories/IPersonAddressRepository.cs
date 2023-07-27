using simple_record.core.entities;
using simple_record.service.InputModels;
using simple_record.service.Models;

namespace simple_record.service.Repositories
{
    public interface IPersonAddressRepository
    {
        Task AddPersonAddressAsync(CreateAddressPersonInputModel model);
        Task DeletePersonAddressAsync(DeleteAddressPersonInputModel model);

        Task<PersonAddressModel> GetPersonAddressByIdAsync(GetAddressPersonByIdInputModel model);
    }
}
