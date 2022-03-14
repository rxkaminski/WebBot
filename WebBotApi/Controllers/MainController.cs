using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace WebBotApi.Controllers
{
    public class MainController : ControllerBase
    {
        protected readonly HttpClient httpClient;

        public MainController(IHttpClientFactory httpClientFactory)
        {
            this.httpClient = httpClientFactory.CreateClient(Startup.WEB_BOT_HTTP_CLIENT_NAME);
        }
    }
}
