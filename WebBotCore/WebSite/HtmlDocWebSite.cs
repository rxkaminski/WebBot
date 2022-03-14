using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBotCore.Helpers;
using WebBotCore.Response;
using WebBotCore.WebConnection;

namespace WebBotCore.WebSite
{
    public class HtmlDocWebSite : IWebSite
    {
        private readonly IWebUri webUri;
        private readonly IWebResponse webResponse;
        protected IEnumerable<IDetailWebSite<HtmlDocument>> htmlDocDetails;

        public HtmlDocWebSite(IWebUri webUri, IWebResponse webResponse)
        {
            this.webUri = webUri;
            this.webResponse = webResponse;
        }

        public async Task DownloadAsync()
        {
            var response = await webResponse.GetResponseAsync(webUri);

            if (response is IHtmlDocTranslatedResponse)
            {
                var htmlDocTransleted = (response as IHtmlDocTranslatedResponse);
                ProcessDetials(htmlDocTransleted);
            }
        }

        private void ProcessDetials(IHtmlDocTranslatedResponse htmlDocTransleted)
        {
            foreach (var htmlDocDetail in htmlDocDetails)
                htmlDocDetail.Process(htmlDocTransleted.HtmlDoc, webUri);
        }

        protected T Detail<T>() => htmlDocDetails.FirstOnTyppe<T, HtmlDocument>();
    }
}
