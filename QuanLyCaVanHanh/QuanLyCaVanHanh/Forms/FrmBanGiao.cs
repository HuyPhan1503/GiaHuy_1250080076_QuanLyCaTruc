using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using QuanLyCaVanHanh.Services;

namespace QuanLyCaVanHanh.Forms
{
    public partial class FrmBanGiao : Form
    {
        public FrmBanGiao()
        {
            InitializeComponent();
        }

        private void FrmBanGiao_Load(object sender, EventArgs e)
        {
            DinhDangLuoi(dgvNhatKy);
            DinhDangLuoi(dgvBanGiao);
            DinhDangLuoi(dgvTonDong);

            cboLoaiNhatKy.SelectedIndex = 0;
            cboMucDo.SelectedIndex = 0;

            // Trưởng ca / Quản lý chỉ giám sát: không ghi nhật ký, không lập biên bản
            if (PhienDangNhap.NguoiDung.VaiTro != VaiTro.NhanVienTruc)
            {
                cboLoaiNhatKy.Parent.Visible = false;       // ẩn khung ghi nhật ký (tab 1)

                // Gỡ tab "Lập biên bản"
                foreach (TabPage trang in tabMain.TabPages)
                {
                    if (trang.Text.Contains("Lập biên bản"))
                    {
                        tabMain.TabPages.Remove(trang);
                        break;
                    }
                }

                // Đánh số lại: "3. Biên bản..." thành "2. Biên bản..."
                for (int i = 0; i < tabMain.TabPages.Count; i++)
                {
                    string ten = tabMain.TabPages[i].Text;
                    int cham = ten.IndexOf('.');
                    if (cham > 0 && cham <= 2)
                        tabMain.TabPages[i].Text = (i + 1) + ten.Substring(cham);
                }
            }

            TaiCaTrucHomNay();
            TaiCaNhanKhaDung();
            TaiDanhSachBanGiao();
            TaiDanhSachTonDong();
        }

        private void DinhDangLuoi(DataGridView dgv)
        {
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToAddRows = false;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(15, 42, 67); // Navy #0F2A43
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        }

        private void TaiCaTrucHomNay()
        {
            try
            {
                DataTable dt = BanGiaoService.LayCaTrucHomNay(PhienDangNhap.NguoiDung.MaNguoiDung, PhienDangNhap.NguoiDung.VaiTro);
                cboCaTrucHomNay.DataSource = dt;
                cboCaTrucHomNay.DisplayMember = "TenHienThi";
                cboCaTrucHomNay.ValueMember = "MaLichTruc";

                if (dt.Rows.Count > 0)
                {
                    cboCaTrucHomNay.SelectedIndex = 0;
                    TaiNhatKyCaHienTai();
                }
                else
                {
                    dgvNhatKy.DataSource = null;
                    lblCaGiaoInfoVal.Text = "Không có ca trực nào trong ngày hôm nay";
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

        private void TaiCaNhanKhaDung()
        {
            try
            {
                DataTable dt = BanGiaoService.LayCaNhanKhaDung();
                cboCaNhan.DataSource = dt;
                cboCaNhan.DisplayMember = "TenHienThi";
                cboCaNhan.ValueMember = "MaLichTruc";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi tải ca nhận", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TaiNhatKyCaHienTai()
        {
            if (cboCaTrucHomNay.SelectedValue == null) return;
            string maLichTruc = cboCaTrucHomNay.SelectedValue.ToString();
            lblCaGiaoInfoVal.Text = cboCaTrucHomNay.Text;

            try
            {
                DataTable dt = BanGiaoService.LayNhatKyCa(maLichTruc);
                dgvNhatKy.DataSource = dt;

                if (dgvNhatKy.Columns.Count > 0)
                {
                    dgvNhatKy.Columns["MaNhatKy"].HeaderText = "Mã NK";
                    dgvNhatKy.Columns["LoaiNhatKy"].HeaderText = "Loại";
                    dgvNhatKy.Columns["MucDo"].HeaderText = "Mức độ";
                    dgvNhatKy.Columns["NoiDung"].HeaderText = "Nội dung";
                    dgvNhatKy.Columns["TrangThai"].HeaderText = "Trạng thái";
                    dgvNhatKy.Columns["ThoiGianGhi"].HeaderText = "Thời gian ghi";
                    dgvNhatKy.Columns["NguoiGhi"].HeaderText = "Người ghi";
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TaiDanhSachBanGiao()
        {
            try
            {
                DataTable dt = BanGiaoService.LayDanhSachBanGiao();
                dgvBanGiao.DataSource = dt;

                if (dgvBanGiao.Columns.Count > 0)
                {
                    dgvBanGiao.Columns["MaBanGiao"].HeaderText = "Mã BB";
                    dgvBanGiao.Columns["MaLichTrucGiao"].Visible = false;
                    dgvBanGiao.Columns["NgayCaGiao"].HeaderText = "Ngày giao";
                    dgvBanGiao.Columns["CaGiao"].HeaderText = "Ca giao";
                    dgvBanGiao.Columns["NguoiGiao"].HeaderText = "Người giao";
                    dgvBanGiao.Columns["MaLichTrucNhan"].Visible = false;
                    dgvBanGiao.Columns["NgayCaNhan"].HeaderText = "Ngày nhận";
                    dgvBanGiao.Columns["CaNhan"].HeaderText = "Ca nhận";
                    dgvBanGiao.Columns["NguoiNhan"].HeaderText = "Người nhận";
                    dgvBanGiao.Columns["NoiDungTongKet"].HeaderText = "Nội dung tổng kết";
                    dgvBanGiao.Columns["ThoiDiemGui"].HeaderText = "Thời điểm gửi";
                    dgvBanGiao.Columns["ThoiDiemNhanCa"].HeaderText = "Thời điểm nhận";
                    dgvBanGiao.Columns["TrangThai"].HeaderText = "Trạng thái";
                    dgvBanGiao.Columns["NguoiXacNhan"].HeaderText = "Người xác nhận";
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TaiDanhSachTonDong()
        {
            try
            {
                DataTable dt = BanGiaoService.LayDanhSachTonDong();
                dgvTonDong.DataSource = dt;

                if (dgvTonDong.Columns.Count > 0)
                {
                    dgvTonDong.Columns["MaTonDong"].HeaderText = "Mã TĐ";
                    dgvTonDong.Columns["MaBanGiao"].HeaderText = "Mã BB";
                    dgvTonDong.Columns["MaNhatKy"].HeaderText = "Mã NK";
                    dgvTonDong.Columns["LoaiNhatKy"].HeaderText = "Loại";
                    dgvTonDong.Columns["MucDo"].HeaderText = "Mức độ";
                    dgvTonDong.Columns["NoiDung"].HeaderText = "Nội dung sự cố";
                    dgvTonDong.Columns["GhiChu"].HeaderText = "Ghi chú";
                    dgvTonDong.Columns["TrangThai"].HeaderText = "Trạng thái";
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboCaTrucHomNay_SelectedIndexChanged(object sender, EventArgs e)
        {
            TaiNhatKyCaHienTai();
        }

        private void cboLoaiNhatKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLoaiNhatKy.SelectedItem != null && cboLoaiNhatKy.SelectedItem.ToString() == "Sự cố")
            {
                cboMucDo.Enabled = true;
            }
            else
            {
                cboMucDo.Enabled = false;
            }
        }

        private void btnGhiNhatKy_Click(object sender, EventArgs e)
        {
            if (cboCaTrucHomNay.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn ca trực hôm nay để ghi nhật ký.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string noiDung = txtNoiDungNhatKy.Text.Trim();
            if (string.IsNullOrEmpty(noiDung))
            {
                MessageBox.Show("Vui lòng nhập nội dung nhật ký / sự cố.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNoiDungNhatKy.Focus();
                return;
            }

            string maLichTruc = cboCaTrucHomNay.SelectedValue.ToString();
            string loaiNhatKy = cboLoaiNhatKy.SelectedItem.ToString();
            string mucDo = loaiNhatKy == "Sự cố" ? cboMucDo.SelectedItem.ToString() : null;

            try
            {
                BanGiaoService.GhiNhatKy(maLichTruc, PhienDangNhap.NguoiDung.MaNguoiDung, loaiNhatKy, mucDo, noiDung);
                MessageBox.Show("Ghi nhật ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNoiDungNhatKy.Clear();
                TaiNhatKyCaHienTai();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Lỗi ghi nhật ký", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLapBienBan_Click(object sender, EventArgs e)
        {
            if (cboCaTrucHomNay.SelectedValue == null)
            {
                MessageBox.Show("Không có ca trực được chọn để lập biên bản bàn giao.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string noiDungTongKet = txtNoiDungTongKet.Text.Trim();
            if (string.IsNullOrEmpty(noiDungTongKet))
            {
                MessageBox.Show("Vui lòng nhập nội dung tổng kết ca trực trước khi gửi biên bản.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNoiDungTongKet.Focus();
                return;
            }

            string maLichTrucGiao = cboCaTrucHomNay.SelectedValue.ToString();

            try
            {
                int soViecTonDong = BanGiaoService.LapBienBan(maLichTrucGiao, PhienDangNhap.NguoiDung.MaNguoiDung, noiDungTongKet);
                MessageBox.Show(string.Format("Lập biên bản bàn giao ca thành công!\nSố công việc/sự cố chưa xong đã kế thừa thành công việc tồn đọng (BR04): {0}", soViecTonDong),
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtNoiDungTongKet.Clear();
                TaiDanhSachBanGiao();
                TaiDanhSachTonDong();
                tabMain.SelectedTab = tabBanGiaoAndTonDong;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Lỗi lập biên bản", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvBanGiao_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBanGiao.CurrentRow != null && dgvBanGiao.CurrentRow.DataBoundItem != null)
            {
                DataRowView drv = (DataRowView)dgvBanGiao.CurrentRow.DataBoundItem;
                string trangThai = drv["TrangThai"].ToString();

                // Chỉ biên bản đang chờ xác nhận mới xác nhận được (Đã khóa / Đã hủy thì không)
                btnXacNhanNhanCa.Enabled = (trangThai == "Chờ xác nhận");
            }
        }

        private void btnXacNhanNhanCa_Click(object sender, EventArgs e)
        {
            if (dgvBanGiao.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn biên bản bàn giao cần xác nhận.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboCaNhan.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn ca nhận tương ứng.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataRowView drv = (DataRowView)dgvBanGiao.CurrentRow.DataBoundItem;
            string maBanGiao = drv["MaBanGiao"].ToString();
            string maLichTrucNhan = cboCaNhan.SelectedValue.ToString();

            try
            {
                BanGiaoService.XacNhanBanGiao(maBanGiao, maLichTrucNhan, PhienDangNhap.NguoiDung.MaNguoiDung);
                MessageBox.Show("Xác nhận nhận ca thành công! Biên bản bàn giao đã chuyển sang trạng thái Đã khóa (BR05).",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                TaiDanhSachBanGiao();
                TaiDanhSachTonDong();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Lỗi xác nhận bàn giao", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            TaiCaTrucHomNay();
            TaiCaNhanKhaDung();
            TaiDanhSachBanGiao();
            TaiDanhSachTonDong();
        }
    }
}