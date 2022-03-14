using System.Threading.Tasks;
using WebBotCore.Response;

namespace WebBotCore.WebConnection
{
    public interface IRequest
    {
        Task<IResponse> SendAsync(IWebUri webUri);
        IStatusOkResponse Ok(string value);
        INoContentResponse InternlServerError();
    }
}
