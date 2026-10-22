CREATE TABLE IF NOT EXISTS medical_supplies (
    id BIGINT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    category VARCHAR(100),
    vendor VARCHAR(100),
    unit_price DECIMAL(10, 2),
    quantity INT DEFAULT 0,
    description VARCHAR(255)
);

INSERT INTO medical_supplies
    (name, category, vendor, unit_price, quantity, description)
VALUES
    ('Notebook', 'Stationery', 'ABC Supplies', 4.99, 25, 'Lab notebook'),
    ('USB Cable', 'Electronics', 'Tech Vendor', 8.50, 10, 'USB-C cable');

DELETE FROM medical_supplies where id = 1;

INSERT INTO medical_supplies (name, category, vendor, unit_price, quantity, description) 
VALUES ('Examination Gloves', 'Personal Protective Equipment', 'Med supplier', 12.99, 50, 'Disposable examination gloves');
INSERT INTO medical_supplies (name, category, vendor, unit_price, quantity, description) 
VALUES ('Bandages', 'First Aid','Andrew Med Care supplier', 6.50, 25, 'Assorted Bandages');
INSERT INTO medical_supplies (name, category, vendor, unit_price, quantity, description) 
VALUES ('Disinfectant', 'Cleaning', 'Canada CleanCare', 5.99, 35, 'Surface disinfectant');

