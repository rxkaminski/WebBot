using Newtonsoft.Json;
using System;
using System.Xml;
using WebBotCore.Response;

namespace WebBotCore.Translate
{
    public class JsonToXmlTranslateResponse : ITranslateResponse
    {
        public IResponse Translate(IResponse response)
        {
            if (!(response is IStatusOkResponse))
                return response;

            var iStatusOkResponse = response as IStatusOkResponse;
            var json = iStatusOkResponse.Content;

            try
            {
                var nodeCorverter = new JsonToXmlNodeConverter()
                {
                    DeserializeRootElementName = "Element",
                    DeserializeArrayElementName = "Elements"
                };

                var xml = (XmlDocument)JsonConvert.DeserializeObject(json, typeof(XmlDocument), nodeCorverter);
                return new JsonToXmlTranslatedResponse(xml, iStatusOkResponse);
            }
            catch (Exception)
            {
                return new InternalServerErrorResponse();
            }
        }
    }
}
