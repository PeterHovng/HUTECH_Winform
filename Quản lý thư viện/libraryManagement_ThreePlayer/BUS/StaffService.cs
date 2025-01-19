using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using static BUS.BooksService;
using static BUS.ReadersService;

namespace BUS
{
    public class StaffService
    {
        private readonly LibraryData _context = new LibraryData();

        public List<StaffViewModel> GetAllStaffs()
        {
            var staff = (from s in _context.NhanVien
                         select new StaffViewModel
                         {
                             MaNhanVien = s.MaNhanVien,
                             HoTenNhanVien = s.HoTenNhanVien,
                             CMND = s.CMND,
                             NgaySinh = s.NgaySinh,
                             GioiTinh = s.GioiTinh,
                             DiaChi = s.DiaChi,
                             MatKhau = s.MatKhau,
                             ChucVu = s.ChucVu,
                             NgayVaoLam = s.NgayVaoLam
                         }).ToList();
            return staff;
        }

        public NhanVien AuthenticateUser(string user, string password)
        {
            return _context.NhanVien.FirstOrDefault(a => a.MaNhanVien == user && a.MatKhau == password);
        }

        public StaffViewModel GetNameAndRole(string user)
        {
            var staffInfo = (from nv in _context.NhanVien
                             where nv.MaNhanVien == user
                             select new StaffViewModel
                             {
                                 MaNhanVien = nv.MaNhanVien,
                                 HoTenNhanVien = nv.HoTenNhanVien,
                                 ChucVu = nv.ChucVu
                             }).FirstOrDefault();

            return staffInfo;
        }

        //Sinh mã tự động
        public string GenerateMaNhanVien()
        {
            // Tìm mã sách lớn nhất hiện tại
            var maxMaNhanVien = _context.NhanVien
                            .Where(s => s.MaNhanVien.StartsWith("NV"))
                            .OrderByDescending(s => s.MaNhanVien)
                            .Select(s => s.MaNhanVien)
                            .FirstOrDefault();

            if (maxMaNhanVien == null)
            {
                return "NV001";
            }

            var numericPart = int.Parse(maxMaNhanVien.Substring(2));
            numericPart++;

            return "NV" + numericPart.ToString("D3");
        }

        // Thêm
        public bool AddStaff(NhanVien newStaff)
        {
            if (_context.NhanVien.Any(r => r.MaNhanVien == newStaff.MaNhanVien))
                return false; // Nếu mã độc giả đã tồn tại, không thêm

            _context.NhanVien.Add(newStaff);
            _context.SaveChanges();
            return true;
        }

        // Chỉnh sửa thông tin
        public bool EditStaff(NhanVien updateStaff)
        {
            var existingStaff = _context.NhanVien.Find(updateStaff.MaNhanVien);
            if (existingStaff == null) return false;

            existingStaff.HoTenNhanVien = updateStaff.HoTenNhanVien;
            existingStaff.CMND = updateStaff.CMND;
            existingStaff.DiaChi = updateStaff.DiaChi;
            existingStaff.GioiTinh = updateStaff.GioiTinh;
            existingStaff.MatKhau = updateStaff.MatKhau;
            existingStaff.ChucVu = updateStaff.ChucVu;
            existingStaff.NgaySinh = updateStaff.NgaySinh;
            existingStaff.NgayVaoLam = updateStaff.NgayVaoLam;

            _context.SaveChanges();
            return true;
        }

        public bool DeleteStaff(string maNhanVien)
        {
            var staff = _context.NhanVien.Find(maNhanVien);
            if (staff == null) return false;

            _context.NhanVien.Remove(staff);
            _context.SaveChanges();
            return true;
        }

        public List<StaffViewModel> SearchStaffs(string searchText)
        {
            var allStaffs = GetAllStaffs();
            var filteredStaffs = allStaffs
                .Where(r => r.MaNhanVien.Contains(searchText)
                || r.HoTenNhanVien.Contains(searchText)
                || r.DiaChi.Contains(searchText)
                || r.GioiTinh.Contains(searchText)
                || r.ChucVu.Contains(searchText))
                .Select(r => new StaffViewModel
                {
                    MaNhanVien = r.MaNhanVien,
                    HoTenNhanVien = r.HoTenNhanVien,
                    GioiTinh = r.GioiTinh,
                    DiaChi = r.DiaChi,
                    ChucVu = r.ChucVu,
                    CMND = r.CMND,
                    NgaySinh = r.NgaySinh,
                    NgayVaoLam = r.NgayVaoLam,
                    MatKhau = r.MatKhau
                })
                .ToList();
            return filteredStaffs;
        }

        public string GetEmployeeId(string username)
        {
            // Giả sử bạn đã có phương thức để lấy thông tin nhân viên
            var staff = _context.NhanVien.FirstOrDefault(n => n.MaNhanVien == username);
            return staff?.MaNhanVien;
        }

        public class StaffViewModel
        {
            public string MaNhanVien { get; set; }
            public string HoTenNhanVien { get; set; }
            public long CMND { get; set; }
            public DateTime NgaySinh { get; set; }
            public string GioiTinh { get; set; }
            public string DiaChi { get; set; }
            public string MatKhau { get; set; }
            public string ChucVu { get; set; }
            public DateTime NgayVaoLam {  get; set; } 
        }
    }
}
