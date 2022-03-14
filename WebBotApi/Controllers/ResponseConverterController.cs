using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using WebBotCore.Translate;
using WebBotCore.WebConnection;
using WebBotCore.WebSite.Converters;

namespace WebBotApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConverterController : MainController
    {
        protected readonly IWebResponse webResponse;

        public ConverterController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            webResponse = WebResponseFactory.Create(httpClient, new JsonToXmlTranslateResponse());
        }

        /// <summary>
        /// Convert JSON response from jsonEndPoint to the XML format
        /// </summary>
        /// <param name="jsonEndPoint">Endpoint with http[s]://</param>
        /// <returns></returns>
        [HttpGet("jsontoxml/{jsonEndPoint}")]
        public async Task<IActionResult> JsonToXml(string jsonEndPoint)
        {
            if (string.IsNullOrWhiteSpace(jsonEndPoint))
                return new StatusCodeResult(400);

            var jsonToXmlConvert = new JsonToXmlConvert(jsonEndPoint, webResponse);
            await jsonToXmlConvert.DownloadAsync();

            if (jsonToXmlConvert.Xml == null)
                return new StatusCodeResult(404);

            return new ContentResult()
            {
                Content = jsonToXmlConvert.Xml.OuterXml,
                ContentType = "text/xml"
            };
        }
    }
}
