namespace libraryManagement_ThreePlayer
{
    partial class frmAuthors
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
            this.pnlData = new System.Windows.Forms.Panel();
            this.dgvAuthors = new System.Windows.Forms.DataGridView();
            this.MaTacGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTenTacGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GioiTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QueQuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuthors)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlData
            // 
            this.pnlData.Controls.Add(this.dgvAuthors);
            this.pnlData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlData.Location = new System.Drawing.Point(0, 0);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(970, 500);
            this.pnlData.TabIndex = 0;
            // 
            // dgvAuthors
            // 
            this.dgvAuthors.AllowUserToAddRows = false;
            this.dgvAuthors.AllowUserToDeleteRows = false;
            this.dgvAuthors.AllowUserToResizeColumns = false;
            this.dgvAuthors.AllowUserToResizeRows = false;
            this.dgvAuthors.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAuthors.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvAuthors.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dgvAuthors.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAuthors.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAuthors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAuthors.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaTacGia,
            this.HoTenTacGia,
            this.GioiTinh,
            this.QueQuan});
            this.dgvAuthors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAuthors.Location = new System.Drawing.Point(0, 0);
            this.dgvAuthors.MultiSelect = false;
            this.dgvAuthors.Name = "dgvAuthors";
            this.dgvAuthors.ReadOnly = true;
            this.dgvAuthors.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvAuthors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAuthors.Size = new System.Drawing.Size(970, 500);
            this.dgvAuthors.TabIndex = 1;
            this.dgvAuthors.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvAuthors_MouseClick);
            // 
            // MaTacGia
            // 
            this.MaTacGia.FillWeight = 65F;
            this.MaTacGia.HeaderText = "Mã tác giả";
            this.MaTacGia.Name = "MaTacGia";
            this.MaTacGia.ReadOnly = true;
            // 
            // HoTenTacGia
            // 
            this.HoTenTacGia.FillWeight = 150F;
            this.HoTenTacGia.HeaderText = "Tên tác giả";
            this.HoTenTacGia.Name = "HoTenTacGia";
            this.HoTenTacGia.ReadOnly = true;
            // 
            // GioiTinh
            // 
            this.GioiTinh.FillWeight = 80F;
            this.GioiTinh.HeaderText = "Giới tính";
            this.GioiTinh.Name = "GioiTinh";
            this.GioiTinh.ReadOnly = true;
            // 
            // QueQuan
            // 
            this.QueQuan.HeaderText = "Quê quán";
            this.QueQuan.Name = "QueQuan";
            this.QueQuan.ReadOnly = true;
            // 
            // frmAuthors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 500);
            this.ControlBox = false;
            this.Controls.Add(this.pnlData);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAuthors";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmAuthors";
            this.Load += new System.EventHandler(this.frmAuthors_Load);
            this.pnlData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuthors)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlData;
        private System.Windows.Forms.DataGridView dgvAuthors;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaTacGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTenTacGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn GioiTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn QueQuan;
    }
}