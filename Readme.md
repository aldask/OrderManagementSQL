# OrderManagement SQL Task

A PostgreSQL database solution for managing customers, products, and orders, with capabilities to generate invoices and reports.

## Functionalities Implemented (~8.25 hours)

- **Customers**
  - Table `customers` stores basic info and JSON details for location.

- **Products**
  - Table `products` stores product name, category, and price.

- **Orders**
  - Table `orders` links to `customers`.
  - Table `order_item`s stores `products`, `quantities`, and links to `orders`.
 
- **Invoices**
  - SQL query to retrieve invoice for a specific order.
 
- **Reports**
  - SQL query to retrieve order distribution by customer city.

## Missing / To Be Included

- Pagination support
- Performance tests
- Automated tests
- Various other enhancements, bug fixes & performance optimizations

## Prerequisites

- .NET 8 
- PostgreSQL database
- Visual Studio
- Docker

## Setup / Run

1. Clone the repository:

   ```bash
   git clone https://github.com/aldask/OrderManagementSQL.git
   ```

2. Configure PostgreSQL connection in appsettings.json:

   ```bash
   "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=OrderManagement;Username=postgres;Password=yourpassword"}
   ```

3. Run PostgreSQL with Docker:
   1. Remove current container + volumes:
      ```bash
      docker compose down -v
      ```
    2. Creates container:
       ```bash
       docker compose up -d
       ```
    3. Verify containers are running:
       ```bash
       docker ps
       ```

4. Build and run .NET endpoint:
   1. Build the project:
      ```bash
      cd API
      dotnet build
      ```
    2. Run the project:
       ```bash
       dotnet run
       ```

