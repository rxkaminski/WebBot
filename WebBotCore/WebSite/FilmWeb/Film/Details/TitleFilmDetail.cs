using HtmlAgilityPack;
using WebBotCore.WebConnection;

namespace WebBotCore.WebSite.FilmWeb.Film.Details
{
    public class TitleFilmDetail : IDetailWebSite<HtmlDocument>
    {
        public string Title { get; private set; }

        public void Process(HtmlDocument htmlDoc, IWebUri webUri)
        {
            var h1 = htmlDoc.DocumentNode.SelectSingleNode("//h1[contains(@class,'filmCoverSection__title')]");
            Title = h1?.InnerText;
        }
    }
}
