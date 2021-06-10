--DROP database QLTuyenSinh
--INSERT TỪ TRÊN XUỐNG DƯỚI TRỪ 2 DÒNG CUỐI
CREATE DATABASE QLTuyenSinh
GO
USE QLTuyenSinh
GO
CREATE TABLE TRUONG
(
	ma_truong varchar(4) primary key,
	ten_truong nvarchar(50)
)
GO
CREATE TABLE NGANH
(
	ma_nganh varchar(20) primary key,
	ten_nganh nvarchar(50)
)
GO
CREATE TABLE PHIEU_DKDT
(
	so_phieu varchar(50) primary key,
	khoi_thi varchar(4),
	ho_va_ten nvarchar(50),
	khu_vuc nvarchar(50),
	nam_tot_nghiep int,
	he_dao_tao nvarchar(3),
	ma_doi_tuong varchar(3),
	dang_ky_thi nvarchar(3),
	ma_truong varchar(4),
	ma_nganh varchar(20),
	ngay_sinh smalldatetime,
	noi_sinh nvarchar(50),
	dia_chi_bao_tin nvarchar(50)
	
)
GO
CREATE TABLE DIEM_CHUAN
(
	ma_nganh varchar(20) Primary Key,
	diem_chuan float
)
GO
CREATE TABLE THI_SINH
(
	so_bao_danh varchar(10) Primary Key,
	ho_ten nvarchar(50),
	ngay_sinh smalldatetime,
	noi_sinh nvarchar(50),
	dia_chi_bao_tin nvarchar(50)
)
GO
CREATE TABLE GIAY_BAO_THI
(
	so_bao_danh varchar(10) Primary Key,
	ngay_thi smalldatetime,
	dia_diem_thi nvarchar(50),
	so_phong_thi varchar(4),
	le_phi_thi money
)
GO
CREATE TABLE KET_QUA_THI
(
	ma_ket_qua varchar(4) Primary Key,
	diem_thi float,
	mon nvarchar(20),
	so_bao_danh varchar(10)
)
GO
CREATE TABLE TUI_CHAM_THI
(
	ma_tui varchar(8) Primary Key,
	ma_mon int
)
GO
CREATE TABLE BAI_THI
(
	so_phach int Primary Key,
	so_bao_danh varchar(10),
	ma_tui varchar(8)
)
CREATE TABLE MON_THI
(
	ma_mon int Primary Key,
	ten_mon nvarchar(10)
)
GO
CREATE TABLE KET_QUA_CHAM_THI
(
	so_phach int Primary Key,
	diem_thi float,
	so_bao_danh varchar (10),
	ma_mon int
)
GO
CREATE TABLE KET_QUA_TUYEN_SINH
(
	so_bao_danh varchar(10) Primary Key,
	ma_nganh varchar(20), 
	tong_diem float,
	trung_tuyen nvarchar(20)
)
GO
--TAO KHOA NGOAI
ALTER TABLE PHIEU_DKDT
ADD CONSTRAINT FK_TRUONG_PDKDT
FOREIGN KEY (ma_truong)
REFERENCES TRUONG(ma_truong)
GO
ALTER TABLE PHIEU_DKDT
ADD CONSTRAINT FK_NGANH_PDKDT
FOREIGN KEY (ma_nganh)
REFERENCES NGANH(ma_nganh)
GO
ALTER TABLE DIEM_CHUAN
ADD CONSTRAINT FK_NGANH_DIEMCHUAN
FOREIGN KEY (ma_nganh)
REFERENCES NGANH(ma_nganh)
GO
ALTER TABLE KET_QUA_TUYEN_SINH
ADD CONSTRAINT FK_NGANH_KQTS
FOREIGN KEY (ma_nganh)
REFERENCES NGANH(ma_nganh)
GO
ALTER TABLE KET_QUA_TUYEN_SINH
ADD CONSTRAINT FK_THISINH_KQTS
FOREIGN KEY (so_bao_danh)
REFERENCES THI_SINH(so_bao_danh)
GO
ALTER TABLE GIAY_BAO_THI
ADD CONSTRAINT FK_THISINH_GBT
FOREIGN KEY (so_bao_danh)
REFERENCES THI_SINH(so_bao_danh)
GO
ALTER TABLE BAI_THI
ADD CONSTRAINT FK_THISINH_BAITHI
FOREIGN KEY (so_bao_danh)
REFERENCES THI_SINH(so_bao_danh)
GO
ALTER TABLE BAI_THI
ADD CONSTRAINT FK_TUICHAMTHI_BAITHI
FOREIGN KEY (ma_tui)
REFERENCES TUI_CHAM_THI(ma_tui)
GO
ALTER TABLE KET_QUA_THI
ADD CONSTRAINT FK_THISINH_KQT
FOREIGN KEY (so_bao_danh)
REFERENCES THI_SINH(so_bao_danh)
GO
ALTER TABLE TUI_CHAM_THI
ADD CONSTRAINT FK_MONTHI_TUICHAMTHI
FOREIGN KEY (ma_mon)
REFERENCES MON_THI(ma_mon)
GO
ALTER TABLE KET_QUA_CHAM_THI
ADD CONSTRAINT FK_THISINH_KQCT
FOREIGN KEY (so_bao_danh)
REFERENCES THI_SINH(so_bao_danh)
GO
ALTER TABLE KET_QUA_CHAM_THI
ADD CONSTRAINT FK_BAITHI_KQCT
FOREIGN KEY (so_phach)
REFERENCES BAI_THI(so_phach)
GO
ALTER TABLE KET_QUA_CHAM_THI
ADD CONSTRAINT FK_MONTHI_KQCT
FOREIGN KEY (ma_mon)
REFERENCES MON_THI(ma_mon)
GO

--INSERT DATA
-- TABLE TRUONG
INSERT [dbo].[TRUONG] ([ma_truong], [ten_truong]) VALUES (N'QSC', N'Đại học Công nghệ Thông tin')
INSERT [dbo].[TRUONG] ([ma_truong], [ten_truong]) VALUES (N'QST', N'Đại học Khoa học Tự nhiên')
GO

-- TABLE NGANH
INSERT [dbo].[NGANH] ([ma_nganh], [ten_nganh]) VALUES (N'7340122', N'Thương mại điện tử')
INSERT [dbo].[NGANH] ([ma_nganh], [ten_nganh]) VALUES (N'7480101', N'Khoa học máy tính')
INSERT [dbo].[NGANH] ([ma_nganh], [ten_nganh]) VALUES (N'7480102', N'Mạng máy tính và truyền thông dữ liệu')
INSERT [dbo].[NGANH] ([ma_nganh], [ten_nganh]) VALUES (N'7480103', N'Kỹ thuật phần mềm')
INSERT [dbo].[NGANH] ([ma_nganh], [ten_nganh]) VALUES (N'7480104', N'Hệ thống thông tin')
INSERT [dbo].[NGANH] ([ma_nganh], [ten_nganh]) VALUES (N'7480106', N'Kĩ thuật máy tính')
INSERT [dbo].[NGANH] ([ma_nganh], [ten_nganh]) VALUES (N'7480109', N'Khoa học dữ liệu')
INSERT [dbo].[NGANH] ([ma_nganh], [ten_nganh]) VALUES (N'7480201', N'Công nghệ thông tin')
INSERT [dbo].[NGANH] ([ma_nganh], [ten_nganh]) VALUES (N'7480202', N'An toàn thông tin')
GO
--TABLE PHIEU_DKDT
INSERT [dbo].[PHIEU_DKDT] ([so_phieu], [khoi_thi], [ho_va_ten], [khu_vuc], [nam_tot_nghiep], [he_dao_tao], [ma_doi_tuong], [dang_ky_thi], [ma_truong], [ma_nganh], [ngay_sinh], [noi_sinh], [dia_chi_bao_tin]) VALUES (N'DK20210001', N'A00', N'Nguyễn Văn Đạt', N'Khu vực 2NT', 2021, N'CB', NULL, N'CB', N'QSC', N'7480103', CAST(N'2002-01-01T00:00:00' AS SmallDateTime), N'Quảng Nam', NULL)
INSERT [dbo].[PHIEU_DKDT] ([so_phieu], [khoi_thi], [ho_va_ten], [khu_vuc], [nam_tot_nghiep], [he_dao_tao], [ma_doi_tuong], [dang_ky_thi], [ma_truong], [ma_nganh], [ngay_sinh], [noi_sinh], [dia_chi_bao_tin]) VALUES (N'DK20210002', N'A01', N'Phùng Thanh Tú', N'Khu vực 3', 2021, N'KCB', NULL, N'KCB', N'QSC', N'7480103', CAST(N'2002-02-02T00:00:00' AS SmallDateTime), N'Hà Tĩnh', N'Hà Tĩnh')
INSERT [dbo].[PHIEU_DKDT] ([so_phieu], [khoi_thi], [ho_va_ten], [khu_vuc], [nam_tot_nghiep], [he_dao_tao], [ma_doi_tuong], [dang_ky_thi], [ma_truong], [ma_nganh], [ngay_sinh], [noi_sinh], [dia_chi_bao_tin]) VALUES (N'DK20210003', N'A00', N'Nguyễn Trung Hiếu', N'Khu vực 1', 2021, N'CB', NULL, N'CB', N'QSC', N'7480103', CAST(N'2002-03-03T00:00:00' AS SmallDateTime), N'Đà Nẵng', N'Đà Nẵng')
INSERT [dbo].[PHIEU_DKDT] ([so_phieu], [khoi_thi], [ho_va_ten], [khu_vuc], [nam_tot_nghiep], [he_dao_tao], [ma_doi_tuong], [dang_ky_thi], [ma_truong], [ma_nganh], [ngay_sinh], [noi_sinh], [dia_chi_bao_tin]) VALUES (N'DK20210004', N'D07', N'Nguyễn Thanh Nga', N'Khu vực 2', 2021, N'CB', NULL, N'CB', N'QSC', N'7480103', CAST(N'2002-04-04T00:00:00' AS SmallDateTime), N'Phú Yên', N'Phú Yên')
INSERT [dbo].[PHIEU_DKDT] ([so_phieu], [khoi_thi], [ho_va_ten], [khu_vuc], [nam_tot_nghiep], [he_dao_tao], [ma_doi_tuong], [dang_ky_thi], [ma_truong], [ma_nganh], [ngay_sinh], [noi_sinh], [dia_chi_bao_tin]) VALUES (N'DK20210005', N'D01', N'Nguyễn Tấn Quân', N'Khu vực 3', 2021, N'CB', NULL, N'CB', N'QSC', N'7340122', CAST(N'2002-05-05T00:00:00' AS SmallDateTime), N'Phú Yên', N'Phú Yên')
INSERT [dbo].[PHIEU_DKDT] ([so_phieu], [khoi_thi], [ho_va_ten], [khu_vuc], [nam_tot_nghiep], [he_dao_tao], [ma_doi_tuong], [dang_ky_thi], [ma_truong], [ma_nganh], [ngay_sinh], [noi_sinh], [dia_chi_bao_tin]) VALUES (N'DK20210006', N'D07', N'Trần Quang Sáng', N'Khu vực 2NT', 2021, N'CB', NULL, N'CB', N'QSC', N'7480201', CAST(N'2002-06-06T00:00:00' AS SmallDateTime), N'Nghệ An', N'Nghệ An')
INSERT [dbo].[PHIEU_DKDT] ([so_phieu], [khoi_thi], [ho_va_ten], [khu_vuc], [nam_tot_nghiep], [he_dao_tao], [ma_doi_tuong], [dang_ky_thi], [ma_truong], [ma_nganh], [ngay_sinh], [noi_sinh], [dia_chi_bao_tin]) VALUES (N'DK20210007', N'A01', N'Cao Bá Lộc', N'Khu vực 1', 2021, N'KCB', NULL, N'KCB', N'QSC', N'7480202', CAST(N'2002-07-07T00:00:00' AS SmallDateTime), N'Sơn La', N'Sơn La')
INSERT [dbo].[PHIEU_DKDT] ([so_phieu], [khoi_thi], [ho_va_ten], [khu_vuc], [nam_tot_nghiep], [he_dao_tao], [ma_doi_tuong], [dang_ky_thi], [ma_truong], [ma_nganh], [ngay_sinh], [noi_sinh], [dia_chi_bao_tin]) VALUES (N'DK20210008', N'A00', N'Hồ Thị Trà My', N'Khu vực 2', 2021, N'KCB', NULL, N'KCB', N'QSC', N'7340122', CAST(N'2002-08-08T00:00:00' AS SmallDateTime), N'Bến Tre', N'Bến Tre')
INSERT [dbo].[PHIEU_DKDT] ([so_phieu], [khoi_thi], [ho_va_ten], [khu_vuc], [nam_tot_nghiep], [he_dao_tao], [ma_doi_tuong], [dang_ky_thi], [ma_truong], [ma_nganh], [ngay_sinh], [noi_sinh], [dia_chi_bao_tin]) VALUES (N'DK20210009', N'D01', N'Nguyễn Cẩm Tú', N'Khu vực 2NT', 2021, N'KCB', NULL, N'KCB', N'QSC', N'7480104', CAST(N'2002-09-09T00:00:00' AS SmallDateTime), N'Long An', N'Long An')
INSERT [dbo].[PHIEU_DKDT] ([so_phieu], [khoi_thi], [ho_va_ten], [khu_vuc], [nam_tot_nghiep], [he_dao_tao], [ma_doi_tuong], [dang_ky_thi], [ma_truong], [ma_nganh], [ngay_sinh], [noi_sinh], [dia_chi_bao_tin]) VALUES (N'DK20210010', N'A01', N'Nguyễn Đình Kim Oanh', N'Khu vực 3', 2021, N'KCB', NULL, N'KCB', N'QSC', N'7480201', CAST(N'2002-10-10T00:00:00' AS SmallDateTime), N'Bình Dương', N'Bình Dương')
GO

--TABLE THI_SINH
INSERT [dbo].[THI_SINH] ([so_bao_danh], [ho_ten], [ngay_sinh], [noi_sinh], [dia_chi_bao_tin]) VALUES (N'20520001', N'Nguyễn Văn Đạt', CAST(N'2002-01-01T00:00:00' AS SmallDateTime), N'Quảng Nam', N'Quảng Nam')
INSERT [dbo].[THI_SINH] ([so_bao_danh], [ho_ten], [ngay_sinh], [noi_sinh], [dia_chi_bao_tin]) VALUES (N'20520002', N'Phùng Thanh Tú', CAST(N'2002-02-02T00:00:00' AS SmallDateTime), N'Hà Tĩnh', N'Hà Tĩnh')
INSERT [dbo].[THI_SINH] ([so_bao_danh], [ho_ten], [ngay_sinh], [noi_sinh], [dia_chi_bao_tin]) VALUES (N'20520003', N'Nguyễn Trung Hiếu', CAST(N'2002-03-03T00:00:00' AS SmallDateTime), N'Đà Nẵng', N'Đà Nẵng')
INSERT [dbo].[THI_SINH] ([so_bao_danh], [ho_ten], [ngay_sinh], [noi_sinh], [dia_chi_bao_tin]) VALUES (N'20520004', N'Nguyễn Thanh Nga', CAST(N'2002-04-04T00:00:00' AS SmallDateTime), N'Phú Yên', N'Phú Yên')
INSERT [dbo].[THI_SINH] ([so_bao_danh], [ho_ten], [ngay_sinh], [noi_sinh], [dia_chi_bao_tin]) VALUES (N'20520005', N'Nguyễn Tấn Quân', CAST(N'2002-05-05T00:00:00' AS SmallDateTime), N'Phú Yên', N'Phú Yên')
INSERT [dbo].[THI_SINH] ([so_bao_danh], [ho_ten], [ngay_sinh], [noi_sinh], [dia_chi_bao_tin]) VALUES (N'20520006', N'Trần Quang Sáng', CAST(N'2002-06-06T00:00:00' AS SmallDateTime), N'Nghệ An', N'Nghệ An')
INSERT [dbo].[THI_SINH] ([so_bao_danh], [ho_ten], [ngay_sinh], [noi_sinh], [dia_chi_bao_tin]) VALUES (N'20520007', N'Cao Bá Lộc', CAST(N'2002-07-07T00:00:00' AS SmallDateTime), N'Sơn La', N'Sơn La')
INSERT [dbo].[THI_SINH] ([so_bao_danh], [ho_ten], [ngay_sinh], [noi_sinh], [dia_chi_bao_tin]) VALUES (N'20520008', N'Hồ Thị Trà My', CAST(N'2002-08-08T00:00:00' AS SmallDateTime), N'Bến Tre', N'Bến Tre')
INSERT [dbo].[THI_SINH] ([so_bao_danh], [ho_ten], [ngay_sinh], [noi_sinh], [dia_chi_bao_tin]) VALUES (N'20520009', N'Nguyễn Cẩm Tú', CAST(N'2002-09-09T00:00:00' AS SmallDateTime), N'Long An', N'Long An')
INSERT [dbo].[THI_SINH] ([so_bao_danh], [ho_ten], [ngay_sinh], [noi_sinh], [dia_chi_bao_tin]) VALUES (N'20520010', N'Nguyễn Đình Kim Oanh', CAST(N'2002-10-10T00:00:00' AS SmallDateTime), N'Bình Dương', N'Bình Dương')
GO

--TABLE GIAY_BAO_THI
INSERT [dbo].[GIAY_BAO_THI] ([so_bao_danh], [ngay_thi], [dia_diem_thi], [so_phong_thi], [le_phi_thi]) VALUES (N'20520001', CAST(N'2021-06-27T00:00:00' AS SmallDateTime), N'Trường đại học Công nghệ Thông tin', N'C101', 30000.0000)
INSERT [dbo].[GIAY_BAO_THI] ([so_bao_danh], [ngay_thi], [dia_diem_thi], [so_phong_thi], [le_phi_thi]) VALUES (N'20520002', CAST(N'2021-06-27T00:00:00' AS SmallDateTime), N'Trường đại học Công nghệ Thông tin', N'C101', 30000.0000)
INSERT [dbo].[GIAY_BAO_THI] ([so_bao_danh], [ngay_thi], [dia_diem_thi], [so_phong_thi], [le_phi_thi]) VALUES (N'20520003', CAST(N'2021-06-27T00:00:00' AS SmallDateTime), N'Trường đại học Công nghệ Thông tin', N'C101', 30000.0000)
INSERT [dbo].[GIAY_BAO_THI] ([so_bao_danh], [ngay_thi], [dia_diem_thi], [so_phong_thi], [le_phi_thi]) VALUES (N'20520004', CAST(N'2021-06-27T00:00:00' AS SmallDateTime), N'Trường đại học Công nghệ Thông tin', N'C101', 30000.0000)
INSERT [dbo].[GIAY_BAO_THI] ([so_bao_danh], [ngay_thi], [dia_diem_thi], [so_phong_thi], [le_phi_thi]) VALUES (N'20520005', CAST(N'2021-06-27T00:00:00' AS SmallDateTime), N'Trường đại học Công nghệ Thông tin', N'B306', 30000.0000)
INSERT [dbo].[GIAY_BAO_THI] ([so_bao_danh], [ngay_thi], [dia_diem_thi], [so_phong_thi], [le_phi_thi]) VALUES (N'20520006', CAST(N'2021-06-27T00:00:00' AS SmallDateTime), N'Trường đại học Công nghệ Thông tin', N'E4.1', 30000.0000)
INSERT [dbo].[GIAY_BAO_THI] ([so_bao_danh], [ngay_thi], [dia_diem_thi], [so_phong_thi], [le_phi_thi]) VALUES (N'20520007', CAST(N'2021-06-27T00:00:00' AS SmallDateTime), N'Trường đại học Công nghệ Thông tin', N'E4.4', 30000.0000)
INSERT [dbo].[GIAY_BAO_THI] ([so_bao_danh], [ngay_thi], [dia_diem_thi], [so_phong_thi], [le_phi_thi]) VALUES (N'20520008', CAST(N'2021-06-27T00:00:00' AS SmallDateTime), N'Trường đại học Công nghệ Thông tin', N'B708', 30000.0000)
INSERT [dbo].[GIAY_BAO_THI] ([so_bao_danh], [ngay_thi], [dia_diem_thi], [so_phong_thi], [le_phi_thi]) VALUES (N'20520009', CAST(N'2021-06-27T00:00:00' AS SmallDateTime), N'Trường đại học Công nghệ Thông tin', N'C122', 30000.0000)
INSERT [dbo].[GIAY_BAO_THI] ([so_bao_danh], [ngay_thi], [dia_diem_thi], [so_phong_thi], [le_phi_thi]) VALUES (N'20520010', CAST(N'2021-06-27T00:00:00' AS SmallDateTime), N'Trường đại học Công nghệ Thông tin', N'A125', 30000.0000)
GO

--TABLE MON_THI
INSERT [dbo].[MON_THI] ([ma_mon], [ten_mon]) VALUES (1, N'Toán')
INSERT [dbo].[MON_THI] ([ma_mon], [ten_mon]) VALUES (2, N'Ngữ Văn')
INSERT [dbo].[MON_THI] ([ma_mon], [ten_mon]) VALUES (3, N'Anh Văn')
INSERT [dbo].[MON_THI] ([ma_mon], [ten_mon]) VALUES (4, N'Vật Lý')
INSERT [dbo].[MON_THI] ([ma_mon], [ten_mon]) VALUES (5, N'Hóa Học')
INSERT [dbo].[MON_THI] ([ma_mon], [ten_mon]) VALUES (6, N'Sinh Học')
INSERT [dbo].[MON_THI] ([ma_mon], [ten_mon]) VALUES (7, N'Lịch Sử')
INSERT [dbo].[MON_THI] ([ma_mon], [ten_mon]) VALUES (8, N'Địa Lý')
INSERT [dbo].[MON_THI] ([ma_mon], [ten_mon]) VALUES (9, N'GDCD')
GO

--TABLE TUI_CHAM_THI
INSERT [dbo].[TUI_CHAM_THI] ([ma_tui], [ma_mon]) VALUES (N'T001', 1)
INSERT [dbo].[TUI_CHAM_THI] ([ma_tui], [ma_mon]) VALUES (N'T002', 2)
INSERT [dbo].[TUI_CHAM_THI] ([ma_tui], [ma_mon]) VALUES (N'T003', 3)
INSERT [dbo].[TUI_CHAM_THI] ([ma_tui], [ma_mon]) VALUES (N'T004', 4)
INSERT [dbo].[TUI_CHAM_THI] ([ma_tui], [ma_mon]) VALUES (N'T005', 5)
INSERT [dbo].[TUI_CHAM_THI] ([ma_tui], [ma_mon]) VALUES (N'T006', 6)
INSERT [dbo].[TUI_CHAM_THI] ([ma_tui], [ma_mon]) VALUES (N'T007', 7)
INSERT [dbo].[TUI_CHAM_THI] ([ma_tui], [ma_mon]) VALUES (N'T008', 8)
INSERT [dbo].[TUI_CHAM_THI] ([ma_tui], [ma_mon]) VALUES (N'T009', 9)
GO

--TABLE BAI_THI
INSERT [dbo].[BAI_THI] ([so_phach], [so_bao_danh], [ma_tui]) VALUES (1001, N'20520001', N'T001')
INSERT [dbo].[BAI_THI] ([so_phach], [so_bao_danh], [ma_tui]) VALUES (1002, N'20520002', N'T001')
INSERT [dbo].[BAI_THI] ([so_phach], [so_bao_danh], [ma_tui]) VALUES (1003, N'20520003', N'T001')
INSERT [dbo].[BAI_THI] ([so_phach], [so_bao_danh], [ma_tui]) VALUES (1004, N'20520008', N'T001')
INSERT [dbo].[BAI_THI] ([so_phach], [so_bao_danh], [ma_tui]) VALUES (1005, N'20520010', N'T001')
INSERT [dbo].[BAI_THI] ([so_phach], [so_bao_danh], [ma_tui]) VALUES (1006, N'20520006', N'T001')
INSERT [dbo].[BAI_THI] ([so_phach], [so_bao_danh], [ma_tui]) VALUES (1007, N'20520007', N'T001')
INSERT [dbo].[BAI_THI] ([so_phach], [so_bao_danh], [ma_tui]) VALUES (1008, N'20520008', N'T001')
INSERT [dbo].[BAI_THI] ([so_phach], [so_bao_danh], [ma_tui]) VALUES (1009, N'20520009', N'T001')
INSERT [dbo].[BAI_THI] ([so_phach], [so_bao_danh], [ma_tui]) VALUES (1010, N'20520010', N'T001')
INSERT [dbo].[BAI_THI] ([so_phach], [so_bao_danh], [ma_tui]) VALUES (2001, N'20520005', N'T002')
INSERT [dbo].[BAI_THI] ([so_phach], [so_bao_danh], [ma_tui]) VALUES (2002, N'20520009', N'T002')
INSERT [dbo].[BAI_THI] ([so_phach], [so_bao_danh], [ma_tui]) VALUES (3001, N'20520002', N'T003')
INSERT [dbo].[BAI_THI] ([so_phach], [so_bao_danh], [ma_tui]) VALUES (3002, N'20520004', N'T003')
INSERT [dbo].[BAI_THI] ([so_phach], [so_bao_danh], [ma_tui]) VALUES (3003, N'20520005', N'T003')
INSERT [dbo].[BAI_THI] ([so_phach], [so_bao_danh], [ma_tui]) VALUES (3004, N'20520006', N'T003')
INSERT [dbo].[BAI_THI] ([so_phach], [so_bao_danh], [ma_tui]) VALUES (3005, N'20520007', N'T003')
INSERT [dbo].[BAI_THI] ([so_phach], [so_bao_danh], [ma_tui]) VALUES (3006, N'20520009', N'T003')
INSERT [dbo].[BAI_THI] ([so_phach], [so_bao_danh], [ma_tui]) VALUES (3007, N'20520010', N'T003')
INSERT [dbo].[BAI_THI] ([so_phach], [so_bao_danh], [ma_tui]) VALUES (4001, N'20520001', N'T004')
INSERT [dbo].[BAI_THI] ([so_phach], [so_bao_danh], [ma_tui]) VALUES (4002, N'20520002', N'T004')
INSERT [dbo].[BAI_THI] ([so_phach], [so_bao_danh], [ma_tui]) VALUES (4003, N'20520003', N'T004')
INSERT [dbo].[BAI_THI] ([so_phach], [so_bao_danh], [ma_tui]) VALUES (4004, N'20520007', N'T004')
INSERT [dbo].[BAI_THI] ([so_phach], [so_bao_danh], [ma_tui]) VALUES (4005, N'20520008', N'T004')
INSERT [dbo].[BAI_THI] ([so_phach], [so_bao_danh], [ma_tui]) VALUES (4006, N'20520010', N'T004')
INSERT [dbo].[BAI_THI] ([so_phach], [so_bao_danh], [ma_tui]) VALUES (5001, N'20520001', N'T005')
INSERT [dbo].[BAI_THI] ([so_phach], [so_bao_danh], [ma_tui]) VALUES (5002, N'20520003', N'T005')
INSERT [dbo].[BAI_THI] ([so_phach], [so_bao_danh], [ma_tui]) VALUES (5003, N'20520004', N'T005')
INSERT [dbo].[BAI_THI] ([so_phach], [so_bao_danh], [ma_tui]) VALUES (5004, N'20520006', N'T005')
INSERT [dbo].[BAI_THI] ([so_phach], [so_bao_danh], [ma_tui]) VALUES (5005, N'20520008', N'T005')
GO

--TABLE KET_QUA_CHAM_THI
INSERT [dbo].[KET_QUA_CHAM_THI] ([so_phach], [diem_thi], [so_bao_danh], [ma_mon]) VALUES (1001, 8.75, N'20520001', 1)
INSERT [dbo].[KET_QUA_CHAM_THI] ([so_phach], [diem_thi], [so_bao_danh], [ma_mon]) VALUES (1002, 8.25, N'20520002', 1)
INSERT [dbo].[KET_QUA_CHAM_THI] ([so_phach], [diem_thi], [so_bao_danh], [ma_mon]) VALUES (1003, 8, N'20520003', 1)
INSERT [dbo].[KET_QUA_CHAM_THI] ([so_phach], [diem_thi], [so_bao_danh], [ma_mon]) VALUES (1004, 9, N'20520004', 1)
INSERT [dbo].[KET_QUA_CHAM_THI] ([so_phach], [diem_thi], [so_bao_danh], [ma_mon]) VALUES (1005, 9.25, N'20520005', 1)
INSERT [dbo].[KET_QUA_CHAM_THI] ([so_phach], [diem_thi], [so_bao_danh], [ma_mon]) VALUES (1006, 9.75, N'20520006', 1)
INSERT [dbo].[KET_QUA_CHAM_THI] ([so_phach], [diem_thi], [so_bao_danh], [ma_mon]) VALUES (1007, 7.75, N'20520007', 1)
INSERT [dbo].[KET_QUA_CHAM_THI] ([so_phach], [diem_thi], [so_bao_danh], [ma_mon]) VALUES (1008, 8.5, N'20520008', 1)
INSERT [dbo].[KET_QUA_CHAM_THI] ([so_phach], [diem_thi], [so_bao_danh], [ma_mon]) VALUES (1009, 9.5, N'20520009', 1)
INSERT [dbo].[KET_QUA_CHAM_THI] ([so_phach], [diem_thi], [so_bao_danh], [ma_mon]) VALUES (1010, 7.5, N'20520010', 1)
INSERT [dbo].[KET_QUA_CHAM_THI] ([so_phach], [diem_thi], [so_bao_danh], [ma_mon]) VALUES (2001, 7.5, N'20520005', 2)
INSERT [dbo].[KET_QUA_CHAM_THI] ([so_phach], [diem_thi], [so_bao_danh], [ma_mon]) VALUES (2002, 7.75, N'20520009', 2)
INSERT [dbo].[KET_QUA_CHAM_THI] ([so_phach], [diem_thi], [so_bao_danh], [ma_mon]) VALUES (3001, 8, N'20520002', 3)
INSERT [dbo].[KET_QUA_CHAM_THI] ([so_phach], [diem_thi], [so_bao_danh], [ma_mon]) VALUES (3002, 7, N'20520004', 3)
INSERT [dbo].[KET_QUA_CHAM_THI] ([so_phach], [diem_thi], [so_bao_danh], [ma_mon]) VALUES (3003, 6.75, N'20520005', 3)
INSERT [dbo].[KET_QUA_CHAM_THI] ([so_phach], [diem_thi], [so_bao_danh], [ma_mon]) VALUES (3004, 8.75, N'20520006', 3)
INSERT [dbo].[KET_QUA_CHAM_THI] ([so_phach], [diem_thi], [so_bao_danh], [ma_mon]) VALUES (3005, 7.5, N'20520007', 3)
INSERT [dbo].[KET_QUA_CHAM_THI] ([so_phach], [diem_thi], [so_bao_danh], [ma_mon]) VALUES (3006, 7.75, N'20520009', 3)
INSERT [dbo].[KET_QUA_CHAM_THI] ([so_phach], [diem_thi], [so_bao_danh], [ma_mon]) VALUES (3007, 9, N'20520010', 3)
INSERT [dbo].[KET_QUA_CHAM_THI] ([so_phach], [diem_thi], [so_bao_danh], [ma_mon]) VALUES (4001, 8, N'20520001', 4)
INSERT [dbo].[KET_QUA_CHAM_THI] ([so_phach], [diem_thi], [so_bao_danh], [ma_mon]) VALUES (4002, 9, N'20520002', 4)
INSERT [dbo].[KET_QUA_CHAM_THI] ([so_phach], [diem_thi], [so_bao_danh], [ma_mon]) VALUES (4003, 7, N'20520003', 4)
INSERT [dbo].[KET_QUA_CHAM_THI] ([so_phach], [diem_thi], [so_bao_danh], [ma_mon]) VALUES (4004, 8.25, N'20520007', 4)
INSERT [dbo].[KET_QUA_CHAM_THI] ([so_phach], [diem_thi], [so_bao_danh], [ma_mon]) VALUES (4005, 8.5, N'20520008', 4)
INSERT [dbo].[KET_QUA_CHAM_THI] ([so_phach], [diem_thi], [so_bao_danh], [ma_mon]) VALUES (4006, 8.75, N'20520010', 4)
INSERT [dbo].[KET_QUA_CHAM_THI] ([so_phach], [diem_thi], [so_bao_danh], [ma_mon]) VALUES (5001, 8, N'20520001', 5)
INSERT [dbo].[KET_QUA_CHAM_THI] ([so_phach], [diem_thi], [so_bao_danh], [ma_mon]) VALUES (5002, 8.25, N'20520003', 5)
INSERT [dbo].[KET_QUA_CHAM_THI] ([so_phach], [diem_thi], [so_bao_danh], [ma_mon]) VALUES (5003, 8.5, N'20520004', 5)
INSERT [dbo].[KET_QUA_CHAM_THI] ([so_phach], [diem_thi], [so_bao_danh], [ma_mon]) VALUES (5004, 8.75, N'20520006', 5)
INSERT [dbo].[KET_QUA_CHAM_THI] ([so_phach], [diem_thi], [so_bao_danh], [ma_mon]) VALUES (5005, 9, N'20520008', 5)
GO

--TABLE DIEM CHUAN
insert into DIEM_CHUAN values('7340122',22.75)
insert into DIEM_CHUAN values('7480101',21.75)
insert into DIEM_CHUAN values('7480102',23.75)
insert into DIEM_CHUAN values('7480103',19.75)
insert into DIEM_CHUAN values('7480104',23.75)
insert into DIEM_CHUAN values('7480106',20.75)
insert into DIEM_CHUAN values('7480109',23.75)
insert into DIEM_CHUAN values('7480201',23.75)
insert into DIEM_CHUAN values('7480202',23.75)
-- BẢNG XÉT XEM CÁC TÚI CHẤM CHI ĐÃ CHẤM HẾT CHƯA
-- MỖI LẦN ADMIN NHẤN NÚT CONFIRM THÌ SẼ CHUYỂN THÀNH TRUE NẾU TRUE HẾT THÌ SẼ CHO HIỂN THỊ BẢNG STATISTIC
create table confirmTui_Cham_Thi(
	ma_mon int,
	confirm varchar(7)
)
GO
insert into  confirmTui_Cham_Thi values(1,'false')
insert  confirmTui_Cham_Thi values(2,'false')
insert  confirmTui_Cham_Thi values(3,'false')
insert  confirmTui_Cham_Thi values(4,'false')
insert  confirmTui_Cham_Thi values(5,'false')
insert  confirmTui_Cham_Thi values(6,'false')
insert  confirmTui_Cham_Thi values(7,'false')
insert  confirmTui_Cham_Thi values(8,'false')
insert  confirmTui_Cham_Thi values(9,'false')
GO

-- BẢNG XÉT XEM AI ĐANG ĐĂNG NHẬP HỆ THỐNG
create table System_Login(
	permission varchar(10)
)
GO
--SET PERMISSION BAN ĐẦU LÀ NONE
-- SAU KHI LOGIN VỚI QUYỀN NÀO SẼ DC UPDATE LẠI VÀO DATABASE
insert into System_Login values('NONE')
GO
-- BẢNG XÉT XEM ĐÃ CONFIRM CÁI PHIẾU DKDT CHƯA, NẾU RỒI THÌ KHI ĐĂNG NHẬP SẼ CHO LUN VÀO GIAO DIỆN MAIN LUN
create table CONFIRM_REGISTER(
confirm varchar(20)
)
GO
insert into CONFIRM_REGISTER values('false')
GO
-- khi sửa bất kì giá trị nào trên PHIEU_DKDT thì các bảng THI_SINH, GIAY_BAO_THI,BAI_THI, KET_QUA_CHAM_THI sẽ thay đổi theo
CREATE TRIGGER TRIGGER_UPDATE_PHIEU_DKDT
ON PHIEU_DKDT FOR UPDATE
AS
	DECLARE  @before_HO_VA_TEN nvarchar(50), @before_NGAY_SINH smalldatetime
	DECLARE @HO_VA_TEN NVARCHAR(50),@HE_DAO_TAO NVARCHAR(3),@NAM_TOT_NGHIEP INT,@NGAY_SINH SMALLDATETIME,@NOI_SINH NVARCHAR(50),@DIA_CHI_BAO_TIN NVARCHAR(50)
	
	SELECT @HO_VA_TEN = ho_va_ten from inserted
	select @before_HO_VA_TEN = ho_va_ten from deleted

	select @NGAY_SINH = ngay_sinh from inserted
	select @before_NGAY_SINH = ngay_sinh from deleted

	select @NOI_SINH = noi_sinh from inserted
	select @HE_DAO_TAO = he_dao_tao from inserted
	select @NAM_TOT_NGHIEP = nam_tot_nghiep from inserted
	select @DIA_CHI_BAO_TIN = dia_chi_bao_tin from inserted

	update THI_SINH
	set ho_ten = @HO_VA_TEN , ngay_sinh= @NGAY_SINH, noi_sinh= @NOI_SINH, dia_chi_bao_tin= @DIA_CHI_BAO_TIN
	where ho_ten= @before_HO_VA_TEN and ngay_sinh= @before_NGAY_SINH
	print('change  THI_SINH')
GO

--Nếu lỡ bấm FINISH REGISTER thì EXCUTE lại dòng lại dòng này để tiếp tục nhập phiếu dkdt
update CONFIRM_REGISTER
set confirm='false'


