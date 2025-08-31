-- Order Items table
CREATE TABLE order_items (
    order_id INT REFERENCES orders(id) ON DELETE CASCADE,
    product_id INT REFERENCES products(id) ON DELETE CASCADE,
    quantity INT,
    PRIMARY KEY(order_id, product_id)
);
CREATE INDEX idx_order_id on order_items(order_id);
CREATE INDEX idx_product_id on order_items(product_id);