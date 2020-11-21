using HtmlAgilityPack;
using WebBotCore.WebConnection;

namespace WebBotCore.WebSite.FilmWeb.Film.Details
{
    public class CreatorFilmDetail : IDetailWebSite<HtmlDocument>
    {
        public string Creator { get; private set; }

        public void Process(HtmlDocument htmlDoc, IWebUri webUri)
        {
            var a = htmlDoc.DocumentNode.SelectSingleNode("//a[@itemprop='creator']");
            Creator = a?.InnerText?.Trim();
        }
    }
}
