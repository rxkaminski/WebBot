using HtmlAgilityPack;
using WebBotCore.Tests.Helpers;

namespace WebBotCore.Tests.WebSite.FilmWeb.Search
{
    public static class SearchRowsDetailsHelpers
    {
        public const string HOST = "http://www.wwww.com.pl";

        public const string TITLE_1 = "TITLE 1";
        public const string YEAR_1 = "2020";
        public const string DURATION_1 = "32";
        public const string RELEASE_1 = "2020-11-19";
        public const string LINK_1 = "/title_1";

        public const string TITLE_2 = "TITLE 2";
        public const string YEAR_2 = "2019";
        public const string DURATION_2 = "124";
        public const string RELEASE_2 = "2019-11-19";
        public const string LINK_2 = "/title_2";



        public static HtmlDocument CreateSearchRowsHtmlDocDetailWebSite()
        {
            var simpleHtmlBuilder = new SimpleHtmlBuilder();
            return simpleHtmlBuilder
                    .CreateElement("html")
                     .CreateElement("body")
                      .CreateElement("div")
                       .CreateElement("ul")
                       .CreateAttribute("class", "resultsList hits")

                       //1
                        .CreateElement("li")
                         .CreateElement("h2", TITLE_1)
                         .CreateAttribute("class", "filmPreview__title")

                         .GoToParent()
                         .CreateElement("div", YEAR_1)
                         .CreateAttribute("class", "filmPreview__year")

                         .GoToParent()
                         .CreateElement("div")
                         .CreateAttribute("class", "filmPreview__filmTime")
                         .CreateAttribute("data-duration", DURATION_1)

                         .GoToParent()
                         .CreateElement("div")
                         .CreateAttribute("class", "filmPreview__release")
                         .CreateAttribute("data-release", RELEASE_1)

                         .GoToParent()
                         .CreateElement("a")
                         .CreateAttribute("class", "filmPreview__link")
                         .CreateAttribute("href", LINK_1)

                         //2
                        .GoToParent().GoToParent()
                        .CreateElement("li")
                         .CreateElement("h2", TITLE_2)
                         .CreateAttribute("class", "filmPreview__title")

                         .GoToParent()
                         .CreateElement("div", YEAR_2)
                         .CreateAttribute("class", "filmPreview__year")

                         .GoToParent()
                         .CreateElement("div")
                         .CreateAttribute("class", "filmPreview__filmTime")
                         .CreateAttribute("data-duration", DURATION_2)

                         .GoToParent()
                         .CreateElement("div")
                         .CreateAttribute("class", "filmPreview__release")
                         .CreateAttribute("data-release", RELEASE_2)

                         .GoToParent()
                         .CreateElement("a")
                         .CreateAttribute("class", "filmPreview__link")
                         .CreateAttribute("href", LINK_2);

        }

        public static HtmlNode GetFirstSearchRow()
        {
            return CreateSearchRowsHtmlDocDetailWebSite().DocumentNode.SelectSingleNode("//li");
        }
    }
}
