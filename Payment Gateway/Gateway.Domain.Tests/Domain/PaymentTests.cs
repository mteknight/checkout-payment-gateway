using System;
using System.Threading;
using System.Threading.Tasks;

using FluentAssertions;

using Gateway.Domain.Services;

using Moq;

using Xunit;

namespace Gateway.Domain.Tests.Domain
{
    public sealed class PaymentTests
    {
        [Fact]
        public Task GivenServiceNull_WhenExecutingPayment_ThenThrowArgumentNullException()
        {
            // Arrange
            var payment = new Payment();
            var service = default(IPaymentService);

            // Act
            async Task SutCall()
            {
                await payment.Execute(service);
            }

            Func<Task> sutCall = SutCall;

            // Assert
            return sutCall.Should().ThrowExactlyAsync<ArgumentNullException>("The service is required to perform the operation.");
        }

        [Fact]
        public async Task GivenServiceProvided_WhenExecutingService_ThenExecuteFromService()
        {
            // Arrange
            var payment = new Payment();
            var mockedService = new Mock<IPaymentService>();
            mockedService
                .Setup(service => service.Execute(payment, It.IsAny<CancellationToken>()))
                .Verifiable();

            // Act
            await payment.Execute(mockedService.Object);

            // Assert
            mockedService.Verify(service => service.Execute(payment, It.IsAny<CancellationToken>()), () => Times.Exactly(1));
        }
    }
}
