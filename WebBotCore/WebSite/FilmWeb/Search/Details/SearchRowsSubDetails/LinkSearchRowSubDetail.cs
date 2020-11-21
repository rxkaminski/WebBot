using HtmlAgilityPack;
using System.Linq;
using WebBotCore.WebConnection;

namespace WebBotCore.WebSite.FilmWeb.Search.Details.SearchRowsSubDetails
{
    public class LinkSearchRowSubDetail : IDetailWebSite<HtmlNode>
    {
        public string Link { get; private set; }

        public void Process(HtmlNode htmlNode, IWebUri webUri)
        {
            Link = webUri.Host + htmlNode.SelectSingleNode(".//a[@class='filmPreview__link']")?.GetAttributes("href")?.FirstOrDefault()?.Value;
        }
    }
}