using WebBotCore.Response;

namespace WebBotCore.Translate
{
    public interface ITranslateResponse
    {
        IResponse Translate(IResponse response);
    }
}
