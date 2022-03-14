using Mapster;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using WebBotApi.Models;
using WebBotCore.WebConnection;
using WebBotCore.WebSite.FilmWeb.Film;
using WebBotCore.WebSite.FilmWeb.Search;
using WebBotCore.WebSite.FilmWeb.Search.Details;

namespace WebBotApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmWebController : MainController
    {
        protected readonly IWebResponse webResponse;

        public FilmWebController(IHttpClientFactory httpClientFactory) 
            : base(httpClientFactory)
        {
            webResponse = WebResponseFactory.Create(httpClient);
        }

        /// <summary>
        /// Find game
        /// </summary>
        /// <param name="gameName">game name</param>
        /// <returns>list of games</returns>
        [HttpGet("search/games/{gameName}")]
        public async Task<IActionResult> SearchGames(string gameName)
        {
            if (string.IsNullOrWhiteSpace(gameName))
                return new StatusCodeResult(400);

            var gamesSearch = new GamesSearch(gameName, webResponse);
            await gamesSearch.DownloadAsync();

            var searchRows = gamesSearch.SearchRows;

            return new JsonResult(searchRows.Adapt<SearchRowViewModel[]>());
        }

        /// <summary>
        /// Find films
        /// </summary>
        /// <param name="title">title</param>
        /// <returns>list of films</returns>
        [HttpGet("search/films/{title}")]
        public async Task<IActionResult> SearchFilms(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                return new StatusCodeResult(400);

            var filmSearch = new FilmsSearch(title, webResponse);
            await filmSearch.DownloadAsync();

            var searchRows = filmSearch.SearchRows;

            return new JsonResult(searchRows.Adapt<SearchRowViewModel[]>());
        }

        /// <summary>
        /// Get film details
        /// </summary>
        /// <param name="partUri">f.e. "Rambo%2BII-1985-997"</param>
        /// <returns>films details</returns>
        [HttpGet("film/{partUri}")]
        public async Task<IActionResult> Film(string partUri)
        {
            if (string.IsNullOrWhiteSpace(partUri))
                return new StatusCodeResult(400);

            var film = new FilmDetails(partUri, webResponse);
            await film.DownloadAsync();

            var filmDetails = film.Details;

            return new JsonResult(filmDetails.Adapt<FilmDetailsViewModel>());
        }
    }
}
