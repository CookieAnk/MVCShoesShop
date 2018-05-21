use master

create database ShoesShop
use ShoesShop
Drop database ShoesShop


 create table KHACH_HANG
 (
	MaKH int identity(1,1) primary key,
	TenKH nvarchar(50),
	DiaChi nvarchar(50),
	SDT varchar(50),
	Email nvarchar(50),
	IDLogin varchar(50),
	Pass varchar(50)
 )

create table LOAI_SAN_PHAM
(
	MaLoaiSP int identity(1,1)primary key,
	TenLoai nvarchar(50),
)

create table SAN_PHAM
(
	MaSP int identity(1,1)primary key,
	TenSP nvarchar(50),
	MaLoaiSP int foreign key references LOAI_SAN_PHAM(MaLoaiSP),
	SoLuongCon int,
	DonGia money,
	Images nvarchar(50),
)

create table HOA_DON
(
	MaHD int identity(1,1) primary key,
	MaKH int foreign key references KHACH_HANG(MaKH),
	NgayLapHD date,
	HinhThucThanhToan nvarchar(50),
	TongTien money,
	TinhTrangThanhToan bit,
)
 create table CT_HOA_DON
 (
	MaCTHD int identity(1,1)primary key,
	MaHD int foreign key references HOA_DON(MaHD),
	MaSP int foreign key references SAN_PHAM(MaSP),
	SoLuong int,
	DonGia money,
	ThanhTien money,
 )

 create table DON_DAT_HANG
 (
	MaDDH int identity(1,1) primary key,
	NgayLapDDH date,
	MaKH int foreign key references KHACH_HANG(MaKH),
 )
 create table CT_DON_DAT_HANG
 (

	MaDDH int foreign key references DON_DAT_HANG(MaDDH),
	MaSP int foreign key references SAN_PHAM(MaSP),
	SoLuong int,
	DonGia money,
	constraint PK_CTDDH primary key(MaDDH,MaSP)
 )

 create table TinhTrangDonHang
 (
	MaTT int identity(1,1) primary key,
	TenTT nvarchar(50),
 )
 set identity_insert TinhTrangDonHang on
 insert into TinhTrangDonHang(MaTT,TenTT) values (1,'Đang xác nhận');
 insert into TinhTrangDonHang(MaTT,TenTT) values (2,'Đã xác nhận');
 insert into TinhTrangDonHang(MaTT,TenTT) values (3,'Đang giao hàng');
 insert into TinhTrangDonHang(MaTT,TenTT) values (4,'Đã giao hàng');
 set identity_insert TinhTrangDonHang off

 create table PHIEU_GIAO_HANG
  (
	MaPGH int identity(1,1) primary key,
	MaKH int foreign key references KHACH_HANG(MaKH),
	NgayGiaoHang date,
	MaTT int foreign key references TinhTrangDonHang(MaTT)
 )
 create table CT_PHIEU_GIAO_HANG
 (
	MaPGH int foreign key references PHIEU_GIAO_HANG(MaPGH),
	MaSP int foreign key references SAN_PHAM(MaSP),
	SoLuong money,
	DonGia money,
	ThanhTien money,
	constraint PK_CTPGH primary key(MaSP,MaPGH)
 )

create table DangNhap
(
	id varchar(50) primary key,
	Username varchar(50),
	Pass varchar(max),
	PhanQuyen varchar(50),
)

set identity_insert KHACH_HANG on
insert into KHACH_HANG (MaKH, TenKH, DiaChi, SDT, Email, IDLogin, Pass) values (1, 'Ronny Eytel', '72885 Ludington Drive', '3534574215', 'reytel0@squidoo.com', 'reytel0', 'rjtBUexg4w');
insert into KHACH_HANG (MaKH, TenKH, DiaChi, SDT, Email, IDLogin, Pass) values (2, 'Krysta Keble', '5437 Grasskamp Avenue', '4082087959', 'kkeble1@pinterest.com', 'kkeble1', 'CZOzjdu');
insert into KHACH_HANG (MaKH, TenKH, DiaChi, SDT, Email, IDLogin, Pass) values (3, 'Margaux Bougen', '7382 Hintze Pass', '5875538494', 'mbougen2@bloglovin.com', 'mbougen2', 'znrSZ1');
insert into KHACH_HANG (MaKH, TenKH, DiaChi, SDT, Email, IDLogin, Pass) values (4, 'Wenona O'' Dornan', '8726 Del Sol Park', '2241373941', 'wo3@globo.com', 'wo3', 'bfqLYFtOx');
insert into KHACH_HANG (MaKH, TenKH, DiaChi, SDT, Email, IDLogin, Pass) values (5, 'Elladine Reavell', '93 Milwaukee Terrace', '2934085401', 'ereavell4@arizona.edu', 'ereavell4', 'yFxYE1Jxok');
insert into KHACH_HANG (MaKH, TenKH, DiaChi, SDT, Email, IDLogin, Pass) values (6, 'Tobin Guillond', '61281 International Circle', '6043826930', 'tguillond5@businesswire.com', 'tguillond5', 'BBbe1Ut7S6D');
insert into KHACH_HANG (MaKH, TenKH, DiaChi, SDT, Email, IDLogin, Pass) values (7, 'Fowler Pywell', '15049 Chive Road', '9924590896', 'fpywell6@blogger.com', 'fpywell6', '7gJSHMyG7tm');
insert into KHACH_HANG (MaKH, TenKH, DiaChi, SDT, Email, IDLogin, Pass) values (8, 'Matthew Scothron', '1851 Judy Crossing', '3995609680', 'mscothron7@google.com.au', 'mscothron7', 'LJujkRvx2');
insert into KHACH_HANG (MaKH, TenKH, DiaChi, SDT, Email, IDLogin, Pass) values (9, 'Conroy Andryunin', '1910 Elka Pass', '3414934263', 'candryunin8@sogou.com', 'candryunin8', 'uK3iH2');
insert into KHACH_HANG (MaKH, TenKH, DiaChi, SDT, Email, IDLogin, Pass) values (10, 'Laurent Tiery', '140 West Point', '2783786947', 'ltiery9@google.com', 'ltiery9', 'F8hb4Q');
set identity_insert KHACH_HANG off

set identity_insert LOAI_SAN_PHAM on
insert into LOAI_SAN_PHAM (MaLoaiSP, TenLoai) values (1, 'Podcat');
insert into LOAI_SAN_PHAM (MaLoaiSP, TenLoai) values (2, 'Kare');
insert into LOAI_SAN_PHAM (MaLoaiSP, TenLoai) values (3, 'Fanoodle');
insert into LOAI_SAN_PHAM (MaLoaiSP, TenLoai) values (4, 'Youopia');
insert into LOAI_SAN_PHAM (MaLoaiSP, TenLoai) values (5, 'Avamm');
set identity_insert LOAI_SAN_PHAM off

insert into SAN_PHAM (TenSP, MaLoaiSP, SoLuongCon, DonGia, Images) values ('FLUID CLOUD', 1, 3, '$115.18', 'fluid.jpg');
insert into SAN_PHAM (TenSP, MaLoaiSP, SoLuongCon, DonGia, Images) values ('Galaxy Trail', 4, 83, '$757.17', 'galaxy.jpg');
insert into SAN_PHAM (TenSP, MaLoaiSP, SoLuongCon, DonGia, Images) values ('Vagram', 4, 133, '$292.73', 'gtx.jpg');
insert into SAN_PHAM (TenSP, MaLoaiSP, SoLuongCon, DonGia, Images) values ('Adidas Yeezy 350', 1, 60, '$803.71', 'IBOSN18928.jpg');
insert into SAN_PHAM (TenSP, MaLoaiSP, SoLuongCon, DonGia, Images) values ('Toughjoyfax', 1, 31, '$886.51', 'icon.jpg');
insert into SAN_PHAM (TenSP, MaLoaiSP, SoLuongCon, DonGia, Images) values ('Edge Lux', 5, 112, '$774.63', 'lux.jpg');
insert into SAN_PHAM (TenSP, MaLoaiSP, SoLuongCon, DonGia, Images) values ('Adidas LZRMS45852 sport shoes', 5, 136, '$120.45', 'LZRMS45852.jpg');
insert into SAN_PHAM (TenSP, MaLoaiSP, SoLuongCon, DonGia, Images) values ('NMD_CS2 PRIMEKNIT SHOES', 1, 120, '$287.81', 'Nmd_cs2.jpg');
insert into SAN_PHAM (TenSP, MaLoaiSP, SoLuongCon, DonGia, Images) values ('NMD_R1 ', 2, 3, '$485.49', 'NMD_R1.jpg');
insert into SAN_PHAM (TenSP, MaLoaiSP, SoLuongCon, DonGia, Images) values ('NMD_XR1 SHOES', 5, 81, '$177.83', 'nmd_xr1.jpg');
insert into SAN_PHAM (TenSP, MaLoaiSP, SoLuongCon, DonGia, Images) values ('TENIS NMD_R1', 2, 92, '$415.43', 'NMDR1.jpg');
insert into SAN_PHAM (TenSP, MaLoaiSP, SoLuongCon, DonGia, Images) values ('Adidas shoes Zx Flux', 2, 27, '$136.05', 'OKTKG32296.jpg');
insert into SAN_PHAM (TenSP, MaLoaiSP, SoLuongCon, DonGia, Images) values ('Ultraboost X Parley', 4, 50, '$450.67', 'parley.jpg');
insert into SAN_PHAM (TenSP, MaLoaiSP, SoLuongCon, DonGia, Images) values ('SPEED TRAINER 3 SHOES', 2, 148, '$507.21', 'speedtrain.jpg');
insert into SAN_PHAM (TenSP, MaLoaiSP, SoLuongCon, DonGia, Images) values ('Supernova ST', 2, 85, '$377.42', 'ST.jpg');
insert into SAN_PHAM (TenSP, MaLoaiSP, SoLuongCon, DonGia, Images) values ('TENIS RESPONSE LITE (BLACK)', 5, 30, '$235.34', 'tenisliteblack.jpg');
insert into SAN_PHAM (TenSP, MaLoaiSP, SoLuongCon, DonGia, Images) values ('Pureboost X All Terrain', 1, 33, '$920.51', 'terrain.jpg');
insert into SAN_PHAM (TenSP, MaLoaiSP, SoLuongCon, DonGia, Images) values ('Ultraboost uncaged', 4, 133, '$255.54', 'uncaged.jpg');
insert into SAN_PHAM (TenSP, MaLoaiSP, SoLuongCon, DonGia, Images) values ('SUPERSTAR VULC ADV SHOES', 4, 130, '$759.39', 'superstar.jpg');

insert into DangNhap(id,Username,Pass) values ('1','admin','123')