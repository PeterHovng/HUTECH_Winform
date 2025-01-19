create database QLTV
use QLTV
set dateformat dmy

----------------------------------------
CREATE TABLE NhanVien (
  MaNhanVien VARCHAR(5) primary key not null,
  HoTenNhanVien NVARCHAR(225) not null,
  CMND BIGINT not null,
  NgaySinh date not null,
  GioiTinh nvarchar(10) not null,
  DiaChi NVARCHAR(225) not null,
  MatKhau VARCHAR(225) not null,
  ChucVu NVARCHAR(225) not null,
  NgayVaoLam date not null
);

----------------------------------------
create table TacGia
(
	MaTacGia varchar(5) primary key not null,
	HoTenTacGia nvarchar(225) not null,
	GioiTinh nvarchar(10),
	QueQuan nvarchar(225),
);

----------------------------------------
create table DocGia
(
	MaDocGia varchar(5) primary key not null,
	HoTenDocGia nvarchar(225) not null,
	GioiTinh nvarchar(10) not null,
	DiaChi nvarchar(225) not null,
	DienThoai BIGINT,
	CMND BIGINT not null,
	NgaySinh date not null,
	NgayLamThe date not null,
);

----------------------------------------
create table TheLoai
(
	MaTheLoai varchar(5) primary key not null,
	TenTheLoai nvarchar(225) not null
);

----------------------------------------
create table Sach
(
	MaSach varchar(10) primary key not null,
	TenSach nvarchar(225) not null,
	MaTheLoai varchar(5) not null,
	NhaXuatBan nvarchar(225) not null,
	NgayXuatBan date not null,
	MaTacGia varchar(5) not null,
	SoLuong int not null,
	GiaTien float not null,
	foreign key (MaTacGia) references TacGia(MaTacGia),
	foreign key (MaTheLoai) references TheLoai(MaTheLoai)
);

----------------------------------------
create table PhieuMuon(
	MaPhieuMuon VARCHAR(5) primary key not null,
	MaNhanVien VARCHAR(5) not null,
    MaDocGia varchar(5) not null,
    NgayMuon date not null,
    foreign key (MaDocGia) references DocGia(MaDocGia),
	foreign key (MaNhanVien) references NhanVien(MaNhanVien)
);

----------------------------------------
create table PhieuPhat(
    MaPhieuPhat VARCHAR(5) primary key not null,
	MaNhanVien VARCHAR(5) not null,
	MaPhieuMuon VARCHAR(5) not null,
    NgayLap date not null,
	foreign key (MaNhanVien) references NhanVien(MaNhanVien),
	foreign key (MaPhieuMuon) references PhieuMuon(MaPhieuMuon)
);

----------------------------------------
create table PhieuTra(
    MaPhieuTra VARCHAR(5) primary key not null,
	MaPhieuMuon VARCHAR (5) not null,
    NgayLap date not null,
	MaNhanVien VARCHAR(5) not null,
	foreign key (MaNhanVien) references NhanVien(MaNhanVien),
	foreign key (MaPhieuMuon) references PhieuMuon(MaPhieuMuon)
);

----------------------------------------
CREATE TABLE CT_PhieuMuon (
  sttPhieuMuon int identity(1,1) primary key not null,
  MaPhieuMuon VARCHAR(5),
  MaSach VARCHAR(10),
  SoLuong INT NOT NULL,
  NgayTra date not null,
  FOREIGN KEY (MaPhieuMuon) REFERENCES PhieuMuon(MaPhieuMuon),
  FOREIGN KEY (MaSach) REFERENCES Sach(MaSach)
);

----------------------------------------
create table CT_PhieuTra(
    sttPhieuTra int identity(1,1) primary key not null,
	sttPhieuMuon int not null,
    MaPhieuTra VARCHAR(5) not null,
	MaDocGia VARCHAR(5) not null,
	NgayTraSach date not null,
	foreign key (MaPhieuTra) references PhieuTra(MaPhieuTra),
	foreign key (sttPhieuMuon) references CT_PhieuMuon(sttPhieuMuon),
	foreign key (MaDocGia) references DocGia(MaDocGia)
);

----------------------------------------
create table CT_PhieuPhat(
    sttPhieuPhat int identity(1,1) primary key not null,
	MaPhieuPhat VARCHAR(5) not null,
	TongTien float,
    NoiDung NVARCHAR(225) not null,
	foreign key (MaPhieuPhat) references PhieuPhat(MaPhieuPhat)
);

create table LichSu(
	maLichSu int identity(1,1) primary key not null,
	sttPhieuMuon int not null,
	sttPhieuTra int not null,
	MaSach varchar
)

INSERT INTO NhanVien (MaNhanVien, HoTenNhanVien, CMND, NgaySinh, GioiTinh, DiaChi, MatKhau, ChucVu, NgayVaoLam) VALUES
('ADMIN', N'Quản trị viên', '901234214821', '2004-01-01', N'Nam', N'Local', 'admin123', N'Admin', '2024-02-11'),
('NV001', N'Nguyễn Văn A', '123456789001', '1990-05-15', N'Nam', N'TP. Hà Nội', 'mk1', N'Thủ thư', '2022-01-01'),
('NV002', N'Trần Thị B', '123456789002', '1992-06-20', N'Nữ', N'TP. Hồ Chí Minh', 'mk2', N'Thủ thư', '2022-01-02'),
('NV003', N'Hoàng Văn C', '123456789003', '1988-07-22', N'Nam', N'TP. Đà Nẵng', 'mk3', N'Thủ thư', '2022-01-03'),
('NV004', N'Phạm Thị D', '123456789004', '1995-08-18', N'Nữ', N'TP. Hải Phòng', 'mk4', N'Thủ thư', '2022-01-04'),
('NV005', N'Lê Văn E', '123456789005', '1985-09-10', N'Nam', N'TP. Cần Thơ', 'mk5', N'Thủ thư', '2022-01-05'),
('NV006', N'Bùi Thị F', '123456789006', '1991-10-30', N'Nữ', N'TP. Quảng Ninh', 'mk6', N'Thủ thư', '2022-01-06'),
('NV007', N'Đinh Văn G', '123456789007', '1983-11-05', N'Nam', N'TP. Nghệ An', 'mk7', N'Thủ thư', '2022-01-07'),
('NV008', N'Phan Thị H', '123456789008', '1994-12-12', N'Nữ', N'TP. Thanh Hóa', 'mk8', N'Thủ thư', '2022-01-08'),
('NV009', N'Vũ Văn I', '123456789009', '1987-01-15', N'Nam', N'TP. Thái Nguyên', 'mk9', N'Thủ thư', '2022-01-09'),
('NV010', N'Ngô Thị J', '123456789010', '1989-02-19', N'Nữ', N'TP. Bình Dương', 'mk10', N'Thủ thư', '2022-01-10'),
('NV011', N'Tạ Văn K', '123456789011', '1986-03-20', N'Nam', N'TP. Đồng Nai', 'mk11', N'Thủ thư', '2022-01-11'),
('NV012', N'Dương Thị L', '123456789012', '1993-04-25', N'Nữ', N'TP. Tiền Giang', 'mk12', N'Thủ thư', '2022-01-12'),
('NV013', N'Tôn Văn M', '123456789013', '1990-05-30', N'Nam', N'TP. Vĩnh Long', 'mk13', N'Thủ thư', '2022-01-13'),
('NV014', N'Võ Thị N', '123456789014', '1991-06-10', N'Nữ', N'TP. Long An', 'mk14', N'Thủ thư', '2022-01-14'),
('NV015', N'Nguyễn Văn O', '123456789015', '1988-07-15', N'Nam', N'TP. Hậu Giang', 'mk15', N'Thủ thư', '2022-01-15'),
('NV016', N'Đoàn Thị P', '123456789016', '1987-08-20', N'Nữ', N'TP. Kiên Giang', 'mk16', N'Thủ thư', '2022-01-16'),
('NV017', N'Nguyễn Văn Q', '123456789017', '1986-09-25', N'Nam', N'TP. An Giang', 'mk17', N'Thủ thư', '2022-01-17'),
('NV018', N'Phạm Thị R', '123456789018', '1985-10-30', N'Nữ', N'TP. Bà Rịa - Vũng Tàu', 'mk18', N'Thủ thư', '2022-01-18'),
('NV019', N'Bùi Văn S', '123456789019', '1983-11-10', N'Nam', N'TP. Sóc Trăng', 'mk19', N'Thủ thư', '2022-01-19');

insert into DocGia (MaDocGia, HoTenDocGia, GioiTinh, DiaChi, DienThoai, CMND, NgaySinh, NgayLamThe) values
('DG001', N'Nguyễn Văn A', N'Nam', N'Tp. Bến Tre', '0365558391', '23456789', '2004-08-18', '2024-04-07'),
('DG002', N'Lê Thị A', N'Nữ', N'Tp. Cần Thơ', '0337841928', '34567890', '2004-07-22', '2024-08-12'),
('DG003', N'Trần Thị B', N'Nữ', N'Tp. Hà Nội', '0371234567', '23456789', '2005-03-15', '2024-06-01'),
('DG004', N'Phạm Văn C', N'Nam', N'Tp. Đà Nẵng', '0387654321', '34567890', '2006-04-25', '2024-06-15'),
('DG005', N'Hoàng Minh D', N'Nam', N'Tp. Cần Thơ', '0398765432', '45678901', '2003-07-30', '2024-07-10'),
('DG006', N'Ngô Thị E', N'Nữ', N'Tp. Hải Phòng', '0321122334', '56789012', '2004-08-18', '2024-07-20'),
('DG007', N'Vũ Văn F', N'Nam', N'Tp. Hồ Chí Minh', '0335678901', '67890123', '2004-09-12', '2024-08-01'),
('DG008', N'Lý Thị G', N'Nữ', N'Tp. Đà Lạt', '0346789012', '78901234', '2005-10-24', '2024-08-05'),
('DG009', N'Hồ Minh H', N'Nam', N'Tp. Huế', '0357890123', '89012345', '2006-11-19', '2024-08-10'),
('DG010', N'Trương Văn I', N'Nam', N'Tp. Vũng Tàu', '0368901234', '90123456', '2005-12-31', '2024-08-15'),
('DG011', N'Nguyễn Thị J', N'Nữ', N'Tp. Hải Dương', '0379012345', '01234567', '2004-01-27', '2024-08-20'),
('DG012', N'Tôn Nữ K', N'Nữ', N'Tp. Quy Nhơn', '0380123456', '12345678', '2005-02-18', '2024-08-25'),
('DG013', N'Chế Minh L', N'Nam', N'Tp. Mỹ Tho', '0391234567', '23456789', '2006-03-15', '2024-08-30'),
('DG014', N'Đào Thị M', N'Nữ', N'Tp. Buôn Ma Thuột', '0322345678', '34567890', '2005-04-21', '2024-09-05'),
('DG015', N'Phùng Văn N', N'Nam', N'Tp. Ninh Bình', '0333456789', '45678901', '2004-05-28', '2024-09-10'),
('DG016', N'Tô Thị O', N'Nữ', N'Tp. Thái Nguyên', '0344567890', '56789012', '2005-06-13', '2024-09-15'),
('DG017', N'Tống Minh P', N'Nam', N'Tp. Thanh Hóa', '0355678901', '67890123', '2006-07-29', '2024-09-20'),
('DG018', N'La Thị Q', N'Nữ', N'Tp. Long Xuyên', '0366789012', '78901234', '2004-08-11', '2024-09-25'),
('DG019', N'Dương Văn R', N'Nam', N'Tp. Biên Hòa', '0377890123', '89012345', '2005-09-02', '2024-09-30'),
('DG020', N'Võ Thị S', N'Nữ', N'Tp. Cà Mau', '0388901234', '90123456', '2006-10-14', '2024-10-05');

insert into TacGia (MaTacGia, HoTenTacGia, GioiTinh, QueQuan) values
('TG001', N'Nguyễn Văn A', N'Nam', N'Tp. Bến Tre'),
('TG002', N'Lê Thị B', N'Nữ', N'Tp. Hồ Chí Minh'),
('TG003', N'Trần Hữu B', N'Nam', N'Tp. Đà Nẵng'),
('TG004', N'Phạm Thị C', N'Nữ', N'Tp. Hà Nội'),
('TG005', N'Ngô Văn D', N'Nam', N'Tp. Cần Thơ'),
('TG006', N'Lê Minh E', N'Nam', N'Tp. Quảng Ninh'),
('TG007', N'Vũ Thị F', N'Nữ', N'Tp. Bắc Giang'),
('TG008', N'Trịnh Văn G', N'Nam', N'Tp. Biên Hòa'),
('TG009', N'Đinh Thị H', N'Nữ', N'Tp. Đồng Nai'),
('TG010', N'Nguyễn Minh I', N'Nam', N'Tp. Bình Dương'),
('TG011', N'Trương Thị J', N'Nữ', N'Tp. Tây Ninh'),
('TG012', N'Đỗ Văn K', N'Nam', N'Tp. Long An');

INSERT INTO TheLoai (MaTheLoai, TenTheLoai) VALUES
('TL001', N'Tiểu thuyết'),
('TL002', N'Trinh thám'),
('TL003', N'Khoa học viễn tưởng'),
('TL004', N'Lịch sử'),
('TL005', N'Tâm lý học'),
('TL006', N'Kinh tế học'),
('TL007', N'Văn học dân gian'),
('TL008', N'Y học'),
('TL009', N'Kỹ năng sống'),
('TL010', N'Ngoại ngữ');

INSERT INTO Sach (MaSach, TenSach, MaTheLoai, NhaXuatBan, NgayXuatBan, MaTacGia, SoLuong, GiaTien) VALUES
('S0001', N'Truyện Kiều', 'TL001', N'NXB Kim Đồng', '2020-03-12', 'TG001', 10, 120000),
('S0002', N'Bí ẩn Kim Tự Tháp', 'TL002', N'NXB Trẻ', '2021-07-19', 'TG002', 15, 180000),
('S0003', N'Hành trình vào không gian', 'TL003', N'NXB Thanh Niên', '2019-09-15', 'TG003', 12, 150000),
('S0004', N'Lịch sử Việt Nam', 'TL004', N'NXB Giáo Dục', '2018-02-20', 'TG004', 10, 95000),
('S0005', N'Thấu hiểu tâm lý', 'TL005', N'NXB Tri Thức', '2022-04-10', 'TG005', 7, 115000),
('S0006', N'Kinh tế học vĩ mô', 'TL006', N'NXB Lao Động', '2021-08-30', 'TG006', 20, 135000),
('S0007', N'Câu chuyện dân gian', 'TL007', N'NXB Kim Đồng', '2017-11-11', 'TG007', 25, 75000),
('S0008', N'Y học cổ truyền', 'TL008', N'NXB Y Học', '2020-12-01', 'TG008', 8, 155000),
('S0009', N'Rèn luyện kỹ năng mềm', 'TL009', N'NXB Trẻ', '2019-10-17', 'TG009', 18, 95000),
('S0010', N'Tiếng Anh giao tiếp', 'TL010', N'NXB Ngoại Ngữ', '2022-05-14', 'TG010', 30, 105000),
('S0011', N'Nghệ thuật thuyết phục', 'TL005', N'NXB Tri Thức', '2021-07-03', 'TG011', 10, 120000),
('S0012', N'Chiến tranh thế giới', 'TL004', N'NXB Giáo Dục', '2016-03-22', 'TG012', 12, 200000),
('S0013', N'Tìm hiểu khoa học', 'TL003', N'NXB Thanh Niên', '2019-09-30', 'TG001', 7, 130000),
('S0014', N'Tư duy phản biện', 'TL006', N'NXB Lao Động', '2020-02-15', 'TG002', 10, 160000),
('S0015', N'Văn học lãng mạn', 'TL001', N'NXB Kim Đồng', '2021-01-05', 'TG003', 10, 95000),
('S0016', N'Khám phá thế giới động vật', 'TL002', N'NXB Trẻ', '2022-08-19', 'TG004', 12, 175000),
('S0017', N'Giải mã giấc mơ', 'TL005', N'NXB Tri Thức', '2017-04-25', 'TG005', 15, 125000),
('S0018', N'Triết học phương Đông', 'TL006', N'NXB Lao Động', '2022-09-12', 'TG006', 10, 145000),
('S0019', N'Truyện cười dân gian', 'TL007', N'NXB Kim Đồng', '2020-07-22', 'TG007', 20, 85000),
('S0020', N'Học tiếng Nhật cho người mới', 'TL010', N'NXB Ngoại Ngữ', '2021-06-14', 'TG008', 10, 125000),
('S0021', N'Công nghệ thông tin', 'TL006', N'NXB Trẻ', '2019-03-14', 'TG001', 20, 120000),
('S0022', N'Toán học phổ thông', 'TL004', N'NXB Giáo Dục', '2020-06-10', 'TG002', 15, 98000),
('S0023', N'Vật lý hiện đại', 'TL003', N'NXB Thanh Niên', '2021-09-25', 'TG003', 10, 145000),
('S0024', N'Lịch sử thế giới', 'TL004', N'NXB Kim Đồng', '2018-05-18', 'TG004', 18, 160000),
('S0025', N'Trinh thám cổ điển', 'TL002', N'NXB Trẻ', '2022-07-12', 'TG005', 12, 95000),
('S0026', N'Văn học Nhật Bản', 'TL001', N'NXB Văn Hóa', '2019-01-15', 'TG006', 25, 110000),
('S0027', N'Phát triển bản thân', 'TL009', N'NXB Trẻ', '2021-08-21', 'TG007', 10, 130000),
('S0028', N'Kinh tế học căn bản', 'TL006', N'NXB Lao Động', '2020-04-18', 'TG008', 22, 120000),
('S0029', N'Những bí ẩn chưa có lời giải', 'TL002', N'NXB Kim Đồng', '2019-10-30', 'TG009', 15, 180000),
('S0030', N'Tiếng Anh cho trẻ em', 'TL010', N'NXB Ngoại Ngữ', '2021-11-19', 'TG010', 30, 85000),
('S0031', N'Thế giới động vật', 'TL003', N'NXB Khoa Học', '2020-07-11', 'TG011', 18, 125000),
('S0032', N'Triết học phương Tây', 'TL006', N'NXB Tri Thức', '2018-02-26', 'TG012', 20, 150000),
('S0033', N'Tư duy sáng tạo', 'TL009', N'NXB Trẻ', '2022-01-01', 'TG001', 17, 90000),
('S0034', N'Thế giới thực vật', 'TL003', N'NXB Khoa Học', '2019-05-23', 'TG002', 10, 155000),
('S0035', N'Thần thoại Hy Lạp', 'TL001', N'NXB Văn Học', '2021-12-14', 'TG003', 12, 110000),
('S0036', N'Tâm lý học nhân cách', 'TL005', N'NXB Tri Thức', '2020-11-18', 'TG004', 8, 135000),
('S0037', N'Làm việc nhóm hiệu quả', 'TL009', N'NXB Trẻ', '2018-06-16', 'TG005', 15, 95000),
('S0038', N'Ngữ pháp tiếng Anh', 'TL010', N'NXB Ngoại Ngữ', '2019-08-29', 'TG006', 22, 75000),
('S0039', N'Những câu chuyện ý nghĩa', 'TL007', N'NXB Kim Đồng', '2021-03-03', 'TG007', 25, 105000),
('S0040', N'Y học thực hành', 'TL008', N'NXB Y Học', '2022-04-27', 'TG008', 10, 140000),
('S0041', N'Khoa học môi trường', 'TL003', N'NXB Khoa Học', '2019-09-09', 'TG009', 14, 170000),
('S0042', N'Kinh tế học vi mô', 'TL006', N'NXB Lao Động', '2020-12-01', 'TG010', 18, 115000),
('S0043', N'Sự tích các loài hoa', 'TL007', N'NXB Kim Đồng', '2018-03-14', 'TG011', 30, 95000),
('S0044', N'Kỹ năng quản lý thời gian', 'TL009', N'NXB Trẻ', '2021-07-20', 'TG012', 20, 120000),
('S0045', N'Thế giới khủng long', 'TL003', N'NXB Khoa Học', '2022-08-05', 'TG001', 12, 135000),
('S0046', N'Tâm lý học phát triển', 'TL005', N'NXB Tri Thức', '2019-04-24', 'TG002', 9, 125000),
('S0047', N'Nghệ thuật giao tiếp', 'TL009', N'NXB Trẻ', '2020-11-09', 'TG003', 10, 95000),
('S0048', N'Giới thiệu về thiền', 'TL005', N'NXB Tri Thức', '2022-02-17', 'TG004', 15, 150000),
('S0049', N'Phương pháp học ngoại ngữ', 'TL010', N'NXB Ngoại Ngữ', '2018-09-13', 'TG005', 18, 100000),
('S0050', N'Truyện cổ tích Việt Nam', 'TL007', N'NXB Kim Đồng', '2020-05-12', 'TG006', 22, 85000),
('S0051', N'Sức khỏe và đời sống', 'TL008', N'NXB Y Học', '2021-06-28', 'TG007', 14, 145000),
('S0052', N'Văn học dân gian Trung Quốc', 'TL001', N'NXB Văn Học', '2019-07-20', 'TG008', 16, 95000),
('S0053', N'Triết học cổ điển', 'TL006', N'NXB Tri Thức', '2020-10-05', 'TG009', 15, 135000),
('S0054', N'Kỹ năng thuyết trình', 'TL009', N'NXB Trẻ', '2018-11-11', 'TG010', 20, 90000),
('S0055', N'Y học dự phòng', 'TL008', N'NXB Y Học', '2021-03-15', 'TG011', 10, 145000),
('S0056', N'Những câu chuyện trinh thám', 'TL002', N'NXB Trẻ', '2019-12-07', 'TG012', 12, 125000),
('S0057', N'Sách hướng dẫn kỹ thuật', 'TL006', N'NXB Lao Động', '2020-06-22', 'TG001', 15, 135000),
('S0058', N'Phát triển tư duy logic', 'TL009', N'NXB Trẻ', '2022-01-30', 'TG002', 17, 95000),
('S0059', N'Tiếng Pháp cho người Việt', 'TL010', N'NXB Ngoại Ngữ', '2021-08-10', 'TG003', 30, 115000),
('S0060', N'Những câu chuyện vui nhộn', 'TL007', N'NXB Kim Đồng', '2020-04-16', 'TG004', 24, 75000);

Select * from NhanVien
Select * from TacGia
Select * from DocGia
Select * from Sach
Select * from TheLoai
Select * from CT_PhieuMuon
Select * from PhieuMuon
Select * from PhieuTra
Select * from CT_PhieuTra