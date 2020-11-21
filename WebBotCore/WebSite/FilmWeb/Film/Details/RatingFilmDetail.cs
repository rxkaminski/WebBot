using HtmlAgilityPack;
using WebBotCore.WebConnection;

namespace WebBotCore.WebSite.FilmWeb.Film.Details
{
    public class RatingFilmDetail : IDetailWebSite<HtmlDocument>
    {
        public string Rating { get; private set; }

        public void Process(HtmlDocument htmlDoc, IWebUri webUri)
        {
            var span = htmlDoc.DocumentNode.SelectSingleNode("//span[@itemprop='ratingValue']");
            Rating = span?.InnerText?.Trim();
        }
    }
}
