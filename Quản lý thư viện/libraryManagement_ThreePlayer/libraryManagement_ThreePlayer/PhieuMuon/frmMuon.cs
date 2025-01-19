using BUS;
using libraryManagement_ThreePlayer.Books;
using System.Collections.Generic;
using System;
using System.Windows.Forms;
using System.Linq;
using static BUS.BorrowService;

namespace libraryManagement_ThreePlayer.PhieuMuon
{
    public partial class frmMuon : Form
    {
        private readonly BorrowService _borrowService = new BorrowService();
        private readonly frmManagement parentForm;
        private frmMuonTools muonToolsForm;

        public frmMuon(frmManagement mainForm)
        {
            InitializeComponent();
            parentForm = mainForm;
        }

        public string GetMaNhanVien()
        {
            return parentForm.GetMaNhanVien();
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

        private void frmMuon_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvBorrows_MouseClick(object sender, MouseEventArgs e)
        {
            if (dgvBorrows.Rows.Count > 0 && dgvBorrows.CurrentRow != null)
            {
                DataGridViewRow selectedRow = dgvBorrows.CurrentRow;
                if (parentForm.frmStaffToolsInstance == null || parentForm.frmStaffToolsInstance.IsDisposed)
                {
                    parentForm.btnBorrowTools_Click(sender, e);
                }
                parentForm.UpdateBorrowToolsForm(selectedRow);
            }
        }
    }
}
