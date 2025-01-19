using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace libraryManagement_ThreePlayer.TheLoai
{
    public partial class frmTheLoai : Form
    {
        private readonly GenresService theloai = new GenresService();

        private readonly frmManagement parentForm;
        private frmTheLoaiTools theLoaiToolsForm;
        public frmTheLoai(frmManagement mainForm)
        {
            InitializeComponent();

            parentForm = mainForm;
        }
        public void LoadData()
        {
            try
            {
                var TheLoai = theloai.GetAllGenres();
                BindGrid(TheLoai);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }
        public void BindGrid(List<GenresViewModel> borrowList)
        {
            dgvTheLoai.Rows.Clear();

            foreach (var item in borrowList)
            {
                int index = dgvTheLoai.Rows.Add();
                dgvTheLoai.Rows[index].Cells[0].Value = item.MaTheLoai;
                dgvTheLoai.Rows[index].Cells[1].Value = item.TenTheLoai;
            }
        }

        private void dgvBorrows_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTheLoai.Rows.Count > 0 && dgvTheLoai.CurrentRow != null)
            {
                DataGridViewRow selectedRow = dgvTheLoai.CurrentRow;
                if (parentForm.frmStaffToolsInstance == null || parentForm.frmStaffToolsInstance.IsDisposed)
                {
                    parentForm.btnBorrowTools_Click(sender, e);
                }
                parentForm.UpdateBorrowToolsForm(selectedRow);
            }
        }

        private void frmTheLoai_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvTheLoai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTheLoai.CurrentRow != null)
            {
                DataGridViewRow selectedRow = dgvTheLoai.CurrentRow;

                if (parentForm.frmAuthorToolsInstance == null || parentForm.frmAuthorToolsInstance.IsDisposed)
                {
                    parentForm.btnTheLoaiTools_Click(sender, e);
                }
                parentForm.UpdateTheLoaiToolsForm(selectedRow);
            }
        }

        private void dgvTheLoai_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
