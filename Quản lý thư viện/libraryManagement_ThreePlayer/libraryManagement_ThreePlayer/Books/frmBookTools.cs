using BUS;
using DAL.Entities;
using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static BUS.BooksService;

namespace libraryManagement_ThreePlayer.Books
{
    public partial class frmBookTools : Form
    {
        //Hàm khởi tạo
        private frmBooks _frmBooks;
        private bool isSearching = false;

        //Hàm khởi tạo Service
        private readonly BooksService _booksService = new BooksService();
        private readonly GenresService _genresService = new GenresService();
        private readonly AuthorsService _authorsService = new AuthorsService();
        private readonly LibraryData _context = new LibraryData();

        //Tham số frmStyle
        private int borderSize = 2;
        private Size formSize;

        public frmBookTools(frmBooks frmBooks)
        {
            InitializeComponent();
            _frmBooks = frmBooks;
        }
        
        //Hàm tùy chỉnh frm
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void pnlTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_NCCALCSIZE = 0x0083;

            if (m.Msg == WM_NCCALCSIZE && m.WParam.ToInt32() == 1)
            {
                return;
            }

            base.WndProc(ref m);
        }

        private void AdjustForm()
        {
            switch (this.WindowState)
            {
                case FormWindowState.Maximized:
                    this.Padding = new Padding(8, 8, 8, 0);
                    break;
                case FormWindowState.Normal:
                    if (this.Padding.Top != borderSize)
                        this.Padding = new Padding(borderSize);
                    break;
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            formSize = this.ClientSize;
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBookTools_Load(object sender, EventArgs e)
        {
            AdjustForm();
            LoadComboBox();
        }

        //Code chức năng
        private void LoadComboBox()
        {
            // Load tên tác giả vào cmbAuthor
            var authors = _authorsService.GetAllAuthorByName();
            cmbAuthor.DataSource = authors;
            cmbAuthor.DisplayMember = "HoTenTacGia";  // Tên hiển thị trong ComboBox
            cmbAuthor.ValueMember = "MaTacGia";       // Giá trị chính tương ứng

            // Load tên thể loại vào cmbTheLoai
            var categories = _genresService.GetAllGenres();
            cmbTheLoai.DataSource = categories;
            cmbTheLoai.DisplayMember = "TenTheLoai";  // Tên hiển thị trong ComboBox
            cmbTheLoai.ValueMember = "MaTheLoai";     // Giá trị chính tương ứng
        }

        private void ClearFields()
        {
            txtMaSach.Clear();
            txtTenSach.Clear();
            cmbAuthor.SelectedValue = -1;
            cmbTheLoai.SelectedValue = -1;
            txtNXB.Clear();
            dTP_NXB.Value = DateTime.Now;
            txtSoLuong.Clear();
            txtGiaTien.Clear();
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Kiểm tra thông tin
            if (string.IsNullOrWhiteSpace(txtTenSach.Text)
                || string.IsNullOrWhiteSpace(txtGiaTien.Text)
                || string.IsNullOrWhiteSpace(txtNXB.Text)
                || string.IsNullOrWhiteSpace(txtSoLuong.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int SoLuongParsed;
            if (!int.TryParse(txtSoLuong.Text, out SoLuongParsed))
            {
                MessageBox.Show("Số lượng phải là một số nguyên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(SoLuongParsed < 1)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int GiaTienParsed;
            if (!int.TryParse(txtGiaTien.Text, out GiaTienParsed))
            {
                MessageBox.Show("Giá tiền phải là một số nguyên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (GiaTienParsed < 1)
            {
                MessageBox.Show("Giá tiền phải lớn hơn 0.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maSachMoi = _booksService.GenerateMaSach();
            string tenTacGia = cmbAuthor.Text;
            string tenTheLoai = cmbTheLoai.Text;
            Sach newBook = new Sach // Chuẩn bị đối tượng sách để thêm
            {
                MaSach = maSachMoi,
                TenSach = txtTenSach.Text,
                NhaXuatBan = txtNXB.Text,
                NgayXuatBan = dTP_NXB.Value,
                SoLuong = SoLuongParsed,
                GiaTien = GiaTienParsed
            };

            bool result = _booksService.AddBook(newBook, tenTacGia, tenTheLoai);
            if (result)
            {
                _frmBooks.LoadData();
                MessageBox.Show("Thêm sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
            }
            else
            {
                MessageBox.Show("Không tìm thấy tên tác giả hoặc mã sách đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string hoTenTacGia = cmbAuthor.Text.Trim();
            string tenTheLoai = cmbTheLoai.Text.Trim();
            // Kiểm tra thông tin
            if (string.IsNullOrWhiteSpace(txtMaSach.Text)
                || string.IsNullOrWhiteSpace(txtTenSach.Text)
                || string.IsNullOrWhiteSpace(txtGiaTien.Text)
                || string.IsNullOrWhiteSpace(txtNXB.Text)
                || string.IsNullOrWhiteSpace(txtSoLuong.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra xem tác giả có trong cơ sở dữ liệu hay không
            var tacGia = _context.TacGia.FirstOrDefault(t => t.HoTenTacGia == hoTenTacGia);
            if (tacGia == null)
            {
                MessageBox.Show("Không tìm thấy tên tác giả trong CSDL", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra xem thể loại có trong cơ sở dữ liệu hay không
            var theLoai = _context.TheLoai.FirstOrDefault(t => t.TenTheLoai == tenTheLoai);
            if (theLoai == null)
            {
                MessageBox.Show("Không tìm thấy thể loại trong CSDL", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int SoLuongParsed;
            if (!int.TryParse(txtSoLuong.Text, out SoLuongParsed))
            {
                MessageBox.Show("Số lượng phải là một số nguyên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (SoLuongParsed < 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn hoặc bằng 0.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int GiaTienParsed;
            if (!int.TryParse(txtGiaTien.Text, out GiaTienParsed))
            {
                MessageBox.Show("Giá tiền phải là một số nguyên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (GiaTienParsed < 1)
            {
                MessageBox.Show("Giá tiền phải lớn hơn 0.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Nếu tìm thấy tác giả, tiếp tục cập nhật sách
            BookViewModel updatedBook = new BookViewModel
            {
                MaSach = txtMaSach.Text,
                TenSach = txtTenSach.Text,
                MaTheLoai = theLoai.MaTheLoai,
                MaTacGia = tacGia.MaTacGia,
                NhaXuatBan = txtNXB.Text,
                NgayXuatBan = dTP_NXB.Value,
                SoLuong = SoLuongParsed,
                GiaTien = GiaTienParsed,
                HoTenTacGia = hoTenTacGia
            }; 

            if (_booksService.UpdateBook(updatedBook))
            {
                _frmBooks.LoadData();
                MessageBox.Show("Cập nhật sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
            }
            else
            {
                MessageBox.Show("Không tìm thấy sách cần cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            // Kiểm tra thông tin
            if (string.IsNullOrWhiteSpace(txtMaSach.Text))
            {
                MessageBox.Show("Vui lòng nhập mã sách để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xóa sách
            DialogResult confirmResult = MessageBox.Show("Bạn có chắc muốn xóa thông tin sách này?", "Xác nhận xóa", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                if (_booksService.DeleteBook(txtMaSach.Text))
                {
                    _frmBooks.LoadData();
                    MessageBox.Show("Xóa sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy mã sách cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else { return; }
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
                    _frmBooks.LoadData();
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
                        _frmBooks.BindGrid(filteredReaders);
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
