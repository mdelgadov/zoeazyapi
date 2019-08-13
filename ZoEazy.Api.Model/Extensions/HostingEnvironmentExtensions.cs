using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace ZoEazy.Api.Model.Extensions
{
    public static class HostingEnvironmentExtensions
    {
        public static string[] GetTranslationFile(this IHostingEnvironment hostingEnvironment)
        {
            return File.ReadAllLines(Path.Combine(hostingEnvironment.ContentRootPath, "translations.csv"));
        }

    }
}
