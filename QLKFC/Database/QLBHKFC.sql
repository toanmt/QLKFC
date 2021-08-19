USE Master
GO
IF EXISTS ( SELECT * FROM sys.databases WHERE name = 'QLBHKFC')
			DROP DATABASE QLBHKFC
GO
Create DATABASE QLBHKFC
GO
USE QLBHKFC

GO
CREATE TABLE NguyenLieu
(
MaNL int IDENTITY(1,1) primary key,
TenNL nvarchar(50),
DonGia float
)
GO
CREATE TABLE LoaiSanPham
(
MaLSP int IDENTITY(1,1) primary key,
TenLSP nvarchar(20)
)
GO
CREATE TABLE SanPham
(
MaSP int IDENTITY(1,1) Primary key,
MaLSP int,
TenSP nvarchar(100),
DonVi nvarchar(20),
DonGia float,
Mota nvarchar(200),
HinhAnh nvarchar(150),
CONSTRAINT fk_LSP_SP FOREIGN KEY (MaLSP) REFERENCES LoaiSanPham(MaLSP)
)

GO
CREATE TABLE HoaDonKho
(
MaHDK int IDENTITY(1,1) primary key,
NgayCC datetime,
TrangThai nvarchar(20)
)
GO
CREATE TABLE CTHoaDonKho
(
MaHDK int,
MaNL int,
SoLuong int,
CONSTRAINT fk_hdk_cthdk FOREIGN KEY (MaHDK) REFERENCES HoaDonKho(MaHDK),
CONSTRAINT fk_hdk_nl FOREIGN KEY (MaNL) REFERENCES NguyenLieu(MaNL),
Primary key(MaHDK,MaNL)
)

GO
CREATE TABLE TaiKhoan
(
ID INT IDENTITY(1,1) PRIMARY KEY,
TaiKhoan varchar(20),
MatKhau varchar(20),
Quyen BIT
)
GO
CREATE TABLE ChucVu
(
MaCV int IDENTITY(1,1) primary key,
TenCV nvarchar(20),
ID int,
FOREIGN KEY (ID) REFERENCES TaiKhoan(ID)
)
GO
Create TABLE NhanVien
(
SoCMT char(12) primary key,
MaCV int,
TenNV nvarchar(20),
GioiTinh nvarchar(10),
NgaySinh DateTime,
DiaChi nvarchar(200),
SoDienThoai char(10),
Email varchar(50),
NgayBatDau datetime,
CONSTRAINT fk_CV_NV FOREIGN KEY (MaCV) REFERENCES ChucVu(MaCV)
)
GO
CREATE TABLE HoaDon
(
MaHD int IDENTITY(1,1) primary key,
TenNV nvarchar(20),
StoreID varchar(10),
Pos varchar(10),
NgayThang datetime
)
GO
CREATE TABLE CTHoaDon
(
MaHD int,
MaSP int,
SoLuong int,
PRIMARY KEY(MaHD,MaSP),
CONSTRAINT fk_hd_cthd FOREIGN KEY (MaHD) REFERENCES HoaDon(MaHD),
CONSTRAINT fk_hd_sp FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP)
)

GO
CREATE TABLE Kho
(
MaNL int Primary key,
SoLuong int,
CONSTRAINT fk_K_SP FOREIGN KEY (MaNL) REFERENCES NguyenLieu(MaNL)
)

--------------------------Thêm dữ liệu----------------------------------------
-------------------Nguyên Liệu-----------------------
SET IDENTITY_INSERT [dbo].[NguyenLieu] ON 
INSERT [dbo].[NguyenLieu] ([MaNL], [TenNL], [DonGia]) VALUES (1, N'Bột Mỳ', 10000)
INSERT [dbo].[NguyenLieu] ([MaNL], [TenNL], [DonGia]) VALUES (2, N'Cánh Gà', 60000)
INSERT [dbo].[NguyenLieu] ([MaNL], [TenNL], [DonGia]) VALUES (3 , N'Gạo', 30000)
INSERT [dbo].[NguyenLieu] ([MaNL], [TenNL], [DonGia]) VALUES (4 , N'Chân Gà', 40000)
INSERT [dbo].[NguyenLieu] ([MaNL], [TenNL], [DonGia]) VALUES (5 , N'Lườn gà', 70000)
INSERT [dbo].[NguyenLieu] ([MaNL], [TenNL], [DonGia]) VALUES (6 , N'Dasani', 2500)
INSERT [dbo].[NguyenLieu] ([MaNL], [TenNL], [DonGia]) VALUES (7 , N'Cocacola', 5000)
INSERT [dbo].[NguyenLieu] ([MaNL], [TenNL], [DonGia]) VALUES (8 , N'Ức gà', 56000)
INSERT [dbo].[NguyenLieu] ([MaNL], [TenNL], [DonGia]) VALUES (9 , N'Xà lách', 49000)
INSERT [dbo].[NguyenLieu] ([MaNL], [TenNL], [DonGia]) VALUES (10 , N'Cà chua', 19000)
SET IDENTITY_INSERT [dbo].[NguyenLieu] OFF

-------------------Loại Sản Phẩm-----------------------
SET IDENTITY_INSERT [dbo].[LoaiSanPham] ON 

INSERT [dbo].[LoaiSanPham] ([MaLSP], [TenLSP]) VALUES (1, N'Đồ ăn')
INSERT [dbo].[LoaiSanPham] ([MaLSP], [TenLSP]) VALUES (2, N'Đồ uống')
INSERT [dbo].[LoaiSanPham] ([MaLSP], [TenLSP]) VALUES (3, N'Combo')
SET IDENTITY_INSERT [dbo].[LoaiSanPham] OFF

-------------------Sản Phẩm-----------------------
SET IDENTITY_INSERT [dbo].[SanPham] ON 

INSERT [dbo].[SanPham] ([MaSP], [MaLSP], [TenSP], [DonVi], [DonGia], [Mota], [HinhAnh]) VALUES (1, 1, N'Gà rán(1 Miếng)', N'Miếng', 36000, N'1  Miếng Gà Giòn Cay / 1 Miếng Gà Giòn Không Cay / 1 Miếng Gà Truyền Thống', N'Gà rán.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaLSP], [TenSP], [DonVi], [DonGia], [Mota], [HinhAnh]) VALUES (2, 1, N'Cơm Gà Truyền Thống', N'Phần', 41000, N'Cơm Gà Truyền Thống (1 Phần)', N'Cơm gà truyền thống.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaLSP], [TenSP], [DonVi], [DonGia], [Mota], [HinhAnh]) VALUES (3, 1, N'Cơm Gà Giòn Cay ', N'Phần', 41000, N'Cơm Gà Giòn Cay (1 Phần)', N'Cơm gà giòn cay.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaLSP], [TenSP], [DonVi], [DonGia], [Mota], [HinhAnh]) VALUES (4, 1, N'Popcorn ', N'Vừa', 57000, N'', N'popcorn vừa.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaLSP], [TenSP], [DonVi], [DonGia], [Mota], [HinhAnh]) VALUES (5, 1, N'Popcorn ', N'Lớn', 57000, N'', N'popcorn lớn.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaLSP], [TenSP], [DonVi], [DonGia], [Mota], [HinhAnh]) VALUES (6, 1, N'Khoai Tây Chiên', N'Vừa', 14000, N'', N'khoai tây chiên(vừa).jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaLSP], [TenSP], [DonVi], [DonGia], [Mota], [HinhAnh]) VALUES (7, 1, N'Khoai Tây Chiên', N'Lớn', 27000, N'', N'Khoai tây chiên Lớn.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaLSP], [TenSP], [DonVi], [DonGia], [Mota], [HinhAnh]) VALUES (8, 2, N'Pepsi Lon', N'Lon', 17000, N'', N'pepsi lon.png')
INSERT [dbo].[SanPham] ([MaSP], [MaLSP], [TenSP], [DonVi], [DonGia], [Mota], [HinhAnh]) VALUES (9, 2, N'Mocktail Ổi Hạt Chia', N'Cốc', 29000, N'', N'Mocktail Ổi Hạt Chia.png')
INSERT [dbo].[SanPham] ([MaSP], [MaLSP], [TenSP], [DonVi], [DonGia], [Mota], [HinhAnh]) VALUES (10, 2, N'Trà đào', N'Cốc', 24000, N'', N'trà đào.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaLSP], [TenSP], [DonVi], [DonGia], [Mota], [HinhAnh]) VALUES (11, 3, N'COMBO NHÓM A', N'Combo', 129000, N'2 Miếng Gà Giòn Cay / 2 Miếng Gà Giòn Không Cay / 2 Miếng Gà Truyền thống
1 Burger Tôm
2 Pepsi Lon', N'combo nhóm A.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaLSP], [TenSP], [DonVi], [DonGia], [Mota], [HinhAnh]) VALUES (12, 3, N'COMBO NHÓM B', N'Combo', 149000, N'3 Miếng Gà Giòn Cay / 3 Miếng Gà Giòn Không Cay / 3 Miếng Gà Truyền Thống
1 Khoai Tây Chiên (Lớn)
2 Pepsi Lon', N'combo nhóm B.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaLSP], [TenSP], [DonVi], [DonGia], [Mota], [HinhAnh]) VALUES (13, 3, N'COMBO GIA ĐÌNH A', N'Combo', 359000, N'8 Miếng Gà Giòn Cay / 8 Miếng Gà Giòn Không Cay / 8 Miếng Gà Truyền Thống
2 Khoai Tây Chiên (Lớn)
4 Pepsi Lon', N'combo gia đình A.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaLSP], [TenSP], [DonVi], [DonGia], [Mota], [HinhAnh]) VALUES (14, 3, N'COMBO GÀ RÁN A', N'Combo', 79000, N'2 Miếng Gà Giòn Cay / 2 Miếng Gà Giòn Không Cay
1 Pepsi Lon', N'Combo gà rán A.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaLSP], [TenSP], [DonVi], [DonGia], [Mota], [HinhAnh]) VALUES (15, 3, N'COMBO GÀ RÁN B', N'Combo', 79000, N'1 Phần Hot Wings 3 Miếng
1 Khoai Tây Chiên (Lớn)
1 Pepsi Lon', N'Combo gà rán B.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaLSP], [TenSP], [DonVi], [DonGia], [Mota], [HinhAnh]) VALUES (16, 3, N'COMBO GÀ RÁN C', N'Combo', 85000, N'1 Miếng Gà Giòn Cay / 1 Miếng Gà Giòn Không Cay
1 Burger Tôm
1 Pepsi Lon', N'Combo gà rán C.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaLSP], [TenSP], [DonVi], [DonGia], [Mota], [HinhAnh]) VALUES (17, 3, N'COMBO GÀ RÁN D', N'Combo', 89000, N'1 Miếng Gà Giòn Cay / 1 Miếng Gà Giòn Không Cay
1 Burger Zinger
1 Pepsi Lon', N'Combo gà rán D.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaLSP], [TenSP], [DonVi], [DonGia], [Mota], [HinhAnh]) VALUES (18, 3, N'COMBO CƠM B', N'Combo', 89000, N'1 Cơm Gà Giòn Cay / 1 Cơm Gà Giòn Không Cay / 1 Cơm Gà Truyền Thống / 1 Cơm Phi-lê Gà Giòn / 1 Cơm Gà Xiên Que
1 Miếng Gà Giòn Cay / 1 Miếng Gà Giòn Không Cay
1 Pepsi Lon', N'Combo Cơm B.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaLSP], [TenSP], [DonVi], [DonGia], [Mota], [HinhAnh]) VALUES (19, 3, N'COMBO CƠM C', N'Combo', 95000, N'1 Cơm Gà Giòn Cay / 1 Cơm Gà Giòn Không Cay / 1 Cơm Gà Truyền Thống / 1 Cơm Phi-lê Gà Giòn / 1 Cơm Gà Xiên Que
1 Burger Zinger
1 Pepsi Lon', N'Combo Cơm C.jpg')

SET IDENTITY_INSERT [dbo].[SanPham] OFF

-------------------Tài Khoản-----------------------
SET IDENTITY_INSERT [dbo].[TaiKhoan] ON 

INSERT [dbo].[TaiKhoan] ([ID], [TaiKhoan], [MatKhau], [Quyen]) VALUES (1, N'admin', N'123', 1)
INSERT [dbo].[TaiKhoan] ([ID], [TaiKhoan], [MatKhau], [Quyen]) VALUES (2, N'nhanvien', N'123', 0)
SET IDENTITY_INSERT [dbo].[TaiKhoan] OFF

-------------------Chức Vụ-----------------------
SET IDENTITY_INSERT [dbo].[ChucVu] ON 

INSERT [dbo].[ChucVu] ([MaCV], [TenCV], [ID]) VALUES (1, N'Quản lý',1)
INSERT [dbo].[ChucVu] ([MaCV], [TenCV], [ID]) VALUES (2, N'Bán Hàng',2)
INSERT [dbo].[ChucVu] ([MaCV], [TenCV], [ID]) VALUES (3, N'Phục Vụ',2)
INSERT [dbo].[ChucVu] ([MaCV], [TenCV], [ID]) VALUES (4, N'Đầu Bếp',2)
SET IDENTITY_INSERT [dbo].[ChucVu] OFF


-------------------Nhân Viên-----------------------

INSERT [dbo].[NhanVien] ([SoCMT], [MaCV], [TenNV], [GioiTinh], [NgaySinh], [DiaChi], [SoDienThoai], [Email], [NgayBatDau]) VALUES ('001200012423', 1, N'Đỗ Thắng', N'Nam', CAST(N'2000-05-10 00:00:00.000' AS DateTime), N'Vạn Phúc', N'0398299428', N'ddooxthawsng@gmail.com', CAST(N'2021-07-01 00:00:00.000' AS DateTime))
INSERT [dbo].[NhanVien] ([SoCMT], [MaCV], [TenNV], [GioiTinh], [NgaySinh], [DiaChi], [SoDienThoai], [Email], [NgayBatDau]) VALUES ('001703015435', 1, N'Mai Thế Toàn', N'Nam', CAST(N'2000-06-06 00:00:00.000' AS DateTime), N'Thanh Hóa', N'0932606905', N'maithe.toan2k@gmail.com', CAST(N'2021-07-01 00:00:00.000' AS DateTime))

-------------------Hóa Đơn-----------------------
SET IDENTITY_INSERT [dbo].[HoaDon] ON 
INSERT [dbo].[HoaDon] ([MaHD], [TenNV], [StoreID], [Pos], [NgayThang]) VALUES (1, N'Mai Thế Toàn', N'044', N'1', CAST(N'2021-08-01 00:00:00.000' AS DateTime))
INSERT [dbo].[HoaDon] ([MaHD], [TenNV], [StoreID], [Pos], [NgayThang]) VALUES (2, N'Mai Thế Toàn', N'044', N'2', CAST(N'2021-08-02 00:00:00.000' AS DateTime))
INSERT [dbo].[HoaDon] ([MaHD], [TenNV], [StoreID], [Pos], [NgayThang]) VALUES (3, N'Mai Thế Toàn', N'044', N'1', CAST(N'2021-08-18 15:39:07.703' AS DateTime))
INSERT [dbo].[HoaDon] ([MaHD], [TenNV], [StoreID], [Pos], [NgayThang]) VALUES (4, N'Mai Thế Toàn', N'044', N'1', CAST(N'2021-08-18 15:39:29.353' AS DateTime))
INSERT [dbo].[HoaDon] ([MaHD], [TenNV], [StoreID], [Pos], [NgayThang]) VALUES (5, N'Mai Thế Toàn', N'044', N'1', CAST(N'2021-08-18 15:39:45.940' AS DateTime))
INSERT [dbo].[HoaDon] ([MaHD], [TenNV], [StoreID], [Pos], [NgayThang]) VALUES (6, N'Mai Thế Toàn', N'044', N'1', CAST(N'2021-08-18 15:40:00.680' AS DateTime))
INSERT [dbo].[HoaDon] ([MaHD], [TenNV], [StoreID], [Pos], [NgayThang]) VALUES (7, N'Mai Thế Toàn', N'044', N'1', CAST(N'2021-08-18 15:40:10.737' AS DateTime))
INSERT [dbo].[HoaDon] ([MaHD], [TenNV], [StoreID], [Pos], [NgayThang]) VALUES (8, N'Mai Thế Toàn', N'044', N'1', CAST(N'2021-08-18 15:40:22.490' AS DateTime))
INSERT [dbo].[HoaDon] ([MaHD], [TenNV], [StoreID], [Pos], [NgayThang]) VALUES (9, N'Mai Thế Toàn', N'044', N'1', CAST(N'2021-08-18 15:40:32.987' AS DateTime))
INSERT [dbo].[HoaDon] ([MaHD], [TenNV], [StoreID], [Pos], [NgayThang]) VALUES (10, N'Mai Thế Toàn', N'044', N'1', CAST(N'2021-08-18 15:40:47.020' AS DateTime))
INSERT [dbo].[HoaDon] ([MaHD], [TenNV], [StoreID], [Pos], [NgayThang]) VALUES (11, N'Mai Thế Toàn', N'044', N'1', CAST(N'2021-08-18 15:40:55.450' AS DateTime))
INSERT [dbo].[HoaDon] ([MaHD], [TenNV], [StoreID], [Pos], [NgayThang]) VALUES (12, N'Đỗ Thắng', N'044', N'3', CAST(N'2021-08-18 15:43:30.217' AS DateTime))
INSERT [dbo].[HoaDon] ([MaHD], [TenNV], [StoreID], [Pos], [NgayThang]) VALUES (13, N'Đỗ Thắng', N'044', N'3', CAST(N'2021-08-18 15:43:47.780' AS DateTime))
INSERT [dbo].[HoaDon] ([MaHD], [TenNV], [StoreID], [Pos], [NgayThang]) VALUES (14, N'Đỗ Thắng', N'044', N'3', CAST(N'2021-08-18 15:43:56.133' AS DateTime))
INSERT [dbo].[HoaDon] ([MaHD], [TenNV], [StoreID], [Pos], [NgayThang]) VALUES (15, N'Đỗ Thắng', N'044', N'3', CAST(N'2021-08-18 15:44:05.830' AS DateTime))
INSERT [dbo].[HoaDon] ([MaHD], [TenNV], [StoreID], [Pos], [NgayThang]) VALUES (16, N'Đỗ Thắng', N'044', N'3', CAST(N'2021-08-18 15:44:15.640' AS DateTime))
INSERT [dbo].[HoaDon] ([MaHD], [TenNV], [StoreID], [Pos], [NgayThang]) VALUES (17, N'Đỗ Thắng', N'044', N'3', CAST(N'2021-08-18 15:44:23.883' AS DateTime))
INSERT [dbo].[HoaDon] ([MaHD], [TenNV], [StoreID], [Pos], [NgayThang]) VALUES (18, N'Đỗ Thắng', N'044', N'3', CAST(N'2021-08-18 15:44:32.050' AS DateTime))
INSERT [dbo].[HoaDon] ([MaHD], [TenNV], [StoreID], [Pos], [NgayThang]) VALUES (19, N'Đỗ Thắng', N'044', N'3', CAST(N'2021-08-18 15:44:45.137' AS DateTime))
SET IDENTITY_INSERT [dbo].[HoaDon] OFF

-------------------Hóa Đơn Kho-----------------------
SET IDENTITY_INSERT [dbo].[HoaDonKho] ON 
INSERT [dbo].[HoaDonKho] ([MaHDK], [NgayCC], [TrangThai]) VALUES (1, CAST(N'2021-08-03 00:00:00.000' AS DateTime), N'Đang Xử Lý')
INSERT [dbo].[HoaDonKho] ([MaHDK], [NgayCC], [TrangThai]) VALUES (2, CAST(N'2021-07-31 00:00:00.000' AS DateTime), N'Hoàn Thành')
INSERT [dbo].[HoaDonKho] ([MaHDK], [NgayCC], [TrangThai]) VALUES (3, CAST(N'2021-08-03 00:00:00.000' AS DateTime), N'Đã hủy')
INSERT [dbo].[HoaDonKho] ([MaHDK], [NgayCC], [TrangThai]) VALUES (4, CAST(N'2021-08-18 15:44:54.330' AS DateTime), N'Đang xử lý')
INSERT [dbo].[HoaDonKho] ([MaHDK], [NgayCC], [TrangThai]) VALUES (5, CAST(N'2021-08-18 15:45:11.550' AS DateTime), N'Đã hủy')
INSERT [dbo].[HoaDonKho] ([MaHDK], [NgayCC], [TrangThai]) VALUES (6, CAST(N'2021-08-18 15:45:24.913' AS DateTime), N'Hoàn Thành')
INSERT [dbo].[HoaDonKho] ([MaHDK], [NgayCC], [TrangThai]) VALUES (7, CAST(N'2021-08-18 15:45:34.683' AS DateTime), N'Đang giao hàng')
SET IDENTITY_INSERT [dbo].[HoaDonKho] OFF

-------------------CTHoa Don-----------------------

INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (1, 2, 6)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (1, 3, 4)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (1, 4, 8)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (2, 5, 3)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (2, 6, 4)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (2, 10, 3)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (3, 1, 2)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (4, 13, 2)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (5, 1, 3)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (6, 2, 4)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (7, 3, 8)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (8, 7, 1212)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (9, 8, 2322323)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (10, 15, 32)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (11, 16, 21)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (12, 2, 32)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (13, 2, 2)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (14, 1, 33)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (15, 18, 221)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (16, 19, 2334234)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (17, 17, 12)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (18, 18, 322)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (19, 17, 43)

-------------------CTHoa Đơn Kho-----------------------
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong]) VALUES (1, 3, 4)
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong]) VALUES (2, 1, 10)
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong]) VALUES (2, 2, 6)
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong]) VALUES (2, 5, 8)
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong]) VALUES (4, 4, 23)
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong]) VALUES (4, 10, 2)
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong]) VALUES (5, 2, 6)
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong]) VALUES (5, 7, 6)
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong]) VALUES (6, 8, 4)
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong]) VALUES (7, 1, 2)
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong]) VALUES (7, 6, 23)


-------------------Kho-----------------------
INSERT [dbo].[Kho] ([MaNL], [SoLuong]) VALUES (1, 10)
INSERT [dbo].[Kho] ([MaNL], [SoLuong]) VALUES (2, 40)
INSERT [dbo].[Kho] ([MaNL], [SoLuong]) VALUES (3, 30)
INSERT [dbo].[Kho] ([MaNL], [SoLuong]) VALUES (4, 29)
INSERT [dbo].[Kho] ([MaNL], [SoLuong]) VALUES (5, 12)



