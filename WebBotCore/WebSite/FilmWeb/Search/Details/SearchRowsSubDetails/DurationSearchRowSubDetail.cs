using HtmlAgilityPack;
using System.Linq;
using WebBotCore.WebConnection;

namespace WebBotCore.WebSite.FilmWeb.Search.Details.SearchRowsSubDetails
{
    public class DurationSearchRowSubDetail : IDetailWebSite<HtmlNode>
    {
        public string Duration { get; private set; }

        public void Process(HtmlNode htmlNode, IWebUri webUri)
        {
            Duration = htmlNode.SelectSingleNode(".//div[@class='filmPreview__filmTime']")?.GetAttributes("data-duration")?.FirstOrDefault()?.Value;
        }
    }
}