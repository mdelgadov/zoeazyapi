using System.Threading.Tasks;

namespace ZoEazy.Api.Helpers
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
