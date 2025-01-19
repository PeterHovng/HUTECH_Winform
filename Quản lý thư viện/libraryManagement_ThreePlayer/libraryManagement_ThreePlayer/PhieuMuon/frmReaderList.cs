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
using static BUS.AuthorsService;
using static BUS.ReadersService;

namespace libraryManagement_ThreePlayer.PhieuMuon
{
    public partial class frmReaderList : Form
    {
        private readonly ReadersService _readersService = new ReadersService();
        private bool isSearching = false;

        public frmReaderList()
        {
            InitializeComponent();
        }

        public void LoadData()
        {
            try
            {
                var reader = _readersService.GetAllReaders();
                BindGrid(reader);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        public void BindGrid(List<ReaderViewModel> readerList)
        {
            dgvReaders.Rows.Clear();

            foreach (var item in readerList)
            {
                int index = dgvReaders.Rows.Add();
                dgvReaders.Rows[index].Cells[0].Value = item.MaDocGia;
                dgvReaders.Rows[index].Cells[1].Value = item.HoTenDocGia;
                dgvReaders.Rows[index].Cells[2].Value = item.GioiTinh;
                dgvReaders.Rows[index].Cells[3].Value = item.DiaChi;
                dgvReaders.Rows[index].Cells[4].Value = item.DienThoai;
                dgvReaders.Rows[index].Cells[5].Value = item.CMND;
                dgvReaders.Rows[index].Cells[6].Value = item.NgaySinh;
                dgvReaders.Rows[index].Cells[7].Value = item.NgayLamThe;
            }
        }

        private void frmAuthorList_Load(object sender, EventArgs e)
        {
            LoadData();
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
                var filteredAuthors = _readersService.SearchReaders(searchText);
                if (filteredAuthors.Any())
                {
                    try
                    {
                        isSearching = true;
                        BindGrid(filteredAuthors);
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

        private void dgvReaders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvReaders.Rows.Count > 0 && dgvReaders.CurrentRow != null)
            {
                string selectedReader = dgvReaders.CurrentRow.Cells[1].Value.ToString();

                DialogResult result = MessageBox.Show($"Bạn có chắc chắn chọn độc giả '{selectedReader}' không?",
                                                      "Xác nhận",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    var parentForm = (frmMuonTools)this.Owner;
                    parentForm.SetDocGiaText(selectedReader);
                    this.Close();
                }
            }
        }
    }
}
