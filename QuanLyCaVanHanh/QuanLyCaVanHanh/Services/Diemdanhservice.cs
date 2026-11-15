using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QuanLyCaVanHanh.Data;

namespace QuanLyCaVanHanh.Services
{
    public static class DiemDanhService
    {
        // Danh sách ca trực trong ngày kèm trạng thái điểm danh.
        // maNguoiDung = null: xem tất cả; khác null: chỉ ca của người đó
        public static DataTable LayDanhSach(DateTime ngay, string maNguoiDung)
        {
            string sql =
                "SELECT l.MaLichTruc, l.NgayTruc, l.HoTen, l.TenCa, l.TenViTri, " +
                "       l.ThoiGianBatDau, l.ThoiGianKetThuc, dd.GioCheckIn, dd.GioCheckOut, " +
                "       ISNULL(dd.TrangThai, N'Chưa điểm danh') AS TrangThaiDiemDanh, " +
                "       l.TrangThaiLich " +
                "FROM v_LichTrucChiTiet l " +
                "LEFT JOIN DIEM_DANH dd ON dd.MaLichTruc = l.MaLichTruc " +
                "WHERE l.NgayTruc = @Ngay AND l.TrangThaiLich <> N'Đã hủy'";

            var ps = new List<SqlParameter>();
            ps.Add(DbHelper.P("@Ngay", ngay.Date));

            if (maNguoiDung != null)
            {
                sql += " AND l.MaNguoiDung = @Nd";
                ps.Add(DbHelper.P("@Nd", maNguoiDung));
            }
            sql += " ORDER BY l.ThoiGianBatDau, l.TenViTri";

            return DbHelper.Query(sql, ps.ToArray());
        }

        // Check-in (BR02, BR03, BR07). Trả về 1 dòng: TrangThaiDiemDanh, GioCheckIn
        public static DataTable CheckIn(string maLichTruc, string maNguoiDung)
        {
            return DbHelper.CallProc("usp_CheckIn",
                DbHelper.P("@MaLichTruc", maLichTruc),
                DbHelper.P("@MaNguoiDung", maNguoiDung));
        }

        // Check-out (BR08). Trả về 1 dòng: TrangThaiDiemDanh, GioCheckOut
        public static DataTable CheckOut(string maLichTruc, string maNguoiDung)
        {
            return DbHelper.CallProc("usp_CheckOut",
                DbHelper.P("@MaLichTruc", maLichTruc),
                DbHelper.P("@MaNguoiDung", maNguoiDung));
        }
    }
}