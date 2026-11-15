using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using QuanLyCaVanHanh.Services;

namespace QuanLyCaVanHanh.Forms
{
    public partial class FrmLichTruc : Form
    {
        private readonly NguoiDung _nguoiDung = PhienDangNhap.NguoiDung;

        // Trưởng ca / Quản lý được xem tất cả và phân công; nhân viên chỉ xem lịch của mình (BR07)
        private bool CoQuyenPhanCong
        {
            get { return _nguoiDung.VaiTro != VaiTro.NhanVienTruc; }
        }

        // Chặn sự kiện đổi ca khi đang nạp danh mục
        private bool _dangNap;

        public FrmLichTruc()
        {
            InitializeComponent();
        }

        private void FrmLichTruc_Load(object sender, EventArgs e)
        {
            dtpTuNgay.Value = DateTime.Today.AddDays(-1);
            dtpDenNgay.Value = DateTime.Today.AddDays(7);
            dtpNgayTruc.Value = DateTime.Today.AddDays(1);
            dtpGioBatDau.Value = DateTime.Today.AddHours(7);     // gợi ý ca gãy: 07:00 - 11:00
            dtpGioKetThuc.Value = DateTime.Today.AddHours(11);

            grpPhanCong.Visible = CoQuyenPhanCong;
            if (CoQuyenPhanCong) NapDanhMuc();

            NapLich();
        }

        private void NapDanhMuc()
        {
            try
            {
                cboNhanVien.DisplayMember = "HoTen";
                cboNhanVien.ValueMember = "MaNguoiDung";
                cboNhanVien.DataSource = LichTrucService.LayNhanVien();

                _dangNap = true;
                cboCa.DisplayMember = "Ten";
                cboCa.ValueMember = "MaCa";
                cboCa.DataSource = LichTrucService.LayCa();
                _dangNap = false;
                CapNhatONhapGio();

                cboViTri.DisplayMember = "TenViTri";
                cboViTri.ValueMember = "MaViTri";
                cboViTri.DataSource = LichTrucService.LayViTri();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Lỗi cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Ca đang chọn có phải ca gãy (giờ tự nhập) không
        private bool DangChonCaGay()
        {
            DataRowView dong = cboCa.SelectedItem as DataRowView;
            return dong != null && Convert.ToBoolean(dong["TuyChinhGio"]);
        }

        // Chỉ hiện ô nhập giờ khi chọn Ca gãy
        private void CapNhatONhapGio()
        {
            bool gay = DangChonCaGay();
            lblGioBatDau.Visible = gay;
            dtpGioBatDau.Visible = gay;
            lblGioKetThuc.Visible = gay;
            dtpGioKetThuc.Visible = gay;
            lblGhiChuCaGay.Visible = gay;
            grpPhanCong.Height = gay ? 150 : 110;
        }

        private void cboCa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dangNap) return;
            CapNhatONhapGio();
        }

        private void NapLich()
        {
            try
            {
                string maLoc = CoQuyenPhanCong ? null : _nguoiDung.MaNguoiDung;
                dgvLichTruc.DataSource = LichTrucService.LayDanhSach(dtpTuNgay.Value, dtpDenNgay.Value, maLoc);
                DinhDangLuoi();
                lblTongSo.Text = "Tổng số lịch trực: " + dgvLichTruc.Rows.Count;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Lỗi cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DinhDangLuoi()
        {
            if (dgvLichTruc.Columns.Count == 0) return;

            dgvLichTruc.Columns["MaLichTruc"].HeaderText = "Mã lịch";
            dgvLichTruc.Columns["NgayTruc"].HeaderText = "Ngày trực";
            dgvLichTruc.Columns["NgayTruc"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvLichTruc.Columns["HoTen"].HeaderText = "Nhân viên";
            dgvLichTruc.Columns["TenCa"].HeaderText = "Ca";
            dgvLichTruc.Columns["TenViTri"].HeaderText = "Vị trí";
            dgvLichTruc.Columns["ThoiGianBatDau"].HeaderText = "Bắt đầu";
            dgvLichTruc.Columns["ThoiGianBatDau"].DefaultCellStyle.Format = "HH:mm";
            dgvLichTruc.Columns["ThoiGianKetThuc"].HeaderText = "Kết thúc";
            dgvLichTruc.Columns["ThoiGianKetThuc"].DefaultCellStyle.Format = "HH:mm";
            dgvLichTruc.Columns["TrangThaiLich"].HeaderText = "Trạng thái";
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (dtpTuNgay.Value.Date > dtpDenNgay.Value.Date)
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc.", "Khoảng ngày không hợp lệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            NapLich();
        }

        private void btnPhanCong_Click(object sender, EventArgs e)
        {
            if (cboNhanVien.SelectedValue == null || cboCa.SelectedValue == null || cboViTri.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn đủ nhân viên, ca và vị trí.", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ca gãy: lấy giờ do người phân công nhập (bỏ phần giây)
            TimeSpan? gioBD = null;
            TimeSpan? gioKT = null;
            if (DangChonCaGay())
            {
                TimeSpan bd = dtpGioBatDau.Value.TimeOfDay;
                TimeSpan kt = dtpGioKetThuc.Value.TimeOfDay;
                gioBD = new TimeSpan(bd.Hours, bd.Minutes, 0);
                gioKT = new TimeSpan(kt.Hours, kt.Minutes, 0);

                if (gioBD.Value == gioKT.Value)
                {
                    MessageBox.Show("Giờ kết thúc phải khác giờ bắt đầu.", "Giờ không hợp lệ",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            try
            {
                LichTrucService.TaoLichTruc(
                    cboNhanVien.SelectedValue.ToString(),
                    cboCa.SelectedValue.ToString(),
                    cboViTri.SelectedValue.ToString(),
                    dtpNgayTruc.Value,
                    gioBD, gioKT);

                MessageBox.Show("Đã phân công lịch trực thành công.", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                NapLich();
            }
            catch (SqlException ex)
            {
                // Ví dụ: "Trùng lịch (BR01): vị trí này trong ca đã có người được phân công."
                MessageBox.Show(ex.Message, "Không thể phân công", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Tô màu trạng thái cho dễ nhìn
        private void dgvLichTruc_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.Value == null) return;
            if (dgvLichTruc.Columns[e.ColumnIndex].Name != "TrangThaiLich") return;

            string tt = e.Value.ToString();
            if (tt == "Đang diễn ra") e.CellStyle.ForeColor = Color.FromArgb(14, 124, 134);
            else if (tt == "Đã hủy") e.CellStyle.ForeColor = Color.Gray;
            else if (tt == "Đã kết thúc") e.CellStyle.ForeColor = Color.FromArgb(107, 119, 133);
        }
    }
}