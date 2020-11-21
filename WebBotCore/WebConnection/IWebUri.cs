namespace WebBotCore.WebConnection
{
    public interface IWebUri
    {
        bool AbsoluteUriCorrected { get; }
        string AbsoluteUri { get; }
        string Host { get; }
    }
}