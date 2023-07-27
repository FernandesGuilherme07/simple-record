using simple_record.core.enums;

namespace simple_record.core.entities
{
    public abstract class Person :  EntityBase
    {
        public Person(string contact, PersonTypes type, List<Address> addresses)
        {
            Type = type;
            Contact = contact;
            Addresses = addresses;
            Validate();
        }
        public Person( string contact, PersonTypes type, string? email, List<Address> addresses)
        {
            Type = type;
            Contact = contact;
            Email = email;
            Addresses = addresses;
            Validate();
        }
        public PersonTypes Type { get; private set; }
        public string Contact { get; protected set; }
        public string? Email { get; protected set; }
        public List<Address> Addresses { get; private set; }

        public void AddAdresses (List<Address> addresses)
        {
            Addresses.AddRange(addresses);
        }

        private void Validate()
        {
            AddNotifications(
                new DomainContract()
                    .Requires()
                    .IsNotNullOrEmpty(Contact, nameof(Contact), "Contact cannot be empty.")
                    .IsNotNull(Type, nameof(Type), "Type cannot be null.")
                    .IsNotNull(Addresses, nameof(Addresses), "Addresses cannot be null.")
                    .IsLowerOrEqualsThan(0, Addresses.Count, nameof(Addresses), "Addresses must have at least one entry.")
                    .IfNotNull(Email, x => x.IsEmail(Email, nameof(Email), "Invalid email format."))
                );

        }
    }
}
