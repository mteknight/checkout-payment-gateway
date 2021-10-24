using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

using Dawn;

using Newtonsoft.Json;

namespace Gateway.Data.Services
{
    public class HttpClientService : IHttpClientService
    {
        private readonly IHttpClientFactory httpClientFactory;

        public HttpClientService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = Guard.Argument(httpClientFactory, nameof(httpClientFactory)).NotNull().Value;
        }

        public async Task<TResult?> Post<TData, TResult>(
            string uri,
            TData data,
            CancellationToken cancellationToken = default)
        {
            using var client = this.httpClientFactory.CreateClient();
            var content = JsonContent.Create(data, typeof(TData));
            var response = await client.PostAsync(uri, content, cancellationToken);

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync(cancellationToken);

            return JsonConvert.DeserializeObject<TResult>(json);
        }
    }
}
