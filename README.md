BgPeopleWebApi
==============
BgPeopleWebApi is ASP.NET REST Server with Entity Framework Code First database


### Routes examples:
*	`http://localhost:11647/api/BgPersonModels/GetBgPersonModels` - (GET) - Return all people.
*	`http://localhost:11647/api/BgPersonModels/GetBgPersonModes/6` - (GET) -  Show one with Id = 6.
*	`http://localhost:11647/api/BgPersonModels/DeleteBgPersonModel/10` - (DELETE) - Delete the person with Id = 10.
*	`http://localhost:11647/api/BgPersonModels/PutBgPersonModel/9` - (Put) - Edit person with Id = 9 (Requires JSON body):
*	`{` <br> `	"Id": 13,` <br> `	"FirstName": "Симона",` <br> `	"MiddleName": "Тодорова",` <br> `	"LastName": "Ангелова",` <br> `	"IsMale": false,` <br> `	"BirthDay": "1917-09-25",` <br> `	"City": "Пещера",` <br> `	"PhoneNumber": "0880152625",` <br> `	"EGN": "1709258478"` <br> `}`

*	`http://localhost:11647/api/BgPersonModels/PostBgPersonModel` - (Post) - Add a person (Requires JSON body as above).
*	`http://localhost:11647/api/BgPersonModels/DeleteAll` - (DELETE) - Delete all people in the database.
*	`http://localhost:11647/api/BgPersonModels/PostRange` - (Post) - Generates a number of random people with [BgPersonGenerator library](https://github.com/TsvetanKT/BgPersonGenerator) (Requires JSON body):
*	`{` <br> `	"NumberOfPeople": 25,` <br> `	"MinAge": 1,` <br> `	"MaxAge": 100,` <br> `	"TranslateToEnglish": false,` <br> `	"Unique": false` <br> `}`
