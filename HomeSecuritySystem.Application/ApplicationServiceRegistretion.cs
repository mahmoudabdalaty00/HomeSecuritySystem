using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HomeSecuritySystem.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection ApplicationService
            (this IServiceCollection services)
        {

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddMediatR(cfg =>
                  cfg.RegisterServicesFromAssembly(
                      Assembly.GetExecutingAssembly()));

            return services;
        }
    }
}
