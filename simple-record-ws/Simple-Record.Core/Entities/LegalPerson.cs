using simple_record.core.enums;

namespace simple_record.core.entities
{
    public class LegalPerson : Person
    {
        public LegalPerson(
          string corporateName,
          string contact,
          PersonTypes type,
          string? email,
          string cNPJ,
          List<Address> addresses) : base(contact, type, email, addresses)
        {
            CorporateName = corporateName;
            CNPJ = cNPJ;

            Validate();
        }
        public string CorporateName { get; private set; }
        public string CNPJ { get; private set; }

        public void UpdatePhysicalPerson(
         string? corporateName,
         string? contact,
         string? email
         )
        {
            if (corporateName != null) CorporateName = corporateName;
            if (contact != null) Contact = contact;
            if (email != null) Email = email;

            Validate();
        }

        private void Validate()
        {
            AddNotifications(
                new DomainContract()
                    .IsCnpjValid(CNPJ, "Cnpj", "Invalid CNPJ")
                    .Requires()
                    .IsNotNullOrEmpty(CorporateName, nameof(CorporateName), "Corporate Name cannot be empty.")
                     
                );

        }
    }
}
