using WebBotCore.WebSite.FilmWeb.Film;
using WebBotCore.WebSite.FilmWeb.Search;
using WebBotCore.WebSite.FilmWeb.Search.Details;

namespace WebBotConsole
{
    class Program
    {
        static void Main()
        {
            SearchFilm();
            //GetFilm();
        }

        private static void GetFilm()
        {
            var film = new FilmDetails("Wiedźmin-2001-1281");
            film.Download();

            var result = film.Details;
        }

        private static void SearchFilm()
        {
            var filmSearch = new FilmsSearch("wiedźmin");
            filmSearch.Download();

            var result = filmSearch.SearchRows;
        }
    }
}
