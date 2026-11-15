using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using QuanLyCaVanHanh.Services;

namespace QuanLyCaVanHanh.Forms
{
    public partial class FrmThongKe : Form
    {
        public FrmThongKe()
        {
            InitializeComponent();
        }

        private void FrmThongKe_Load(object sender, EventArgs e)
        {
            DinhDangLuoi(dgvChuyenCan);
            DinhDangLuoi(dgvSuCo);

            DateTime now = DateTime.Now;
            dtpTuNgay.Value = new DateTime(now.Year, now.Month, 1);
            dtpDenNgay.Value = now.Date;

            TaiBaoCaoThongKe();
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

        private void TaiBaoCaoThongKe()
        {
            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date;

            if (tuNgay > denNgay)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataSet ds = ThongKeService.LayBaoCaoThongKe(tuNgay, denNgay);

                if (ds != null && ds.Tables.Count >= 3)
                {
                    // Bảng 1: Thống kê chuyên cần nhân viên
                    DataTable dtChuyenCan = ds.Tables[0];
                    dgvChuyenCan.DataSource = dtChuyenCan;
                    if (dgvChuyenCan.Columns.Count > 0)
                    {
                        dgvChuyenCan.Columns["MaNguoiDung"].HeaderText = "Mã NV";
                        dgvChuyenCan.Columns["HoTen"].HeaderText = "Họ và tên";
                        dgvChuyenCan.Columns["TongSoCa"].HeaderText = "Tổng số ca";
                        dgvChuyenCan.Columns["SoCaDungGio"].HeaderText = "Đúng giờ";
                        dgvChuyenCan.Columns["SoCaDiTre"].HeaderText = "Đi trễ";
                        dgvChuyenCan.Columns["SoCaVeSom"].HeaderText = "Về sớm";
                        dgvChuyenCan.Columns["SoCaVang"].HeaderText = "Vắng mặt";
                    }

                    // Bảng 2: Thống kê sự cố
                    DataTable dtSuCo = ds.Tables[1];
                    dgvSuCo.DataSource = dtSuCo;
                    if (dgvSuCo.Columns.Count > 0)
                    {
                        dgvSuCo.Columns["MucDo"].HeaderText = "Mức độ sự cố";
                        dgvSuCo.Columns["TrangThai"].HeaderText = "Trạng thái xử lý";
                        dgvSuCo.Columns["SoLuong"].HeaderText = "Số lượng";
                    }

                    // Bảng 3: Chỉ số tổng quan bàn giao & tồn đọng
                    DataTable dtTongQuan = ds.Tables[2];
                    if (dtTongQuan.Rows.Count > 0)
                    {
                        DataRow dr = dtTongQuan.Rows[0];
                        lblDaKhoaVal.Text = dr["SoBienBanDaKhoa"].ToString();
                        lblChoXacNhanVal.Text = dr["SoBienBanChoXacNhan"].ToString();
                        lblTonDongVal.Text = dr["SoTonDongChuaXuLy"].ToString();
                    }
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

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            TaiBaoCaoThongKe();
        }
    }
}