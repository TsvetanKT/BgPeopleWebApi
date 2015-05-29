BgPeopleWebApi
==============
BgPeopleWebApi is ASP.NET REST Server with Entity Framework Code First database

###Requirements:
*	Visual Studio.
*	Database (the server is configured for MS SQL Server with `Data Source=.` in `connectionStrings`).

###To run:
*	Download and restore nuget packages.
*	Start the SQL server.
*	Set up `BgPeopleWebApi.Services` as a StartUp project.
*	Run `Global.asax` from `BgPeopleWebApi.Services`.

### Routes examples:
*	`http://localhost:11647/api/BgPersonModels/GetBgPersonModels` - (GET) - Return all people.
*	`http://localhost:11647/api/BgPersonModels/GetBgPersonModes/6` - (GET) -  Show one with `Id = 6`.
*	`http://localhost:11647/api/BgPersonModels/DeleteBgPersonModel/10` - (DELETE) - Delete the person with `Id = 10`.
*	`http://localhost:11647/api/BgPersonModels/PutBgPersonModel/9` - (PUT) - Edit person with Id = 9 (Requires JSON body example):
*	`{` <br> `	"FirstName": "Симона",` <br> `	"MiddleName": "Тодорова",` <br> `	"LastName": "Ангелова",` <br> `	"IsMale": false,` <br> `	"BirthDay": "1917-09-25",` <br> `	"City": "Пещера",` <br> `	"PhoneNumber": "0880152625",` <br> `	"EGN": "1709258478"` <br> `}`
*	`http://localhost:11647/api/BgPersonModels/PostBgPersonModel` - (POST) - Add a person (Requires JSON body as above).
*	`http://localhost:11647/api/BgPersonModels/DeleteAll` - (DELETE) - Delete all people in the database.
*	`http://localhost:11647/api/BgPersonModels/PostRange` - (POST) - Generates a number of random people with [BgPersonGenerator library](https://github.com/TsvetanKT/BgPersonGenerator) (Requires JSON body example):
*	`{` <br> `	"NumberOfPeople": 25,` <br> `	"MinAge": 1,` <br> `	"MaxAge": 100,` <br> `	"TranslateToEnglish": false,` <br> `	"Unique": false` <br> `}`

```
{
    "NumberOfPeople": 25,
    "MinAge": 1,
    "MaxAge": 100,
    "TranslateToEnglish": false,
    "Unique": false
}
```