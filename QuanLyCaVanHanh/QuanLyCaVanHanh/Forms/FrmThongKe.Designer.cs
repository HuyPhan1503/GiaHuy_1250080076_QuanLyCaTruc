namespace QuanLyCaVanHanh.Forms
{
    partial class FrmThongKe
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.pnlTongQuan = new System.Windows.Forms.Panel();
            this.pnlCardTonDong = new System.Windows.Forms.Panel();
            this.lblTonDongVal = new System.Windows.Forms.Label();
            this.lblTonDongTitle = new System.Windows.Forms.Label();
            this.pnlCardChoXacNhan = new System.Windows.Forms.Panel();
            this.lblChoXacNhanVal = new System.Windows.Forms.Label();
            this.lblChoXacNhanTitle = new System.Windows.Forms.Label();
            this.pnlCardDaKhoa = new System.Windows.Forms.Panel();
            this.lblDaKhoaVal = new System.Windows.Forms.Label();
            this.lblDaKhoaTitle = new System.Windows.Forms.Label();
            this.spcDetails = new System.Windows.Forms.SplitContainer();
            this.grpChuyenCan = new System.Windows.Forms.GroupBox();
            this.dgvChuyenCan = new System.Windows.Forms.DataGridView();
            this.grpSuCo = new System.Windows.Forms.GroupBox();
            this.dgvSuCo = new System.Windows.Forms.DataGridView();
            this.pnlHeader.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.pnlTongQuan.SuspendLayout();
            this.pnlCardTonDong.SuspendLayout();
            this.pnlCardChoXacNhan.SuspendLayout();
            this.pnlCardDaKhoa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcDetails)).BeginInit();
            this.spcDetails.Panel1.SuspendLayout();
            this.spcDetails.Panel2.SuspendLayout();
            this.spcDetails.SuspendLayout();
            this.grpChuyenCan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChuyenCan)).BeginInit();
            this.grpSuCo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuCo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(42)))), ((int)(((byte)(67)))));
            this.pnlHeader.Controls.Add(this.lblHeaderTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1100, 50);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeaderTitle.Location = new System.Drawing.Point(15, 12);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(434, 25);
            this.lblHeaderTitle.TabIndex = 0;
            this.lblHeaderTitle.Text = "BÁO CÁO THỐNG KÊ VẬN HÀNH CA TRỰC (UC12)";
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.btnThongKe);
            this.pnlFilter.Controls.Add(this.dtpDenNgay);
            this.pnlFilter.Controls.Add(this.dtpTuNgay);
            this.pnlFilter.Controls.Add(this.lblDenNgay);
            this.pnlFilter.Controls.Add(this.lblTuNgay);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 50);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1100, 50);
            this.pnlFilter.TabIndex = 1;
            // 
            // btnThongKe
            // 
            this.btnThongKe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(42)))), ((int)(((byte)(67)))));
            this.btnThongKe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongKe.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnThongKe.ForeColor = System.Drawing.Color.White;
            this.btnThongKe.Location = new System.Drawing.Point(535, 10);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(130, 30);
            this.btnThongKe.TabIndex = 4;
            this.btnThongKe.Text = "Xem Báo Cáo";
            this.btnThongKe.UseVisualStyleBackColor = false;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDenNgay.Location = new System.Drawing.Point(365, 12);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(140, 25);
            this.dtpDenNgay.TabIndex = 3;
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTuNgay.Location = new System.Drawing.Point(100, 12);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(140, 25);
            this.dtpTuNgay.TabIndex = 1;
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDenNgay.Location = new System.Drawing.Point(280, 15);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(75, 19);
            this.lblDenNgay.TabIndex = 2;
            this.lblDenNgay.Text = "Đến ngày:";
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTuNgay.Location = new System.Drawing.Point(20, 15);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(67, 19);
            this.lblTuNgay.TabIndex = 0;
            this.lblTuNgay.Text = "Từ ngày:";
            // 
            // pnlTongQuan
            // 
            this.pnlTongQuan.Controls.Add(this.pnlCardTonDong);
            this.pnlTongQuan.Controls.Add(this.pnlCardChoXacNhan);
            this.pnlTongQuan.Controls.Add(this.pnlCardDaKhoa);
            this.pnlTongQuan.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTongQuan.Location = new System.Drawing.Point(0, 100);
            this.pnlTongQuan.Name = "pnlTongQuan";
            this.pnlTongQuan.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.pnlTongQuan.Size = new System.Drawing.Size(1100, 90);
            this.pnlTongQuan.TabIndex = 2;
            // 
            // pnlCardTonDong
            // 
            this.pnlCardTonDong.BackColor = System.Drawing.Color.White;
            this.pnlCardTonDong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCardTonDong.Controls.Add(this.lblTonDongVal);
            this.pnlCardTonDong.Controls.Add(this.lblTonDongTitle);
            this.pnlCardTonDong.Location = new System.Drawing.Point(730, 10);
            this.pnlCardTonDong.Name = "pnlCardTonDong";
            this.pnlCardTonDong.Size = new System.Drawing.Size(340, 70);
            this.pnlCardTonDong.TabIndex = 2;
            // 
            // lblTonDongVal
            // 
            this.lblTonDongVal.AutoSize = true;
            this.lblTonDongVal.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTonDongVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(64)))), ((int)(((byte)(43)))));
            this.lblTonDongVal.Location = new System.Drawing.Point(15, 30);
            this.lblTonDongVal.Name = "lblTonDongVal";
            this.lblTonDongVal.Size = new System.Drawing.Size(28, 32);
            this.lblTonDongVal.TabIndex = 1;
            this.lblTonDongVal.Text = "0";
            // 
            // lblTonDongTitle
            // 
            this.lblTonDongTitle.AutoSize = true;
            this.lblTonDongTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTonDongTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblTonDongTitle.Location = new System.Drawing.Point(15, 8);
            this.lblTonDongTitle.Name = "lblTonDongTitle";
            this.lblTonDongTitle.Size = new System.Drawing.Size(193, 17);
            this.lblTonDongTitle.TabIndex = 0;
            this.lblTonDongTitle.Text = "CÔNG VIỆC TỒN ĐỌNG CHƯA XỬ LÝ";
            // 
            // pnlCardChoXacNhan
            // 
            this.pnlCardChoXacNhan.BackColor = System.Drawing.Color.White;
            this.pnlCardChoXacNhan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCardChoXacNhan.Controls.Add(this.lblChoXacNhanVal);
            this.pnlCardChoXacNhan.Controls.Add(this.lblChoXacNhanTitle);
            this.pnlCardChoXacNhan.Location = new System.Drawing.Point(370, 10);
            this.pnlCardChoXacNhan.Name = "pnlCardChoXacNhan";
            this.pnlCardChoXacNhan.Size = new System.Drawing.Size(340, 70);
            this.pnlCardChoXacNhan.TabIndex = 1;
            // 
            // lblChoXacNhanVal
            // 
            this.lblChoXacNhanVal.AutoSize = true;
            this.lblChoXacNhanVal.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblChoXacNhanVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(124)))), ((int)(((byte)(134)))));
            this.lblChoXacNhanVal.Location = new System.Drawing.Point(15, 30);
            this.lblChoXacNhanVal.Name = "lblChoXacNhanVal";
            this.lblChoXacNhanVal.Size = new System.Drawing.Size(28, 32);
            this.lblChoXacNhanVal.TabIndex = 1;
            this.lblChoXacNhanVal.Text = "0";
            // 
            // lblChoXacNhanTitle
            // 
            this.lblChoXacNhanTitle.AutoSize = true;
            this.lblChoXacNhanTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblChoXacNhanTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblChoXacNhanTitle.Location = new System.Drawing.Point(15, 8);
            this.lblChoXacNhanTitle.Name = "lblChoXacNhanTitle";
            this.lblChoXacNhanTitle.Size = new System.Drawing.Size(182, 17);
            this.lblChoXacNhanTitle.TabIndex = 0;
            this.lblChoXacNhanTitle.Text = "BIÊN BẢN CHỜ XÁC NHẬN";
            // 
            // pnlCardDaKhoa
            // 
            this.pnlCardDaKhoa.BackColor = System.Drawing.Color.White;
            this.pnlCardDaKhoa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCardDaKhoa.Controls.Add(this.lblDaKhoaVal);
            this.pnlCardDaKhoa.Controls.Add(this.lblDaKhoaTitle);
            this.pnlCardDaKhoa.Location = new System.Drawing.Point(10, 10);
            this.pnlCardDaKhoa.Name = "pnlCardDaKhoa";
            this.pnlCardDaKhoa.Size = new System.Drawing.Size(340, 70);
            this.pnlCardDaKhoa.TabIndex = 0;
            // 
            // lblDaKhoaVal
            // 
            this.lblDaKhoaVal.AutoSize = true;
            this.lblDaKhoaVal.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblDaKhoaVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(42)))), ((int)(((byte)(67)))));
            this.lblDaKhoaVal.Location = new System.Drawing.Point(15, 30);
            this.lblDaKhoaVal.Name = "lblDaKhoaVal";
            this.lblDaKhoaVal.Size = new System.Drawing.Size(28, 32);
            this.lblDaKhoaVal.TabIndex = 1;
            this.lblDaKhoaVal.Text = "0";
            // 
            // lblDaKhoaTitle
            // 
            this.lblDaKhoaTitle.AutoSize = true;
            this.lblDaKhoaTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDaKhoaTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblDaKhoaTitle.Location = new System.Drawing.Point(15, 8);
            this.lblDaKhoaTitle.Name = "lblDaKhoaTitle";
            this.lblDaKhoaTitle.Size = new System.Drawing.Size(188, 17);
            this.lblDaKhoaTitle.TabIndex = 0;
            this.lblDaKhoaTitle.Text = "BIÊN BẢN ĐÃ KHÓA (BR05)";
            // 
            // spcDetails
            // 
            this.spcDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcDetails.Location = new System.Drawing.Point(0, 190);
            this.spcDetails.Name = "spcDetails";
            // 
            // spcDetails.Panel1
            // 
            this.spcDetails.Panel1.Controls.Add(this.grpChuyenCan);
            this.spcDetails.Panel1.Padding = new System.Windows.Forms.Padding(10);
            // 
            // spcDetails.Panel2
            // 
            this.spcDetails.Panel2.Controls.Add(this.grpSuCo);
            this.spcDetails.Panel2.Padding = new System.Windows.Forms.Padding(10);
            this.spcDetails.Size = new System.Drawing.Size(1100, 460);
            this.spcDetails.SplitterDistance = 680;
            this.spcDetails.TabIndex = 3;
            // 
            // grpChuyenCan
            // 
            this.grpChuyenCan.Controls.Add(this.dgvChuyenCan);
            this.grpChuyenCan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpChuyenCan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpChuyenCan.Location = new System.Drawing.Point(10, 10);
            this.grpChuyenCan.Name = "grpChuyenCan";
            this.grpChuyenCan.Size = new System.Drawing.Size(660, 440);
            this.grpChuyenCan.TabIndex = 0;
            this.grpChuyenCan.TabStop = false;
            this.grpChuyenCan.Text = "Báo cáo chuyên cần theo nhân viên";
            // 
            // dgvChuyenCan
            // 
            this.dgvChuyenCan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChuyenCan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChuyenCan.Location = new System.Drawing.Point(3, 21);
            this.dgvChuyenCan.Name = "dgvChuyenCan";
            this.dgvChuyenCan.Size = new System.Drawing.Size(654, 416);
            this.dgvChuyenCan.TabIndex = 0;
            // 
            // grpSuCo
            // 
            this.grpSuCo.Controls.Add(this.dgvSuCo);
            this.grpSuCo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSuCo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpSuCo.Location = new System.Drawing.Point(10, 10);
            this.grpSuCo.Name = "grpSuCo";
            this.grpSuCo.Size = new System.Drawing.Size(396, 440);
            this.grpSuCo.TabIndex = 0;
            this.grpSuCo.TabStop = false;
            this.grpSuCo.Text = "Thống kê sự cố theo mức độ";
            // 
            // dgvSuCo
            // 
            this.dgvSuCo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSuCo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSuCo.Location = new System.Drawing.Point(3, 21);
            this.dgvSuCo.Name = "dgvSuCo";
            this.dgvSuCo.Size = new System.Drawing.Size(390, 416);
            this.dgvSuCo.TabIndex = 0;
            // 
            // FrmThongKe
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(245)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.spcDetails);
            this.Controls.Add(this.pnlTongQuan);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmThongKe";
            this.Text = "Báo cáo thống kê";
            this.Load += new System.EventHandler(this.FrmThongKe_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.pnlTongQuan.ResumeLayout(false);
            this.pnlCardTonDong.ResumeLayout(false);
            this.pnlCardTonDong.PerformLayout();
            this.pnlCardChoXacNhan.ResumeLayout(false);
            this.pnlCardChoXacNhan.PerformLayout();
            this.pnlCardDaKhoa.ResumeLayout(false);
            this.pnlCardDaKhoa.PerformLayout();
            this.spcDetails.Panel1.ResumeLayout(false);
            this.spcDetails.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcDetails)).EndInit();
            this.spcDetails.ResumeLayout(false);
            this.grpChuyenCan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChuyenCan)).EndInit();
            this.grpSuCo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuCo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Label lblTuNgay;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Panel pnlTongQuan;
        private System.Windows.Forms.Panel pnlCardDaKhoa;
        private System.Windows.Forms.Label lblDaKhoaTitle;
        private System.Windows.Forms.Label lblDaKhoaVal;
        private System.Windows.Forms.Panel pnlCardChoXacNhan;
        private System.Windows.Forms.Label lblChoXacNhanVal;
        private System.Windows.Forms.Label lblChoXacNhanTitle;
        private System.Windows.Forms.Panel pnlCardTonDong;
        private System.Windows.Forms.Label lblTonDongVal;
        private System.Windows.Forms.Label lblTonDongTitle;
        private System.Windows.Forms.SplitContainer spcDetails;
        private System.Windows.Forms.GroupBox grpChuyenCan;
        private System.Windows.Forms.DataGridView dgvChuyenCan;
        private System.Windows.Forms.GroupBox grpSuCo;
        private System.Windows.Forms.DataGridView dgvSuCo;
    }
}