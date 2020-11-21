using System.Collections.Generic;

namespace WebBotCore.WebSite
{
    public class WebSiteCollection : IWebSite
    {
        private IEnumerable<IWebSite> webSites;

        public WebSiteCollection(IEnumerable<IWebSite> webUris)
        {
            this.webSites = webUris;
        }

        public void Download()
        {
            foreach (var webSite in webSites)
                webSite.Download();
        }
    }
}
