# Kế hoạch phát triển ứng dụng "QUẢN LÝ BÁN HÀNG"

## Phần đã hoàn thành

### 1. Database (Có tổng cộng 7 Tables)
- Products(ProductID, Category, Model, Brand, Price, StockQuantity, Specifications)
- Orders(OrderID, CustomerID, EmployeeID, OrderDate, TotalAmount, Status)
- OrderDetails(OrderDetailID, OrderID, ProductID, Quantity, Price)
- Customers(CustomerID, Name, Email, Phone, MembershipLevel)
- Employees(EmployeeID, Name, Position, Salary, HireDate)
- StockTransactions(TransactionID, ProductID, TransactionType, Quantity, TransactionDate, EmployeeID)
- Users(UserID, Username, PasswordHash, Role, CreatedAt)
### 2. Form Login (frmLogin)
- Đã cập nhật các chức năng liên quan đến phân quyền (role)
- Thay đổi hàm băm SHA256 trong UserService để phù hợp với CSDL (chuỗi HEX)
- Thêm UI, các chức năng phụ (nút đóng, checkBox Hide/Show password,...)

## A. Tổng quan các module chính

### 1. Quản lý Sản phẩm (Products):
- Thêm mới sản phẩm.
- Cập nhật thông tin sản phẩm.
- Xóa sản phẩm.
- Xem danh sách sản phẩm.
- Tìm kiếm, lọc sản phẩm theo danh mục, thương hiệu.

### 2. Quản lý Đơn hàng (Orders, OrderDetails)
- Tạo đơn hàng mới.
- Cập nhật đơn hàng (Hủy, Hoàn thành).
- Xem chi tiết đơn hàng.
- Lọc đơn hàng theo trạng thái.

### 3. Quản lý Khách hàng (Customers)
- Thêm mới khách hàng.
- Cập nhật thông tin khách hàng.
- Xem danh sách khách hàng.
- Phân loại khách hàng theo hạng (Silver, Gold, Platinum).

### 4. Quản lý Nhân viên (Employees) (Dành cho Admin)
- Thêm, sửa, xóa nhân viên.
- Cập nhật lương và thông tin nhân viên.
- Phân quyền nhân viên (Admin, Sales).

### 5. Quản lý Kho (StockTransactions)
- Nhập/xuất kho sản phẩm.
- Xem lịch sử giao dịch kho.

### 6. Báo cáo & Thống kê
- Báo cáo doanh thu theo ngày/tháng/năm.
- Thống kê sản phẩm bán chạy.
- Thống kê nhân viên có nhiều đơn hàng.
