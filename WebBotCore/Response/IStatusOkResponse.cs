namespace WebBotCore.Response
{
    public interface IStatusOkResponse : IResponse
    {
        string Content { get; }
    }
}
