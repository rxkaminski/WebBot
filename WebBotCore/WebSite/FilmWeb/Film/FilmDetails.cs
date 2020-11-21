using HtmlAgilityPack;
using System.Collections.Generic;
using WebBotCore.Helpers;
using WebBotCore.WebConnection;
using WebBotCore.WebSite.FilmWeb.Film.Details;

namespace WebBotCore.WebSite.FilmWeb.Film
{
    public class FilmDetails : HtmlDocWebSite
    {
        private static IWebUri WebUri(string q) => new WebUri("https://www.film" + "web" + $".pl/film/{q}");

        public FilmDetailsModel Details
        {
            get => new FilmDetailsModel()
            {
                Title = Detail<TitleFilmDetail>().Title,
                Duration = Detail<DurationFilmDetail>().Duration,
                Rating = Detail<RatingFilmDetail>().Rating,
                Genre = Detail<GenreFilmDetail>().Genre,
                Directior = Detail<DirectorFilmDetail>().Directior,
                Creator = Detail<CreatorFilmDetail>().Creator
            };
        }

        public FilmDetails(string q, IWebResponse webResponse = null) : base(WebUri(q), webResponse)
        {
            var htmlDocDetailsLocal = new List<IDetailWebSite<HtmlDocument>>
            {
                new TitleFilmDetail(),
                new DurationFilmDetail(),
                new RatingFilmDetail(),
                new GenreFilmDetail(),
                new DirectorFilmDetail(),
                new CreatorFilmDetail()
            };

            htmlDocDetails = htmlDocDetailsLocal;
        }
    }
}
