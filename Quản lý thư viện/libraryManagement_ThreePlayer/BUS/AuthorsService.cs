using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class AuthorsService
    {
        private readonly LibraryData _context = new LibraryData();
        
        //Lấy toàn bộ danh sách
        public List<AuthorsViewModel> GetAllAuthor()
        {
            var authors = (from s in _context.TacGia
                         select new AuthorsViewModel
                         {
                             MaTacGia = s.MaTacGia,
                             HoTenTacGia = s.HoTenTacGia,
                             GioiTinh = s.GioiTinh,
                             QueQuan = s.QueQuan
                         }).ToList();
            return authors;
        }

        public List<AuthorsViewModel> GetAllAuthorByName()
        {
            var authors = (from s in _context.TacGia
                           select new AuthorsViewModel
                           {
                               MaTacGia = s.MaTacGia,
                               HoTenTacGia = s.HoTenTacGia
                           }).ToList();
            return authors;
        }


        // Thêm tác giả mới
        public bool AddAuthor(TacGia author)
        {
            if (_context.TacGia.Any(a => a.MaTacGia == author.MaTacGia))
                return false; // Nếu mã tác giả đã tồn tại, không thêm

            _context.TacGia.Add(author);
            _context.SaveChanges();
            return true;
        }

        // Chỉnh sửa thông tin tác giả
        public bool EditAuthor(TacGia updatedAuthor)
        {
            var existingAuthor = _context.TacGia.Find(updatedAuthor.MaTacGia);
            if (existingAuthor == null) return false;

            existingAuthor.HoTenTacGia = updatedAuthor.HoTenTacGia;
            existingAuthor.GioiTinh = updatedAuthor.GioiTinh;
            existingAuthor.QueQuan = updatedAuthor.QueQuan;

            _context.SaveChanges();
            return true;
        }

        // Xóa tác giả
        public bool DeleteAuthor(string maTacGia)
        {
            var author = _context.TacGia.Find(maTacGia);
            if (author == null) return false;

            _context.TacGia.Remove(author);
            _context.SaveChanges();
            return true;
        }

        //Tìm kiếm
        public List<AuthorsViewModel> SearchAuthors(string searchText)
        {
            var allAuthors = GetAllAuthor();
            var filteredAuthors = allAuthors
                .Where(a => a.MaTacGia.Contains(searchText) || a.HoTenTacGia.Contains(searchText)
                || a.GioiTinh.Contains(searchText) || a.QueQuan.Contains(searchText))
                .Select(a => new AuthorsViewModel
                {
                    MaTacGia = a.MaTacGia,
                    HoTenTacGia= a.HoTenTacGia,
                    GioiTinh = a.GioiTinh,
                    QueQuan = a.QueQuan
                })
                .ToList();
            return filteredAuthors;
        }

        //Sinh mã tự động
        public string GenerateMaTacGia()
        {
            // Tìm mã sách lớn nhất hiện tại
            var maxMaTacGia = _context.TacGia
                            .Where(s => s.MaTacGia.StartsWith("TG"))
                            .OrderByDescending(s => s.MaTacGia)
                            .Select(s => s.MaTacGia)
                            .FirstOrDefault();

            if (maxMaTacGia == null)
            {
                return "TG001";
            }

            var numericPart = int.Parse(maxMaTacGia.Substring(2));
            numericPart++;

            return "TG" + numericPart.ToString("D3");
        }

        public class AuthorsViewModel
        {
            public string MaTacGia { get; set; }
            public string HoTenTacGia { get; set; }
            public string GioiTinh { get; set; }
            public string QueQuan { get; set; }
        }
    }
}
