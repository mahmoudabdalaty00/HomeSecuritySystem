using HomeSecuritySystem.Application.Contracts.Email;
using HomeSecuritySystem.Application.Contracts.Logging;
using HomeSecuritySystem.Application.Models.Emailmodels;
using HomeSecuritySystem.Infrastructure.EmailService;
using HomeSecuritySystem.Infrastructure.Logging;
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

            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            /* 
             we should Select where we put our login action (success , fail , details )_
                1- we can put it in the controller
                2- we can put it in the service
                3- we can put it in the repository
                4- we can put it in the infrastructure
                5- we can put it in the application

            in the door or using Ai  as you like 

             
             */

            // Add your infrastructure services here
            return services;
        }
    }
}
