using HtmlAgilityPack;
using WebBotCore.Response;

namespace WebBotCore.Translate
{
    public class HtmlDocTranslateResponse : ITranslateResponse
    {
        public IResponse Translate(IResponse response)
        {
            if (!(response is IStatusOkResponse))
                return response;

            var iStatusOkResponse = response as IStatusOkResponse;

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(iStatusOkResponse.Content);

            return new HtmlDocTranslaredResponse(htmlDoc, iStatusOkResponse);
        }
    }
}
