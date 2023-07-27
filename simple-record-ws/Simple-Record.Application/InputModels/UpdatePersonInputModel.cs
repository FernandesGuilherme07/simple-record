using Flunt.Notifications;
using simple_record.core;
using simple_record.core.entities;
using simple_record.core.enums;
using simple_record.service.Models;

namespace simple_record.service.InputModels
{ 
    public class UpdatePersonInputModel : Notifiable
        {
        public UpdatePersonInputModel(
        Guid id,
         string name,
         string document,
         PersonTypes type,
         string contact,
         string? email,
         List<PersonAddressModel> addresses
     )
        {
            Id = id;
            Name = name;
            Document = document;
            Type = type;
            Contact = contact;
            Email = email;
            Addresses = addresses;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public PersonTypes Type { get; set; }
        public string Contact { get; set; }
        public string? Email { get; set; }
        public List<PersonAddressModel> Addresses { get; set; }

        public LegalPerson ToEntityLegalPerson() => new LegalPerson(Name, Contact, Type, Email, Document, FromAddressList());
        public PhysicalPerson ToEntityPhysicalPerson() => new PhysicalPerson(Name, Contact, Type, Email, Document, FromAddressList());

        public List<Address> FromAddressList()
        {
            var personAddressModels = new List<Address>();

            foreach (var address in Addresses)
            {
                var personAddressModel = new Address(address.Type, address.Street, address.Number, address.Neighborhood, address.ZipCode, address.City, address.State, address.Complement);

                personAddressModels.Add(personAddressModel);
            }

            return personAddressModels;
        }

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

        public void Validate()
        {
            AddNotifications(
            new DomainContract()
                .Requires()
            .IsNotNullOrEmpty(Name, nameof(Name), "Name cannot be empty.")
            .IsNotNullOrEmpty(Contact, nameof(Contact), "Contact cannot be empty.")
            .IsNotNull(Id, nameof(Id), "Id cannot be null.")
            );

        }

    }
}


