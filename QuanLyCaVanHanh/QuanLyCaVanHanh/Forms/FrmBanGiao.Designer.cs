namespace QuanLyCaVanHanh.Forms
{
    partial class FrmBanGiao
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
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabNhatKy = new System.Windows.Forms.TabPage();
            this.grpGhiNhatKy = new System.Windows.Forms.GroupBox();
            this.btnGhiNhatKy = new System.Windows.Forms.Button();
            this.txtNoiDungNhatKy = new System.Windows.Forms.TextBox();
            this.cboMucDo = new System.Windows.Forms.ComboBox();
            this.cboLoaiNhatKy = new System.Windows.Forms.ComboBox();
            this.lblNoiDung = new System.Windows.Forms.Label();
            this.lblMucDo = new System.Windows.Forms.Label();
            this.lblLoaiNhatKy = new System.Windows.Forms.Label();
            this.dgvNhatKy = new System.Windows.Forms.DataGridView();
            this.pnlTopNK = new System.Windows.Forms.Panel();
            this.btnTaiLai = new System.Windows.Forms.Button();
            this.cboCaTrucHomNay = new System.Windows.Forms.ComboBox();
            this.lblSelectCa = new System.Windows.Forms.Label();
            this.tabLapBienBan = new System.Windows.Forms.TabPage();
            this.pnlLapBG = new System.Windows.Forms.Panel();
            this.lblGhiChuBR04 = new System.Windows.Forms.Label();
            this.btnLapBienBan = new System.Windows.Forms.Button();
            this.txtNoiDungTongKet = new System.Windows.Forms.TextBox();
            this.lblNoiDungTongKet = new System.Windows.Forms.Label();
            this.lblCaGiaoInfoVal = new System.Windows.Forms.Label();
            this.lblCaGiaoInfo = new System.Windows.Forms.Label();
            this.tabBanGiaoAndTonDong = new System.Windows.Forms.TabPage();
            this.spcBanGiao = new System.Windows.Forms.SplitContainer();
            this.grpBanGiao = new System.Windows.Forms.GroupBox();
            this.dgvBanGiao = new System.Windows.Forms.DataGridView();
            this.pnlXacNhan = new System.Windows.Forms.Panel();
            this.btnXacNhanNhanCa = new System.Windows.Forms.Button();
            this.cboCaNhan = new System.Windows.Forms.ComboBox();
            this.lblCaNhan = new System.Windows.Forms.Label();
            this.grpTonDong = new System.Windows.Forms.GroupBox();
            this.dgvTonDong = new System.Windows.Forms.DataGridView();
            this.pnlHeader.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabNhatKy.SuspendLayout();
            this.grpGhiNhatKy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhatKy)).BeginInit();
            this.pnlTopNK.SuspendLayout();
            this.tabLapBienBan.SuspendLayout();
            this.pnlLapBG.SuspendLayout();
            this.tabBanGiaoAndTonDong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcBanGiao)).BeginInit();
            this.spcBanGiao.Panel1.SuspendLayout();
            this.spcBanGiao.Panel2.SuspendLayout();
            this.spcBanGiao.SuspendLayout();
            this.grpBanGiao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBanGiao)).BeginInit();
            this.pnlXacNhan.SuspendLayout();
            this.grpTonDong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTonDong)).BeginInit();
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
            this.lblHeaderTitle.Size = new System.Drawing.Size(462, 25);
            this.lblHeaderTitle.TabIndex = 0;
            this.lblHeaderTitle.Text = "QUẢN LÝ NHẬT KÝ CA VÀ BÀN GIAO VẬN HÀNH";
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabNhatKy);
            this.tabMain.Controls.Add(this.tabLapBienBan);
            this.tabMain.Controls.Add(this.tabBanGiaoAndTonDong);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.tabMain.Location = new System.Drawing.Point(0, 50);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1100, 600);
            this.tabMain.TabIndex = 1;
            // 
            // tabNhatKy
            // 
            this.tabNhatKy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(245)))), ((int)(((byte)(240)))));
            this.tabNhatKy.Controls.Add(this.grpGhiNhatKy);
            this.tabNhatKy.Controls.Add(this.dgvNhatKy);
            this.tabNhatKy.Controls.Add(this.pnlTopNK);
            this.tabNhatKy.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabNhatKy.Location = new System.Drawing.Point(4, 26);
            this.tabNhatKy.Name = "tabNhatKy";
            this.tabNhatKy.Padding = new System.Windows.Forms.Padding(10);
            this.tabNhatKy.Size = new System.Drawing.Size(1092, 570);
            this.tabNhatKy.TabIndex = 0;
            this.tabNhatKy.Text = "1. Nhật ký ca hiện tại";
            // 
            // grpGhiNhatKy
            // 
            this.grpGhiNhatKy.Controls.Add(this.btnGhiNhatKy);
            this.grpGhiNhatKy.Controls.Add(this.txtNoiDungNhatKy);
            this.grpGhiNhatKy.Controls.Add(this.cboMucDo);
            this.grpGhiNhatKy.Controls.Add(this.cboLoaiNhatKy);
            this.grpGhiNhatKy.Controls.Add(this.lblNoiDung);
            this.grpGhiNhatKy.Controls.Add(this.lblMucDo);
            this.grpGhiNhatKy.Controls.Add(this.lblLoaiNhatKy);
            this.grpGhiNhatKy.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpGhiNhatKy.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpGhiNhatKy.Location = new System.Drawing.Point(10, 390);
            this.grpGhiNhatKy.Name = "grpGhiNhatKy";
            this.grpGhiNhatKy.Size = new System.Drawing.Size(1072, 170);
            this.grpGhiNhatKy.TabIndex = 2;
            this.grpGhiNhatKy.TabStop = false;
            this.grpGhiNhatKy.Text = "Ghi nhật ký / Báo cáo sự cố mới (UC08)";
            // 
            // btnGhiNhatKy
            // 
            this.btnGhiNhatKy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(42)))), ((int)(((byte)(67)))));
            this.btnGhiNhatKy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGhiNhatKy.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGhiNhatKy.ForeColor = System.Drawing.Color.White;
            this.btnGhiNhatKy.Location = new System.Drawing.Point(920, 30);
            this.btnGhiNhatKy.Name = "btnGhiNhatKy";
            this.btnGhiNhatKy.Size = new System.Drawing.Size(135, 125);
            this.btnGhiNhatKy.TabIndex = 6;
            this.btnGhiNhatKy.Text = "Lưu Nhật Ký";
            this.btnGhiNhatKy.UseVisualStyleBackColor = false;
            this.btnGhiNhatKy.Click += new System.EventHandler(this.btnGhiNhatKy_Click);
            // 
            // txtNoiDungNhatKy
            // 
            this.txtNoiDungNhatKy.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNoiDungNhatKy.Location = new System.Drawing.Point(105, 70);
            this.txtNoiDungNhatKy.Multiline = true;
            this.txtNoiDungNhatKy.Name = "txtNoiDungNhatKy";
            this.txtNoiDungNhatKy.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNoiDungNhatKy.Size = new System.Drawing.Size(795, 85);
            this.txtNoiDungNhatKy.TabIndex = 5;
            // 
            // cboMucDo
            // 
            this.cboMucDo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMucDo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboMucDo.FormattingEnabled = true;
            this.cboMucDo.Items.AddRange(new object[] {
            "Thấp",
            "Trung bình",
            "Cao",
            "Khẩn cấp"});
            this.cboMucDo.Location = new System.Drawing.Point(420, 30);
            this.cboMucDo.Name = "cboMucDo";
            this.cboMucDo.Size = new System.Drawing.Size(180, 25);
            this.cboMucDo.TabIndex = 3;
            // 
            // cboLoaiNhatKy
            // 
            this.cboLoaiNhatKy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiNhatKy.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboLoaiNhatKy.FormattingEnabled = true;
            this.cboLoaiNhatKy.Items.AddRange(new object[] {
            "Vận hành",
            "Sự cố"});
            this.cboLoaiNhatKy.Location = new System.Drawing.Point(105, 30);
            this.cboLoaiNhatKy.Name = "cboLoaiNhatKy";
            this.cboLoaiNhatKy.Size = new System.Drawing.Size(180, 25);
            this.cboLoaiNhatKy.TabIndex = 1;
            this.cboLoaiNhatKy.SelectedIndexChanged += new System.EventHandler(this.cboLoaiNhatKy_SelectedIndexChanged);
            // 
            // lblNoiDung
            // 
            this.lblNoiDung.AutoSize = true;
            this.lblNoiDung.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNoiDung.Location = new System.Drawing.Point(15, 73);
            this.lblNoiDung.Name = "lblNoiDung";
            this.lblNoiDung.Size = new System.Drawing.Size(68, 19);
            this.lblNoiDung.TabIndex = 4;
            this.lblNoiDung.Text = "Nội dung:";
            // 
            // lblMucDo
            // 
            this.lblMucDo.AutoSize = true;
            this.lblMucDo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMucDo.Location = new System.Drawing.Point(340, 33);
            this.lblMucDo.Name = "lblMucDo";
            this.lblMucDo.Size = new System.Drawing.Size(60, 19);
            this.lblMucDo.TabIndex = 2;
            this.lblMucDo.Text = "Mức độ:";
            // 
            // lblLoaiNhatKy
            // 
            this.lblLoaiNhatKy.AutoSize = true;
            this.lblLoaiNhatKy.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblLoaiNhatKy.Location = new System.Drawing.Point(15, 33);
            this.lblLoaiNhatKy.Name = "lblLoaiNhatKy";
            this.lblLoaiNhatKy.Size = new System.Drawing.Size(86, 19);
            this.lblLoaiNhatKy.TabIndex = 0;
            this.lblLoaiNhatKy.Text = "Loại nhật ký:";
            // 
            // dgvNhatKy
            // 
            this.dgvNhatKy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNhatKy.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvNhatKy.Location = new System.Drawing.Point(10, 55);
            this.dgvNhatKy.Name = "dgvNhatKy";
            this.dgvNhatKy.Size = new System.Drawing.Size(1072, 325);
            this.dgvNhatKy.TabIndex = 1;
            // 
            // pnlTopNK
            // 
            this.pnlTopNK.Controls.Add(this.btnTaiLai);
            this.pnlTopNK.Controls.Add(this.cboCaTrucHomNay);
            this.pnlTopNK.Controls.Add(this.lblSelectCa);
            this.pnlTopNK.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopNK.Location = new System.Drawing.Point(10, 10);
            this.pnlTopNK.Name = "pnlTopNK";
            this.pnlTopNK.Size = new System.Drawing.Size(1072, 45);
            this.pnlTopNK.TabIndex = 0;
            // 
            // btnTaiLai
            // 
            this.btnTaiLai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(124)))), ((int)(((byte)(134)))));
            this.btnTaiLai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaiLai.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnTaiLai.ForeColor = System.Drawing.Color.White;
            this.btnTaiLai.Location = new System.Drawing.Point(540, 6);
            this.btnTaiLai.Name = "btnTaiLai";
            this.btnTaiLai.Size = new System.Drawing.Size(110, 30);
            this.btnTaiLai.TabIndex = 2;
            this.btnTaiLai.Text = "Tải dữ liệu";
            this.btnTaiLai.UseVisualStyleBackColor = false;
            this.btnTaiLai.Click += new System.EventHandler(this.btnTaiLai_Click);
            // 
            // cboCaTrucHomNay
            // 
            this.cboCaTrucHomNay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCaTrucHomNay.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboCaTrucHomNay.FormattingEnabled = true;
            this.cboCaTrucHomNay.Location = new System.Drawing.Point(165, 9);
            this.cboCaTrucHomNay.Name = "cboCaTrucHomNay";
            this.cboCaTrucHomNay.Size = new System.Drawing.Size(355, 25);
            this.cboCaTrucHomNay.TabIndex = 1;
            this.cboCaTrucHomNay.SelectedIndexChanged += new System.EventHandler(this.cboCaTrucHomNay_SelectedIndexChanged);
            // 
            // lblSelectCa
            // 
            this.lblSelectCa.AutoSize = true;
            this.lblSelectCa.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSelectCa.Location = new System.Drawing.Point(5, 12);
            this.lblSelectCa.Name = "lblSelectCa";
            this.lblSelectCa.Size = new System.Drawing.Size(154, 19);
            this.lblSelectCa.TabIndex = 0;
            this.lblSelectCa.Text = "Chọn ca trực hôm nay:";
            // 
            // tabLapBienBan
            // 
            this.tabLapBienBan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(245)))), ((int)(((byte)(240)))));
            this.tabLapBienBan.Controls.Add(this.pnlLapBG);
            this.tabLapBienBan.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabLapBienBan.Location = new System.Drawing.Point(4, 26);
            this.tabLapBienBan.Name = "tabLapBienBan";
            this.tabLapBienBan.Padding = new System.Windows.Forms.Padding(15);
            this.tabLapBienBan.Size = new System.Drawing.Size(1092, 570);
            this.tabLapBienBan.TabIndex = 1;
            this.tabLapBienBan.Text = "2. Lập biên bản bàn giao (UC05, UC06)";
            // 
            // pnlLapBG
            // 
            this.pnlLapBG.BackColor = System.Drawing.Color.White;
            this.pnlLapBG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLapBG.Controls.Add(this.lblGhiChuBR04);
            this.pnlLapBG.Controls.Add(this.btnLapBienBan);
            this.pnlLapBG.Controls.Add(this.txtNoiDungTongKet);
            this.pnlLapBG.Controls.Add(this.lblNoiDungTongKet);
            this.pnlLapBG.Controls.Add(this.lblCaGiaoInfoVal);
            this.pnlLapBG.Controls.Add(this.lblCaGiaoInfo);
            this.pnlLapBG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLapBG.Location = new System.Drawing.Point(15, 15);
            this.pnlLapBG.Name = "pnlLapBG";
            this.pnlLapBG.Padding = new System.Windows.Forms.Padding(20);
            this.pnlLapBG.Size = new System.Drawing.Size(1062, 540);
            this.pnlLapBG.TabIndex = 0;
            // 
            // lblGhiChuBR04
            // 
            this.lblGhiChuBR04.AutoSize = true;
            this.lblGhiChuBR04.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Italic);
            this.lblGhiChuBR04.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(64)))), ((int)(((byte)(43)))));
            this.lblGhiChuBR04.Location = new System.Drawing.Point(20, 390);
            this.lblGhiChuBR04.Name = "lblGhiChuBR04";
            this.lblGhiChuBR04.Size = new System.Drawing.Size(657, 17);
            this.lblGhiChuBR04.TabIndex = 4;
            this.lblGhiChuBR04.Text = "* Quy tắc BR04: Các nhật ký/sự cố chưa xử lý xong trong ca này sẽ tự động kế thừa thành Công việc tồn đọng cho ca sau.";
            // 
            // btnLapBienBan
            // 
            this.btnLapBienBan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(42)))), ((int)(((byte)(67)))));
            this.btnLapBienBan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLapBienBan.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnLapBienBan.ForeColor = System.Drawing.Color.White;
            this.btnLapBienBan.Location = new System.Drawing.Point(23, 430);
            this.btnLapBienBan.Name = "btnLapBienBan";
            this.btnLapBienBan.Size = new System.Drawing.Size(260, 45);
            this.btnLapBienBan.TabIndex = 5;
            this.btnLapBienBan.Text = "LẬP VÀ GỬI BIÊN BẢN";
            this.btnLapBienBan.UseVisualStyleBackColor = false;
            this.btnLapBienBan.Click += new System.EventHandler(this.btnLapBienBan_Click);
            // 
            // txtNoiDungTongKet
            // 
            this.txtNoiDungTongKet.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNoiDungTongKet.Location = new System.Drawing.Point(23, 105);
            this.txtNoiDungTongKet.Multiline = true;
            this.txtNoiDungTongKet.Name = "txtNoiDungTongKet";
            this.txtNoiDungTongKet.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNoiDungTongKet.Size = new System.Drawing.Size(1010, 260);
            this.txtNoiDungTongKet.TabIndex = 3;
            // 
            // lblNoiDungTongKet
            // 
            this.lblNoiDungTongKet.AutoSize = true;
            this.lblNoiDungTongKet.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNoiDungTongKet.Location = new System.Drawing.Point(20, 75);
            this.lblNoiDungTongKet.Name = "lblNoiDungTongKet";
            this.lblNoiDungTongKet.Size = new System.Drawing.Size(217, 19);
            this.lblNoiDungTongKet.TabIndex = 2;
            this.lblNoiDungTongKet.Text = "Nội dung tổng kết ca làm việc:";
            // 
            // lblCaGiaoInfoVal
            // 
            this.lblCaGiaoInfoVal.AutoSize = true;
            this.lblCaGiaoInfoVal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCaGiaoInfoVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(124)))), ((int)(((byte)(134)))));
            this.lblCaGiaoInfoVal.Location = new System.Drawing.Point(175, 25);
            this.lblCaGiaoInfoVal.Name = "lblCaGiaoInfoVal";
            this.lblCaGiaoInfoVal.Size = new System.Drawing.Size(148, 19);
            this.lblCaGiaoInfoVal.TabIndex = 1;
            this.lblCaGiaoInfoVal.Text = "[Chưa chọn ca trực]";
            // 
            // lblCaGiaoInfo
            // 
            this.lblCaGiaoInfo.AutoSize = true;
            this.lblCaGiaoInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCaGiaoInfo.Location = new System.Drawing.Point(20, 25);
            this.lblCaGiaoInfo.Name = "lblCaGiaoInfo";
            this.lblCaGiaoInfo.Size = new System.Drawing.Size(135, 19);
            this.lblCaGiaoInfo.TabIndex = 0;
            this.lblCaGiaoInfo.Text = "Ca trực bàn giao:";
            // 
            // tabBanGiaoAndTonDong
            // 
            this.tabBanGiaoAndTonDong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(245)))), ((int)(((byte)(240)))));
            this.tabBanGiaoAndTonDong.Controls.Add(this.spcBanGiao);
            this.tabBanGiaoAndTonDong.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabBanGiaoAndTonDong.Location = new System.Drawing.Point(4, 26);
            this.tabBanGiaoAndTonDong.Name = "tabBanGiaoAndTonDong";
            this.tabBanGiaoAndTonDong.Padding = new System.Windows.Forms.Padding(10);
            this.tabBanGiaoAndTonDong.Size = new System.Drawing.Size(1092, 570);
            this.tabBanGiaoAndTonDong.TabIndex = 2;
            this.tabBanGiaoAndTonDong.Text = "3. Biên bản bàn giao & Tồn đọng (UC07)";
            // 
            // spcBanGiao
            // 
            this.spcBanGiao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcBanGiao.Location = new System.Drawing.Point(10, 10);
            this.spcBanGiao.Name = "spcBanGiao";
            this.spcBanGiao.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcBanGiao.Panel1
            // 
            this.spcBanGiao.Panel1.Controls.Add(this.grpBanGiao);
            // 
            // spcBanGiao.Panel2
            // 
            this.spcBanGiao.Panel2.Controls.Add(this.grpTonDong);
            this.spcBanGiao.Size = new System.Drawing.Size(1072, 550);
            this.spcBanGiao.SplitterDistance = 330;
            this.spcBanGiao.TabIndex = 0;
            // 
            // grpBanGiao
            // 
            this.grpBanGiao.Controls.Add(this.dgvBanGiao);
            this.grpBanGiao.Controls.Add(this.pnlXacNhan);
            this.grpBanGiao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBanGiao.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpBanGiao.Location = new System.Drawing.Point(0, 0);
            this.grpBanGiao.Name = "grpBanGiao";
            this.grpBanGiao.Size = new System.Drawing.Size(1072, 330);
            this.grpBanGiao.TabIndex = 0;
            this.grpBanGiao.TabStop = false;
            this.grpBanGiao.Text = "Danh sách biên bản bàn giao ca";
            // 
            // dgvBanGiao
            // 
            this.dgvBanGiao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBanGiao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBanGiao.Location = new System.Drawing.Point(3, 21);
            this.dgvBanGiao.Name = "dgvBanGiao";
            this.dgvBanGiao.Size = new System.Drawing.Size(1066, 256);
            this.dgvBanGiao.TabIndex = 0;
            this.dgvBanGiao.SelectionChanged += new System.EventHandler(this.dgvBanGiao_SelectionChanged);
            // 
            // pnlXacNhan
            // 
            this.pnlXacNhan.Controls.Add(this.btnXacNhanNhanCa);
            this.pnlXacNhan.Controls.Add(this.cboCaNhan);
            this.pnlXacNhan.Controls.Add(this.lblCaNhan);
            this.pnlXacNhan.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlXacNhan.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.pnlXacNhan.Location = new System.Drawing.Point(3, 277);
            this.pnlXacNhan.Name = "pnlXacNhan";
            this.pnlXacNhan.Size = new System.Drawing.Size(1066, 50);
            this.pnlXacNhan.TabIndex = 1;
            // 
            // btnXacNhanNhanCa
            // 
            this.btnXacNhanNhanCa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(124)))), ((int)(((byte)(134)))));
            this.btnXacNhanNhanCa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXacNhanNhanCa.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnXacNhanNhanCa.ForeColor = System.Drawing.Color.White;
            this.btnXacNhanNhanCa.Location = new System.Drawing.Point(540, 8);
            this.btnXacNhanNhanCa.Name = "btnXacNhanNhanCa";
            this.btnXacNhanNhanCa.Size = new System.Drawing.Size(180, 32);
            this.btnXacNhanNhanCa.TabIndex = 2;
            this.btnXacNhanNhanCa.Text = "Xác nhận nhận ca";
            this.btnXacNhanNhanCa.UseVisualStyleBackColor = false;
            this.btnXacNhanNhanCa.Click += new System.EventHandler(this.btnXacNhanNhanCa_Click);
            // 
            // cboCaNhan
            // 
            this.cboCaNhan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCaNhan.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboCaNhan.FormattingEnabled = true;
            this.cboCaNhan.Location = new System.Drawing.Point(155, 12);
            this.cboCaNhan.Name = "cboCaNhan";
            this.cboCaNhan.Size = new System.Drawing.Size(365, 25);
            this.cboCaNhan.TabIndex = 1;
            // 
            // lblCaNhan
            // 
            this.lblCaNhan.AutoSize = true;
            this.lblCaNhan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCaNhan.Location = new System.Drawing.Point(10, 15);
            this.lblCaNhan.Name = "lblCaNhan";
            this.lblCaNhan.Size = new System.Drawing.Size(139, 19);
            this.lblCaNhan.TabIndex = 0;
            this.lblCaNhan.Text = "Chọn ca tiếp nhận:";
            // 
            // grpTonDong
            // 
            this.grpTonDong.Controls.Add(this.dgvTonDong);
            this.grpTonDong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTonDong.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpTonDong.Location = new System.Drawing.Point(0, 0);
            this.grpTonDong.Name = "grpTonDong";
            this.grpTonDong.Size = new System.Drawing.Size(1072, 216);
            this.grpTonDong.TabIndex = 0;
            this.grpTonDong.TabStop = false;
            this.grpTonDong.Text = "Danh sách công việc tồn đọng chưa xử lý (Kế thừa ca trước - BR04)";
            // 
            // dgvTonDong
            // 
            this.dgvTonDong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTonDong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTonDong.Location = new System.Drawing.Point(3, 21);
            this.dgvTonDong.Name = "dgvTonDong";
            this.dgvTonDong.Size = new System.Drawing.Size(1066, 192);
            this.dgvTonDong.TabIndex = 0;
            // 
            // FrmBanGiao
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(245)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmBanGiao";
            this.Text = "Quản lý Bàn giao ca";
            this.Load += new System.EventHandler(this.FrmBanGiao_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.tabNhatKy.ResumeLayout(false);
            this.grpGhiNhatKy.ResumeLayout(false);
            this.grpGhiNhatKy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhatKy)).EndInit();
            this.pnlTopNK.ResumeLayout(false);
            this.pnlTopNK.PerformLayout();
            this.tabLapBienBan.ResumeLayout(false);
            this.pnlLapBG.ResumeLayout(false);
            this.pnlLapBG.PerformLayout();
            this.tabBanGiaoAndTonDong.ResumeLayout(false);
            this.spcBanGiao.Panel1.ResumeLayout(false);
            this.spcBanGiao.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcBanGiao)).EndInit();
            this.spcBanGiao.ResumeLayout(false);
            this.grpBanGiao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBanGiao)).EndInit();
            this.pnlXacNhan.ResumeLayout(false);
            this.pnlXacNhan.PerformLayout();
            this.grpTonDong.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTonDong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabNhatKy;
        private System.Windows.Forms.TabPage tabLapBienBan;
        private System.Windows.Forms.TabPage tabBanGiaoAndTonDong;
        private System.Windows.Forms.Panel pnlTopNK;
        private System.Windows.Forms.ComboBox cboCaTrucHomNay;
        private System.Windows.Forms.Label lblSelectCa;
        private System.Windows.Forms.DataGridView dgvNhatKy;
        private System.Windows.Forms.GroupBox grpGhiNhatKy;
        private System.Windows.Forms.Label lblLoaiNhatKy;
        private System.Windows.Forms.ComboBox cboMucDo;
        private System.Windows.Forms.ComboBox cboLoaiNhatKy;
        private System.Windows.Forms.Label lblNoiDung;
        private System.Windows.Forms.Label lblMucDo;
        private System.Windows.Forms.TextBox txtNoiDungNhatKy;
        private System.Windows.Forms.Button btnGhiNhatKy;
        private System.Windows.Forms.Panel pnlLapBG;
        private System.Windows.Forms.Label lblCaGiaoInfoVal;
        private System.Windows.Forms.Label lblCaGiaoInfo;
        private System.Windows.Forms.Label lblNoiDungTongKet;
        private System.Windows.Forms.TextBox txtNoiDungTongKet;
        private System.Windows.Forms.Button btnLapBienBan;
        private System.Windows.Forms.Label lblGhiChuBR04;
        private System.Windows.Forms.SplitContainer spcBanGiao;
        private System.Windows.Forms.GroupBox grpBanGiao;
        private System.Windows.Forms.DataGridView dgvBanGiao;
        private System.Windows.Forms.GroupBox grpTonDong;
        private System.Windows.Forms.DataGridView dgvTonDong;
        private System.Windows.Forms.Panel pnlXacNhan;
        private System.Windows.Forms.ComboBox cboCaNhan;
        private System.Windows.Forms.Label lblCaNhan;
        private System.Windows.Forms.Button btnXacNhanNhanCa;
        private System.Windows.Forms.Button btnTaiLai;
    }
}