using simple_record.core.entities;
using simple_record.core.enums;
using simple_record.service.Models;

namespace simple_record.service.InputModels
{
    public class CreateAddressPersonInputModel
    {
        public Guid PersonId { get; set; }  
        public AddressType Type { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string? Complement { get; set; }
        public string Neighborhood { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public Address ToEntity() => new Address(Type, Street, Number, Neighborhood, ZipCode, City, State, Complement);

        public PersonAddressModel FromEntityToModel() => new PersonAddressModel()
        {
            PersonId = PersonId,
            Type = ToEntity().Type,
            Street = ToEntity().Street,
            Number = ToEntity().Number,
            Complement = ToEntity().Complement,
            Neighborhood = ToEntity().Neighborhood,
            ZipCode = ToEntity().ZipCode,
            City = ToEntity().City,
            State = ToEntity().State,
        };
    }
}
