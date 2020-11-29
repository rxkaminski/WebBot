using System.Xml;
using WebBotCore.Response;
using WebBotCore.Translate;
using WebBotCore.WebConnection;

namespace WebBotCore.WebSite.Converters
{
    public class JsonToXmlConvert : IWebSite
    {
        private readonly IWebResponse webResponse;

        public XmlDocument Xml { get; private set; }

        public JsonToXmlConvert(string uri, IWebResponse webResponse = null)
        {
            this.webResponse = webResponse ?? WebResponseBuilder.Create(new WebUri(uri),
                            translateResponse: new JsonToXmlTranslateResponse());
        }

        public void Download()
        {
            var response = webResponse.GetResponse();

            if (response is IJsonToXmlTranslatedResponse)
                Xml = (response as IJsonToXmlTranslatedResponse).Xml;
        }
    }
}
