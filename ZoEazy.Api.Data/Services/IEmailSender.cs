using System.Threading.Tasks;

namespace ZoEazy.Api.Data.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
