using System;
using System.IO;
using System.Net;
using WebBotCore.Response;

namespace WebBotCore.WebConnection
{
    public class Request : IRequest
    {
        private readonly IWebUri uri;

        public Request(IWebUri uri)
        {
            this.uri = uri;
        }

        public IResponse Send()
        {
            try
            {
                if (!uri.AbsoluteUriCorrected)
                    return InternlServerError();

                string responseFromServer;

                var request = WebRequest.Create(uri.AbsoluteUri);
                request.Credentials = CredentialCache.DefaultCredentials;

                using (var response = request.GetResponse())
                using (var dataStream = response.GetResponseStream())
                using (var reader = new StreamReader(dataStream))
                    responseFromServer = reader.ReadToEnd();

                return Ok(responseFromServer);
            }
            catch(Exception)
            {
                return InternlServerError();
            }
        }

        public IStatusOkResponse Ok(string value)
        {
            return new StatusOkResponse(value);
        }

        public INoContentResponse InternlServerError()
        {
            return new InternalServerErrorResponse();
        }


    }
}
