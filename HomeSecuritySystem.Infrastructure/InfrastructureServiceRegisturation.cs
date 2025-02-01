using HomeSecuritySystem.Application.Contracts.Email;
using HomeSecuritySystem.Application.Models.Emailmodels;
using HomeSecuritySystem.Infrastructure.EmailService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HomeSecuritySystem.Infrastructure
{
    public static class InfrastructureServiceRegisturation
    {
        public static IServiceCollection AddInfrastructureService(
            this IServiceCollection services , IConfiguration configuration)
        {

            services.Configure<EmailSettings>(
                configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailSender, EmailSender>();





            // Add your infrastructure services here
            return services;
        }
    }
}
