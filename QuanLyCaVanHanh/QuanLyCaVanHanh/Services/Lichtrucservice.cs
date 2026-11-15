using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QuanLyCaVanHanh.Data;

namespace QuanLyCaVanHanh.Services
{
    public static class LichTrucService
    {
        // Lấy danh sách lịch trực trong khoảng ngày.
        // maNguoiDung = null: xem tất cả (Trưởng ca / Quản lý); khác null: chỉ xem lịch của người đó (BR07)
        public static DataTable LayDanhSach(DateTime tuNgay, DateTime denNgay, string maNguoiDung)
        {
            string sql =
                "SELECT MaLichTruc, NgayTruc, HoTen, TenCa, TenViTri, " +
                "       ThoiGianBatDau, ThoiGianKetThuc, TrangThaiLich " +
                "FROM v_LichTrucChiTiet " +
                "WHERE NgayTruc BETWEEN @Tu AND @Den";

            var ps = new List<SqlParameter>();
            ps.Add(DbHelper.P("@Tu", tuNgay.Date));
            ps.Add(DbHelper.P("@Den", denNgay.Date));

            if (maNguoiDung != null)
            {
                sql += " AND MaNguoiDung = @Nd";
                ps.Add(DbHelper.P("@Nd", maNguoiDung));
            }
            sql += " ORDER BY NgayTruc, ThoiGianBatDau, TenViTri";

            return DbHelper.Query(sql, ps.ToArray());
        }

        public static DataTable LayNhanVien()
        {
            return DbHelper.Query(
                "SELECT MaNguoiDung, HoTen FROM NGUOI_DUNG " +
                "WHERE VaiTro = 'NHAN_VIEN_TRUC' AND TrangThai = N'Hoạt động' ORDER BY HoTen");
        }

        public static DataTable LayCa()
        {
            return DbHelper.Query(
                "SELECT MaCa, TuyChinhGio, " +
                "       CASE WHEN TuyChinhGio = 1 THEN TenCa + N' (tự nhập giờ)' " +
                "            ELSE TenCa + N' (' + LEFT(CONVERT(VARCHAR(8), GioBatDau, 108), 5) + N' - ' " +
                "                 + LEFT(CONVERT(VARCHAR(8), GioKetThuc, 108), 5) + N')' END AS Ten " +
                "FROM CA ORDER BY TuyChinhGio, GioBatDau");
        }

        public static DataTable LayViTri()
        {
            return DbHelper.Query("SELECT MaViTri, TenViTri FROM VI_TRI ORDER BY MaViTri");
        }

        // Sinh mã lịch tiếp theo dạng LT001, LT002, ...
        private static string SinhMaLich()
        {
            DataTable dt = DbHelper.Query(
                "SELECT ISNULL(MAX(CAST(SUBSTRING(MaLichTruc, 3, 18) AS INT)), 0) + 1 " +
                "FROM LICH_TRUC " +
                "WHERE MaLichTruc LIKE 'LT[0-9]%' AND MaLichTruc NOT LIKE 'LT%[^0-9]%'");
            int so = Convert.ToInt32(dt.Rows[0][0]);
            return "LT" + so.ToString("D3");
        }

        // Phân công lịch trực (gọi usp_TaoLichTruc, BR01). Lỗi nghiệp vụ trả về dạng SqlException.
        // gioBatDau / gioKetThuc chỉ truyền khi là ca gãy (ca cố định để null).
        public static void TaoLichTruc(string maNguoiDung, string maCa, string maViTri, DateTime ngayTruc,
                                       TimeSpan? gioBatDau = null, TimeSpan? gioKetThuc = null)
        {
            DbHelper.CallProc("usp_TaoLichTruc",
                DbHelper.P("@MaLichTruc", SinhMaLich()),
                DbHelper.P("@MaNguoiDung", maNguoiDung),
                DbHelper.P("@MaCa", maCa),
                DbHelper.P("@MaViTri", maViTri),
                DbHelper.P("@NgayTruc", ngayTruc.Date),
                DbHelper.P("@GioBatDau", gioBatDau.HasValue ? (object)gioBatDau.Value : DBNull.Value),
                DbHelper.P("@GioKetThuc", gioKetThuc.HasValue ? (object)gioKetThuc.Value : DBNull.Value));
        }
    }
}