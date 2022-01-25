# Hospital management system

A console application that works with the Microsoft SQL Server database using Entity Framework Core 6 with code first approach.
The application allows you to set up accounts and manage patients in the hospital.


## Design patterns

#### Creational patterns
<ul>
    <li>
        <a href="https://refactoring.guru/design-patterns/builder"><b>Builder</b></a>
      <ul>
        <li><a href="https://github.com/damiandudek35146/Hospital/tree/master/Hospital.UI/Builder">Hospital.UI/Builder</a></li>
      </ul>
    </li>
    <br>
    <li>
      <a href="https://refactoring.guru/design-patterns/singleton"><b>Singleton</b></a>
      <ul >
        <li><a href="https://github.com/damiandudek35146/Hospital/blob/master/Hospital.DataLayer/ConnectionStringSingleton.cs"> ConnectionStringSingleton.cs </a></li>
      </ul>
    </li>
  </ul>
  
  #### Structural patterns
<ul>
    <li>
      <a href="https://refactoring.guru/design-patterns/facade"><b>Facade</b></a>
      <ul>
        <li><a href="https://github.com/damiandudek35146/Hospital/tree/master/Hospital.UI/Facade">Hospital.UI/Facade</a></li>
      </ul>
    </li>
     <br>
    <li>
      <a href="https://refactoring.guru/design-patterns/decorator"><b>Decorator</b></a>
      <ul>
        <li><a href="https://github.com/damiandudek35146/Hospital/tree/master/Hospital.UI/Decorator">Hospital.UI/Decorator</a></li>
      </ul>
    </li>
  </ul>
  
   #### Behavioral patterns
<ul>
    <li>
      <a href="https://refactoring.guru/design-patterns/strategy"><b>Strategy</b></a>
      <ul >
        <li><a href="https://github.com/damiandudek35146/Hospital/tree/master/Hospital.UI/Strategy">Hospital.UI/Strategy</a></li>
      </ul>
    </li>
     <br>
    <li>
      <a href="https://refactoring.guru/design-patterns/memento"><b>Memento</b></a>
      <ul>
        <li><a href="https://github.com/damiandudek35146/Hospital/tree/master/Hospital.UI/Memento">Hospital.UI/Memento</a></li>
      </ul>
    </li>
  </ul>
<br>

## Parallel Programming

### Task
<b>Creating a new task and using parallel loop</b>
![image](https://user-images.githubusercontent.com/56117599/151020794-0e3966ba-01f5-4b19-9c3a-216605415c08.png)
<br>
### Async
<b>An example of an async method</b>
![image](https://user-images.githubusercontent.com/56117599/151024042-33f911e4-3d76-48ce-8b14-308919de8831.png)


## About The Project
This project was created in order to get to know .Net 6 better, implement design patterns and asynchronous programming, connect with the database, implement good programming practices and independently solve encountered problems in the process of developing the application functionality.

### Built With
* [Visual Studio 2022](https://visualstudio.microsoft.com/pl/vs/)
* [C# 10.0](https://docs.microsoft.com/pl-pl/dotnet/csharp/whats-new/csharp-10)
* [.NET 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
* [Entity Framework Core (Code First)](https://docs.microsoft.com/pl-pl/ef/core/)
* [MS SQL Server](https://www.microsoft.com/pl-pl/sql-server/sql-server-downloads)


## Getting Started

This is an instruction how tu run this project

### Prerequisites

This is an example of how to list things you need to use the software and how to install them.
* Visual Studio
* SQL Server

### Run

1. Download this repo
2. Set login and password in connection string -> Hospital.DataLayer/ConnectionStringSingleton.cs
3. Open Package Manager Console and set dafault project as a Hospital.DataLayer
4. Add Migration in Package Manager Console
```
add-migration init
```
3. Update database in Package Manager Console
```
update-database
```
4. Set Hospital.UI as a startup project
5. Run and enjoy :)

## License
Distributed under the MIT License. See `LICENSE` for more information.

