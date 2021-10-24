using System;
using System.Threading.Tasks;

using FluentAssertions;

using Gateway.Domain.Payment.Services;

using Moq;

using Xunit;

namespace Gateway.Domain.Tests.Domain
{
    public class PaymentTests
    {
        [Fact]
        public Task GivenServiceNull_WhenExecutingPayment_ThenThrowArgumentNullException()
        {
            // Arrange
            var payment = new Payment.Payment();
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
            var payment = new Payment.Payment();
            var mockedService = new Mock<IPaymentService>();
            mockedService
                .Setup(service => service.Execute(payment))
                .Verifiable();

            // Act
            await payment.Execute(mockedService.Object);

            // Assert
            mockedService.Verify(service => service.Execute(payment), () => Times.Exactly(1));
        }
    }
}
