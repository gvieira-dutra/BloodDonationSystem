# Welcome to the Blood Donation System Application!

This README provides general information about the application, the technologies used, and instructions on how to get started.

## Overview

The Blood Donation System is designed to manage blood donation processes, ensuring efficient tracking of donors, blood stocks, and donations.

## Key Features

### Donor Registration
- Validate donor data.
- Integrate with an external API for postal code lookup during address registration.

### Blood Stock Control
- Notify users when blood stock reaches a predefined minimum quantity.

### Donation Records
- Automatically update blood stock whenever a donation is registered.

### Donor Inquiry
- Allow donors to consult their donation history.

### Reporting
- Generate reports on total blood available by type.
- Generate reports of donations from the last 30 days, including donor information.

## Business Rules

- Donors cannot register with existing email.
- Individuals under 18 years old can register but cannot donate.
- Donors must weigh at least 50 kg.
- Women can donate every 90 days.
- Men can donate every 60 days.
- The amount of blood donated must be between 420 ml and 470 ml.

## Architecture

This project adheres to Clean Architecture principles and is divided into four sections:

### API
- Controllers with routes and endpoints.
- Filters for data validation.
- Application settings.

### Application
- Business logic implementing the CQRS principle.
- Validator classes for data entry using Fluent Validation.

### Core
- Data Transfer Objects (DTOs).
- Entity classes for all application entities.
- Enumerables for predefined values.
- Interfaces for the Repository Pattern to access data in the database.

### Infrastructure
- Configuration classes for attribute relationships.
- Migrations for setting up tables in the database.
- Repository classes to access data based on business logic.
- DB Context for database access mediation.

## Technologies Used

- [.NET SDK](https://dotnet.microsoft.com/download) (version 8.0)
- [Visual Studio](https://visualstudio.microsoft.com/) (version 2019) with the following workloads:
  - ASP.NET and Web Development
- Microsoft SQL Server Management Studio (SSMS) - 20.1

## Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/gvieira-dutra/BloodDonationSystem
```

### 2. Navigate to the Project Directory

```bash
cd BloodDonationSystem
```

### 3. Open the Project in Visual Studio

1. Click on **File** > **Open** > **Project/Solution**.
2. Navigate to the cloned directory and select the `.sln` (Solution) file.

### 4. Restore Dependencies

Open the Package Manager Console in Visual Studio (Tools > NuGet Package Manager > Package Manager Console) and run:

```bash
dotnet restore
```

Alternatively, run the same command in a terminal.

### 5. Build the Solution

In Visual Studio, go to **Build** > **Build Solution** or use the shortcut **Ctrl+Shift+B**.

### 6. Update Connection String

In the `appsettings.json` file, update the connection string to match your SQL Server Express instance.

### 7. Apply Migrations

Run the following command to apply migrations:

```bash
dotnet ef database update
```

If you encounter issues, ensure the `dotnet-ef` tool is installed globally:

```bash
dotnet tool install --global dotnet-ef
```

### 8. Run the Application

To run the application, press **F5** or click the **Start** button in Visual Studio.
