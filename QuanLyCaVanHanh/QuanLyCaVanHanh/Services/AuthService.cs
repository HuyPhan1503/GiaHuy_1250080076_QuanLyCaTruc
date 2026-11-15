using System.Data;
using QuanLyCaVanHanh.Data;

namespace QuanLyCaVanHanh.Services
{
    public static class AuthService
    {
        // Trả về người dùng nếu đúng, null nếu sai tên đăng nhập hoặc mật khẩu
        public static NguoiDung DangNhap(string tenDangNhap, string matKhau)
        {
            DataTable dt = DbHelper.CallProc("usp_DangNhap",
                DbHelper.P("@TenDangNhap", tenDangNhap),
                DbHelper.P("@MatKhau", matKhau));

            if (dt.Rows.Count == 0) return null;

            DataRow r = dt.Rows[0];
            return new NguoiDung
            {
                MaNguoiDung = r["MaNguoiDung"].ToString(),
                HoTen = r["HoTen"].ToString(),
                VaiTro = r["VaiTro"].ToString()
            };
        }
    }
}