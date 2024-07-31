using HMS.Domain.Interfaces.Gateways;
using HMS.Domain.Interfaces.Repositories;
using HMS.Infra.Data.Context;
using HMS.Infra.Data.Repositories;
using HMS.Infra.Gateways.Gateways;
using HMS.Infra.Services.Interfaces;
using HMS.Infra.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HMS.Infra.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {

            #region Infrastructure            

            // Services
            services.AddScoped<IPacienteService, PacienteService>();



            // Gateways
            services.AddScoped<IPacienteGateway, PacienteGateway>();
            services.AddScoped<IUsuarioGateway, UsuarioGateway>();


            #endregion

            #region Data
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

            services.AddScoped<IPacienteRepository, PacienteRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();


            services.AddScoped<ApplicationDbContext>();
            #endregion


        }
    }
}