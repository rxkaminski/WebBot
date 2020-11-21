namespace WebBotCore.Response
{
    public class InternalServerErrorResponse : INoContentResponse
    {
        private const int INTERNAL_SERVER_ERROR = 500;

        public int StatusCode => INTERNAL_SERVER_ERROR;
    }
}
