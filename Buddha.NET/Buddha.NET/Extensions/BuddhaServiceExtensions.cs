using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

namespace Buddha.NET
{
    public static class BuddhaServiceExtensions
    {
        /// <summary>
        /// Add Buddha.NET main and app-specific actions with commands and validators to Microsoft Dependency Injection container
        /// </summary>
        /// <param name="buddhaAssembly">The assembly that contains the Buddha actions (commands, validators, request, response).</param>
        /// <returns></returns>
        public static IServiceCollection AddBuddha(this IServiceCollection services, Assembly buddhaAssembly = null, ServiceLifetime actionsServiceLifetime = ServiceLifetime.Scoped)
        {
            services.AddSingleton<Buddha>();

            var assembly = buddhaAssembly ?? Assembly.GetCallingAssembly();
            var assemblyTypes = assembly.GetTypes();

            var buddhaTypes = assemblyTypes.Where(_ => _.BaseType.Name == "Command`2" ||
                                                          _.BaseType.Name == "Validator`1"
                                                    );

            foreach (var type in buddhaTypes)
            {
                switch (actionsServiceLifetime)
                {
                    case ServiceLifetime.Singleton:
                        services.AddSingleton(type);
                        break;
                    case ServiceLifetime.Scoped:
                        services.AddScoped(type);
                        break;
                    case ServiceLifetime.Transient:
                        services.AddTransient(type);
                        break;
                }
            }

            return services;
        }
    }
}
