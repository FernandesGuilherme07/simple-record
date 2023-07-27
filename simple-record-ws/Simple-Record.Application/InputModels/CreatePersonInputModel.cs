using simple_record.core.entities;
using simple_record.core.enums;
using simple_record.service.Models;

namespace simple_record.service.InputModels
{
    public class CreatePersonInputModel
    {
        public CreatePersonInputModel(
         string name,
         string document,
         PersonTypes type,
         string contact,
         string? email,
         List<Address> addresses
     )
        {
            Name = name;
            Document = document;
            Type = type;
            Contact = contact;
            Email = email;
            Addresses = addresses;
        }

        public string Name { get; set; }
        public string Document { get; set; }
        public PersonTypes Type { get; set; }
        public string Contact { get; set; }
        public string? Email { get; set; }
        public List<Address> Addresses { get; set; }

        public LegalPerson ToEntityLegalPerson() => new LegalPerson(Name, Contact, Type, Email, Document, Addresses);
        public PhysicalPerson ToEntityPhysicalPerson() => new PhysicalPerson(Name, Contact, Type, Email, Document, Addresses);

        public PersonModel ToPersonModel()
        {
            var personModel = new PersonModel
            {
                Name = Name,
                Document = Document,
                Type = Type,
                Contact = Contact,
                Email = Email,
                Addresses = Addresses.Select(address => new PersonAddressModel
                {
                    Id = address.Id,
                    Type = address.Type,
                    Street = address.Street,
                    Number = address.Number,
                    Complement = address.Complement,
                    Neighborhood = address.Neighborhood,
                    ZipCode = address.ZipCode,
                    City = address.City,
                    State = address.State
                }).ToList()
            };

            return personModel;
        }

    }
}
