using BUS;
using libraryManagement_ThreePlayer.Books;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BUS.AuthorsService;
using static BUS.BooksService;

namespace libraryManagement_ThreePlayer
{
    public partial class frmAuthors : Form
    {
        private readonly AuthorsService authorsService = new AuthorsService();
        private readonly frmManagement parentForm;
        private frmAuthors authorToolsForm;

        public frmAuthors(frmManagement mainForm)
        {
            InitializeComponent();
            parentForm = mainForm;
        }

        public void LoadData()
        {
            try
            {
                var author = authorsService.GetAllAuthor();
                BindGrid(author);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        public void BindGrid(List<AuthorsViewModel> authorList)
        {
            var books = authorsService.GetAllAuthor();
            dgvAuthors.Rows.Clear();

            foreach (var item in authorList)
            {
                int index = dgvAuthors.Rows.Add();
                dgvAuthors.Rows[index].Cells[0].Value = item.MaTacGia;
                dgvAuthors.Rows[index].Cells[1].Value = item.HoTenTacGia;
                dgvAuthors.Rows[index].Cells[2].Value = item.GioiTinh;
                dgvAuthors.Rows[index].Cells[3].Value = item.QueQuan;
            }
        }

        private void frmAuthors_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvAuthors_MouseClick(object sender, MouseEventArgs e)
        {
            if (dgvAuthors.Rows.Count > 0 && dgvAuthors.CurrentRow != null)
            {
                DataGridViewRow selectedRow = dgvAuthors.CurrentRow;

                if (parentForm.frmAuthorToolsInstance == null || parentForm.frmAuthorToolsInstance.IsDisposed)
                {
                    parentForm.btnAuthorTools_Click(sender, e);
                }
                parentForm.UpdateAuthorToolsForm(selectedRow);
            }
        }
    }
}
