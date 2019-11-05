# Hotel Finder

A software that helps you to find the best option between three hotels - based on the less expensive bill and classification levels. You can insert the dates you desire and the best hotel option will be returned to you.

## Getting Started

**Important**: This project was built using .NET Core 3.0, so you need to have this version of the framework and also the Visual Studio version 16.3 (or higher).
You can find the .NET Core needed here: https://dotnet.microsoft.com/download/thank-you/dotnet-sdk-3.0.100-windows-x64-installer

To start the project you should unzip the files, open the project with Visual Studio and rebuild the project, so the nuget packages can be downloaded. Then you can run it. 
A command line window will appear and you can insert the data, such as:

```
<client type>:, <date1>, <date2>, <date3> ....

Regular: 16Mar2009(mon), 17Mar2009(tues), 18Mar2009(wed)
```

The output will be the best hotel option (Lawekood, for this example).

## Project structure

The main project was structured using Models, Repositories and Services.

* Models

Models are the main classes we have in the project. We use them as example to instantiate new classes and organize our project acconding to the Object Oriented Programming paradigm.

* Repositories

A repository is a storage location. In this project, is where we store all the available hotels. Instantiating the repository gives full access to all the current hotels.

* Services

In the services folder we have the Hotel Best Option Searcher class. Is where we have all the logic concerning the hotel search. There we have all the funcions and validations needed to get to the correct output.








