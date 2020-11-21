using System.Linq;
using WebBotCore.WebConnection;
using WebBotCore.WebSite.FilmWeb.Search;
using Xunit;
using static WebBotCore.Tests.WebSite.FilmWeb.Search.SearchRowsDetailsHelpers;

namespace WebBotCore.Tests.WebSite.FilmWeb.Search
{
    public class SearchRowsDetailsTest
    {
        [Fact]
        public void FilmSearchRowsHtmlDocDetailWebSiteTest()
        {
            //Arrange
            var html = CreateSearchRowsHtmlDocDetailWebSite();
            var search = new SearchRowsDetail();
            var webUri = new WebUri(HOST);

            //Act
            search.Process(html, webUri);
            var searchRows = search.SearchRows;

            var row1 = searchRows.ElementAt(0);
            var row2 = searchRows.ElementAt(1);

            //Assert
            Assert.Equal(2, searchRows.Count);

            Assert.Equal(TITLE_1, row1.Title);
            Assert.Equal(YEAR_1, row1.Year);
            Assert.Equal(DURATION_1, row1.Duration);
            Assert.Equal(RELEASE_1, row1.Release);
            Assert.Equal(HOST + LINK_1, row1.Link);

            Assert.Equal(TITLE_2, row2.Title);
            Assert.Equal(YEAR_2, row2.Year);
            Assert.Equal(DURATION_2, row2.Duration);
            Assert.Equal(RELEASE_2, row2.Release);
            Assert.Equal(HOST + LINK_2, row2.Link);

        }
    }
}
