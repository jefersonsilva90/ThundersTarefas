using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ThunderTarefas.Application.Interfaces;
using ThunderTarefas.Application.Mappings;
using ThunderTarefas.Application.Notificacoes;
using ThunderTarefas.Application.Services;
using ThunderTarefas.Data.Context;
using ThunderTarefas.Data.Repositories;
using ThunderTarefas.Domain.Interfaces;

namespace ThunderTarefas.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
                                                            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
             options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"
            ), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<ITarefaRespository, TarefaRepository>();

            services.AddScoped<ITarefaService, TarefaService>();
            services.AddScoped<INotificador, Notificador>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            var myhandlers = AppDomain.CurrentDomain.Load("ThunderTarefas.Application");
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(myhandlers));

            return services;
        }
    }
}

