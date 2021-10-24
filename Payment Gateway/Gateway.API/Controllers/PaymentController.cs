using System.Threading;
using System.Threading.Tasks;

using Dawn;

using Gateway.Domain;
using Gateway.Domain.Services;

using Microsoft.AspNetCore.Mvc;

namespace Gateway.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            this.paymentService = Guard.Argument(paymentService, nameof(paymentService)).NotNull().Value;
        }

        [HttpPost]
        public async Task<IActionResult> ExecutePayment(
            [FromBody] Payment payment,
            CancellationToken cancellationToken = default)
        {
            if (payment is null)
            {
                return this.BadRequest($"Parameter {nameof(payment)} is required for this operation.");
            }

            var result = await payment.Execute(this.paymentService, cancellationToken);

            return this.Ok(result);
        }
    }
}
