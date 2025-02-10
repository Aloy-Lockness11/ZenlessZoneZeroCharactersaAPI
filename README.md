# Zenless Zone Zero Character API

This is a **RESTful API** for managing **characters and items** in Zenless Zone Zero. It allows users to create, retrieve, update, and delete characters and items, as well as assign items to characters.

## Features
- **CRUD operations** for Characters & Items.
- **Assign Items to Characters** dynamically.
- **Entity Framework Core with SQL Server** as the database.
- **Postman Collection for API testing**.

---

## Prerequisites
Before setting up the project, ensure you have the following installed:

- **.NET 6.0 or later** → [Download Here](https://dotnet.microsoft.com/en-us/download)
- **SQL Server** → [Download Here](https://www.apachefriends.org/download.html)
- **Postman** (for API testing) → [Download Here](https://www.postman.com/downloads/)
- **Entity Framework Core CLI** (Install via `dotnet tool`)

---

##  Setup & Installation

###  Clone the Repository**
```sh
git clone https://github.com/yourusername/ZenlessZoneZeroCharacterAPI.git
cd ZenlessZoneZeroCharacterAPI
```


### Configure Database Connection
- Open the project in Visual Studio or VS Code.
- Navigate to appsettings.json.
- Modify the connection string to match your SQL Server instance:

"ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=ZZZCharactersDB;Trusted_Connection=True;MultipleActiveResultSets=true"
}

### install Dependencies
dotnet restore

### Run Database Migrations
dotnet ef database update

### Run the API
