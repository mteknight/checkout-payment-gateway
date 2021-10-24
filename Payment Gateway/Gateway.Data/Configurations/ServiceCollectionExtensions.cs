using Gateway.Data.Services;

using Microsoft.Extensions.DependencyInjection;

namespace Gateway.Data.Configurations
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureDataDependencies(this IServiceCollection services)
        {
            return services
                .AddHttpClient()
                .AddSingleton<IHttpClientService, HttpClientService>();

        }
    }
}
