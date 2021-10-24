using System;
using System.Threading;
using System.Threading.Tasks;

using AutoFixture.Xunit2;

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
            var sut = GetSutService();

            // Act
            async Task SutCall()
            {
                await sut.Execute(payment);
            }

            Func<Task> sutCall = SutCall;

            // Assert
            return sutCall.Should().ThrowExactlyAsync<ArgumentNullException>("A payment instance is required when making the post request");
        }

        [Theory]
        [AutoData]
        public async Task GivenValidPayment_WhenExecutingPayment_ThenRequestIsSuccessful(
            bool expectedResult,
            Payment payment)
        {
            // Arrange
            var result = default(bool?);
            var sut = GetSutService(expectedResult);

            // Act
            async Task SutCall()
            {
                result = await sut.Execute(payment);
            }

            Func<Task> sutCall = SutCall;

            // Assert
            await sutCall.Should().NotThrowAsync("Payment execution is expected to complete without errors.");
            result.Should().NotBeNull("A result is expected when executing without errors");
        }

        private static IPaymentService GetSutService(bool expectedResult = default)
        {
            var mockedHttpClientService = SetupHttpClientServiceMock(expectedResult);

            return DIHelper.GetServices()
                .RegisterMock(mockedHttpClientService)
                .GetConfiguredService<IPaymentService>();
        }

        private static Mock<IHttpClientService> SetupHttpClientServiceMock(bool expectedResult)
        {
            var mockedHttpClientService = new Mock<IHttpClientService>();
            mockedHttpClientService
                .Setup(service => service.Post<Payment, bool>(It.IsAny<string>(), It.IsAny<Payment>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResult);

            return mockedHttpClientService;
        }
    }
}
