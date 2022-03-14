using System;
using System.Net.Http;
using System.Threading.Tasks;
using WebBotCore.Response;

namespace WebBotCore.WebConnection
{
    public class RequestHttpClient : IRequest
    {
        private readonly HttpClient httpClient;

        public RequestHttpClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IResponse> SendAsync(IWebUri uri)
        {
            try
            {
                if (!uri.AbsoluteUriCorrected)
                    return InternlServerError();

                var responce = await httpClient.GetAsync(uri.AbsoluteUri);

                responce.EnsureSuccessStatusCode();

                var responseFromServer = await responce.Content.ReadAsStringAsync();

                return Ok(responseFromServer);
            }
            catch(Exception)
            {
                return InternlServerError();
            }
        }

        public IStatusOkResponse Ok(string value)
        {
            return new StatusOkResponse(value);
        }

        public INoContentResponse InternlServerError()
        {
            return new InternalServerErrorResponse();
        }
    }
}
