
using Microsoft.Extensions.DependencyInjection;
using simple_record.service.Services;
using simple_record.service.Services.Contracts;

namespace Simple_Record.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddApplicationServices();

            return services;
        }

        private static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IPersonServices, PersonServices>();
            services.AddScoped<IAddressPersonService, AddressPersonService>();

            return services;
        }
    }
}
