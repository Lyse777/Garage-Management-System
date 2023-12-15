using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Garage_Management_System.Interfaces
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            var emailSettings = _configuration.GetSection("EmailSettings");

            using var client = new SmtpClient
            {
                Host = emailSettings["MailServer"],
                Port = int.Parse(emailSettings["MailPort"]),
                EnableSsl = true,
                Credentials = new NetworkCredential(emailSettings["Sender"], emailSettings["Password"])
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(emailSettings["Sender"], emailSettings["SenderName"]),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };
            mailMessage.To.Add(to);

            await client.SendMailAsync(mailMessage);
        }
    }
}
