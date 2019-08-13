using System.Collections.Generic;
using System.Threading.Tasks;

namespace ZoEazy.Api.Helpers
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string template, Dictionary<string, object> parameters, string email, int orderId, decimal total);
        Task SendEmailAsync(string template, string email, string code, string name);
        }
}
