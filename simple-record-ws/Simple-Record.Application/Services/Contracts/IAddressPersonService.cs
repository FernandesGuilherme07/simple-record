using simple_record.service.InputModels;
using simple_record.service.Models;

namespace simple_record.service.Services.Contracts
{
    public interface IAddressPersonService
    {
        Task<GenericServiceResult> CreateAddressPerson(CreateAddressPersonInputModel model);
        Task<GenericServiceResult> DeleteAddressPerson(DeleteAddressPersonInputModel model);
    }
}
