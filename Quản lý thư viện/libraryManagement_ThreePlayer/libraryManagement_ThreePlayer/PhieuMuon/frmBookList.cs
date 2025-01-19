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

namespace libraryManagement_ThreePlayer.PhieuMuon
{
    public partial class frmBookList : Form
    {
        private readonly BooksService _booksService = new BooksService();
        private bool isSearching = false;

        public frmBookList()
        {
            InitializeComponent();
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

        private void frmBookList_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvBooks.Rows.Count > 0 && dgvBooks.CurrentRow != null)
            {
                string selectedBook = dgvBooks.CurrentRow.Cells[1].Value.ToString();

                DialogResult result = MessageBox.Show($"Bạn có chắc chắn chọn sách '{selectedBook}' không?",
                                                      "Xác nhận",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    var parentForm = (frmMuonTools)this.Owner;
                    parentForm.SetSachText(selectedBook);
                    this.Close();
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text;
            if (string.IsNullOrWhiteSpace(searchText) && !isSearching)
            {
                MessageBox.Show("Vui lòng nhập thông tin cần tìm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (isSearching)
            {
                try
                {
                    isSearching = false;
                    LoadData();
                    btnSearch.Text = "Tìm kiếm";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                var filteredReaders = _booksService.SearchBooks(searchText);
                if (filteredReaders.Any())
                {
                    try
                    {
                        isSearching = true;
                        BindGrid(filteredReaders);
                        btnSearch.Text = "Hủy tìm";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
