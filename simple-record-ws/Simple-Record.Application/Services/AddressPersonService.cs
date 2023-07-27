using simple_record.service.InputModels;
using simple_record.service.Repositories;
using simple_record.service.Services.Contracts;

namespace simple_record.service.Services
{
    public class AddressPersonService : IAddressPersonService
    {   
        private readonly IPersonAddressRepository _repository;
        private readonly IPersonRepository _personRepository;

        public AddressPersonService(IPersonAddressRepository repository, IPersonRepository personRepository)
        {
            _repository = repository;
            _personRepository = personRepository;
        }

        public async Task<GenericServiceResult> CreateAddressPerson(CreateAddressPersonInputModel model)
        {
            var getPersonByIdInputModel = new GetPersonByIdInputModel()
            {
                Id = model.PersonId
            };
            var person = await _personRepository.GetPersonByIdAsync(getPersonByIdInputModel);

            if (person == null)
            {
                return new GenericServiceResult("Invalid Id", false, null, null);
            }
            var data = model.ToEntity();
            if (!data.Valid)
            {
                return new GenericServiceResult("Invalid data", false, null, data.Notifications);
            }

            await _repository.AddPersonAddressAsync(model);

            return new GenericServiceResult("Created AddressPerson", true, data, data.Notifications);
        }

        public async Task<GenericServiceResult> DeleteAddressPerson(DeleteAddressPersonInputModel model)
        {
            var getPersonByIdInputModel = new GetPersonByIdInputModel()
            {
                Id = model.PersonId
            };
            var person = await _personRepository.GetPersonByIdAsync(getPersonByIdInputModel);

            if (person == null)
            {
                return new GenericServiceResult("Invalid Id", false, null, null);
            }

            await _repository.DeletePersonAddressAsync(model);

            return new GenericServiceResult("Deleted AddressPerson", true, null, null);
        }
    }
}
