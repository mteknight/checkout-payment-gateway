using System;
using System.Threading.Tasks;

namespace Gateway.Domain.Payment.Services
{
    internal class PaymentService : IPaymentService
    {
        public Task<bool> Execute(Payment payment)
        {
            throw new NotImplementedException();
        }
    }
}