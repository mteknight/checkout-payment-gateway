using System.Threading.Tasks;

namespace Gateway.Domain.Services
{
    public interface IPaymentService
    {
        Task<bool> Execute(Payment payment);
    }
}
