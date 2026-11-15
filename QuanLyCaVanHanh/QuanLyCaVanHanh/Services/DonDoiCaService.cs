using System;
using System.Data;
using QuanLyCaVanHanh.Data;

namespace QuanLyCaVanHanh.Services
{
    public static class DonDoiCaService
    {
        public static string SinhMaDon()
        {
            DataTable dt = DbHelper.Query("SELECT ISNULL(MAX(CAST(SUBSTRING(MaDon, 3, 10) AS INT)), 0) + 1 FROM DON_DOI_CA WHERE MaDon LIKE 'DD%'");
            int next = Convert.ToInt32(dt.Rows[0][0]);
            return "DD" + next.ToString("D3");
        }

        public static DataTable LayLichTrucChoKichHoat(string maNguoiDung)
        {
            string sql = "SELECT MaLichTruc, (TenCa + ' - ' + TenViTri + ' (' + CONVERT(VARCHAR(10), NgayTruc, 103) + ')') AS TenHienThi " +
                         "FROM v_LichTrucChiTiet " +
                         "WHERE MaNguoiDung = @MaNguoiDung AND TrangThaiLich = N'Chờ kích hoạt' AND NgayTruc >= CAST(GETDATE() AS DATE) " +
                         "ORDER BY NgayTruc, ThoiGianBatDau";
            return DbHelper.Query(sql, DbHelper.P("@MaNguoiDung", maNguoiDung));
        }

        public static DataTable LayDanhSachDon(string maNguoiDung, string vaiTro)
        {
            string sql;
            if (vaiTro == "NHAN_VIEN_TRUC")
            {
                sql = "SELECT MaDon, LoaiDon, NguoiGui, NgayTruc, TenCa, TenViTri, LyDo, ThoiDiemGui, TrangThai, NguoiDuyet, ThoiDiemDuyet, MaNguoiGui, MaNguoiDuyet, MaLichTruc " +
                      "FROM v_DonDoiCaChiTiet " +
                      "WHERE MaNguoiGui = @MaNguoiGui " +
                      "ORDER BY ThoiDiemGui DESC";
                return DbHelper.Query(sql, DbHelper.P("@MaNguoiGui", maNguoiDung));
            }
            else
            {
                sql = "SELECT MaDon, LoaiDon, NguoiGui, NgayTruc, TenCa, TenViTri, LyDo, ThoiDiemGui, TrangThai, NguoiDuyet, ThoiDiemDuyet, MaNguoiGui, MaNguoiDuyet, MaLichTruc " +
                      "FROM v_DonDoiCaChiTiet " +
                      "ORDER BY ThoiDiemGui DESC";
                return DbHelper.Query(sql);
            }
        }

        public static void GuiDon(string maNguoiGui, string maLichTruc, string loaiDon, string lyDo)
        {
            string maDon = SinhMaDon();
            DbHelper.CallProc("usp_GuiDon",
                DbHelper.P("@MaDon", maDon),
                DbHelper.P("@MaNguoiGui", maNguoiGui),
                DbHelper.P("@MaLichTruc", maLichTruc),
                DbHelper.P("@LoaiDon", loaiDon),
                DbHelper.P("@LyDo", lyDo),
                DbHelper.P("@SoGioToiThieu", 24)
            );
        }

        public static void DuyetDon(string maDon, string maNguoiDuyet, string ketQua)
        {
            DbHelper.CallProc("usp_DuyetDon",
                DbHelper.P("@MaDon", maDon),
                DbHelper.P("@MaNguoiDuyet", maNguoiDuyet),
                DbHelper.P("@KetQua", ketQua)
            );
        }
    }
}