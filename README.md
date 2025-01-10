# C4F Sales Management

C4F Sales Management là một ứng dụng quản lý bán hàng được thiết kế để hỗ trợ các cửa hàng kinh doanh phụ kiện máy tính tối ưu hóa quy trình quản lý sản phẩm, đơn hàng, khách hàng, kho hàng và nhân viên. Ứng dụng được phát triển trên nền tảng `.NET Framework` với sự kết hợp của `Entity Framework` và `mô hình 3 lớp`.

- **Nhóm 1 - CODE FOR FOOD**:
  - Cù Thanh Cầm
  - Nguyễn Trần Đăng Khoa
  - Trần Trung Hậu
  - Trương Phước Hưng

## Tính Năng Chính

1. **Quản lý sản phẩm**:
   - Thêm mới, chỉnh sửa, xóa, và tìm kiếm sản phẩm.
   - Quản lý danh mục sản phẩm như CPU, RAM, Mainboard, Case, và nhiều hơn nữa.

2. **Quản lý đơn hàng**:
   - Theo dõi danh sách đơn hàng và chi tiết từng đơn hàng.
   - Xử lý trạng thái đơn hàng (Pending, Completed, Cancelled).

3. **Quản lý khách hàng**:
   - Lưu trữ thông tin khách hàng và theo dõi lịch sử mua sắm.
   - Tìm kiếm, chỉnh sửa và thêm mới khách hàng.

4. **Quản lý giao dịch kho**:
   - Theo dõi lịch sử nhập/xuất hàng.
   - Cập nhật số lượng tồn kho theo thời gian thực.

5. **Thống kê và báo cáo**:
   - Tổng hợp doanh thu, lợi nhuận, và các chỉ số kinh doanh.
   - Hiển thị dưới dạng biểu đồ và báo cáo chi tiết.

6. **Quản lý nhân viên**:
   - Quản lý thông tin và phân quyền nhân viên (Admin, Staff).
   - Theo dõi hoạt động và thông tin đăng nhập.

## Công Nghệ Sử Dụng

- **Ngôn ngữ lập trình**: C# (Windows Forms)
- **Nền tảng phát triển**: .NET Framework
- **Quản lý dữ liệu**: Entity Framework, SQL Server
- **Mô hình kiến trúc**: 3-Layers Architecture (Presentation, Business Logic, Data Access)

## Hướng Dẫn Cài Đặt

1. **Yêu cầu hệ thống**:
   - Windows OS
   - .NET Framework 4.7.2 trở lên
   - SQL Server

2. **Bước cài đặt**:
   - Clone repository:
     ```bash
     git clone https://github.com/username/C4F-Sales-Management.git
     ```
   - Import cơ sở dữ liệu từ file SQL có sẵn trong thư mục `Database`.
   - Cấu hình chuỗi kết nối trong file `App.config`.
   - Build và chạy ứng dụng từ Visual Studio.

## Hướng Phát Triển Tương Lai

1. **Mở rộng nền tảng**:
   - Phát triển phiên bản web và mobile.
   - Tích hợp API để đồng bộ hóa với các nền tảng thương mại điện tử.

2. **Tăng cường tính năng**:
   - Tích hợp thanh toán trực tuyến qua MoMo, VNPay, ZaloPay.
   - Hỗ trợ các chương trình khuyến mãi và tri ân khách hàng.

3. **Bảo mật**:
   - Xác thực hai yếu tố (2FA).
   - Áp dụng các giao thức mã hóa dữ liệu hiện đại.

4. **Tối ưu hóa giao diện**:
   - Nâng cao trải nghiệm người dùng với giao diện hiện đại và trực quan hơn.




