using Gateway.Domain.Services;

using Microsoft.Extensions.DependencyInjection;

namespace Gateway.Domain.Configurations
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureDomainDependencies(this IServiceCollection services)
        {
            return services
                .AddSingleton<IPaymentService, PaymentService>();

        }
    }
}
