using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;

namespace WebBotCore.Translate
{
    public  class JsonToXmlNodeConverter : XmlNodeConverter
    {
        public string DeserializeArrayElementName { get; set; }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token;
            if (reader.TokenType == JsonToken.StartArray) {
                var jarray = JArray.Load(reader);
                token = new JObject() { { DeserializeRootElementName, jarray } };
                DeserializeRootElementName = DeserializeArrayElementName;
            }
            else
                token = JObject.Load(reader);

            var innerReader = token.CreateReader();
            innerReader.Read();
            return base.ReadJson(innerReader, objectType, existingValue, serializer);
        }
    }
}