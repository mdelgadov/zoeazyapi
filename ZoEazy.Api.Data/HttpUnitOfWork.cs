using Microsoft.AspNetCore.Http;
using AspNet.Security.OpenIdConnect.Primitives;

namespace ZoEazy.Api.Data
{
    public class HttpUnitOfWork : UnitOfWork
    {
        public HttpUnitOfWork(ZoeazyDbContext context, IHttpContextAccessor httpAccessor) : base(context)
        {
            context.CurrentUserId = httpAccessor.HttpContext.User.FindFirst(OpenIdConnectConstants.Claims.Subject)?.Value?.Trim();
        }
    }
}
