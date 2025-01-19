using BUS;
using DAL.Entities;
using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace libraryManagement_ThreePlayer.PhieuTra
{
    public partial class frmTraTools : Form
    {
        private frmTra _frmReturn;
        private bool isSearching = false;

        //Hàm khởi tạo Service
        private ReturnService _returnService = new ReturnService();
        private BooksService _booksService = new BooksService();
        private BorrowService _borrowService = new BorrowService();
        private LibraryData _context = new LibraryData();

        //Tham số frmStyle
        private int borderSize = 2;
        private Size formSize;

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
        public frmTraTools(frmTra frmTra)
        {
            InitializeComponent();
            _frmReturn = frmTra;
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

        private void frmTraTools_Load(object sender, EventArgs e)
        {
            if(cmbInfo.Items.Count >= 0)
            {
                cmbInfo.SelectedItem = 0;
            }
        }

        //Code chức năng
        private void ClearFields()
        {
            txtMaPhieuTra.Clear();
            txtMaPhieuMuon.Clear();
            txtSach.Clear();
            txtDocGia.Clear();
            cmbInfo.Items.Clear();
            cmbInfo.Text = "";
            txtSoLuong.Clear();
            dTP_NgayLap.Value = DateTime.Now;
        }

        // Hàm khóa chức năng
        private void Locked(bool x)
        {
            if (x)
            {
                btnChon.Enabled = false;
                btnSave.Enabled = false;
                btnCancel.Enabled = false;
                txtSoLuong.Enabled = false;
                dTP_NgayLap.Enabled = false;
                btnReturn.Enabled = true;
            }
            else
            {
                btnChon.Enabled = true;
                btnSave.Enabled = true;
                btnCancel.Enabled = true;
                txtSoLuong.Enabled = true;
                dTP_NgayLap.Enabled = false;
                btnReturn.Enabled = false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearFields();
            Locked(false);

        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            frmMuonList muonListForm = new frmMuonList(this);
            muonListForm.Owner = this;
            muonListForm.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Locked(true);
            try
            {
                // Khởi tạo các biến và lấy thông tin cần thiết từ các control
                string maPhieuTra = _returnService.GenerateMaPhieuTra();
                string maPhieuMuon = txtMaPhieuMuon.Text;
                DateTime ngayLap = dTP_NgayLap.Value;
                string maNhanVien = _frmReturn.GetMaNhanVien();
                int SoLuong;
                int.TryParse(txtSoLuong.Text, out SoLuong);

                // Kiểm tra các giá trị quan trọng trước khi thêm mới
                if (string.IsNullOrEmpty(maPhieuMuon) || string.IsNullOrEmpty(maNhanVien))
                {
                    MessageBox.Show("Mã phiếu mượn và mã nhân viên không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy thông tin cho bảng CT_PhieuTra
                string tenSach = txtSach.Text;
                string maDocGia = _returnService.GetMaDocGiaByMaPhieuMuon(maPhieuMuon);

                if (string.IsNullOrEmpty(tenSach) || string.IsNullOrEmpty(maDocGia))
                {
                    MessageBox.Show("Thông tin sách và độc giả không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy MaSach từ TenSach bằng hàm GetBookIdByTitle trong BookService
                string maSach = _booksService.GetBookIdByTitle(tenSach);

                // Lấy sttPhieuMuon từ CT_PhieuMuon dựa trên MaPhieuMuon và MaSach
                int sttPhieuMuon = _returnService.GetSttPhieuMuon(maPhieuMuon, maSach);

                // Kiểm tra xem sttPhieuMuon đã tồn tại trong bảng CT_PhieuTra chưa
                var existingRecord = _returnService.GetCTPhieuTraBySttPhieuMuon(sttPhieuMuon);
                if (existingRecord != null)
                {
                    MessageBox.Show("Sách này đã được trả.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _booksService.UpdateBookQuantity(maSach, -SoLuong);
                    return;
                }

                // Thêm mới dữ liệu vào bảng PhieuTra
                var phieuTra = new DAL.Entities.PhieuTra
                {
                    MaPhieuTra = maPhieuTra,
                    MaPhieuMuon = maPhieuMuon,
                    NgayLap = ngayLap,
                    MaNhanVien = maNhanVien
                };

                _context.PhieuTra.Add(phieuTra);
                _context.SaveChanges();

                DateTime ngayTraSach = dTP_NgayLap.Value;

                // Thêm mới dữ liệu vào bảng CT_PhieuTra
                var ctPhieuTra = new CT_PhieuTra
                {
                    sttPhieuMuon = sttPhieuMuon,
                    MaPhieuTra = maPhieuTra,
                    MaDocGia = maDocGia,
                    NgayTraSach = ngayTraSach
                };

                _context.CT_PhieuTra.Add(ctPhieuTra);
                _context.SaveChanges();

                MessageBox.Show("Thêm mới dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _frmReturn.LoadData();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lấy TenSach từ mục được chọn trong cmbInfo
            string tenSach = cmbInfo.SelectedItem?.ToString();
            if (string.IsNullOrWhiteSpace(tenSach)) return;

            // Gán TenSach vào txtSach
            txtSach.Text = tenSach;

            // Lấy MaSach từ TenSach
            string maSach = _booksService.GetBookIdByTitle(tenSach);

            // Lấy MaPhieuMuon từ txtMaPhieuMuon
            string maPhieuMuon = txtMaPhieuMuon.Text;

            // Kiểm tra nếu `maSach` và `maPhieuMuon` không rỗng
            if (!string.IsNullOrEmpty(maSach) && !string.IsNullOrEmpty(maPhieuMuon))
            {
                // Gọi hàm BUS để lấy SoLuong từ MaPhieuMuon và MaSach
                int soLuong = _borrowService.GetSoLuongByMaPhieuMuonAndMaSach(maPhieuMuon, maSach);

                // Gán giá trị SoLuong vào txtSoLuong
                txtSoLuong.Text = soLuong.ToString();
            }
            else
            {
                MessageBox.Show("Không thể lấy thông tin số lượng. Vui lòng kiểm tra lại thông tin sách và mã phiếu mượn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearFields();
            Locked(true);
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
                    _frmReturn.LoadData();
                    btnSearch.Text = "Tìm kiếm";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                var filteredReturns = _returnService.SearchReturns(searchText);
                if (filteredReturns.Any())
                {
                    try
                    {
                        isSearching = true;
                        _frmReturn.BindGrid(filteredReturns);
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
