using System.Net.Http;
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
            var request = new RequestHttpClient(new HttpClient());

            //Act
            var response = request.SendAsync(webUri).GetAwaiter().GetResult();

            //Asset
            Assert.True(response is IStatusOkResponse);
        }

        [Fact]
        public void BadRequest()
        {
            //Arrange
            var webUri = new WebUri("https://micrasfasfasfasosoftm");
            var request = new RequestHttpClient(new HttpClient());

            //Act
            var response = request.SendAsync(webUri).GetAwaiter().GetResult();

            //Assert
            Assert.False(response is IStatusOkResponse);
        }
    }
}
