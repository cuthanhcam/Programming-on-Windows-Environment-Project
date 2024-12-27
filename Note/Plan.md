# Kế hoạch thực hiện

## Giai đoạn 1: Phân tích yêu cầu và thiết kế hệ thống
- Xây dựng tài liệu mô tả yêu cầu chi tiết.
- Phân tích quy trình nghiệp vụ: luồng nhập kho, bán hàng, báo cáo, tính năng Building PC.
- Thiết kế cơ sở dữ liệu:
  - **Các bảng chính:** Sản phẩm, Hóa đơn, Nhân viên, Đối tác, Cấu hình máy, Phân quyền.
  - **Quan hệ:** Hóa đơn chi tiết, Khách hàng - Ưu đãi, Nhân viên - Lương.
- Thiết kế giao diện người dùng:
  - Phác thảo mockup các màn hình: Dashboard, Quản lý kho, Building PC.

## Giai đoạn 2: Thiết lập môi trường và xây dựng cơ sở dữ liệu
- **Cài đặt:**
  - Windows Forms App (.NET Framework).
  - Entity Framework: Code First hoặc Database First.
- **Xây dựng cơ sở dữ liệu (SQL Server):**
  - Tạo bảng, ràng buộc quan hệ.
  - Đảm bảo tối ưu hóa truy vấn (index, trigger).

## Giai đoạn 3: Phát triển các chức năng chính
1. **Module Quản lý hàng hóa:**
   - Hoàn thiện nhập kho và cảnh báo tồn kho.
   - Hiển thị danh sách sản phẩm với CRUD (Create, Read, Update, Delete).
2. **Module Giao dịch và hóa đơn:**
   - Xử lý tạo hóa đơn, lưu trữ và hiển thị.
   - Quy tắc về chỉnh sửa và xóa hóa đơn.
3. **Module Dashboard và Báo cáo:**
   - Kết hợp truy vấn phức tạp (doanh thu, sản phẩm bán chạy).
   - Trực quan hóa dữ liệu (biểu đồ hoặc danh sách).
4. **Module Đối tác & nhân viên:**
   - Quản lý khách hàng: ưu đãi, cấp bậc thành viên.
   - Lịch làm việc nhân viên và tính toán lương.

## Giai đoạn 4: Phát triển tính năng "Building PC"
- **Xây dựng giao diện chọn linh kiện:**
  - Dropdown danh sách linh kiện theo danh mục (CPU, RAM, v.v.).
- **Kiểm tra tính tương thích:**
  - Áp dụng logic về socket CPU-Mainboard, dung lượng RAM, PSU.
- **Gợi ý cấu hình:**
  - Dựa trên ngân sách hoặc nhu cầu (gaming, văn phòng).
- **Thông báo lỗi hoặc cảnh báo cổ chai:**
  - Tính toán dựa trên hiệu suất.

## Giai đoạn 5: Tích hợp và kiểm thử
- **Tích hợp các module lại với nhau.**
- **Kiểm thử:**
  - Unit Test (từng chức năng nhỏ).
  - Integration Test (tích hợp).
  - User Acceptance Testing (người dùng thử nghiệm).
- **Sửa lỗi và tối ưu.**

## Giai đoạn 6: Hoàn thiện và triển khai
- **Viết tài liệu hướng dẫn sử dụng** (cho chủ shop và nhân viên).
- **Đóng gói ứng dụng và cài đặt trên máy thực tế.**
- **Thu thập phản hồi người dùng** để cải thiện.

---

# Kế hoạch chi tiết từng giao diện

## 1. Giao diện Đăng nhập (Login Form)
- **Chức năng:**
  - Nhập tên đăng nhập và mật khẩu.
  - Kiểm tra quyền truy cập (chủ shop hoặc nhân viên).
  - Thông báo lỗi nếu thông tin không chính xác.
- **Lưu ý:**
  - Thêm checkbox "Nhớ đăng nhập".
  - **Cấp quyền:**
    - Chủ shop có toàn bộ quyền.
    - Nhân viên chỉ truy cập các chức năng liên quan.

## 2. Giao diện Dashboard (Trang chính sau khi đăng nhập)
- **Chức năng (Chủ shop):**
  - Hiển thị thống kê:
    - Doanh thu hôm nay, doanh thu tháng.
    - Danh sách mặt hàng bán chạy.
    - Hoạt động gần đây (thêm/sửa hóa đơn, nhập kho).
  - Trực quan hóa dữ liệu bằng biểu đồ cột hoặc biểu đồ tròn.
- **Chức năng (Nhân viên):**
  - Thống kê doanh số cá nhân hôm nay/tháng.
  - Xếp hạng doanh thu (so sánh với các nhân viên khác).

## 3. Giao diện Quản lý hàng hóa
- **Tabs hoặc Menu chính:**
  1. **Nhập kho:**
     - Xem danh sách hóa đơn nhập hàng.
     - Thêm hóa đơn nhập kho mới:
       - Chọn nhà cung cấp.
       - Nhập thông tin hàng hóa (tên, số lượng, giá nhập).
  2. **Kho hàng:**
     - Danh sách sản phẩm hiện tại:
       - Hiển thị thông tin sản phẩm: Tên, số lượng tồn, giá bán.
       - Thay đổi giá bán (nếu có quyền).
     - **Cảnh báo:**
       - Số lượng tồn kho < 5: Hiển thị cảnh báo "Sắp hết hàng".
       - Hàng tồn quá 90 ngày: Hiển thị “Cần kiểm tra”.

## 4. Giao diện Quản lý giao dịch
- **Tabs hoặc Menu chính:**
  1. **Đơn đặt hàng:**
     - Xem danh sách đơn hàng:
       - Lọc theo trạng thái: Đang xử lý, Đã giao, Hủy.
  2. **Quản lý hóa đơn:**
     - Danh sách hóa đơn:
       - Hiển thị ID hóa đơn, ngày lập, tổng tiền.
     - Tạo lập hóa đơn mới:
       - Chọn khách hàng (thành viên hoặc khách lẻ).
       - Thêm sản phẩm từ danh sách kho.
       - Tính tổng tiền, áp dụng ưu đãi (nếu có).

## 5. Giao diện Quản lý đối tác
- **Tabs hoặc Menu chính:**
  1. **Nhà cung cấp:**
     - Hiển thị danh sách nhà cung cấp.
     - Thêm/sửa thông tin nhà cung cấp: Tên, số điện thoại, địa chỉ.
  2. **Khách hàng thành viên:**
     - Danh sách khách hàng thành viên:
       - Tên, cấp bậc (vàng, bạc), ưu đãi áp dụng.
     - Thêm khách hàng mới.
     - Chỉnh sửa thông tin hoặc cập nhật ưu đãi.

## 6. Giao diện Quản lý nhân viên
- **Chức năng:**
  - Xem danh sách nhân viên:
    - Họ tên, MANV, ngày vào làm, lương cơ bản.
  - **Lịch làm việc:**
    - Xem lịch phân công tuần này/tuần sau.
    - Điểm danh (chỉ điểm danh đúng thời gian quy định).
  - **Thống kê lương:**
    - Hiển thị số buổi nghỉ, doanh thu đóng góp.
  - **Cập nhật thông tin cá nhân:**
    - Sửa thông tin (trừ MANV và ngày vào làm).
    - Đổi username/mật khẩu.

## 7. Giao diện Báo cáo
- **Tabs hoặc Menu chính:**
  1. **Tài chính:**
     - Lợi nhuận theo tháng, quý, năm.
  2. **Báo cáo cuối ngày:**
     - Tổng doanh thu.
     - Số lượng hàng hóa nhập vào, bán ra.
     - Giao dịch thực hiện hôm nay.
  3. **Báo cáo nhân viên:**
     - Doanh thu của từng nhân viên.

## 8. Giao diện Building PC
- **Chức năng:**
  - Dropdown chọn linh kiện: CPU, Mainboard, RAM, GPU, PSU.
  - **Kiểm tra tính tương thích:**
    - Socket CPU-Mainboard.
    - RAM phù hợp mainboard (loại, dung lượng tối đa).
    - PSU đủ công suất.
  - **Gợi ý cấu hình:**
    - Dựa theo ngân sách hoặc hiệu suất.
  - **Thông báo lỗi:**
    - “Không tương thích” hoặc “Cổ chai” (ví dụ: GPU quá mạnh so với CPU).
