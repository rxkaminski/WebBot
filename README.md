# WebBot

The project in progress.

### Introduction
##### 1. WebBot application get information from the website and shared as WebApi
##### 1.1 Example to search a film
Use url:
`https://localhost:44387/api/FilmWeb/search/films/rambo`
Response:
```json
[
  {
    "title": "Rambo: Pierwsza krew",
    "year": "1982",
    "duration": "93",
    "release": "1982-10-22",
    "link": "https://www.film[remove]web.pl/film/Rambo%3A+Pierwsza+krew-1982-9063"
  },
  {
    "title": "John Rambo",
    "year": "2008",
    "duration": "92",
    "release": "2008-03-07",
    "link": "https://www.film[remove]web.pl/film/John+Rambo-2008-219806"
  }
  ......
]
```
##### 1.2 Example to show details of film
Use url:
`https://localhost:44387/api/FilmWeb/film/John%2BRambo-2008-219806`
Response:
```json 
{
  "title": "John Rambo",
  "duration": "92",
  "rating": "6,8",
  "genre": "Akcja",
  "directior": "Sylvester Stallone",
  "creator": "Sylvester Stallone"
}
```

##### 2. WebBot transform json response from external API to xml format
##### 2.1 Example

Orginal request: `https://localhost:44337/api/user/1/status/event`
Orginal response:
```json
[
  {
    "Id": 2,
    "UserId": 1,
    "From": "2020-01-20T00:00:00Z",
    "To": "2020-01-24T00:00:00Z",
    "TypeId": 3,
    "ProjectId": 1,
    "Description": "Status event for Nowak Rafa\u0142: business trip",
    "Type": {
      "Id": 3,
      "Description": "business trip"
    },
    "Project": {
      "Id": 1,
      "Number": "20-0005",
      "Title": "Projekt 5"
    },
    "CreatedById": 1,
    "CreatedAt": "2020-11-07T21:51:13Z",
    "CreatedBy": null,
    "ModifiedById": 1,
    "ModifiedAt": "2020-11-07T21:51:13Z",
    "ModifiedBy": null
  },
    ...
]
```

Request to convert JSON response to XML format: `https://localhost:44387/api/Converter/jsontoxml/https%3A%2F%2Flocalhost%3A44337%2Fapi%2Fuser%2F1%2Fstatus%2Fevent`

Response:
```xml
<Elements>
  <Element>
    <Id>2</Id>
    <UserId>1</UserId>
    <From>2020-01-20T00:00:00Z</From>
    <To>2020-01-24T00:00:00Z</To>
    <TypeId>3</TypeId>
    <ProjectId>1</ProjectId>
    <Description>Status event for Nowak Rafał: business trip</Description>
    <Type>
      <Id>3</Id>
      <Description>business trip</Description>
    </Type>
    <Project>
      <Id>1</Id>
      <Number>20-0005</Number>
      <Title>Projekt 5</Title>
    </Project>
    <CreatedById>1</CreatedById>
    <CreatedAt>2020-11-07T21:51:13Z</CreatedAt>
    <CreatedBy />
    <ModifiedById>1</ModifiedById>
    <ModifiedAt>2020-11-07T21:51:13Z</ModifiedAt>
    <ModifiedBy />
  </Element>
    ...
</Elements>
```


#### ToDo:
Get informationn from other API.

### Used
- .Net Core 3.1
- WebApi
- xUnit
- HtmlAgilityPack
- Mapster
- Docker
- Swagger
- async/await
- IHttpClientFactory
