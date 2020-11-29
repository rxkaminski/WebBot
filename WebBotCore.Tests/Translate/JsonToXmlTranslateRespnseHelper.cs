namespace WebBotCore.Tests.Translate
{
    public static class JsonToXmlTranslateRespnseHelper
    {
        public static string JsonElement => @"{
    ""Id"": 2,
    ""UserId"": 1,
    ""From"": ""2020-01-20T00:00:00Z"",
    ""To"": ""2020-01-24T00:00:00Z"",
    ""TypeId"": 3,
    ""ProjectId"": 1,
    ""Description"": ""Status event for Nowak Rafa\u0142: business trip"",
    ""Type"": {
      ""Id"": 3,
      ""Description"": ""business trip""
    },
    ""Project"": {
      ""Id"": 1,
      ""Number"": ""20-0005"",
      ""Title"": ""Projekt 5""
    },
    ""CreatedById"": 1,
    ""CreatedAt"": ""2020-11-07T21:51:13Z"",
    ""CreatedBy"": null,
    ""ModifiedById"": 1,
    ""ModifiedAt"": ""2020-11-07T21:51:13Z"",
    ""ModifiedBy"": null
  }";

        public static string XmlElement => "<Element><Id>2</Id><UserId>1</UserId><From>2020-01-20T00:00:00Z</From><To>2020-01-24T00:00:00Z</To><TypeId>3</TypeId><ProjectId>1</ProjectId><Description>Status event for Nowak Rafał: business trip</Description><Type><Id>3</Id><Description>business trip</Description></Type><Project><Id>1</Id><Number>20-0005</Number><Title>Projekt 5</Title></Project><CreatedById>1</CreatedById><CreatedAt>2020-11-07T21:51:13Z</CreatedAt><CreatedBy /><ModifiedById>1</ModifiedById><ModifiedAt>2020-11-07T21:51:13Z</ModifiedAt><ModifiedBy /></Element>";

        public static string JsonArrayOfElements => @"[
  {
    ""Id"": 2,
    ""UserId"": 1,
    ""From"": ""2020-01-20T00:00:00Z"",
    ""To"": ""2020-01-24T00:00:00Z"",
    ""TypeId"": 3,
    ""ProjectId"": 1,
    ""Description"": ""Status event for Nowak Rafa\u0142: business trip"",
    ""Type"": {
      ""Id"": 3,
      ""Description"": ""business trip""
    },
    ""Project"": {
      ""Id"": 1,
      ""Number"": ""20-0005"",
      ""Title"": ""Projekt 5""
    },
    ""CreatedById"": 1,
    ""CreatedAt"": ""2020-11-07T21:51:13Z"",
    ""CreatedBy"": null,
    ""ModifiedById"": 1,
    ""ModifiedAt"": ""2020-11-07T21:51:13Z"",
    ""ModifiedBy"": null
  },
  {
    ""Id"": 3,
    ""UserId"": 1,
    ""From"": ""2020-01-27T00:00:00Z"",
    ""To"": ""2020-01-31T00:00:00Z"",
    ""TypeId"": 4,
    ""ProjectId"": 1,
    ""Description"": ""Status event for Nowak Rafa\u0142: home office"",
    ""Type"": {
      ""Id"": 4,
      ""Description"": ""home office""
    },
    ""Project"": {
      ""Id"": 1,
      ""Number"": ""20-0005"",
      ""Title"": ""Projekt 5""
    },
    ""CreatedById"": 1,
    ""CreatedAt"": ""2020-11-07T21:51:13Z"",
    ""CreatedBy"": null,
    ""ModifiedById"": 1,
    ""ModifiedAt"": ""2020-11-07T21:51:13Z"",
    ""ModifiedBy"": null
  }
]";
    }
}
