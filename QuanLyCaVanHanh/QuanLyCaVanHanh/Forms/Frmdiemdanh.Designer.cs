namespace QuanLyCaVanHanh.Forms
{
    partial class FrmDiemDanh
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblDongHo = new System.Windows.Forms.Label();
            this.btnXem = new System.Windows.Forms.Button();
            this.dtpNgay = new System.Windows.Forms.DateTimePicker();
            this.lblNgay = new System.Windows.Forms.Label();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.btnCheckIn = new System.Windows.Forms.Button();
            this.dgvDiemDanh = new System.Windows.Forms.DataGridView();
            this.timerDongHo = new System.Windows.Forms.Timer(this.components);
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiemDanh)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.lblDongHo);
            this.pnlTop.Controls.Add(this.btnXem);
            this.pnlTop.Controls.Add(this.dtpNgay);
            this.pnlTop.Controls.Add(this.lblNgay);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1100, 60);
            this.pnlTop.TabIndex = 0;
            // 
            // lblNgay
            // 
            this.lblNgay.AutoSize = true;
            this.lblNgay.Location = new System.Drawing.Point(16, 22);
            this.lblNgay.Name = "lblNgay";
            this.lblNgay.Size = new System.Drawing.Size(40, 19);
            this.lblNgay.TabIndex = 0;
            this.lblNgay.Text = "Ngày";
            // 
            // dtpNgay
            // 
            this.dtpNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgay.Location = new System.Drawing.Point(64, 18);
            this.dtpNgay.Name = "dtpNgay";
            this.dtpNgay.Size = new System.Drawing.Size(130, 26);
            this.dtpNgay.TabIndex = 1;
            // 
            // btnXem
            // 
            this.btnXem.BackColor = System.Drawing.Color.FromArgb(14, 124, 134);
            this.btnXem.FlatAppearance.BorderSize = 0;
            this.btnXem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXem.ForeColor = System.Drawing.Color.White;
            this.btnXem.Location = new System.Drawing.Point(214, 14);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(110, 34);
            this.btnXem.TabIndex = 2;
            this.btnXem.Text = "Xem ca trực";
            this.btnXem.UseVisualStyleBackColor = false;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // lblDongHo
            // 
            this.lblDongHo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDongHo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblDongHo.ForeColor = System.Drawing.Color.FromArgb(15, 42, 67);
            this.lblDongHo.Location = new System.Drawing.Point(740, 17);
            this.lblDongHo.Name = "lblDongHo";
            this.lblDongHo.Size = new System.Drawing.Size(344, 26);
            this.lblDongHo.TabIndex = 3;
            this.lblDongHo.Text = "Bây giờ: --:--:--";
            this.lblDongHo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.White;
            this.pnlBottom.Controls.Add(this.lblGhiChu);
            this.pnlBottom.Controls.Add(this.btnCheckOut);
            this.pnlBottom.Controls.Add(this.btnCheckIn);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 570);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1100, 80);
            this.pnlBottom.TabIndex = 2;
            // 
            // btnCheckIn
            // 
            this.btnCheckIn.BackColor = System.Drawing.Color.FromArgb(14, 124, 134);
            this.btnCheckIn.FlatAppearance.BorderSize = 0;
            this.btnCheckIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckIn.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCheckIn.ForeColor = System.Drawing.Color.White;
            this.btnCheckIn.Location = new System.Drawing.Point(16, 16);
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.Size = new System.Drawing.Size(170, 48);
            this.btnCheckIn.TabIndex = 0;
            this.btnCheckIn.Text = "Check-in";
            this.btnCheckIn.UseVisualStyleBackColor = false;
            this.btnCheckIn.Click += new System.EventHandler(this.btnCheckIn_Click);
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.BackColor = System.Drawing.Color.FromArgb(15, 42, 67);
            this.btnCheckOut.FlatAppearance.BorderSize = 0;
            this.btnCheckOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckOut.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCheckOut.ForeColor = System.Drawing.Color.White;
            this.btnCheckOut.Location = new System.Drawing.Point(202, 16);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(170, 48);
            this.btnCheckOut.TabIndex = 1;
            this.btnCheckOut.Text = "Check-out";
            this.btnCheckOut.UseVisualStyleBackColor = false;
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.ForeColor = System.Drawing.Color.FromArgb(107, 119, 133);
            this.lblGhiChu.Location = new System.Drawing.Point(392, 12);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(690, 56);
            this.lblGhiChu.TabIndex = 2;
            this.lblGhiChu.Text = "Check-in sớm tối đa 30 phút trước giờ bắt đầu ca; check-in sau giờ bắt đầu bị ghi \"Đi trễ\" (BR02). " +
    "Check-out trước giờ kết thúc ca bị ghi \"Về sớm\" (BR08).";
            this.lblGhiChu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvDiemDanh
            // 
            this.dgvDiemDanh.AllowUserToAddRows = false;
            this.dgvDiemDanh.AllowUserToDeleteRows = false;
            this.dgvDiemDanh.AllowUserToResizeRows = false;
            this.dgvDiemDanh.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDiemDanh.BackgroundColor = System.Drawing.Color.White;
            this.dgvDiemDanh.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(15, 42, 67);
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(15, 42, 67);
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvDiemDanh.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDiemDanh.ColumnHeadersHeight = 36;
            this.dgvDiemDanh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDiemDanh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDiemDanh.EnableHeadersVisualStyles = false;
            this.dgvDiemDanh.Location = new System.Drawing.Point(0, 60);
            this.dgvDiemDanh.MultiSelect = false;
            this.dgvDiemDanh.Name = "dgvDiemDanh";
            this.dgvDiemDanh.ReadOnly = true;
            this.dgvDiemDanh.RowHeadersVisible = false;
            this.dgvDiemDanh.RowTemplate.Height = 30;
            this.dgvDiemDanh.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDiemDanh.Size = new System.Drawing.Size(1100, 510);
            this.dgvDiemDanh.TabIndex = 1;
            this.dgvDiemDanh.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDiemDanh_CellFormatting);
            this.dgvDiemDanh.SelectionChanged += new System.EventHandler(this.dgvDiemDanh_SelectionChanged);
            // 
            // timerDongHo
            // 
            this.timerDongHo.Interval = 1000;
            this.timerDongHo.Tick += new System.EventHandler(this.timerDongHo_Tick);
            // 
            // FrmDiemDanh
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(247, 245, 240);
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.dgvDiemDanh);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "FrmDiemDanh";
            this.Text = "Điểm danh chuyên cần";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmDiemDanh_FormClosed);
            this.Load += new System.EventHandler(this.FrmDiemDanh_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiemDanh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblDongHo;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.DateTimePicker dtpNgay;
        private System.Windows.Forms.Label lblNgay;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.Button btnCheckOut;
        private System.Windows.Forms.Button btnCheckIn;
        private System.Windows.Forms.DataGridView dgvDiemDanh;
        private System.Windows.Forms.Timer timerDongHo;
    }
}