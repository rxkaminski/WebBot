using System.Threading.Tasks;
using WebBotCore.Response;
using WebBotCore.Tests.Translate;
using WebBotCore.Translate;
using WebBotCore.WebConnection;
using WebBotCore.WebSite.Converters;
using Xunit;

namespace WebBotCore.Tests.WebSite.Converters
{
    public class JsonToXmlConvertTest
    {
        [Fact]
        public void JsonToXmlConvert()
        {
            //Arrange
            var requestLocal = new JsonFakeRequest();
            var repeatLocal = new Repeat(requestLocal);
            var translateResponseLocal = new JsonToXmlTranslateResponse();

            var jsonFakeResponse = new WebResponse(repeatLocal, translateResponseLocal);

            var jsonToXmlConverter = new JsonToXmlConvert(null, jsonFakeResponse);

            //Act
            jsonToXmlConverter.DownloadAsync().GetAwaiter().GetResult();
            var xml = jsonToXmlConverter.Xml;

            //Assert
            Assert.Equal(JsonToXmlTranslateRespnseHelper.XmlElement, xml.OuterXml);
        }

        private class JsonFakeRequest : IRequest
        {
            public INoContentResponse InternlServerError()
            {
                return new InternalServerErrorResponse();
            }

            public IStatusOkResponse Ok(string value)
            {
                return new StatusOkResponse(value);
            }

#pragma warning disable CS1998
            public async Task<IResponse> SendAsync(IWebUri webUri)
            {
                return Ok(JsonToXmlTranslateRespnseHelper.JsonElement);
            }
#pragma warning restore CS1998
        }
    }
}
