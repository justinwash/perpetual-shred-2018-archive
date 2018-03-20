using System.Threading.Tasks;

namespace PerpetualShred.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
