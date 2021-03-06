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
SoLuongDaNhap int,
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
Quyen int
)
GO
CREATE TABLE ChucVu
(
MaCV int IDENTITY(1,1) primary key,
TenCV nvarchar(20),
)
GO
Create TABLE NhanVien
(
SoCMT char(12) primary key,
MaCV int,
ID int,
TenNV nvarchar(20),
GioiTinh nvarchar(10),
NgaySinh DateTime,
DiaChi nvarchar(200),
SoDienThoai char(10),
Email varchar(50),
NgayBatDau datetime,
HinhAnh nvarchar(150),
FOREIGN KEY (ID) REFERENCES TaiKhoan(ID),
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
GO
CREATE TABLE BaoCao
(
MaBC int IDENTITY(1,1)Primary key,
TenNV nvarchar(20),
NgayLap DateTime,
Loai nvarchar(50),
StoreID nvarchar(20),
Mota nvarchar(1000)
)
GO
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

INSERT [dbo].[TaiKhoan] ([ID], [TaiKhoan], [MatKhau], [Quyen]) VALUES (1, N'thang', N'123456', 1)
INSERT [dbo].[TaiKhoan] ([ID], [TaiKhoan], [MatKhau], [Quyen]) VALUES (2, N'toan', N'123456', 2)
INSERT [dbo].[TaiKhoan] ([ID], [TaiKhoan], [MatKhau], [Quyen]) VALUES (3, N'manh', N'123456', 3)
SET IDENTITY_INSERT [dbo].[TaiKhoan] OFF

-------------------Chức Vụ-----------------------
SET IDENTITY_INSERT [dbo].[ChucVu] ON 

INSERT [dbo].[ChucVu] ([MaCV], [TenCV]) VALUES (1, N'Quản lý')
INSERT [dbo].[ChucVu] ([MaCV], [TenCV]) VALUES (2, N'Bán Hàng')
INSERT [dbo].[ChucVu] ([MaCV], [TenCV]) VALUES (3, N'Phục Vụ')
INSERT [dbo].[ChucVu] ([MaCV], [TenCV]) VALUES (4, N'Đầu Bếp')
SET IDENTITY_INSERT [dbo].[ChucVu] OFF


-------------------Nhân Viên-----------------------

INSERT [dbo].[NhanVien] ([SoCMT], [MaCV], [ID], [TenNV], [GioiTinh], [NgaySinh], [DiaChi], [SoDienThoai], [Email], [NgayBatDau],[HinhAnh]) VALUES ('001200012423', 1,1, N'Đỗ Thắng', N'Nam', CAST(N'2000-05-10 00:00:00.000' AS DateTime), N'Vạn Phúc', N'0398299428', N'ddooxthawsng@gmail.com', CAST(N'2021-07-01 00:00:00.000' AS DateTime), N'thang.jpg')
INSERT [dbo].[NhanVien] ([SoCMT], [MaCV], [ID], [TenNV], [GioiTinh], [NgaySinh], [DiaChi], [SoDienThoai], [Email], [NgayBatDau],[HinhAnh]) VALUES ('001703015435', 2,2, N'Mai Thế Toàn', N'Nam', CAST(N'2000-06-06 00:00:00.000' AS DateTime), N'Thanh Hóa', N'0932606905', N'maithe.toan2k@gmail.com', CAST(N'2021-07-01 00:00:00.000' AS DateTime),N'toan.jpg')
INSERT [dbo].[NhanVien] ([SoCMT], [MaCV], [ID], [TenNV], [GioiTinh], [NgaySinh], [DiaChi], [SoDienThoai], [Email], [NgayBatDau],[HinhAnh]) VALUES ('001200012345', 4,3, N'Kim Anh Mạnh', N'Nam', CAST(N'2000-01-01 00:00:00.000' AS DateTime), N'Hà Nội', N'0123456789', N'Manh@gmail.com', CAST(N'2021-07-01 00:00:00.000' AS DateTime),N'amdz.jpg')

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
INSERT [dbo].[HoaDon] ([MaHD], [TenNV], [StoreID], [Pos], [NgayThang]) VALUES (20, N'Đỗ Thắng', N'044', N'1', CAST(N'2021-08-25 15:43:34.307' AS DateTime))
INSERT [dbo].[HoaDon] ([MaHD], [TenNV], [StoreID], [Pos], [NgayThang]) VALUES (21, N'Đỗ Thắng', N'044', N'1', CAST(N'2021-08-25 15:43:40.783' AS DateTime))
INSERT [dbo].[HoaDon] ([MaHD], [TenNV], [StoreID], [Pos], [NgayThang]) VALUES (22, N'Đỗ Thắng', N'044', N'1', CAST(N'2021-08-25 15:43:58.343' AS DateTime))
INSERT [dbo].[HoaDon] ([MaHD], [TenNV], [StoreID], [Pos], [NgayThang]) VALUES (23, N'Đỗ Thắng', N'044', N'1', CAST(N'2021-08-25 15:44:04.767' AS DateTime))
INSERT [dbo].[HoaDon] ([MaHD], [TenNV], [StoreID], [Pos], [NgayThang]) VALUES (24, N'Đỗ Thắng', N'044', N'1', CAST(N'2021-08-25 15:44:14.303' AS DateTime))
INSERT [dbo].[HoaDon] ([MaHD], [TenNV], [StoreID], [Pos], [NgayThang]) VALUES (25, N'Đỗ Thắng', N'044', N'1', CAST(N'2021-08-25 15:44:27.680' AS DateTime))
INSERT [dbo].[HoaDon] ([MaHD], [TenNV], [StoreID], [Pos], [NgayThang]) VALUES (26, N'Đỗ Thắng', N'044', N'1', CAST(N'2021-08-25 15:44:37.320' AS DateTime))
INSERT [dbo].[HoaDon] ([MaHD], [TenNV], [StoreID], [Pos], [NgayThang]) VALUES (27, N'Đỗ Thắng', N'044', N'1', CAST(N'2021-08-25 15:44:46.633' AS DateTime))
INSERT [dbo].[HoaDon] ([MaHD], [TenNV], [StoreID], [Pos], [NgayThang]) VALUES (28, N'Đỗ Thắng', N'044', N'1', CAST(N'2021-08-25 15:44:53.857' AS DateTime))
INSERT [dbo].[HoaDon] ([MaHD], [TenNV], [StoreID], [Pos], [NgayThang]) VALUES (29, N'Đỗ Thắng', N'044', N'1', CAST(N'2021-08-25 15:45:03.120' AS DateTime))
INSERT [dbo].[HoaDon] ([MaHD], [TenNV], [StoreID], [Pos], [NgayThang]) VALUES (30, N'Đỗ Thắng', N'044', N'1', CAST(N'2021-08-25 15:45:19.460' AS DateTime))
INSERT [dbo].[HoaDon] ([MaHD], [TenNV], [StoreID], [Pos], [NgayThang]) VALUES (31, N'Đỗ Thắng', N'044', N'1', CAST(N'2021-08-25 15:45:31.120' AS DateTime))
INSERT [dbo].[HoaDon] ([MaHD], [TenNV], [StoreID], [Pos], [NgayThang]) VALUES (32, N'Đỗ Thắng', N'044', N'1', CAST(N'2021-08-25 15:45:35.880' AS DateTime))
INSERT [dbo].[HoaDon] ([MaHD], [TenNV], [StoreID], [Pos], [NgayThang]) VALUES (33, N'Đỗ Thắng', N'044', N'1', CAST(N'2021-08-25 15:45:43.967' AS DateTime))
INSERT [dbo].[HoaDon] ([MaHD], [TenNV], [StoreID], [Pos], [NgayThang]) VALUES (34, N'Đỗ Thắng', N'044', N'1', CAST(N'2021-08-25 15:45:49.367' AS DateTime))
INSERT [dbo].[HoaDon] ([MaHD], [TenNV], [StoreID], [Pos], [NgayThang]) VALUES (35, N'Đỗ Thắng', N'044', N'1', CAST(N'2021-08-25 15:45:55.567' AS DateTime))
INSERT [dbo].[HoaDon] ([MaHD], [TenNV], [StoreID], [Pos], [NgayThang]) VALUES (36, N'Đỗ Thắng', N'044', N'1', CAST(N'2021-08-25 15:46:02.383' AS DateTime))
INSERT [dbo].[HoaDon] ([MaHD], [TenNV], [StoreID], [Pos], [NgayThang]) VALUES (37, N'Đỗ Thắng', N'044', N'1', CAST(N'2021-08-25 15:46:07.950' AS DateTime))
INSERT [dbo].[HoaDon] ([MaHD], [TenNV], [StoreID], [Pos], [NgayThang]) VALUES (38, N'Đỗ Thắng', N'044', N'1', CAST(N'2021-08-26 21:12:24.817' AS DateTime))
INSERT [dbo].[HoaDon] ([MaHD], [TenNV], [StoreID], [Pos], [NgayThang]) VALUES (39, N'Đỗ Thắng', N'044', N'2', CAST(N'2021-08-28 23:14:08.070' AS DateTime))
INSERT [dbo].[HoaDon] ([MaHD], [TenNV], [StoreID], [Pos], [NgayThang]) VALUES (40, N'Đỗ Thắng', N'044', N'2', CAST(N'2021-08-28 23:14:14.443' AS DateTime))
INSERT [dbo].[HoaDon] ([MaHD], [TenNV], [StoreID], [Pos], [NgayThang]) VALUES (41, N'Đỗ Thắng', N'044', N'2', CAST(N'2021-08-28 23:14:20.030' AS DateTime))
INSERT [dbo].[HoaDon] ([MaHD], [TenNV], [StoreID], [Pos], [NgayThang]) VALUES (42, N'Đỗ Thắng', N'044', N'2', CAST(N'2021-08-28 23:14:27.847' AS DateTime))
SET IDENTITY_INSERT [dbo].[HoaDon] OFF

-------------------Hóa Đơn Kho-----------------------
SET IDENTITY_INSERT [dbo].[HoaDonKho] ON 
INSERT [dbo].[HoaDonKho] ([MaHDK], [NgayCC], [TrangThai]) VALUES (1, CAST(N'2021-08-03 00:00:00.000' AS DateTime), N'Hoàn Thành')
INSERT [dbo].[HoaDonKho] ([MaHDK], [NgayCC], [TrangThai]) VALUES (2, CAST(N'2021-07-31 00:00:00.000' AS DateTime), N'Hoàn Thành')
INSERT [dbo].[HoaDonKho] ([MaHDK], [NgayCC], [TrangThai]) VALUES (3, CAST(N'2021-08-03 00:00:00.000' AS DateTime), N'Đã hủy')
INSERT [dbo].[HoaDonKho] ([MaHDK], [NgayCC], [TrangThai]) VALUES (4, CAST(N'2021-08-18 15:44:54.330' AS DateTime), N'Đang giao hàng')
INSERT [dbo].[HoaDonKho] ([MaHDK], [NgayCC], [TrangThai]) VALUES (5, CAST(N'2021-08-18 15:45:11.550' AS DateTime), N'Đã hủy')
INSERT [dbo].[HoaDonKho] ([MaHDK], [NgayCC], [TrangThai]) VALUES (6, CAST(N'2021-08-18 15:45:24.913' AS DateTime), N'Hoàn Thành')
INSERT [dbo].[HoaDonKho] ([MaHDK], [NgayCC], [TrangThai]) VALUES (7, CAST(N'2021-08-18 15:45:34.683' AS DateTime), N'Đang giao hàng')
INSERT [dbo].[HoaDonKho] ([MaHDK], [NgayCC], [TrangThai]) VALUES (8, CAST(N'2021-08-25 15:46:27.613' AS DateTime), N'Hoàn Thành')
INSERT [dbo].[HoaDonKho] ([MaHDK], [NgayCC], [TrangThai]) VALUES (9, CAST(N'2021-08-25 15:50:39.407' AS DateTime), N'Đang giao hàng')
INSERT [dbo].[HoaDonKho] ([MaHDK], [NgayCC], [TrangThai]) VALUES (10, CAST(N'2021-08-28 23:19:58.647' AS DateTime), N'Đang xử lý')
INSERT [dbo].[HoaDonKho] ([MaHDK], [NgayCC], [TrangThai]) VALUES (11, CAST(N'2021-08-28 23:20:05.957' AS DateTime), N'Đang xử lý')
INSERT [dbo].[HoaDonKho] ([MaHDK], [NgayCC], [TrangThai]) VALUES (12, CAST(N'2021-08-28 23:20:14.507' AS DateTime), N'Đang xử lý')
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
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (20, 1, 1)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (20, 2, 1)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (21, 3, 2)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (22, 4, 5)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (22, 7, 2)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (22, 9, 2)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (23, 12, 2)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (24, 11, 2)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (24, 12, 1)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (24, 13, 2)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (24, 14, 4)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (25, 17, 2)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (25, 18, 3)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (26, 16, 2)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (26, 18, 4)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (26, 19, 4)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (27, 9, 3)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (28, 5, 2)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (29, 2, 3)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (29, 3, 3)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (29, 8, 3)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (30, 3, 323)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (31, 7, 10)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (32, 6, 1)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (33, 6, 1)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (34, 7, 1)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (35, 7, 1)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (36, 8, 2)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (37, 10, 32)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (38, 3, 2)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (39, 2, 2)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (40, 4, 3)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (41, 5, 3)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (42, 1, 222)

-------------------CTHoa Đơn Kho-----------------------
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong], [SoLuongDaNhap]) VALUES (1, 3, 4, 4)
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong], [SoLuongDaNhap]) VALUES (2, 1, 10, 4)
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong], [SoLuongDaNhap]) VALUES (2, 2, 6, 5)
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong], [SoLuongDaNhap]) VALUES (2, 5, 8, 4)
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong], [SoLuongDaNhap]) VALUES (3, 4, 23, 0)
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong], [SoLuongDaNhap]) VALUES (3, 10, 2, 0)
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong], [SoLuongDaNhap]) VALUES (4, 4, 23, 23)
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong], [SoLuongDaNhap]) VALUES (4, 10, 2, 2)
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong], [SoLuongDaNhap]) VALUES (5, 2, 6, 0)
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong], [SoLuongDaNhap]) VALUES (5, 7, 6, 0)
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong], [SoLuongDaNhap]) VALUES (6, 8, 4, 2)
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong], [SoLuongDaNhap]) VALUES (7, 1, 2, 1)
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong], [SoLuongDaNhap]) VALUES (7, 6, 23, 20)
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong], [SoLuongDaNhap]) VALUES (8, 1, 12, 8)
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong], [SoLuongDaNhap]) VALUES (8, 2, 12, 5)
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong], [SoLuongDaNhap]) VALUES (8, 3, 12, 2)
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong], [SoLuongDaNhap]) VALUES (8, 4, 24, 3)
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong], [SoLuongDaNhap]) VALUES (8, 5, 12, 6)
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong], [SoLuongDaNhap]) VALUES (8, 6, 12, 2)
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong], [SoLuongDaNhap]) VALUES (8, 7, 12, 2)
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong], [SoLuongDaNhap]) VALUES (8, 8, 12, 2)
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong], [SoLuongDaNhap]) VALUES (8, 9, 12, 3)
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong], [SoLuongDaNhap]) VALUES (8, 10, 24, 24)
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong], [SoLuongDaNhap]) VALUES (9, 2, 22, 0)
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong], [SoLuongDaNhap]) VALUES (9, 3, 2, 0)
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong], [SoLuongDaNhap]) VALUES (9, 7, 12, 0)
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong], [SoLuongDaNhap]) VALUES (9, 9, 11, 0)
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong], [SoLuongDaNhap]) VALUES (9, 10, 466, 0)
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong], [SoLuongDaNhap]) VALUES (10, 2, 22, 0)
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong], [SoLuongDaNhap]) VALUES (11, 4, 2, 0)
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong], [SoLuongDaNhap]) VALUES (11, 5, 2, 0)
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong], [SoLuongDaNhap]) VALUES (11, 8, 2, 0)
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong], [SoLuongDaNhap]) VALUES (12, 6, 2, 0)
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong], [SoLuongDaNhap]) VALUES (12, 8, 4, 0)
INSERT [dbo].[CTHoaDonKho] ([MaHDK], [MaNL], [SoLuong], [SoLuongDaNhap]) VALUES (12, 10, 2, 0)


-------------------Kho-----------------------
INSERT [dbo].[Kho] ([MaNL], [SoLuong]) VALUES (1, 16)
INSERT [dbo].[Kho] ([MaNL], [SoLuong]) VALUES (2, 41)
INSERT [dbo].[Kho] ([MaNL], [SoLuong]) VALUES (3, 31)
INSERT [dbo].[Kho] ([MaNL], [SoLuong]) VALUES (4, 32)
INSERT [dbo].[Kho] ([MaNL], [SoLuong]) VALUES (5, 14)
INSERT [dbo].[Kho] ([MaNL], [SoLuong]) VALUES (6, 2)
INSERT [dbo].[Kho] ([MaNL], [SoLuong]) VALUES (7, 2)
INSERT [dbo].[Kho] ([MaNL], [SoLuong]) VALUES (8, 2)
INSERT [dbo].[Kho] ([MaNL], [SoLuong]) VALUES (9, 2)


----------------------Báo cáo------------------------------

SET IDENTITY_INSERT [dbo].[BaoCao] ON 

INSERT [dbo].[BaoCao] ([MaBC], [TenNV], [NgayLap], [Loai], [StoreID], [Mota]) VALUES (1, N'Đỗ Thắng', CAST(N'2021-08-25 15:51:39.767' AS DateTime), N'Xuất hàng', N'044', N'Xuất hàng thành công
Bột Mỳ- Số lượng : 1- Tổng : 10000
Cocacola- Số lượng : 2- Tổng : 10000')
INSERT [dbo].[BaoCao] ([MaBC], [TenNV], [NgayLap], [Loai], [StoreID], [Mota]) VALUES (2, N'Đỗ Thắng', CAST(N'2021-08-25 15:56:24.543' AS DateTime), N'Xuất hàng', N'044', N'Xuất hàng thành công
Cánh Gà- Số lượng : 6- Tổng : 360000
Chân Gà- Số lượng : 3- Tổng : 120000
Bột Mỳ- Số lượng : 3- Tổng : 30000
Gạo- Số lượng : 3- Tổng : 90000
Lườn gà- Số lượng : 3- Tổng : 210000')
INSERT [dbo].[BaoCao] ([MaBC], [TenNV], [NgayLap], [Loai], [StoreID], [Mota]) VALUES (3, N'Đỗ Thắng', CAST(N'2021-08-25 15:58:30.357' AS DateTime), N'Hủy hàng', N'044', N'Hết date
Gạo- Số lượng : 23- Tổng : 230000
Chân Gà- Số lượng : 1- Tổng : 10000
Cánh Gà- Số lượng : 1- Tổng : 10000
Bột Mỳ- Số lượng : 1- Tổng : 10000
Lườn gà- Số lượng : 1- Tổng : 10000')
INSERT [dbo].[BaoCao] ([MaBC], [TenNV], [NgayLap], [Loai], [StoreID], [Mota]) VALUES (4, N'Đỗ Thắng', CAST(N'2021-08-25 15:58:39.073' AS DateTime), N'Xuất hàng', N'044', N'Xuất hàng thành công
Bột Mỳ- Số lượng : 3- Tổng : 30000
Chân Gà- Số lượng : 2- Tổng : 80000')
INSERT [dbo].[BaoCao] ([MaBC], [TenNV], [NgayLap], [Loai], [StoreID], [Mota]) VALUES (6, N'Đỗ Thắng', CAST(N'2021-08-26 16:00:12.367' AS DateTime), N'Nhập hàng', N'044', N'Mã hóa đơn : 8
	Tên nguyên liệu Cánh Gà - Số lượng : 1 - Tổng : 60000
	Tên nguyên liệu Bột Mỳ - Số lượng : 1 - Tổng : 10000')
INSERT [dbo].[BaoCao] ([MaBC], [TenNV], [NgayLap], [Loai], [StoreID], [Mota]) VALUES (7, N'Đỗ Thắng', CAST(N'2021-08-26 16:00:38.813' AS DateTime), N'Nhập hàng', N'044', N'Mã hóa đơn : 8
	Tên nguyên liệu Cánh Gà - Số lượng : 2 - Tổng : 120000
	Tên nguyên liệu Cà chua - Số lượng : 22 - Tổng : 418000
	Tên nguyên liệu Lườn gà - Số lượng : 4 - Tổng : 280000')
INSERT [dbo].[BaoCao] ([MaBC], [TenNV], [NgayLap], [Loai], [StoreID], [Mota]) VALUES (9, N'Đỗ Thắng', CAST(N'2021-08-26 16:06:51.413' AS DateTime), N'Nhập hàng', N'044', N'Mã hóa đơn : 8
	Tên nguyên liệu Cà chua - Số lượng : 1 - Tổng : 19000')
INSERT [dbo].[BaoCao] ([MaBC], [TenNV], [NgayLap], [Loai], [StoreID], [Mota]) VALUES (10, N'Đỗ Thắng', CAST(N'2021-08-26 16:07:14.023' AS DateTime), N'Nhập hàng', N'044', N'Mã hóa đơn : 8
	Tên nguyên liệu Cánh Gà - Số lượng : 1 - Tổng : 60000
	Tên nguyên liệu Gạo - Số lượng : 1 - Tổng : 30000')
INSERT [dbo].[BaoCao] ([MaBC], [TenNV], [NgayLap], [Loai], [StoreID], [Mota]) VALUES (11, N'Đỗ Thắng', CAST(N'2021-08-26 16:07:37.350' AS DateTime), N'Nhập hàng', N'044', N'Mã hóa đơn : 8
	Tên nguyên liệu Xà lách - Số lượng : 1 - Tổng : 49000
	Tên nguyên liệu Cà chua - Số lượng : 1 - Tổng : 19000
	Tên nguyên liệu Bột Mỳ - Số lượng : 1 - Tổng : 10000')
INSERT [dbo].[BaoCao] ([MaBC], [TenNV], [NgayLap], [Loai], [StoreID], [Mota]) VALUES (12, N'Đỗ Thắng', CAST(N'2021-08-26 16:31:15.643' AS DateTime), N'Nhập hàng', N'044', N'Mã hóa đơn : 8
	Tên nguyên liệu Bột Mỳ - Số lượng : 1 - Tổng : 10000
	Tên nguyên liệu Cánh Gà - Số lượng : 1 - Tổng : 60000
	Tên nguyên liệu Gạo - Số lượng : 1 - Tổng : 30000
	Tên nguyên liệu Chân Gà - Số lượng : 1 - Tổng : 40000
	Tên nguyên liệu Lườn gà - Số lượng : 2 - Tổng : 140000
	Tên nguyên liệu Dasani - Số lượng : 2 - Tổng : 5000
	Tên nguyên liệu Cocacola - Số lượng : 2 - Tổng : 10000
	Tên nguyên liệu Ức gà - Số lượng : 2 - Tổng : 112000
	Tên nguyên liệu Xà lách - Số lượng : 2 - Tổng : 98000')
INSERT [dbo].[BaoCao] ([MaBC], [TenNV], [NgayLap], [Loai], [StoreID], [Mota]) VALUES (13, N'Đỗ Thắng', CAST(N'2021-08-28 23:22:12.663' AS DateTime), N'Nhập hàng', N'044', N'Mã hóa đơn : 8
	Tên nguyên liệu Bột Mỳ - Số lượng : 5 - Tổng : 50000
	Tên nguyên liệu Chân Gà - Số lượng : 2 - Tổng : 80000')
INSERT [dbo].[BaoCao] ([MaBC], [TenNV], [NgayLap], [Loai], [StoreID], [Mota]) VALUES (14, N'Đỗ Thắng', CAST(N'2021-08-28 23:22:14.633' AS DateTime), N'Nhập hàng-Thiếu', N'044', N'Mã đơn hàng 8 .Đơn hàng thiếu : 
Bột Mỳ- Thiếu : 4
Cánh Gà- Thiếu : 7
Gạo- Thiếu : 10
Chân Gà- Thiếu : 21
Lườn gà- Thiếu : 6
Dasani- Thiếu : 10
Cocacola- Thiếu : 10
Ức gà- Thiếu : 10
Xà lách- Thiếu : 9')
SET IDENTITY_INSERT [dbo].[BaoCao] OFF
