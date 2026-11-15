namespace QuanLyCaVanHanh.Forms
{
    partial class FrmLichTruc
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlLoc = new System.Windows.Forms.Panel();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.btnXem = new System.Windows.Forms.Button();
            this.lblTongSo = new System.Windows.Forms.Label();
            this.grpPhanCong = new System.Windows.Forms.GroupBox();
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.cboNhanVien = new System.Windows.Forms.ComboBox();
            this.lblCa = new System.Windows.Forms.Label();
            this.cboCa = new System.Windows.Forms.ComboBox();
            this.lblViTri = new System.Windows.Forms.Label();
            this.cboViTri = new System.Windows.Forms.ComboBox();
            this.lblNgayTruc = new System.Windows.Forms.Label();
            this.dtpNgayTruc = new System.Windows.Forms.DateTimePicker();
            this.btnPhanCong = new System.Windows.Forms.Button();
            this.lblGioBatDau = new System.Windows.Forms.Label();
            this.dtpGioBatDau = new System.Windows.Forms.DateTimePicker();
            this.lblGioKetThuc = new System.Windows.Forms.Label();
            this.dtpGioKetThuc = new System.Windows.Forms.DateTimePicker();
            this.lblGhiChuCaGay = new System.Windows.Forms.Label();
            this.dgvLichTruc = new System.Windows.Forms.DataGridView();
            this.pnlLoc.SuspendLayout();
            this.grpPhanCong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichTruc)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLoc
            // 
            this.pnlLoc.BackColor = System.Drawing.Color.White;
            this.pnlLoc.Controls.Add(this.lblTongSo);
            this.pnlLoc.Controls.Add(this.btnXem);
            this.pnlLoc.Controls.Add(this.dtpDenNgay);
            this.pnlLoc.Controls.Add(this.lblDenNgay);
            this.pnlLoc.Controls.Add(this.dtpTuNgay);
            this.pnlLoc.Controls.Add(this.lblTuNgay);
            this.pnlLoc.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLoc.Location = new System.Drawing.Point(0, 0);
            this.pnlLoc.Name = "pnlLoc";
            this.pnlLoc.Size = new System.Drawing.Size(1100, 60);
            this.pnlLoc.TabIndex = 0;
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Location = new System.Drawing.Point(16, 22);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(60, 19);
            this.lblTuNgay.TabIndex = 0;
            this.lblTuNgay.Text = "Từ ngày";
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTuNgay.Location = new System.Drawing.Point(84, 18);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(130, 26);
            this.dtpTuNgay.TabIndex = 1;
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Location = new System.Drawing.Point(240, 22);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(69, 19);
            this.lblDenNgay.TabIndex = 2;
            this.lblDenNgay.Text = "Đến ngày";
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDenNgay.Location = new System.Drawing.Point(317, 18);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(130, 26);
            this.dtpDenNgay.TabIndex = 3;
            // 
            // btnXem
            // 
            this.btnXem.BackColor = System.Drawing.Color.FromArgb(14, 124, 134);
            this.btnXem.FlatAppearance.BorderSize = 0;
            this.btnXem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXem.ForeColor = System.Drawing.Color.White;
            this.btnXem.Location = new System.Drawing.Point(470, 14);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(100, 34);
            this.btnXem.TabIndex = 4;
            this.btnXem.Text = "Xem lịch";
            this.btnXem.UseVisualStyleBackColor = false;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // lblTongSo
            // 
            this.lblTongSo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTongSo.Location = new System.Drawing.Point(850, 22);
            this.lblTongSo.Name = "lblTongSo";
            this.lblTongSo.Size = new System.Drawing.Size(234, 19);
            this.lblTongSo.TabIndex = 5;
            this.lblTongSo.Text = "Tổng số lịch trực: 0";
            this.lblTongSo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpPhanCong
            // 
            this.grpPhanCong.Controls.Add(this.lblGhiChuCaGay);
            this.grpPhanCong.Controls.Add(this.dtpGioKetThuc);
            this.grpPhanCong.Controls.Add(this.lblGioKetThuc);
            this.grpPhanCong.Controls.Add(this.dtpGioBatDau);
            this.grpPhanCong.Controls.Add(this.lblGioBatDau);
            this.grpPhanCong.Controls.Add(this.btnPhanCong);
            this.grpPhanCong.Controls.Add(this.dtpNgayTruc);
            this.grpPhanCong.Controls.Add(this.lblNgayTruc);
            this.grpPhanCong.Controls.Add(this.cboViTri);
            this.grpPhanCong.Controls.Add(this.lblViTri);
            this.grpPhanCong.Controls.Add(this.cboCa);
            this.grpPhanCong.Controls.Add(this.lblCa);
            this.grpPhanCong.Controls.Add(this.cboNhanVien);
            this.grpPhanCong.Controls.Add(this.lblNhanVien);
            this.grpPhanCong.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpPhanCong.Location = new System.Drawing.Point(0, 540);
            this.grpPhanCong.Name = "grpPhanCong";
            this.grpPhanCong.Size = new System.Drawing.Size(1100, 110);
            this.grpPhanCong.TabIndex = 2;
            this.grpPhanCong.TabStop = false;
            this.grpPhanCong.Text = "Phân công lịch trực (Trưởng ca / Quản lý)";
            // 
            // lblNhanVien
            // 
            this.lblNhanVien.AutoSize = true;
            this.lblNhanVien.Location = new System.Drawing.Point(16, 30);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(70, 19);
            this.lblNhanVien.TabIndex = 0;
            this.lblNhanVien.Text = "Nhân viên";
            // 
            // cboNhanVien
            // 
            this.cboNhanVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNhanVien.FormattingEnabled = true;
            this.cboNhanVien.Location = new System.Drawing.Point(16, 54);
            this.cboNhanVien.Name = "cboNhanVien";
            this.cboNhanVien.Size = new System.Drawing.Size(220, 27);
            this.cboNhanVien.TabIndex = 1;
            // 
            // lblCa
            // 
            this.lblCa.AutoSize = true;
            this.lblCa.Location = new System.Drawing.Point(256, 30);
            this.lblCa.Name = "lblCa";
            this.lblCa.Size = new System.Drawing.Size(24, 19);
            this.lblCa.TabIndex = 2;
            this.lblCa.Text = "Ca";
            // 
            // cboCa
            // 
            this.cboCa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCa.FormattingEnabled = true;
            this.cboCa.Location = new System.Drawing.Point(256, 54);
            this.cboCa.Name = "cboCa";
            this.cboCa.Size = new System.Drawing.Size(220, 27);
            this.cboCa.TabIndex = 3;
            this.cboCa.SelectedIndexChanged += new System.EventHandler(this.cboCa_SelectedIndexChanged);
            // 
            // lblViTri
            // 
            this.lblViTri.AutoSize = true;
            this.lblViTri.Location = new System.Drawing.Point(496, 30);
            this.lblViTri.Name = "lblViTri";
            this.lblViTri.Size = new System.Drawing.Size(42, 19);
            this.lblViTri.TabIndex = 4;
            this.lblViTri.Text = "Vị trí";
            // 
            // cboViTri
            // 
            this.cboViTri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboViTri.FormattingEnabled = true;
            this.cboViTri.Location = new System.Drawing.Point(496, 54);
            this.cboViTri.Name = "cboViTri";
            this.cboViTri.Size = new System.Drawing.Size(220, 27);
            this.cboViTri.TabIndex = 5;
            // 
            // lblNgayTruc
            // 
            this.lblNgayTruc.AutoSize = true;
            this.lblNgayTruc.Location = new System.Drawing.Point(736, 30);
            this.lblNgayTruc.Name = "lblNgayTruc";
            this.lblNgayTruc.Size = new System.Drawing.Size(71, 19);
            this.lblNgayTruc.TabIndex = 6;
            this.lblNgayTruc.Text = "Ngày trực";
            // 
            // dtpNgayTruc
            // 
            this.dtpNgayTruc.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayTruc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayTruc.Location = new System.Drawing.Point(736, 54);
            this.dtpNgayTruc.Name = "dtpNgayTruc";
            this.dtpNgayTruc.Size = new System.Drawing.Size(130, 26);
            this.dtpNgayTruc.TabIndex = 7;
            // 
            // btnPhanCong
            // 
            this.btnPhanCong.BackColor = System.Drawing.Color.FromArgb(15, 42, 67);
            this.btnPhanCong.FlatAppearance.BorderSize = 0;
            this.btnPhanCong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPhanCong.ForeColor = System.Drawing.Color.White;
            this.btnPhanCong.Location = new System.Drawing.Point(890, 50);
            this.btnPhanCong.Name = "btnPhanCong";
            this.btnPhanCong.Size = new System.Drawing.Size(140, 36);
            this.btnPhanCong.TabIndex = 8;
            this.btnPhanCong.Text = "Phân công";
            this.btnPhanCong.UseVisualStyleBackColor = false;
            this.btnPhanCong.Click += new System.EventHandler(this.btnPhanCong_Click);
            // 
            // lblGioBatDau
            // 
            this.lblGioBatDau.AutoSize = true;
            this.lblGioBatDau.Location = new System.Drawing.Point(16, 108);
            this.lblGioBatDau.Name = "lblGioBatDau";
            this.lblGioBatDau.Size = new System.Drawing.Size(80, 19);
            this.lblGioBatDau.TabIndex = 9;
            this.lblGioBatDau.Text = "Giờ bắt đầu";
            this.lblGioBatDau.Visible = false;
            // 
            // dtpGioBatDau
            // 
            this.dtpGioBatDau.CustomFormat = "HH:mm";
            this.dtpGioBatDau.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpGioBatDau.Location = new System.Drawing.Point(110, 104);
            this.dtpGioBatDau.Name = "dtpGioBatDau";
            this.dtpGioBatDau.ShowUpDown = true;
            this.dtpGioBatDau.Size = new System.Drawing.Size(90, 26);
            this.dtpGioBatDau.TabIndex = 10;
            this.dtpGioBatDau.Visible = false;
            // 
            // lblGioKetThuc
            // 
            this.lblGioKetThuc.AutoSize = true;
            this.lblGioKetThuc.Location = new System.Drawing.Point(230, 108);
            this.lblGioKetThuc.Name = "lblGioKetThuc";
            this.lblGioKetThuc.Size = new System.Drawing.Size(88, 19);
            this.lblGioKetThuc.TabIndex = 11;
            this.lblGioKetThuc.Text = "Giờ kết thúc";
            this.lblGioKetThuc.Visible = false;
            // 
            // dtpGioKetThuc
            // 
            this.dtpGioKetThuc.CustomFormat = "HH:mm";
            this.dtpGioKetThuc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpGioKetThuc.Location = new System.Drawing.Point(330, 104);
            this.dtpGioKetThuc.Name = "dtpGioKetThuc";
            this.dtpGioKetThuc.ShowUpDown = true;
            this.dtpGioKetThuc.Size = new System.Drawing.Size(90, 26);
            this.dtpGioKetThuc.TabIndex = 12;
            this.dtpGioKetThuc.Visible = false;
            // 
            // lblGhiChuCaGay
            // 
            this.lblGhiChuCaGay.ForeColor = System.Drawing.Color.FromArgb(107, 119, 133);
            this.lblGhiChuCaGay.Location = new System.Drawing.Point(440, 100);
            this.lblGhiChuCaGay.Name = "lblGhiChuCaGay";
            this.lblGhiChuCaGay.Size = new System.Drawing.Size(640, 38);
            this.lblGhiChuCaGay.TabIndex = 13;
            this.lblGhiChuCaGay.Text = "Không được trùng giờ với ca khác của cùng vị trí hoặc cùng nhân viên (BR01).";
            this.lblGhiChuCaGay.Visible = false;
            // 
            // dgvLichTruc
            // 
            this.dgvLichTruc.AllowUserToAddRows = false;
            this.dgvLichTruc.AllowUserToDeleteRows = false;
            this.dgvLichTruc.AllowUserToResizeRows = false;
            this.dgvLichTruc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLichTruc.BackgroundColor = System.Drawing.Color.White;
            this.dgvLichTruc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(15, 42, 67);
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(15, 42, 67);
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvLichTruc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLichTruc.ColumnHeadersHeight = 36;
            this.dgvLichTruc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvLichTruc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLichTruc.EnableHeadersVisualStyles = false;
            this.dgvLichTruc.Location = new System.Drawing.Point(0, 60);
            this.dgvLichTruc.MultiSelect = false;
            this.dgvLichTruc.Name = "dgvLichTruc";
            this.dgvLichTruc.ReadOnly = true;
            this.dgvLichTruc.RowHeadersVisible = false;
            this.dgvLichTruc.RowTemplate.Height = 30;
            this.dgvLichTruc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLichTruc.Size = new System.Drawing.Size(1100, 480);
            this.dgvLichTruc.TabIndex = 1;
            this.dgvLichTruc.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvLichTruc_CellFormatting);
            // 
            // FrmLichTruc
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(247, 245, 240);
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.dgvLichTruc);
            this.Controls.Add(this.grpPhanCong);
            this.Controls.Add(this.pnlLoc);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "FrmLichTruc";
            this.Text = "Quản lý lịch trực";
            this.Load += new System.EventHandler(this.FrmLichTruc_Load);
            this.pnlLoc.ResumeLayout(false);
            this.pnlLoc.PerformLayout();
            this.grpPhanCong.ResumeLayout(false);
            this.grpPhanCong.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichTruc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLoc;
        private System.Windows.Forms.Label lblTuNgay;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.Label lblTongSo;
        private System.Windows.Forms.GroupBox grpPhanCong;
        private System.Windows.Forms.Label lblNhanVien;
        private System.Windows.Forms.ComboBox cboNhanVien;
        private System.Windows.Forms.Label lblCa;
        private System.Windows.Forms.ComboBox cboCa;
        private System.Windows.Forms.Label lblViTri;
        private System.Windows.Forms.ComboBox cboViTri;
        private System.Windows.Forms.Label lblNgayTruc;
        private System.Windows.Forms.DateTimePicker dtpNgayTruc;
        private System.Windows.Forms.Button btnPhanCong;
        private System.Windows.Forms.Label lblGioBatDau;
        private System.Windows.Forms.DateTimePicker dtpGioBatDau;
        private System.Windows.Forms.Label lblGioKetThuc;
        private System.Windows.Forms.DateTimePicker dtpGioKetThuc;
        private System.Windows.Forms.Label lblGhiChuCaGay;
        private System.Windows.Forms.DataGridView dgvLichTruc;
    }
}