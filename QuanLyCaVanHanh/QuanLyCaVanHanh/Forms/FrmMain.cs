using System;
using System.Windows.Forms;

namespace QuanLyCaVanHanh.Forms
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            NguoiDung nd = PhienDangNhap.NguoiDung;
            lblNguoiDung.Text = "Người dùng: " + nd.HoTen + " (" + VaiTro.TenHienThi(nd.VaiTro) + ")";

            // Phân quyền menu: chỉ Trưởng ca / Quản lý được xem thống kê
            mnuThongKe.Visible = nd.VaiTro != VaiTro.NhanVienTruc;
        }

        // Mở một Form con trong khung chính, đóng các Form con đang mở
        private void MoFormCon(Form f)
        {
            foreach (Form c in MdiChildren) c.Close();
            f.MdiParent = this;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;
            f.Show();
        }

        private void ChuaCoForm(string ten)
        {
            MessageBox.Show("Chức năng " + ten + " đang được xây dựng.", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Các Form làm ở bước sau: thay ChuaCoForm(...) bằng MoFormCon(new FrmXxx());
        private void mnuLichTruc_Click(object sender, EventArgs e) { MoFormCon(new FrmLichTruc()); }
        private void mnuDiemDanh_Click(object sender, EventArgs e) { MoFormCon(new FrmDiemDanh()); }
        private void mnuBanGiao_Click(object sender, EventArgs e) { MoFormCon(new FrmBanGiao()); }
        private void mnuDonDoiCa_Click(object sender, EventArgs e) { MoFormCon(new FrmDonDoiCa()); }
        private void mnuThongKe_Click(object sender, EventArgs e) { MoFormCon(new FrmThongKe()); }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            PhienDangNhap.NguoiDung = null;
            Application.Restart();
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}