using System.Xml;

namespace WebBotCore.Response
{
    class JsonToXmlTranslatedResponse: IJsonToXmlTranslatedResponse
    {
        public XmlDocument Xml { get; }

        public string Content { get; }

        public int StatusCode { get; }

        public JsonToXmlTranslatedResponse(XmlDocument xml, IStatusOkResponse statusOkResopnse)
        {
            Xml = xml;
            Content = statusOkResopnse.Content;
            StatusCode = statusOkResopnse.StatusCode;
        }
    }
}
