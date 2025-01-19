namespace libraryManagement_ThreePlayer.PhieuTra
{
    partial class frmTra
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
            this.dgvReturn = new System.Windows.Forms.DataGridView();
            this.MaPhieuTra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaPhieuMuon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayLap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTenNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReturn)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvReturn
            // 
            this.dgvReturn.AllowUserToAddRows = false;
            this.dgvReturn.AllowUserToDeleteRows = false;
            this.dgvReturn.AllowUserToResizeColumns = false;
            this.dgvReturn.AllowUserToResizeRows = false;
            this.dgvReturn.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReturn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvReturn.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dgvReturn.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReturn.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvReturn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReturn.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaPhieuTra,
            this.MaPhieuMuon,
            this.NgayLap,
            this.HoTenNhanVien});
            this.dgvReturn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReturn.Location = new System.Drawing.Point(0, 0);
            this.dgvReturn.MultiSelect = false;
            this.dgvReturn.Name = "dgvReturn";
            this.dgvReturn.ReadOnly = true;
            this.dgvReturn.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvReturn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReturn.Size = new System.Drawing.Size(970, 500);
            this.dgvReturn.TabIndex = 2;
            this.dgvReturn.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReturn_CellClick);
            this.dgvReturn.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReturn_CellContentClick);
            // 
            // MaPhieuTra
            // 
            this.MaPhieuTra.HeaderText = "Mã phiếu trả";
            this.MaPhieuTra.Name = "MaPhieuTra";
            this.MaPhieuTra.ReadOnly = true;
            // 
            // MaPhieuMuon
            // 
            this.MaPhieuMuon.HeaderText = "Mã phiếu mượn";
            this.MaPhieuMuon.Name = "MaPhieuMuon";
            this.MaPhieuMuon.ReadOnly = true;
            // 
            // NgayLap
            // 
            this.NgayLap.HeaderText = "Ngày lập phiếu";
            this.NgayLap.Name = "NgayLap";
            this.NgayLap.ReadOnly = true;
            // 
            // HoTenNhanVien
            // 
            this.HoTenNhanVien.HeaderText = "Nhân viên";
            this.HoTenNhanVien.Name = "HoTenNhanVien";
            this.HoTenNhanVien.ReadOnly = true;
            // 
            // frmTra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 500);
            this.Controls.Add(this.dgvReturn);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmTra";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmTra";
            this.Load += new System.EventHandler(this.frmTra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReturn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvReturn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaPhieuTra;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaPhieuMuon;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayLap;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTenNhanVien;
    }
}