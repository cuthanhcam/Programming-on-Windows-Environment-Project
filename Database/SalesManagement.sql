﻿-- Tạo cơ sở dữ liệu
CREATE DATABASE SalesManagement;
GO

-- Sử dụng cơ sở dữ liệu vừa tạo
USE SalesManagement;
GO

--SET DATEFORMAT DMY

DROP TABLE Products;
DROP TABLE Orders;
DROP TABLE OrderDetails;
DROP TABLE Customers;
DROP TABLE Employees;
DROP TABLE StockTransactions;


-- Tạo bảng Products (Sản phẩm)
CREATE TABLE Products (
    ProductID INT IDENTITY(1,1) PRIMARY KEY, -- Khóa chính tự tăng
    Category NVARCHAR(100) NOT NULL,        -- Loại linh kiện
    Model NVARCHAR(200) NOT NULL,           -- Tên model
    Brand NVARCHAR(100) NOT NULL,           -- Thương hiệu
    Price DECIMAL(18, 2) NOT NULL CHECK (Price > 0), -- Giá bán
    StockQuantity INT NOT NULL CHECK (StockQuantity >= 0), -- Số lượng tồn kho
    Specifications NVARCHAR(MAX) NULL,      -- Thông số kỹ thuật (JSON)
    CONSTRAINT CK_Products_Category CHECK (Category <> '') -- Kiểm tra loại sản phẩm không rỗng
);
GO

-- Tạo bảng Orders (Đơn hàng)
CREATE TABLE Orders (
    OrderID INT IDENTITY(1,1) PRIMARY KEY,  -- Khóa chính tự tăng
    CustomerID INT NOT NULL,                -- Liên kết đến khách hàng
    EmployeeID INT NULL,                    -- Người thực hiện đơn hàng
    OrderDate DATETIME NOT NULL DEFAULT GETDATE(), -- Ngày đặt hàng, mặc định là ngày hiện tại
    TotalAmount DECIMAL(18, 2) NOT NULL CHECK (TotalAmount > 0), -- Tổng tiền
    Status NVARCHAR(50) NOT NULL CHECK (Status IN ('Pending', 'Completed', 'Canceled')), -- Trạng thái đơn hàng
    CONSTRAINT FK_Orders_Customers FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID) ON DELETE CASCADE,
    CONSTRAINT FK_Orders_Employees FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID) ON DELETE SET NULL
);
GO

-- Tạo bảng OrderDetails (Chi tiết đơn hàng)
CREATE TABLE OrderDetails (
    OrderDetailID INT IDENTITY(1,1) PRIMARY KEY, -- Khóa chính tự tăng
    OrderID INT NOT NULL,                        -- Liên kết đến bảng Orders
    ProductID INT NOT NULL,                      -- Liên kết đến bảng Products
    Quantity INT NOT NULL CHECK (Quantity > 0),  -- Số lượng sản phẩm
    Price DECIMAL(18, 2) NOT NULL CHECK (Price > 0), -- Giá sản phẩm tại thời điểm đặt hàng
    CONSTRAINT FK_OrderDetails_Orders FOREIGN KEY (OrderID) REFERENCES Orders(OrderID) ON DELETE CASCADE,
    CONSTRAINT FK_OrderDetails_Products FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);
GO

-- Tạo bảng Customers (Khách hàng)
CREATE TABLE Customers (
    CustomerID INT IDENTITY(1,1) PRIMARY KEY, -- Khóa chính tự tăng
    Name NVARCHAR(200) NOT NULL,              -- Tên khách hàng
    Email NVARCHAR(200) NULL,                 -- Email khách hàng
    Phone VARCHAR(15) NULL,                   -- Số điện thoại
    MembershipLevel NVARCHAR(50) NULL 
        CONSTRAINT DF_Customers_MembershipLevel DEFAULT 'Silver',
    CONSTRAINT CK_Customers_MembershipLevel CHECK (MembershipLevel IN ('Silver', 'Gold', 'Platinum'))
);
GO

-- Tạo bảng Employees (Nhân viên)
CREATE TABLE Employees (
    EmployeeID INT IDENTITY(1,1) PRIMARY KEY, -- Khóa chính tự tăng
    Name NVARCHAR(200) NOT NULL,              -- Tên nhân viên
    Position NVARCHAR(100) NOT NULL,          -- Chức vụ (Admin, Sales)
    Salary DECIMAL(18, 2) NULL CHECK (Salary >= 0), -- Lương
    HireDate DATETIME NOT NULL DEFAULT GETDATE() -- Ngày vào làm
);
GO

-- Tạo bảng StockTransactions (Giao dịch kho)
CREATE TABLE StockTransactions (
    TransactionID INT IDENTITY(1,1) PRIMARY KEY, -- Khóa chính tự tăng
    ProductID INT NOT NULL,                      -- Liên kết đến bảng Products
    TransactionType NVARCHAR(50) NOT NULL CHECK (TransactionType IN ('Nhập kho', 'Xuất kho')), -- Loại giao dịch
    Quantity INT NOT NULL CHECK (Quantity > 0),  -- Số lượng
    TransactionDate DATETIME NOT NULL DEFAULT GETDATE(), -- Ngày giao dịch
    EmployeeID INT NOT NULL,                     -- Người thực hiện
    CONSTRAINT FK_StockTransactions_Products FOREIGN KEY (ProductID) REFERENCES Products(ProductID),
    CONSTRAINT FK_StockTransactions_Employees FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID)
);
GO


SELECT * FROM Products;
SELECT * FROM Orders;
SELECT * FROM OrderDetails;
SELECT * FROM Customers;
SELECT * FROM Employees;
SELECT * FROM StockTransactions;

