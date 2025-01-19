using BUS;
using libraryManagement_ThreePlayer.Books;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static BUS.BooksService;

namespace libraryManagement_ThreePlayer
{
    public partial class frmBooks : Form
    {
        private readonly BooksService _booksService = new BooksService();
        private readonly frmManagement parentForm;
        private frmBookTools bookToolsForm;

        public frmBooks(frmManagement mainForm)
        {
            InitializeComponent();
            parentForm = mainForm;
        }

        public void LoadData()
        {
            try
            {
                var books = _booksService.GetAllBooks();
                BindGrid(books);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        public void BindGrid(List<BookViewModel> bookList)
        {
            dgvBooks.Rows.Clear();

            foreach (var item in bookList)
            {
                int index = dgvBooks.Rows.Add();
                dgvBooks.Rows[index].Cells[0].Value = item.MaSach;
                dgvBooks.Rows[index].Cells[1].Value = item.TenSach;
                dgvBooks.Rows[index].Cells[2].Value = item.TenTheLoai;
                dgvBooks.Rows[index].Cells[3].Value = item.HoTenTacGia;
                dgvBooks.Rows[index].Cells[4].Value = item.NhaXuatBan;
                dgvBooks.Rows[index].Cells[5].Value = item.NgayXuatBan;
                dgvBooks.Rows[index].Cells[6].Value = item.SoLuong;
                dgvBooks.Rows[index].Cells[7].Value = item.GiaTien;
            }
        }

        private void frmBook_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvBooks_MouseClick(object sender, MouseEventArgs e)
        {
            if (dgvBooks.Rows.Count > 0 && dgvBooks.CurrentRow != null)
            {
                DataGridViewRow selectedRow = dgvBooks.CurrentRow;
                if (parentForm.frmBookToolsInstance == null || parentForm.frmBookToolsInstance.IsDisposed)
                {
                    parentForm.btnBookTools_Click(sender, e);
                }
                parentForm.UpdateBookToolsForm(selectedRow);
            }
        }

        private void dgvBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
