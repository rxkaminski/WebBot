using System.Xml;

namespace WebBotCore.Response
{
    public interface IJsonToXmlTranslatedResponse : ITranslatedResponse
    {
        public XmlDocument Xml { get; }
    }
}
