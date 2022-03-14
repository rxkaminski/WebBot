using System.Threading.Tasks;
using WebBotCore.Response;
using WebBotCore.Translate;

namespace WebBotCore.WebConnection
{
    public class WebResponse : IWebResponse
    {
        public IRepeat Repeat { get; }
        public ITranslateResponse TranslateResponse { get; }

        public WebResponse(IRepeat repeat, ITranslateResponse translateResponse)
        {
            Repeat = repeat;
            TranslateResponse = translateResponse;
        }

        public async Task<IResponse> GetResponseAsync(IWebUri webUri)
        {
            var response = await Repeat.GetResponseAsync(webUri);

            if (TranslateResponse == null)
                return response;

            return TranslateResponse.Translate(response);
        }
    }
}
