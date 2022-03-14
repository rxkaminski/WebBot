using System.Threading.Tasks;

namespace WebBotCore.WebSite
{
    public interface IWebSite
    {
        Task DownloadAsync();
    }
}