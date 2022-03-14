using WebBotCore.WebConnection;

namespace WebBotCore.WebSite.FilmWeb.Search.Details
{
    public class FilmsSearch : Search
    {
        private static IWebUri WebUri(string q) => new WebUri($"https://www.film" + "web" + $".pl/films/search?q={q}");

        public FilmsSearch(string q, IWebResponse webResponse) : base(WebUri(q), webResponse) { }
    }
}
