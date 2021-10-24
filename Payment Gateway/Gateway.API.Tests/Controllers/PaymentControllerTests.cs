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
        [Theory]
        [AutoData]
        public async Task GivenNullPayment_WhenRequestPaymentExecution_ThenReturnBadRequest(Payment payment)
        {
            // Arrange
            var sutController = GetSutController();

            // Act
            var result = await sutController.ExecutePayment(payment);

            // Assert
            result.Should().BeAssignableTo<BadRequestObjectResult>("Parameter is required when executing a payment.");

        }

        private static PaymentController GetSutController(bool expectedResult = default)
        {
            var mockedPaymentService = SetupPaymentServiceMock(expectedResult);

            return DIHelper.GetServices()
                .AddSingleton<PaymentController>()
                .RegisterMock(mockedPaymentService)
                .GetConfiguredService<PaymentController>();
        }

        private static Mock<IPaymentService> SetupPaymentServiceMock(bool expectedResult)
        {
            var mockedPaymentService = new Mock<IPaymentService>();
            mockedPaymentService
                .Setup(service => service.Execute(It.IsAny<Payment>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResult);

            return mockedPaymentService;
        }
    }
}
