using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using QuanLyCaVanHanh.Data;
using QuanLyCaVanHanh.Services;

namespace QuanLyCaVanHanh.Forms
{
    public partial class FrmDangNhap : Form
    {
        public FrmDangNhap()
        {
            InitializeComponent();
        }

        private void FrmDangNhap_Load(object sender, EventArgs e)
        {
            string loi;
            if (!DbHelper.KiemTraKetNoi(out loi))
            {
                MessageBox.Show("Không kết nối được cơ sở dữ liệu:\n" + loi +
                    "\n\nKiểm tra lại chuỗi kết nối trong App.config.",
                    "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string ten = txtTenDangNhap.Text.Trim();
            string mk = txtMatKhau.Text;

            if (ten == "" || mk == "")
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu.",
                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                NguoiDung nd = AuthService.DangNhap(ten, mk);
                if (nd == null)
                {
                    MessageBox.Show("Sai tên đăng nhập, mật khẩu hoặc tài khoản đã bị khóa.",
                        "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMatKhau.Clear();
                    txtMatKhau.Focus();
                    return;
                }

                PhienDangNhap.NguoiDung = nd;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Lỗi cơ sở dữ liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}