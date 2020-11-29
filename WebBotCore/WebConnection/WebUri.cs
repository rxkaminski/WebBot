using System;
using System.Web;

namespace WebBotCore.WebConnection
{
    public class WebUri : IWebUri
    {
        private readonly Uri uri;

        public bool AbsoluteUriCorrected { get; } = false;
        public string AbsoluteUri { get => uri?.AbsoluteUri; }
        public string Host { get; private set; }
        
        public WebUri(string uri)
        {
            uri = HttpUtility.UrlDecode(uri);

            if (Uri.TryCreate(uri, UriKind.Absolute, out var resultUri))
            {
                AbsoluteUriCorrected = true;
                this.uri = resultUri;

                if (resultUri.AbsolutePath != "/")
                {
                    var idx = resultUri.AbsoluteUri.IndexOf(resultUri.AbsolutePath);
                    Host = resultUri.AbsoluteUri.Substring(0, idx);
                }
                else
                {
                    Host = resultUri.AbsoluteUri.TrimEnd('/');
                }
            }
        }
    }
}
