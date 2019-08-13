using Microsoft.AspNetCore.Http;

namespace ZoEazy.Api.Data.Services
{
    public interface IApplicationDataService
    {
        object GetApplicationData(HttpContext context, string stsAuthority);
    }
}