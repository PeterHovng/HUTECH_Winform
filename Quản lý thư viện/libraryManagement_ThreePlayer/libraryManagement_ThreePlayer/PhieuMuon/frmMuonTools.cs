using BUS;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static BUS.BorrowService;

namespace libraryManagement_ThreePlayer.PhieuMuon
{
    public partial class frmMuonTools : Form
    {
        private frmMuon _frmBorrows;
        private bool isSearching = false;

        //Hàm khởi tạo Service
        private BorrowService _borrowService = new BorrowService();
        private ReadersService _readersService = new ReadersService();
        private BooksService _booksService = new BooksService();

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

        public frmMuonTools(frmMuon frmMuon)
        {
            InitializeComponent();
            _frmBorrows = frmMuon;
        }

        private void frmMuonTools_Load(object sender, EventArgs e)
        {
            AdjustForm();
        }

        // Hàm nhận dữ liệu

        public void SetDocGiaText(string docGia)
        {
            txtDocGia.Text = docGia;
        }

        public void SetSachText(string Sach)
        {
            txtSach.Text = Sach;
        }

        // Code chức năng

        private void ClearFields()
        {
            txtMaPhieu.Clear();
            txtSach.Clear();
            txtDocGia.Clear();
            cmbInfo.Items.Clear();
            cmbInfo.Text = "";
            txtSoLuong.Clear();
            dTP_NgayMuon.Value = DateTime.Now;
            dTP_NgayTra.Value = DateTime.Now;
        }

        // Hàm khóa chức năng
        private void Locked(bool x)
        {
            if (x) 
            {
                btnSach.Enabled = false;
                btnDocGia.Enabled = false;
                btnAddBook.Enabled = false;
                btnSave.Enabled = false;
                btnCancel.Enabled = false;
                txtSoLuong.Enabled = false;
                dTP_NgayMuon.Enabled = false;
                dTP_NgayTra.Enabled = false;
                btnEdit.Enabled = true;
                btnAdd.Enabled = true;
            }
            else
            {
                btnSach.Enabled = true;
                btnDocGia.Enabled = true;
                btnAddBook.Enabled = true;
                btnSave.Enabled = true;
                btnCancel.Enabled = true;
                txtSoLuong.Enabled = true;
                dTP_NgayMuon.Enabled = false;
                dTP_NgayTra.Enabled = true;
                btnEdit.Enabled = false;
                btnAdd.Enabled = false;
            }
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            // Kiểm tra txtSach không được để trống
            if (string.IsNullOrWhiteSpace(txtSach.Text))
            {
                MessageBox.Show("Tên sách không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra SoLuong phải là số và trong khoảng từ 0 đến 4
            if (!int.TryParse(txtSoLuong.Text, out int soLuong) || soLuong < 0 || soLuong > 4)
            {
                MessageBox.Show("Số lượng phải là một số từ 0 đến 4.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra xem TenSach đã tồn tại trong cmbInfo chưa
            bool exists = false;
            for (int i = 0; i < cmbInfo.Items.Count; i++)
            {
                var parts = cmbInfo.Items[i].ToString().Split('-');
                if (parts[0].Trim() == txtSach.Text.Trim())
                {
                    // Nếu SoLuong là 0, xóa mục hiện tại và không thêm lại
                    if (soLuong == 0)
                    {
                        cmbInfo.Items.RemoveAt(i);
                        MessageBox.Show("Đã xóa sách khỏi danh sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // Xóa mục hiện tại và đánh dấu tồn tại
                    cmbInfo.Items.RemoveAt(i);
                    exists = true;
                    break;
                }
            }

            // Nếu SoLuong là 0 và sách không có trong danh sách, không cần thêm
            if (soLuong == 0)
            {
                MessageBox.Show("Số lượng là 0 nên không cần thêm sách vào danh sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Kiểm tra tổng số lượng trong cmbInfo không vượt quá 4
            int totalQuantity = soLuong;
            foreach (var item in cmbInfo.Items)
            {
                var parts = item.ToString().Split('-');
                if (parts.Length == 2 && int.TryParse(parts[1].Trim(), out int existingQuantity))
                {
                    totalQuantity += existingQuantity;
                }
            }
            if (totalQuantity > 4)
            {
                MessageBox.Show("Tổng số lượng sách không được lớn hơn 4.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int soLuongKho = _booksService.GetSoLuongByTenSach(txtSach.Text);
            
            if (btnSave.Tag != "Edit" && (soLuongKho - soLuong < 0))
            {
                MessageBox.Show($"Số lượng sách '{txtSach.Text}' còn lại không đủ để mượn. Số lượng hiện tại: {soLuongKho}.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Thêm mới hoặc cập nhật lại mục TenSach và SoLuong
            cmbInfo.Items.Add($"{txtSach.Text.Trim()} - {soLuong}");
        }

        private void btnSach_Click(object sender, EventArgs e)
        {
            frmBookList bookListForm = new frmBookList();
            bookListForm.Owner = this;
            bookListForm.ShowDialog();
        }

        private void btnDocGia_Click(object sender, EventArgs e)
        {
            frmReaderList authorListForm = new frmReaderList();
            authorListForm.Owner = this;
            authorListForm.ShowDialog();
        }

        private void cmbInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbInfo.SelectedItem is ComboBoxItem selectedItem)
            {
                txtSach.Text = selectedItem.TenSach;

                var record = _borrowService.GetBorrowDetailBySttPhieuMuon(selectedItem.SttPhieuMuon);
                if (record != null)
                {
                    txtSoLuong.Text = record.SoLuong.ToString();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Locked(true);
            string maPhieuMuonMoi = _borrowService.GenerateMaPhieuMuon();
            string maPhieuMuon = txtMaPhieu.Text;
            string maDocGia;

            // Kiểm tra thông tin
            if (string.IsNullOrWhiteSpace(txtDocGia.Text) || string.IsNullOrEmpty(txtDocGia.Text))
            {
                MessageBox.Show("Vui lòng chọn thông tin độc giả.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            maDocGia = _readersService.GetMaDocGiaByTenDocGia(txtDocGia.Text);
            if (maDocGia == null)
            {
                MessageBox.Show("Không tìm thấy mã độc giả.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!string.IsNullOrEmpty(maPhieuMuon))
            {   
                // Kiểm tra nếu không có sách nào trong cmbInfo
                if (cmbInfo.Items.Count == 0)
                {
                    var confirmResult = MessageBox.Show("Thông tin sách mượn không có. Bạn có muốn xóa toàn bộ thông tin phiếu mượn này không?",
                                                        "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirmResult == DialogResult.Yes)
                    {
                        _borrowService.DeleteBorrowRecord(maPhieuMuon);
                        _frmBorrows.LoadData();
                        ClearFields();
                        MessageBox.Show("Đã xóa phiếu mượn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Hủy bỏ thao tác xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    return;
                }
            }

            var books = new List<(string TenSach, int SoLuong)>();
            foreach (var item in cmbInfo.Items)
            {
                var parts = item.ToString().Split('-');
                if (parts.Length == 2 && int.TryParse(parts[1].Trim(), out int soLuong))
                {
                    books.Add((parts[0].Trim(), soLuong));
                }
            }

            DateTime ngayMuon = dTP_NgayMuon.Value;
            DateTime ngayTra = dTP_NgayTra.Value;
            string maNhanVien = _frmBorrows.GetMaNhanVien();

            SaveOrUpdateResult result;
            if (btnSave.Tag?.ToString() != "Add" && !string.IsNullOrEmpty(maPhieuMuon))
            {
                result = _borrowService.UpdateBorrowRecord(maPhieuMuon, books, maDocGia, ngayMuon, ngayTra, maNhanVien);
                ClearFields();
            }
            else
            {
                if(cmbInfo.Items.Count != 0)
                {
                    result = _borrowService.SaveBorrowRecord(maPhieuMuonMoi, books, maDocGia, ngayMuon, ngayTra, maNhanVien);
                    ClearFields();
                }
                else 
                {
                    MessageBox.Show("Vui lòng nhập thông tin sách mượn trước khi lưu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            }

            if (!result.Success)
            {
                MessageBox.Show(result.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                _frmBorrows.LoadData();
                MessageBox.Show(result.Message, "Hoàn thành", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Locked(true);
            ClearFields();
        }

        // Chức năng thêm sửa
        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnSave.Tag = "Add";
            ClearFields();
            Locked(false);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnSave.Tag = "Edit";
            Locked(false);
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
                    _frmBorrows.LoadData();
                    btnSearch.Text = "Tìm kiếm";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                var filteredAuthors = _borrowService.SearchBorrows(searchText);
                if (filteredAuthors.Any())
                {
                    try
                    {
                        isSearching = true;
                        _frmBorrows.BindGrid(filteredAuthors);
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
