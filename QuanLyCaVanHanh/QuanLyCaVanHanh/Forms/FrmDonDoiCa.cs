using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using QuanLyCaVanHanh.Services;

namespace QuanLyCaVanHanh.Forms
{
    public partial class FrmDonDoiCa : Form
    {
        public FrmDonDoiCa()
        {
            InitializeComponent();
        }

        private void FrmDonDoiCa_Load(object sender, EventArgs e)
        {
            DinhDangLuoi();
            cboLoaiDon.SelectedIndex = 0;

            PhanQuyenNguoiDung();

            // Bổ sung: nhân viên chỉ gửi đơn; Trưởng ca / Quản lý chỉ duyệt đơn
            bool laNhanVien = PhienDangNhap.NguoiDung.VaiTro == VaiTro.NhanVienTruc;
            Button btnGui = TimNut(this, "GỬI ĐƠN");
            Button btnDuyet = TimNut(this, "PHÊ DUYỆT");
            Button btnTuChoi = TimNut(this, "TỪ CHỐI");

            if (laNhanVien)
            {
                if (btnDuyet != null) btnDuyet.Visible = false;
                if (btnTuChoi != null) btnTuChoi.Visible = false;
            }
            else if (btnGui != null)
            {
                if (btnGui.Parent is GroupBox) btnGui.Parent.Visible = false;   // ẩn cả khung "Gửi đơn mới"
                else btnGui.Visible = false;
            }

            TaiLichTrucKhaDung();
            TaiDanhSachDon();
        }

        private static Button TimNut(Control goc, string chuaChu)
        {
            foreach (Control c in goc.Controls)
            {
                Button b = c as Button;
                if (b != null && b.Text.ToUpper().Contains(chuaChu))
                    return b;

                Button con = TimNut(c, chuaChu);
                if (con != null)
                    return con;
            }
            return null;
        }

        private void DinhDangLuoi()
        {
            dgvDonDoiCa.ReadOnly = true;
            dgvDonDoiCa.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDonDoiCa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDonDoiCa.RowHeadersVisible = false;
            dgvDonDoiCa.AllowUserToAddRows = false;
            dgvDonDoiCa.EnableHeadersVisualStyles = false;
            dgvDonDoiCa.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(15, 42, 67); // Navy #0F2A43
            dgvDonDoiCa.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDonDoiCa.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        }

        private void PhanQuyenNguoiDung()
        {
            string vaiTro = PhienDangNhap.NguoiDung.VaiTro;
            if (vaiTro == "NHAN_VIEN_TRUC")
            {
                pnlThaoTacDuyet.Visible = false;
                grpGuiDon.Visible = true;
            }
            else
            {
                pnlThaoTacDuyet.Visible = true;
                grpGuiDon.Visible = true;
            }
        }

        private void TaiLichTrucKhaDung()
        {
            try
            {
                DataTable dt = DonDoiCaService.LayLichTrucChoKichHoat(PhienDangNhap.NguoiDung.MaNguoiDung);
                cboLichTruc.DataSource = dt;
                cboLichTruc.DisplayMember = "TenHienThi";
                cboLichTruc.ValueMember = "MaLichTruc";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi tải lịch trực", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TaiDanhSachDon()
        {
            try
            {
                DataTable dt = DonDoiCaService.LayDanhSachDon(PhienDangNhap.NguoiDung.MaNguoiDung, PhienDangNhap.NguoiDung.VaiTro);
                dgvDonDoiCa.DataSource = dt;

                if (dgvDonDoiCa.Columns.Count > 0)
                {
                    dgvDonDoiCa.Columns["MaDon"].HeaderText = "Mã đơn";
                    dgvDonDoiCa.Columns["LoaiDon"].HeaderText = "Loại đơn";
                    dgvDonDoiCa.Columns["NguoiGui"].HeaderText = "Người gửi";
                    dgvDonDoiCa.Columns["NgayTruc"].HeaderText = "Ngày trực";
                    dgvDonDoiCa.Columns["TenCa"].HeaderText = "Ca trực";
                    dgvDonDoiCa.Columns["TenViTri"].HeaderText = "Vị trí";
                    dgvDonDoiCa.Columns["LyDo"].HeaderText = "Lý do";
                    dgvDonDoiCa.Columns["ThoiDiemGui"].HeaderText = "Thời điểm gửi";
                    dgvDonDoiCa.Columns["TrangThai"].HeaderText = "Trạng thái";
                    dgvDonDoiCa.Columns["NguoiDuyet"].HeaderText = "Người duyệt";
                    dgvDonDoiCa.Columns["ThoiDiemDuyet"].HeaderText = "Thời điểm duyệt";

                    dgvDonDoiCa.Columns["MaNguoiGui"].Visible = false;
                    dgvDonDoiCa.Columns["MaNguoiDuyet"].Visible = false;
                    dgvDonDoiCa.Columns["MaLichTruc"].Visible = false;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuiDon_Click(object sender, EventArgs e)
        {
            if (cboLichTruc.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn ca trực cần xin đổi / nghỉ phép.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string lyDo = txtLyDo.Text.Trim();
            if (string.IsNullOrEmpty(lyDo))
            {
                MessageBox.Show("Vui lòng nhập lý do gửi đơn.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLyDo.Focus();
                return;
            }

            string maLichTruc = cboLichTruc.SelectedValue.ToString();
            string loaiDon = cboLoaiDon.SelectedItem.ToString();

            try
            {
                DonDoiCaService.GuiDon(PhienDangNhap.NguoiDung.MaNguoiDung, maLichTruc, loaiDon, lyDo);
                MessageBox.Show("Gửi đơn thành công! Đơn đã chuyển sang trạng thái Chờ duyệt.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtLyDo.Clear();
                TaiLichTrucKhaDung();
                TaiDanhSachDon();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Lỗi gửi đơn (BR06/BR07)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDuyet_Click(object sender, EventArgs e)
        {
            XuLyDuyetDon("Đã duyệt");
        }

        private void btnTuChoi_Click(object sender, EventArgs e)
        {
            XuLyDuyetDon("Từ chối");
        }

        private void XuLyDuyetDon(string ketQua)
        {
            if (dgvDonDoiCa.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn đơn cần xử lý.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataRowView drv = (DataRowView)dgvDonDoiCa.CurrentRow.DataBoundItem;
            string maDon = drv["MaDon"].ToString();
            string trangThai = drv["TrangThai"].ToString();

            if (trangThai != "Chờ duyệt")
            {
                MessageBox.Show("Đơn này không còn ở trạng thái Chờ duyệt.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DonDoiCaService.DuyetDon(maDon, PhienDangNhap.NguoiDung.MaNguoiDung, ketQua);
                MessageBox.Show(string.Format("Đã cập nhật kết quả: {0} thành công!", ketQua), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                TaiDanhSachDon();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Lỗi phê duyệt đơn", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            TaiLichTrucKhaDung();
            TaiDanhSachDon();
        }
    }
}