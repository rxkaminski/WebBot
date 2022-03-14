using System.Threading.Tasks;
using WebBotCore.Response;

namespace WebBotCore.WebConnection
{
    public interface IRepeat
    {
        Task<IResponse> GetResponseAsync(IWebUri webUri);
    }
}
