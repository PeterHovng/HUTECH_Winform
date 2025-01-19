using BUS;
using DAL.Entities;
using libraryManagement_ThreePlayer.PhieuMuon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace libraryManagement_ThreePlayer.TheLoai
{
    public partial class frmTheLoaiTools : Form
    {
        private frmTheLoai _frmGenres;
        private bool isSearching = false;

        private readonly GenresService _genresService = new GenresService();
        private readonly LibraryData _context = new LibraryData();

        //Tham số frmStyle
        private int borderSize = 2;
        private Size formSize;

        public frmTheLoaiTools(frmTheLoai frmTheLoai)
        {
            InitializeComponent();
            _frmGenres = frmTheLoai;
        }

        //Hàm tùy chỉnh frm
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);



        private void btnAdd_Click(object sender, EventArgs e)
        {
            string maTheLoai = txtTL_ID.Text.Trim();
            string tenTheLoai = txtTenTL.Text.Trim();

            if (string.IsNullOrWhiteSpace(maTheLoai) || string.IsNullOrWhiteSpace(tenTheLoai))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin thể loại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var theLoai = new DAL.Entities.TheLoai
            {
                MaTheLoai = maTheLoai,
                TenTheLoai = tenTheLoai
            };

            bool result = _genresService.AddGenre(theLoai);

            if (result)
            {
                MessageBox.Show("Thêm thể loại thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _frmGenres.LoadData();

            }
            else
            {
                MessageBox.Show("Thể loại đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string maTheLoai = txtTL_ID.Text.Trim();
            string tenTheLoaiMoi = txtTenTL.Text.Trim();

            if (string.IsNullOrWhiteSpace(maTheLoai) || string.IsNullOrWhiteSpace(tenTheLoaiMoi))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin thể loại để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool result = _genresService.EditGenre(maTheLoai, tenTheLoaiMoi);

            if (result)
            {
                MessageBox.Show("Sửa thể loại thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _frmGenres.LoadData(); // Tải lại dữ liệu sau khi chỉnh sửa

            }
            else
            {
                MessageBox.Show("Không tìm thấy thể loại với mã đã cho.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            string maTheLoai = txtTL_ID.Text.Trim();

            if (string.IsNullOrWhiteSpace(maTheLoai))
            {
                MessageBox.Show("Vui lòng nhập mã thể loại để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa thể loại này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                bool result = _genresService.DeleteGenre(maTheLoai);

                if (result)
                {
                    MessageBox.Show("Xóa thể loại thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _frmGenres.LoadData(); // Tải lại dữ liệu sau khi xóa

                }
                else
                {
                    MessageBox.Show("Không tìm thấy thể loại với mã đã cho.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Hủy bỏ thao tác xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    _frmGenres.LoadData();
                    btnSearch.Text = "Tìm kiếm";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                var filteredAuthors = _genresService.SearchGenres(searchText);
                if (filteredAuthors.Any())
                {
                    try
                    {
                        isSearching = true;
                        _frmGenres.BindGrid(filteredAuthors);
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

        private void frmTheLoaiTools_Load(object sender, EventArgs e)
        {
            AdjustForm();
        }
    }
}
