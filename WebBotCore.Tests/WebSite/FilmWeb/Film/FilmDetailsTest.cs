using WebBotCore.Response;
using WebBotCore.Tests.Helpers;
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
            var fakeWebResponse = WebResponseBuilder.Create(null, request: new FakeRequest());
            var filmDetails = new FilmDetails(null, fakeWebResponse);

            //Act
            filmDetails.Download();
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

            public IResponse Send()
            {
                var rawHtml = GenerateSite();
                return Ok(rawHtml);
            }

            private string GenerateSite()
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
        }
    }
}
