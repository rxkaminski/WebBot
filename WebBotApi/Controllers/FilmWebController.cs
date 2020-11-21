using Mapster;
using Microsoft.AspNetCore.Mvc;
using WebBotApi.Models;
using WebBotCore.WebSite.FilmWeb.Film;
using WebBotCore.WebSite.FilmWeb.Search;
using WebBotCore.WebSite.FilmWeb.Search.Details;

namespace WebBotApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmWebController : ControllerBase
    {
        /// <summary>
        /// Find game
        /// </summary>
        /// <param name="gameName">game name</param>
        /// <returns>list of games</returns>
        [HttpGet("search/games/{q}")]
        public IActionResult SearchGames(string gameName)
        {
            if (string.IsNullOrWhiteSpace(gameName))
                return new StatusCodeResult(400);

            var gamesSearch = new GamesSearch(gameName);
            gamesSearch.Download();

            var searchRows = gamesSearch.SearchRows;

            return new JsonResult(searchRows.Adapt<SearchRowViewModel[]>());
        }

        /// <summary>
        /// Find films
        /// </summary>
        /// <param name="title">title</param>
        /// <returns>list of films</returns>
        [HttpGet("search/films/{q}")]
        public IActionResult SearchFilms(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                return new StatusCodeResult(400);

            var filmSearch = new FilmsSearch(title);
            filmSearch.Download();

            var searchRows = filmSearch.SearchRows;

            return new JsonResult(searchRows.Adapt<SearchRowViewModel[]>());
        }

        /// <summary>
        /// Get film details
        /// </summary>
        /// <param name="partUri">f.e. "Rambo%2BII-1985-997"</param>
        /// <returns>films details</returns>
        [HttpGet("film/{partUri}")]
        public IActionResult Film(string partUri)
        {
            if (string.IsNullOrWhiteSpace(partUri))
                return new StatusCodeResult(400);

            var film = new FilmDetails(partUri);
            film.Download();

            var filmDetails = film.Details;

            return new JsonResult(filmDetails.Adapt<FilmDetailsViewModel>());
        }
    }
}
