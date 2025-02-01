using HomeSecuritySystem.Application.Contracts.Presistance;
using HomeSecuritySystem.Persistence.DBContext;
using HomeSecuritySystem.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HomeSecuritySystem.Persistence
{
    public static class PersistenceServiceRegistration
    {

        public static IServiceCollection AddPersistenceServices(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HSSDatabaseContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("HomeSecuritySystemDB")));

            services.AddScoped(typeof(IGenericRepoistory<>), typeof(GenericRepository<>));
            services.AddScoped<IHomeRepository, HouseRepository>();
            services.AddScoped<IDeviceRepository, DeviceRepository>();
 
            return services;
        }
    }
}
