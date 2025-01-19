using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BorrowService
    {
        private readonly LibraryData _context = new LibraryData();
        private readonly BooksService _booksService = new BooksService();

        public List<LoanRecordViewModel> GetAllLoanRecords()
        {
            var loanRecords = (from pm in _context.PhieuMuon
                               join nv in _context.NhanVien on pm.MaNhanVien equals nv.MaNhanVien
                               join dg in _context.DocGia on pm.MaDocGia equals dg.MaDocGia
                               join ctpm in _context.CT_PhieuMuon on pm.MaPhieuMuon equals ctpm.MaPhieuMuon
                               join s in _context.Sach on ctpm.MaSach equals s.MaSach
                               select new LoanRecordViewModel
                               {
                                   MaDocGia = pm.MaDocGia,
                                   MaNhanVien = pm.MaNhanVien,
                                   MaPhieuMuon = pm.MaPhieuMuon,
                                   HoTenNhanVien = nv.HoTenNhanVien,
                                   HoTenDocGia = dg.HoTenDocGia,
                                   NgayMuon = pm.NgayMuon,
                                   NgayTra = ctpm.NgayTra,
                                   SoLuong = ctpm.SoLuong,
                                   MaSach = ctpm.MaSach,
                                   TenSach = s.TenSach
                               }).ToList();
            return loanRecords;
        }

        public List<LoanRecordViewModel> GetLoanRecords()
        {
            var loanRecords = (from pm in _context.PhieuMuon
                               join nv in _context.NhanVien on pm.MaNhanVien equals nv.MaNhanVien
                               join dg in _context.DocGia on pm.MaDocGia equals dg.MaDocGia
                               join ctpm in _context.CT_PhieuMuon on pm.MaPhieuMuon equals ctpm.MaPhieuMuon into ctpmGroup
                               let ctpmLatest = ctpmGroup.OrderByDescending(ct => ct.NgayTra).FirstOrDefault()
                               select new LoanRecordViewModel
                               {
                                   MaPhieuMuon = pm.MaPhieuMuon,
                                   HoTenNhanVien = nv.HoTenNhanVien,
                                   HoTenDocGia = dg.HoTenDocGia,
                                   NgayMuon = pm.NgayMuon
                               }).ToList();

            return loanRecords;
        }

        public List<BookDetailViewModel> GetBookDetailsByMaPhieuMuon(string maPhieuMuon)
        {
            var bookDetails = (from ctpm in _context.CT_PhieuMuon
                               join s in _context.Sach on ctpm.MaSach equals s.MaSach
                               where ctpm.MaPhieuMuon == maPhieuMuon
                               orderby ctpm.sttPhieuMuon
                               select new BookDetailViewModel
                               {
                                   TenSach = s.TenSach,
                                   sttPhieuMuon = ctpm.sttPhieuMuon
                               }).ToList();

            return bookDetails;
        }

        public LoanRecordViewModel GetBorrowDetailBySttPhieuMuon(int sttPhieuMuon)
        {
            return (from ct in _context.CT_PhieuMuon
                    where ct.sttPhieuMuon == sttPhieuMuon
                    select new LoanRecordViewModel
                    {
                        SoLuong = ct.SoLuong
                    }).FirstOrDefault();
        }

        // Thêm mới

        public SaveOrUpdateResult SaveBorrowRecord(string maPhieuMuon, List<(string TenSach, int SoLuong)> books, string maDocGia, DateTime ngayMuon, DateTime ngayTra, string maNhanVien)
        {
            var result = new SaveOrUpdateResult();

            // Tạo mới phiếu mượn
            var borrowRecord = new PhieuMuon
            {
                MaPhieuMuon = maPhieuMuon,
                MaDocGia = maDocGia,
                NgayMuon = ngayMuon,
                MaNhanVien = maNhanVien // Cập nhật MaNhanVien khi thêm mới
            };
            _context.PhieuMuon.Add(borrowRecord);

            // Duyệt qua từng sách trong danh sách mượn để cập nhật CT_PhieuMuon
            foreach (var (tenSach, soLuong) in books)
            {
                var maSach = _booksService.GetBookIdByTitle(tenSach);
                if (string.IsNullOrEmpty(maSach))
                {
                    result.Message = $"Sách '{tenSach}' không tìm thấy.";
                    result.Success = false;
                    return result;
                }

                var sach = _context.Sach.FirstOrDefault(s => s.MaSach == maSach);
                if (sach == null || sach.SoLuong < soLuong)
                {
                    result.Message = $"Không đủ số lượng sách '{tenSach}'. Số lượng còn lại: {sach?.SoLuong ?? 0}.";
                    result.Success = false;
                    return result;
                }

                // Thêm mới bản ghi CT_PhieuMuon
                _context.CT_PhieuMuon.Add(new CT_PhieuMuon
                {
                    MaPhieuMuon = maPhieuMuon,
                    MaSach = maSach,
                    SoLuong = soLuong,
                    NgayTra = ngayTra // Cập nhật NgayTra
                });

                // Cập nhật số lượng sách trong kho
                _booksService.UpdateBookQuantity(maSach, soLuong);
                if (sach.SoLuong == 0)
                {
                    result.Message = $"Sách '{tenSach}' hiện đã hết.";
                }
            }

            try
            {
                _context.SaveChanges();
                result.Success = true;
                result.Message = "Thêm phiếu mượn thành công!";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Có lỗi khi thêm phiếu mượn: {ex.Message}";
            }

            return result;
        }

        // Cập nhật

        public SaveOrUpdateResult UpdateBorrowRecord(string maPhieuMuon, List<(string TenSach, int SoLuong)> books, string maDocGia, DateTime ngayMuon, DateTime ngayTra, string maNhanVien)
        {
            var result = new SaveOrUpdateResult();

            // Tìm phiếu mượn theo MaPhieuMuon
            var borrowRecord = _context.PhieuMuon.FirstOrDefault(p => p.MaPhieuMuon == maPhieuMuon);
            if (borrowRecord == null)
            {
                result.Success = false;
                result.Message = "Phiếu mượn không tồn tại.";
                return result;
            }

            // Cập nhật thông tin phiếu mượn
            borrowRecord.NgayMuon = ngayMuon;
            borrowRecord.MaDocGia = maDocGia;
            borrowRecord.MaNhanVien = maNhanVien;

            // Xử lý danh sách CT_PhieuMuon
            var existingDetails = _context.CT_PhieuMuon.Where(ct => ct.MaPhieuMuon == maPhieuMuon).ToList();

            // Xóa các sách không còn trong danh sách mới (books)
            foreach (var detail in existingDetails)
            {
                if (!books.Any(b => _booksService.GetBookIdByTitle(b.TenSach) == detail.MaSach))
                {
                    _context.CT_PhieuMuon.Remove(detail);
                }
            }

            // Cập nhật hoặc thêm mới sách trong danh sách mới (books)
            foreach (var (tenSach, soLuong) in books)
            {
                var maSach = _booksService.GetBookIdByTitle(tenSach);
                if (string.IsNullOrEmpty(maSach))
                {
                    result.Message = $"Sách '{tenSach}' không tìm thấy.";
                    result.Success = false;
                    return result;
                }

                var ctPhieuMuon = existingDetails.FirstOrDefault(ct => ct.MaSach == maSach);
                if (ctPhieuMuon != null)
                {
                    // Nếu đã có thì cập nhật số lượng mới và ngày trả
                    int oldQuantity = ctPhieuMuon.SoLuong;
                    ctPhieuMuon.SoLuong = soLuong;
                    ctPhieuMuon.NgayTra = ngayTra;

                    // Điều chỉnh số lượng sách trong kho
                    _booksService.UpdateBookQuantity(maSach, -(oldQuantity - soLuong));
                }
                else
                {
                    // Nếu chưa có thì thêm mới
                    _context.CT_PhieuMuon.Add(new CT_PhieuMuon
                    {
                        MaPhieuMuon = maPhieuMuon,
                        MaSach = maSach,
                        SoLuong = soLuong,
                        NgayTra = ngayTra
                    });

                    // Cập nhật số lượng sách trong kho
                    _booksService.UpdateBookQuantity(maSach, soLuong);
                }

                var sach = _context.Sach.FirstOrDefault(s => s.MaSach == maSach);
                if (sach == null || sach.SoLuong < soLuong)
                {
                    result.Message = $"Không đủ số lượng sách '{tenSach}'. Số lượng còn lại: {sach?.SoLuong ?? 0}.";
                    result.Success = false;
                    return result;
                }
            }

            try
            {
                _context.SaveChanges();
                result.Success = true;
                result.Message = "Dữ liệu được cập nhật thành công!";
            }
            catch (Exception ex)
            {
                result.Message = "Có lỗi xảy ra khi lưu dữ liệu: " + ex.Message;
                result.Success = false;
            }

            return result;
        }

        // Xóa

        public bool DeleteBorrowRecord(string maPhieuMuon)
        {
            try
            {
                // Lấy phiếu mượn từ MaPhieuMuon
                var borrowRecord = _context.PhieuMuon.FirstOrDefault(p => p.MaPhieuMuon == maPhieuMuon);

                if (borrowRecord == null)
                {
                    // Trả về false nếu không tìm thấy phiếu mượn
                    return false;
                }

                // Lấy danh sách chi tiết phiếu mượn liên quan đến MaPhieuMuon
                var borrowDetails = _context.CT_PhieuMuon.Where(ct => ct.MaPhieuMuon == maPhieuMuon).ToList();

                // Xóa các chi tiết phiếu mượn
                foreach (var detail in borrowDetails)
                {
                    // Khôi phục số lượng sách trong kho trước khi xóa chi tiết phiếu mượn
                    _booksService.UpdateBookQuantity(detail.MaSach, -detail.SoLuong);

                    // Xóa chi tiết phiếu mượn
                    _context.CT_PhieuMuon.Remove(detail);
                }

                // Xóa phiếu mượn
                _context.PhieuMuon.Remove(borrowRecord);

                // Lưu thay đổi vào cơ sở dữ liệu
                _context.SaveChanges();

                return true; // Trả về true nếu xóa thành công
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có lỗi xảy ra
                Console.WriteLine("Lỗi khi xóa phiếu mượn: " + ex.Message);
                return false;
            }
        }
        //Tìm kiếm

        public List<LoanRecordViewModel> SearchBorrows(string searchText)
        {
            var allLoan = GetLoanRecords();
            var filteredLoans = allLoan
                .Where(a => a.MaPhieuMuon.Contains(searchText) || a.HoTenNhanVien.Contains(searchText)
                || a.HoTenDocGia.Contains(searchText))
                .Select(a => new LoanRecordViewModel
                {
                    MaPhieuMuon = a.MaPhieuMuon,
                    HoTenNhanVien = a.HoTenNhanVien,
                    HoTenDocGia = a.HoTenDocGia,
                    NgayMuon = a.NgayMuon
                })
                .ToList();
            return filteredLoans;
        }

        // Sinh mã tự động

        public string GenerateMaPhieuMuon()
        {
            var maxMaPhieu = _context.PhieuMuon
                            .Where(s => s.MaPhieuMuon.StartsWith("M"))
                            .OrderByDescending(s => s.MaPhieuMuon)
                            .Select(s => s.MaPhieuMuon)
                            .FirstOrDefault();

            if (maxMaPhieu == null)
            {
                return "M0001";
            }

            var numericPart = int.Parse(maxMaPhieu.Substring(1));

            numericPart++;

            return "M" + numericPart.ToString("D4");
        }

        public int GetSoLuongByMaPhieuMuonAndMaSach(string maPhieuMuon, string maSach)
        {
            // Tìm `SoLuong` trong bảng `CT_PhieuMuon` dựa trên `MaPhieuMuon` và `MaSach`
            var soLuong = _context.CT_PhieuMuon
                          .Where(ct => ct.MaPhieuMuon == maPhieuMuon && ct.MaSach == maSach)
                          .Select(ct => ct.SoLuong)
                          .FirstOrDefault();

            return soLuong;
        }

    }
    // Lớp đại diện dữ liệu
    public class LoanRecordViewModel
    {
        public string MaPhieuMuon { get; set; }
        public string MaNhanVien { get; set; }
        public string HoTenNhanVien { get; set; }
        public string MaDocGia { get; set; }
        public string HoTenDocGia { get; set; }
        public DateTime NgayMuon { get; set; }
        public DateTime NgayTra { get; set; }
        public int SoLuong { get; set; }
        public string MaSach { get; set; }
        public string TenSach { get; set; }
    }

    public class BookDetailViewModel
    {
        public string TenSach { get; set; }
        public int sttPhieuMuon { get; set; }
    }

    public class SaveOrUpdateResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public bool IsNew { get; set; }
    }
}
