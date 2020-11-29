using Microsoft.AspNetCore.Mvc;
using WebBotCore.WebSite.Converters;


namespace WebBotApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConverterController
    {
        /// <summary>
        /// Convert JSON response from jsonEndPoint to the XML format
        /// </summary>
        /// <param name="jsonEndPoint">Endpoint with http[s]://</param>
        /// <returns></returns>
        [HttpGet("jsontoxml/{jsonEndPoint}")]
        public IActionResult JsonToXml(string jsonEndPoint)
        {
            if (string.IsNullOrWhiteSpace(jsonEndPoint))
                return new StatusCodeResult(400);

            var jsonToXmlConvert = new JsonToXmlConvert(jsonEndPoint);
            jsonToXmlConvert.Download();

            if (jsonToXmlConvert.Xml == null)
                return new StatusCodeResult(404);

            return new ContentResult()
            {
                Content = jsonToXmlConvert.Xml.OuterXml,
                ContentType = "text/xml"
            };
        }
    }
}
