INSERT INTO products (name, category, price)
SELECT 'Product' || gs AS name,
    'Category' || ((gs % 20) + 1) AS category,
    (random() * 10000)::NUMERIC(20, 2) AS price
FROM generate_series(1, 8000) gs;