using System.Threading.Tasks;
namespace Garage_Management_System.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(string to, string subject, string body);
    }
}
