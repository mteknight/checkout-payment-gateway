using System.Threading;
using System.Threading.Tasks;

using Dawn;

using Gateway.Data.Services;

namespace Gateway.Domain.Services
{
    internal class PaymentService : IPaymentService
    {
        private const string AcquiringBankUri = "";
        private readonly IHttpClientService httpClientService;

        public PaymentService(IHttpClientService httpClientService)
        {
            this.httpClientService = Guard.Argument(httpClientService, nameof(httpClientService)).NotNull().Value;
        }

        public Task<bool> Execute(
            Payment payment,
            CancellationToken cancellationToken = default)
        {
            Guard.Argument(payment, nameof(payment)).NotNull();

            return this.httpClientService.Post<Payment, bool>(AcquiringBankUri, payment, cancellationToken);
        }
    }
}
