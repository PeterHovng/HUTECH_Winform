using BUS;
using libraryManagement_ThreePlayer.Books;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BUS.BooksService;
using static BUS.StaffService;

namespace libraryManagement_ThreePlayer.Account
{
    public partial class frmStaffs : Form
    {
        private readonly StaffService _staffService = new StaffService();
        private readonly frmManagement parentForm;
        private frmStaffTools frmStaffTools;

        public frmStaffs(frmManagement mainForm)
        {
            InitializeComponent();
            parentForm = mainForm;
        }

        public void LoadData()
        {
            try
            {
                var staff = _staffService.GetAllStaffs();
                BindGrid(staff);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        public void BindGrid(List<StaffViewModel> staffList)
        {
            dgvStaffs.Rows.Clear();
            foreach (var item in staffList)
            {
                int index = dgvStaffs.Rows.Add();
                dgvStaffs.Rows[index].Cells[0].Value = item.MaNhanVien;
                dgvStaffs.Rows[index].Cells[1].Value = item.HoTenNhanVien;
                dgvStaffs.Rows[index].Cells[2].Value = item.CMND;
                dgvStaffs.Rows[index].Cells[3].Value = item.ChucVu;
                dgvStaffs.Rows[index].Cells[4].Value = item.GioiTinh;
                dgvStaffs.Rows[index].Cells[5].Value = item.DiaChi;
                dgvStaffs.Rows[index].Cells[6].Value = item.MatKhau;
                dgvStaffs.Rows[index].Cells[7].Value = item.NgaySinh;
                dgvStaffs.Rows[index].Cells[8].Value = item.NgayVaoLam;
            }
        }

        private void frmStaffs_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvStaffs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvStaffs.Rows.Count > 0 && dgvStaffs.CurrentRow != null)
            {
                DataGridViewRow selectedRow = dgvStaffs.CurrentRow;
                if (parentForm.frmStaffToolsInstance == null || parentForm.frmStaffToolsInstance.IsDisposed)
                {
                    parentForm.btnStaffTools_Click(sender, e);
                }
                parentForm.UpdateStaffToolsForm(selectedRow);
            }
        }
    }
}
