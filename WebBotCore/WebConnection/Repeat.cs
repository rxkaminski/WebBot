using System.Threading.Tasks;
using WebBotCore.Response;

namespace WebBotCore.WebConnection
{
    public class Repeat : IRepeat
    {
        private readonly IRequest request;

        public short RepeatCount { get; }
        public short Repeated { get; private set; }

        public Repeat(IRequest request, short repeatCount = 3)
        {
            this.request = request;
            this.RepeatCount = repeatCount;
        }

        public async Task<IResponse> GetResponseAsync(IWebUri webUri)
        {
            Repeated = 0;

            for (var i = 1; i <= RepeatCount; i++)
            {
                IResponse response = await request.SendAsync(webUri);
                Repeated++;

                if (!(response is IStatusOkResponse))
                    continue;

                return response;
            }

            return request.InternlServerError();
        }
    }
}
