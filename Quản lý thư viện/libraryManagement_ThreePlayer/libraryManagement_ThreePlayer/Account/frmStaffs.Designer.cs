namespace libraryManagement_ThreePlayer.Account
{
    partial class frmStaffs
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvStaffs = new System.Windows.Forms.DataGridView();
            this.MaNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTenNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CMND = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChucVu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GioiTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MatKhau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgaySinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayVaoLam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaffs)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvStaffs
            // 
            this.dgvStaffs.AllowUserToAddRows = false;
            this.dgvStaffs.AllowUserToDeleteRows = false;
            this.dgvStaffs.AllowUserToResizeColumns = false;
            this.dgvStaffs.AllowUserToResizeRows = false;
            this.dgvStaffs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStaffs.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvStaffs.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dgvStaffs.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStaffs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvStaffs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStaffs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaNhanVien,
            this.HoTenNhanVien,
            this.CMND,
            this.ChucVu,
            this.GioiTinh,
            this.DiaChi,
            this.MatKhau,
            this.NgaySinh,
            this.NgayVaoLam});
            this.dgvStaffs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStaffs.Location = new System.Drawing.Point(0, 0);
            this.dgvStaffs.MultiSelect = false;
            this.dgvStaffs.Name = "dgvStaffs";
            this.dgvStaffs.ReadOnly = true;
            this.dgvStaffs.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvStaffs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStaffs.Size = new System.Drawing.Size(970, 500);
            this.dgvStaffs.TabIndex = 1;
            this.dgvStaffs.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStaffs_CellClick);
            // 
            // MaNhanVien
            // 
            this.MaNhanVien.FillWeight = 60F;
            this.MaNhanVien.HeaderText = "MNV";
            this.MaNhanVien.Name = "MaNhanVien";
            this.MaNhanVien.ReadOnly = true;
            // 
            // HoTenNhanVien
            // 
            this.HoTenNhanVien.FillWeight = 150F;
            this.HoTenNhanVien.HeaderText = "Họ tên nhân viên";
            this.HoTenNhanVien.Name = "HoTenNhanVien";
            this.HoTenNhanVien.ReadOnly = true;
            // 
            // CMND
            // 
            this.CMND.HeaderText = "CCCD/CMND";
            this.CMND.Name = "CMND";
            this.CMND.ReadOnly = true;
            // 
            // ChucVu
            // 
            this.ChucVu.FillWeight = 80F;
            this.ChucVu.HeaderText = "Chức vụ";
            this.ChucVu.Name = "ChucVu";
            this.ChucVu.ReadOnly = true;
            // 
            // GioiTinh
            // 
            this.GioiTinh.FillWeight = 80F;
            this.GioiTinh.HeaderText = "Giới tính";
            this.GioiTinh.Name = "GioiTinh";
            this.GioiTinh.ReadOnly = true;
            // 
            // DiaChi
            // 
            this.DiaChi.FillWeight = 110F;
            this.DiaChi.HeaderText = "Địa chỉ";
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.ReadOnly = true;
            // 
            // MatKhau
            // 
            this.MatKhau.FillWeight = 80F;
            this.MatKhau.HeaderText = "Mật khẩu";
            this.MatKhau.Name = "MatKhau";
            this.MatKhau.ReadOnly = true;
            // 
            // NgaySinh
            // 
            this.NgaySinh.HeaderText = "Ngày sinh";
            this.NgaySinh.Name = "NgaySinh";
            this.NgaySinh.ReadOnly = true;
            // 
            // NgayVaoLam
            // 
            this.NgayVaoLam.FillWeight = 110F;
            this.NgayVaoLam.HeaderText = "Ngày vào làm";
            this.NgayVaoLam.Name = "NgayVaoLam";
            this.NgayVaoLam.ReadOnly = true;
            // 
            // frmStaffs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 500);
            this.ControlBox = false;
            this.Controls.Add(this.dgvStaffs);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStaffs";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmAccount";
            this.Load += new System.EventHandler(this.frmStaffs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaffs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvStaffs;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTenNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn CMND;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChucVu;
        private System.Windows.Forms.DataGridViewTextBoxColumn GioiTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn MatKhau;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgaySinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayVaoLam;
    }
}