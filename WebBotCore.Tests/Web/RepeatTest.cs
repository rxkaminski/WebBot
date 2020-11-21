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
            var response = repeat.GetResponse();

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
            var response = repeat.GetResponse();

            //Assert
            Assert.False(response is IStatusOkResponse);
            Assert.True(rep > repeat.Repeated);
        }
    }



    class RequestToTest : IRequest
    {
        private readonly Request request = new Request(null);
        private readonly short returnOkAfter;
        private short repeated = 0;

        public RequestToTest(short returnOkAfter)
        {
            this.returnOkAfter = returnOkAfter;
        }

        public IResponse Send()
        {
            repeated++;

            if (repeated >= returnOkAfter)
                return Ok("OK");

            return InternlServerError();
        }


        public IStatusOkResponse Ok(string value)
            => request.Ok(value);

        public INoContentResponse InternlServerError()
            => request.InternlServerError();


    }
}

