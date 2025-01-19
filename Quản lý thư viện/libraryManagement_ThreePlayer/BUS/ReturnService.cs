using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BUS
{
    public class ReturnService
    {
        private readonly LibraryData _context = new LibraryData();

        public List<ReturnViewModel> GetReturn()
        {
            var list = (from s in _context.PhieuTra
                        select new ReturnViewModel
                        {
                            MaPhieuTra = s.MaPhieuTra,
                            MaPhieuMuon = s.MaPhieuMuon,
                            MaNhanVien = s.MaNhanVien,
                            NgayLap = s.NgayLap
                        }).ToList();
            return list;
        }

        public string GetTenDocGiaByMaPhieuTra(string maPhieuTra)
        {
            // Lấy MaPhieuMuon từ bản ghi PhieuTra
            var maPhieuMuon = _context.PhieuTra
                .Where(pt => pt.MaPhieuTra == maPhieuTra)
                .Select(pt => pt.MaPhieuMuon)
                .FirstOrDefault();

            if (maPhieuMuon == null)
            {
                throw new InvalidOperationException($"Không tìm thấy MaPhieuTra '{maPhieuTra}' trong cơ sở dữ liệu.");
            }

            // Lấy MaDocGia từ bản ghi PhieuMuon
            var maDocGia = _context.PhieuMuon
                .Where(pm => pm.MaPhieuMuon == maPhieuMuon)
                .Select(pm => pm.MaDocGia)
                .FirstOrDefault();

            if (maDocGia == null)
            {
                throw new InvalidOperationException($"Không tìm thấy MaDocGia tương ứng với MaPhieuMuon '{maPhieuMuon}'.");
            }

            // Lấy họ tên độc giả từ bảng DocGia
            var tenDocGia = _context.DocGia
                .Where(dg => dg.MaDocGia == maDocGia)
                .Select(dg => dg.HoTenDocGia)
                .FirstOrDefault();

            if (tenDocGia == null)
            {
                throw new InvalidOperationException($"Không tìm thấy độc giả với mã '{maDocGia}' trong cơ sở dữ liệu.");
            }

            return tenDocGia;
        }

        public List<CT_PhieuTra> GetCTPhieuTraByMaPhieuTra(string maPhieuTra)
        {
            // Kiểm tra xem MaPhieuTra có tồn tại trong bảng PhieuTra hay không
            var phieuTra = _context.PhieuTra.FirstOrDefault(pt => pt.MaPhieuTra == maPhieuTra);
            if (phieuTra == null)
            {
                throw new InvalidOperationException($"Không tìm thấy MaPhieuTra '{maPhieuTra}' trong cơ sở dữ liệu.");
            }

            // Lấy tất cả thông tin từ bảng CT_PhieuTra dựa trên MaPhieuTra
            var ctPhieuTraList = _context.CT_PhieuTra
                .Where(ct => ct.MaPhieuTra == maPhieuTra)
                .ToList();

            return ctPhieuTraList;
        }

        public List<string> GetTenSachByMaPhieuTra(string maPhieuTra)
        {
            // Bước 1: Lấy danh sách sttPhieuMuon từ bảng CT_PhieuTra dựa trên MaPhieuTra
            var sttPhieuMuonList = _context.CT_PhieuTra
                .Where(ctpt => ctpt.MaPhieuTra == maPhieuTra)
                .Select(ctpt => ctpt.sttPhieuMuon)
                .ToList();

            // Kiểm tra nếu không có sttPhieuMuon nào tồn tại trong CT_PhieuTra với MaPhieuTra truyền vào
            if (!sttPhieuMuonList.Any())
            {
                throw new InvalidOperationException($"Không tìm thấy sttPhieuMuon nào cho MaPhieuTra '{maPhieuTra}' trong bảng CT_PhieuTra.");
            }

            // Bước 2: Lấy danh sách MaSach từ bảng CT_PhieuMuon dựa trên danh sách sttPhieuMuon
            var maSachList = _context.CT_PhieuMuon
                .Where(ctpm => sttPhieuMuonList.Contains(ctpm.sttPhieuMuon))
                .Select(ctpm => ctpm.MaSach)
                .Distinct()
                .ToList();

            // Kiểm tra nếu không có MaSach nào trong CT_PhieuMuon với các sttPhieuMuon này
            if (!maSachList.Any())
            {
                throw new InvalidOperationException("Không tìm thấy MaSach nào liên quan đến các sttPhieuMuon trong bảng CT_PhieuMuon.");
            }

            // Bước 3: Lấy danh sách TenSach từ bảng Sach dựa trên danh sách MaSach
            var tenSachList = _context.Sach
                .Where(s => maSachList.Contains(s.MaSach))
                .Select(s => s.TenSach)
                .Distinct()
                .ToList();

            return tenSachList;
        }

        public string GetMaPhieuMuonByMaPhieuTra(string maPhieuTra)
        {
            var maPhieuMuon = _context.PhieuTra
                .Where(pt => pt.MaPhieuTra == maPhieuTra)
                .Select(pt => pt.MaPhieuMuon)
                .FirstOrDefault();

            return maPhieuMuon;
        }

        //Sinh mã tự động
        public string GenerateMaPhieuTra()
        {
            var maxMaPhieu = _context.PhieuTra
                            .Where(s => s.MaPhieuTra.StartsWith("T"))
                            .OrderByDescending(s => s.MaPhieuTra)
                            .Select(s => s.MaPhieuTra)
                            .FirstOrDefault();

            if (maxMaPhieu == null)
            {
                return "T0001";
            }

            var numericPart = int.Parse(maxMaPhieu.Substring(1));

            numericPart++;

            return "T" + numericPart.ToString("D4");
        }

        public int GetSttPhieuMuon(string maPhieuMuon, string maSach)
        {
            var sttPhieuMuon = _context.CT_PhieuMuon
                .Where(ct => ct.MaPhieuMuon == maPhieuMuon && ct.MaSach == maSach)
                .Select(ct => ct.sttPhieuMuon)
                .FirstOrDefault();

            if (sttPhieuMuon == 0)
            {
                throw new InvalidOperationException("Không tìm thấy sttPhieuMuon cho MaPhieuMuon và MaSach này.");
            }

            return sttPhieuMuon;
        }

        public string GetMaDocGiaByMaPhieuMuon(string maPhieuMuon)
        {
            var maDocGia = _context.PhieuMuon
                .Where(pm => pm.MaPhieuMuon == maPhieuMuon)
                .Select(pm => pm.MaDocGia)
                .FirstOrDefault();

            if (maDocGia == null)
            {
                throw new InvalidOperationException("Không tìm thấy MaDocGia cho MaPhieuMuon này.");
            }

            return maDocGia;
        }

        public CT_PhieuTra GetCTPhieuTraBySttPhieuMuon(int sttPhieuMuon)
        {
            // Tìm bản ghi trong bảng CT_PhieuTra với sttPhieuMuon tương ứng
            var ctPhieuTra = _context.CT_PhieuTra
                .FirstOrDefault(ct => ct.sttPhieuMuon == sttPhieuMuon);

            return ctPhieuTra;
        }

        public List<ReturnViewModel> SearchReturns(string searchText)
        {
            var allReturns = GetReturn();
            var filteredReturns = allReturns
                .Where(a => a.MaPhieuMuon.Contains(searchText) || a.MaPhieuTra.Contains(searchText)
                || a.HoTenNhanVien.Contains(searchText))
                .Select(a => new ReturnViewModel
                {
                    MaPhieuTra = a.MaPhieuTra,
                    MaPhieuMuon = a.MaPhieuMuon,
                    HoTenNhanVien = a.HoTenNhanVien,
                    NgayLap = a.NgayLap,
                })
                .ToList();
            return filteredReturns;
        }
    }

    public class ReturnViewModel
    {
    public string MaPhieuTra {  get; set; }
    public string MaPhieuMuon { get; set; }
    public DateTime NgayLap { get; set; }
    public string MaNhanVien { get; set; }
    public string HoTenNhanVien { get; set; }
    }
}
