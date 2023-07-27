using simple_record.core.entities;
using simple_record.core.enums;
using simple_record.service.Models;

namespace simple_record.service.ViewModels
{
    public class GetPersonByIdViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public PersonTypes Type { get; set; }
        public string Contact { get; set; }
        public string? Email { get; set; }
        public List<PersonAddressModel> Addresses { get; set; }
    }
}
