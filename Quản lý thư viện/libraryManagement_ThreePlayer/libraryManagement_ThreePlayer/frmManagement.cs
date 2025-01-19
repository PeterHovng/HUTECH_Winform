using BUS;
using DAL.Entities;
using libraryManagement_ThreePlayer.Account;
using libraryManagement_ThreePlayer.Authors;
using libraryManagement_ThreePlayer.Books;
using libraryManagement_ThreePlayer.PhieuMuon;
using libraryManagement_ThreePlayer.PhieuTra;
using libraryManagement_ThreePlayer.Readers;
using libraryManagement_ThreePlayer.TheLoai;
using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace libraryManagement_ThreePlayer
{
    public partial class frmManagement : Form
    {
        private readonly BorrowService _borrowService = new BorrowService();
        private readonly ReturnService _returnService = new ReturnService();

        //Khởi tạo frm
        public frmLogin frmLoginInstance;
        public frmBooks frmBooksInstance;
        public frmAuthors frmAuthorsInstance;
        public frmReaders frmReadersInstance;
        public frmStaffs frmStaffsInstance;
        public frmMuon frmBorrowInstance;
        public frmTra frmReturnInstance;
        public frmTheLoai frmTheLoaiInstance;

        public frmBookTools frmBookToolsInstance;
        public frmAuthorTools frmAuthorToolsInstance;
        public frmReaderTools frmReaderToolsInstance;
        public frmStaffTools frmStaffToolsInstance;
        public frmMuonTools frmBorrowToolsInstance;
        public frmTraTools frmReturnToolsInstance;
        public frmTheLoaiTools frmGenresToolsInstance;

        private Form activeForm = null; // Biến để lưu giữ form hiện tại

        //Khởi tạo các tham số cho frmStyle
        private int borderSize = 2;
        private Size formSize;

        public frmManagement()
        {
            InitializeComponent();
        }

        private void frmManagement_Load(object sender, EventArgs e)
        {
            formSize = this.ClientSize;
            this.Padding = new Padding(borderSize);
            this.BackColor = Color.FromArgb(242, 242, 242);
            this.FormBorderStyle = FormBorderStyle.Sizable;
            frmLoginInstance = new frmLogin(this);
            LoadChildForm(frmLoginInstance);
            SetUserRole("Guest");
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
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MINIMIZE = 0xF020;
            const int SC_RESTORE = 0xF120;
            const int WM_NCHITTEST = 0x0084;
            const int resizeAreaSize = 10;

            #region Form Resize
            const int HTCLIENT = 1;
            const int HTLEFT = 10;
            const int HTRIGHT = 11;
            const int HTTOP = 12;
            const int HTTOPLEFT = 13;
            const int HTTOPRIGHT = 14;
            const int HTBOTTOM = 15;
            const int HTBOTTOMLEFT = 16;
            const int HTBOTTOMRIGHT = 17;

            if (m.Msg == WM_NCHITTEST)
            {
                base.WndProc(ref m);
                if (this.WindowState == FormWindowState.Normal)
                {
                    if ((int)m.Result == HTCLIENT)
                    {
                        Point screenPoint = new Point(m.LParam.ToInt32());
                        Point clientPoint = this.PointToClient(screenPoint);
                        if (clientPoint.Y <= resizeAreaSize)
                        {
                            if (clientPoint.X <= resizeAreaSize)
                                m.Result = (IntPtr)HTTOPLEFT;
                            else if (clientPoint.X < (this.Size.Width - resizeAreaSize))
                                m.Result = (IntPtr)HTTOP;
                            else
                                m.Result = (IntPtr)HTTOPRIGHT;
                        }
                        else if (clientPoint.Y <= (this.Size.Height - resizeAreaSize))
                        {
                            if (clientPoint.X <= resizeAreaSize)
                                m.Result = (IntPtr)HTLEFT;
                            else if (clientPoint.X > (this.Width - resizeAreaSize))
                                m.Result = (IntPtr)HTRIGHT;
                        }
                        else
                        {
                            if (clientPoint.X <= resizeAreaSize)
                                m.Result = (IntPtr)HTBOTTOMLEFT;
                            else if (clientPoint.X < (this.Size.Width - resizeAreaSize))
                                m.Result = (IntPtr)HTBOTTOM;
                            else
                                m.Result = (IntPtr)HTBOTTOMRIGHT;
                        }
                    }
                }
                return;
            }
            #endregion

            if (m.Msg == WM_NCCALCSIZE && m.WParam.ToInt32() == 1)
            {
                return;
            }

            if (m.Msg == WM_SYSCOMMAND)
            {
                int wParam = (m.WParam.ToInt32() & 0xFFF0);
                if (wParam == SC_MINIMIZE)
                    formSize = this.ClientSize;
                if (wParam == SC_RESTORE)
                    this.Size = formSize;
            }

            base.WndProc(ref m);
        }

        private void frmManagement_Resize(object sender, EventArgs e)
        {
            AdjustForm();
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

        private void CollapseMenu()
        {
            if (this.pnlMenu.Width > 180)
            {
                pnlMenu.Width = 100;
                btnMenu.Text = "";
                btnMenu.ImageAlign = ContentAlignment.TopCenter;
                btnMenu.Padding = new Padding(0);
                btnMenu.Dock = DockStyle.Top;
                foreach (Button menuButton in pnlMenu.Controls.OfType<Button>())
                {
                    menuButton.Text = "";
                    menuButton.ImageAlign = ContentAlignment.TopCenter;
                    menuButton.Padding = new Padding(0);
                }
            }
            else
            {
                pnlMenu.Width = 200;
                btnMenu.Text = "   " + btnMenu.Tag.ToString();
                btnMenu.ImageAlign = ContentAlignment.TopCenter;
                btnMenu.Padding = new Padding(0, 0, 0, 0);
                btnMenu.Dock = DockStyle.Top;
                foreach (Button menuButton in pnlMenu.Controls.OfType<Button>())
                {
                    menuButton.Text = "   " + menuButton.Tag.ToString();
                    menuButton.ImageAlign = ContentAlignment.TopCenter;
                    menuButton.Padding = new Padding(10, 0, 0, 0);
                }
            }
        }

        private void btnMaxmize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                formSize = this.ClientSize;
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                this.Size = formSize;
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            formSize = this.ClientSize;
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoadChildForm(Form childForm)
        {
            if (pnlDesktop.Controls.Count > 0)
            {
                pnlDesktop.Controls[0].Dispose();
                pnlDesktop.Controls.Clear();
            }

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            pnlDesktop.Controls.Add(childForm);
            pnlDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            CollapseMenu();
        }

        private void frmManagement_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                formSize = this.ClientSize;
            }
        }

        //Hàm ràng buộc mở frm Tools
        private void OpenSingleForm(Form newForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }

            activeForm = newForm;
            activeForm.TopLevel = true;
            activeForm.TopMost = false;
            activeForm.Show();
        }

        //Menu
        private void btnSystems_Click(object sender, EventArgs e)
        {
            SystemMenu.Show(btnSystems, btnSystems.Width, 0);
        }

        private void btnManager_Click(object sender, EventArgs e)
        {
            ManagerMenu.Show(btnManager, btnManager.Width, 0);
        }

        private void btnTools_Click(object sender, EventArgs e)
        {
            ToolsMenu.Show(btnTools, btnTools.Width, 0);
        }
        private void btnPhieu_Click(object sender, EventArgs e)
        {
            PhieuMenu.Show(btnPhieu, btnPhieu.Width, 0);
        }

        // Xử lý đăng nhập
        private void loginMenu_Click(object sender, EventArgs e)
        {
            if (frmLoginInstance == null || frmLoginInstance.IsDisposed)
            {
                frmLoginInstance = new frmLogin(this);
                LoadChildForm(frmLoginInstance);
            }
            else
            {
                frmLoginInstance.BringToFront();
            }
        }

        public void UserActive(string user)
        {
            this.Tag = user;
        }

        public string _maNhanVien;

        public string GetMaNhanVien()
        {
            return _maNhanVien;
        }

        public void SetUserRole(string chucVu)
        {
            if (chucVu == "Guest")
            {
                logoutMenu.Enabled = false;
                loginMenu.Enabled = true;
                frmLoginInstance = new frmLogin(this);
                LoadChildForm(frmLoginInstance);

                btnManager.Enabled = false;
                btnTools.Enabled = false;
                btnPhieu.Enabled = false;
                labelUserName.Text = "[##] Chưa đăng nhập";
                labelChucVu.Text = "Chức vụ: Không có";
            }
            else if (chucVu == "Thủ thư")
            {
                logoutMenu.Enabled = true;
                loginMenu.Enabled = false;

                //Menu chính
                btnManager.Enabled = true;
                btnTools.Enabled = true;
                btnPhieu.Enabled = true;

                //Quản lý
                btnAuthors.Enabled = false;
                btnStaffs.Enabled = false;
                btnGenres.Enabled = false;

                //Công cụ
                btnAuthorTools.Enabled = false;
                btnStaffTools.Enabled = false;
                btnTheLoaiTools.Enabled = false;

                //Phiếu


            }
            else
            {//Admin
                logoutMenu.Enabled = true;
                loginMenu.Enabled = false;

                //Menu chính
                btnManager.Enabled = true;
                btnTools.Enabled = true;
                btnPhieu.Enabled = true;

                //Quản lý
                btnAuthors.Enabled = true;
                btnStaffs.Enabled = true;
                btnGenres.Enabled = true;

                //Công cụ
                btnAuthorTools.Enabled = true;
                btnStaffTools.Enabled = true;
                btnTheLoaiTools.Enabled = true;
            }
        }

        private void logoutMenu_Click(object sender, EventArgs e)
        {
            SetUserRole("Guest");
            if (activeForm != null) activeForm.Close();
            MessageBox.Show("Đăng xuất thành công.", "Thông báo", MessageBoxButtons.OK);
        }

        // frm GridView
        private void btnBooks_Click(object sender, EventArgs e)
        {
            if (frmBooksInstance == null || frmBooksInstance.IsDisposed)
            {
                frmBooksInstance = new frmBooks(this); // Truyền frmManagement vào frmBooks
                LoadChildForm(frmBooksInstance); // Mở form frmBooks
            }
            else
            {
                frmBooksInstance.BringToFront(); // Đưa frmBooks lên phía trước nếu đã mở
            }
        }

        private void btnAuthors_Click(object sender, EventArgs e)
        {
            if (frmAuthorsInstance == null || frmAuthorsInstance.IsDisposed)
            {
                frmAuthorsInstance = new frmAuthors(this);
                LoadChildForm(frmAuthorsInstance);
            }
            else
            {
                frmAuthorsInstance.BringToFront();
            }
        }

        private void btnReaders_Click(object sender, EventArgs e)
        {
            if (frmReadersInstance == null || frmReadersInstance.IsDisposed)
            {
                frmReadersInstance = new frmReaders(this);
                LoadChildForm(frmReadersInstance);
            }
            else
            {
                frmReadersInstance.BringToFront();
            }
        }

        private void btnStaffs_Click(object sender, EventArgs e)
        {
            if (frmStaffsInstance == null || frmStaffsInstance.IsDisposed)
            {
                frmStaffsInstance = new frmStaffs(this);
                LoadChildForm(frmStaffsInstance);
            }
            else
            {
                frmReadersInstance.BringToFront();
            }
        }

        private void btnMuon_Click(object sender, EventArgs e)
        {
            if (frmBorrowInstance == null || frmBorrowInstance.IsDisposed)
            {
                frmBorrowInstance = new frmMuon(this);
                LoadChildForm(frmBorrowInstance);
            }
            else
            {
                frmBorrowInstance.BringToFront();
            }
        }

        private void btnTra_Click(object sender, EventArgs e)
        {
            if (frmReturnInstance == null || frmReturnInstance.IsDisposed)
            {
                frmReturnInstance = new frmTra(this);
                LoadChildForm(frmReturnInstance);
            }
            else
            {
                frmReturnInstance.BringToFront();
            }
        }

        private void btnGenres_Click(object sender, EventArgs e)
        {
            if (frmTheLoaiInstance == null || frmTheLoaiInstance.IsDisposed)
            {
                frmTheLoaiInstance = new frmTheLoai(this); // Truyền frmManagement vào frmBooks
                LoadChildForm(frmTheLoaiInstance); // Mở form frmBooks
            }
            else
            {
                frmTheLoaiInstance.BringToFront(); // Đưa frmBooks lên phía trước nếu đã mở
            }
        }

        // frmTools
        public void btnBookTools_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem frmBooksInstance đã được khởi tạo chưa
            if (frmBooksInstance == null || frmBooksInstance.IsDisposed)
            {
                MessageBox.Show("Vui lòng mở danh sách trước khi sử dụng công cụ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra xem frmBookTools đã mở hay chưa
            if (frmBookToolsInstance == null || frmBookToolsInstance.IsDisposed)
            {
                frmBookToolsInstance = new frmBookTools(frmBooksInstance); // Truyền frmBooksInstance vào frmBookTools
                OpenSingleForm(frmBookToolsInstance); // Mở frmBookTools
            }
        }

        public void btnAuthorTools_Click(object sender, EventArgs e)
        {
            if (frmAuthorsInstance == null || frmAuthorsInstance.IsDisposed)
            {
                MessageBox.Show("Vui lòng mở danh sách trước khi sử dụng công cụ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (frmAuthorToolsInstance == null || frmAuthorToolsInstance.IsDisposed)
            {
                frmAuthorToolsInstance = new frmAuthorTools(frmAuthorsInstance);
                OpenSingleForm(frmAuthorToolsInstance);
            }
        }

        public void btnReaderTools_Click(object sender, EventArgs e)
        {
            if (frmReadersInstance == null || frmReadersInstance.IsDisposed)
            {
                MessageBox.Show("Vui lòng mở danh sách trước khi sử dụng công cụ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (frmReaderToolsInstance == null || frmReaderToolsInstance.IsDisposed)
            {
                frmReaderToolsInstance = new frmReaderTools(frmReadersInstance);
                OpenSingleForm(frmReaderToolsInstance);
            }
        }

        public void btnStaffTools_Click(object sender, EventArgs e)
        {
            if (frmStaffsInstance == null || frmStaffsInstance.IsDisposed)
            {
                MessageBox.Show("Vui lòng mở danh sách trước khi sử dụng công cụ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (frmStaffToolsInstance == null || frmStaffToolsInstance.IsDisposed)
            {
                frmStaffToolsInstance = new frmStaffTools(frmStaffsInstance);
                OpenSingleForm(frmStaffToolsInstance);
            }
        }

        public void btnBorrowTools_Click(object sender, EventArgs e)
        {
            if (frmBorrowInstance == null || frmBorrowInstance.IsDisposed)
            {
                MessageBox.Show("Vui lòng mở danh sách trước khi sử dụng công cụ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (frmBorrowToolsInstance == null || frmBorrowToolsInstance.IsDisposed)
            {
                frmBorrowToolsInstance = new frmMuonTools(frmBorrowInstance);
                OpenSingleForm(frmBorrowToolsInstance);
            }
        }

        public void btnReturn_Click(object sender, EventArgs e)
        {
            if (frmReturnInstance == null || frmReturnInstance.IsDisposed)
            {
                MessageBox.Show("Vui lòng mở danh sách trước khi sử dụng công cụ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (frmReturnToolsInstance == null || frmReturnToolsInstance.IsDisposed)
            {
                frmReturnToolsInstance = new frmTraTools(frmReturnInstance);
                OpenSingleForm(frmReturnToolsInstance);
            }
        }

        public void btnTheLoaiTools_Click(object sender, EventArgs e)
        {
            if (frmTheLoaiInstance == null || frmTheLoaiInstance.IsDisposed)
            {
                MessageBox.Show("Vui lòng mở danh sách trước khi sử dụng công cụ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (frmGenresToolsInstance == null || frmGenresToolsInstance.IsDisposed)
            {
                frmGenresToolsInstance = new frmTheLoaiTools(frmTheLoaiInstance);
                OpenSingleForm(frmGenresToolsInstance);
            }
        }

        // Hàm xử lý đổ dữ liệu vào frmTools
        public void UpdateBookToolsForm(DataGridViewRow selectedRow)
        {
            if (frmBookToolsInstance != null && !frmBookToolsInstance.IsDisposed)
            {
                frmBookToolsInstance.txtMaSach.Text = selectedRow.Cells[0].Value.ToString();
                frmBookToolsInstance.txtTenSach.Text = selectedRow.Cells[1].Value.ToString();
                frmBookToolsInstance.cmbTheLoai.Text = selectedRow.Cells[2].Value.ToString();
                frmBookToolsInstance.cmbAuthor.Text = selectedRow.Cells[3].Value.ToString();
                frmBookToolsInstance.txtNXB.Text = selectedRow.Cells[4].Value.ToString();
                frmBookToolsInstance.dTP_NXB.Value = Convert.ToDateTime(selectedRow.Cells[5].Value);
                frmBookToolsInstance.txtSoLuong.Text = selectedRow.Cells[6].Value.ToString();
                frmBookToolsInstance.txtGiaTien.Text = selectedRow.Cells[7].Value.ToString();
            }
        }

        public void UpdateAuthorToolsForm(DataGridViewRow selectedRow)
        {
            if (frmAuthorToolsInstance != null && !frmAuthorToolsInstance.IsDisposed)
            {
                frmAuthorToolsInstance.txtID_TG.Text = selectedRow.Cells[0].Value.ToString();
                frmAuthorToolsInstance.txtHoTen.Text = selectedRow.Cells[1].Value.ToString();
                if (selectedRow.Cells[2].Value.ToString() == "Nam")
                {
                    frmAuthorToolsInstance.btnNam.Checked = true;
                    frmAuthorToolsInstance.btnNu.Checked = false;
                }
                else
                {
                    frmAuthorToolsInstance.btnNam.Checked = false;
                    frmAuthorToolsInstance.btnNu.Checked = true;
                }
                frmAuthorToolsInstance.txtQueQuan.Text = selectedRow.Cells[3].Value.ToString();
            }
        }

        public void UpdateReaderToolsForm(DataGridViewRow selectedRow)
        {
            if (frmReaderToolsInstance != null && !frmReaderToolsInstance.IsDisposed)
            {
                frmReaderToolsInstance.txtID_DG.Text = selectedRow.Cells[0].Value.ToString();
                frmReaderToolsInstance.txtHoTen.Text = selectedRow.Cells[1].Value.ToString();
                if (selectedRow.Cells[2].Value.ToString() == "Nam")
                {
                    frmReaderToolsInstance.btnNam.Checked = true;
                    frmReaderToolsInstance.btnNu.Checked = false;
                }
                else
                {
                    frmReaderToolsInstance.btnNam.Checked = false;
                    frmReaderToolsInstance.btnNu.Checked = true;
                }
                frmReaderToolsInstance.txtDiaChi.Text = selectedRow.Cells[3].Value.ToString();
                frmReaderToolsInstance.txtDT.Text = selectedRow.Cells[4].Value.ToString();
                frmReaderToolsInstance.txtCMND.Text = selectedRow.Cells[5].Value.ToString();
                frmReaderToolsInstance.dTP_Sinh.Value = Convert.ToDateTime(selectedRow.Cells[6].Value);
                frmReaderToolsInstance.dTP_The.Value = Convert.ToDateTime(selectedRow.Cells[6].Value);
            }
        }

        public void UpdateStaffToolsForm(DataGridViewRow selectedRow)
        {
            if (frmStaffToolsInstance != null && !frmStaffToolsInstance.IsDisposed)
            {
                frmStaffToolsInstance.txtMaNV.Text = selectedRow.Cells[0].Value.ToString();
                frmStaffToolsInstance.txtTenNV.Text = selectedRow.Cells[1].Value.ToString();
                frmStaffToolsInstance.txtCMND.Text = selectedRow.Cells[2].Value.ToString();
                frmStaffToolsInstance.cmbChucVu.Text = selectedRow.Cells[3].Value.ToString();
                if (selectedRow.Cells[4].Value.ToString() == "Nam")
                {
                    frmStaffToolsInstance.btnNam.Checked = true;
                    frmStaffToolsInstance.btnNu.Checked = false;
                }
                else
                {
                    frmStaffToolsInstance.btnNam.Checked = false;
                    frmStaffToolsInstance.btnNu.Checked = true;
                }
                frmStaffToolsInstance.txtDiaChi.Text = selectedRow.Cells[5].Value.ToString();
                frmStaffToolsInstance.txtMatKhau.Text = selectedRow.Cells[6].Value.ToString();
                frmStaffToolsInstance.dTP_NgaySinh.Value = Convert.ToDateTime(selectedRow.Cells[7].Value);
                frmStaffToolsInstance.dTP_NVL.Value = Convert.ToDateTime(selectedRow.Cells[8].Value);
                frmStaffToolsInstance.btnShow.Image = Properties.Resources.eye_48;
            }
        }

        public void UpdateTheLoaiToolsForm(DataGridViewRow selectedRow)
        {
            if (frmGenresToolsInstance != null && !frmGenresToolsInstance.IsDisposed)
            {
                frmGenresToolsInstance.txtTL_ID.Text = selectedRow.Cells[0].Value.ToString();
                frmGenresToolsInstance.txtTenTL.Text = selectedRow.Cells[1].Value.ToString();
            }
        }

        public void UpdateBorrowToolsForm(DataGridViewRow selectedRow)
        {
            if (frmBorrowToolsInstance != null && !frmBorrowToolsInstance.IsDisposed)
            {
                // Lấy MaPhieuMuon từ hàng được chọn
                string maPhieuMuon = selectedRow.Cells[0].Value.ToString();

                // Lấy toàn bộ danh sách
                var borrowRecord = _borrowService.GetAllLoanRecords().FirstOrDefault(b => b.MaPhieuMuon == maPhieuMuon);

                if (borrowRecord != null)
                {
                    frmBorrowToolsInstance.txtSoLuong.Text = borrowRecord.SoLuong.ToString();
                    frmBorrowToolsInstance.dTP_NgayTra.Text = borrowRecord.NgayTra.ToString();
                }

                // Đặt giá trị cho txtMaPhieu và txtDocGia
                frmBorrowToolsInstance.txtMaPhieu.Text = maPhieuMuon;
                frmBorrowToolsInstance.txtDocGia.Text = selectedRow.Cells[2].Value.ToString();
                frmBorrowToolsInstance.dTP_NgayMuon.Text = selectedRow.Cells[3].Value.ToString();

                // Lấy danh sách sách cho MaPhieuMuon
                var bookDetails = _borrowService.GetBookDetailsByMaPhieuMuon(maPhieuMuon);

                if (bookDetails != null)
                {
                    // Đổ TenSach và sttPhieuMuon vào cmbInfo
                    frmBorrowToolsInstance.cmbInfo.Items.Clear();
                    foreach (var book in bookDetails)
                    {
                        frmBorrowToolsInstance.cmbInfo.Items.Add(new ComboBoxItem { SttPhieuMuon = book.sttPhieuMuon, TenSach = book.TenSach });
                    }

                    // Hiển thị TenSach có sttPhieuMuon nhỏ nhất vào txtSach
                    if (bookDetails.Any())
                    {
                        frmBorrowToolsInstance.txtSach.Text = bookDetails.First().TenSach;
                    }
                }
            }
        }

        public void UpdateTraToolsForm(DataGridViewRow selectedRow)
        {
            if (frmReturnToolsInstance != null && !frmReturnToolsInstance.IsDisposed)
            {
                string maPhieuTra = selectedRow.Cells[0].Value.ToString();

                var returnRecord = _returnService.GetReturn().FirstOrDefault(b => b.MaPhieuTra == maPhieuTra);

                if (returnRecord != null)
                {
                    frmReturnToolsInstance.txtMaPhieuTra.Text = returnRecord.MaPhieuTra.ToString();
                    frmReturnToolsInstance.txtMaPhieuMuon.Text = returnRecord.MaPhieuMuon.ToString();
                    frmReturnToolsInstance.dTP_NgayLap.Text = returnRecord.NgayLap.ToString();
                }

                var docGia = _returnService.GetTenDocGiaByMaPhieuTra(maPhieuTra);
                frmReturnToolsInstance.txtDocGia.Text = docGia;

                var maPhieuMuon = _returnService.GetMaPhieuMuonByMaPhieuTra(maPhieuTra);

                // Lấy danh sách sách cho MaPhieuMuon
                var bookDetails = _borrowService.GetBookDetailsByMaPhieuMuon(maPhieuMuon);

                if (bookDetails != null)
                {
                    // Đổ TenSach và sttPhieuMuon vào cmbInfo
                    frmReturnToolsInstance.cmbInfo.Items.Clear();
                    foreach (var book in bookDetails)
                    {
                        frmReturnToolsInstance.cmbInfo.Items.Add(new ComboBoxItem { SttPhieuMuon = book.sttPhieuMuon, TenSach = book.TenSach });
                    }

                    // Hiển thị TenSach có sttPhieuMuon nhỏ nhất vào txtSach
                    if (bookDetails.Any())
                    {
                        frmReturnToolsInstance.txtSach.Text = bookDetails.First().TenSach;
                    }
                }

                var borrowRecord = _borrowService.GetAllLoanRecords().FirstOrDefault(b => b.MaPhieuMuon == maPhieuMuon);

                if (borrowRecord != null)
                {
                    frmReturnToolsInstance.txtSoLuong.Text = borrowRecord.SoLuong.ToString();
                }
            }
        }

        private void ToolsMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
    public class ComboBoxItem
        {
            public int SttPhieuMuon { get; set; }
            public string TenSach { get; set; }

            public override string ToString()
            {
                return TenSach;
            }
        }
    }
