using System;
using System.Data;
using QuanLyCaVanHanh.Data;

namespace QuanLyCaVanHanh.Services
{
    public static class BanGiaoService
    {
        public static string SinhMaNhatKy()
        {
            DataTable dt = DbHelper.Query("SELECT ISNULL(MAX(CAST(SUBSTRING(MaNhatKy, 3, 10) AS INT)), 0) + 1 FROM NHAT_KY WHERE MaNhatKy LIKE 'NK%'");
            int next = Convert.ToInt32(dt.Rows[0][0]);
            return "NK" + next.ToString("D3");
        }

        public static string SinhMaBanGiao()
        {
            DataTable dt = DbHelper.Query("SELECT ISNULL(MAX(CAST(SUBSTRING(MaBanGiao, 3, 10) AS INT)), 0) + 1 FROM BAN_GIAO WHERE MaBanGiao LIKE 'BG%'");
            int next = Convert.ToInt32(dt.Rows[0][0]);
            return "BG" + next.ToString("D3");
        }

        public static DataTable LayCaTrucHomNay(string maNguoiDung, string vaiTro)
        {
            string sql;
            if (vaiTro == "QUAN_LY")
            {
                sql = "SELECT MaLichTruc, (TenCa + ' - ' + TenViTri + ' (' + HoTen + ')') AS TenHienThi, TrangThaiLich FROM v_LichTrucChiTiet WHERE NgayTruc = CAST(GETDATE() AS DATE) AND TrangThaiLich <> N'Đã hủy' ORDER BY ThoiGianBatDau";
                return DbHelper.Query(sql);
            }
            else
            {
                sql = "SELECT MaLichTruc, (TenCa + ' - ' + TenViTri + ' (' + HoTen + ')') AS TenHienThi, TrangThaiLich FROM v_LichTrucChiTiet WHERE MaNguoiDung = @MaNguoiDung AND NgayTruc = CAST(GETDATE() AS DATE) AND TrangThaiLich <> N'Đã hủy' ORDER BY ThoiGianBatDau";
                return DbHelper.Query(sql, DbHelper.P("@MaNguoiDung", maNguoiDung));
            }
        }

        public static DataTable LayCaNhanKhaDung()
        {
            string sql = "SELECT MaLichTruc, (TenCa + ' - ' + TenViTri + ' (' + HoTen + ' - ' + CONVERT(VARCHAR(10), NgayTruc, 103) + ')') AS TenHienThi FROM v_LichTrucChiTiet WHERE TrangThaiLich <> N'Đã hủy' AND NgayTruc >= CAST(GETDATE() AS DATE) ORDER BY NgayTruc, ThoiGianBatDau";
            return DbHelper.Query(sql);
        }

        public static DataTable LayNhatKyCa(string maLichTruc)
        {
            string sql = "SELECT MaNhatKy, LoaiNhatKy, MucDo, NoiDung, TrangThai, ThoiGianGhi, NguoiGhi FROM v_NhatKyChiTiet WHERE MaLichTruc = @MaLichTruc ORDER BY ThoiGianGhi DESC";
            return DbHelper.Query(sql, DbHelper.P("@MaLichTruc", maLichTruc));
        }

        public static void GhiNhatKy(string maLichTruc, string maNguoiDung, string loaiNhatKy, string mucDo, string noiDung)
        {
            string maNhatKy = SinhMaNhatKy();
            DbHelper.CallProc("usp_GhiNhatKy",
                DbHelper.P("@MaNhatKy", maNhatKy),
                DbHelper.P("@MaLichTruc", maLichTruc),
                DbHelper.P("@MaNguoiDung", maNguoiDung),
                DbHelper.P("@LoaiNhatKy", loaiNhatKy),
                DbHelper.P("@MucDo", string.IsNullOrEmpty(mucDo) ? (object)DBNull.Value : mucDo),
                DbHelper.P("@NoiDung", noiDung)
            );
        }

        public static int LapBienBan(string maLichTrucGiao, string maNguoiDung, string noiDungTongKet)
        {
            string maBanGiao = SinhMaBanGiao();
            DataTable dt = DbHelper.CallProc("usp_LapBienBan",
                DbHelper.P("@MaBanGiao", maBanGiao),
                DbHelper.P("@MaLichTrucGiao", maLichTrucGiao),
                DbHelper.P("@MaNguoiDung", maNguoiDung),
                DbHelper.P("@NoiDungTongKet", noiDungTongKet)
            );

            if (dt != null && dt.Rows.Count > 0 && dt.Columns.Contains("SoViecTonDong"))
            {
                return Convert.ToInt32(dt.Rows[0]["SoViecTonDong"]);
            }
            return 0;
        }

        public static DataTable LayDanhSachBanGiao()
        {
            string sql = "SELECT MaBanGiao, MaLichTrucGiao, NgayCaGiao, CaGiao, NguoiGiao, MaLichTrucNhan, NgayCaNhan, CaNhan, NguoiNhan, NoiDungTongKet, ThoiDiemGui, ThoiDiemNhanCa, TrangThai, NguoiXacNhan FROM v_BanGiaoChiTiet ORDER BY ThoiDiemGui DESC";
            return DbHelper.Query(sql);
        }

        public static DataTable LayDanhSachTonDong()
        {
            string sql = "SELECT MaTonDong, MaBanGiao, MaNhatKy, LoaiNhatKy, MucDo, NoiDung, GhiChu, TrangThai FROM v_TonDongChuaXuLy";
            return DbHelper.Query(sql);
        }

        public static void XacNhanBanGiao(string maBanGiao, string maLichTrucNhan, string maNguoiXacNhan)
        {
            DbHelper.CallProc("usp_XacNhanBanGiao",
                DbHelper.P("@MaBanGiao", maBanGiao),
                DbHelper.P("@MaLichTrucNhan", maLichTrucNhan),
                DbHelper.P("@MaNguoiXacNhan", maNguoiXacNhan)
            );
        }
    }
}