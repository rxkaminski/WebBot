using HtmlAgilityPack;
using WebBotCore.WebConnection;

namespace WebBotCore.WebSite.FilmWeb.Film.Details
{
    public class DirectorFilmDetail : IDetailWebSite<HtmlDocument>
    {
        public string Directior { get; private set; }

        public void Process(HtmlDocument htmlDoc, IWebUri webUri)
        {
            var a = htmlDoc.DocumentNode.SelectSingleNode("//a[@itemprop='director']");
            Directior = a?.InnerText?.Trim();
        }
    }
}
