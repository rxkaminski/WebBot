using HtmlAgilityPack;
namespace WebBotCore.Response
{
    public class HtmlDocTranslaredResponse : IHtmlDocTranslatedResponse
    {
        public HtmlDocument HtmlDoc { get; }

        public string Content { get; }

        public int StatusCode { get; }

        public HtmlDocTranslaredResponse(HtmlDocument htmlDoc, IStatusOkResponse statusOkResopnse)
        {
            HtmlDoc = htmlDoc;
            Content = statusOkResopnse.Content;
            StatusCode = statusOkResopnse.StatusCode;
        }

    }
}
