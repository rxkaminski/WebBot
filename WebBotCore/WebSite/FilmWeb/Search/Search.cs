using HtmlAgilityPack;
using System.Collections.Generic;
using WebBotCore.WebConnection;

namespace WebBotCore.WebSite.FilmWeb.Search
{
    public class Search : HtmlDocWebSite
    {
        public List<SearchRowModel> SearchRows { get => Detail<SearchRowsDetail>().SearchRows; }

        public Search(IWebUri webUri) : base(webUri)
        {
            var htmlDocDetailsLocal = new List<IDetailWebSite<HtmlDocument>>
            {
                new SearchRowsDetail()
            };

            htmlDocDetails = htmlDocDetailsLocal;
        }
    }
}
