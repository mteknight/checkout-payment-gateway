using Gateway.Data.Configurations;
using Gateway.Domain.Configurations;

using Microsoft.Extensions.DependencyInjection;

using Moq;

namespace Gateway.Domain.Tests
{
    public static class DIHelper
    {
        public static IServiceCollection GetServices()
        {
            return new ServiceCollection()
                .ConfigureDataDependencies()
                .ConfigureDomainDependencies();
        }

        public static TService GetConfiguredService<TService>(this IServiceCollection services)
        {
            return services
                .BuildServiceProvider()
                .GetService<TService>();
        }

        public static IServiceCollection RegisterMock<TMockObject>(
            this IServiceCollection services,
            Mock<TMockObject> mockToRegister)
            where TMockObject : class
        {
            return services.AddSingleton(_ => mockToRegister.Object);
        }
    }
}
