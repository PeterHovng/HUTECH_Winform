using BUS;
using System;
using System.Windows.Forms;

namespace libraryManagement_ThreePlayer
{
    public partial class frmLogin : Form
    {
        private readonly StaffService _staffService = new StaffService();
        private readonly frmManagement parentForm;

        public frmLogin(frmManagement mainForm)
        {
            InitializeComponent();
            parentForm = mainForm;
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xác thực tài khoản
            var account = _staffService.AuthenticateUser(user, password);

            if (account != null)
            {
                var staffInfo = _staffService.GetNameAndRole(user);
                if (staffInfo != null)
                {
                    parentForm.SetUserRole(account.ChucVu); // Thiết lập quyền của người dùng trên form cha
                    parentForm.labelUserName.Text = "[" + staffInfo.MaNhanVien + "] " + staffInfo.HoTenNhanVien;
                    parentForm.labelChucVu.Text = "Chức vụ: " + staffInfo.ChucVu;
                    parentForm._maNhanVien = account.MaNhanVien;
                    MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    parentForm.labelUserName.Text = "[##] Lỗi đăng nhập";
                    parentForm.labelChucVu.Text = "Chức vụ: Không có";
                    MessageBox.Show("Không tìm thấy thông tin nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPassword.Text))
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            // Bật hoặc tắt chế độ hiện mật khẩu
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;

            btnShow.Image = txtPassword.UseSystemPasswordChar
                ? Properties.Resources.eye_48
                : Properties.Resources.invisible_48;
        }
    }
}
