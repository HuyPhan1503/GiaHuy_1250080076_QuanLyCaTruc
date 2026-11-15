namespace QuanLyCaVanHanh.Forms
{
    partial class FrmDonDoiCa
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
            this.grpGuiDon = new System.Windows.Forms.GroupBox();
            this.lblGhiChuBR06 = new System.Windows.Forms.Label();
            this.btnGuiDon = new System.Windows.Forms.Button();
            this.txtLyDo = new System.Windows.Forms.TextBox();
            this.cboLoaiDon = new System.Windows.Forms.ComboBox();
            this.cboLichTruc = new System.Windows.Forms.ComboBox();
            this.lblLyDo = new System.Windows.Forms.Label();
            this.lblLoaiDon = new System.Windows.Forms.Label();
            this.lblLichTruc = new System.Windows.Forms.Label();
            this.grpDanhSachDon = new System.Windows.Forms.GroupBox();
            this.dgvDonDoiCa = new System.Windows.Forms.DataGridView();
            this.pnlThaoTacDuyet = new System.Windows.Forms.Panel();
            this.btnTaiLai = new System.Windows.Forms.Button();
            this.btnTuChoi = new System.Windows.Forms.Button();
            this.btnDuyet = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.grpGuiDon.SuspendLayout();
            this.grpDanhSachDon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonDoiCa)).BeginInit();
            this.pnlThaoTacDuyet.SuspendLayout();
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
            this.lblHeaderTitle.Size = new System.Drawing.Size(397, 25);
            this.lblHeaderTitle.TabIndex = 0;
            this.lblHeaderTitle.Text = "ĐĂNG KÝ VÀ PHÊ DUYỆT ĐỔI CA / NGHỈ PHÉP";
            // 
            // grpGuiDon
            // 
            this.grpGuiDon.Controls.Add(this.lblGhiChuBR06);
            this.grpGuiDon.Controls.Add(this.btnGuiDon);
            this.grpGuiDon.Controls.Add(this.txtLyDo);
            this.grpGuiDon.Controls.Add(this.cboLoaiDon);
            this.grpGuiDon.Controls.Add(this.cboLichTruc);
            this.grpGuiDon.Controls.Add(this.lblLyDo);
            this.grpGuiDon.Controls.Add(this.lblLoaiDon);
            this.grpGuiDon.Controls.Add(this.lblLichTruc);
            this.grpGuiDon.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpGuiDon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpGuiDon.Location = new System.Drawing.Point(10, 60);
            this.grpGuiDon.Name = "grpGuiDon";
            this.grpGuiDon.Padding = new System.Windows.Forms.Padding(10);
            this.grpGuiDon.Size = new System.Drawing.Size(1080, 160);
            this.grpGuiDon.TabIndex = 1;
            this.grpGuiDon.TabStop = false;
            this.grpGuiDon.Text = "Gửi đơn mới (UC09, UC10)";
            // 
            // lblGhiChuBR06
            // 
            this.lblGhiChuBR06.AutoSize = true;
            this.lblGhiChuBR06.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblGhiChuBR06.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(64)))), ((int)(((byte)(43)))));
            this.lblGhiChuBR06.Location = new System.Drawing.Point(110, 132);
            this.lblGhiChuBR06.Name = "lblGhiChuBR06";
            this.lblGhiChuBR06.Size = new System.Drawing.Size(438, 15);
            this.lblGhiChuBR06.TabIndex = 7;
            this.lblGhiChuBR06.Text = "* Quy tắc BR06: Đơn phải được gửi trước giờ bắt đầu ca tối thiểu 24 giờ để xét duyệt.";
            // 
            // btnGuiDon
            // 
            this.btnGuiDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(42)))), ((int)(((byte)(67)))));
            this.btnGuiDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuiDon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuiDon.ForeColor = System.Drawing.Color.White;
            this.btnGuiDon.Location = new System.Drawing.Point(915, 30);
            this.btnGuiDon.Name = "btnGuiDon";
            this.btnGuiDon.Size = new System.Drawing.Size(145, 95);
            this.btnGuiDon.TabIndex = 6;
            this.btnGuiDon.Text = "GỬI ĐƠN";
            this.btnGuiDon.UseVisualStyleBackColor = false;
            this.btnGuiDon.Click += new System.EventHandler(this.btnGuiDon_Click);
            // 
            // txtLyDo
            // 
            this.txtLyDo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtLyDo.Location = new System.Drawing.Point(110, 70);
            this.txtLyDo.Multiline = true;
            this.txtLyDo.Name = "txtLyDo";
            this.txtLyDo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLyDo.Size = new System.Drawing.Size(785, 55);
            this.txtLyDo.TabIndex = 5;
            // 
            // cboLoaiDon
            // 
            this.cboLoaiDon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiDon.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboLoaiDon.FormattingEnabled = true;
            this.cboLoaiDon.Items.AddRange(new object[] {
            "Đổi ca",
            "Nghỉ phép"});
            this.cboLoaiDon.Location = new System.Drawing.Point(620, 30);
            this.cboLoaiDon.Name = "cboLoaiDon";
            this.cboLoaiDon.Size = new System.Drawing.Size(275, 25);
            this.cboLoaiDon.TabIndex = 3;
            // 
            // cboLichTruc
            // 
            this.cboLichTruc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLichTruc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboLichTruc.FormattingEnabled = true;
            this.cboLichTruc.Location = new System.Drawing.Point(110, 30);
            this.cboLichTruc.Name = "cboLichTruc";
            this.cboLichTruc.Size = new System.Drawing.Size(415, 25);
            this.cboLichTruc.TabIndex = 1;
            // 
            // lblLyDo
            // 
            this.lblLyDo.AutoSize = true;
            this.lblLyDo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblLyDo.Location = new System.Drawing.Point(15, 73);
            this.lblLyDo.Name = "lblLyDo";
            this.lblLyDo.Size = new System.Drawing.Size(45, 19);
            this.lblLyDo.TabIndex = 4;
            this.lblLyDo.Text = "Lý do:";
            // 
            // lblLoaiDon
            // 
            this.lblLoaiDon.AutoSize = true;
            this.lblLoaiDon.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblLoaiDon.Location = new System.Drawing.Point(545, 33);
            this.lblLoaiDon.Name = "lblLoaiDon";
            this.lblLoaiDon.Size = new System.Drawing.Size(63, 19);
            this.lblLoaiDon.TabIndex = 2;
            this.lblLoaiDon.Text = "Loại đơn:";
            // 
            // lblLichTruc
            // 
            this.lblLichTruc.AutoSize = true;
            this.lblLichTruc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblLichTruc.Location = new System.Drawing.Point(15, 33);
            this.lblLichTruc.Name = "lblLichTruc";
            this.lblLichTruc.Size = new System.Drawing.Size(65, 19);
            this.lblLichTruc.TabIndex = 0;
            this.lblLichTruc.Text = "Chọn ca:";
            // 
            // grpDanhSachDon
            // 
            this.grpDanhSachDon.Controls.Add(this.dgvDonDoiCa);
            this.grpDanhSachDon.Controls.Add(this.pnlThaoTacDuyet);
            this.grpDanhSachDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDanhSachDon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpDanhSachDon.Location = new System.Drawing.Point(10, 220);
            this.grpDanhSachDon.Name = "grpDanhSachDon";
            this.grpDanhSachDon.Padding = new System.Windows.Forms.Padding(10);
            this.grpDanhSachDon.Size = new System.Drawing.Size(1080, 420);
            this.grpDanhSachDon.TabIndex = 2;
            this.grpDanhSachDon.TabStop = false;
            this.grpDanhSachDon.Text = "Danh sách đơn đăng ký (UC11)";
            // 
            // dgvDonDoiCa
            // 
            this.dgvDonDoiCa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDonDoiCa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDonDoiCa.Location = new System.Drawing.Point(10, 28);
            this.dgvDonDoiCa.Name = "dgvDonDoiCa";
            this.dgvDonDoiCa.Size = new System.Drawing.Size(1060, 332);
            this.dgvDonDoiCa.TabIndex = 0;
            // 
            // pnlThaoTacDuyet
            // 
            this.pnlThaoTacDuyet.Controls.Add(this.btnTaiLai);
            this.pnlThaoTacDuyet.Controls.Add(this.btnTuChoi);
            this.pnlThaoTacDuyet.Controls.Add(this.btnDuyet);
            this.pnlThaoTacDuyet.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlThaoTacDuyet.Location = new System.Drawing.Point(10, 360);
            this.pnlThaoTacDuyet.Name = "pnlThaoTacDuyet";
            this.pnlThaoTacDuyet.Size = new System.Drawing.Size(1060, 50);
            this.pnlThaoTacDuyet.TabIndex = 1;
            // 
            // btnTaiLai
            // 
            this.btnTaiLai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(124)))), ((int)(((byte)(134)))));
            this.btnTaiLai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaiLai.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTaiLai.ForeColor = System.Drawing.Color.White;
            this.btnTaiLai.Location = new System.Drawing.Point(310, 10);
            this.btnTaiLai.Name = "btnTaiLai";
            this.btnTaiLai.Size = new System.Drawing.Size(120, 35);
            this.btnTaiLai.TabIndex = 2;
            this.btnTaiLai.Text = "Tải lại";
            this.btnTaiLai.UseVisualStyleBackColor = false;
            this.btnTaiLai.Click += new System.EventHandler(this.btnTaiLai_Click);
            // 
            // btnTuChoi
            // 
            this.btnTuChoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(64)))), ((int)(((byte)(43)))));
            this.btnTuChoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTuChoi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTuChoi.ForeColor = System.Drawing.Color.White;
            this.btnTuChoi.Location = new System.Drawing.Point(160, 10);
            this.btnTuChoi.Name = "btnTuChoi";
            this.btnTuChoi.Size = new System.Drawing.Size(135, 35);
            this.btnTuChoi.TabIndex = 1;
            this.btnTuChoi.Text = "Từ Chối";
            this.btnTuChoi.UseVisualStyleBackColor = false;
            this.btnTuChoi.Click += new System.EventHandler(this.btnTuChoi_Click);
            // 
            // btnDuyet
            // 
            this.btnDuyet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(42)))), ((int)(((byte)(67)))));
            this.btnDuyet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDuyet.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDuyet.ForeColor = System.Drawing.Color.White;
            this.btnDuyet.Location = new System.Drawing.Point(10, 10);
            this.btnDuyet.Name = "btnDuyet";
            this.btnDuyet.Size = new System.Drawing.Size(135, 35);
            this.btnDuyet.TabIndex = 0;
            this.btnDuyet.Text = "Phê Duyệt";
            this.btnDuyet.UseVisualStyleBackColor = false;
            this.btnDuyet.Click += new System.EventHandler(this.btnDuyet_Click);
            // 
            // FrmDonDoiCa
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(245)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.grpDanhSachDon);
            this.Controls.Add(this.grpGuiDon);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmDonDoiCa";
            this.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.Text = "Đơn đổi ca / Nghỉ phép";
            this.Load += new System.EventHandler(this.FrmDonDoiCa_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.grpGuiDon.ResumeLayout(false);
            this.grpGuiDon.PerformLayout();
            this.grpDanhSachDon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonDoiCa)).EndInit();
            this.pnlThaoTacDuyet.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.GroupBox grpGuiDon;
        private System.Windows.Forms.ComboBox cboLoaiDon;
        private System.Windows.Forms.ComboBox cboLichTruc;
        private System.Windows.Forms.Label lblLyDo;
        private System.Windows.Forms.Label lblLoaiDon;
        private System.Windows.Forms.Label lblLichTruc;
        private System.Windows.Forms.TextBox txtLyDo;
        private System.Windows.Forms.Button btnGuiDon;
        private System.Windows.Forms.Label lblGhiChuBR06;
        private System.Windows.Forms.GroupBox grpDanhSachDon;
        private System.Windows.Forms.DataGridView dgvDonDoiCa;
        private System.Windows.Forms.Panel pnlThaoTacDuyet;
        private System.Windows.Forms.Button btnDuyet;
        private System.Windows.Forms.Button btnTuChoi;
        private System.Windows.Forms.Button btnTaiLai;
    }
}