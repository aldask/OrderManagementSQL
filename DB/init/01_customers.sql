-- Customers table
CREATE TABLE customers (
    id SERIAL PRIMARY KEY,
    first_name VARCHAR(255),
    last_name VARCHAR(255),
    email VARCHAR(255) UNIQUE,
    details JSONB
);
CREATE INDEX idx_customers_first_name ON customers(first_name);
CREATE INDEX idx_customers_last_name ON customers(last_name);
CREATE INDEX idx_customers_city ON customers ((details->>'city'));
CREATE INDEX idx_customers_country ON customers ((details->>'country'));