using System.Threading.Tasks;

namespace Gateway.Domain.Payment.Services
{
    public interface IPaymentService
    {
        Task<bool> Execute(Payment payment);
    }
}