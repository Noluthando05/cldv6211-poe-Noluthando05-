CREATE TABLE Products (
    ID INT PRIMARY KEY,
    Product_Name VARCHAR(100) NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,  
    Category VARCHAR(50) NOT NULL,
    Availability BIT NOT NULL,
    Ratings VARCHAR(20) NOT NULL
    );

    INSERT INTO Products (ID, Product_Name, Price, Category, Availability, Ratings)
VALUES
(1, 'Handcrafted Mug', 150.00, 'Home Decor', 1, 'Excellent'),
(2, 'Artisanal Soap', 84.90, 'Beauty', 1, 'Superb'),
(3, 'Handmade Jewelry Set', 299.99, 'Fashion', 0, 'Average'),
(4, 'Wood Carving Sculpture', 499.90, 'Art', 1, 'Outstanding'),
(5, 'Vintage Leather Bag', 799.99, 'Accessories', 1, 'Great'),
(6, 'Organic Skincare Set', 199.50, 'Beauty', 1, 'Fantastic');


