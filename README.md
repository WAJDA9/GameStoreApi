# Game Store API - Backend Service

## Introduction

The **Game Store API** is a backend service developed using .NET that powers an online game store. This API provides endpoints for managing games, users, orders, and other related entities.

## Technologies Used

- **.NET Core**
- **Entity Framework Core**
- **SQL Server**
- **JWT (JSON Web Tokens)**
- **Swagger**
- **xUnit**
- **Docker**

## Features

- User Management
- Game Management
- Order Management
- Search and Filter
- Authentication and Authorization
- Pagination and Sorting
- Error Handling

## Getting Started

### Prerequisites

- .NET SDK (version 6.0 or later)
- SQL Server (or any other compatible database)
- Docker (optional, for containerization)

### Installation

1. Clone the repository:
   ```sh
   git clone https://github.com/yourusername/game-store-api.git
   cd game-store-api
   ```

2. Restore dependencies:
   ```sh
   dotnet restore
   ```

3. Build the project:
   ```sh
   dotnet build
   ```

4. Run the application:
   ```sh
   dotnet run
   ```

### Configuration

- Update the `appsettings.json` file with your database connection string and other configurations.

## API Endpoints

- **Users**: `/api/users`
- **Games**: `/api/games`
- **Orders**: `/api/orders`

## Contributing

Contributions are welcome! Please read the [contributing guidelines](CONTRIBUTING.md) before getting started.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
