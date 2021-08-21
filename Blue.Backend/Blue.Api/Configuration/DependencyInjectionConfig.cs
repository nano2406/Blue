using Blue.Domain.Interface;
using Blue.Domain.Services;
using Blue.Infra.Context;
using Blue.Infra.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Blue.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {

            services.AddScoped<IContatoRepository, ContatoRepository>();
            services.AddScoped<IContatoService, ContatoService>();
            services.AddDbContext<BlueContext>();

            return services;
        }
    }
}
