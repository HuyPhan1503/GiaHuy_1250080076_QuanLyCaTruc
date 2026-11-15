using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using QuanLyCaVanHanh.Services;

namespace QuanLyCaVanHanh.Forms
{
    public partial class FrmDiemDanh : Form
    {
        private readonly NguoiDung _nguoiDung = PhienDangNhap.NguoiDung;

        // Nhân viên chỉ thấy ca của mình; Trưởng ca / Quản lý thấy tất cả
        private string MaLoc
        {
            get { return _nguoiDung.VaiTro == VaiTro.NhanVienTruc ? _nguoiDung.MaNguoiDung : null; }
        }

        public FrmDiemDanh()
        {
            InitializeComponent();
        }

        private void FrmDiemDanh_Load(object sender, EventArgs e)
        {
            dtpNgay.Value = DateTime.Today;
            CapNhatDongHo();
            timerDongHo.Start();

            // Trưởng ca / Quản lý chỉ giám sát, không tự điểm danh
            if (_nguoiDung.VaiTro != VaiTro.NhanVienTruc)
            {
                btnCheckIn.Visible = false;
                btnCheckOut.Visible = false;
                lblGhiChu.Left = btnCheckIn.Left;
                lblGhiChu.Text = "Chế độ giám sát: bạn xem được điểm danh của toàn bộ ca trực. "
                               + "Việc check-in / check-out do nhân viên của từng ca tự thực hiện (BR07).";
            }

            NapDanhSach();
        }

        private void FrmDiemDanh_FormClosed(object sender, FormClosedEventArgs e)
        {
            timerDongHo.Stop();
        }

        private void timerDongHo_Tick(object sender, EventArgs e)
        {
            CapNhatDongHo();
        }

        private void CapNhatDongHo()
        {
            lblDongHo.Text = "Bây giờ: " + DateTime.Now.ToString("HH:mm:ss  dd/MM/yyyy");
        }

        private void NapDanhSach()
        {
            try
            {
                dgvDiemDanh.DataSource = DiemDanhService.LayDanhSach(dtpNgay.Value, MaLoc);
                DinhDangLuoi();
                CapNhatNut();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Lỗi cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DinhDangLuoi()
        {
            if (dgvDiemDanh.Columns.Count == 0) return;

            dgvDiemDanh.Columns["MaLichTruc"].HeaderText = "Mã lịch";
            dgvDiemDanh.Columns["NgayTruc"].HeaderText = "Ngày trực";
            dgvDiemDanh.Columns["NgayTruc"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvDiemDanh.Columns["HoTen"].HeaderText = "Nhân viên";
            dgvDiemDanh.Columns["TenCa"].HeaderText = "Ca";
            dgvDiemDanh.Columns["TenViTri"].HeaderText = "Vị trí";
            dgvDiemDanh.Columns["ThoiGianBatDau"].HeaderText = "Bắt đầu ca";
            dgvDiemDanh.Columns["ThoiGianBatDau"].DefaultCellStyle.Format = "HH:mm";
            dgvDiemDanh.Columns["ThoiGianKetThuc"].HeaderText = "Kết thúc ca";
            dgvDiemDanh.Columns["ThoiGianKetThuc"].DefaultCellStyle.Format = "HH:mm";
            dgvDiemDanh.Columns["GioCheckIn"].HeaderText = "Giờ check-in";
            dgvDiemDanh.Columns["GioCheckIn"].DefaultCellStyle.Format = "HH:mm:ss";
            dgvDiemDanh.Columns["GioCheckOut"].HeaderText = "Giờ check-out";
            dgvDiemDanh.Columns["GioCheckOut"].DefaultCellStyle.Format = "HH:mm:ss";
            dgvDiemDanh.Columns["TrangThaiDiemDanh"].HeaderText = "Điểm danh";
            dgvDiemDanh.Columns["TrangThaiLich"].HeaderText = "Trạng thái ca";
        }

        // Bật/tắt nút theo dòng đang chọn
        private void CapNhatNut()
        {
            DataGridViewRow row = dgvDiemDanh.CurrentRow;
            if (row == null)
            {
                btnCheckIn.Enabled = false;
                btnCheckOut.Enabled = false;
                return;
            }

            bool daCheckIn = row.Cells["GioCheckIn"].Value != DBNull.Value && row.Cells["GioCheckIn"].Value != null;
            bool daCheckOut = row.Cells["GioCheckOut"].Value != DBNull.Value && row.Cells["GioCheckOut"].Value != null;

            btnCheckIn.Enabled = !daCheckIn;
            btnCheckOut.Enabled = daCheckIn && !daCheckOut;
        }

        private string LayMaLichDangChon()
        {
            if (dgvDiemDanh.CurrentRow == null) return null;
            return dgvDiemDanh.CurrentRow.Cells["MaLichTruc"].Value.ToString();
        }

        private void dgvDiemDanh_SelectionChanged(object sender, EventArgs e)
        {
            CapNhatNut();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            NapDanhSach();
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            string ma = LayMaLichDangChon();
            if (ma == null)
            {
                MessageBox.Show("Vui lòng chọn một ca trực.", "Chưa chọn ca", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataTable kq = DiemDanhService.CheckIn(ma, _nguoiDung.MaNguoiDung);
                string trangThai = kq.Rows[0]["TrangThaiDiemDanh"].ToString();
                DateTime gio = Convert.ToDateTime(kq.Rows[0]["GioCheckIn"]);

                MessageBox.Show("Check-in thành công lúc " + gio.ToString("HH:mm:ss") + "\nTrạng thái: " + trangThai,
                    "Check-in", MessageBoxButtons.OK, MessageBoxIcon.Information);
                NapDanhSach();
            }
            catch (SqlException ex)
            {
                // Ví dụ: "Chưa đến giờ check-in...", "Ca trước chưa gửi biên bản bàn giao..."
                MessageBox.Show(ex.Message, "Không thể check-in", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            string ma = LayMaLichDangChon();
            if (ma == null)
            {
                MessageBox.Show("Vui lòng chọn một ca trực.", "Chưa chọn ca", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataTable kq = DiemDanhService.CheckOut(ma, _nguoiDung.MaNguoiDung);
                string trangThai = kq.Rows[0]["TrangThaiDiemDanh"].ToString();
                DateTime gio = Convert.ToDateTime(kq.Rows[0]["GioCheckOut"]);

                MessageBox.Show("Check-out thành công lúc " + gio.ToString("HH:mm:ss") + "\nTrạng thái: " + trangThai,
                    "Check-out", MessageBoxButtons.OK, MessageBoxIcon.Information);
                NapDanhSach();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Không thể check-out", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Tô màu trạng thái điểm danh
        private void dgvDiemDanh_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.Value == null) return;
            if (dgvDiemDanh.Columns[e.ColumnIndex].Name != "TrangThaiDiemDanh") return;

            string tt = e.Value.ToString();
            if (tt == "Đúng giờ") e.CellStyle.ForeColor = Color.FromArgb(14, 124, 134);
            else if (tt == "Đi trễ" || tt == "Về sớm") e.CellStyle.ForeColor = Color.FromArgb(164, 64, 43);
            else if (tt == "Vắng") e.CellStyle.ForeColor = Color.Red;
        }
    }
}