# Kế hoạch phát triển ứng dụng "QUẢN LÝ BÁN HÀNG"

## Phần đã hoàn thành

### 1. Database (Có tổng cộng 7 Tables)
- Products(ProductID, Category, Model, Brand, Price, StockQuantity, Specifications, Promotion, Warranty, Image)
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


## B. Phân Quyền Chức Năng theo Vai Trò:
- Chức Năng-------------------------------- -Admin 	User (Nhân viên)
- Quản lý sản phẩm---------------------------✔️		✔️
- Quản lý đơn hàng---------------------------✔️		✔️
- Quản lý khách hàng-------------------------✔️		✔️
- Quản lý nhân viên---------------------------✔️		❌
- Quản lý kho--------------------------------- ✔️		✔️
- Báo cáo & Thống kê------------------------✔️		✔️ (Hạn chế)
- Tạo tài khoản và phân quyền---------------✔️		❌

## C. Các phương án tổ Chức frmMain:

### Phương án 1: Sử dụng MenuStrip + Tab Control (Phù hợp ứng dụng lớn)
- Tạo MenuStrip gồm các menu như Sản phẩm, Đơn hàng, Khách hàng, Nhân viên, Kho, Báo cáo.
- Mỗi khi click vào mục trong MenuStrip, hiển thị TabPage tương ứng trong TabControl bên dưới.
- Tối ưu cho việc mở nhiều chức năng cùng lúc và quản lý dễ dàng.
### Phương án 2: Dùng Panel và Sidebar (Giao diện hiện đại hơn)
- Tạo Panel Sidebar bên trái chứa các button/icon (Sản phẩm, Đơn hàng, Khách hàng...).
- Khi click vào từng button, load UserControl tương ứng vào Panel chính giữa.
- Giao diện trực quan, dễ chuyển đổi giữa các chức năng.
### Phương án 3: Tạo Form riêng cho từng chức năng (Phù hợp với ứng dụng đơn giản)
- Tạo form riêng cho từng chức năng (frmProducts, frmOrders, frmEmployees…).
- Sử dụng MenuStrip hoặc Ribbon để gọi các form này khi click vào.
- Thích hợp với ứng dụng không cần mở nhiều form cùng lúc. \

## D. Gợi ý Thiết Kế Giao Diện (UI/UX):
- Sản phẩm: GridView hiển thị danh sách sản phẩm, nút thêm/xóa/sửa bên trên.
- Đơn hàng: ListView đơn hàng + chi tiết hiển thị dạng popup.
- Khách hàng: GridView với ô tìm kiếm nhanh.
- Kho: Biểu đồ trạng thái kho hoặc lịch sử giao dịch.
- Báo cáo: Biểu đồ cột và đường trực quan cho doanh thu, bán hàng.