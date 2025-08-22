-- ================================================
-- Schema
-- ================================================

-- Customers table
CREATE TABLE IF NOT EXISTS customers (
    id SERIAL PRIMARY KEY,
    first_name VARCHAR(255),
    last_name VARCHAR(255),
    email VARCHAR(255) UNIQUE,
    details JSONB
);

-- Products table
CREATE TABLE IF NOT EXISTS products (
    id SERIAL PRIMARY KEY,
    name VARCHAR(255),
    category VARCHAR(255),
    price DECIMAL(20, 2)
);

-- Orders table
CREATE TABLE IF NOT EXISTS orders (
    id SERIAL PRIMARY KEY,
    customer_id INT REFERENCES customers(id) ON DELETE CASCADE,
    order_date TIMESTAMP DEFAULT NOW()
);

-- Order Items table
CREATE TABLE IF NOT EXISTS order_items (
    order_id INT REFERENCES orders(id) ON DELETE CASCADE,
    product_id INT REFERENCES products(id) ON DELETE CASCADE,
    quantity INT,
    PRIMARY KEY(order_id, product_id)
);

-- ================================================
-- Mock data
-- ================================================

-- Customers mock data
INSERT INTO customers (first_name, last_name, email, details)
SELECT
    'FirstName' || gs AS first_name,
    'LastName' || gs AS last_name,
    'userMail' || gs || '@mail.com' AS email,
    jsonb_build_object(
        'country', countries[1 + floor(random() * array_length(countries,1))::int],
        'city', cities[1 + floor(random() * array_length(cities,1))::int]
    ) AS details
FROM generate_series(1, 10000) gs
CROSS JOIN LATERAL (
    SELECT ARRAY['Lithuania','USA','UK','France','Latvia'] AS countries,
           ARRAY['Kaunas','Vilnius','London','Washington','Paris','Riga'] AS cities
) t;

-- Products mock data
INSERT INTO products (name, category, price)
SELECT
    'Product' || gs AS name,
    'Category' || ((gs % 20) + 1) AS category,
    (random() * 10000)::NUMERIC(20,2) AS price
FROM generate_series(1, 8000) gs;

-- Orders mock data
INSERT INTO orders (customer_id, order_date)
SELECT
    (floor(random() * (SELECT max(id) FROM customers)) + 1)::int AS customer_id,
    NOW() - (random() * INTERVAL '365 days') AS order_date
FROM generate_series(1, 100000) gs;

-- Order items mock data
INSERT INTO order_items (order_id, product_id, quantity)
SELECT o.id AS order_id,
       p.id AS product_id,
       (floor(random() * 50) + 1)::int AS quantity
FROM orders o
JOIN LATERAL (
    SELECT id
    FROM products
    ORDER BY random()
    LIMIT (1 + floor(random() * 100)) -- 1 to 100 products per order
) p ON TRUE
GROUP BY o.id, p.id;
