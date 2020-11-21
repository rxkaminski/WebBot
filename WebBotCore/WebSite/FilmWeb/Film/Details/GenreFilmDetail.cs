using HtmlAgilityPack;
using WebBotCore.WebConnection;

namespace WebBotCore.WebSite.FilmWeb.Film.Details
{
    public class GenreFilmDetail : IDetailWebSite<HtmlDocument>
    {
        public string Genre { get; private set; }

        public void Process(HtmlDocument htmlDoc, IWebUri webUri)
        {
            var div = htmlDoc.DocumentNode.SelectSingleNode("//div[@itemprop='genre']");
            Genre = div.InnerText;
        }
    }
}
