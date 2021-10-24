using System;
using System.Threading;
using System.Threading.Tasks;

using FluentAssertions;

using Gateway.Data.Services;
using Gateway.Domain.Services;

using Moq;

using Xunit;

namespace Gateway.Domain.Tests.Services
{
    public class PaymentServiceTests
    {
        [Fact]
        public Task GivenNullPayment_WhenExecutingPayment_ThenThrowArgumentNullException()
        {
            // Arrange
            var payment = default(Payment);
            var mockedHttpClientService = new Mock<IHttpClientService>();
            mockedHttpClientService
                .Setup(service => service.Post<Payment, bool>(It.IsAny<string>(), It.IsAny<Payment>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            var sut = DIHelper.GetServices()
                .RegisterMock(mockedHttpClientService)
                .GetConfiguredService<IPaymentService>();

            // Act
            async Task SutCall()
            {
                await sut.Execute(payment);
            }

            Func<Task> sutCall = SutCall;

            // Assert
            return sutCall.Should().ThrowExactlyAsync<ArgumentNullException>("A payment instance is required when making the post request");
        }
    }
}
