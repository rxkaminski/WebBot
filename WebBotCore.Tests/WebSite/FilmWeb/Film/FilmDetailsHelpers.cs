using HtmlAgilityPack;
using WebBotCore.Tests.Helpers;

namespace WebBotCore.Tests.WebSite.FilmWeb.Film
{
    class FilmDetailsHelpers
    {
        public const string CREATOR = "Jan Nowak";
        public const string DIRECTOR = "Jan Kowalski";
        public const string DURATION = "123";
        public const string GENRE = "Fantasy / Przygodowy";
        public const string RATING = "9.81";
        public const string TITLE = "Wiedźmin";

        public static HtmlDocument CreatorFilmHtmlDocDetailsWebSite()
            => PreparePartHtmlDocument("a", CREATOR, "itemprop", "creator");

        public static HtmlDocument DirectorFilmHtmlDocDetailsWebSite()
            => PreparePartHtmlDocument("a", DIRECTOR, "itemprop", "director");

        public static HtmlDocument GenreFilmHtmlDocDetailsWebSite()
            => PreparePartHtmlDocument("div", GENRE, "itemprop", "genre");

        public static HtmlDocument RatingFilmHtmlDocDetailsWebSite()
            => PreparePartHtmlDocument("span", RATING, "itemprop", "ratingValue");

        public static HtmlDocument TitleFilmHtmlDocDetailsWebSite()
            => PreparePartHtmlDocument("h1", TITLE, "class", "filmCoverSection__title");

        public static HtmlDocument DurationFilmHtmlDocDetailsWebSite()
        {
            var simpleHtmlBuilder = new SimpleHtmlBuilder();
            return simpleHtmlBuilder
                    .CreateElement("html")
                     .CreateElement("body")
                      .CreateElement("div")
                       .CreateElement("div", null)
                       .CreateAttribute("itemprop", "timeRequired")
                       .CreateAttribute("data-duration", DURATION);
        }

        private static HtmlDocument PreparePartHtmlDocument(string elementName, string elemntValue, string attributeName, string attributeValue)
        {
            var simpleHtmlBuilder = new SimpleHtmlBuilder();
            return simpleHtmlBuilder
                    .CreateElement("html")
                     .CreateElement("body")
                      .CreateElement("div")
                       .CreateElement(elementName, elemntValue)
                       .CreateAttribute(attributeName, attributeValue);
        }
    }
}
