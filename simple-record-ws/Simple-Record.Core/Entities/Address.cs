using simple_record.core.enums;

namespace simple_record.core.entities
{
    public class Address : EntityBase
    {
        public Address(
            AddressType type, 
            string street, 
            string? number, 
            string neighborhood, 
            string zipCode, 
            string city,
            string state,
            string? complement
            )
        {
            Type = type;
            Street = street;
            Number = number;
            Complement = complement;
            Neighborhood = neighborhood;
            ZipCode = zipCode;
            City = city;
            State = state;

            Validate();
        }

        public AddressType Type { get; private set; }
        public string Street { get; private set; }
        public string? Number { get; private set; }
        public string? Complement { get; private set; }
        public string Neighborhood { get; private set; }
        public string ZipCode { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }

        private void Validate()
        {
            AddNotifications(
            new DomainContract()
                 .Requires()
                .IsNotNullOrEmpty(Street, nameof(Street), "Street cannot be empty.")
                .IsNotNullOrEmpty(Neighborhood, nameof(Neighborhood), "Neighborhood cannot be empty.")
                .IsNotNullOrEmpty(ZipCode, nameof(ZipCode), "ZipCode cannot be empty.")
                .HasLen(ZipCode, 8, nameof(ZipCode), "ZipCode must have 8 characters.")
                .IsNotNullOrEmpty(City, nameof(City), "City cannot be empty.")
                .IsNotNullOrEmpty(State, nameof(State), "State cannot be empty.")
                );
        }
    }
}
