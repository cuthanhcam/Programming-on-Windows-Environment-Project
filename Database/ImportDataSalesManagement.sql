USE SalesManagement;
GO

-- Kiểm tra mã băm SHA256 (nghi ngờ không đồng nhất với dotnet) - Đã fix
SELECT CONVERT(VARCHAR(MAX), HASHBYTES('SHA2_256', 'admin123'), 2) AS HashedPassword;

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

DELETE FROM Customers;
DELETE FROM Employees;
DELETE FROM Products;
DELETE FROM Orders;
DELETE FROM OrderDetails;
DELETE FROM StockTransactions;

INSERT INTO Customers (Name, Email, Phone, Address, MembershipLevel)
VALUES 
    (N'Nguyễn Văn A', 'nguyenvana@gmail.com', '0912345678', N'Hà Nội', 'Silver'),
    (N'Trần Thị B', 'tranthib@gmail.com', '0912345679', N'Hồ Chí Minh', 'Gold'),
    (N'Lê Văn C', 'levanc@gmail.com', '0912345680', N'Đà Nẵng', 'Platinum'),
    (N'Phạm Thị D', 'phamthid@gmail.com', '0912345681', N'Hải Phòng', 'Silver'),
    (N'Hoàng Văn E', 'hoangvane@gmail.com', '0912345682', N'Cần Thơ', 'Gold');
GO

INSERT INTO Employees (Name, Phone, Address, Role, Salary, Username, PasswordHash)
VALUES 
	(N'Cù Thanh Cầm', '0353818874' , N'Quảng Ngãi', 'Admin', 1500, 'camct', CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', 'admin123'), 2)),
	(N'Trần Trung Hậu', '0902621876' , N'Cần Giờ', 'Staff', 1000, 'hautt', CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', 'staff123'), 2));
GO

INSERT INTO Products (Category, Model, Brand, Price, Specifications, StockQuantity)
VALUES 
	('Processor', 'Ryzen Threadripper 3990X', 'AMD', 8078, 
	'{"Cores": "64", "Threads": "128", "Socket Type": "sTRX4", "Memory Speed": "DDR4", "Memory Type": "3200 MHz", "Base Speed": "2.9 GHz", "Turbo Speed": "4.3 GHz", "Max Power Consumption": "280 W"}', 20),
	('Processor', 'Ryzen 9 7950X', 'AMD', 699, 
	'{"Cores": "16", "Threads": "32", "Socket Type": "AM5", "Memory Type": "DDR5", "Memory Speed": "5200 MHz", "Base Speed": "4.5 GHz", "Turbo Speed": "5.7 GHz", "Max Power Consumption": "170 W"}', 20),
	('Processor', 'i9-13900KF', 'Intel', 574, 
	'{"Cores": "24", "Threads": "32", "Socket Type": "LGA 1700", "Memory Type": "DDR5", "Memory Speed": "5600 MHz", "Base Speed": "3.0 GHz", "Turbo Speed": "5.8 GHz", "Max Power Consumption": "125 W"}', 20),
	('Motherboard', 'TRX40 CREATOR', 'ASRock', 1549, 
	'{"Chipset": "AMD X570", "Form Factor": "ATX", "Socket Type": "sTRX4", "Memory Slots": "8", "Memory Type": "DDR4", "Memory Speed": "2666 MHz", "Storage Expansion": "SATA III, PCIe 4.0 x4", "Multi-GPU Support": "Yes"}', 20),
	('Motherboard', 'TRX40 Aorus Pro WiFi', 'Gigabyte', 820, 
	'{"Chipset": "AMD TRX40", "Form Factor": "ATX", "Socket Type": "sTRX4", "Memory Slots": "8", "Memory Type": "DDR4", "Memory Speed": "4400 MHz", "Storage Expansion": "SATA III, PCIe 4.0 x4", "Multi-GPU Support": "Yes"}', 20),
	('Motherboard', 'ROG ZENITH II EXTREME ALPHA', 'ASUS', 962.99, 
	'{"Chipset": "AMD TRX40", "Form Factor": "Extended ATX", "Socket Type": "sTRX4", "Memory Slots": "8", "Memory Type": "DDR4", "Memory Speed": "2400 MHz", "Storage Expansion": "SATA III, PCIe 4.0 x4", "Multi-GPU Support": "yes"}', 20),
	('CPU Cooler', 'Hyper 212 EVO', 'Cooler Master', 42.99, 
	'{"Fan RPM": "600 to 2000 rpm", "Noise Level": "9 to 36 dBA", "Color": "RGB"}', 20),
	('CPU Cooler', 'Hyper 212 RGB', 'Cooler Master', 95.99, 
	'{"Fan RPM": "650 to 2000 rpm", "Noise Level": "8 to 30 dBA", "Color": "RGB"}', 20),
	('CPU Cooler', 'Hyper H412R', 'Cooler Master', 32.99, 
	'{"Fan RPM": "600 to 2000 RPM", "Noise Level": "29.4 dBA", "Color": "Black"}', 20),
	('Case', 'H510B-W1', 'NZXT', 89.99, 
	'{"Side Panel": "Tempered Glass, Steel", "Carbinet Type": "ATX Mid Tower", "Color": "White", "Motherboard Support": "ATX, Micro-ATK, Mini-ITX", "Max GPU Length": "381 mm", "CPU Cooler Height": "165 mm", "Supported PSU Size": "ATX"}', 20),
	('Case', 'H510B-B1', 'NZXT', 83.13, 
	'{"Side Panel": "Tempered Glass, Steel", "Carbinet Type": "ATX Full Tower", "Color": "Black", "Motherboard Support": "ATX, Micro-ATX, Mini-ITX", "Max GPU Length": "381 mm", "CPU Cooler Height": "165 mm", "Supported PSU Size": "ATX"}', 20),
	('Case', 'H510 Elite', 'NZXT', 99.99, 
	'{"Side Panel": "Tempered Glass, Steel", "Carbinet Type": "ATX Mid Tower", "Color": "White", "Motherboard Support": "ATX, Micro-ATX, Mini-ITX", "Max GPU Length": "368.6 mm", "CPU Cooler Height": "165 mm", "Supported PSU Size": "ATX"}', 20),
	('Graphic Card', 'GeForce RTX 3080 Ti Gaming OC 12G', 'Gigabyte', 1529.86, 
	'{"Memory": "12 GB", "Memory Interface": "GDDR6X", "Length": "320 mm", "Interface": "PCIe x16", "Chipset": "GeForce RTX 3080 Ti", "Max Power Consumption": "350 W"}', 20),
	('Graphic Card', 'TUF Gaming GeForce RTX 3080 Ti OC Edition', 'ASUS', 1159, 
	'{"Memory": "12 GB", "Memory Interface": "GDDR6X", "Length": "300 mm", "Interface": "PCIe x16", "Chipset": "GeForce RTX 3080 Ti", "Max Power Consumption": "350 W"}', 20),
	('Graphic Card', 'RTX 4090 Gaming Trio 24G', 'MSI', 2999.99, 
	'{"Memory": "24GB", "Memory Interface": "GDDR6X", "Length": "337 mm", "Interface": "PCIe 4.0 x16", "Chipset": "GeForce RTX 4090", "Max Power Consumption": "450 W"}', 20),
	('RAM', 'Trident Z5 RGB', 'G.Skill', 269.99, 
	'{"RAM Size": "32 GB", "Quantity": "2x16 GB", "RAM Type": "DDR5", "RAM Speed": "6400 MHz"}', 20),
	('RAM', 'Fury Renegade RGB', 'Kingston', 307.20, 
	'{"RAM Size": "32 GB", "Quantity": "2x16 GB", "RAM Type": "DDR5", "RAM Speed": "6400 MHz"}', 20),
	('RAM', 'XLR8', 'PNY', 219.99, 
	'{"RAM Size": "32 GB", "Quantity": "2x16 GB", "RAM Type": "DDR5", "RAM Speed": "6200 MHz"}', 20),
	('Storage', '970 EVO', 'Samsung', 219.99, 
	'{"Capacity": "1 TB", "Type": "SSD", "RPM": "N/A", "Interface": "PCIe 3.0 x4", "Cache Memory": "1024 MB", "Form Factor": "M.2-2280"}', 20),
	('Storage', 'BarraCuda', 'Seagate', 55.49, 
	'{"Capacity": "2 TB", "Type": "HHD", "RPM": "7200 RPM", "Interface": "SATA III", "Cache Memory": "256 MB", "Form Factor": "3.5\""}', 20),
	('Storage', 'Caviar Blue', 'Western Digital', 34.99, 
	'{"Capacity": "1 TB", "Type": "HDD", "RPM": "7200RPM", "Interface": "SATA III", "Cache Memory": "64 MB", "Form Factor": "3.5\""}', 20),
	('Case Cooler', 'MasterFan MF120R', 'Cooler Master', 79, 
	'{"Fan RPM": "650 to 2000 RPM", "Airflow": "59 CFM", "Noise Level": "31 dBA"}', 20),
	('Case Cooler', 'AER RGB', 'NZXT', 24.55, 
	'{"Fan RPM": "500 to 1500 RPM", "Airflow": "17.48 to 52.44 CFM", "Noise Level": "22 to 33 dBA"}', 20),
	('Case Cooler', 'P12 PST', 'ARCTIC', 9.99, 
	'{"Fan RPM": "1800 RPM", "Airflow": "56.3 CFM", "Noise Level": "56.3dBA"}', 20),
	('Power Supply', 'RM750', 'Corsair', 169, 
	'{"Power": "750 W", "Efficiency": "80+ Gold", "Color": "Black"}', 20),
	('Power Supply', 'RM850', 'Corsair', 195, 
	'{"Power": "850 W", "Efficiency": "80+ Gold", "Color": "Black"}', 20),
	('Power Supply', 'Toughpower PF1', 'Thermaltake', 149.99, 
	'{"Power": "850 W", "Efficiency": "80+ Platinum", "Color": "Black"}', 20);
GO


INSERT INTO Orders (CustomerID, EmployeeID, TotalAmount, Status, Note)
VALUES 
	(1, 2, 17705, 'Completed', N'Khách hàng hài lòng với dịch vụ'),
    (2, 1, 2927.86, 'Pending', N'Yêu cầu giao hàng sớm'),
    (3, 2, 219.99, 'Completed', N'Khách hàng yêu cầu bảo hành thêm'),
    (4, 2, 962.99, 'Canceled', N'Khách hàng hủy đơn do lý do cá nhân');
GO

INSERT INTO OrderDetails (OrderID, ProductID, Quantity, UnitPrice, Price)
VALUES 
    (1, 1, 2, 8078, 16156), -- Ryzen Threadripper 3990X
    (1, 4, 1, 1549, 1549),  -- TRX40 CREATOR
    (2, 2, 2, 699, 1398),   -- Ryzen 9 7950X
    (2, 14, 1, 1529.86, 1529.86), -- GeForce RTX 3080 Ti Gaming OC 12G
    (3, 19, 1, 219.99, 219.99),   -- 970 EVO
    (4, 6, 1, 962.99, 962.99);    -- ROG ZENITH II EXTREME ALPHA
GO

INSERT INTO StockTransactions (ProductID, TransactionType, Quantity, EmployeeID, Note)
VALUES 
    (1, 'Import', 10, 2, N'Nhập kho lần 1'),
    (2, 'Import', 5, 2, N'Nhập kho lần 1'),
    (3, 'Import', 3, 2, N'Nhập kho lần 1'),
    (4, 'Import', 20, 2, N'Nhập kho lần 1'),
    (5, 'Import', 15, 2, N'Nhập kho lần 1');
GO


-- Products: Processor
INSERT INTO Products (Category, Model, Brand, Price, Specifications, StockQuantity)
VALUES 
	('Processor', 'Ryzen Threadripper 3990X', 'AMD', 8078, 
	'{"Cores": "64", "Threads": "128", "Socket Type": "sTRX4", "Memory Speed": "DDR4", "Memory Type": "3200 MHz", "Base Speed": "2.9 GHz", "Turbo Speed": "4.3 GHz", "Max Power Consumption": "280 W"}', 20),
	('Processor', 'Ryzen 9 7950X', 'AMD', 699, 
	'{"Cores": "16", "Threads": "32", "Socket Type": "AM5", "Memory Type": "DDR5", "Memory Speed": "5200 MHz", "Base Speed": "4.5 GHz", "Turbo Speed": "5.7 GHz", "Max Power Consumption": "170 W"}', 20),
	('Processor', 'i9-13900KF', 'Intel', 574, 
	'{"Cores": "24", "Threads": "32", "Socket Type": "LGA 1700", "Memory Type": "DDR5", "Memory Speed": "5600 MHz", "Base Speed": "3.0 GHz", "Turbo Speed": "5.8 GHz", "Max Power Consumption": "125 W"}', 20),
	('Processor', 'Ryzen Threadripper 3970X', 'AMD', 2193.4, 
	'{"Cores": "32", "Threads": "64", "Socket Type": "sTRX4", "Memory Type": "DDR4", "Memory Speed": "3200 MHz", "Base Speed": "3.7 GHz", "Turbo Speed": "4.5 GHz", "Max Power Consumption": "280 W"}', 20),
	('Processor', 'i9-13900K', 'Intel', 641.92, 
	'{"Cores": "24", "Threads": "32", "Socket Type": "LGA 1700", "Memory Type": "DDR5", "Memory Speed": "5600 MHz", "Base Speed": "3.0 GHz", "Turbo Speed": "5.8 GHz", "Max Power Consumption": "125 W"}', 20),
	('Processor', 'Ryzen 9 7900X', 'AMD', 439.99, 
	'{"Cores": "12", "Threads": "24", "Socket Type": "AM5", "Memory Type": "DDR5", "Memory Speed": "5200 MHz", "Base Speed": "4.7 GHz", "Turbo Speed": "5.6 GHz", "Max Power Consumption": "170 W"}', 20),
	('Processor', 'Ryzen 9 5950X', 'AMD', 559.2, 
	'{"Cores": "16", "Threads": "32", "Socket Type": "AM4", "Memory Type": "DDR4", "Memory Speed": "3200 MHz", "Base Speed": "3.4 GHz", "Turbo Speed": "4.9 GHz", "Max Power Consumption": "105 W"}', 20),
	('Processor', 'i5-13600K', 'Intel', 319.97, 
	'{"Cores": "14", "Threads": "20", "Socket Type": "LGA 1700", "Memory Type": "DDR5", "Memory Speed": "5600 MHz", "Base Speed": "3.5 GHz", "Turbo Speed": "5.1 GHz", "Max Power Consumption": "125 W"}', 20),
	('Processor', 'Ryzen 9 3950X', 'AMD', 610, 
	'{"Cores": "16", "Threads": "32", "Socket Type": "AM4", "Memory Type": "DDR4", "Memory Speed": "3200 MHz", "Base Speed": "3.5 GHz", "Turbo Speed": "4.7 GHz", "Max Power Consumption": "105 W"}', 20),
	('Processor', 'i7-13700KF', 'Intel', 397.99, 
	'{"Cores": "16", "Threads": "24", "Socket Type": "LGA 1700", "Memory Type": "DDR5", "Memory Speed": "5600 MHz", "Base Speed": "3.4 GHz", "Turbo Speed": "5.4 GHz", "Max Power Consumption": "125 W"}', 20),
	('Processor', 'i9-12900K', 'Intel', 479, 
	'{"Cores": "16", "Threads": "24", "Socket Type": "LGA 1700", "Memory Type": "DDR5", "Memory Speed": "4800 MHz", "Base Speed": "3.2 GHz", "Turbo Speed": "5.2 GHz", "Max Power Consumption": "125 W"}', 20),
	('Processor', 'Ryzen 7 7700X', 'AMD', 348.99, 
	'{"Cores": "8", "Threads": "16", "Socket Type": "AM5", "Memory Type": "DDR5", "Memory Speed": "5200 MHz", "Base Speed": "4.5 GHz", "Turbo Speed": "5.4 GHz", "Max Power Consumption": "107 W"}', 20);
GO
-- Products: Motherboard
INSERT INTO Products (Category, Model, Brand, Price, Specifications, StockQuantity)
VALUES 
	('Motherboard', 'TRX40 CREATOR', 'ASRock', 1549, 
	'{"Chipset": "AMD X570", "Form Factor": "ATX", "Socket Type": "sTRX4", "Memory Slots": "8", "Memory Type": "DDR4", "Memory Speed": "2666 MHz", "Storage Expansion": "SATA III, PCIe 4.0 x4", "Multi-GPU Support": "Yes"}', 20),
	('Motherboard', 'TRX40 Aorus Pro WiFi', 'Gigabyte', 820, 
	'{"Chipset": "AMD TRX40", "Form Factor": "ATX", "Socket Type": "sTRX4", "Memory Slots": "8", "Memory Type": "DDR4", "Memory Speed": "4400 MHz", "Storage Expansion": "SATA III, PCIe 4.0 x4", "Multi-GPU Support": "Yes"}', 20),
	('Motherboard', 'ROG ZENITH II EXTREME ALPHA', 'ASUS', 962.99, 
	'{"Chipset": "AMD TRX40", "Form Factor": "Extended ATX", "Socket Type": "sTRX4", "Memory Slots": "8", "Memory Type": "DDR4", "Memory Speed": "2400 MHz", "Storage Expansion": "SATA III, PCIe 4.0 x4", "Multi-GPU Support": "yes"}', 20),
	('Motherboard', 'TRX40 AORUS XTREME', 'Gigabyte', 1599.99, 
	'{"Chipset": "AMD TRX40", "Form Factor": "Extended ATX", "Socket Type": "sTRX4", "Memory Slots": "8", "Memory Type": "DDR4", "Memory Speed": "4400 MHz", "Storage Expansion": "SATA, SATA III, PCIe 4.0 x4, PCIe 4.0 x2", "Multi-GPU Support": "yes"}', 20),
	('Motherboard', 'TRX40 DESIGNARE', 'Gigabyte', 1449.99, 
	'{"Chipset": "AMD TRX40", "Form Factor": "Extended ATX", "Socket Type": "sTRX4", "Memory Slots": "8", "Memory Type": "DDR4", "Memory Speed": "4400 MHz", "Storage Expansion": "SATA, SATA III, PCIe 4.0 x4, PCIe 4.0 x2", "Multi-GPU Support": "yes"}', 20),
	('Motherboard', 'TRX40P', 'MSI', 669.6, 
	'{"Chipset": "AMD TRX40", "Form Factor": "ATX", "Socket Type": "sTRX4", "Memory Slots": "8", "Memory Type": "DDR4", "Memory Speed": "2666 MHz", "Storage Expansion": "SATA, SATA III, PCIe 4.0 x4, PCIe 4.0 x2", "Multi-GPU Support": "yes"}', 20),
	('Motherboard', 'TUF GAMING X570-PLUS (WI-FI)', 'ASUS', 179.99, 
	'{"Chipset": "AMD X570", "Form Factor": "ATX", "Socket Type": "AM4", "Memory Slots": "4", "Memory Type": "DDR4", "Memory Speed": "4400 MHz", "Storage Expansion": "SATA III, PCIe 4.0 x4", "Multi-GPU Support": "no"}', 20),
	('Motherboard', 'X570S AORUS ELITE AX', 'Gigabyte', 189.99, 
	'{"Chipset": "AMD X570", "Form Factor": "ATX", "Socket Type": "AM4", "Memory Slots": "4", "Memory Type": "DDR4", "Memory Speed": "5400 MHz", "Storage Expansion": "SATA 6 Gb/s, 2260/2280/22110 M-key", "Multi-GPU Support": "no"}', 20),
	('Motherboard', 'X570 AORUS ELITE', 'Gigabyte', 264.45, 
	'{"Chipset": "AMD X570", "Form Factor": "ATX", "Socket Type": "AM4", "Memory Slots": "4", "Memory Type": "DDR4", "Memory Speed": "2133 MHz", "Storage Expansion": "SATA III, PCIe 4.0 x4", "Multi-GPU Support": "yes"}', 20),
	('Motherboard', 'X570 I AORUS PRO WIFI', 'Gigabyte', 268.9, 
	'{"Chipset": "AMD X570", "Form Factor": "Mini ITX", "Socket Type": "AM4", "Memory Slots": "2", "Memory Type": "DDR4", "Memory Speed": "2666 MHz", "Storage Expansion": "SATA III, PCIe 4.0 x4", "Multi-GPU Support": "no"}', 20),
	('Motherboard', 'X570 PRO WIFI', 'MSI', 338.99, 
	'{"Chipset": "AMD X570", "Form Factor": "ATX", "Socket Type": "AM4", "Memory Slots": "4", "Memory Type": "DDR4", "Memory Speed": "2666 MHz", "Storage Expansion": "SATA III, PCIe 4.0 x4, PCIe 3.0 x4", "Multi-GPU Support": "yes"}', 20),
	('Motherboard', 'ROG CROSSHAIR VIII HERO (WI-FI)', 'ASUS', 380.75, 
	'{"Chipset": "AMD X570", "Form Factor": "ATX", "Socket Type": "AM4", "Memory Slots": "4", "Memory Type": "DDR4", "Memory Speed": "2133 MHz", "Storage Expansion": "SATA III, PCIe 4.0 x4", "Multi-GPU Support": "yes"}', 20);
GO
-- Products: CPU Cooler
INSERT INTO Products (Category, Model, Brand, Price, Specifications, StockQuantity)
VALUES 
	('CPU Cooler', 'Hyper 212 EVO', 'Cooler Master', 42.99, 
	'{"Fan RPM": "600 to 2000 rpm", "Noise Level": "9 to 36 dBA", "Color": "RGB"}', 20),
	('CPU Cooler', 'Hyper 212 RGB', 'Cooler Master', 95.99, 
	'{"Fan RPM": "650 to 2000 rpm", "Noise Level": "8 to 30 dBA", "Color": "RGB"}', 20),
	('CPU Cooler', 'Hyper H412R', 'Cooler Master', 32.99, 
	'{"Fan RPM": "600 to 2000 RPM", "Noise Level": "29.4 dBA", "Color": "Black"}', 20),
	('CPU Cooler', 'Hyper 212 Black Edition', 'Cooler Master', 34.99, 
	'{"Fan RPM": "800 to 2000 RPM", "Noise Level": "6.5 to 26 dBA", "Color": "Black"}', 20),
	('CPU Cooler', 'Hyper T2', 'Cooler Master', 39.99, 
	'{"Fan RPM": "2800 RPM", "Noise Level": "17 to 35 dBA", "Color": "Black"}', 20),
	('CPU Cooler', 'Kraken X53', 'NZXT', 123.99, 
	'{"Fan RPM": "500 to 2000 RPM", "Noise Level": "21 to 36 dBA", "Color": "RGB"}', 20),
	('CPU Cooler', 'Kraken Z73', 'NZXT', 249.99, 
	'{"Fan RPM": "500 to 1800 RPM", "Noise Level": "21 to 36 dBA", "Color": "Black"}', 20),
	('CPU Cooler', 'Kraken M22', 'NZXT', 105.67, 
	'{"Fan RPM": "200 to 2300 RPM", "Noise Level": "21 to 36 dBA", "Color": "Black"}', 20),
	('CPU Cooler', 'Kraken X53 RGB', 'NZXT', 129, 
	'{"Fan RPM": "500 to 1500 RPM", "Noise Level": "22 to 33 dBA", "Color": "RGB"}', 20),
	('CPU Cooler', 'Kraken X53 RGB 240mm', 'NZXT', 149.99, 
	'{"Fan RPM": "500 to 1500 RPM", "Noise Level": "22 to 33 dBA", "Color": "RGB"}', 20),
	('CPU Cooler', 'Kraken X63 RGB', 'NZXT', 159.99, 
	'{"Fan RPM": "500 to 1500 RPM", "Noise Level": "22 to 33 dBA", "Color": "RGB"}', 20),
	('CPU Cooler', 'Kraken Z73 RGB', 'NZXT', 290.99, 
	'{"Fan RPM": "500 to 1500 RPM", "Noise Level": "22 to 33 dBA", "Color": "RGB"}', 20);
GO
-- Products: Case
INSERT INTO Products (Category, Model, Brand, Price, Specifications, StockQuantity)
VALUES 
	('Case', 'H510B-W1', 'NZXT', 89.99, 
	'{"Side Panel": "Tempered Glass, Steel", "Carbinet Type": "ATX Mid Tower", "Color": "White", "Motherboard Support": "ATX, Micro-ATK, Mini-ITX", "Max GPU Length": "381 mm", "CPU Cooler Height": "165 mm", "Supported PSU Size": "ATX"}', 20),
	('Case', 'H510B-B1', 'NZXT', 83.13, 
	'{"Side Panel": "Tempered Glass, Steel", "Carbinet Type": "ATX Full Tower", "Color": "Black", "Motherboard Support": "ATX, Micro-ATX, Mini-ITX", "Max GPU Length": "381 mm", "CPU Cooler Height": "165 mm", "Supported PSU Size": "ATX"}', 20),
	('Case', 'H510 Elite', 'NZXT', 99.99, 
	'{"Side Panel": "Tempered Glass, Steel", "Carbinet Type": "ATX Mid Tower", "Color": "White", "Motherboard Support": "ATX, Micro-ATX, Mini-ITX", "Max GPU Length": "368.6 mm", "CPU Cooler Height": "165 mm", "Supported PSU Size": "ATX"}', 20),
	('Case', 'H510B', 'NZXT', 59.99, 
	'{"Side Panel": "Tempered Glass, Steel", "Carbinet Type": "ATX Mid Tower", "Color": "Black/Red", "Motherboard Support": "ATX, Micro-ATX, Mini-ITX", "Max GPU Length": "381 mm", "CPU Cooler Height": "165 mm", "Supported PSU Size": "ATX"}', 20),
	('Case', 'H510i', 'NZXT', 120.58, 
	'{"Side Panel": "Tempered Glass, Steel", "Carbinet Type": "ATX Mid Tower", "Color": "White", "Motherboard Support": "ATX, Micro-ATX, Mini-ITX", "Max GPU Length": "381 mm", "CPU Cooler Height": "165 mm", "Supported PSU Size": "ATX"}', 20),
	('Case', 'MasterBox Q500L', 'Cooler Master', 56.11, 
	'{"Side Panel": "Steel, Plastic", "Carbinet Type": "ATX Mid Tower", "Color": "Black", "Motherboard Support": "ATX, Micro-ATX, Mini-ITX", "Max GPU Length": "360 mm", "CPU Cooler Height": "160 mm", "Supported PSU Size": "ATX"}', 20),
	('Case', 'Q300L', 'Cooler Master', 66.49, 
	'{"Side Panel": "Steel, Plastic", "Carbinet Type": "MicroATX Mid Tower", "Color": "Black", "Motherboard Support": "Micro-ATX, Mini-ITX", "Max GPU Length": "360 mm", "CPU Cooler Height": "157 mm", "Supported PSU Size": "ATX"}', 20),
	('Case', 'CARBIDE SPEC-05', 'Cosair', 116.12, 
	'{"Side Panel": "Acrylic", "Carbinet Type": "ATX Mid Tower", "Color": "Black", "Motherboard Support": "ATX, Micro-ATX, Mini-ITX", "Max GPU Length": "370 mm", "CPU Cooler Height": "N/A", "Supported PSU Size": "ATX"}', 20),
	('Case', 'Carbide SPEC-Omega', 'Cosair', 207.34, 
	'{"Side Panel": "Tempered Glass", "Carbinet Type": "ATX Mid Tower", "Color": "Black", "Motherboard Support": "ATX, Micro-ATX, Mini-ITX", "Max GPU Length": "370 mm", "CPU Cooler Height": "N/A", "Supported PSU Size": "ATX"}', 20),
	('Case', '4000D Airflow', 'Cosair', 89.99, 
	'{"Side Panel": "Tinted Tempered Glass", "Carbinet Type": "ATX Mid Tower", "Color": "White", "Motherboard Support": "ATX, Micro-ATX, Mini-ITX", "Max GPU Length": "360 mm", "CPU Cooler Height": "N/A", "Supported PSU Size": "ATX"}', 20),
	('Case', 'MasterBox TD500', 'Cooler Master', 109.31, 
	'{"Side Panel": "Tempered Glass, Steel", "Carbinet Type": "ATX Mid Tower", "Color": "White ARGB", "Motherboard Support": "ATX, E-ATX, Micro-ATX, Mini-ITX, SSI-CEB", "Max GPU Length": "410 mm", "CPU Cooler Height": "165 mm", "Supported PSU Size": "ATX"}', 20),
	('Case', 'CC-9011205-WW', 'Cosair', 119.99, 
	'{"Side Panel": "Tempered Glass", "Carbinet Type": "ATX Mid Tower", "Color": "White", "Motherboard Support": "ATX, Micro-ATX, Mini-ITX", "Max GPU Length": "360 mm", "CPU Cooler Height": "N/A", "Supported PSU Size": "ATX"}', 20);
GO
-- Products: Graphic Card
INSERT INTO Products (Category, Model, Brand, Price, Specifications, StockQuantity)
VALUES 
	('Graphic Card', 'GeForce RTX 3080 Ti Gaming OC 12G', 'Gigabyte', 1529.86, 
	'{"Memory": "12 GB", "Memory Interface": "GDDR6X", "Length": "320 mm", "Interface": "PCIe x16", "Chipset": "GeForce RTX 3080 Ti", "Max Power Consumption": "350 W"}', 20),
	('Graphic Card', 'TUF Gaming GeForce RTX 3080 Ti OC Edition', 'ASUS', 1159, 
	'{"Memory": "12 GB", "Memory Interface": "GDDR6X", "Length": "300 mm", "Interface": "PCIe x16", "Chipset": "GeForce RTX 3080 Ti", "Max Power Consumption": "350 W"}', 20),
	('Graphic Card', 'RTX 4090 Gaming Trio 24G', 'MSI', 2999.99, 
	'{"Memory": "24GB", "Memory Interface": "GDDR6X", "Length": "337 mm", "Interface": "PCIe 4.0 x16", "Chipset": "GeForce RTX 4090", "Max Power Consumption": "450 W"}', 20),
	('Graphic Card', 'GV-N4090WF3-24GD', 'Gigabyte', 2599.99, 
	'{"Memory": "24GB", "Memory Interface": "GDDR6X", "Length": "331 mm", "Interface": "PCIe 4.0 x16", "Chipset": "GeForce RTX 4090", "Max Power Consumption": "450 W"}', 20),
	('Graphic Card', 'GeForce RTX 4090 Founders Edition', 'NVIDIA', 2929.99, 
	'{"Memory": "24GB", "Memory Interface": "GDDR6X", "Length": "304 mm", "Interface": "PCIe 4.0 x16", "Chipset": "GeForce RTX 4090", "Max Power Consumption": "450 W"}', 20),
	('Graphic Card', 'GeForce RTX 4090 SUPRIM LIQUID X 24G', 'MSI', 2632, 
	'{"Memory": "24GB", "Memory Interface": "GDDR6X", "Length": "280 mm", "Interface": "PCIe 4.0 x16", "Chipset": "GeForce RTX 4090", "Max Power Consumption": "450 W"}', 20),
	('Graphic Card', 'Gaming GeForce RTX 4090 Trinity OC', 'ZOTAC', 2159, 
	'{"Memory": "24GB", "Memory Interface": "GDDR6X", "Length": "356 mm", "Interface": "PCIe 4.0 x16", "Chipset": "GeForce RTX 4090", "Max Power Consumption": "450 W"}', 20),
	('Graphic Card', 'GeForce RTX 3090 Ti FTW3 Ultra Gaming', 'EVGA', 2199.99, 
	'{"Memory": "24GB", "Memory Interface": "GDDR6X", "Length": "300 mm", "Interface": "PCIe 4.0 x16", "Chipset": "GeForce RTX 3090Ti", "Max Power Consumption": "450 W"}', 20),
	('Graphic Card', 'GeForce RTX 3090 Ti AMP Extreme Holo', 'ZOTAC', 1599.99, 
	'{"Memory": "24GB", "Memory Interface": "GDDR6X", "Length": "356 mm", "Interface": "PCIe 4.0 x16", "Chipset": "GeForce RTX 3090Ti", "Max Power Consumption": "450 W"}', 20),
	('Graphic Card', 'RTX 3080 Ti FTW3 Ultra', 'EVGA', 1340.08, 
	'{"Memory": "12GB", "Memory Interface": "GDDR6X", "Length": "300 mm", "Interface": "PCIe 4.0 x16", "Chipset": "GeForce RTX 3080Ti", "Max Power Consumption": "350 W"}', 20),
	('Graphic Card', 'RTX 3080 Ti XC3 ULTRA', 'EVGA', 1399, 
	'{"Memory": "12GB", "Memory Interface": "GDDR6X", "Length": "300 mm", "Interface": "PCIe 4.0 x16", "Chipset": "GeForce RTX 3080Ti", "Max Power Consumption": "350 W"}', 20),
	('Graphic Card', 'RTX 3080 Ti Ventus 3X 12G OC', 'MSI', 1199.99, 
	'{"Memory": "12GB", "Memory Interface": "GDDR6X", "Length": "305 mm", "Interface": "PCIe 4.0 x16", "Chipset": "GeForce RTX 3080Ti", "Max Power Consumption": "350 W"}', 20);
GO
-- Products: RAM
INSERT INTO Products (Category, Model, Brand, Price, Specifications, StockQuantity)
VALUES 
	('RAM', 'Trident Z5 RGB', 'G.Skill', 269.99, 
	'{"RAM Size": "32 GB", "Quantity": "2x16 GB", "RAM Type": "DDR5", "RAM Speed": "6400 MHz"}', 20),
	('RAM', 'Fury Renegade RGB', 'Kingston', 307.20, 
	'{"RAM Size": "32 GB", "Quantity": "2x16 GB", "RAM Type": "DDR5", "RAM Speed": "6400 MHz"}', 20),
	('RAM', 'XLR8', 'PNY', 219.99, 
	'{"RAM Size": "32 GB", "Quantity": "2x16 GB", "RAM Type": "DDR5", "RAM Speed": "6200 MHz"}', 20),
	('RAM', 'FF3D532G6000HC38ADC0', 'TEAMGROUP', 474.41, 
	'{"RAM Size": "32 GB", "Quantity": "2x16 GB", "RAM Type": "DDR5", "RAM Speed": "6000 MHz"}', 20),
	('RAM', 'AX5U6000C4016G-DCLARBK', 'XPG', 284.91, 
	'{"RAM Size": "32 GB", "Quantity": "2x16 GB", "RAM Type": "DDR5", "RAM Speed": "6000 MHz"}', 20),
	('RAM', 'DOMINATOR PLATINUM', 'Corsair', 275.99, 
	'{"RAM Size": "32 GB", "Quantity": "2x16 GB", "RAM Type": "DDR5", "RAM Speed": "6000 MHz"}', 20),
	('RAM', 'Trident Z5', 'G.Skill', 189.99, 
	'{"RAM Size": "32 GB", "Quantity": "2x16 GB", "RAM Type": "DDR5", "RAM Speed": "6000 MHz"}', 20),
	('RAM', 'CMH32GX5M2D6000C36', 'Corsair', 199.99, 
	'{"RAM Size": "32 GB", "Quantity": "2x16 GB", "RAM Type": "DDR5", "RAM Speed": "6000 MHz"}', 20),
	('RAM', 'Viper Venom RGB', 'Patriot Memory', 219.99, 
	'{"RAM Size": "32 GB", "Quantity": "2x16 GB", "RAM Type": "DDR5", "RAM Speed": "6000 MHz"}', 20),
	('RAM', 'RipJaws S5', 'G.Skill', 189.99, 
	'{"RAM Size": "32 GB", "Quantity": "2x16 GB", "RAM Type": "DDR5", "RAM Speed": "6000 MHz"}', 20),
	('RAM', 'CMK32GX5M2B5600C36', 'Corsair', 144.99, 
	'{"RAM Size": "32 GB", "Quantity": "2x16 GB", "RAM Type": "DDR5", "RAM Speed": "5600 MHz"}', 20),
	('RAM', 'KF556C40BBAK2-64', 'Kingston', 423.99, 
	'{"RAM Size": "32 GB", "Quantity": "2x16 GB", "RAM Type": "DDR5", "RAM Speed": "5600 MHz"}', 20),
	('RAM', 'Vengeance LPX', 'Corsair', 423.99, 
	'{"RAM Size": "16 GB", "Quantity": "2x8 GB", "RAM Type": "DDR4", "RAM Speed": "4600 MHz"}', 20),
	('RAM', 'Trident Z Royal', 'G.Skill', 560, 
	'{"RAM Size": "16 GB", "Quantity": "2x8 GB", "RAM Type": "DDR4", "RAM Speed": "4800 MHz"}', 20),
	('RAM', 'Trident Z RGB', 'G.Skill', 311.46, 
	'{"RAM Size": "16 GB", "Quantity": "2x8 GB", "RAM Type": "DDR4", "RAM Speed": "4600 MHz"}', 20);
GO
-- Products: Storage
INSERT INTO Products (Category, Model, Brand, Price, Specifications, StockQuantity)
VALUES 
	('Storage', '970 EVO', 'Samsung', 219.99, 
	'{"Capacity": "1 TB", "Type": "SSD", "RPM": "N/A", "Interface": "PCIe 3.0 x4", "Cache Memory": "1024 MB", "Form Factor": "M.2-2280"}', 20),
	('Storage', 'BarraCuda', 'Seagate', 55.49, 
	'{"Capacity": "2 TB", "Type": "HHD", "RPM": "7200 RPM", "Interface": "SATA III", "Cache Memory": "256 MB", "Form Factor": "3.5\""}', 20),
	('Storage', 'Caviar Blue', 'Western Digital', 34.99, 
	'{"Capacity": "1 TB", "Type": "HDD", "RPM": "7200RPM", "Interface": "SATA III", "Cache Memory": "64 MB", "Form Factor": "3.5\""}', 20),
	('Storage', 'P1', 'Crucial', 129.99, 
	'{"Capacity": "1 TB", "Type": "SSD", "RPM": "N/A", "Interface": "PCIe 3.0 x4", "Cache Memory": "N/A", "Form Factor": "SATA III"}', 20),
	('Storage', 'Blue 500', 'Western Digital', 68, 
	'{"Capacity": "500 GB", "Type": "SSD", "RPM": "N/A", "Interface": "SATA III 6Gb/s", "Cache Memory": "N/A", "Form Factor": "M.2-2280"}', 20),
	('Storage', 'A400', 'Kingston', 19.99, 
	'{"Capacity": "240 GB", "Type": "SSD", "RPM": "N/A", "Interface": "SATA III", "Cache Memory": "N/A", "Form Factor": "2.5\""}', 20),
	('Storage', 'Blue', 'Western Digital', 122.11, 
	'{"Capacity": "1 TB", "Type": "SSD", "RPM": "N/A", "Interface": "SATA III 6Gb/s", "Cache Memory": "N/A", "Form Factor": "M.2-2280"}', 20),
	('Storage', 'EVO 500', 'Samsung', 74.99, 
	'{"Capacity": "500 GB", "Type": "SSD", "RPM": "N/A", "Interface": "SATA III 6Gb/s", "Cache Memory": "512 MB", "Form Factor": "2.5\""}', 20),
	('Storage', 'Blue SN 550', 'Western Digital', 156, 
	'{"Capacity": "1 TB", "Type": "SSD", "RPM": "N/A", "Interface": "PCIe 4.0 x4", "Cache Memory": "N/A", "Form Factor": "M.2-2280"}', 20),
	('Storage', 'GX2', 'TEAMGROUP', 36.99, 
	'{"Capacity": "512 GB", "Type": "SSD", "RPM": "N/A", "Interface": "SATA III", "Cache Memory": "N/A", "Form Factor": "2.5\""}', 20),
	('Storage', 'MX 500', 'Crucial', 67.99, 
	'{"Capacity": "1 TB", "Type": "SSD", "RPM": "N/A", "Interface": "SATA III", "Cache Memory": "N/A", "Form Factor": "2.5\""}', 20),
	('Storage', 'SN 750', 'Western Digital', 137.99, 
	'{"Capacity": "1 TB", "Type": "SSD", "RPM": "N/A", "Interface": "PCIe 4.0 x4", "Cache Memory": "N/A", "Form Factor": "M.2-2280"}', 20);
GO
-- Products: Case Cooler
INSERT INTO Products (Category, Model, Brand, Price, Specifications, StockQuantity)
VALUES 
	('Case Cooler', 'MasterFan MF120R', 'Cooler Master', 79, 
	'{"Fan RPM": "650 to 2000 RPM", "Airflow": "59 CFM", "Noise Level": "31 dBA"}', 20),
	('Case Cooler', 'AER RGB', 'NZXT', 24.55, 
	'{"Fan RPM": "500 to 1500 RPM", "Airflow": "17.48 to 52.44 CFM", "Noise Level": "22 to 33 dBA"}', 20),
	('Case Cooler', 'P12 PST', 'ARCTIC', 9.99, 
	'{"Fan RPM": "1800 RPM", "Airflow": "56.3 CFM", "Noise Level": "56.3dBA"}', 20),
	('Case Cooler', 'P12 PST RGB', 'ARCTIC', 14.99, 
	'{"Fan RPM": "2000 RPM", "Airflow": "48.8 CFM", "Noise Level": "N/A"}', 20),
	('Case Cooler', 'ACFAN00118A', 'ARCTIC', 8.49, 
	'{"Fan RPM": "1800 RPM", "Airflow": "56.3 CFM", "Noise Level": "N/A"}', 20),
	('Case Cooler', 'ACFAN00170A', 'ARCTIC', 9.95, 
	'{"Fan RPM": "1800 RPM", "Airflow": "56.3 CFM", "Noise Level": "N/A"}', 20),
	('Case Cooler', 'P12 PWM', 'ARCTIC', 42.99, 
	'{"Fan RPM": "2000 RPM", "Airflow": "48.8 CFM", "Noise Level": "N/A"}', 20),
	('Case Cooler', 'P12 Silent', 'ARCTIC', 8.15, 
	'{"Fan RPM": "1050 RPM", "Airflow": "24.1 CFM", "Noise Level": "N/A"}', 20),
	('Case Cooler', 'CO-9050015-RLED', 'Corsair', 43.1, 
	'{"Fan RPM": "1500 RPM", "Airflow": "52.19 CFM", "Noise Level": "25.2dBA"}', 20),
	('Case Cooler', 'CO-9050015-BLED', 'Corsair', 19.99, 
	'{"Fan RPM": "1500 RPM", "Airflow": "52.19 CFM", "Noise Level": "25.2dBA"}', 20),
	('Case Cooler', 'SP120 RGB', 'Corsair', 74.99, 
	'{"Fan RPM": "1400 RPM", "Airflow": "52 CFM", "Noise Level": "26dBA"}', 20),
	('Case Cooler', 'HD140 RGB', 'Corsair', 142.98, 
	'{"Fan RPM": "600 to 1350 RPM", "Airflow": "74 CFM", "Noise Level": "18 to 28.6 dBA"}', 20);
GO
-- Products: Power Supply
INSERT INTO Products (Category, Model, Brand, Price, Specifications, StockQuantity)
VALUES 
	('Power Supply', 'RM750', 'Corsair', 169, 
	'{"Power": "750 W", "Efficiency": "80+ Gold", "Color": "Black"}', 20),
	('Power Supply', 'RM850', 'Corsair', 195, 
	'{"Power": "850 W", "Efficiency": "80+ Gold", "Color": "Black"}', 20),
	('Power Supply', 'Toughpower PF1', 'Thermaltake', 149.99, 
	'{"Power": "850 W", "Efficiency": "80+ Platinum", "Color": "Black"}', 20),
	('Power Supply', 'SPD-0700NP', 'Thermaltake', 54.99, 
	'{"Power": "700 W", "Efficiency": "80+", "Color": "Black"}', 20),
	('Power Supply', 'Toughpower GX1', 'Thermaltake', 59.99, 
	'{"Power": "600 W", "Efficiency": "80+ Gold", "Color": "Black"}', 20),
	('Power Supply', 'SMART 600', 'Thermaltake', 42.99, 
	'{"Power": "600 W", "Efficiency": "80+", "Color": "Black"}', 20),
	('Power Supply', 'PS-SPD-0500NPCWUS-W', 'Thermaltake', 39.99, 
	'{"Power": "500 W", "Efficiency": "80+", "Color": "Black"}', 20),
	('Power Supply', 'PS-SPD-0430NPCWUS-W', 'Thermaltake', 27.99, 
	'{"Power": "450 W", "Efficiency": "80+", "Color": "Black"}', 20),
	('Power Supply', '220-G6-0850-X1', 'EVGA', 176.99, 
	'{"Power": "850 W", "Efficiency": "80+ Gold", "Color": "Black"}', 20),
	('Power Supply', 'SuperNOVA 1000 G6', 'EVGA', 224.99, 
	'{"Power": "1000 W", "Efficiency": "80+ Gold", "Color": "Black"}', 20),
	('Power Supply', 'SuperNOVA 750 G6', 'EVGA', '139.99', 
	'{"Power": "750 W", "Efficiency": "80+ Gold", "Color": "Black"}', 20),
	('Power Supply', 'SuperNOVA', 'EVGA', 379.99, 
	'{"Power": "1000 W", "Efficiency": "80+ Gold", "Color": "Black"}', 20);
GO


