using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

namespace Buddha.NET
{
    public static class BuddhaServiceExtensions
    {
        public static IServiceCollection AddBuddha(this IServiceCollection services)
        {
            services.AddSingleton<Buddha>();

            var appAssembly = Assembly.GetCallingAssembly();
            var appAssemblyTypes = appAssembly.GetTypes();

            var buddhaTypes = appAssemblyTypes.Where(_ => _.BaseType.Name == "Command`2" ||
                                                          _.BaseType.Name == "Validator`1"
                                                    );

            foreach (var command in buddhaTypes)
            {
                services.AddTransient(command);
            }

            return services;
        }
    }
}
