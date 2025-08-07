# OMS.EFCore

> Order Management System with Entity Framwork Core 8
  
# Quick Start Guide

Prerequisites:

- .NET 8 SDK installed.
- Visual Studio IDE.
- SQL Server Data Tools installed in IDE.

Please follow the below instructions.

1. Clone this repository to your local.
2. Open up the `./OMS.EFCore.sln`.
3. This would up the Starter solution which has 3 main components.
   1. Web API (set as the default project)
   2. Libraries
   3. Unit Test
4. Now we will have to set the connection string for the API. Navigate to `./OMS.EFCore/appsettings.json` and change the `ConnectionString` under `OMSEFCoreDbContext`. Save it.
5. Once that is done, run the application via Visual Studio, with OMS.EFCore as the default project. This will open up OMS.EFCore API at `https://localhost:7204/swagger/index.html`.

# 🔎 The Project

# ✨ Technologies

- Entity Framework Core 8
- xUnit Test

# 🧪 Running Locally
  
# 📝 Notes

## Add Migrations

In IDE tools, open Package Manger Console (Tools > NuGet Package Manger > Package Manger Console)
In the Default Project options, please choose OMS.EFCore.Data, then execute the commands below in turn:

```bash
	Add-Migration OMSCore
	Update-Database
```

