using System.Net.Http;
using WebBotCore.WebConnection;

namespace WebBotCore.WebSite.FilmWeb.Search
{
    public class GamesSearch : Search
    {
        private static IWebUri WebUri(string q) => new WebUri($"https://www.film" + "web" + $".pl/games/search?q={q}");

        public GamesSearch(string q, IWebResponse webResponse) : base(WebUri(q), webResponse) { }
    }
}
