using HtmlAgilityPack;
using System.Linq;
using WebBotCore.WebConnection;

namespace WebBotCore.WebSite.FilmWeb.Search.Details.SearchRowsSubDetails
{
    public class ReleaseSearchRowSubDetail : IDetailWebSite<HtmlNode>
    {
        public string Release { get; private set; }

        public void Process(HtmlNode htmlNode, IWebUri webUri)
        {
            Release = htmlNode.SelectSingleNode(".//div[@class='filmPreview__release']")?.GetAttributes("data-release")?.FirstOrDefault()?.Value;
        }
    }
}