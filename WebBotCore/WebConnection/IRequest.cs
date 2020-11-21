using WebBotCore.Response;

namespace WebBotCore.WebConnection
{
    public interface IRequest
    {
        IResponse Send();
        IStatusOkResponse Ok(string value);
        INoContentResponse InternlServerError();
    }
}
