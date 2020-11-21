using WebBotCore.Response;
using WebBotCore.Translate;

namespace WebBotCore.WebConnection
{
    public class WebResponse : IWebResponse
    {
        public IWebUri WebUri { get; }
        public IRepeat Repeat { get; }
        public IRequest Request { get; }
        public ITranslateResponse TranslateResponse { get; }

        public WebResponse(IWebUri webUri, IRepeat repeat, IRequest request, ITranslateResponse translateResponse)
        {
            WebUri = webUri;
            Repeat = repeat;
            Request = request;
            TranslateResponse = translateResponse;
        }

        public IResponse GetResponse()
        {
            var response = Repeat.GetResponse();

            if (TranslateResponse == null)
                return response;

            return TranslateResponse.Translate(response);
        }
    }
}
