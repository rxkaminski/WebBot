using WebBotCore.Response;
using WebBotCore.WebConnection;
using Xunit;

namespace WebBotCore.Tests.Web
{
    public class RequestTest
    {
        [Fact]
        public void GoodRequest()
        {
            //Arrange
            var webUri = new WebUri("https://microsoft.com");
            var request = new Request(webUri);

            //Act
            var response = request.Send();

            //Asset
            Assert.True(response is IStatusOkResponse);
        }

        [Fact]
        public void BadRequest()
        {
            //Arrange
            var webUri = new WebUri("https://micrasfasfasfasosoftm");
            var request = new Request(webUri);

            //Act
            var response = request.Send();

            //Assert
            Assert.False(response is IStatusOkResponse);
        }
    }
}
