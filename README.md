# Orfelin – Library Management System

A desktop application for managing library operations, built with C# and WPF.

## Tech Stack

- **Frontend:** WPF (.NET 8)
- **Backend:** ASP.NET Core Web API
- **Database:** SQL Server (Entity Framework Core)
- **Architecture:** 3-tier (Core / API / WPF)

## Features

- Role-based login (Librarian / Manager)
- Book management (CRUD)
- Reader management (CRUD)
- Employee management (Manager only)
- Book borrowing and returns

## Project Structure
Orfelin.Core   – Models, DbContext, Services, Interfaces
Orfelin.API    – REST API Controllers
Orfelin.WPF    – Desktop UI

## Default Login

| Username | Password | Role |
|----------|----------|------|
| root | root | Rukovodilac |

## Getting Started

1. Clone the repository
2. Update connection string in `Orfelin.API/appsettings.json`
3. Run migrations: `Update-Database`
4. Start both `Orfelin.API` and `Orfelin.WPF`