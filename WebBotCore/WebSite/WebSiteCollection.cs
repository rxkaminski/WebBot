using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebBotCore.WebSite
{
    public class WebSiteCollection : IWebSite
    {
        private IEnumerable<IWebSite> webSites;

        public WebSiteCollection(IEnumerable<IWebSite> webUris)
        {
            this.webSites = webUris;
        }

        public async Task DownloadAsync()
        {
            foreach (var webSite in webSites)
                await webSite.DownloadAsync();
        }
    }
}
