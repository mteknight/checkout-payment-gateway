using System.Threading;
using System.Threading.Tasks;

namespace Gateway.Domain.Services
{
    public interface IPaymentService
    {
        Task<bool> Execute(Payment payment, CancellationToken cancellationToken = default);
    }
}
