using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using WebBotCore.Helpers;
using WebBotCore.WebConnection;
using WebBotCore.WebSite.FilmWeb.Search.Details.SearchRowsSubDetails;

namespace WebBotCore.WebSite.FilmWeb.Search
{
    public class SearchRowsDetail : IDetailWebSite<HtmlDocument>
    {
        public List<SearchRowModel> SearchRows { get; private set; }

        private IEnumerable<IDetailWebSite<HtmlNode>> CreateSubDetailsList()
        {
            return new List<IDetailWebSite<HtmlNode>>()
            {
                new TitleSearchRowSubDetail(),
                new YearSearchRowSubDetail(),
                new DurationSearchRowSubDetail(),
                new ReleaseSearchRowSubDetail(),
                new LinkSearchRowSubDetail()
            };
        }

        public void Process(HtmlDocument htmlDoc, IWebUri webUri)
        {
            SearchRows = new List<SearchRowModel>();

            var lis = GetLisSubDetails(htmlDoc);

            foreach (var li in lis)
            {
                var subDetailWebSites = CreateSubDetailsList();

                foreach (var subDetail in subDetailWebSites)
                    subDetail.Process(li, webUri);

                if (TryCreateModel(subDetailWebSites, out var model))
                    SearchRows.Add(model);
            }
        }

        private bool TryCreateModel(IEnumerable<IDetailWebSite<HtmlNode>> subDetailWebSites, out SearchRowModel searchRowModel)
        {
            searchRowModel = null;

            var title = SubDetail<TitleSearchRowSubDetail>(subDetailWebSites)?.Title;
            if (string.IsNullOrEmpty(title))
                return false;

            searchRowModel = new SearchRowModel()
            {
                Title = title,
                Year = SubDetail<YearSearchRowSubDetail>(subDetailWebSites)?.Year,
                Duration = SubDetail<DurationSearchRowSubDetail>(subDetailWebSites)?.Duration,
                Release = SubDetail<ReleaseSearchRowSubDetail>(subDetailWebSites)?.Release,
                Link = SubDetail<LinkSearchRowSubDetail>(subDetailWebSites)?.Link,
            };

            return true;
        }

        private static IEnumerable<HtmlNode> GetLisSubDetails(HtmlDocument htmlDoc)
        {
            var ul = htmlDoc.DocumentNode.SelectSingleNode("//ul[@class='resultsList hits']");
            var lis = ul.ChildNodes.Where(ch => ch.Name == "li");
            return lis;
        }

        protected T SubDetail<T>(IEnumerable<IDetailWebSite<HtmlNode>> subDetailWebSites) => subDetailWebSites.FirstOnTyppe<T, HtmlNode>();
    }
}
