using simple_record.core.entities;
using simple_record.core.enums;
using simple_record.service.InputModels;
using simple_record.service.Repositories;
using simple_record.service.Services.Contracts;

namespace simple_record.service.Services
{
    public class PersonServices : IPersonServices
    {
        private readonly IPersonRepository _repository;
        public PersonServices(IPersonRepository repository)
        {
            _repository = repository;
        }

        async public Task<GenericServiceResult> CreatePerson(CreatePersonInputModel model)
        {
            Person person;
            switch (model.Type)
            {
                case PersonTypes.Legal:
                    person = model.ToEntityLegalPerson();
                    break;
                default:
                    person = model.ToEntityPhysicalPerson();
                    break;
            }

            if (!person.Valid)
            {
                return new GenericServiceResult("Invalid person data", false, null, person.Notifications);
            }
            await _repository.CreatePersonAsync(model);

            return new GenericServiceResult("OK", true, model, null);
        }

        public async Task<GenericServiceResult> DeletePerson(DeletePersonInputModel model)
        {
            var getPersonByIdInputModel = new GetPersonByIdInputModel()
            {
                Id = model.Id
            };
            var person = await _repository.GetPersonByIdAsync(getPersonByIdInputModel);

            if (person == null)
            {
                return new GenericServiceResult("Invalid Id", false, null, null);
            }

            await _repository.DeletePersonAsync(model);
            return new GenericServiceResult("Deleted Person Successfull", true, null, null);
        }

        public async Task<GenericServiceResult> GetAllPeoples(GetAllPeoplesInputModel model)
        {
            var data = await _repository.GetAllPeoplesAsync(model);
            return new GenericServiceResult("OK", true, data, null);
        }

        public async Task<GenericServiceResult> GetPersonById(GetPersonByIdInputModel model)
        {
            var person = await _repository.GetPersonByIdAsync(model);

            if (person == null)
            {
                return new GenericServiceResult("Invalid Id", false, null, null);
            }

            return new GenericServiceResult("OK", true, person, null);
        }

        public async Task<GenericServiceResult> UpdatePerson(UpdatePersonInputModel model)
        {
            model.Validate();

            if (!model.Valid)
            {
                return new GenericServiceResult("Invalid person data", false, model.Notifications, null);
            }

            var getPersonByIdInputModel = new GetPersonByIdInputModel()
            {
                Id = model.Id
            };
            var person = await _repository.GetPersonByIdAsync(getPersonByIdInputModel);

            if (person == null)
            {
                return new GenericServiceResult("Invalid Id", false, null, null);
            }

            await _repository.UpdatePersonAsync(model);
            var data = await _repository.GetPersonByIdAsync(new GetPersonByIdInputModel() { Id = model.Id });

            return new GenericServiceResult("Updated", true, data, null);
        }
    }
}
