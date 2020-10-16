use master;

CREATE DATABASE Apis_Ventas;

use Apis_Ventas;

/* Table Users */
CREATE TABLE Users(
idUser INT NOT NULL IDENTITY PRIMARY KEY,
Email NVARCHAR(100) UNIQUE,
Password NVARCHAR(50)
);

/* Table Customer */
CREATE TABLE Customers(
idCustomer INT NOT NULL IDENTITY PRIMARY KEY,
DocumentId NVARCHAR(20) UNIQUE,
FirstName NVARCHAR(50),
LastName NVARCHAR(50),
Address NVARCHAR(50),
City NVARCHAR(50),
Cellphone NVARCHAR(50),
idUserNew INT,
idUserUpdate INT,
DateTimeNew DATETIME,
DateTimeUpdate DATETIME
);

/* Table Sales */
CREATE TABLE Sales(
idSale INT NOT NULL IDENTITY PRIMARY KEY,
Period NVARCHAR(6),
Quantity FLOAT,
Value MONEY,
idCustomer INT
);

/* Foreing Keys Customers */
ALTER TABLE Customers ADD FOREIGN KEY (idUserNew) REFERENCES Users(idUser);
ALTER TABLE Customers ADD FOREIGN KEY (idUserUpdate) REFERENCES Users(idUser);

/* Foreing Key Sales */
ALTER TABLE Sales ADD FOREIGN KEY (idCustomer) REFERENCES Customers(idCustomer);

/*Data*/
INSERT INTO Users VALUES ('fernando.arpre@gmail.com','arce123');

