using System.Threading.Tasks;
using WebBotCore.Response;

namespace WebBotCore.WebConnection
{
    public interface IWebResponse
    {
        Task<IResponse> GetResponseAsync(IWebUri webUri);
    }
}