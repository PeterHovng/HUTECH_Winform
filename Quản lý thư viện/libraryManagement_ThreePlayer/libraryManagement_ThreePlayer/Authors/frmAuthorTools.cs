using BUS;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace libraryManagement_ThreePlayer.Authors
{
    public partial class frmAuthorTools : Form
    {
        //Khởi tạo
        private frmAuthors _frmAuthors;
        private bool isSearching = false;

        //Khởi tạo Service
        private readonly AuthorsService _authorsService = new AuthorsService();
        private readonly LibraryData _context = new LibraryData();

        //Tham số frmStyle
        private int borderSize = 2;
        private Size formSize;

        public frmAuthorTools(frmAuthors frmAuthors)
        {
            InitializeComponent();
            _frmAuthors = frmAuthors;
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

        private void frmAuthorTools_Load(object sender, EventArgs e)
        {
            AdjustForm();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            formSize = this.ClientSize;
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Code chức năng
        private void ClearFields()
        {
            txtHoTen.Text = string.Empty;
            txtID_TG.Text = string.Empty;
            txtQueQuan.Text = string.Empty;
        }

        private string CheckedGioiTinh()
        {
            string gioiTinh;
            if (btnNam.Checked)
            {
                gioiTinh = "Nam";
            }
            else
            {
                gioiTinh = "Nữ";
            }
            return gioiTinh;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Kiểm tra thông tin
            if (string.IsNullOrWhiteSpace(txtHoTen.Text)
                || string.IsNullOrWhiteSpace(txtQueQuan.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin tác giả.");
                return;
            }

            if (!btnNam.Checked && !btnNu.Checked)
            {
                MessageBox.Show("Vui lòng chọn giới tính.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maTacGiaMoi = _authorsService.GenerateMaTacGia();
            TacGia newAuthor = new TacGia
            {
                MaTacGia = maTacGiaMoi,
                HoTenTacGia = txtHoTen.Text,
                GioiTinh = CheckedGioiTinh(),
                QueQuan = txtQueQuan.Text
            };

            bool result = _authorsService.AddAuthor(newAuthor);
            if (result)
            {
                _frmAuthors.LoadData();
                MessageBox.Show("Thêm tác giả thành công!");
                ClearFields();
            }
            else
            {
                MessageBox.Show("Mã tác giả đã tồn tại trong CSDL.");
                return;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Kiểm tra thông tin
            if (string.IsNullOrWhiteSpace(txtHoTen.Text)
                || string.IsNullOrWhiteSpace(txtQueQuan.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin tác giả.");
                return;
            }

            if (!btnNam.Checked && !btnNu.Checked)
            {
                MessageBox.Show("Vui lòng chọn giới tính.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TacGia updatedAuthor = new TacGia
            {
                MaTacGia = txtID_TG.Text,
                HoTenTacGia = txtHoTen.Text,
                GioiTinh = CheckedGioiTinh(),
                QueQuan = txtQueQuan.Text
            };

            bool result = _authorsService.EditAuthor(updatedAuthor);
            if (result)
            {
                _frmAuthors.LoadData();
                MessageBox.Show("Chỉnh sửa thông tin tác giả thành công!");
                ClearFields();
            }
            else
            {
                MessageBox.Show("Không tìm thấy tác giả với mã này.");
                return;
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            // Kiểm tra thông tin
            if (string.IsNullOrWhiteSpace(txtID_TG.Text))
            {
                MessageBox.Show("Vui lòng chọn chính xác mã tác giả cần xóa.");
                return;
            }

            string maTacGia = txtID_TG.Text;

            DialogResult confirmResult = MessageBox.Show("Bạn có chắc muốn xóa tác giả này?", "Xác nhận xóa", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                bool result = _authorsService.DeleteAuthor(maTacGia);
                if (result)
                {
                    _frmAuthors.LoadData();
                    MessageBox.Show("Xóa tác giả thành công!");
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy tác giả với mã này.");
                    return;
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
                    _frmAuthors.LoadData();
                    btnSearch.Text = "Tìm kiếm";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                var filteredAuthors = _authorsService.SearchAuthors(searchText);
                if (filteredAuthors.Any())
                {
                    try
                    {
                        isSearching = true;
                        _frmAuthors.BindGrid(filteredAuthors);
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
