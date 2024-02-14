# Financial Tracker API

The Financial Tracker API is a C# API that provides CRUD (Create, Read, Update, Delete) functionality for managing accounts and transactions. It is designed to work with a Microsoft Azure database, providing a reliable and scalable solution for tracking financial data.

## Features

- **Accounts Management**: Create, retrieve, update, and delete accounts.
- **Transactions Management**: Perform CRUD operations on financial transactions associated with accounts.

## Prerequisites

Before using the Financial Tracker API, ensure that you have the following prerequisites installed:

- .NET Core SDK
- Microsoft Azure account with a provisioned database.

## Usage

1. Clone the repository.
2. Navigate to the project directory.
3. Configure your Azure database connection string in the `appsettings.json` file.
4. Build and run the API.
5. Navigate to `http://localhost:{port}/swagger/index.html`.

## Endpoints

### Accounts

- `GET /api/account/all`: Retrieve all accounts.
- `GET /api/account/byId`: Retrieve an account by ID.
- `POST /api/account`: Create a new account.
- `PATCH /api/account/`: Update the balance of an account.
- `PATCH /api/account/account_name`: Update the name of an account.
- `DELETE /api/account/`: Delete an account.

### Transactions

- `GET /api/transactions/allByAccountId`: Retrieve all transactions for a specific account.
- `POST /api/transactions`: Create a new transaction for a specific account.
- `PATCH /api/transactions`: Update an existing transaction.
- `DELETE /api/transactions`: Delete a transaction for a specific account.

  
