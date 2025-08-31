SELECT p.name AS product_name,
    p.category,
    oi.quantity,
    (oi.quantity * p.price) AS amount,
    SUM(oi.quantity * p.price) OVER () AS total_amount
FROM order_items oi
    JOIN products p ON oi.product_id = p.id
WHERE oi.order_id = 1;
-- Use actual order id to get its details