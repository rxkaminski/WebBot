using HtmlAgilityPack;
using WebBotCore.Response;
using WebBotCore.Translate;
using Xunit;

namespace WebBotCore.Tests.Translate
{
    public class HtmlDocTranslateResponseTest
    {
        [Fact]
        public void CanTranslatedResponse()
        {
            //Arrange
            var statusOkResponse = new StatusOkResponse("test");

            //Act
            var response = (new HtmlDocTranslateResponse()).Translate(statusOkResponse);

            //Assert
            Assert.True(response is IHtmlDocTranslatedResponse);
        }

        [Fact]
        public void CantTranslatedResponse()
        {
            //Arrange
            var internalServerError = new InternalServerErrorResponse();

            //Act
            var response = (new HtmlDocTranslateResponse()).Translate(internalServerError);

            //Assert
            Assert.False(response is IHtmlDocTranslatedResponse);
        }

        [Fact]
        public void TestCoretcHtmlTranslation()
        {
            //Arrange
            var statusOkResponse = new StatusOkResponse("<html></html>");

            //Act
            var response = (new HtmlDocTranslateResponse()).Translate(statusOkResponse);

            //Assert
            Assert.True(response is IHtmlDocTranslatedResponse);
            Assert.True((response as IHtmlDocTranslatedResponse)?.HtmlDoc is HtmlDocument);
        }
    }
}
