# Native-apps-2-Windows-Groep-NL9

Project for the course Native apps 2: Windows


## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

You need Visual Studio 2017

### Installing


First clone the project and open the solution. This solution contains 2 projects, the frontend and the backend.

There are 2 options for Data to use, the MockDataSource, which is limited in usage (It will throw NotImplementedExceptions, you have been warned!), and you have the actual REST backend (OnlineDataSource). This one runs off an actual SQL database.

To change which of the 2 data sources you want to use, you need to change this in the [IDataSource](Windows-App/Data/IDataSource.cs) file:

```C#
Line 16:
        //SINGLETON
        public static IDataSource singleton = new OnlineDataSource();
        
        //Change new OnlineDataSource() to MockDataSource() to change to Mock data
```

If you would like to use the backend with the SQL database, you will first have to fill generate the database and fill it with some data. 

Set BackendV7 as startup project in the solution

Open the Nuget Package Manager Console and type this:

```
Update-Database
```

If all goes correct, there shouldn't be any errors and the database is filled with some business and establishments to explore!

(Don't forget to set the solution as startup project and select both frontend and backend to start up when starting the solution)


## Built With

* [UWP](https://docs.microsoft.com/en-us/windows/uwp/design/basics/design-and-ui-intro) - Platform which the app is built on
* [ASP.NET](https://www.asp.net) - The framework used for the backend
* [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/) - Used to create the database and the backend using code first migrations

## Authors

* **Jens De Taey** - *Initial work* - [JensDeTaey](https://github.com/JensDeTaey)
* **Robin De Bock** - *Initial work* - [RobinDeBock](https://github.com/RobinDeBock)
* **Casper Verswijvelt** - *Initial work* - [CasperVerswijvelt](https://github.com/CasperVerswijvelt)


