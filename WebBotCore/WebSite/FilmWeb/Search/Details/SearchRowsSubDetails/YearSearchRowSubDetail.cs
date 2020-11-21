using HtmlAgilityPack;
using WebBotCore.WebConnection;

namespace WebBotCore.WebSite.FilmWeb.Search.Details.SearchRowsSubDetails
{
    public class YearSearchRowSubDetail : IDetailWebSite<HtmlNode>
    {
        public string Year { get; private set; }

        public void Process(HtmlNode htmlNode, IWebUri webUri)
        {
            Year = htmlNode.SelectSingleNode(".//div[@class='filmPreview__year']")?.InnerText;
        }
    }
}