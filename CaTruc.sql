/* =========================================================================
   DỰ ÁN: CỔNG QUẢN LÝ CA TRỰC VÀ BÀN GIAO VẬN HÀNH
   Sinh viên: Phan Nguyễn Gia Huy — MSSV: 1250080076
   CSDL: SQL Server (T-SQL)

   NỘI DUNG SCRIPT (chạy một lần, theo thứ tự):
     PHẦN 1. Tạo cơ sở dữ liệu và 9 bảng (13 khóa ngoại), hỗ trợ ca gãy (CA04)
     PHẦN 2. Dữ liệu mẫu (tài khoản mật khẩu: 123456)
     PHẦN 3. View (7 view)
     PHẦN 4. Stored Procedure (10 thủ tục)
     PHẦN 5. Trigger (5 trigger)
     PHẦN 6. Ví dụ gọi thử

   QUY TẮC NGHIỆP VỤ ĐƯỢC CÀI TRONG CSDL:
     BR01  chỉ mục duy nhất (ca cố định) + usp_TaoLichTruc (kiểm tra trùng theo khoảng giờ, gồm ca gãy)
     BR02  usp_CheckIn  (check-in sớm tối đa 30 phút, sau giờ bắt đầu = Đi trễ)
     BR03  usp_CheckIn  (ca trước chưa có biên bản thì không nhận ca)
     BR04  usp_LapBienBan (tự tạo TON_DONG từ nhật ký chưa xử lý xong)
     BR05  usp_XacNhanBanGiao + trigger chặn sửa/xóa biên bản "Đã khóa"
     BR06  usp_GuiDon   (gửi đơn trước giờ bắt đầu ca tối thiểu 24 giờ)
     BR07  kiểm tra chủ lịch trực trong các thủ tục
     BR08  usp_CheckOut (check-out trước giờ kết thúc = Về sớm)
   ========================================================================= */

/* =========================================================================
   PHẦN 1. TẠO CƠ SỞ DỮ LIỆU VÀ CÁC BẢNG
   ========================================================================= */
-- Tạo database nếu chưa có (không xóa database, tránh lỗi "đang được sử dụng")
USE master;
GO

IF DB_ID(N'CaTrucDB') IS NULL
BEGIN
    CREATE DATABASE CaTrucDB;
END
GO

USE CaTrucDB;
GO

-- CHÚ Ý: các lệnh dưới XÓA toàn bộ view, thủ tục, bảng cũ của dự án (nếu có)
-- để script chạy lại được nhiều lần mà không báo "already exists".
-- Mọi dữ liệu cũ trong các bảng này sẽ mất.

-- 1) Xóa view
IF OBJECT_ID(N'v_ThongKeChuyenCan', N'V') IS NOT NULL DROP VIEW v_ThongKeChuyenCan;
IF OBJECT_ID(N'v_DonDoiCaChiTiet', N'V')  IS NOT NULL DROP VIEW v_DonDoiCaChiTiet;
IF OBJECT_ID(N'v_TonDongChuaXuLy', N'V')  IS NOT NULL DROP VIEW v_TonDongChuaXuLy;
IF OBJECT_ID(N'v_BanGiaoChiTiet', N'V')   IS NOT NULL DROP VIEW v_BanGiaoChiTiet;
IF OBJECT_ID(N'v_NhatKyChiTiet', N'V')    IS NOT NULL DROP VIEW v_NhatKyChiTiet;
IF OBJECT_ID(N'v_DiemDanhChiTiet', N'V')  IS NOT NULL DROP VIEW v_DiemDanhChiTiet;
IF OBJECT_ID(N'v_LichTrucChiTiet', N'V')  IS NOT NULL DROP VIEW v_LichTrucChiTiet;

-- 2) Xóa stored procedure
IF OBJECT_ID(N'usp_DangNhap', N'P')       IS NOT NULL DROP PROCEDURE usp_DangNhap;
IF OBJECT_ID(N'usp_TaoLichTruc', N'P')    IS NOT NULL DROP PROCEDURE usp_TaoLichTruc;
IF OBJECT_ID(N'usp_CheckIn', N'P')        IS NOT NULL DROP PROCEDURE usp_CheckIn;
IF OBJECT_ID(N'usp_CheckOut', N'P')       IS NOT NULL DROP PROCEDURE usp_CheckOut;
IF OBJECT_ID(N'usp_GhiNhatKy', N'P')      IS NOT NULL DROP PROCEDURE usp_GhiNhatKy;
IF OBJECT_ID(N'usp_LapBienBan', N'P')     IS NOT NULL DROP PROCEDURE usp_LapBienBan;
IF OBJECT_ID(N'usp_XacNhanBanGiao', N'P') IS NOT NULL DROP PROCEDURE usp_XacNhanBanGiao;
IF OBJECT_ID(N'usp_GuiDon', N'P')         IS NOT NULL DROP PROCEDURE usp_GuiDon;
IF OBJECT_ID(N'usp_DuyetDon', N'P')       IS NOT NULL DROP PROCEDURE usp_DuyetDon;
IF OBJECT_ID(N'usp_BaoCaoThongKe', N'P')  IS NOT NULL DROP PROCEDURE usp_BaoCaoThongKe;

-- 3) Xóa bảng theo thứ tự ngược với khóa ngoại (trigger và index đi theo bảng)
IF OBJECT_ID(N'DON_DOI_CA', N'U') IS NOT NULL DROP TABLE DON_DOI_CA;
IF OBJECT_ID(N'TON_DONG', N'U')   IS NOT NULL DROP TABLE TON_DONG;
IF OBJECT_ID(N'BAN_GIAO', N'U')   IS NOT NULL DROP TABLE BAN_GIAO;
IF OBJECT_ID(N'NHAT_KY', N'U')    IS NOT NULL DROP TABLE NHAT_KY;
IF OBJECT_ID(N'DIEM_DANH', N'U')  IS NOT NULL DROP TABLE DIEM_DANH;
IF OBJECT_ID(N'LICH_TRUC', N'U')  IS NOT NULL DROP TABLE LICH_TRUC;
IF OBJECT_ID(N'VI_TRI', N'U')     IS NOT NULL DROP TABLE VI_TRI;
IF OBJECT_ID(N'CA', N'U')         IS NOT NULL DROP TABLE CA;
IF OBJECT_ID(N'NGUOI_DUNG', N'U') IS NOT NULL DROP TABLE NGUOI_DUNG;
GO

/* 1. NGUOI_DUNG */
CREATE TABLE NGUOI_DUNG (
    MaNguoiDung VARCHAR(20)   NOT NULL,
    HoTen       NVARCHAR(100) NOT NULL,
    TenDangNhap VARCHAR(50)   NOT NULL,
    MatKhauHash VARCHAR(255)  NOT NULL,
    VaiTro      VARCHAR(20)   NOT NULL,
    TrangThai   NVARCHAR(30)  NOT NULL DEFAULT N'Hoạt động',

    CONSTRAINT PK_NGUOI_DUNG PRIMARY KEY (MaNguoiDung),
    CONSTRAINT UQ_NGUOI_DUNG_TENDANGNHAP UNIQUE (TenDangNhap),
    CONSTRAINT CK_NGUOI_DUNG_VAITRO
        CHECK (VaiTro IN ('NHAN_VIEN_TRUC', 'TRUONG_CA', 'QUAN_LY')),
    CONSTRAINT CK_NGUOI_DUNG_TRANGTHAI
        CHECK (TrangThai IN (N'Hoạt động', N'Bị khóa'))
);
GO

/* 2. CA */
CREATE TABLE CA (
    MaCa       VARCHAR(20)  NOT NULL,
    TenCa      NVARCHAR(50) NOT NULL,
    GioBatDau  TIME         NOT NULL,
    GioKetThuc TIME         NOT NULL,
    -- 1 = ca gãy: giờ bắt đầu/kết thúc do Trưởng ca / Quản lý nhập khi phân công
    TuyChinhGio BIT         NOT NULL CONSTRAINT DF_CA_TUYCHINHGIO DEFAULT 0,

    CONSTRAINT PK_CA PRIMARY KEY (MaCa)
);
GO

/* 3. VI_TRI */
CREATE TABLE VI_TRI (
    MaViTri  VARCHAR(20)   NOT NULL,
    TenViTri NVARCHAR(100) NOT NULL,
    MoTa     NVARCHAR(255) NULL,

    CONSTRAINT PK_VI_TRI PRIMARY KEY (MaViTri)
);
GO

/* 4. LICH_TRUC */
CREATE TABLE LICH_TRUC (
    MaLichTruc  VARCHAR(20)  NOT NULL,
    MaNguoiDung VARCHAR(20)  NOT NULL,
    MaCa        VARCHAR(20)  NOT NULL,
    MaViTri     VARCHAR(20)  NOT NULL,
    NgayTruc    DATE         NOT NULL,
    TrangThai   NVARCHAR(30) NOT NULL DEFAULT N'Chờ kích hoạt',
    -- Chỉ dùng cho ca gãy (CA.TuyChinhGio = 1): giờ do người phân công nhập
    GioBatDauTuyChinh  TIME  NULL,
    GioKetThucTuyChinh TIME  NULL,

    CONSTRAINT PK_LICH_TRUC PRIMARY KEY (MaLichTruc),
    CONSTRAINT FK_LICH_TRUC_NGUOI_DUNG
        FOREIGN KEY (MaNguoiDung) REFERENCES NGUOI_DUNG (MaNguoiDung),
    CONSTRAINT FK_LICH_TRUC_CA
        FOREIGN KEY (MaCa) REFERENCES CA (MaCa),
    CONSTRAINT FK_LICH_TRUC_VI_TRI
        FOREIGN KEY (MaViTri) REFERENCES VI_TRI (MaViTri),

    -- Hai cột giờ tùy chỉnh phải cùng có hoặc cùng trống
    CONSTRAINT CK_LICH_TRUC_GIO_TUYCHINH
        CHECK ((GioBatDauTuyChinh IS NULL AND GioKetThucTuyChinh IS NULL)
            OR (GioBatDauTuyChinh IS NOT NULL AND GioKetThucTuyChinh IS NOT NULL)),

    CONSTRAINT CK_LICH_TRUC_TRANGTHAI
        CHECK (TrangThai IN (N'Chờ kích hoạt', N'Đang diễn ra', N'Đã kết thúc', N'Đã hủy'))
);
GO

-- BR01 (ca cố định): mỗi vị trí trong một ca của một ngày chỉ có một nhân sự
-- Ca gãy (CA04) được loại khỏi chỉ mục này vì một ngày có thể có nhiều ca gãy khác giờ;
-- với ca gãy, usp_TaoLichTruc kiểm tra trùng theo khoảng giờ.
CREATE UNIQUE INDEX UX_LICH_TRUC_VITRI_CA_NGAY
    ON LICH_TRUC (MaViTri, MaCa, NgayTruc) WHERE MaCa <> 'CA04';
-- Một nhân viên không trực hai vị trí cùng ca (cố định) trong một ngày
CREATE UNIQUE INDEX UX_LICH_TRUC_NGUOI_CA_NGAY
    ON LICH_TRUC (MaNguoiDung, MaCa, NgayTruc) WHERE MaCa <> 'CA04';
GO

/* 5. DIEM_DANH */
CREATE TABLE DIEM_DANH (
    MaDiemDanh  VARCHAR(20)  NOT NULL,
    MaLichTruc  VARCHAR(20)  NOT NULL,
    GioCheckIn  DATETIME     NULL,
    GioCheckOut DATETIME     NULL,
    TrangThai   NVARCHAR(30) NOT NULL DEFAULT N'Chưa điểm danh',

    CONSTRAINT PK_DIEM_DANH PRIMARY KEY (MaDiemDanh),
    CONSTRAINT FK_DIEM_DANH_LICH_TRUC
        FOREIGN KEY (MaLichTruc) REFERENCES LICH_TRUC (MaLichTruc),
    CONSTRAINT UQ_DIEM_DANH_LICH_TRUC UNIQUE (MaLichTruc),
    CONSTRAINT CK_DIEM_DANH_GIO
        CHECK (GioCheckOut IS NULL OR GioCheckIn IS NULL OR GioCheckOut >= GioCheckIn),
    -- BR02, BR08
    CONSTRAINT CK_DIEM_DANH_TRANGTHAI
        CHECK (TrangThai IN (N'Chưa điểm danh', N'Đúng giờ', N'Đi trễ', N'Về sớm', N'Vắng'))
);
GO

/* 6. NHAT_KY */
CREATE TABLE NHAT_KY (
    MaNhatKy    VARCHAR(20)   NOT NULL,
    MaLichTruc  VARCHAR(20)   NOT NULL,
    LoaiNhatKy  NVARCHAR(30)  NOT NULL,
    MucDo       NVARCHAR(20)  NULL,
    NoiDung     NVARCHAR(MAX) NOT NULL,
    TrangThai   NVARCHAR(30)  NOT NULL DEFAULT N'Chưa xử lý',
    ThoiGianGhi DATETIME      NOT NULL DEFAULT GETDATE(),

    CONSTRAINT PK_NHAT_KY PRIMARY KEY (MaNhatKy),
    CONSTRAINT FK_NHAT_KY_LICH_TRUC
        FOREIGN KEY (MaLichTruc) REFERENCES LICH_TRUC (MaLichTruc),
    CONSTRAINT CK_NHAT_KY_LOAI
        CHECK (LoaiNhatKy IN (N'Vận hành', N'Sự cố')),
    CONSTRAINT CK_NHAT_KY_MUCDO
        CHECK (MucDo IS NULL OR MucDo IN (N'Thấp', N'Trung bình', N'Cao', N'Khẩn cấp')),
    CONSTRAINT CK_NHAT_KY_TRANGTHAI
        CHECK (TrangThai IN (N'Chưa xử lý', N'Đang xử lý', N'Đã xử lý'))
);
GO

/* 7. BAN_GIAO */
CREATE TABLE BAN_GIAO (
    MaBanGiao      VARCHAR(20)   NOT NULL,
    MaLichTrucGiao VARCHAR(20)   NOT NULL,
    MaLichTrucNhan VARCHAR(20)   NULL,
    NoiDungTongKet NVARCHAR(MAX) NOT NULL,
    ThoiDiemGui    DATETIME      NOT NULL DEFAULT GETDATE(),
    ThoiDiemNhanCa DATETIME      NULL,
    TrangThai      NVARCHAR(30)  NOT NULL DEFAULT N'Chờ xác nhận',
    MaNguoiXacNhan VARCHAR(20)   NULL,

    CONSTRAINT PK_BAN_GIAO PRIMARY KEY (MaBanGiao),
    CONSTRAINT FK_BAN_GIAO_LICH_GIAO
        FOREIGN KEY (MaLichTrucGiao) REFERENCES LICH_TRUC (MaLichTruc),
    CONSTRAINT FK_BAN_GIAO_LICH_NHAN
        FOREIGN KEY (MaLichTrucNhan) REFERENCES LICH_TRUC (MaLichTruc),
    CONSTRAINT FK_BAN_GIAO_NGUOI_XAC_NHAN
        FOREIGN KEY (MaNguoiXacNhan) REFERENCES NGUOI_DUNG (MaNguoiDung),
    CONSTRAINT UQ_BAN_GIAO_LICH_GIAO UNIQUE (MaLichTrucGiao),
    CONSTRAINT CK_BAN_GIAO_KHAC_LICH
        CHECK (MaLichTrucNhan IS NULL OR MaLichTrucNhan <> MaLichTrucGiao),
    CONSTRAINT CK_BAN_GIAO_TRANGTHAI
        CHECK (TrangThai IN (N'Chờ xác nhận', N'Đã khóa', N'Đã hủy')),
    -- BR05: chỉ khóa biên bản khi đã có người xác nhận và thời điểm nhận ca
    CONSTRAINT CK_BAN_GIAO_KHOA_DU_DIEU_KIEN
        CHECK (TrangThai <> N'Đã khóa'
               OR (MaNguoiXacNhan IS NOT NULL AND ThoiDiemNhanCa IS NOT NULL))
);
GO

-- Mỗi lịch trực chỉ nhận tối đa một biên bản ở vai trò ca nhận
CREATE UNIQUE INDEX UX_BAN_GIAO_LICH_NHAN
    ON BAN_GIAO (MaLichTrucNhan)
    WHERE MaLichTrucNhan IS NOT NULL;
GO

/* 8. TON_DONG */
CREATE TABLE TON_DONG (
    MaTonDong VARCHAR(20)   NOT NULL,
    MaBanGiao VARCHAR(20)   NOT NULL,
    MaNhatKy  VARCHAR(20)   NOT NULL,
    GhiChu    NVARCHAR(255) NULL,
    TrangThai NVARCHAR(30)  NOT NULL DEFAULT N'Chưa xử lý',

    CONSTRAINT PK_TON_DONG PRIMARY KEY (MaTonDong),
    CONSTRAINT FK_TON_DONG_BAN_GIAO
        FOREIGN KEY (MaBanGiao) REFERENCES BAN_GIAO (MaBanGiao),
    CONSTRAINT FK_TON_DONG_NHAT_KY
        FOREIGN KEY (MaNhatKy) REFERENCES NHAT_KY (MaNhatKy),
    CONSTRAINT CK_TON_DONG_TRANGTHAI
        CHECK (TrangThai IN (N'Chưa xử lý', N'Đang xử lý', N'Đã xử lý'))
);
GO

/* 9. DON_DOI_CA */
CREATE TABLE DON_DOI_CA (
    MaDon         VARCHAR(20)   NOT NULL,
    MaNguoiGui    VARCHAR(20)   NOT NULL,
    MaNguoiDuyet  VARCHAR(20)   NULL,
    MaLichTruc    VARCHAR(20)   NOT NULL,
    LoaiDon       NVARCHAR(30)  NOT NULL,
    LyDo          NVARCHAR(255) NOT NULL,
    ThoiDiemGui   DATETIME      NOT NULL DEFAULT GETDATE(),
    ThoiDiemDuyet DATETIME      NULL,
    TrangThai     NVARCHAR(30)  NOT NULL DEFAULT N'Chờ duyệt',

    CONSTRAINT PK_DON_DOI_CA PRIMARY KEY (MaDon),
    CONSTRAINT FK_DON_NGUOI_GUI
        FOREIGN KEY (MaNguoiGui) REFERENCES NGUOI_DUNG (MaNguoiDung),
    CONSTRAINT FK_DON_NGUOI_DUYET
        FOREIGN KEY (MaNguoiDuyet) REFERENCES NGUOI_DUNG (MaNguoiDung),
    CONSTRAINT FK_DON_LICH_TRUC
        FOREIGN KEY (MaLichTruc) REFERENCES LICH_TRUC (MaLichTruc),
    CONSTRAINT CK_DON_LOAI
        CHECK (LoaiDon IN (N'Đổi ca', N'Nghỉ phép')),
    CONSTRAINT CK_DON_NGUOI_KHAC
        CHECK (MaNguoiDuyet IS NULL OR MaNguoiDuyet <> MaNguoiGui),
    CONSTRAINT CK_DON_TRANGTHAI
        CHECK (TrangThai IN (N'Chờ duyệt', N'Đã duyệt', N'Từ chối', N'Đã hủy'))
);
GO


/* =========================================================================
   PHẦN 2. DỮ LIỆU MẪU
   Mật khẩu của mọi tài khoản mẫu: 123456 (lưu dạng băm SHA-256)
   ========================================================================= */
INSERT INTO NGUOI_DUNG (MaNguoiDung, HoTen, TenDangNhap, MatKhauHash, VaiTro) VALUES
('NV001', N'Nguyễn Văn An',  'an',    CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', N'123456'), 2), 'NHAN_VIEN_TRUC'),
('NV002', N'Trần Thị Bình',  'binh',  CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', N'123456'), 2), 'NHAN_VIEN_TRUC'),
('NV003', N'Lê Văn Cường',   'cuong', CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', N'123456'), 2), 'NHAN_VIEN_TRUC'),
('TC001', N'Phạm Thị Dung',  'dung',  CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', N'123456'), 2), 'TRUONG_CA'),
('QL001', N'Hoàng Văn Em',   'em',    CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', N'123456'), 2), 'QUAN_LY');
GO

INSERT INTO CA (MaCa, TenCa, GioBatDau, GioKetThuc, TuyChinhGio) VALUES
('CA01', N'Ca sáng',  '06:00', '14:00', 0),
('CA02', N'Ca chiều', '14:00', '22:00', 0),
('CA03', N'Ca đêm',   '22:00', '06:00', 0),
('CA04', N'Ca gãy',   '00:00', '00:00', 1);   -- giờ thật nằm ở LICH_TRUC.GioBatDauTuyChinh / GioKetThucTuyChinh
GO

INSERT INTO VI_TRI (MaViTri, TenViTri, MoTa) VALUES
('VT01', N'Phòng điều khiển', N'Giám sát và điều phối hệ thống chính'),
('VT02', N'Giám sát mạng',    N'Theo dõi tình trạng mạng và máy chủ'),
('VT03', N'Hỗ trợ kỹ thuật',  N'Tiếp nhận và xử lý yêu cầu kỹ thuật');
GO

-- Các dữ liệu phụ thuộc ngày dùng chung một batch để tính theo ngày hiện tại
DECLARE @Hom DATE = CAST(GETDATE() AS DATE);
DECLARE @Qua DATE = DATEADD(DAY, -1, @Hom);
DECLARE @Sau DATE = DATEADD(DAY, 3, @Hom);

INSERT INTO LICH_TRUC (MaLichTruc, MaNguoiDung, MaCa, MaViTri, NgayTruc, TrangThai) VALUES
('LT001', 'NV001', 'CA01', 'VT01', @Qua, N'Đã kết thúc'),
('LT002', 'NV002', 'CA02', 'VT01', @Qua, N'Đã kết thúc'),
('LT003', 'NV001', 'CA01', 'VT01', @Hom, N'Chờ kích hoạt'),
('LT004', 'NV002', 'CA02', 'VT01', @Hom, N'Chờ kích hoạt'),
('LT005', 'NV003', 'CA01', 'VT02', @Hom, N'Chờ kích hoạt'),
('LT006', 'NV003', 'CA01', 'VT01', @Sau, N'Chờ kích hoạt');

-- Điểm danh ngày hôm qua: LT001 đi trễ 5 phút, LT002 đúng giờ nhưng về sớm
INSERT INTO DIEM_DANH (MaDiemDanh, MaLichTruc, GioCheckIn, GioCheckOut, TrangThai) VALUES
('DD_LT001', 'LT001',
    DATEADD(MINUTE, 6 * 60 + 5,  CAST(@Qua AS DATETIME)),
    DATEADD(MINUTE, 14 * 60,     CAST(@Qua AS DATETIME)), N'Đi trễ'),
('DD_LT002', 'LT002',
    DATEADD(MINUTE, 13 * 60 + 50, CAST(@Qua AS DATETIME)),
    DATEADD(MINUTE, 21 * 60 + 40, CAST(@Qua AS DATETIME)), N'Về sớm');

INSERT INTO NHAT_KY (MaNhatKy, MaLichTruc, LoaiNhatKy, MucDo, NoiDung, TrangThai, ThoiGianGhi) VALUES
('NK001', 'LT001', N'Sự cố',   N'Cao',  N'Máy chủ báo lỗi kết nối cơ sở dữ liệu, đã khởi động lại nhưng chưa ổn định.', N'Đang xử lý',
    DATEADD(MINUTE, 10 * 60, CAST(@Qua AS DATETIME))),
('NK002', 'LT001', N'Vận hành', NULL,    N'Kiểm tra định kỳ hệ thống làm mát, hoạt động bình thường.',                  N'Đã xử lý',
    DATEADD(MINUTE, 8 * 60,  CAST(@Qua AS DATETIME)));

-- Biên bản bàn giao từ ca sáng (LT001) sang ca chiều (LT002), đã khóa
INSERT INTO BAN_GIAO (MaBanGiao, MaLichTrucGiao, MaLichTrucNhan, NoiDungTongKet,
                      ThoiDiemGui, ThoiDiemNhanCa, TrangThai, MaNguoiXacNhan) VALUES
('BG001', 'LT001', 'LT002', N'Hệ thống ổn định, còn một sự cố máy chủ cần theo dõi tiếp.',
    DATEADD(MINUTE, 13 * 60 + 55, CAST(@Qua AS DATETIME)),
    DATEADD(MINUTE, 14 * 60 + 2,  CAST(@Qua AS DATETIME)),
    N'Đã khóa', 'NV002');

INSERT INTO TON_DONG (MaTonDong, MaBanGiao, MaNhatKy, GhiChu, TrangThai) VALUES
('TD_NK001', 'BG001', 'NK001', N'Theo dõi tiếp lỗi kết nối máy chủ cơ sở dữ liệu.', N'Chưa xử lý');

-- Đơn nghỉ phép đang chờ duyệt
INSERT INTO DON_DOI_CA (MaDon, MaNguoiGui, MaLichTruc, LoaiDon, LyDo) VALUES
('DD001', 'NV003', 'LT006', N'Nghỉ phép', N'Việc gia đình đột xuất.');
GO


/* =========================================================================
   PHẦN 3. VIEW
   ========================================================================= */

/* View 1: Lịch trực chi tiết, có tính sẵn thời điểm bắt đầu/kết thúc thực tế
   (xử lý cả ca đêm vắt qua nửa đêm; ca gãy lấy giờ tùy chỉnh của từng lịch) */
CREATE VIEW v_LichTrucChiTiet
AS
SELECT
    l.MaLichTruc,
    l.NgayTruc,
    l.MaNguoiDung,
    nd.HoTen,
    c.MaCa,
    c.TenCa,
    vt.MaViTri,
    vt.TenViTri,
    l.TrangThai AS TrangThaiLich,
    DATEADD(SECOND, DATEDIFF(SECOND, 0, CAST(ISNULL(l.GioBatDauTuyChinh, c.GioBatDau) AS DATETIME)),
            CAST(l.NgayTruc AS DATETIME)) AS ThoiGianBatDau,
    DATEADD(DAY, CASE WHEN ISNULL(l.GioKetThucTuyChinh, c.GioKetThuc) <= ISNULL(l.GioBatDauTuyChinh, c.GioBatDau) THEN 1 ELSE 0 END,
        DATEADD(SECOND, DATEDIFF(SECOND, 0, CAST(ISNULL(l.GioKetThucTuyChinh, c.GioKetThuc) AS DATETIME)),
                CAST(l.NgayTruc AS DATETIME))) AS ThoiGianKetThuc
FROM LICH_TRUC l
JOIN NGUOI_DUNG nd ON nd.MaNguoiDung = l.MaNguoiDung
JOIN CA c          ON c.MaCa = l.MaCa
JOIN VI_TRI vt     ON vt.MaViTri = l.MaViTri;
GO

/* View 2: Điểm danh chi tiết (cho FrmDiemDanh) */
CREATE VIEW v_DiemDanhChiTiet
AS
SELECT
    l.MaLichTruc,
    l.NgayTruc,
    l.HoTen,
    l.TenCa,
    l.TenViTri,
    l.TrangThaiLich,
    dd.GioCheckIn,
    dd.GioCheckOut,
    ISNULL(dd.TrangThai, N'Chưa điểm danh') AS TrangThaiDiemDanh
FROM v_LichTrucChiTiet l
LEFT JOIN DIEM_DANH dd ON dd.MaLichTruc = l.MaLichTruc;
GO

/* View 3: Nhật ký và sự cố (cho tổng hợp nhật ký ca hiện tại) */
CREATE VIEW v_NhatKyChiTiet
AS
SELECT
    nk.MaNhatKy,
    nk.MaLichTruc,
    l.NgayTruc,
    l.TenCa,
    l.TenViTri,
    l.HoTen AS NguoiGhi,
    nk.LoaiNhatKy,
    nk.MucDo,
    nk.NoiDung,
    nk.TrangThai,
    nk.ThoiGianGhi
FROM NHAT_KY nk
JOIN v_LichTrucChiTiet l ON l.MaLichTruc = nk.MaLichTruc;
GO

/* View 4: Biên bản bàn giao chi tiết (cho FrmBanGiao) */
CREATE VIEW v_BanGiaoChiTiet
AS
SELECT
    bg.MaBanGiao,
    bg.MaLichTrucGiao,
    lg.NgayTruc      AS NgayCaGiao,
    lg.TenCa         AS CaGiao,
    lg.HoTen         AS NguoiGiao,
    bg.MaLichTrucNhan,
    ln.NgayTruc      AS NgayCaNhan,
    ln.TenCa         AS CaNhan,
    ln.HoTen         AS NguoiNhan,
    bg.NoiDungTongKet,
    bg.ThoiDiemGui,
    bg.ThoiDiemNhanCa,
    bg.TrangThai,
    nx.HoTen         AS NguoiXacNhan
FROM BAN_GIAO bg
JOIN v_LichTrucChiTiet lg ON lg.MaLichTruc = bg.MaLichTrucGiao
LEFT JOIN v_LichTrucChiTiet ln ON ln.MaLichTruc = bg.MaLichTrucNhan
LEFT JOIN NGUOI_DUNG nx ON nx.MaNguoiDung = bg.MaNguoiXacNhan;
GO

/* View 5: Công việc tồn đọng chưa xử lý (hiển thị bắt buộc ở ca kế tiếp - BR04) */
CREATE VIEW v_TonDongChuaXuLy
AS
SELECT
    td.MaTonDong,
    td.MaBanGiao,
    bg.MaLichTrucNhan,
    nk.MaNhatKy,
    nk.LoaiNhatKy,
    nk.MucDo,
    nk.NoiDung,
    td.GhiChu,
    td.TrangThai
FROM TON_DONG td
JOIN BAN_GIAO bg ON bg.MaBanGiao = td.MaBanGiao
JOIN NHAT_KY nk  ON nk.MaNhatKy = td.MaNhatKy
WHERE td.TrangThai <> N'Đã xử lý';
GO

/* View 6: Đơn đổi ca / nghỉ phép chi tiết (cho FrmDonDoiCa) */
CREATE VIEW v_DonDoiCaChiTiet
AS
SELECT
    d.MaDon,
    d.LoaiDon,
    d.LyDo,
    d.ThoiDiemGui,
    d.ThoiDiemDuyet,
    d.TrangThai,
    d.MaNguoiGui,
    gui.HoTen AS NguoiGui,
    d.MaNguoiDuyet,
    duyet.HoTen AS NguoiDuyet,
    d.MaLichTruc,
    l.NgayTruc,
    l.TenCa,
    l.TenViTri
FROM DON_DOI_CA d
JOIN NGUOI_DUNG gui ON gui.MaNguoiDung = d.MaNguoiGui
LEFT JOIN NGUOI_DUNG duyet ON duyet.MaNguoiDung = d.MaNguoiDuyet
JOIN v_LichTrucChiTiet l ON l.MaLichTruc = d.MaLichTruc;
GO

/* View 7: Thống kê chuyên cần theo nhân viên (cho FrmThongKe) */
CREATE VIEW v_ThongKeChuyenCan
AS
SELECT
    nd.MaNguoiDung,
    nd.HoTen,
    COUNT(l.MaLichTruc) AS TongSoCa,
    SUM(CASE WHEN dd.TrangThai = N'Đúng giờ' THEN 1 ELSE 0 END) AS SoCaDungGio,
    SUM(CASE WHEN dd.TrangThai = N'Đi trễ'   THEN 1 ELSE 0 END) AS SoCaDiTre,
    SUM(CASE WHEN dd.TrangThai = N'Về sớm'   THEN 1 ELSE 0 END) AS SoCaVeSom,
    SUM(CASE WHEN dd.TrangThai = N'Vắng'     THEN 1 ELSE 0 END) AS SoCaVang
FROM NGUOI_DUNG nd
LEFT JOIN LICH_TRUC l ON l.MaNguoiDung = nd.MaNguoiDung
                     AND l.TrangThai <> N'Đã hủy'
LEFT JOIN DIEM_DANH dd ON dd.MaLichTruc = l.MaLichTruc
WHERE nd.VaiTro = 'NHAN_VIEN_TRUC'
GROUP BY nd.MaNguoiDung, nd.HoTen;
GO


/* =========================================================================
   PHẦN 4. STORED PROCEDURE
   Quy ước: lỗi nghiệp vụ được báo bằng THROW (mã 50001–50099);
   ứng dụng C# bắt SqlException và hiển thị ex.Message.
   ========================================================================= */

/* SP1: Đăng nhập (FrmDangNhap). Trả về 1 dòng nếu đúng, 0 dòng nếu sai */
CREATE PROCEDURE usp_DangNhap
    @TenDangNhap VARCHAR(50),
    @MatKhau     NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT MaNguoiDung, HoTen, VaiTro
    FROM NGUOI_DUNG
    WHERE TenDangNhap = @TenDangNhap
      AND MatKhauHash = CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', @MatKhau), 2)
      AND TrangThai = N'Hoạt động';
END
GO

/* SP2: Tạo lịch trực - BR01 (UC02)
   Ca cố định (CA01..CA03): giờ lấy từ bảng CA.
   Ca gãy (CA.TuyChinhGio = 1): bắt buộc nhập @GioBatDau, @GioKetThuc.
   BR01 kiểm tra theo khoảng giờ: cùng vị trí hoặc cùng nhân viên không được chồng giờ. */
CREATE PROCEDURE usp_TaoLichTruc
    @MaLichTruc  VARCHAR(20),
    @MaNguoiDung VARCHAR(20),
    @MaCa        VARCHAR(20),
    @MaViTri     VARCHAR(20),
    @NgayTruc    DATE,
    @GioBatDau   TIME = NULL,    -- chỉ dùng cho ca gãy
    @GioKetThuc  TIME = NULL     -- chỉ dùng cho ca gãy
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    DECLARE @TuyChinh BIT, @GioBD TIME, @GioKT TIME, @BD DATETIME, @KT DATETIME;

    IF NOT EXISTS (SELECT 1 FROM NGUOI_DUNG WHERE MaNguoiDung = @MaNguoiDung AND TrangThai = N'Hoạt động')
        THROW 50001, N'Nhân viên không tồn tại hoặc đã bị khóa.', 1;

    SELECT @TuyChinh = TuyChinhGio, @GioBD = GioBatDau, @GioKT = GioKetThuc
    FROM CA WHERE MaCa = @MaCa;

    IF @TuyChinh IS NULL
        THROW 50004, N'Ca trực không tồn tại.', 1;

    IF @TuyChinh = 1
    BEGIN
        IF @GioBatDau IS NULL OR @GioKetThuc IS NULL
            THROW 50005, N'Ca gãy phải nhập đủ giờ bắt đầu và giờ kết thúc.', 1;
        SET @GioBD = @GioBatDau;
        SET @GioKT = @GioKetThuc;
    END
    ELSE
    BEGIN
        -- Ca cố định không có giờ riêng
        SET @GioBatDau = NULL;
        SET @GioKetThuc = NULL;
    END

    -- Thời điểm bắt đầu/kết thúc thực tế (giờ kết thúc <= giờ bắt đầu nghĩa là qua nửa đêm)
    SET @BD = DATEADD(SECOND, DATEDIFF(SECOND, 0, CAST(@GioBD AS DATETIME)), CAST(@NgayTruc AS DATETIME));
    SET @KT = DATEADD(DAY, CASE WHEN @GioKT <= @GioBD THEN 1 ELSE 0 END,
              DATEADD(SECOND, DATEDIFF(SECOND, 0, CAST(@GioKT AS DATETIME)), CAST(@NgayTruc AS DATETIME)));

    IF @TuyChinh = 1 AND (@GioKT = @GioBD OR DATEDIFF(MINUTE, @BD, @KT) > 720)
        THROW 50006, N'Ca gãy: giờ kết thúc phải khác giờ bắt đầu và ca dài tối đa 12 giờ.', 1;

    -- BR01: vị trí đã có người trực trong khoảng giờ này
    IF EXISTS (SELECT 1 FROM v_LichTrucChiTiet
               WHERE MaViTri = @MaViTri AND TrangThaiLich <> N'Đã hủy'
                 AND ThoiGianBatDau < @KT AND ThoiGianKetThuc > @BD)
        THROW 50002, N'Trùng lịch (BR01): vị trí này đã có người được phân công trong khoảng giờ này.', 1;

    -- Một người không trực hai nơi trong cùng khoảng giờ
    IF EXISTS (SELECT 1 FROM v_LichTrucChiTiet
               WHERE MaNguoiDung = @MaNguoiDung AND TrangThaiLich <> N'Đã hủy'
                 AND ThoiGianBatDau < @KT AND ThoiGianKetThuc > @BD)
        THROW 50003, N'Trùng lịch (BR01): nhân viên đã có lịch trực trong khoảng giờ này.', 1;

    INSERT INTO LICH_TRUC (MaLichTruc, MaNguoiDung, MaCa, MaViTri, NgayTruc, GioBatDauTuyChinh, GioKetThucTuyChinh)
    VALUES (@MaLichTruc, @MaNguoiDung, @MaCa, @MaViTri, @NgayTruc, @GioBatDau, @GioKetThuc);
END
GO

/* SP3: Check-in - BR02, BR03, BR07 (UC03) */
CREATE PROCEDURE usp_CheckIn
    @MaLichTruc  VARCHAR(20),
    @MaNguoiDung VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    DECLARE @Now DATETIME = GETDATE();
    DECLARE @BatDau DATETIME, @KetThuc DATETIME;
    DECLARE @ChuLich VARCHAR(20), @TrangThaiLich NVARCHAR(30), @MaViTri VARCHAR(20);
    DECLARE @VaiTro VARCHAR(20), @MaLichTrucTruoc VARCHAR(20), @TrangThai NVARCHAR(30);

    SELECT @BatDau = ThoiGianBatDau, @KetThuc = ThoiGianKetThuc,
           @ChuLich = MaNguoiDung, @TrangThaiLich = TrangThaiLich, @MaViTri = MaViTri
    FROM v_LichTrucChiTiet
    WHERE MaLichTruc = @MaLichTruc;

    IF @BatDau IS NULL
        THROW 50010, N'Không tìm thấy lịch trực.', 1;

    SELECT @VaiTro = VaiTro FROM NGUOI_DUNG WHERE MaNguoiDung = @MaNguoiDung;

    -- BR07: chỉ thao tác trên ca của mình (Quản lý có toàn quyền)
    IF @ChuLich <> @MaNguoiDung AND ISNULL(@VaiTro, '') <> 'QUAN_LY'
        THROW 50011, N'Bạn chỉ được thao tác trên ca trực của mình (BR07).', 1;

    IF @TrangThaiLich IN (N'Đã hủy', N'Đã kết thúc')
        THROW 50012, N'Lịch trực đã hủy hoặc đã kết thúc, không thể check-in.', 1;

    IF EXISTS (SELECT 1 FROM DIEM_DANH WHERE MaLichTruc = @MaLichTruc AND GioCheckIn IS NOT NULL)
        THROW 50013, N'Ca trực này đã check-in.', 1;

    -- BR02: chỉ được check-in sớm tối đa 30 phút
    IF @Now < DATEADD(MINUTE, -30, @BatDau)
        THROW 50014, N'Chưa đến giờ check-in: chỉ được check-in sớm tối đa 30 phút (BR02).', 1;

    IF @Now > @KetThuc
        THROW 50015, N'Ca trực đã kết thúc, không thể check-in.', 1;

    -- BR03: ca liền trước tại cùng vị trí phải có biên bản bàn giao
    SELECT TOP 1 @MaLichTrucTruoc = MaLichTruc
    FROM v_LichTrucChiTiet
    WHERE MaViTri = @MaViTri
      AND ThoiGianKetThuc = @BatDau
      AND TrangThaiLich <> N'Đã hủy'
      AND MaLichTruc <> @MaLichTruc;

    IF @MaLichTrucTruoc IS NOT NULL
       AND NOT EXISTS (SELECT 1 FROM BAN_GIAO WHERE MaLichTrucGiao = @MaLichTrucTruoc)
        THROW 50016, N'Ca trước chưa gửi biên bản bàn giao, chưa thể nhận ca (BR03).', 1;

    -- BR02: sau giờ bắt đầu là "Đi trễ"
    SET @TrangThai = CASE WHEN @Now > @BatDau THEN N'Đi trễ' ELSE N'Đúng giờ' END;

    BEGIN TRY
        BEGIN TRANSACTION;

        IF EXISTS (SELECT 1 FROM DIEM_DANH WHERE MaLichTruc = @MaLichTruc)
            UPDATE DIEM_DANH
            SET GioCheckIn = @Now, TrangThai = @TrangThai
            WHERE MaLichTruc = @MaLichTruc;
        ELSE
            INSERT INTO DIEM_DANH (MaDiemDanh, MaLichTruc, GioCheckIn, TrangThai)
            VALUES (LEFT('DD_' + @MaLichTruc, 20), @MaLichTruc, @Now, @TrangThai);

        UPDATE LICH_TRUC SET TrangThai = N'Đang diễn ra' WHERE MaLichTruc = @MaLichTruc;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH

    SELECT @TrangThai AS TrangThaiDiemDanh, @Now AS GioCheckIn;
END
GO

/* SP4: Check-out - BR08 (UC04) */
CREATE PROCEDURE usp_CheckOut
    @MaLichTruc  VARCHAR(20),
    @MaNguoiDung VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    DECLARE @Now DATETIME = GETDATE();
    DECLARE @KetThuc DATETIME, @ChuLich VARCHAR(20), @VaiTro VARCHAR(20);
    DECLARE @GioCheckIn DATETIME, @GioCheckOut DATETIME, @TrangThai NVARCHAR(30);

    SELECT @KetThuc = ThoiGianKetThuc, @ChuLich = MaNguoiDung
    FROM v_LichTrucChiTiet
    WHERE MaLichTruc = @MaLichTruc;

    IF @KetThuc IS NULL
        THROW 50020, N'Không tìm thấy lịch trực.', 1;

    SELECT @VaiTro = VaiTro FROM NGUOI_DUNG WHERE MaNguoiDung = @MaNguoiDung;

    IF @ChuLich <> @MaNguoiDung AND ISNULL(@VaiTro, '') <> 'QUAN_LY'
        THROW 50021, N'Bạn chỉ được thao tác trên ca trực của mình (BR07).', 1;

    SELECT @GioCheckIn = GioCheckIn, @GioCheckOut = GioCheckOut, @TrangThai = TrangThai
    FROM DIEM_DANH
    WHERE MaLichTruc = @MaLichTruc;

    IF @GioCheckIn IS NULL
        THROW 50022, N'Chưa check-in nên không thể check-out.', 1;

    IF @GioCheckOut IS NOT NULL
        THROW 50023, N'Ca trực này đã check-out.', 1;

    -- BR08: check-out trước giờ kết thúc là "Về sớm"
    IF @Now < @KetThuc
        SET @TrangThai = N'Về sớm';

    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE DIEM_DANH
        SET GioCheckOut = @Now, TrangThai = @TrangThai
        WHERE MaLichTruc = @MaLichTruc;

        UPDATE LICH_TRUC SET TrangThai = N'Đã kết thúc' WHERE MaLichTruc = @MaLichTruc;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH

    SELECT @TrangThai AS TrangThaiDiemDanh, @Now AS GioCheckOut;
END
GO

/* SP5: Ghi nhật ký / sự cố (UC08) */
CREATE PROCEDURE usp_GhiNhatKy
    @MaNhatKy    VARCHAR(20),
    @MaLichTruc  VARCHAR(20),
    @MaNguoiDung VARCHAR(20),
    @LoaiNhatKy  NVARCHAR(30),
    @MucDo       NVARCHAR(20) = NULL,
    @NoiDung     NVARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    DECLARE @ChuLich VARCHAR(20), @TrangThaiLich NVARCHAR(30), @VaiTro VARCHAR(20);

    SELECT @ChuLich = MaNguoiDung, @TrangThaiLich = TrangThaiLich
    FROM v_LichTrucChiTiet
    WHERE MaLichTruc = @MaLichTruc;

    IF @ChuLich IS NULL
        THROW 50030, N'Không tìm thấy lịch trực.', 1;

    SELECT @VaiTro = VaiTro FROM NGUOI_DUNG WHERE MaNguoiDung = @MaNguoiDung;

    IF @ChuLich <> @MaNguoiDung AND ISNULL(@VaiTro, '') <> 'QUAN_LY'
        THROW 50031, N'Bạn chỉ được ghi nhật ký trên ca trực của mình (BR07).', 1;

    IF @TrangThaiLich <> N'Đang diễn ra'
        THROW 50032, N'Chỉ được ghi nhật ký khi ca đang diễn ra (cần check-in trước).', 1;

    IF @LoaiNhatKy = N'Sự cố' AND @MucDo IS NULL
        THROW 50033, N'Sự cố phải có mức độ.', 1;

    INSERT INTO NHAT_KY (MaNhatKy, MaLichTruc, LoaiNhatKy, MucDo, NoiDung)
    VALUES (@MaNhatKy, @MaLichTruc, @LoaiNhatKy, @MucDo, @NoiDung);
END
GO

/* SP6: Lập biên bản bàn giao và tự kế thừa việc tồn đọng - BR04 (UC05, UC06) */
CREATE PROCEDURE usp_LapBienBan
    @MaBanGiao      VARCHAR(20),
    @MaLichTrucGiao VARCHAR(20),
    @MaNguoiDung    VARCHAR(20),
    @NoiDungTongKet NVARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    DECLARE @ChuLich VARCHAR(20), @TrangThaiLich NVARCHAR(30), @VaiTro VARCHAR(20);

    SELECT @ChuLich = MaNguoiDung, @TrangThaiLich = TrangThaiLich
    FROM v_LichTrucChiTiet
    WHERE MaLichTruc = @MaLichTrucGiao;

    IF @ChuLich IS NULL
        THROW 50040, N'Không tìm thấy lịch trực của ca giao.', 1;

    SELECT @VaiTro = VaiTro FROM NGUOI_DUNG WHERE MaNguoiDung = @MaNguoiDung;

    IF @ChuLich <> @MaNguoiDung AND ISNULL(@VaiTro, '') <> 'QUAN_LY'
        THROW 50041, N'Bạn chỉ được lập biên bản cho ca trực của mình (BR07).', 1;

    IF @TrangThaiLich = N'Đã hủy'
        THROW 50042, N'Lịch trực đã hủy, không thể lập biên bản.', 1;

    IF EXISTS (SELECT 1 FROM BAN_GIAO WHERE MaLichTrucGiao = @MaLichTrucGiao)
        THROW 50043, N'Ca trực này đã có biên bản bàn giao.', 1;

    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO BAN_GIAO (MaBanGiao, MaLichTrucGiao, NoiDungTongKet)
        VALUES (@MaBanGiao, @MaLichTrucGiao, @NoiDungTongKet);

        -- BR04: nhật ký/sự cố chưa xử lý xong tự động thành "Công việc tồn đọng"
        INSERT INTO TON_DONG (MaTonDong, MaBanGiao, MaNhatKy, GhiChu, TrangThai)
        SELECT LEFT('TD_' + nk.MaNhatKy, 20),
               @MaBanGiao,
               nk.MaNhatKy,
               CAST(nk.NoiDung AS NVARCHAR(255)),
               nk.TrangThai
        FROM NHAT_KY nk
        WHERE nk.MaLichTruc = @MaLichTrucGiao
          AND nk.TrangThai <> N'Đã xử lý';

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH

    SELECT COUNT(*) AS SoViecTonDong FROM TON_DONG WHERE MaBanGiao = @MaBanGiao;
END
GO

/* SP7: Xác nhận bàn giao và khóa biên bản - BR05 (UC07) */
CREATE PROCEDURE usp_XacNhanBanGiao
    @MaBanGiao      VARCHAR(20),
    @MaLichTrucNhan VARCHAR(20),
    @MaNguoiXacNhan VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    DECLARE @TrangThai NVARCHAR(30), @ChuLichNhan VARCHAR(20), @VaiTro VARCHAR(20);

    SELECT @TrangThai = TrangThai FROM BAN_GIAO WHERE MaBanGiao = @MaBanGiao;

    IF @TrangThai IS NULL
        THROW 50050, N'Không tìm thấy biên bản bàn giao.', 1;

    IF @TrangThai <> N'Chờ xác nhận'
        THROW 50051, N'Biên bản không ở trạng thái chờ xác nhận (có thể đã khóa hoặc đã hủy).', 1;

    SELECT @ChuLichNhan = MaNguoiDung FROM LICH_TRUC WHERE MaLichTruc = @MaLichTrucNhan;

    IF @ChuLichNhan IS NULL
        THROW 50052, N'Không tìm thấy lịch trực của ca nhận.', 1;

    SELECT @VaiTro = VaiTro FROM NGUOI_DUNG WHERE MaNguoiDung = @MaNguoiXacNhan;

    -- Người xác nhận phải là người nhận ca hoặc Trưởng ca / Quản lý
    IF @ChuLichNhan <> @MaNguoiXacNhan AND ISNULL(@VaiTro, '') NOT IN ('TRUONG_CA', 'QUAN_LY')
        THROW 50053, N'Chỉ người nhận ca hoặc Trưởng ca / Quản lý mới được xác nhận biên bản.', 1;

    -- Cập nhật một lần: Chờ xác nhận -> Đã khóa (BR05)
    UPDATE BAN_GIAO
    SET MaLichTrucNhan = @MaLichTrucNhan,
        MaNguoiXacNhan = @MaNguoiXacNhan,
        ThoiDiemNhanCa = GETDATE(),
        TrangThai      = N'Đã khóa'
    WHERE MaBanGiao = @MaBanGiao;
END
GO

/* SP8: Gửi đơn đổi ca / nghỉ phép - BR06, BR07 (UC09) */
CREATE PROCEDURE usp_GuiDon
    @MaDon           VARCHAR(20),
    @MaNguoiGui      VARCHAR(20),
    @MaLichTruc      VARCHAR(20),
    @LoaiDon         NVARCHAR(30),
    @LyDo            NVARCHAR(255),
    @SoGioToiThieu   INT = 24          -- hạn gửi đơn: trước giờ bắt đầu ca tối thiểu 24 giờ
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    DECLARE @ChuLich VARCHAR(20), @BatDau DATETIME, @TrangThaiLich NVARCHAR(30);

    SELECT @ChuLich = MaNguoiDung, @BatDau = ThoiGianBatDau, @TrangThaiLich = TrangThaiLich
    FROM v_LichTrucChiTiet
    WHERE MaLichTruc = @MaLichTruc;

    IF @ChuLich IS NULL
        THROW 50060, N'Không tìm thấy lịch trực.', 1;

    IF @ChuLich <> @MaNguoiGui
        THROW 50061, N'Bạn chỉ được gửi đơn cho ca trực của mình (BR07).', 1;

    IF @TrangThaiLich <> N'Chờ kích hoạt'
        THROW 50062, N'Chỉ được gửi đơn cho ca chưa bắt đầu.', 1;

    -- BR06: phải gửi trước hạn quy định
    IF GETDATE() > DATEADD(HOUR, -@SoGioToiThieu, @BatDau)
        THROW 50063, N'Đã quá hạn gửi đơn theo quy định (BR06).', 1;

    IF EXISTS (SELECT 1 FROM DON_DOI_CA WHERE MaLichTruc = @MaLichTruc AND TrangThai = N'Chờ duyệt')
        THROW 50064, N'Ca trực này đã có đơn đang chờ duyệt.', 1;

    INSERT INTO DON_DOI_CA (MaDon, MaNguoiGui, MaLichTruc, LoaiDon, LyDo)
    VALUES (@MaDon, @MaNguoiGui, @MaLichTruc, @LoaiDon, @LyDo);
END
GO

/* SP9: Phê duyệt / từ chối đơn - BR06 (UC10) */
CREATE PROCEDURE usp_DuyetDon
    @MaDon        VARCHAR(20),
    @MaNguoiDuyet VARCHAR(20),
    @KetQua       NVARCHAR(30)      -- N'Đã duyệt' hoặc N'Từ chối'
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    DECLARE @TrangThai NVARCHAR(30), @MaNguoiGui VARCHAR(20), @MaLichTruc VARCHAR(20), @VaiTro VARCHAR(20);

    IF @KetQua NOT IN (N'Đã duyệt', N'Từ chối')
        THROW 50070, N'Kết quả phải là "Đã duyệt" hoặc "Từ chối".', 1;

    SELECT @TrangThai = TrangThai, @MaNguoiGui = MaNguoiGui, @MaLichTruc = MaLichTruc
    FROM DON_DOI_CA
    WHERE MaDon = @MaDon;

    IF @TrangThai IS NULL
        THROW 50071, N'Không tìm thấy đơn.', 1;

    IF @TrangThai <> N'Chờ duyệt'
        THROW 50072, N'Đơn không còn ở trạng thái chờ duyệt.', 1;

    SELECT @VaiTro = VaiTro FROM NGUOI_DUNG WHERE MaNguoiDung = @MaNguoiDuyet;

    IF ISNULL(@VaiTro, '') NOT IN ('TRUONG_CA', 'QUAN_LY')
        THROW 50073, N'Chỉ Trưởng ca / Quản lý mới được duyệt đơn (BR06).', 1;

    IF @MaNguoiDuyet = @MaNguoiGui
        THROW 50074, N'Người duyệt phải khác người gửi đơn.', 1;

    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE DON_DOI_CA
        SET TrangThai = @KetQua,
            MaNguoiDuyet = @MaNguoiDuyet,
            ThoiDiemDuyet = GETDATE()
        WHERE MaDon = @MaDon;

        -- Đơn được duyệt thì lịch trực gốc được hủy để phân công lại
        IF @KetQua = N'Đã duyệt'
            UPDATE LICH_TRUC SET TrangThai = N'Đã hủy' WHERE MaLichTruc = @MaLichTruc;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

/* SP10: Báo cáo thống kê (UC11, FrmThongKe) - trả về 3 bảng kết quả */
CREATE PROCEDURE usp_BaoCaoThongKe
    @TuNgay  DATE,
    @DenNgay DATE
AS
BEGIN
    SET NOCOUNT ON;

    -- 1) Chuyên cần theo nhân viên trong khoảng thời gian
    SELECT nd.MaNguoiDung,
           nd.HoTen,
           COUNT(l.MaLichTruc) AS TongSoCa,
           SUM(CASE WHEN dd.TrangThai = N'Đúng giờ' THEN 1 ELSE 0 END) AS SoCaDungGio,
           SUM(CASE WHEN dd.TrangThai = N'Đi trễ'   THEN 1 ELSE 0 END) AS SoCaDiTre,
           SUM(CASE WHEN dd.TrangThai = N'Về sớm'   THEN 1 ELSE 0 END) AS SoCaVeSom,
           SUM(CASE WHEN dd.TrangThai = N'Vắng'     THEN 1 ELSE 0 END) AS SoCaVang
    FROM NGUOI_DUNG nd
    LEFT JOIN LICH_TRUC l ON l.MaNguoiDung = nd.MaNguoiDung
                         AND l.NgayTruc BETWEEN @TuNgay AND @DenNgay
                         AND l.TrangThai <> N'Đã hủy'
    LEFT JOIN DIEM_DANH dd ON dd.MaLichTruc = l.MaLichTruc
    WHERE nd.VaiTro = 'NHAN_VIEN_TRUC'
    GROUP BY nd.MaNguoiDung, nd.HoTen;

    -- 2) Số sự cố theo mức độ và trạng thái
    SELECT nk.MucDo,
           nk.TrangThai,
           COUNT(*) AS SoLuong
    FROM NHAT_KY nk
    JOIN LICH_TRUC l ON l.MaLichTruc = nk.MaLichTruc
    WHERE nk.LoaiNhatKy = N'Sự cố'
      AND l.NgayTruc BETWEEN @TuNgay AND @DenNgay
    GROUP BY nk.MucDo, nk.TrangThai;

    -- 3) Biên bản bàn giao và công việc tồn đọng
    SELECT
        (SELECT COUNT(*) FROM BAN_GIAO bg
           JOIN LICH_TRUC l ON l.MaLichTruc = bg.MaLichTrucGiao
          WHERE l.NgayTruc BETWEEN @TuNgay AND @DenNgay
            AND bg.TrangThai = N'Đã khóa')  AS SoBienBanDaKhoa,
        (SELECT COUNT(*) FROM BAN_GIAO bg
           JOIN LICH_TRUC l ON l.MaLichTruc = bg.MaLichTrucGiao
          WHERE l.NgayTruc BETWEEN @TuNgay AND @DenNgay
            AND bg.TrangThai = N'Chờ xác nhận') AS SoBienBanChoXacNhan,
        (SELECT COUNT(*) FROM TON_DONG WHERE TrangThai <> N'Đã xử lý') AS SoTonDongChuaXuLy;
END
GO


/* =========================================================================
   PHẦN 5. TRIGGER
   ========================================================================= */

/* Trigger 1 - BR05: chặn sửa biên bản đã khóa */
CREATE TRIGGER TR_BAN_GIAO_CHAN_SUA
ON BAN_GIAO
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- deleted chứa dữ liệu cũ: nếu bản ghi cũ đã "Đã khóa" thì không cho sửa
    IF EXISTS (SELECT 1 FROM deleted WHERE TrangThai = N'Đã khóa')
    BEGIN
        ROLLBACK TRANSACTION;
        THROW 50090, N'Biên bản đã khóa, không được sửa (BR05).', 1;
    END
END
GO

/* Trigger 2 - BR05: chặn xóa biên bản đã khóa */
CREATE TRIGGER TR_BAN_GIAO_CHAN_XOA
ON BAN_GIAO
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM deleted WHERE TrangThai = N'Đã khóa')
        THROW 50091, N'Biên bản đã khóa, không được xóa (BR05).', 1;

    DELETE b
    FROM BAN_GIAO b
    JOIN deleted d ON d.MaBanGiao = b.MaBanGiao;
END
GO

/* Trigger 3 - BR05: không thêm công việc tồn đọng vào biên bản đã khóa */
CREATE TRIGGER TR_TON_DONG_CHAN_THEM
ON TON_DONG
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1
               FROM inserted i
               JOIN BAN_GIAO bg ON bg.MaBanGiao = i.MaBanGiao
               WHERE bg.TrangThai = N'Đã khóa')
    BEGIN
        ROLLBACK TRANSACTION;
        THROW 50092, N'Biên bản đã khóa, không được thêm công việc tồn đọng (BR05).', 1;
    END
END
GO

/* Trigger 4: không sửa nội dung / xóa nhật ký của ca đã có biên bản khóa.
   Cho phép cập nhật trạng thái xử lý (ca sau xử lý xong sự cố). */
CREATE TRIGGER TR_NHAT_KY_BAO_VE
ON NHAT_KY
AFTER UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    -- Trường hợp UPDATE: chỉ kiểm tra khi có thay đổi nội dung hoặc loại nhật ký
    IF EXISTS (SELECT 1 FROM inserted)
       AND NOT (UPDATE(NoiDung) OR UPDATE(LoaiNhatKy) OR UPDATE(MucDo))
        RETURN;

    IF EXISTS (SELECT 1
               FROM deleted d
               JOIN BAN_GIAO bg ON bg.MaLichTrucGiao = d.MaLichTruc
               WHERE bg.TrangThai = N'Đã khóa')
    BEGIN
        ROLLBACK TRANSACTION;
        THROW 50093, N'Nhật ký thuộc ca đã có biên bản khóa, không được sửa nội dung hoặc xóa (BR05).', 1;
    END
END
GO

/* Trigger 5: tự ghi thời điểm duyệt khi đơn chuyển sang Đã duyệt / Từ chối */
CREATE TRIGGER TR_DON_DOI_CA_GHI_THOI_DIEM_DUYET
ON DON_DOI_CA
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT UPDATE(TrangThai) RETURN;

    UPDATE d
    SET ThoiDiemDuyet = GETDATE()
    FROM DON_DOI_CA d
    JOIN inserted i ON i.MaDon = d.MaDon
    WHERE i.TrangThai IN (N'Đã duyệt', N'Từ chối')
      AND d.ThoiDiemDuyet IS NULL;
END
GO


/* =========================================================================
   PHẦN 6. VÍ DỤ GỌI THỬ (bỏ comment từng dòng để chạy)
   ========================================================================= */
-- Đăng nhập
-- EXEC usp_DangNhap 'an', N'123456';

-- Xem các view
-- SELECT * FROM v_LichTrucChiTiet;
-- SELECT * FROM v_BanGiaoChiTiet;
-- SELECT * FROM v_TonDongChuaXuLy;
-- SELECT * FROM v_ThongKeChuyenCan;

-- Tạo lịch (thử BR01: trùng vị trí/ca/ngày sẽ báo lỗi)
-- EXEC usp_TaoLichTruc 'LT100', 'NV002', 'CA02', 'VT02', '2026-11-01';
-- Ca gãy: nhập giờ riêng (07:00 - 11:00 tại Hỗ trợ kỹ thuật)
-- EXEC usp_TaoLichTruc 'LT101', 'NV003', 'CA04', 'VT03', '2026-11-01', '07:00', '11:00';

-- Check-in / Check-out (phải đúng khung giờ của ca, xem BR02)
-- EXEC usp_CheckIn  'LT003', 'NV001';
-- EXEC usp_CheckOut 'LT003', 'NV001';

-- Lập biên bản và xác nhận
-- EXEC usp_LapBienBan 'BG002', 'LT003', 'NV001', N'Bàn giao ca sáng, hệ thống ổn định.';
-- EXEC usp_XacNhanBanGiao 'BG002', 'LT004', 'NV002';

-- Thử trigger BR05: phải báo lỗi vì BG001 đã khóa
-- UPDATE BAN_GIAO SET NoiDungTongKet = N'Sửa thử' WHERE MaBanGiao = 'BG001';
-- DELETE FROM BAN_GIAO WHERE MaBanGiao = 'BG001';

-- Đơn đổi ca / nghỉ phép
-- EXEC usp_GuiDon 'DD002', 'NV003', 'LT005', N'Nghỉ phép', N'Đi khám bệnh.';   -- thường báo quá hạn (BR06)
-- EXEC usp_DuyetDon 'DD001', 'TC001', N'Đã duyệt';

-- Báo cáo
-- EXEC usp_BaoCaoThongKe '2026-10-01', '2026-12-31';