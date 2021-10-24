using System;
using System.Threading.Tasks;

using Dawn;

using FluentAssertions;

using Moq;

using Xunit;

namespace Gateway.Test.Domain
{
    public class PaymentTests
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
                .Setup(service => service.Execute(payment))
                .Verifiable();

            // Act
            await payment.Execute(mockedService.Object);

            // Assert
            mockedService.Verify(service => service.Execute(payment), () => Times.Exactly(1));
        }
    }

    public class Payment
    {
        public string CardNumber { get; set; }

        public DateTime ExpiryDate { get; set; }

        public decimal Amount { get; set; }

        public string Currency { get; set; }

        public string CVV { get; set; }

        public Task<bool> Execute(IPaymentService service)
        {
            Guard.Argument(service, nameof(service)).NotNull();

            throw new NotImplementedException();
        }
    }

    public interface IPaymentService
    {
        Task<bool> Execute(Payment payment);
    }

    internal class PaymentService : IPaymentService
    {
        public Task<bool> Execute(Payment payment)
        {
            throw new NotImplementedException();
        }
    }
}
