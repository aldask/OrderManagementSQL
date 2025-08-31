-- Products table
CREATE TABLE products (
    id SERIAL PRIMARY KEY,
    name VARCHAR(255),
    category VARCHAR(255),
    price DECIMAL(20, 2)
);
CREATE INDEX idx_products_name on products(name);
CREATE INDEX idx_products_category on products(category);
CREATE INDEX idx_products_price on products(price);
CREATE INDEX idx_products_category_price on products(category, price);