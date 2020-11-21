using WebBotCore.Translate;

namespace WebBotCore.WebConnection
{
    public class WebResponseBuilder
    {
        public static IWebResponse Create(IWebUri webUri, IRepeat repeat = null, IRequest request = null, ITranslateResponse translateResponse = null)
        {
            var requestLocal = request ?? new Request(webUri);
            var repeatLocal = repeat ?? new Repeat(requestLocal);
            var translateResponseLocal = translateResponse ?? new HtmlDocTranslateResponse();

            return new WebResponse(webUri, repeatLocal, requestLocal, translateResponseLocal);
        }
    }
}
