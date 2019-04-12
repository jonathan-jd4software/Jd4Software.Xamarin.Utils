# Jd4Software.Xamarin.Utils
Having developed apps in Xamarin for clients for over 5 year, I have found that I keep repeating certain tasks over and over again.  I thought it was about time that I put these classes into a library and put it on https://nuget.org so I can access it easily in the future.  If others want to use this code then even better.

I will be adding to this project over time, but the initial version includes classes used for SQLite access.

## Tools used
### sqlite-net-pcl ###
Simple, powerful, cross-platform SQLite client and ORM for .NET - https://github.com/praeclarum/sqlite-net 


## Jd4Software.Xamarin.Utils.SQLite ##

Define a Simple data object for use in a SQLite database repository

```
using Jd4Software.Utils.SQLite;

namespace Test.DataModels
{
    public class SimpleData : Entity
    {
        public string Name { get; set; }
    }
}
```

Instantiate a DatabaseConnectionManager for a database named "test.db" in the application's documents folder

```
var dbConMgr = new DatabaseConnectionManager(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "test.db");
```
Using the interface definition ```IDatabaseConnectionManager``` the created  DatabaseConnectionManager can be added into IOC like this for MvvmCross
```
Mvx.IoCProvider.RegisterSingleton<IDatabaseConnectionManager>(dbConMgr);
```

A repository for the ```SimpleData``` class can be added into IOC (MvvmCross again)
```
Mvx.IoCProvider.RegisterSingleton<IRepository<SimpleData>>(new RepositoryBase<SimpleData>(dbConMgr));
```

The repository can then easily be accessed in Service classes or ViewModels as appropriate.  The best way to do this would be via constructor injection.

Dont forget that any database table needs to be created before any data access.  Here the rpeository is pulled out of IOC directly to create the table.

```
Mvx.IoCProvider.GetSingleton<IRepository<SimpleData>>().CreateTable();
```

