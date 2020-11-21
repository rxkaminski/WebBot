namespace WebBotCore.Response
{
    public class StatusOkResponse : IStatusOkResponse
    {
        private const int STATUS_OK = 200;

        public int StatusCode => STATUS_OK;
        public string Content { get; private set; }

        public StatusOkResponse(string content)
        {
            Content = content;
        }
    }
}
