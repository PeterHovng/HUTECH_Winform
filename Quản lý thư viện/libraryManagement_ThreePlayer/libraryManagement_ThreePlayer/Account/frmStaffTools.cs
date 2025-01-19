using BUS;
using DAL.Entities;
using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static BUS.StaffService;

namespace libraryManagement_ThreePlayer.Account
{
    public partial class frmStaffTools : Form
    {
        private frmStaffs _frmStaffs;
        private bool isSearching = false;

        //Hàm khởi tạo Service
        private StaffService _staffService = new StaffService();

        //Tham số frmStyle
        private int borderSize = 2;
        private Size formSize;

        public frmStaffTools(frmStaffs frmStaffs)
        {
            InitializeComponent();
            _frmStaffs = frmStaffs;
        }

        //Hàm tùy chỉnh frm
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        protected override void WndProc(ref Message m)
        {
            const int WM_NCCALCSIZE = 0x0083;

            if (m.Msg == WM_NCCALCSIZE && m.WParam.ToInt32() == 1)
            {
                return;
            }

            base.WndProc(ref m);
        }

        private void pnlTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
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

        private void frmStaffTools_Load(object sender, EventArgs e)
        {
            AdjustForm();
            LoadComboBox();
            ClearFields();
        }

        //Code chức năng
        private void LoadComboBox()
        {
            cmbChucVu.Items.Add("Thủ thư");
            cmbChucVu.Items.Insert(1, "Admin");
        }

        private void ClearFields()
        {
            txtMaNV.Clear();
            txtMatKhau.Clear();
            txtTenNV.Clear();
            txtCMND.Clear();
            txtDiaChi.Clear();
            cmbChucVu.SelectedValue = -1;
            dTP_NVL.Value = DateTime.Now;
            dTP_NgaySinh.Value = DateTime.Now;
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

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMatKhau.Text))
            {
                txtMatKhau.UseSystemPasswordChar = true;
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            // Bật hoặc tắt chế độ hiện mật khẩu
            txtMatKhau.UseSystemPasswordChar = !txtMatKhau.UseSystemPasswordChar;

            btnShow.Image = txtMatKhau.UseSystemPasswordChar
                ? Properties.Resources.eye_48
                : Properties.Resources.invisible_48;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Kiểm tra thông tin
            if (string.IsNullOrWhiteSpace(txtCMND.Text)
                || string.IsNullOrWhiteSpace(txtDiaChi.Text)
                || string.IsNullOrWhiteSpace(txtTenNV.Text)
                || string.IsNullOrWhiteSpace(txtMatKhau.Text)
                || string.IsNullOrWhiteSpace(cmbChucVu.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            string maNhanVienMoi = _staffService.GenerateMaNhanVien();
            string chucVu = cmbChucVu.Text;
            NhanVien newStaff = new NhanVien // Chuẩn bị đối tượng sách để thêm
            {
                MaNhanVien = maNhanVienMoi,
                CMND = CMNDParsed,
                DiaChi = txtDiaChi.Text,
                GioiTinh = CheckedGioiTinh(),
                HoTenNhanVien = txtTenNV.Text,
                MatKhau = txtMatKhau.Text,
                ChucVu = chucVu,
                NgaySinh = dTP_NgaySinh.Value,
                NgayVaoLam = dTP_NVL.Value,
            };

            bool result = _staffService.AddStaff(newStaff);
            if (result)
            {
                _frmStaffs.LoadData();
                MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
            }
            else
            {
                MessageBox.Show("Không thể thêm nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Kiểm tra thông tin
            if (string.IsNullOrWhiteSpace(txtMaNV.Text)
                || string.IsNullOrWhiteSpace(txtCMND.Text)
                || string.IsNullOrWhiteSpace(txtDiaChi.Text)
                || string.IsNullOrWhiteSpace(txtTenNV.Text)
                || string.IsNullOrWhiteSpace(txtMatKhau.Text)
                || string.IsNullOrWhiteSpace(cmbChucVu.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            string chucVu = cmbChucVu.Text;
            NhanVien updatedStaff = new NhanVien
            {
                MaNhanVien = txtMaNV.Text,
                CMND = CMNDParsed,
                DiaChi = txtDiaChi.Text,
                GioiTinh = CheckedGioiTinh(),
                HoTenNhanVien = txtTenNV.Text,
                MatKhau = txtMatKhau.Text,
                ChucVu = chucVu,
                NgaySinh = dTP_NgaySinh.Value,
                NgayVaoLam = dTP_NVL.Value,
            };

            if (_staffService.EditStaff(updatedStaff))
            {
                _frmStaffs.LoadData();
                MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
            }
            else
            {
                MessageBox.Show("Không tìm thấy nhân viên cần cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            // Kiểm tra thông tin
            if (string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maNhanVien = txtMaNV.Text;

            DialogResult confirmResult = MessageBox.Show("Bạn có chắc muốn xóa nhân viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                bool result = _staffService.DeleteStaff(maNhanVien);
                if (result)
                {
                    _frmStaffs.LoadData();
                    MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhân viên này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    _frmStaffs.LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                btnSearch.Text = "Tìm kiếm";
            }
            else
            {
                var filteredReaders = _staffService.SearchStaffs(searchText);
                if (filteredReaders.Any())
                {
                    try
                    {
                        isSearching = true;
                        _frmStaffs.BindGrid(filteredReaders);
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
