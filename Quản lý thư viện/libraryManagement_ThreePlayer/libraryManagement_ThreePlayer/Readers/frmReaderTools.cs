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

namespace libraryManagement_ThreePlayer.Readers
{
    public partial class frmReaderTools : Form
    {
        //Hàm khởi tạo
        private frmReaders _frmReaders;
        private bool isSearching = false;

        //Khởi tạo Service
        private readonly ReadersService _readersService = new ReadersService();
        private readonly LibraryData _context = new LibraryData();

        //Tham số frmStyle
        private int borderSize = 2;
        private Size formSize;

        public frmReaderTools(frmReaders frmReaders)
        {
            InitializeComponent();
            _frmReaders = frmReaders;
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
            Close();
        }

        private void frmReaderTools_Load(object sender, EventArgs e)
        {
            AdjustForm();
        }

        //Code chức năng
        private void ClearFields()
        {
            txtCMND.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            txtDT.Text = string.Empty;
            txtHoTen.Text = string.Empty;
            dTP_The.Value = DateTime.Now;
            dTP_Sinh.Value = DateTime.Now;
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
                || string.IsNullOrWhiteSpace(txtDT.Text)
                || string.IsNullOrWhiteSpace(txtDiaChi.Text) 
                || string.IsNullOrWhiteSpace(txtCMND.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin độc giả.");
                return;
            }

            long CMNDParsed;
            if (!long.TryParse(txtCMND.Text, out CMNDParsed))
            {
                MessageBox.Show("CCCD phải là dạng số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (CMNDParsed.ToString().Length != 12)
            {
                MessageBox.Show("CCCD phải đủ 12 số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            long DTParsed;
            if (!long.TryParse(txtDT.Text, out DTParsed))
            {
                MessageBox.Show("Số điện thoại phải là dạng số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (DTParsed.ToString().Length != 10)
            {
                MessageBox.Show("Số điện thoại phải đủ 10 số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(!btnNam.Checked && !btnNu.Checked)
            {
                MessageBox.Show("Vui lòng chọn giới tính.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maDocGiaMoi = _readersService.GenerateMaDocGia();
            DocGia newReader = new DocGia
            {
                MaDocGia = maDocGiaMoi,
                HoTenDocGia = txtHoTen.Text,
                GioiTinh = CheckedGioiTinh(),
                DienThoai = DTParsed,
                DiaChi = txtDiaChi.Text,
                CMND = CMNDParsed,
                NgaySinh = dTP_Sinh.Value,
                NgayLamThe = dTP_The.Value
            };

            bool result = _readersService.AddReader(newReader);
            if (result)
            {
                _frmReaders.LoadData();
                MessageBox.Show("Thêm độc giả thành công!");
                ClearFields();
            }
            else
            {
                MessageBox.Show("Mã độc giả đã tồn tại trong CSDL.");
                return;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Kiểm tra thông tin
            if (string.IsNullOrWhiteSpace(txtID_DG.Text) 
                || string.IsNullOrWhiteSpace(txtHoTen.Text)
                || string.IsNullOrWhiteSpace(txtDT.Text)
                || string.IsNullOrWhiteSpace(txtDiaChi.Text) 
                || string.IsNullOrWhiteSpace(txtCMND.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin độc giả.");
                return;
            }

            long CMNDParsed;
            if (!long.TryParse(txtCMND.Text, out CMNDParsed))
            {
                MessageBox.Show("CCCD phải là dạng số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (CMNDParsed.ToString().Length != 12)
            {
                MessageBox.Show("CCCD phải đủ 12 số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            long DTParsed;
            if (!long.TryParse(txtDT.Text, out DTParsed))
            {
                MessageBox.Show("Số điện thoại phải là dạng số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (DTParsed.ToString().Length != 10)
            {
                MessageBox.Show("Số điện thoại phải đủ 10 số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!btnNam.Checked && !btnNu.Checked)
            {
                MessageBox.Show("Vui lòng chọn giới tính.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DocGia updatedReader = new DocGia
            {
                MaDocGia = txtID_DG.Text,
                HoTenDocGia = txtHoTen.Text,
                GioiTinh = CheckedGioiTinh(),
                DienThoai = DTParsed,
                DiaChi = txtDiaChi.Text,
                CMND = CMNDParsed,
                NgaySinh = dTP_Sinh.Value,
                NgayLamThe = dTP_The.Value
            };

            bool result = _readersService.EditReader(updatedReader);
            if (result)
            {
                _frmReaders.LoadData();
                MessageBox.Show("Chỉnh sửa thông tin độc giả thành công!");
                ClearFields();
            }
            else
            {
                MessageBox.Show("Không tìm thấy độc giả với mã này.");
                return;
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            // Kiểm tra thông tin
            if (string.IsNullOrWhiteSpace(txtID_DG.Text))
            {
                MessageBox.Show("Vui lòng nhập chính xác mã độc giả.");
                return;
            }

            string maDocGia = txtID_DG.Text;

            DialogResult confirmResult = MessageBox.Show("Bạn có chắc muốn xóa độc giả này?", "Xác nhận xóa", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                bool result = _readersService.DeleteReader(maDocGia);
                if (result)
                {
                    _frmReaders.LoadData();
                    MessageBox.Show("Xóa độc giả thành công!");
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy độc giả với mã này.");
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
                isSearching = false;
                try
                {
                    _frmReaders.LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                btnSearch.Text = "Tìm kiếm";
            }
            else
            {
                var filteredReaders = _readersService.SearchReaders(searchText);
                if (filteredReaders.Any())
                {
                    try
                    {
                        isSearching = true;
                        _frmReaders.BindGrid(filteredReaders);
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
