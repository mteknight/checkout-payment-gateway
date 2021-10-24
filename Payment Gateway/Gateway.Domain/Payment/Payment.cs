using System;
using System.Threading.Tasks;

using Dawn;

using Gateway.Domain.Services;

namespace Gateway.Domain
{
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

            return service.Execute(this);
        }
    }
}
