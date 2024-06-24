CREATE TABLE MyProducts (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    Product_name VARCHAR(255) NOT NULL,
    Price DECIMAL(10,2) NOT NULL,
    Category VARCHAR(500) NOT NULL,
    Availability  VARCHAR(500) NOT NULL,
    Created_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
);

SET IDENTITY_INSERT MyProducts ON;


INSERT INTO MYProducts (Id, Product_name, Price, Category, Availability)
VALUES 
    (1, 'Handcrafted Wooden Bowl', 349.99, 'Home Decor',' yes'),
    (2, 'African Print Tote Bag', 259.99, 'Fashion Accessories', 'yes'),
    (3, 'Beaded Necklace Set', 699.99, 'Jewelry',' yes'),
    (4, 'Handwoven Basket', 499.99, 'Home Decor',' yes'),
    (5, 'Leather Journal', 189.99, 'Stationery',' no');

