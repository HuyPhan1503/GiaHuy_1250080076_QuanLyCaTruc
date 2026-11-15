namespace QuanLyCaVanHanh.Forms
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuLichTruc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDiemDanh = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBanGiao = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDonDoiCa = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThongKe = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHeThong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDangXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblNguoiDung = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(15, 42, 67);
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLichTruc,
            this.mnuDiemDanh,
            this.mnuBanGiao,
            this.mnuDonDoiCa,
            this.mnuThongKe,
            this.mnuHeThong});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1200, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuLichTruc
            // 
            this.mnuLichTruc.ForeColor = System.Drawing.Color.White;
            this.mnuLichTruc.Name = "mnuLichTruc";
            this.mnuLichTruc.Size = new System.Drawing.Size(80, 24);
            this.mnuLichTruc.Text = "Lịch trực";
            this.mnuLichTruc.Click += new System.EventHandler(this.mnuLichTruc_Click);
            // 
            // mnuDiemDanh
            // 
            this.mnuDiemDanh.ForeColor = System.Drawing.Color.White;
            this.mnuDiemDanh.Name = "mnuDiemDanh";
            this.mnuDiemDanh.Size = new System.Drawing.Size(89, 24);
            this.mnuDiemDanh.Text = "Điểm danh";
            this.mnuDiemDanh.Click += new System.EventHandler(this.mnuDiemDanh_Click);
            // 
            // mnuBanGiao
            // 
            this.mnuBanGiao.ForeColor = System.Drawing.Color.White;
            this.mnuBanGiao.Name = "mnuBanGiao";
            this.mnuBanGiao.Size = new System.Drawing.Size(90, 24);
            this.mnuBanGiao.Text = "Bàn giao ca";
            this.mnuBanGiao.Click += new System.EventHandler(this.mnuBanGiao_Click);
            // 
            // mnuDonDoiCa
            // 
            this.mnuDonDoiCa.ForeColor = System.Drawing.Color.White;
            this.mnuDonDoiCa.Name = "mnuDonDoiCa";
            this.mnuDonDoiCa.Size = new System.Drawing.Size(168, 24);
            this.mnuDonDoiCa.Text = "Đơn đổi ca / nghỉ phép";
            this.mnuDonDoiCa.Click += new System.EventHandler(this.mnuDonDoiCa_Click);
            // 
            // mnuThongKe
            // 
            this.mnuThongKe.ForeColor = System.Drawing.Color.White;
            this.mnuThongKe.Name = "mnuThongKe";
            this.mnuThongKe.Size = new System.Drawing.Size(79, 24);
            this.mnuThongKe.Text = "Thống kê";
            this.mnuThongKe.Click += new System.EventHandler(this.mnuThongKe_Click);
            // 
            // mnuHeThong
            // 
            this.mnuHeThong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDangXuat,
            this.mnuThoat});
            this.mnuHeThong.ForeColor = System.Drawing.Color.White;
            this.mnuHeThong.Name = "mnuHeThong";
            this.mnuHeThong.Size = new System.Drawing.Size(79, 24);
            this.mnuHeThong.Text = "Hệ thống";
            // 
            // mnuDangXuat
            // 
            this.mnuDangXuat.Name = "mnuDangXuat";
            this.mnuDangXuat.Size = new System.Drawing.Size(150, 26);
            this.mnuDangXuat.Text = "Đăng xuất";
            this.mnuDangXuat.Click += new System.EventHandler(this.mnuDangXuat_Click);
            // 
            // mnuThoat
            // 
            this.mnuThoat.Name = "mnuThoat";
            this.mnuThoat.Size = new System.Drawing.Size(150, 26);
            this.mnuThoat.Text = "Thoát";
            this.mnuThoat.Click += new System.EventHandler(this.mnuThoat_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblNguoiDung});
            this.statusStrip1.Location = new System.Drawing.Point(0, 698);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1200, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblNguoiDung
            // 
            this.lblNguoiDung.Name = "lblNguoiDung";
            this.lblNguoiDung.Size = new System.Drawing.Size(0, 17);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 720);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cổng quản lý ca trực và bàn giao vận hành";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuLichTruc;
        private System.Windows.Forms.ToolStripMenuItem mnuDiemDanh;
        private System.Windows.Forms.ToolStripMenuItem mnuBanGiao;
        private System.Windows.Forms.ToolStripMenuItem mnuDonDoiCa;
        private System.Windows.Forms.ToolStripMenuItem mnuThongKe;
        private System.Windows.Forms.ToolStripMenuItem mnuHeThong;
        private System.Windows.Forms.ToolStripMenuItem mnuDangXuat;
        private System.Windows.Forms.ToolStripMenuItem mnuThoat;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblNguoiDung;
    }
}