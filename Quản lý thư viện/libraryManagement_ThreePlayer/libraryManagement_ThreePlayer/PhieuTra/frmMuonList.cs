using BUS;
using DAL.Entities;
using libraryManagement_ThreePlayer.PhieuMuon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace libraryManagement_ThreePlayer.PhieuTra
{
    public partial class frmMuonList : Form
    {
        private readonly BorrowService _borrowService = new BorrowService();
        public frmTraTools frmReturnToolsInstance;
        private bool isSearching = false;

        public frmMuonList(frmTraTools frmTraTools)
        {
            InitializeComponent();
            frmReturnToolsInstance = frmTraTools;
        }

        public void LoadData()
        {
            try
            {
                var borrow = _borrowService.GetLoanRecords();
                BindGrid(borrow);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        public void BindGrid(List<LoanRecordViewModel> borrowList)
        {
            dgvBorrows.Rows.Clear();

            foreach (var item in borrowList)
            {
                int index = dgvBorrows.Rows.Add();
                dgvBorrows.Rows[index].Cells[0].Value = item.MaPhieuMuon;
                dgvBorrows.Rows[index].Cells[1].Value = item.HoTenNhanVien;
                dgvBorrows.Rows[index].Cells[2].Value = item.HoTenDocGia;
                dgvBorrows.Rows[index].Cells[3].Value = item.NgayMuon;
            }
        }

        private void frmMuonList_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvBorrows_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvBorrows.Rows.Count > 0 && dgvBorrows.CurrentRow != null)
            {
                string selectedPM = dgvBorrows.CurrentRow.Cells[0].Value.ToString();
                string selectedDG = dgvBorrows.CurrentRow.Cells[2].Value.ToString();

                DialogResult result = MessageBox.Show($"Bạn có chắc chắn chọn phiếu mượn '{selectedPM}' không?",
                                                      "Xác nhận",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Lấy danh sách sách cho MaPhieuMuon
                    var bookDetails = _borrowService.GetBookDetailsByMaPhieuMuon(selectedPM);

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

                    var parentForm = (frmTraTools)this.Owner;
                    frmReturnToolsInstance.txtMaPhieuMuon.Text = selectedPM;
                    frmReturnToolsInstance.txtDocGia.Text = selectedDG;
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
                var filteredReaders = _borrowService.SearchBorrows(searchText);
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
