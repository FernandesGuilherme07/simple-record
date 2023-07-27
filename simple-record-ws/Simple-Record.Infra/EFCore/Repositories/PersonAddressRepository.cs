using Microsoft.EntityFrameworkCore;
using simple_record.service.InputModels;
using simple_record.service.Models;
using simple_record.service.Repositories;

namespace simple_record.infra.EFCore.Repositories
{
    public class PersonAddressRepository : IPersonAddressRepository
    {
        private readonly ApplicationDbContext _context;

        public PersonAddressRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddPersonAddressAsync(CreateAddressPersonInputModel model)
        {
            _context.Addresses.Add(model.FromEntityToModel());
            await _context.SaveChangesAsync();
        }

        public async Task DeletePersonAddressAsync(DeleteAddressPersonInputModel model)
        {

            var addressPerson = await _context.Addresses.FindAsync(model.Id);

            if (addressPerson != null)
            {
                _context.Addresses.Remove(addressPerson);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<PersonAddressModel> GetPersonAddressByIdAsync(GetAddressPersonByIdInputModel model)
        {
            var addressPerson = await _context.Addresses
                .Where(ap => ap.Id == model.Id)
                .Select(ap => new PersonAddressModel
                {
                    Id = ap.Id,
                    // Mapear os dados da entidade AddressPerson para o modelo AddressPersonModel
                    // Por exemplo: AddressType, Street, Number, Complement, etc.
                })
                .FirstOrDefaultAsync();

            return addressPerson;
        }
    }
}