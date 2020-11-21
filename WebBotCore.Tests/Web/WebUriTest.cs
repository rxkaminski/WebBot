using WebBotCore.WebConnection;
using Xunit;

namespace WebBotCore.Tests.Web
{
    public class WebUriTest
    {
        [Fact]
        public void UriCorrected()
        {
            //Act
            var webUri = new WebUri("https://microsoft.com");

            //Assert
            Assert.True(webUri.AbsoluteUriCorrected);
            Assert.NotNull(webUri.AbsoluteUri);
        }

        [Fact]
        public void UriNotCorrected()
        {
            //Act
            var webUri = new WebUri("microsoft.com");

            //Assert
            Assert.False(webUri.AbsoluteUriCorrected);
            Assert.Null(webUri.AbsoluteUri);
        }

        [Theory]
        [InlineData("https://www.www.pl/")]
        [InlineData("https://www.www.pl")]
        [InlineData("https://www.www.pl/site2345/asasa")]
        public void CalculateHost(string uri)
        {
            //Arrange
            //Act
            var webUri = new WebUri(uri);

            //Assert
            Assert.Equal("https://www.www.pl", webUri.Host);
        }
    }
}
