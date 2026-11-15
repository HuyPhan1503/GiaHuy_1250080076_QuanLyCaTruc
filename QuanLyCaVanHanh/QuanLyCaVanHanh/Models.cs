namespace QuanLyCaVanHanh
{
    public static class VaiTro
    {
        public const string NhanVienTruc = "NHAN_VIEN_TRUC";
        public const string TruongCa = "TRUONG_CA";
        public const string QuanLy = "QUAN_LY";

        public static string TenHienThi(string vaiTro)
        {
            switch (vaiTro)
            {
                case NhanVienTruc: return "Nhân viên trực";
                case TruongCa: return "Trưởng ca";
                case QuanLy: return "Quản lý";
                default: return vaiTro;
            }
        }
    }

    public class NguoiDung
    {
        public string MaNguoiDung { get; set; }
        public string HoTen { get; set; }
        public string VaiTro { get; set; }
    }

    // Lưu người dùng đang đăng nhập, dùng chung cho mọi Form
    public static class PhienDangNhap
    {
        public static NguoiDung NguoiDung { get; set; }
    }
}