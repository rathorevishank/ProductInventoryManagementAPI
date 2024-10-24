# Product API

This API allows you to manage products, including adding new products, retrieving product information, and updating products with category details.

## Table of Contents
1. [Prerequisites](#prerequisites)
2. [Getting Started](#getting-started)
3. [API Endpoints](#api-endpoints)
4. [Authentication](#authentication)
5. [Example Requests](#example-requests)
6. [Errors](#errors)
7. [License](#license)
8. [Contributing](#contributing)

---

## Prerequisites

Before you start, make sure you have the following installed:
- [.NET Core SDK](https://dotnet.microsoft.com/download)
- [Postman](https://www.postman.com/) or `curl` for testing the API
- SQL Server (if your API uses a database)

### Additional Requirements
- An API token (JWT) for authentication
- A tool for sending HTTP requests (Postman or cURL)

---

## Getting Started

### Step 1: Clone the Repository

git clone https://github.com/rathorevishank/ProductInventoryManagementAPI
Step 2: Configure the Environment
Open the appsettings.json file and update the database connection strings and JWT token configuration.
Ensure the correct URL is configured for the API (localhost or production URL).
json
Copy code
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=ProductDB;Trusted_Connection=True;"
  },
  "Jwt": {
    "Key": "your_secret_key",
    "Issuer": "yourdomain.com",
    "Audience": "yourdomain.com"
  }
}
Step 3: Build and Run the Application
To run the application, use the .NET CLI:

dotnet build
dotnet run
The API should now be running on https://localhost:7117.

API Endpoints
POST /api/v1.0/Product
Adds a new product to the system.

Request URL: https://localhost:7117/api/v1.0/Product

Request Body:

{
  "productID": 0,
  "sku": "SKU56789",
  "name": "laptop",
  "price": 25000,
  "productCategories": [
    "Electronics"
  ]
}
Response:

200 OK - The product was successfully added.
400 Bad Request - Invalid input data.
401 Unauthorized - Missing or invalid token.
Other Endpoints
More endpoints such as GET, PUT, and DELETE can be added here based on your implementation.

Authentication
This API uses JWT (JSON Web Token) for authentication. Every request must include a valid token in the Authorization header.

To authorize requests, follow these steps:

Obtain a JWT token by authenticating the user.
Include the token in the request headers using the Bearer scheme.
Example Authorization Header

-H "Authorization: Bearer your_jwt_token_here"
Example Requests
POST a New Product
Here is how to send a request to add a new product:

cURL:


curl -X 'POST' \
  'https://localhost:7117/api/v1.0/Product' \
  -H 'accept: text/plain' \
  -H 'Authorization: Bearer your_jwt_token_here' \
  -H 'Content-Type: application/json' \
  -d '{
    "productID": 0,
    "sku": "SKU56789",
    "name": "laptop",
    "price": 25000,
    "productCategories": [
      "Electronics"
    ]
  }'
Postman:

Set the method to POST.
Enter the URL: https://localhost:7117/api/v1.0/Product.
In the Headers section, add:
Authorization: Bearer your_jwt_token_here
Content-Type: application/json
In the Body section, select raw and JSON, then enter the following JSON:

{
  "productID": 0,
  "sku": "SKU56789",
  "name": "laptop",
  "price": 25000,
  "productCategories": [
    "Electronics"
  ]
}
Send the request and check the response.

