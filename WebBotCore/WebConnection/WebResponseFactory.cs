using System.Net.Http;
using WebBotCore.Translate;

namespace WebBotCore.WebConnection
{
    public class WebResponseFactory
    {
        public static IWebResponse Create(HttpClient httpClient, ITranslateResponse translateResponse = null)
        {
            var requestLocal = new RequestHttpClient(httpClient);
            var repeatLocal = new Repeat(requestLocal);
            var translateResponseLocal = translateResponse ?? new HtmlDocTranslateResponse();

            return new WebResponse(repeatLocal, translateResponseLocal);
        }
    }
}
