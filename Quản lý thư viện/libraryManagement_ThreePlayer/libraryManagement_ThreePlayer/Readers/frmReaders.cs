using BUS;
using libraryManagement_ThreePlayer.Readers;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static BUS.ReadersService;

namespace libraryManagement_ThreePlayer
{
    public partial class frmReaders : Form
    {
        private readonly ReadersService _readersService = new ReadersService();
        private readonly frmManagement parentForm;
        private frmReaderTools frmReaderTools;

        public frmReaders(frmManagement mainForm)
        {
            InitializeComponent();
            parentForm = mainForm;
        }

        public void LoadData()
        {
            try
            {
                var reader = _readersService.GetAllReaders();
                BindGrid(reader);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        public void BindGrid(List<ReaderViewModel> readerList)
        {
            dgvReaders.Rows.Clear();

            foreach (var item in readerList)
            {
                int index = dgvReaders.Rows.Add();
                dgvReaders.Rows[index].Cells[0].Value = item.MaDocGia;
                dgvReaders.Rows[index].Cells[1].Value = item.HoTenDocGia;
                dgvReaders.Rows[index].Cells[2].Value = item.GioiTinh;
                dgvReaders.Rows[index].Cells[3].Value = item.DiaChi;
                dgvReaders.Rows[index].Cells[4].Value = item.DienThoai;
                dgvReaders.Rows[index].Cells[5].Value = item.CMND;
                dgvReaders.Rows[index].Cells[6].Value = item.NgaySinh;
                dgvReaders.Rows[index].Cells[7].Value = item.NgayLamThe;
            }
        }

        private void frmReaders_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvReaders_MouseClick(object sender, MouseEventArgs e)
        {
            if (dgvReaders.Rows.Count > 0 && dgvReaders.CurrentRow != null)
            {
                DataGridViewRow selectedRow = dgvReaders.CurrentRow;
                if (parentForm.frmReaderToolsInstance == null || parentForm.frmReaderToolsInstance.IsDisposed)
                {
                    parentForm.btnReaderTools_Click(sender, e);
                }
                parentForm.UpdateReaderToolsForm(selectedRow);
            }
        }
    }
}
