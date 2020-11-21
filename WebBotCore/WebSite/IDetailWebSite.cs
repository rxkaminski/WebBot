using HtmlAgilityPack;
using WebBotCore.WebConnection;

namespace WebBotCore.WebSite
{
    public interface IDetailWebSite<T>
    {
        void Process(T htmlDoc, IWebUri webUri);
    }
}