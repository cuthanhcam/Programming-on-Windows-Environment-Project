CREATE DATABASE SalesManagement;
GO

USE SalesManagement;
GO

SELECT * FROM Customers;
SELECT * FROM Employees;
SELECT * FROM Products;
SELECT * FROM Orders;
SELECT * FROM OrderDetails;
SELECT * FROM StockTransactions;

DROP TABLE IF EXISTS Customers;
DROP TABLE IF EXISTS Employees;
DROP TABLE IF EXISTS Products;
DROP TABLE IF EXISTS Orders;
DROP TABLE IF EXISTS OrderDetails;
DROP TABLE IF EXISTS StockTransactions;

-- Tạo bảng Customers (Khách hàng)
CREATE TABLE Customers (
    CustomerID INT IDENTITY(1,1) PRIMARY KEY, -- Khóa chính tự tăng
    Name NVARCHAR(200) NOT NULL,              -- Tên khách hàng
    Email NVARCHAR(200) NULL,                 -- Email khách hàng
    Phone VARCHAR(15) NULL,                   -- Số điện thoại
    Address NVARCHAR(MAX) NULL,               -- Địa chỉ
    MembershipLevel NVARCHAR(50) NULL
        CONSTRAINT DF_Customers_MembershipLevel DEFAULT 'Silver',
    CONSTRAINT CK_Customers_MembershipLevel CHECK (MembershipLevel IN ('Silver', 'Gold', 'Platinum')),
    CONSTRAINT UQ_Customers_Phone UNIQUE (Phone), -- Phone là duy nhất
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(), -- Ngày tạo
    UpdatedAt DATETIME NOT NULL DEFAULT GETDATE()  -- Ngày cập nhật
);
GO

-- Tạo bảng Employees (Nhân viên)
CREATE TABLE Employees (
    EmployeeID INT IDENTITY(1,1) PRIMARY KEY, -- Khóa chính tự tăng
    Name NVARCHAR(200) NOT NULL,              -- Tên nhân viên
    Phone VARCHAR(15) NOT NULL,               -- Số điện thoại nhân viên
    Address NVARCHAR(MAX) NOT NULL,           -- Địa chỉ nhân viên
    Role NVARCHAR(20) NOT NULL CHECK (Role IN ('Admin', 'Staff')), -- Chức vụ (Admin, Staff)
    Salary DECIMAL(18, 2) NULL CHECK (Salary >= 0), -- Lương
    HireDate DATETIME NOT NULL DEFAULT GETDATE(), -- Ngày vào làm
    Username NVARCHAR(50) NULL UNIQUE,        -- Tên đăng nhập, duy nhất (có thể NULL)
    PasswordHash NVARCHAR(255) NULL,          -- Mật khẩu mã hóa (có thể NULL)
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(), -- Ngày tạo tài khoản
    UpdatedAt DATETIME NOT NULL DEFAULT GETDATE()  -- Ngày cập nhật
);
GO

-- Tạo bảng Products (Sản phẩm)
CREATE TABLE Products (
    ProductID INT IDENTITY(1,1) PRIMARY KEY, -- Khóa chính tự tăng
    Category NVARCHAR(100) NOT NULL,        -- Loại linh kiện
    Model NVARCHAR(200) NOT NULL,           -- Tên model
    Brand NVARCHAR(100) NOT NULL,           -- Thương hiệu
    Price DECIMAL(18, 2) NOT NULL CHECK (Price > 0), -- Giá bán
    StockQuantity INT NOT NULL CHECK (StockQuantity >= 0), -- Số lượng tồn kho
    Specifications NVARCHAR(MAX) NULL,      -- Thông số kỹ thuật (JSON)
    Promotion INT DEFAULT 0,
    Warranty INT DEFAULT 0,
    Image NVARCHAR(255) NULL,
    CONSTRAINT CK_Products_Category CHECK (Category <> ''), -- Kiểm tra loại sản phẩm không rỗng
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(), -- Ngày tạo
    UpdatedAt DATETIME NOT NULL DEFAULT GETDATE()  -- Ngày cập nhật
);
GO

-- Tạo bảng Orders (Đơn hàng)
CREATE TABLE Orders (
    OrderID INT IDENTITY(1,1) PRIMARY KEY,  -- Khóa chính tự tăng
    CustomerID INT NOT NULL,                -- Liên kết đến khách hàng
    EmployeeID INT NULL,                    -- Người thực hiện đơn hàng
    OrderDate DATETIME NOT NULL DEFAULT GETDATE(), -- Ngày đặt hàng, mặc định là ngày hiện tại
    TotalAmount DECIMAL(18, 2) NOT NULL CHECK (TotalAmount > 0), -- Tổng tiền
    Discount DECIMAL(18, 2) DEFAULT 0,      -- Giảm giá
    Status NVARCHAR(50) NOT NULL CHECK (Status IN ('Pending', 'Completed', 'Canceled')), -- Trạng thái đơn hàng
    Note NVARCHAR(MAX) NULL,                -- Ghi chú đơn hàng
    CONSTRAINT FK_Orders_Customers FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID) ON DELETE CASCADE,
    CONSTRAINT FK_Orders_Employees FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID) ON DELETE SET NULL,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(), -- Ngày tạo
    UpdatedAt DATETIME NOT NULL DEFAULT GETDATE()  -- Ngày cập nhật
);
GO

-- Tạo bảng OrderDetails (Chi tiết đơn hàng)
CREATE TABLE OrderDetails (
    OrderDetailID INT IDENTITY(1,1) PRIMARY KEY, -- Khóa chính tự tăng
    OrderID INT NOT NULL,                        -- Liên kết đến bảng Orders
    ProductID INT NOT NULL,                      -- Liên kết đến bảng Products
    Quantity INT NOT NULL CHECK (Quantity > 0),  -- Số lượng sản phẩm
    UnitPrice DECIMAL(18, 2) NOT NULL CHECK (UnitPrice > 0), -- Giá đơn vị sản phẩm
    Price DECIMAL(18, 2) NOT NULL CHECK (Price > 0), -- Giá sản phẩm tại thời điểm đặt hàng
    CONSTRAINT FK_OrderDetails_Orders FOREIGN KEY (OrderID) REFERENCES Orders(OrderID) ON DELETE CASCADE,
    CONSTRAINT FK_OrderDetails_Products FOREIGN KEY (ProductID) REFERENCES Products(ProductID),
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(), -- Ngày tạo
    UpdatedAt DATETIME NOT NULL DEFAULT GETDATE()  -- Ngày cập nhật
);
GO


-- Tạo bảng StockTransactions (Giao dịch kho)
CREATE TABLE StockTransactions (
    TransactionID INT IDENTITY(1,1) PRIMARY KEY, -- Khóa chính tự tăng
    ProductID INT NOT NULL,                      -- Liên kết đến bảng Products
    TransactionType NVARCHAR(50) NOT NULL CHECK (TransactionType IN (N'Import', N'Export')), -- Loại giao dịch
    Quantity INT NOT NULL CHECK (Quantity > 0),  -- Số lượng
    TransactionDate DATETIME NOT NULL DEFAULT GETDATE(), -- Ngày giao dịch
    EmployeeID INT NOT NULL,                     -- Người thực hiện
    Note NVARCHAR(MAX) NULL,                     -- Ghi chú giao dịch
    CONSTRAINT FK_StockTransactions_Products FOREIGN KEY (ProductID) REFERENCES Products(ProductID),
    CONSTRAINT FK_StockTransactions_Employees FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID),
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(), -- Ngày tạo
    UpdatedAt DATETIME NOT NULL DEFAULT GETDATE()  -- Ngày cập nhật
);
GO




