using Microsoft.EntityFrameworkCore;
using simple_record.service.InputModels;
using simple_record.service.Models;
using simple_record.service.Repositories;
using simple_record.service.ViewModels;

namespace simple_record.infra.EFCore.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ApplicationDbContext _context;

        public PersonRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreatePersonAsync(CreatePersonInputModel model)
        {
            await _context.Person.AddAsync(model.ToPersonModel());
            await _context.SaveChangesAsync();
        }

        public async Task DeletePersonAsync(DeletePersonInputModel model)
        {
            var person = await _context.Person.FindAsync(model.Id);
          
            _context.Person.Remove(person);
            await _context.SaveChangesAsync();
            
        }
        public async Task<List<GetAllPeoplesViewModel>> GetAllPeoplesAsync(GetAllPeoplesInputModel model)
        {
            var query = _context.Person.Include(p => p.Addresses).AsQueryable();

            // Aplicar filtros diretamente na consulta LINQ
            if (!string.IsNullOrWhiteSpace(model.SearchTerm))
            {
                query = query.Where(x => x.Document.Contains(model.SearchTerm) || x.Name.ToLower().Contains(model.SearchTerm.ToLower()));
            }

            // Aplicar paginação, se fornecido o número da página e tamanho da página
            if (model.PageNumber.HasValue && model.PageSize.HasValue)
            {
                // Total de itens antes da paginação
                var totalItems = await query.CountAsync();

                query = Paginate(query, model, totalItems);
            }

            // Executar a consulta final para obter os resultados
            var people = await query.ToListAsync();

            var viewModel = new GetAllPeoplesViewModel().ToListFromModel(people);


            return viewModel;
        }

        public async Task<GetPersonByIdViewModel> GetPersonByIdAsync(GetPersonByIdInputModel model)
        {
            var person = await _context.Person
              .Include(p => p.Addresses) // Incluindo os endereços relacionados
              .FirstOrDefaultAsync(p => p.Id == model.Id);

            var viewModel = new GetPersonByIdViewModel()
            {
                Addresses = person.Addresses,
                Contact = person.Contact,
                Document = person.Document,
                Email = person.Email,
                Id = person.Id,
                Name = person.Name
            };

            return viewModel;
        }

        public async Task UpdatePersonAsync(UpdatePersonInputModel model)
        {
            var person = await _context.Person
                .Include(p => p.Addresses)
                .FirstOrDefaultAsync(p => p.Id == model.Id);

            if (person != null)
            {
                // Atualize os dados do objeto person com base nos dados do model
                person.Name = model.Name;
                person.Document = model.Document;
                person.Type = model.Type;
                person.Contact = model.Contact;
                person.Email = model.Email;
                person.Addresses = model.Addresses;
               
                await _context.SaveChangesAsync();
            }
        }



        private IQueryable<PersonModel> Paginate(IQueryable<PersonModel> query, GetAllPeoplesInputModel model, int totalItems)
        {
            var totalPages = (int)Math.Ceiling((double)totalItems / model.PageSize.Value);

            // Garantir que o número da página esteja dentro dos limites
            if (model.PageNumber < 1)
            {
                model.PageNumber = 1;
            }
            else if (model.PageNumber > totalPages)
            {
                model.PageNumber = totalPages;
            }

            // Verificar se o tamanho da página é maior que 0
            if (model.PageSize <= 0)
            {
                model.PageSize = 10; // Ou defina um valor padrão apropriado
            }

            // Ordenar por nome antes de aplicar a paginação
            query = query.OrderBy(p => p.Name);

            // Calcular o valor de Skip, evitando valores negativos ou maiores que o total de itens
            var skip = (model.PageNumber.Value - 1) * model.PageSize.Value;
            if (skip < 0)
            {
                skip = 0;
            }
            else if (skip >= totalItems)
            {
                skip = (totalPages - 1) * model.PageSize.Value;
            }

            // Aplicar a paginação diretamente na consulta LINQ
            return query
                .Skip(skip)
                .Take(model.PageSize.Value);
        }


    }
}
