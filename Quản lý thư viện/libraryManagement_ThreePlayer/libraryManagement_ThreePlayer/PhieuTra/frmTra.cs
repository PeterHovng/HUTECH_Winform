using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Navigation;

namespace libraryManagement_ThreePlayer.PhieuTra
{
    public partial class frmTra : Form
    {
        private readonly ReturnService _returnService = new ReturnService();
        private readonly frmManagement parentForm;

        public frmTra(frmManagement mainForm)
        {
            InitializeComponent();
            parentForm = mainForm;
        }

        public void LoadData()
        {
            try
            {
                var data = _returnService.GetReturn();
                BindGrid(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        public void BindGrid(List<ReturnViewModel> dataList)
        {
            dgvReturn.Rows.Clear();

            foreach (var item in dataList)
            {
                int index = dgvReturn.Rows.Add();
                dgvReturn.Rows[index].Cells[0].Value = item.MaPhieuTra;
                dgvReturn.Rows[index].Cells[1].Value = item.MaPhieuMuon;
                dgvReturn.Rows[index].Cells[2].Value = item.NgayLap;
                dgvReturn.Rows[index].Cells[3].Value = item.MaNhanVien;
            }
        }

        private void frmTra_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvReturn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvReturn.Rows.Count > 0 && dgvReturn.CurrentRow != null)
            {
                DataGridViewRow selectedRow = dgvReturn.CurrentRow;
                if (parentForm.frmStaffToolsInstance == null || parentForm.frmStaffToolsInstance.IsDisposed)
                {
                    parentForm.btnReturn_Click(sender, e);
                }
                parentForm.UpdateTraToolsForm(selectedRow);
            }
        }

        public string GetMaNhanVien()
        {
            return parentForm.GetMaNhanVien();
        }

        private void dgvReturn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
