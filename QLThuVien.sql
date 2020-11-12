create database QuanLyThuVien
go

USE QuanLyThuVien
GO
-- tạo bảng Bằng cấp
CREATE TABLE BANGCAP
(
	MaBC char(20) PRIMARY KEY NOT NULL,
	TenBC nvarchar(50) NOT NULL
)
GO
-- tạo bảng Nhân viên
CREATE TABLE NHANVIEN
(
	MaNV char(20) PRIMARY KEY NOT NULL,
	HoTenNV nvarchar(50) NOT NULL,
	Ngaysinh datetime,
	Diachi nvarchar(100) NOT NULL,
	Dienthoai char(20) NOT NULL,
	MaBC char(20) NOT NULL,
	CONSTRAINT FK_NHANVIEN_BANGCAP FOREIGN KEY (MaBC) REFERENCES BANGCAP
)
GO
-- tạo bảng Đọc giả
CREATE TABLE DOCGIA
(
	MaDocGia char(20) PRIMARY KEY NOT NULL,
	HoTenDocGia nvarchar(100) NOT NULL,
	Diachi char(100) NOT NULL,
	NgaySinh datetime NOT NULL,
	Email nvarchar(50),
	Ngaylapthe datetime,
	Ngayhethan datetime,
	Tienno Float NOT NULL
)
GO
-- tạo bảng Phiếu thu tiền
CREATE TABLE PHIEUTHUTIEN
(
	MaPTT char(20) PRIMARY KEY NOT NULL,
	Sotienno Float NOT NULL,
	Sotienthu Float NOT NULL,
	MaDocGia char(20) NOT NULL,
	MaNV char(20) NOT NULL,
	CONSTRAINT FK_PHIEUTHUTIEN_DOCGIA FOREIGN KEY (MaDocGia) REFERENCES DOCGIA,
	CONSTRAINT FK_PHIEUTHUTIEN_NHANVIEN FOREIGN KEY (MaNV) REFERENCES NHANVIEN
)
GO 
-- tạo bảng Sách
CREATE TABLE SACH
(
	MaSach char(20) PRIMARY KEY NOT NULL,
	TenSach nvarchar(50) NOT NULL,
	TacGia nvarchar(50) NOT NULL,
	Namxuatban datetime NOT NULL,
	Nhaxuatban nvarchar(50) NOT NULL,
	Trigia Float NOT NULL,
	Ngaynhap datetime
)
GO
-- tạo bảng Phiếu mượn sách
CREATE TABLE PHIEUMUONSACH
(
	MaPMS char(20) PRIMARY KEY NOT NULL,
	Ngaymuon datetime NOT NULL,
	MaDocGia char(20) NOT NULL,
	CONSTRAINT FK_PHIEUMUONSACH_DOCGIA FOREIGN KEY (MaDocGia) REFERENCES DOCGIA 
)
GO
-- tạo bảng Chi tiết phiếu mượn
CREATE TABLE CHITIETPHIEUMUON
(
	MaSach char(20) NOT NULL,
	MaPMS char(20) NOT NULL,
	NgayTra datetime,
	CONSTRAINT PK_CHITIETPHIEUMUON PRIMARY KEY (MaSach, MaPMS),
	CONSTRAINT FK_CHITIETPHIEUMUON_SACH FOREIGN KEY (MaSach) REFERENCES SACH,
	CONSTRAINT FK_CHITIETPHIEUMUON_PHIEUMUONSACH FOREIGN KEY (MaPMS) REFERENCES PHIEUMUONSACH
)
GO
CREATE TABLE ACCOUNT
(
	ID INT IDENTITY PRIMARY KEY,
	Username NCHAR(100) NOT NULL,
	Passwork NCHAR(100) NOT NULL,
	IdNV char(20) NOT NULL,
	FOREIGN KEY(IdNV) REFERENCES dbo.NHANVIEN(MaNV)
)
GO

use QuanLyThuVien
go
INSERT INTO SACH(MaSach,TenSach, TacGia, NamXuatBan, NhaXuatBan, TriGia, NgayNhap) VALUES
('S001',N'Toán Tin', N'Phó Đức Chính', '2010-08-10', N'Hà Nội', 55000, '2011-01-15'),
('S002',N'Chuyện nhỏ trong thế giới lớn', N'E.H.GOMBRICH', '2015-04-15', N'NXB Tri thức', 120000, '2015-08-30'),
('S003',N'Hạt giống tâm hồn', N'Nhiều tác giả', '2016-01-19', N'NXB Tổng Hợp', 42000, '2019-03-20'),
('S004',N'Cho tôi xin một vé đi tuổi thơ', N'Nguyễn Nhật Ánh', '2013-03-19', N'NXB Trẻ', 40000, '2014-12-07'),
('S005',N'Số Đỏ', N'Kim Lân', '2018-07-30', N'NXB Văn Học', 65000, '2018-07-31')

INSERT INTO BANGCAP(MaBC,TenBC)
VALUES (N'QC002',N'Cao Đẳng'),
(N'QC003',N'Đại Học'),
(N'QC004',N'Thạc Sĩ'),
(N'QC005',N'Tiến Sĩ')


INSERT INTO NHANVIEN(MaNV,HoTenNV, Ngaysinh, Diachi, Dienthoai, MaBC)
VALUES
(N'021',N'Phan Thị Thu Trang', '2000-03-19', N'Lê Đức Thọ, Q.Gò Vấp, TP.HCM', '0764933597',N'QC003'),
(N'323',N'Võ Anh Bằng', '1997-12-05', N'Thái An, Q.12, TP.HCM', '090872452',N'QC005'),
(N'129',N'Mai Thanh Xuân', '1998-03-20', N'01 Phùng Văn Cung, Q.Phú Nhuận, TP.HCM', '036757723', N'QC004'),
(N'015',N'Nguyễn Tuấn Anh', '1999-01-24', N' 461 Võ Văn Tần, Q.3, TP.HCM', '0906355654', N'QC002'),
(N'056',N'Trần Khánh Hà', '1998-06-13', N'371 Nguyễn Kiệm, Q.Qò Vấp, TP.HCM', '0903743235', N'QC003')


INSERT INTO DOCGIA(MaDocGia,HoTenDocGia, NgaySinh, DiaChi, Email, NgayLapThe, NgayHetHan, TienNo)
VALUES
(N'T001',N'Lưu Thành LỄ', '1992-09-07', N'24 Vạn Kiếp, Q.Bình Thạnh, TP.HCM', 'le.ngth@gmail.com', '2018-03-10','2020-03-20', 0),
(N'T003',N'Ngô Văn Long', '2001-09-17', N'113 Trần Kế Xương, Q.5, TP.HCM','long.nv@gmail.com', '2019-01-24','2020-04-24', 55000),
(N'T002',N'Trần Minh Vương', '2000-03-20', N'97 3 Tháng 2, Q.11, TP.HCM', 'vuong.vm@gmail.com', '2020-02-12','2020-06-12', 20000),
(N'T009',N'Võ Kim Chi', '1999-06-24', N' 112 Trần Não, Q.2, TP.HCM', 'bao.la@gmail.com', '2019-03-20','2020-05-11', 40000),
(N'T010',N'Trần Hạnh Mai', '1998-06-13', N'32/3 Lê Chí Thọ, Q.6, TP.HCM', 'mai.ngocng@gmail.com', '2019-06-05','2020-06-05', 0)

use QuanLyThuVien
go
INSERT INTO PHIEUTHUTIEN(MaPTT,SoTienNo, SoTienThu, MaDocGia, MaNV)
VALUES
(N'001',0, 30000,N'T001', N'056'),
(N'003',55000, 100000, N'T003', N'021'),
(N'004',40000, 50000, N'T009', N'056'),
(N'002',20000, 20000, N'T002', N'129'),
(N'006',0, 10000, N'T010', N'323')

INSERT INTO PHIEUMUONSACH(MaPMS,Ngaymuon, MaDocGia)
VALUES
(N'093','2020-01-22', N'T001'),
(N'094','2020-04-20', N'T003'),
(N'095','2020-02-14', N'T009'),
(N'096','2020-06-23', N'T002'),
(N'097','2020-05-17', N'T010')

INSERT INTO CHITIETPHIEUMUON(MaSach, MaPMS, NgayTra)
VALUES
(N'S002',N'094' ,'2020-08-22'),
(N'S001',N'097','2020-04-11'),
(N'S005', N'093','2020-06-16'),
(N'S003',N'096',null),
(N'S004', N'095',null)
GO

-- chức năng
CREATE VIEW view_PhieuMuon AS 
SELECT MaSach,CHITIETPHIEUMUON.MaPMS,MaDocGia,Ngaymuon FROM dbo.CHITIETPHIEUMUON INNER JOIN dbo.PHIEUMUONSACH 
ON PHIEUMUONSACH.MaPMS = CHITIETPHIEUMUON.MaPMS
GO 

CREATE PROC USP_ThemPhieuMuon 
@MaSach CHAR(20),@MaPMS CHAR(20),@MaDocGia CHAR(20),@Ngaymuon DATE
AS
BEGIN
    INSERT INTO dbo.PHIEUMUONSACH(MaPMS,Ngaymuon,MaDocGia)
    VALUES(@MaPMS,@Ngaymuon,@MaDocGia)

    INSERT INTO dbo.CHITIETPHIEUMUON(MaSach,MaPMS,NgayTra)
    VALUES(@MaSach,@MaPMS,NULL)
END
GO

CREATE PROC USP_SuaPhieuMuon
@MaSach CHAR(20),@MaPMS CHAR(20),@MaDocGia CHAR(20),@Ngaymuon DATE
AS 
BEGIN
    UPDATE dbo.PHIEUMUONSACH SET Ngaymuon = @Ngaymuon,MaDocGia = @MaDocGia WHERE MaPMS = @MaPMS
    UPDATE dbo.CHITIETPHIEUMUON SET MaSach = @MaSach WHERE MaPMS = @MaPMS
END
GO
CREATE PROC USP_XoaPhieuMuon
@MaPMS CHAR(20)
AS
BEGIN
    DELETE dbo.CHITIETPHIEUMUON WHERE MaPMS = @MaPMS
    DELETE dbo.PHIEUMUONSACH WHERE MaPMS = @MaPMS
END
GO

-- Login --
CREATE PROC USP_Login
@Username NCHAR(100), @Password NCHAR(100)
AS
BEGIN
	SELECT * FROM dbo.ACCOUNT
	WHERE Username = @Username AND Passwork = @Password
END
GO
SELECT * FROM dbo.ACCOUNT

SELECT * FROM dbo.ACCOUNT JOIN dbo.NHANVIEN ON NHANVIEN.MaNV = ACCOUNT.IdNV
WHERE Username = 'Admin' AND Passwork = 'ICy5YqxZB1uWSwcVLSNLcA=='