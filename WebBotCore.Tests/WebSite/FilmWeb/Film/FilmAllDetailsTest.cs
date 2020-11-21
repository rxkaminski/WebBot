using WebBotCore.WebSite.FilmWeb.Film.Details;
using Xunit;
using static WebBotCore.Tests.WebSite.FilmWeb.Film.FilmDetailsHelpers;

namespace WebBotCore.Tests.WebSite.FilmWeb.Film
{
    public class FilmAllDetailsTest
    {
        [Fact]
        public void CreatorFilmDetailTest()
        {
            //Arrange
            var html = CreatorFilmHtmlDocDetailsWebSite();
            var creator = new CreatorFilmDetail();

            //Act
            creator.Process(html, null);

            //Assert
            Assert.Equal(CREATOR, creator.Creator);
        }

        [Fact]
        public void DirectorFilmDetailTest()
        {
            //Arrange
            var html = DirectorFilmHtmlDocDetailsWebSite();
            var director = new DirectorFilmDetail();

            //Act
            director.Process(html, null);

            //Assert
            Assert.Equal(DIRECTOR, director.Directior);
        }

        [Fact]
        public void DurationFilmDetailTest()
        {
            //Arrange
            var html = DurationFilmHtmlDocDetailsWebSite();
            var director = new DurationFilmDetail();

            //Act
            director.Process(html, null);

            //Assert
            Assert.Equal(DURATION, director.Duration);
        }

        [Fact]
        public void GenreFilmDetailTest()
        {
            //Arrange
            var html = GenreFilmHtmlDocDetailsWebSite();
            var genre = new GenreFilmDetail();

            //Act
            genre.Process(html, null);

            //Assert
            Assert.Equal(GENRE, genre.Genre);
        }

        [Fact]
        public void RatingFilmDetailTest()
        {
            //Arrange
            var html = RatingFilmHtmlDocDetailsWebSite();
            var rating = new RatingFilmDetail();

            //Act
            rating.Process(html, null);

            //Assert
            Assert.Equal(RATING, rating.Rating);
        }

        [Fact]
        public void TitleFilmDetailTest()
        {
            //Arrange
            var html = TitleFilmHtmlDocDetailsWebSite();
            var title = new TitleFilmDetail();

            //Act
            title.Process(html, null);

            //Assert
            Assert.Equal(TITLE, title.Title);
        }
    }
}
