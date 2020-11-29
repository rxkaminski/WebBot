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
            var jsonFakeResponse = WebResponseBuilder.Create(null, request: new JsonFakeRequest(), translateResponse: new JsonToXmlTranslateResponse());
            var jsonToXmlConverter = new JsonToXmlConvert(null, jsonFakeResponse);

            //Act
            jsonToXmlConverter.Download();
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

            public IResponse Send()
            {
                return Ok(JsonToXmlTranslateRespnseHelper.JsonElement);
            }
        }
    }
}
