using simple_record.core.enums;
using simple_record.service.Models;

namespace simple_record.service.ViewModels
{
    public class GetAllPeoplesViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public PersonTypes Type { get; set; }
        public string Contact { get; set; }
        public string? Email { get; set; }
        public List<PersonAddressModel> AddressesResidentials { get; set; }
        public List<PersonAddressModel> AddressesCommercials { get; set; }

        public List<GetAllPeoplesViewModel> ToListFromModel(List<PersonModel> peopleModels)
        {
            return peopleModels.Select(person => new GetAllPeoplesViewModel
            {
                Id = person.Id,
                Name = person.Name,
                Document = person.Document,
                Type = person.Type,
                Contact = person.Contact,
                Email = person.Email,
                AddressesResidentials = person.Addresses.Where(address => address.Type == AddressType.Residential).ToList(),
                AddressesCommercials = person.Addresses.Where(address => address.Type == AddressType.Commercial).ToList(),
            }).ToList();
        }
    }
}
