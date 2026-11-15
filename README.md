# CỔNG QUẢN LÝ CA TRỰC VÀ BÀN GIAO VẬN HÀNH

## 1. Giới thiệu

Đây là đồ án cuối kỳ môn **Phương pháp phát triển phần mềm hướng đối tượng (OOSD)**, xây dựng ứng dụng **Cổng quản lý ca trực và bàn giao vận hành** bằng **C#** và **Windows Forms**.

- Sinh viên: **Phan Nguyễn Gia Huy** – MSSV **1250080076** – Lớp **12_ĐH_CNPM2**
- Giảng viên hướng dẫn: **ThS. Phạm Trọng Huynh**
- Trường Đại học Tài nguyên và Môi trường TP.HCM – Khoa Công nghệ thông tin

Ứng dụng hỗ trợ đơn vị vận hành quản lý lịch trực, điểm danh chuyên cần, ghi nhật ký và sự cố trong ca, lập và xác nhận biên bản bàn giao ca, theo dõi công việc tồn đọng, xử lý đơn đổi ca / nghỉ phép và thống kê. Dữ liệu được lưu trên **SQL Server** với cơ sở dữ liệu **CaTrucDB**.

Chương trình được tổ chức theo nhiều tầng: giao diện (Forms), nghiệp vụ (Services), mô hình dữ liệu (Models) và truy cập dữ liệu (Data). Các quy tắc nghiệp vụ **BR01 đến BR08** được kiểm tra ngay trong cơ sở dữ liệu bằng stored procedure, view và trigger.

## 2. Công nghệ sử dụng

- C# (.NET Framework 4.7.2)
- Windows Forms
- ADO.NET (System.Data.SqlClient)
- SQL Server (Stored Procedure, View, Trigger)
- Visual Studio
- Git/GitHub

## 3. Chức năng chính

**Đăng nhập và phân quyền**

- Đăng nhập bằng tên đăng nhập và mật khẩu (mật khẩu được băm SHA-256 trong cơ sở dữ liệu).
- Ba vai trò: **Nhân viên trực**, **Trưởng ca**, **Quản lý**. Menu và các nút thao tác hiển thị theo vai trò.

**Quản lý lịch trực**

- Xem lịch trực theo khoảng ngày (nhân viên chỉ xem lịch của mình).
- Trưởng ca / Quản lý phân công lịch trực theo nhân viên, ca, vị trí, ngày.
- Hỗ trợ **ca gãy**: người phân công tự nhập giờ bắt đầu và giờ kết thúc (tối đa 12 giờ).
- Chống trùng lịch theo khoảng giờ (BR01).

**Điểm danh chuyên cần**

- Check-in sớm tối đa 30 phút trước ca; check-in sau giờ bắt đầu bị ghi "Đi trễ" (BR02).
- Chỉ được nhận ca khi ca trước đã gửi biên bản bàn giao (BR03).
- Check-out trước giờ kết thúc bị ghi "Về sớm" (BR08).

**Nhật ký, sự cố và bàn giao ca**

- Ghi nhật ký vận hành và sự cố (có mức độ) khi ca đang diễn ra.
- Lập biên bản bàn giao; việc và sự cố chưa xử lý tự chuyển thành công việc tồn đọng (BR04).
- Người nhận ca xác nhận biên bản; biên bản đã xác nhận bị khóa, không sửa hoặc xóa được (BR05).

**Đơn đổi ca và nghỉ phép**

- Nhân viên gửi đơn cho ca của mình, trước giờ bắt đầu ca ít nhất 24 giờ (BR06, BR07).
- Trưởng ca / Quản lý duyệt hoặc từ chối đơn; đơn được duyệt thì lịch gốc chuyển sang "Đã hủy".

**Thống kê**

- Chuyên cần theo nhân viên (đúng giờ, đi trễ, về sớm, vắng), số sự cố theo mức độ, số biên bản và công việc tồn đọng.

## 4. Cấu trúc thư mục

```text
GiaHuy_1250080076_QuanLyCaTruc/
├── README.md
├── CaTruc.sql                  # Script tạo CSDL, bảng, dữ liệu mẫu, view, stored procedure, trigger
├── Diagrams/                   # Sơ đồ use case, activity, sequence, class, ERD
├── Images/                     # Ảnh giao diện và hình minh họa
├── (Báo cáo .docx)
└── QuanLyCaVanHanh/
    ├── QuanLyCaVanHanh.sln
    └── QuanLyCaVanHanh/
        ├── App.config          # Chuỗi kết nối CSDL
        ├── Program.cs
        ├── Models.cs           # Các lớp thực thể
        ├── Data/
        │   └── DbHelper.cs     # Truy cập CSDL (ADO.NET)
        ├── Services/           # Xử lý nghiệp vụ (AuthService, LichTrucService, ...)
        └── Forms/              # Giao diện (FrmDangNhap, FrmMain, FrmLichTruc, ...)
```

## 5. Cách tải và chạy chương trình

### 5.1. Tải source code

```bash
git clone https://github.com/HuyPhan1503/GiaHuy_1250080076_QuanLyCaTruc.git
cd GiaHuy_1250080076_QuanLyCaTruc
```

Hoặc bấm **Code → Download ZIP** trên trang GitHub rồi giải nén.

### 5.2. Mở project

Mở thư mục `QuanLyCaVanHanh` và mở file `QuanLyCaVanHanh.sln` bằng Visual Studio.

Hoặc mở Visual Studio, chọn **File → Open → Project/Solution**, sau đó chọn file `QuanLyCaVanHanh.sln`.

### 5.3. Tạo cơ sở dữ liệu

1. Mở **SQL Server Management Studio (SSMS)** và kết nối đến SQL Server.
2. Mở file `CaTruc.sql` ở thư mục gốc của repository.
3. Thực thi toàn bộ script (**Execute** hoặc F5) để tạo cơ sở dữ liệu `CaTrucDB`, các bảng, dữ liệu mẫu, view, stored procedure và trigger.

### 5.4. Cấu hình kết nối cơ sở dữ liệu

Mở file `App.config` trong project và kiểm tra chuỗi kết nối đến SQL Server.

Nếu tên SQL Server trên máy khác với cấu hình hiện tại (mặc định dự án dùng instance `.\SQL2025`), hãy thay đổi giá trị `Data Source` cho phù hợp.

Ví dụ:

```xml
<connectionStrings>
    <add name="CaTrucDB"
         connectionString="Data Source=.\SQL2025;Initial Catalog=CaTrucDB;Integrated Security=True"
         providerName="System.Data.SqlClient" />
</connectionStrings>
```

Không đưa mật khẩu hoặc thông tin bí mật vào `App.config` khi đẩy lên GitHub; dự án dùng xác thực Windows (`Integrated Security=True`).

### 5.5. Chạy chương trình

Trong Visual Studio:

1. Chọn project `QuanLyCaVanHanh` làm **Startup Project**.
2. Chọn **Build → Build Solution** để build project.
3. Nhấn **F5** hoặc chọn **Debug → Start Debugging** để chạy chương trình.

Nếu cấu hình đúng, màn hình đăng nhập của ứng dụng sẽ xuất hiện.

### 5.6. Tài khoản đăng nhập mẫu

Mật khẩu của tất cả tài khoản mẫu là `123456`.

| Tên đăng nhập | Vai trò        |
| ------------- | -------------- |
| `an`          | Nhân viên trực |
| `binh`        | Nhân viên trực |
| `cuong`       | Nhân viên trực |
| `dung`        | Trưởng ca      |
| `em`          | Quản lý        |

### 5.7. Gợi ý thao tác thử nhanh

1. Đăng nhập `em` (Quản lý) → **Lịch trực** → phân công một ca cho nhân viên.
2. Đăng nhập `an` (Nhân viên trực) → **Điểm danh** → Check-in khi đến giờ ca.
3. Vào **Bàn giao ca** → ghi nhật ký, ghi sự cố, lập biên bản.
4. Đăng nhập nhân viên ca sau → xác nhận nhận ca.
5. Đăng nhập `em` → **Thống kê** để xem báo cáo.

### 5.8. Lưu ý

- Cần cài đặt **Visual Studio** (khối lượng công việc .NET desktop) và **SQL Server** trước khi chạy chương trình.
- Cần thực thi file `CaTruc.sql` để tạo cơ sở dữ liệu trước khi chạy ứng dụng.
- Kiểm tra lại `Data Source` trong `App.config` nếu chương trình không kết nối được với SQL Server.
- Nếu Visual Studio báo thiếu `System.Configuration`, thêm reference này cho project (Add Reference → Assemblies → System.Configuration).
- Đảm bảo **SQL Server đang hoạt động** trước khi chạy chương trình.
- Nếu muốn đưa dữ liệu về trạng thái ban đầu, chạy lại file `CaTruc.sql` (script xóa và tạo lại dữ liệu mẫu).
