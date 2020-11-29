using WebBotCore.Translate;
using WebBotCore.Response;
using Xunit;
using System.Xml;
using static WebBotCore.Tests.Translate.JsonToXmlTranslateRespnseHelper;

namespace WebBotCore.Tests.Translate
{
    public class JsonToXmlTranslateRespnseTest
    {

        [Fact]
        public void CanTranslatedResponse()
        {
            //Arrange
            var statusOkResponse = new StatusOkResponse(JsonElement);

            //Act
            var response = (new JsonToXmlTranslateResponse()).Translate(statusOkResponse);

            //Assert
            Assert.True(response is IJsonToXmlTranslatedResponse);
        }

        [Fact]
        public void CantTranslatedResponse()
        {
            //Arrange
            var internalServerError = new InternalServerErrorResponse();

            //Act
            var response = (new JsonToXmlTranslateResponse()).Translate(internalServerError);

            //Assert
            Assert.False(response is IJsonToXmlTranslatedResponse);
        }

        [Fact]
        public void CorredJsonToXmlTranslation()
        {
            //Arrange
            var statusOkResponse = new StatusOkResponse(JsonElement);

            //Act
            var response = (new JsonToXmlTranslateResponse()).Translate(statusOkResponse);

            //Assert
            Assert.True(response is IJsonToXmlTranslatedResponse);
            Assert.True((response as IJsonToXmlTranslatedResponse)?.Xml is XmlDocument);
        }

        [Fact]
        public void NotCorredJsonToXmlTranslation()
        {
            //Arrange
            var statusOkResponse = new StatusOkResponse("test test test");

            //Act
            var response = (new JsonToXmlTranslateResponse()).Translate(statusOkResponse);

            //Assert
            Assert.True(response is INoContentResponse);
        }

        [Fact]
        public void ConvertJsonArrayElementsToXml()
        {
            //Arrange
            var statusOkResponse = new StatusOkResponse(JsonArrayOfElements);

            //Act
            var response = (new JsonToXmlTranslateResponse()).Translate(statusOkResponse);

            //Assert
            Assert.Equal(2, ((IJsonToXmlTranslatedResponse)response).Xml.FirstChild.ChildNodes.Count);
            Assert.Equal("Elements", ((IJsonToXmlTranslatedResponse)response).Xml.FirstChild.Name);
            Assert.Equal("Element", ((IJsonToXmlTranslatedResponse)response).Xml.FirstChild.FirstChild.Name);
        }


        [Fact]
        public void ConvertJsonElementToXml()
        {
            //Arrange
            var statusOkResponse = new StatusOkResponse(JsonElement);

            //Act
            var response = (new JsonToXmlTranslateResponse()).Translate(statusOkResponse);

            //Assert
            Assert.Equal("Element", ((IJsonToXmlTranslatedResponse)response).Xml.FirstChild.Name);
        }
    }
}
