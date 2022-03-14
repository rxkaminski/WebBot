using System.Threading.Tasks;
using WebBotCore.Response;
using WebBotCore.WebConnection;
using Xunit;

namespace WebBotCore.Tests.Web
{
    public class RepeatTest
    {
        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(5)]
        public void ReturnedOk(short rep)
        {
            //Arrange 
            var request = new RequestToTest(rep);
            var repeat = new Repeat(request, 5);

            //Act
            var response = repeat.GetResponseAsync(null).GetAwaiter().GetResult();

            //Assert
            Assert.True(response is IStatusOkResponse);
            Assert.Equal(rep, repeat.Repeated);
        }

        [Theory]
        [InlineData(6)]
        public void ReturnedInternalSeverError(short rep)
        {
            //Arrange 
            var request = new RequestToTest(rep);
            var repeat = new Repeat(request, 5);

            //Act
            var response = repeat.GetResponseAsync(null).GetAwaiter().GetResult();

            //Assert
            Assert.False(response is IStatusOkResponse);
            Assert.True(rep > repeat.Repeated);
        }
    }



    class RequestToTest : IRequest
    {
        private readonly RequestHttpClient request = new RequestHttpClient(null);
        private readonly short returnOkAfter;
        private short repeated = 0;

        public RequestToTest(short returnOkAfter)
        {
            this.returnOkAfter = returnOkAfter;
        }

#pragma warning disable CS1998
        public async Task<IResponse> SendAsync(IWebUri webUri)
        {
            repeated++;

            if (repeated >= returnOkAfter)
                return Ok("OK");

            return InternlServerError();
        }
#pragma warning restore CS1998

        public IStatusOkResponse Ok(string value)
            => request.Ok(value);

        public INoContentResponse InternlServerError()
            => request.InternlServerError();

    }
}

