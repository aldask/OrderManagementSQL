SELECT c.details->>'city' AS city,
    COUNT(o.id) AS number_of_orders,
    SUM(oi.quantity * p.price) AS total_amount
FROM customer c
    JOIN orders o ON o.customer_id = c.id
    JOIN order_items oi ON oi.order_id = o.id
    JOIN products p ON p.id = oi.product_id
WHERE c.details->>'city' = 'Kaunas' -- City filter (change city name here)
GROUP BY city
ORDER BY number_of_orders ASC;
-- Order by number of orders (change here)