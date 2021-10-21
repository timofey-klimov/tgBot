using Core.Menu.Base;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

namespace Core.Extensions
{
    public static class RegisterMenu
    {
        public static void RegisterMenuCreators(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            var types = assembly
                .GetExportedTypes()
                .Where(x => !x.IsAbstract && typeof(BaseMenuCreator).IsAssignableFrom(x));

            foreach (var type in types)
            {
                services.AddSingleton(type);
            }
        }
    }
}
