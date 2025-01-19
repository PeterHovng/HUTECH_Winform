using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class GenresService
    {
        private readonly LibraryData _context = new LibraryData();

        // Lấy toàn bộ danh sách thể loại
        public List<GenresViewModel> GetAllGenres()
        {
            var genres = (from g in _context.TheLoai
                          select new GenresViewModel
                          {
                              MaTheLoai = g.MaTheLoai,
                              TenTheLoai = g.TenTheLoai
                          }).ToList();
            return genres;
        }

        // Thêm thể loại mới
        public bool AddGenre(TheLoai genre)
        {
            if (_context.TheLoai.Any(g => g.MaTheLoai == genre.MaTheLoai))
                return false; // Nếu mã thể loại đã tồn tại, không thêm

            _context.TheLoai.Add(genre);
            _context.SaveChanges();
            return true;
        }

        // Chỉnh sửa thông tin thể loại
        public bool EditGenre(string maTheLoai, string tenTheLoaiMoi)
        {
            var existingTheLoai = _context.TheLoai.FirstOrDefault(t => t.MaTheLoai == maTheLoai);
            if (existingTheLoai == null)
                return false; // Không tìm thấy thể loại cần sửa

            existingTheLoai.TenTheLoai = tenTheLoaiMoi;
            _context.SaveChanges();
            return true;
        }

        // Xóa thể loại
        public bool DeleteGenre(string maTheLoai)
        {
            var genre = _context.TheLoai.Find(maTheLoai);
            if (genre == null) return false;

            _context.TheLoai.Remove(genre);
            _context.SaveChanges();
            return true;
        }

        // Tìm kiếm thể loại
        public List<GenresViewModel> SearchGenres(string searchText)
        {
            var allGenres = GetAllGenres();
            var filteredGenres = allGenres
                .Where(g => g.MaTheLoai.Contains(searchText) || g.TenTheLoai.Contains(searchText))
                .Select(g => new GenresViewModel
                {
                    MaTheLoai = g.MaTheLoai,
                    TenTheLoai = g.TenTheLoai
                })
                .ToList();
            return filteredGenres;
        }

        // Sinh mã tự động cho thể loại
        public string GenerateMaTheLoai()
        {
            var maxMaTheLoai = _context.TheLoai
                            .Where(g => g.MaTheLoai.StartsWith("TL"))
                            .OrderByDescending(g => g.MaTheLoai)
                            .Select(g => g.MaTheLoai)
                            .FirstOrDefault();

            if (maxMaTheLoai == null)
            {
                return "TL001";
            }

            var numericPart = int.Parse(maxMaTheLoai.Substring(2));
            numericPart++;

            return "TL" + numericPart.ToString("D3");
        }
    }
    public class GenresViewModel
    {
        public string MaTheLoai { get; set; }
        public string TenTheLoai { get; set; }
    }
}
