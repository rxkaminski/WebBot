using System.Threading.Tasks;
using WebBotCore.Response;
using WebBotCore.Tests.Helpers;
using WebBotCore.Translate;
using WebBotCore.WebConnection;
using WebBotCore.WebSite.FilmWeb.Film;
using Xunit;
using static WebBotCore.Tests.WebSite.FilmWeb.Film.FilmDetailsHelpers;

namespace WebBotCore.Tests.WebSite.FilmWeb.Film
{
    public class FilmDetailsTest
    {
        [Fact]
        public void CheckResponse()
        {
            //Arrange
            var requestLocal = new FakeRequest();
            var repeatLocal = new Repeat(requestLocal);
            var translateResponseLocal = new HtmlDocTranslateResponse();

            var fakeWebResponse = new WebResponse(repeatLocal, translateResponseLocal);
            var filmDetails = new FilmDetails(null, fakeWebResponse);

            //Act
            filmDetails.DownloadAsync().GetAwaiter().GetResult();
            var model = filmDetails.Details;

            //Assert
            Assert.Equal(CREATOR, model.Creator);
            Assert.Equal(DIRECTOR, model.Directior);
            Assert.Equal(DURATION, model.Duration);
            Assert.Equal(GENRE, model.Genre);
            Assert.Equal(RATING, model.Rating);
            Assert.Equal(TITLE, model.Title);
        }

        private class FakeRequest : IRequest
        {
            public INoContentResponse InternlServerError()
            {
                return new InternalServerErrorResponse();
            }

            public IStatusOkResponse Ok(string value)
            {
                return new StatusOkResponse(value);
            }

            public async Task<IResponse> SendAsync(IWebUri webUri)
            {
                var rawHtml = await GenerateSite();
                return Ok(rawHtml);
            }

#pragma warning disable CS1998
            private async Task<string> GenerateSite()
            {
                var result = CreatorFilmHtmlDocDetailsWebSite();
                result.MergeBody(
                    DirectorFilmHtmlDocDetailsWebSite(),
                    DurationFilmHtmlDocDetailsWebSite(),
                    GenreFilmHtmlDocDetailsWebSite(),
                    RatingFilmHtmlDocDetailsWebSite(),
                    TitleFilmHtmlDocDetailsWebSite()
                    );
                return result.DocumentNode.OuterHtml;
            }
#pragma warning restore CS1998
        }
    }
}
