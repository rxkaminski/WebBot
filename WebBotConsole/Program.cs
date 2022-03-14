using System.Net.Http;
using System.Threading.Tasks;
using WebBotCore.WebConnection;
using WebBotCore.WebSite.FilmWeb.Film;
using WebBotCore.WebSite.FilmWeb.Search;
using WebBotCore.WebSite.FilmWeb.Search.Details;

namespace WebBotConsole
{
    class Program
    {
        static void Main()
        {
            IWebResponse webResponse = WebResponseFactory.Create(new HttpClient());

            SearchFilm(webResponse).GetAwaiter().GetResult();
            GetFilm(webResponse).GetAwaiter().GetResult();
        }

        private static async Task GetFilm(IWebResponse webResponse)
        {
            var film = new FilmDetails("Wiedźmin-2001-1281", webResponse);
            await film.DownloadAsync();

            var result = film.Details;
        }

        private static async Task SearchFilm(IWebResponse webResponse)
        {
            var filmSearch = new FilmsSearch("wiedźmin", webResponse);
            await filmSearch.DownloadAsync();

            var result = filmSearch.SearchRows;
        }
    }
}
