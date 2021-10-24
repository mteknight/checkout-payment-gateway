using System;
using System.Threading.Tasks;

using Dawn;

using Gateway.Data.Services;

namespace Gateway.Domain.Services
{
    internal class PaymentService : IPaymentService
    {
        private readonly IHttpClientService httpClientService;

        public PaymentService(IHttpClientService httpClientService)
        {
            this.httpClientService = Guard.Argument(httpClientService, nameof(httpClientService)).NotNull().Value;
        }

        public Task<bool> Execute(Payment payment)
        {
            throw new NotImplementedException();
        }
    }
}
