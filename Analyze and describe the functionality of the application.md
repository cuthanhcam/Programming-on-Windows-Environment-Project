# Kế hoạch phát triển ứng dụng "QUẢN LÝ BÁN HÀNG"

## A. Tổng quan các module chính

### 1. Giao diện tổng quan (Dashboard):
- Thống kê doanh thu ngày, tháng.
- Hiển thị hoạt động gần đây (chủ shop & nhân viên).
- Thống kê các mặt hàng bán chạy trong tháng.

### 2. Quản lý hàng hóa:
- **Quản lý nhập kho:**
  - Danh mục hóa đơn nhập hàng.
  - Tạo lập hóa đơn nhập kho.
- **Quản lý kho:**
  - Danh sách hàng hóa tồn kho (thêm, sửa giá bán).
  - Cảnh báo hàng sắp hết hoặc tồn quá lâu.

### 3. Quản lý giao dịch:
- Quản lý đơn đặt hàng.
- Hiển thị và tạo lập hóa đơn mới.
- **Quy tắc:** Hóa đơn thanh toán không được sửa, hóa đơn quá hạn 30 ngày sẽ bị xóa.

### 4. Quản lý đối tác:
- Nhà cung cấp.
- Khách hàng thành viên (quản lý ưu đãi, cấp bậc khách hàng).

### 5. Quản lý nhân viên:
- Tra cứu thông tin nhân viên, lịch làm việc, và lương.
- Thống kê doanh thu theo nhân viên.

### 6. Báo cáo:
- Lợi nhuận theo tháng, quý, năm.
- Báo cáo hàng hóa, giao dịch trong ngày.
- Báo cáo doanh thu nhân viên.

### 7. Phân quyền và đăng nhập:
- Hệ thống phân quyền (chủ shop, nhân viên).
- Quản lý thông tin cá nhân, đổi mật khẩu.

### 8. Tính năng "Building PC" (đặc biệt):
- Cho phép khách hàng chọn linh kiện phù hợp (mainboard, CPU, RAM, v.v.).
- Kiểm tra tính tương thích giữa các linh kiện.
- Đưa gợi ý cấu hình tối ưu dựa trên ngân sách hoặc hiệu suất.
- Cảnh báo "nghẽn cổ chai" hoặc lỗi không tương thích.

## B. Chức năng dành riêng cho nhân viên
- Thống kê doanh số cá nhân theo ngày/tháng.
- Tạo và xem hóa đơn.
- Tra cứu lịch làm việc, thống kê số buổi nghỉ.
- Quản lý thông tin cá nhân, lương.
