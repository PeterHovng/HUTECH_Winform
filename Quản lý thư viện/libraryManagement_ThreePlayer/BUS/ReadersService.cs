using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class ReadersService
    {
        private readonly LibraryData _context = new LibraryData();
        public List<ReaderViewModel> GetAllReaders()
        {
            var reader = (from s in _context.DocGia
                         select new ReaderViewModel
                         {
                             MaDocGia = s.MaDocGia,
                             HoTenDocGia = s.HoTenDocGia,
                             GioiTinh = s.GioiTinh,
                             DiaChi = s.DiaChi,
                             DienThoai = s.DienThoai,
                             CMND = s.CMND,
                             NgaySinh = s.NgaySinh,
                             NgayLamThe = s.NgayLamThe
                         }).ToList();
            return reader;
        }
        // Thêm độc giả mới
        public bool AddReader(DocGia reader)
        {
            if (_context.DocGia.Any(r => r.MaDocGia == reader.MaDocGia))
                return false; // Nếu mã độc giả đã tồn tại, không thêm

            _context.DocGia.Add(reader);
            _context.SaveChanges();
            return true;
        }

        // Chỉnh sửa thông tin độc giả
        public bool EditReader(DocGia updatedReader)
        {
            var existingReader = _context.DocGia.Find(updatedReader.MaDocGia);
            if (existingReader == null) return false;

            existingReader.HoTenDocGia = updatedReader.HoTenDocGia;
            existingReader.GioiTinh = updatedReader.GioiTinh;
            existingReader.DienThoai = updatedReader.DienThoai;
            existingReader.DiaChi = updatedReader.DiaChi;
            existingReader.CMND = updatedReader.CMND;
            existingReader.NgaySinh = updatedReader.NgaySinh;
            existingReader.NgayLamThe = updatedReader.NgayLamThe;

            _context.SaveChanges();
            return true;
        }

        // Xóa độc giả
        public bool DeleteReader(string maDocGia)
        {
            var reader = _context.DocGia.Find(maDocGia);
            if (reader == null) return false;

            _context.DocGia.Remove(reader);
            _context.SaveChanges();
            return true;
        }

        public List<ReaderViewModel> SearchReaders(string searchText)
        {
            var allReaders = GetAllReaders();
            var filteredReaders = allReaders
                .Where(r => r.MaDocGia.Contains(searchText) 
                || r.HoTenDocGia.Contains(searchText)
                || r.DiaChi.Contains(searchText) 
                || r.GioiTinh.Contains(searchText))
                .Select(r => new ReaderViewModel
                {
                    MaDocGia = r.MaDocGia,
                    HoTenDocGia = r.HoTenDocGia,
                    GioiTinh = r.GioiTinh,
                    DiaChi = r.DiaChi,
                    DienThoai = r.DienThoai,
                    CMND = r.CMND,
                    NgaySinh = r.NgaySinh,
                    NgayLamThe = r.NgayLamThe
                })
                .ToList();
            return filteredReaders;
        }

        //Sinh mã tự động
        public string GenerateMaDocGia()
        {
            // Tìm mã sách lớn nhất hiện tại
            var maxMaDocGia = _context.DocGia
                            .Where(s => s.MaDocGia.StartsWith("DG"))
                            .OrderByDescending(s => s.MaDocGia)
                            .Select(s => s.MaDocGia)
                            .FirstOrDefault();

            if (maxMaDocGia == null)
            {
                return "DG001";
            }

            var numericPart = int.Parse(maxMaDocGia.Substring(2));
            numericPart++;

            return "DG" + numericPart.ToString("D3");
        }

        // Lấy MaDocGia từ TenDocGia
        public string GetMaDocGiaByTenDocGia(string tenDocGia)
        {
            // Lấy MaDocGia dựa trên HoTenDocGia
            var maDocGia = _context.DocGia
                .Where(dg => dg.HoTenDocGia == tenDocGia)
                .Select(dg => dg.MaDocGia)
                .FirstOrDefault(); // Lấy giá trị đầu tiên hoặc null nếu không có

            return maDocGia; // Trả về MaDocGia tìm thấy
        }
    }

    public class ReaderViewModel
    {
        public string MaDocGia { get; set; }
        public string HoTenDocGia { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public long? DienThoai { get; set; }
        public long CMND { get; set; }
        public DateTime NgaySinh { get; set; }
        public DateTime NgayLamThe { get; set; }
    }
}
