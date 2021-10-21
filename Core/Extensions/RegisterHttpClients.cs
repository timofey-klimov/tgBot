using Core.HttpClients;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class RegisterHttpClients
    {
        public static void RegisterClients(this IServiceCollection services, IConfiguration cfg)
        {
            var assembly = Assembly.GetExecutingAssembly();

            var types = assembly
                .GetExportedTypes()
                .Where(x => !x.IsAbstract && typeof(BaseApiClient).IsAssignableFrom(x));

            foreach (var type in types)
            {
                var instanse = Activator.CreateInstance(type, new object[] { cfg.GetSection("ApiUrl").Get<string>() });
                services.AddSingleton(type, instanse);
            }
        }
    }
}
