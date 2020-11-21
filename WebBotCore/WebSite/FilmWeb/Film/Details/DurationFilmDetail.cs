using HtmlAgilityPack;
using System.Linq;
using WebBotCore.WebConnection;

namespace WebBotCore.WebSite.FilmWeb.Film.Details
{
    public class DurationFilmDetail : IDetailWebSite<HtmlDocument>
    {
        public string Duration { get; private set; }

        public void Process(HtmlDocument htmlDoc, IWebUri webUri)
        {
            var span = htmlDoc.DocumentNode.SelectSingleNode("//span[@itemprop='timeRequired']");
            Duration = span?.GetAttributes("data-duration")?.FirstOrDefault()?.Value;
        }
    }
}
