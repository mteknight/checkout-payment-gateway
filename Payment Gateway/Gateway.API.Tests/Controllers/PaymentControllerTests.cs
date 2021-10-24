using System.Threading;
using System.Threading.Tasks;

using AutoFixture.Xunit2;

using FluentAssertions;

using Gateway.API.Controllers;
using Gateway.Domain;
using Gateway.Domain.Services;
using Gateway.Domain.Tests;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

using Moq;

using Xunit;

namespace Gateway.API.Tests.Controllers
{
    public sealed class PaymentControllerTests
    {
        private Mock<IPaymentService> mockedPaymentService;

        [Fact]
        public async Task GivenNullPayment_WhenRequestPaymentExecution_ThenReturnBadRequest()
        {
            // Arrange
            var payment = default(Payment);
            var sutController = this.GetSutController();

            // Act
            var result = await sutController.ExecutePayment(payment);

            // Assert
            result.Should().BeAssignableTo<BadRequestObjectResult>("Parameter is required when executing a payment.");

        }

        [Theory]
        [AutoData]
        public async Task GivenValidPayment_WhenRequestPaymentExecution_ThenCallServiceExecute(Payment payment)
        {
            // Arrange
            var sutController = this.GetSutController();

            // Act
            await sutController.ExecutePayment(payment);

            // Assert
            this.mockedPaymentService
                .Verify(service => service.Execute(It.IsAny<Payment>(), It.IsAny<CancellationToken>()), () => Times.Exactly(1));
        }

        [Theory]
        [AutoData]
        public async Task GivenValidPayment_WhenRequestPaymentExecution_ThenReturnOkWithResult(
            bool expectedResult,
            Payment payment)
        {
            // Arrange
            var sutController = this.GetSutController(expectedResult);

            // Act
            var result = await sutController.ExecutePayment(payment);

            // Assert
            result.Should().BeOfType<OkObjectResult>("An Ok result is expected if the payment is processed.");
            result.As<OkObjectResult>().Value.As<bool>().Should().Be(expectedResult, "The expected result should be returned.");

        }

        private PaymentController GetSutController(bool expectedResult = default)
        {
            var mockedPaymentService = this.SetupPaymentServiceMock(expectedResult);

            return DIHelper.GetServices()
                .AddSingleton<PaymentController>()
                .RegisterMock(mockedPaymentService)
                .GetConfiguredService<PaymentController>();
        }

        private Mock<IPaymentService> SetupPaymentServiceMock(bool expectedResult)
        {
            this.mockedPaymentService = new Mock<IPaymentService>();
            this.mockedPaymentService
                .Setup(service => service.Execute(It.IsAny<Payment>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResult)
                .Verifiable();

            return this.mockedPaymentService;
        }
    }
}
