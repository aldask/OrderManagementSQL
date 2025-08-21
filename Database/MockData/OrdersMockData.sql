INSERT INTO orders (customer_id, order_date)
SELECT (
        floor(
            random() * (
                SELECT max(id)
                FROM customer
            )
        ) + 1
    )::int AS customer_id,
    NOW() - (random() * INTERVAL '365 days') AS order_date
FROM generate_series(1, 100000) gs;