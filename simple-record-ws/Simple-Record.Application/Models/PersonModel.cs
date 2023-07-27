using simple_record.core.enums;

namespace simple_record.service.Models
{
    public class PersonModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public PersonTypes Type { get; set; }
        public string Contact { get; set; }
        public string? Email { get; set; }
        public List<PersonAddressModel>? Addresses { get; set; }


    }
}
