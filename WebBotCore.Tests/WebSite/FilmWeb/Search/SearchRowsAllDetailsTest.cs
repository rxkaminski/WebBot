using HtmlAgilityPack;
using WebBotCore.WebConnection;
using WebBotCore.WebSite.FilmWeb.Search.Details.SearchRowsSubDetails;
using Xunit;
using static WebBotCore.Tests.WebSite.FilmWeb.Search.SearchRowsDetailsHelpers;

namespace WebBotCore.Tests.WebSite.FilmWeb.Search
{
    public class SearchRowsAllDetailsTest
    {
        private HtmlNode firstSearchRow;

        public SearchRowsAllDetailsTest()
        {
            firstSearchRow = GetFirstSearchRow();
        }

        [Fact]
        public void DurationSearchRowSubDetailTest()
        {
            //Arrange
            var duration = new DurationSearchRowSubDetail();

            //Act
            duration.Process(firstSearchRow, null);

            //Assert
            Assert.Equal(DURATION_1, duration.Duration);
        }

        [Fact]
        public void LinkSearchRowSubDetailTest()
        {
            //Arrange
            var link = new LinkSearchRowSubDetail();
            var webUri = new WebUri(HOST);

            //Act
            link.Process(firstSearchRow, webUri);

            //Assert
            Assert.Equal(HOST + LINK_1, link.Link);
        }

        [Fact]
        public void ReleaseSearchRowSubDetailTest()
        {
            //Arrange
            var release = new ReleaseSearchRowSubDetail();

            //Act
            release.Process(firstSearchRow, null);

            //Assert
            Assert.Equal(RELEASE_1, release.Release);
        }

        [Fact]
        public void TitleSearchRowSubDetailTest()
        {
            //Arrange
            var title = new TitleSearchRowSubDetail();

            //Act
            title.Process(firstSearchRow, null);

            //Assert
            Assert.Equal(TITLE_1, title.Title);
        }


        [Fact]
        public void YearSearchRowSubDetailTest()
        {
            //Arrange
            var year = new YearSearchRowSubDetail();

            //Act
            year.Process(firstSearchRow, null);

            //Assert
            Assert.Equal(YEAR_1, year.Year);
        }
    }
}
