using Microsoft.Extensions.DependencyInjection;
using WebDav;

namespace Cactus.WebDav.Extensions.DependencyInjection
{
    public static class WebDavExtension
    {
        public static IServiceCollection RegisterWebDavService(this IServiceCollection services)
        {
            services.AddTransient<IWebDavClient, WebDavClient>();

            return services;
        }
    }
}
