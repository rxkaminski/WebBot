using System.Threading.Tasks;
using System.Xml;
using WebBotCore.Response;
using WebBotCore.Translate;
using WebBotCore.WebConnection;

namespace WebBotCore.WebSite.Converters
{
    public class JsonToXmlConvert : IWebSite
    {
        private readonly IWebResponse webResponse;
        private readonly IWebUri webUri;

        public XmlDocument Xml { get; private set; }

        public JsonToXmlConvert(string uri, IWebResponse webResponse)
        {
            this.webUri = new WebUri(uri);
            this.webResponse = webResponse;
        }

        public async Task DownloadAsync()
        {
            var response = await webResponse.GetResponseAsync(webUri);

            if (response is IJsonToXmlTranslatedResponse)
                Xml = (response as IJsonToXmlTranslatedResponse).Xml;
        }
    }
}
