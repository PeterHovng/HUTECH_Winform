namespace libraryManagement_ThreePlayer.PhieuMuon
{
    partial class frmMuon
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
            this.dgvBorrows = new System.Windows.Forms.DataGridView();
            this.MaPhieuMuon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTenNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTenDocGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayMuon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBorrows)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBorrows
            // 
            this.dgvBorrows.AllowUserToAddRows = false;
            this.dgvBorrows.AllowUserToDeleteRows = false;
            this.dgvBorrows.AllowUserToResizeColumns = false;
            this.dgvBorrows.AllowUserToResizeRows = false;
            this.dgvBorrows.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBorrows.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvBorrows.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dgvBorrows.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBorrows.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBorrows.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBorrows.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaPhieuMuon,
            this.HoTenNhanVien,
            this.HoTenDocGia,
            this.NgayMuon});
            this.dgvBorrows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBorrows.Location = new System.Drawing.Point(0, 0);
            this.dgvBorrows.MultiSelect = false;
            this.dgvBorrows.Name = "dgvBorrows";
            this.dgvBorrows.ReadOnly = true;
            this.dgvBorrows.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvBorrows.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBorrows.Size = new System.Drawing.Size(970, 500);
            this.dgvBorrows.TabIndex = 1;
            this.dgvBorrows.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvBorrows_MouseClick);
            // 
            // MaPhieuMuon
            // 
            this.MaPhieuMuon.HeaderText = "Mã phiếu";
            this.MaPhieuMuon.Name = "MaPhieuMuon";
            this.MaPhieuMuon.ReadOnly = true;
            // 
            // HoTenNhanVien
            // 
            this.HoTenNhanVien.HeaderText = "Họ tên nhân viên";
            this.HoTenNhanVien.Name = "HoTenNhanVien";
            this.HoTenNhanVien.ReadOnly = true;
            // 
            // HoTenDocGia
            // 
            this.HoTenDocGia.HeaderText = "Họ tên độc giả";
            this.HoTenDocGia.Name = "HoTenDocGia";
            this.HoTenDocGia.ReadOnly = true;
            // 
            // NgayMuon
            // 
            this.NgayMuon.HeaderText = "Ngày mượn";
            this.NgayMuon.Name = "NgayMuon";
            this.NgayMuon.ReadOnly = true;
            // 
            // frmMuon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 500);
            this.Controls.Add(this.dgvBorrows);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMuon";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmMuon";
            this.Load += new System.EventHandler(this.frmMuon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBorrows)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBorrows;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaPhieuMuon;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTenNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTenDocGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayMuon;
    }
}