using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;
using WebBotCore.WebConnection;

namespace WebBotCore.WebSite.FilmWeb.Search.Details.SearchRowsSubDetails
{
    public class TitleSearchRowSubDetail : IDetailWebSite<HtmlNode>
    {
        public string Title { get; private set; }

        public void Process(HtmlNode htmlNode, IWebUri webUri)
        {
            Title = htmlNode.SelectSingleNode(".//h2[@class='filmPreview__title']")?.InnerHtml;
        }
    }
}
