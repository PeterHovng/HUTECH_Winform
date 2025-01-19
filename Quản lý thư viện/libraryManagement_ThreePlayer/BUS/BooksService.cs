using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BUS
{
    public class BooksService
    {
        private readonly LibraryData _context = new LibraryData();
        
        //Lấy toàn bộ danh sách
        public List<BookViewModel> GetAllBooks()
        {
            var books = (from s in _context.Sach
                         join t in _context.TacGia on s.MaTacGia equals t.MaTacGia
                         join tl in _context.TheLoai on s.MaTheLoai equals tl.MaTheLoai
                         select new BookViewModel
                         {
                             MaSach = s.MaSach,
                             TenSach = s.TenSach,
                             TenTheLoai = tl.TenTheLoai,
                             HoTenTacGia = t.HoTenTacGia,
                             NhaXuatBan = s.NhaXuatBan,
                             NgayXuatBan = s.NgayXuatBan,
                             SoLuong = s.SoLuong,
                             GiaTien = (float)s.GiaTien
                         }).ToList();
            return books;
        }
        
        //Thêm
        public bool AddBook(Sach book, string hoTenTacGia, string tenTheLoai)
        {
            // Kiểm tra nếu MaSach đã tồn tại
            if (_context.Sach.Any(b => b.MaSach == book.MaSach))
            {
                return false;
            }

            // Tìm MaTacGia dựa vào HoTenTacGia
            var tacGia = _context.TacGia.FirstOrDefault(t => t.HoTenTacGia == hoTenTacGia);
            if (tacGia == null)
            {
                return false;
            }

            // Tìm MaTheLoai dựa vào TenTheLoai
            var theLoai = _context.TheLoai.FirstOrDefault(t => t.TenTheLoai == tenTheLoai);
            if (theLoai == null)
            {
                return false;
            }

            // Gán MaTacGia và MaTheLoai từ tác giả tìm thấy
            book.MaTacGia = tacGia.MaTacGia;
            book.MaTheLoai = theLoai.MaTheLoai;

            // Thêm sách mới vào cơ sở dữ liệu
            _context.Sach.Add(book);
            _context.SaveChanges();
            return true;
        }
        
        //Xóa
        public bool DeleteBook(string maSach)
        {
            var book = _context.Sach.Find(maSach);
            if (book == null) return false;

            _context.Sach.Remove(book);
            _context.SaveChanges();
            return true;
        }
        
        //Cập nhật
        public bool UpdateBook(BookViewModel updatedBookViewModel)
        {
            var existingBook = _context.Sach.Find(updatedBookViewModel.MaSach);
            if (existingBook == null) return false;

            // Lấy MaTacGia dựa trên HoTenTacGia từ bảng TacGia
            var tacGia = _context.TacGia.FirstOrDefault(t => t.HoTenTacGia == updatedBookViewModel.HoTenTacGia);
            if (tacGia == null) return false; // Nếu không tìm thấy tác giả, trả về false

            // Cập nhật các thuộc tính của sách
            existingBook.TenSach = updatedBookViewModel.TenSach;
            existingBook.MaTheLoai = updatedBookViewModel.MaTheLoai;
            existingBook.NhaXuatBan = updatedBookViewModel.NhaXuatBan;
            existingBook.NgayXuatBan = updatedBookViewModel.NgayXuatBan;
            existingBook.MaTacGia = tacGia.MaTacGia; // Cập nhật MaTacGia
            existingBook.SoLuong = updatedBookViewModel.SoLuong;
            existingBook.GiaTien = updatedBookViewModel.GiaTien;

            _context.SaveChanges();
            return true;
        }

        //Lấy số lượng theo tên sách
        public int GetSoLuongByTenSach(string tenSach)
        {
            var sach = _context.Sach
                .AsNoTracking()
                .FirstOrDefault(s => s.TenSach == tenSach);
            if (sach == null)
                throw new InvalidOperationException($"Sách với tên '{tenSach}' không tồn tại trong cơ sở dữ liệu.");
            return sach.SoLuong;
        }

        //Tìm kiếm
        public List<BookViewModel> SearchBooks(string searchText)
        {
            // Lấy danh sách các sách với thông tin thể loại từ DAL
            var filteredBooks = (from book in _context.Sach
                                 join category in _context.TheLoai
                                 on book.MaTheLoai equals category.MaTheLoai
                                 join author in _context.TacGia
                                 on book.MaTacGia equals author.MaTacGia
                                 where book.MaSach.Contains(searchText)
                                     || book.TenSach.Contains(searchText)
                                     || category.TenTheLoai.Contains(searchText)
                                     || author.HoTenTacGia.Contains(searchText)
                                     || book.NhaXuatBan.Contains(searchText)
                                 select new BookViewModel
                                 {
                                     MaSach = book.MaSach,
                                     TenSach = book.TenSach,
                                     TenTheLoai = category.TenTheLoai,
                                     HoTenTacGia = author.HoTenTacGia,
                                     NhaXuatBan = book.NhaXuatBan,
                                     NgayXuatBan = book.NgayXuatBan,
                                     SoLuong = book.SoLuong,
                                     GiaTien = (float)book.GiaTien
                                 })
                                 .ToList();
            return filteredBooks;
        }

        //Sinh mã tự động
        public string GenerateMaSach()
        {
            // Tìm mã sách lớn nhất hiện tại
            var maxMaSach = _context.Sach
                            .Where(s => s.MaSach.StartsWith("S"))
                            .OrderByDescending(s => s.MaSach)
                            .Select(s => s.MaSach)
                            .FirstOrDefault();

            // Nếu không có mã nào, khởi tạo mã đầu tiên
            if (maxMaSach == null)
            {
                return "S0001";
            }

            // Lấy phần số của mã sách, bỏ ký tự 'S'
            var numericPart = int.Parse(maxMaSach.Substring(1));

            // Tăng giá trị lên 1
            numericPart++;

            // Ghép lại mã sách mới với định dạng S0001
            return "S" + numericPart.ToString("D4");
        }

        // Hàm lấy mã sách từ tên sách
        public string GetBookIdByTitle(string tenSach)
        {
            var book = _context.Sach.FirstOrDefault(b => b.TenSach == tenSach);
            return book?.MaSach;
        }

        // Hàm cập nhật số lượng sách trong kho
        public void UpdateBookQuantity(string maSach, int quantity)
        {
            var book = _context.Sach.FirstOrDefault(b => b.MaSach == maSach);
            if (book != null)
            {
                book.SoLuong -= quantity;
                if (book.SoLuong < 0) book.SoLuong = 0; // Đảm bảo không giảm dưới 0
                _context.SaveChanges();
            }
        }
    }

    public class BookViewModel
    {
        public string MaSach { get; set; }
        public string TenSach { get; set; }
        public string MaTheLoai { get; set; }
        public string TenTheLoai { get; set; }
        public string NhaXuatBan { get; set; }
        public DateTime NgayXuatBan { get; set; }
        public string HoTenTacGia { get; set; }
        public string MaTacGia { get; set; }
        public int SoLuong { get; set; }
        public float GiaTien { get; set; }
    }
}
