using Microsoft.Extensions.DependencyInjection;
using simple_record.infra.EFCore.Repositories;
using simple_record.service.Repositories;

namespace simple_record.infra
{
    public static class InfraModule
    {
        public static IServiceCollection AddInfra(this IServiceCollection services)
        {

            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IPersonAddressRepository, PersonAddressRepository>();

            return services;
        }

    
    }
}