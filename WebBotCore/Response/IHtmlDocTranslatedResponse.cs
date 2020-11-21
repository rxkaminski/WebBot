using HtmlAgilityPack;

namespace WebBotCore.Response

{
    public interface IHtmlDocTranslatedResponse : ITranslatedResponse
    {
        public HtmlDocument HtmlDoc { get; }
    }
}
