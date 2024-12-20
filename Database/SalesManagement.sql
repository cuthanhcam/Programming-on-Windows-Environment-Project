-- Tạo cơ sở dữ liệu
CREATE DATABASE SalesManagement;
GO

-- Sử dụng cơ sở dữ liệu vừa tạo
USE SalesManagement;
GO

--SET DATEFORMAT DMY

-- Tạo bảng Products (Sản phẩm)
CREATE TABLE Products (
    ProductID INT IDENTITY(1,1) PRIMARY KEY, -- Khóa chính tự tăng
    Category NVARCHAR(100) NOT NULL,        -- Loại linh kiện
    Model NVARCHAR(200) NOT NULL,           -- Tên model
    Brand NVARCHAR(100) NOT NULL,           -- Thương hiệu
    Price DECIMAL(18, 2) NOT NULL,          -- Giá bán
    StockQuantity INT NOT NULL,              -- Số lượng tồn kho
	Specifications NVARCHAR(MAX) NULL      -- Thông số kỹ thuật (dạng text hoặc JSON)
);
GO

-- Tạo bảng Orders (Đơn hàng)
CREATE TABLE Orders (
    OrderID INT IDENTITY(1,1) PRIMARY KEY,  -- Khóa chính tự tăng
    CustomerID INT NOT NULL,                -- Liên kết đến khách hàng
    EmployeeID INT NULL,                    -- Người thực hiện đơn hàng
    OrderDate DATETIME NOT NULL DEFAULT GETDATE(), -- Ngày đặt hàng, mặc định là ngày hiện tại
    TotalAmount DECIMAL(18, 2) NOT NULL,    -- Tổng tiền
    Status NVARCHAR(50) NOT NULL CHECK (Status IN ('Pending', 'Completed', 'Canceled')), -- Trạng thái đơn hàng
);
GO

-- Tạo bảng OrderDetails (Chi tiết đơn hàng)
CREATE TABLE OrderDetails (
    OrderDetailID INT IDENTITY(1,1) PRIMARY KEY, -- Khóa chính tự tăng
    OrderID INT NOT NULL,                        -- Liên kết đến bảng Orders
    ProductID INT NOT NULL,                      -- Liên kết đến bảng Products
    Quantity INT NOT NULL,                       -- Số lượng sản phẩm
    Price DECIMAL(18, 2) NOT NULL,               -- Giá sản phẩm tại thời điểm đặt hàng
);
GO

-- Tạo bảng Customers (Khách hàng)
CREATE TABLE Customers (
    CustomerID INT IDENTITY(1,1) PRIMARY KEY, -- Khóa chính tự tăng
    Name NVARCHAR(200) NOT NULL,              -- Tên khách hàng
    Email NVARCHAR(200) NULL,                 -- Email khách hàng
    Phone VARCHAR(15) NULL,                   -- Số điện thoại
    MembershipLevel NVARCHAR(50) NULL CHECK (MembershipLevel IN ('Silver', 'Gold', 'Platinum')) -- Cấp bậc khách hàng
);
GO

-- Tạo bảng Employees (Nhân viên)
CREATE TABLE Employees (
    EmployeeID INT IDENTITY(1,1) PRIMARY KEY, -- Khóa chính tự tăng
    Name NVARCHAR(200) NOT NULL,              -- Tên nhân viên
    Position NVARCHAR(100) NOT NULL,          -- Chức vụ (Admin, Sales)
    Salary DECIMAL(18, 2) NULL,               -- Lương
    HireDate DATETIME NOT NULL DEFAULT GETDATE() -- Ngày vào làm
);
GO

-- Tạo bảng StockTransactions (Giao dịch kho)
CREATE TABLE StockTransactions (
    TransactionID INT IDENTITY(1,1) PRIMARY KEY, -- Khóa chính tự tăng
    ProductID INT NOT NULL,                      -- Liên kết đến bảng Products
    TransactionType NVARCHAR(50) NOT NULL,       -- Loại giao dịch (Nhập kho, Xuất kho)
    Quantity INT NOT NULL,                       -- Số lượng
    TransactionDate DATETIME NOT NULL DEFAULT GETDATE(), -- Ngày giao dịch
    EmployeeID INT NOT NULL,                     -- Người thực hiện
);
GO

SELECT * FROM Products;
SELECT * FROM Orders;
SELECT * FROM OrderDetails;
SELECT * FROM Customers;
SELECT * FROM Employees;
SELECT * FROM StockTransactions;

