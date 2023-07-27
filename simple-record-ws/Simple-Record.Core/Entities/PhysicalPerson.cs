using simple_record.core.enums;

namespace simple_record.core.entities
{
    public class PhysicalPerson : Person
    {
        public PhysicalPerson(
            string name,
            string contact,
            PersonTypes type,
            string? email,
            string cpf,
            List<Address> addresses
            ) : base(contact, type, email, addresses )
        {
            Name = name;
            CPF = cpf;

            Validate();
        }

        public string Name { get; private set; }
        public string CPF { get; private set; }

        public void UpdatePhysicalPerson(
            string? name,
            string? contact,
            string? email
            )
        {   if ( name != null ) Name = name;
            if ( contact != null ) Contact = contact;
            if ( email != null ) Email = email;

            Validate();
        }

        private void Validate()
        {
            AddNotifications(
                new DomainContract()
                    .IsCpfValid(CPF, "Cpf", "Invalid CPF")
                    .Requires()
                    .IsNotNullOrEmpty(Name, nameof(Name), "Corporate Name cannot be empty.")

                );

        }
    }
}
