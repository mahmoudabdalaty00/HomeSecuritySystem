using HomeSecuritySystem.Application.Contracts.Email;
using HomeSecuritySystem.Application.Models.Emailmodels;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace HomeSecuritySystem.Infrastructure.EmailService
{
    public class EmailSender : IEmailSender
    {
        public EmailSettings _emailSettings { get; }
        public EmailSender(IOptions<EmailSettings> options)
        {
            _emailSettings = options.Value;
        }

        public async Task<bool> SendEmail(EmailMessage email)
        {
            var client = new SendGridClient(_emailSettings.ApiKey);
            var To = new EmailAddress(email.To);
            var From = new EmailAddress
            {
                Email = _emailSettings.FromAddress,
                Name = _emailSettings.FromName
            };

            var msg = MailHelper.CreateSingleEmail(
                From, To, email.Subject, email.Body, email.Body );

            var response =await client.SendEmailAsync(msg);


            return
                   response.StatusCode == System.Net.HttpStatusCode.OK
                || response.StatusCode == System.Net.HttpStatusCode.Accepted
                || response.IsSuccessStatusCode;
                
        }
    }
}
