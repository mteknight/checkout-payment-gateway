using System.Threading;
using System.Threading.Tasks;

namespace Gateway.Data.Services
{
    public interface IHttpClientService
    {
        Task<TResult?> Post<TData, TResult>(
            string uri,
            TData data,
            CancellationToken cancellationToken = default);
    }
}
