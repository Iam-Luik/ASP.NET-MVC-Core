using AspNetCoreIdentity.Extensions;
using KissLog;
using KissLog.AspNetCore;
using Microsoft.AspNetCore.Authorization;

namespace AspNetCoreIdentity.Config
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IAuthorizationHandler, PermissaoNecessariaHandler>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped((context) => Logger.Factory.Get());
            services.AddLogging(logging =>
            {
                logging.AddKissLog();
            });

            services.AddScoped<AuditoriaFilter>();

            return services;
        }
    }
}
