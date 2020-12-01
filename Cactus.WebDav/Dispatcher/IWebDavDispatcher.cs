using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WebDav.Request.Parameters;

namespace WebDav.Dispatcher
{
    internal interface IWebDavDispatcher
    {
        Uri BaseAddress { get; }

        Task<HttpResponseMessage> Send(
            Uri requestUri,
            HttpMethod method,
            RequestParameters requestParams,
            CancellationToken cancellationToken,
            HttpCompletionOption httpCompletionOption = HttpCompletionOption.ResponseContentRead);
    }
}