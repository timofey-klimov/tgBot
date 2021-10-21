using Core.Commands.Base;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class RegisterCommands
    {
        public static void RegisterTelegramCommandCreators(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            var types = assembly
                .GetExportedTypes()
                .Where(x => !x.IsAbstract && typeof(CommandCreator).IsAssignableFrom(x))
                .ToList();

            types.ForEach(x => services.AddSingleton(typeof(CommandCreator), x));
        }
    }
}
