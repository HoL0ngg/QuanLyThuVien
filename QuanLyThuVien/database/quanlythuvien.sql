-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Máy chủ: 127.0.0.1
-- Thời gian đã tạo: Th12 04, 2025 lúc 07:32 AM
-- Phiên bản máy phục vụ: 10.4.32-MariaDB
-- Phiên bản PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Cơ sở dữ liệu: `qltv`
--

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `chucnang_nhomquyen`
--

CREATE TABLE `chucnang_nhomquyen` (
  `MaNhomQuyen` int(11) NOT NULL,
  `MaChucNang` int(11) NOT NULL,
  `HanhDong` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `chucnang_nhomquyen`
--

INSERT INTO `chucnang_nhomquyen` (`MaNhomQuyen`, `MaChucNang`, `HanhDong`) VALUES
(1, 1, 'THEM'),
(1, 1, 'XOA'),
(1, 1, 'SUA'),
(1, 1, 'XEM'),
(1, 2, 'THEM'),
(1, 2, 'XOA'),
(1, 2, 'SUA'),
(1, 2, 'XEM'),
(1, 3, 'THEM'),
(1, 3, 'XOA'),
(1, 3, 'SUA'),
(1, 3, 'XEM'),
(1, 4, 'THEM'),
(1, 4, 'XOA'),
(1, 4, 'SUA'),
(1, 4, 'XEM'),
(1, 5, 'THEM'),
(1, 5, 'XOA'),
(1, 5, 'SUA'),
(1, 5, 'XEM'),
(1, 6, 'THEM'),
(1, 6, 'XOA'),
(1, 6, 'SUA'),
(1, 6, 'XEM'),
(1, 7, 'THEM'),
(1, 7, 'XOA'),
(1, 7, 'SUA'),
(1, 7, 'XEM'),
(1, 8, 'THEM'),
(1, 8, 'XOA'),
(1, 8, 'SUA'),
(1, 8, 'XEM'),
(2, 1, 'THEM'),
(2, 1, 'XOA'),
(2, 1, 'SUA'),
(2, 1, 'XEM'),
(2, 2, 'THEM'),
(2, 2, 'XOA'),
(2, 2, 'SUA'),
(2, 2, 'XEM'),
(2, 3, 'THEM'),
(2, 3, 'XOA'),
(2, 3, 'SUA'),
(2, 3, 'XEM'),
(2, 4, 'THEM'),
(2, 4, 'XOA'),
(2, 4, 'SUA'),
(2, 4, 'XEM'),
(2, 5, 'THEM'),
(2, 5, 'XOA'),
(2, 5, 'SUA'),
(2, 5, 'XEM'),
(2, 6, 'THEM'),
(2, 6, 'XOA'),
(2, 6, 'SUA'),
(2, 6, 'XEM'),
(2, 7, 'THEM'),
(2, 7, 'XOA'),
(2, 7, 'SUA'),
(2, 7, 'XEM'),
(2, 8, 'THEM'),
(2, 8, 'XOA'),
(2, 8, 'SUA'),
(2, 8, 'XEM'),
(3, 1, 'THEM'),
(3, 1, 'XOA'),
(3, 1, 'SUA'),
(3, 1, 'XEM'),
(3, 2, 'THEM'),
(3, 2, 'XOA'),
(3, 2, 'SUA'),
(3, 2, 'XEM'),
(3, 3, 'THEM'),
(3, 3, 'XOA'),
(3, 3, 'SUA'),
(3, 3, 'XEM'),
(3, 4, 'THEM'),
(3, 4, 'XOA'),
(3, 4, 'SUA'),
(3, 4, 'XEM'),
(3, 5, 'THEM'),
(3, 5, 'XOA'),
(3, 5, 'SUA'),
(3, 5, 'XEM'),
(3, 6, 'THEM'),
(3, 6, 'XOA'),
(3, 6, 'SUA'),
(3, 6, 'XEM'),
(3, 7, 'THEM'),
(3, 7, 'XOA'),
(3, 7, 'SUA'),
(3, 7, 'XEM'),
(3, 8, 'THEM'),
(3, 8, 'XOA'),
(3, 8, 'SUA'),
(3, 8, 'XEM');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `chuc_nang`
--

CREATE TABLE `chuc_nang` (
  `MACN` int(11) NOT NULL,
  `TENCN` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `chuc_nang`
--

INSERT INTO `chuc_nang` (`MACN`, `TENCN`) VALUES
(1, 'Nhân Viên'),
(2, 'Phiếu Mượn'),
(3, 'Phiếu Nhập'),
(4, 'Phiếu Trả'),
(5, 'Phiếu Phạt'),
(6, 'Đầu Sách'),
(7, 'Độc Giả'),
(8, 'Thống Kê');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `ctphieu_muon`
--

CREATE TABLE `ctphieu_muon` (
  `MaPhieuMuon` int(11) NOT NULL,
  `MaSach` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `ctphieu_muon`
--

INSERT INTO `ctphieu_muon` (`MaPhieuMuon`, `MaSach`) VALUES
(1, 1),
(1, 2),
(2, 3),
(3, 4),
(3, 5),
(3, 6),
(4, 7),
(5, 8),
(5, 9),
(6, 10),
(7, 1),
(7, 3),
(8, 2),
(9, 4),
(9, 6),
(9, 8),
(10, 5),
(10, 7);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `ctphieu_nhap`
--

CREATE TABLE `ctphieu_nhap` (
  `MaPhieuNhap` int(11) NOT NULL,
  `MaDauSach` int(11) NOT NULL,
  `SoLuong` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `ctphieu_phat`
--

CREATE TABLE `ctphieu_phat` (
  `TienPhat` int(11) NOT NULL,
  `MaSach` int(11) NOT NULL,
  `MaPhieuPhat` int(11) NOT NULL,
  `MaCTPhieuPhat` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `ctphieu_phat`
--

INSERT INTO `ctphieu_phat` (`TienPhat`, `MaSach`, `MaPhieuPhat`, `MaCTPhieuPhat`) VALUES
(5000, 3, 2, 2),
(0, 4, 3, 3),
(0, 10, 6, 6),
(0, 1, 7, 7),
(5000, 2, 8, 8),
(10000, 5, 29, 11),
(10000, 4, 30, 12),
(10000, 8, 31, 13),
(60000, 7, 32, 14);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `ctphieu_tra`
--

CREATE TABLE `ctphieu_tra` (
  `MaCTPhieuTra` int(11) NOT NULL,
  `TrangThai` int(11) NOT NULL,
  `MaPhieuTra` int(11) NOT NULL,
  `MaSach` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `ctphieu_tra`
--

INSERT INTO `ctphieu_tra` (`MaCTPhieuTra`, `TrangThai`, `MaPhieuTra`, `MaSach`) VALUES
(1, 1, 1, 1),
(2, 2, 2, 3),
(3, 1, 3, 4),
(4, 2, 4, 7),
(5, 3, 5, 8),
(6, 1, 6, 10),
(7, 1, 7, 1),
(8, 2, 8, 2),
(9, 1, 9, 4),
(10, 4, 10, 5);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `ctthe_loai`
--

CREATE TABLE `ctthe_loai` (
  `MaTheLoai` int(11) NOT NULL,
  `TenTheLoai` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `ctthe_loai`
--

INSERT INTO `ctthe_loai` (`MaTheLoai`, `TenTheLoai`) VALUES
(1, 'Văn học'),
(2, 'Tiểu thuyết'),
(3, 'Truyện tranh'),
(4, 'Thiếu nhi'),
(5, 'Khoa học'),
(6, 'Công nghệ thông tin'),
(7, 'Kinh tế'),
(8, 'Kỹ năng sống'),
(9, 'Tâm lý học'),
(10, 'Lịch sử'),
(11, 'Địa lý'),
(12, 'Ngoại ngữ'),
(13, 'Pháp luật'),
(14, 'Khoa học viễn tưởng');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `dau_sach`
--

CREATE TABLE `dau_sach` (
  `MaDauSach` int(11) NOT NULL,
  `TenDauSach` varchar(100) NOT NULL,
  `HinhAnh` varchar(200) NOT NULL,
  `NhaXuatBan` varchar(100) NOT NULL,
  `NamXuatBan` varchar(100) NOT NULL,
  `NgonNgu` varchar(100) NOT NULL,
  `SoLuong` int(11) NOT NULL,
  `Gia` int(11) DEFAULT NULL,
  `TrangThai` tinyint(1) NOT NULL DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `dau_sach`
--

INSERT INTO `dau_sach` (`MaDauSach`, `TenDauSach`, `HinhAnh`, `NhaXuatBan`, `NamXuatBan`, `NgonNgu`, `SoLuong`, `Gia`, `TrangThai`) VALUES
(1, 'Tuổi Thơ Dữ Dội', 'tuoithodu_doi.jpg', '1', '1988', 'Tiếng Việt', 50, NULL, 1),
(2, 'Doraemon - Tập 1', 'doraemon_tap1.jpg', '1', '1992', 'Tiếng Việt', 120, NULL, 1),
(3, 'Harry Potter và Hòn Đá Phù Thủy', 'hp1.jpg', '2', '1997', 'Tiếng Anh', 80, NULL, 1),
(4, 'Nhà Giả Kim', 'nha_gia_kim.jpg', '3', '1988', 'Tiếng Việt', 60, NULL, 1),
(5, 'Đắc Nhân Tâm', 'dac_nhan_tam.jpg', '4', '1936', 'Tiếng Việt', 100, NULL, 1),
(6, 'Chí Phèo', 'chi_pheo.jpg', '3', '1941', 'Tiếng Việt', 40, NULL, 1),
(7, 'Sherlock Holmes - Tập 1', 'sherlock1.jpg', '5', '1892', 'Tiếng Anh', 55, NULL, 1),
(8, 'Không Gia Đình', 'khong_gia_dinh.jpg', '1', '1878', 'Tiếng Việt', 70, NULL, 1),
(9, 'One Piece - Tập 1', 'onepiece_tap1.jpg', '1', '1997', 'Tiếng Việt', 150, NULL, 1),
(10, 'Around the World in 80 Days', 'around80days.jpg', '6', '1873', 'Tiếng Anh', 30, NULL, 1);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `doc_gia`
--

CREATE TABLE `doc_gia` (
  `MADG` int(11) NOT NULL,
  `TENDG` varchar(100) NOT NULL,
  `SDT` varchar(15) NOT NULL,
  `DIACHI` varchar(150) NOT NULL,
  `TRANGTHAI` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `doc_gia`
--

INSERT INTO `doc_gia` (`MADG`, `TENDG`, `SDT`, `DIACHI`, `TRANGTHAI`) VALUES
(1, 'Nguyễn Văn An', '0912345678', 'Quận 1, TP. HCM', 1),
(2, 'Trần Thị Bình', '0987654321', 'Quận Bình Thạnh, TP. HCM', 1),
(3, 'Lê Hoàng Minh', '0901122334', 'Quận 3, TP. HCM', 1),
(4, 'Phạm Ngọc Hân', '0933445566', 'Quận 7, TP. HCM', 1),
(5, 'Đỗ Thanh Tú', '0967788990', 'Quận 5, TP. HCM', 1),
(6, 'Võ Thị Lan', '0978899001', 'Quận Tân Bình, TP. HCM', 1),
(7, 'Huỳnh Đức Thịnh', '0922334455', 'Quận 10, TP. HCM', 1),
(8, 'Bùi Gia Huy', '0945566778', 'Quận Phú Nhuận, TP. HCM', 1),
(9, 'Phan Minh Nhật', '0956677889', 'TP. Thủ Đức, TP. HCM', 1),
(10, 'Tạ Thu Trang', '0933221100', 'Quận Gò Vấp, TP. HCM', 1);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `nhan_vien`
--

CREATE TABLE `nhan_vien` (
  `MANV` int(11) NOT NULL,
  `TENNV` varchar(100) NOT NULL,
  `GIOITINH` tinyint(1) NOT NULL,
  `NGAYSINH` date NOT NULL,
  `SDT` varchar(100) NOT NULL,
  `TenDangNhap` varchar(100) NOT NULL,
  `MatKhau` varchar(100) NOT NULL,
  `TrangThai` int(11) NOT NULL,
  `Email` varchar(100) DEFAULT NULL,
  `MaNhomQuyen` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `nhan_vien`
--

INSERT INTO `nhan_vien` (`MANV`, `TENNV`, `GIOITINH`, `NGAYSINH`, `SDT`, `TenDangNhap`, `MatKhau`, `TrangThai`, `Email`, `MaNhomQuyen`) VALUES
(1, 'Lê Quang Hoàng', 1, '2005-08-23', '0364722740', 'ad', '1', 1, 'admin@library.com', 1),
(2, 'Trần Thị B', 0, '1995-09-20', '0987654321', 'thuthu', 'thuthu123', 1, 'thuthu@library.com', 2),
(3, 'Phạm Hữu C', 1, '1990-02-15', '0909123123', 'qlkho', 'qlkho123', 1, 'quanlykho@library.com', 3);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `nha_cung_cap`
--

CREATE TABLE `nha_cung_cap` (
  `MANCC` int(11) NOT NULL,
  `TENNCC` varchar(100) NOT NULL,
  `DIACHI` varchar(100) NOT NULL,
  `EMAIL` varchar(100) NOT NULL,
  `SDT` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `nha_cung_cap`
--

INSERT INTO `nha_cung_cap` (`MANCC`, `TENNCC`, `DIACHI`, `EMAIL`, `SDT`) VALUES
(1, 'Công ty Sách Việt', 'Quận 1, TP. HCM', 'contact@sachviet.com', '0901112233'),
(2, 'Nhà Xuất Bản Trẻ', 'Quận 3, TP. HCM', 'info@nxbtre.vn', '0902223344'),
(3, 'Công ty Phát Hành Sách Minh Long', 'Quận Bình Thạnh, TP. HCM', 'minhlong@sach.com', '0903334455'),
(4, 'Nhà Sách Fahasa', 'Quận 5, TP. HCM', 'support@fahasa.vn', '0904445566'),
(5, 'Nhà Sách Phương Nam', 'Quận 10, TP. HCM', 'pnbook@pncom.vn', '0905556677'),
(6, 'Công ty Sách Alpha', 'TP. Thủ Đức, TP. HCM', 'alpha@alphabooks.vn', '0906667788'),
(7, 'Công ty Văn Hóa Đông A', 'Quận Tân Bình, TP. HCM', 'dongA@vanhoa.vn', '0907778899'),
(8, 'Nhà Sách Tiến Thọ', 'Quận Gò Vấp, TP. HCM', 'tientho@bookstore.vn', '0908889900'),
(9, 'Công ty Sách Nhã Nam', 'Quận Phú Nhuận, TP. HCM', 'info@nhanam.vn', '0909990011'),
(10, 'Công ty Kim Đồng', 'Quận 4, TP. HCM', 'kimdong@kimdong.vn', '0901234567');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `nha_xuat_ban`
--

CREATE TABLE `nha_xuat_ban` (
  `MaNXB` int(11) NOT NULL,
  `TenNXB` varchar(100) NOT NULL,
  `Status` int(11) NOT NULL DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `nha_xuat_ban`
--

INSERT INTO `nha_xuat_ban` (`MaNXB`, `TenNXB`, `Status`) VALUES
(1, 'Nhà Xuất Bản Trẻ', 1),
(2, 'Bloomsbury Publishing', 1),
(3, 'Nhà Xuất Bản Văn Học', 1),
(4, 'Nhà Xuất Bản Đắc Nhân Tâm', 1),
(5, 'Penguin Random House', 1),
(6, 'Nhà Xuất Bản Kim Đồng', 1);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `nhom_quyen`
--

CREATE TABLE `nhom_quyen` (
  `MANQ` int(11) NOT NULL,
  `TENNQ` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `nhom_quyen`
--

INSERT INTO `nhom_quyen` (`MANQ`, `TENNQ`) VALUES
(1, 'Admin'),
(2, 'Thủ thư'),
(3, 'Quản lý kho');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `phieu_muon`
--

CREATE TABLE `phieu_muon` (
  `MaPhieuMuon` int(11) NOT NULL,
  `NgayMuon` date NOT NULL,
  `NgayTraDuKien` date NOT NULL,
  `trangthai` int(11) NOT NULL,
  `MaDocGia` int(11) NOT NULL,
  `MaNhanVien` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `phieu_muon`
--

INSERT INTO `phieu_muon` (`MaPhieuMuon`, `NgayMuon`, `NgayTraDuKien`, `trangthai`, `MaDocGia`, `MaNhanVien`) VALUES
(1, '2025-01-05', '2025-01-12', 1, 1, 2),
(2, '2025-01-07', '2025-01-14', 1, 2, 2),
(3, '2025-01-08', '2025-01-15', 2, 3, 2),
(4, '2025-01-10', '2025-01-17', 1, 4, 2),
(5, '2025-01-11', '2025-01-18', 3, 5, 2),
(6, '2025-01-12', '2025-01-19', 1, 6, 2),
(7, '2025-01-14', '2025-01-21', 2, 7, 2),
(8, '2025-01-15', '2025-01-22', 1, 8, 2),
(9, '2025-01-16', '2025-01-23', 3, 9, 2),
(10, '2025-01-17', '2025-01-24', 1, 10, 2);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `phieu_nhap`
--

CREATE TABLE `phieu_nhap` (
  `MaPhieuNhap` int(11) NOT NULL,
  `ThoiGian` date NOT NULL,
  `MaNV` int(11) NOT NULL,
  `MaNCC` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `phieu_phat`
--

CREATE TABLE `phieu_phat` (
  `MaPhieuPhat` int(11) NOT NULL,
  `NgayPhat` date NOT NULL,
  `TrangThai` int(11) NOT NULL,
  `MaCTPhieuTra` int(11) NOT NULL,
  `Ngaytra` date DEFAULT NULL,
  `MaDG` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `phieu_phat`
--

INSERT INTO `phieu_phat` (`MaPhieuPhat`, `NgayPhat`, `TrangThai`, `MaCTPhieuTra`, `Ngaytra`, `MaDG`) VALUES
(2, '2025-01-15', 1, 2, '2025-01-16', 2),
(3, '2025-01-16', 1, 3, '2025-01-16', 3),
(6, '2025-01-19', 1, 6, '2025-01-19', 6),
(7, '2025-01-22', 1, 7, '2025-01-22', 7),
(8, '2025-01-23', 1, 8, '2025-01-24', 8),
(29, '2025-11-28', 1, 10, '2025-01-26', 10),
(30, '2025-11-28', 1, 9, '2025-01-25', 9),
(31, '2025-11-28', 0, 5, '2025-01-20', 5),
(32, '2025-11-28', 0, 4, '2025-01-19', 4);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `phieu_tra`
--

CREATE TABLE `phieu_tra` (
  `MaPhieuTra` int(11) NOT NULL,
  `NgayTra` date NOT NULL,
  `MaDG` int(11) NOT NULL,
  `MaNV` int(11) NOT NULL,
  `MaPhieuMuon` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `phieu_tra`
--

INSERT INTO `phieu_tra` (`MaPhieuTra`, `NgayTra`, `MaDG`, `MaNV`, `MaPhieuMuon`) VALUES
(1, '2025-01-12', 1, 1, 1),
(2, '2025-01-15', 2, 2, 2),
(3, '2025-01-16', 3, 1, 3),
(4, '2025-01-19', 4, 3, 4),
(5, '2025-01-20', 5, 2, 5),
(6, '2025-01-19', 6, 1, 6),
(7, '2025-01-22', 7, 3, 7),
(8, '2025-01-23', 8, 1, 8),
(9, '2025-01-25', 9, 2, 9),
(10, '2025-01-26', 10, 3, 10);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `sach`
--

CREATE TABLE `sach` (
  `MaSach` int(11) NOT NULL,
  `trangthai` int(11) NOT NULL,
  `MaDauSach` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `sach`
--

INSERT INTO `sach` (`MaSach`, `trangthai`, `MaDauSach`) VALUES
(1, 1, 1),
(2, 1, 2),
(3, 1, 3),
(4, 1, 4),
(5, 1, 5),
(6, 1, 6),
(7, 1, 7),
(8, 1, 8),
(9, 1, 9),
(10, 1, 10);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `tacgia_dausach`
--

CREATE TABLE `tacgia_dausach` (
  `MaTacGia` int(11) NOT NULL,
  `MaDauSach` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `tacgia_dausach`
--

INSERT INTO `tacgia_dausach` (`MaTacGia`, `MaDauSach`) VALUES
(1, 1),
(2, 1),
(2, 2),
(3, 6),
(4, 8),
(5, 3),
(7, 7),
(10, 10);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `tac_gia`
--

CREATE TABLE `tac_gia` (
  `MaTacGia` int(11) NOT NULL,
  `TenTacGia` varchar(100) NOT NULL,
  `NamSinh` date NOT NULL,
  `QuocTich` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `tac_gia`
--

INSERT INTO `tac_gia` (`MaTacGia`, `TenTacGia`, `NamSinh`, `QuocTich`) VALUES
(1, 'Nguyễn Nhật Ánh', '1955-05-07', 'Việt Nam'),
(2, 'Tô Hoài', '1920-09-27', 'Việt Nam'),
(3, 'Nam Cao', '1915-10-29', 'Việt Nam'),
(4, 'Victor Hugo', '1802-02-26', 'Pháp'),
(5, 'J.K. Rowling', '1965-07-31', 'Anh'),
(6, 'Haruki Murakami', '1949-01-12', 'Nhật Bản'),
(7, 'George Orwell', '1903-06-25', 'Anh'),
(8, 'Ernest Hemingway', '1899-07-21', 'Mỹ'),
(9, 'Paulo Coelho', '1947-08-24', 'Brazil'),
(10, 'Lev Tolstoy', '1828-09-09', 'Nga');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `the_loai`
--

CREATE TABLE `the_loai` (
  `MaDauSach` int(11) NOT NULL,
  `MaTheLoai` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `the_loai`
--

INSERT INTO `the_loai` (`MaDauSach`, `MaTheLoai`) VALUES
(1, 1),
(1, 4),
(2, 3),
(2, 4),
(3, 2),
(3, 14),
(4, 1),
(4, 2),
(5, 7),
(5, 8),
(6, 1),
(7, 1),
(7, 2),
(8, 1),
(8, 4),
(9, 3),
(10, 1),
(10, 12);

--
-- Chỉ mục cho các bảng đã đổ
--

--
-- Chỉ mục cho bảng `chucnang_nhomquyen`
--
ALTER TABLE `chucnang_nhomquyen`
  ADD KEY `chucnang_nhomquyen_ibfk_1` (`MaChucNang`),
  ADD KEY `chucnang_nhomquyen_ibfk_2` (`MaNhomQuyen`);

--
-- Chỉ mục cho bảng `chuc_nang`
--
ALTER TABLE `chuc_nang`
  ADD PRIMARY KEY (`MACN`);

--
-- Chỉ mục cho bảng `ctphieu_muon`
--
ALTER TABLE `ctphieu_muon`
  ADD PRIMARY KEY (`MaPhieuMuon`,`MaSach`),
  ADD KEY `MaSach` (`MaSach`);

--
-- Chỉ mục cho bảng `ctphieu_nhap`
--
ALTER TABLE `ctphieu_nhap`
  ADD PRIMARY KEY (`MaPhieuNhap`,`MaDauSach`),
  ADD KEY `MaDauSach` (`MaDauSach`);

--
-- Chỉ mục cho bảng `ctphieu_phat`
--
ALTER TABLE `ctphieu_phat`
  ADD PRIMARY KEY (`MaCTPhieuPhat`),
  ADD KEY `MaPhieuPhat` (`MaPhieuPhat`),
  ADD KEY `MaSach` (`MaSach`);

--
-- Chỉ mục cho bảng `ctphieu_tra`
--
ALTER TABLE `ctphieu_tra`
  ADD PRIMARY KEY (`MaCTPhieuTra`),
  ADD KEY `fk_maPhieuTra_idx` (`MaPhieuTra`);

--
-- Chỉ mục cho bảng `ctthe_loai`
--
ALTER TABLE `ctthe_loai`
  ADD PRIMARY KEY (`MaTheLoai`);

--
-- Chỉ mục cho bảng `dau_sach`
--
ALTER TABLE `dau_sach`
  ADD PRIMARY KEY (`MaDauSach`);

--
-- Chỉ mục cho bảng `doc_gia`
--
ALTER TABLE `doc_gia`
  ADD PRIMARY KEY (`MADG`);

--
-- Chỉ mục cho bảng `nhan_vien`
--
ALTER TABLE `nhan_vien`
  ADD PRIMARY KEY (`MANV`),
  ADD UNIQUE KEY `SDT` (`SDT`),
  ADD UNIQUE KEY `TenDangNhap_UNIQUE` (`TenDangNhap`),
  ADD KEY `abc_idx` (`MaNhomQuyen`),
  MODIFY `MANV` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Chỉ mục cho bảng `nha_cung_cap`
--
ALTER TABLE `nha_cung_cap`
  ADD PRIMARY KEY (`MANCC`),
  ADD UNIQUE KEY `EMAIL` (`EMAIL`),
  ADD UNIQUE KEY `SDT` (`SDT`);

--
-- Chỉ mục cho bảng `nha_xuat_ban`
--
ALTER TABLE `nha_xuat_ban`
  ADD PRIMARY KEY (`MaNXB`);

--
-- Chỉ mục cho bảng `nhom_quyen`
--
ALTER TABLE `nhom_quyen`
  ADD PRIMARY KEY (`MANQ`),
  MODIFY `MANQ` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Chỉ mục cho bảng `phieu_muon`
--
ALTER TABLE `phieu_muon`
  ADD PRIMARY KEY (`MaPhieuMuon`),
  ADD KEY `MaNhanVien` (`MaNhanVien`),
  ADD KEY `MaDocGia` (`MaDocGia`);

--
-- Chỉ mục cho bảng `phieu_nhap`
--
ALTER TABLE `phieu_nhap`
  ADD PRIMARY KEY (`MaPhieuNhap`),
  ADD KEY `MaNCC` (`MaNCC`),
  ADD KEY `MaNV` (`MaNV`);

--
-- Chỉ mục cho bảng `phieu_phat`
--
ALTER TABLE `phieu_phat`
  ADD PRIMARY KEY (`MaPhieuPhat`),
  ADD KEY `MaCTPhieuTra` (`MaCTPhieuTra`),
  ADD KEY `MaDG` (`MaDG`);

--
-- Chỉ mục cho bảng `phieu_tra`
--
ALTER TABLE `phieu_tra`
  ADD PRIMARY KEY (`MaPhieuTra`),
  ADD KEY `MaNV` (`MaNV`),
  ADD KEY `MaPhieuMuon` (`MaPhieuMuon`),
  ADD KEY `MaDG` (`MaDG`);

--
-- Chỉ mục cho bảng `sach`
--
ALTER TABLE `sach`
  ADD PRIMARY KEY (`MaSach`),
  ADD KEY `MaDauSach` (`MaDauSach`);

--
-- Chỉ mục cho bảng `tacgia_dausach`
--
ALTER TABLE `tacgia_dausach`
  ADD PRIMARY KEY (`MaTacGia`,`MaDauSach`),
  ADD KEY `MaDauSach` (`MaDauSach`);

--
-- Chỉ mục cho bảng `tac_gia`
--
ALTER TABLE `tac_gia`
  ADD PRIMARY KEY (`MaTacGia`);

--
-- Chỉ mục cho bảng `the_loai`
--
ALTER TABLE `the_loai`
  ADD PRIMARY KEY (`MaDauSach`,`MaTheLoai`),
  ADD KEY `MaTheLoai` (`MaTheLoai`);

--
-- AUTO_INCREMENT cho các bảng đã đổ
--

--
-- AUTO_INCREMENT cho bảng `chuc_nang`
--
ALTER TABLE `chuc_nang`
  MODIFY `MACN` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT cho bảng `ctphieu_muon`
--
ALTER TABLE `ctphieu_muon`
  MODIFY `MaPhieuMuon` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT cho bảng `ctphieu_phat`
--
ALTER TABLE `ctphieu_phat`
  MODIFY `MaCTPhieuPhat` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT cho bảng `ctphieu_tra`
--
ALTER TABLE `ctphieu_tra`
  MODIFY `MaCTPhieuTra` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT cho bảng `ctthe_loai`
--
ALTER TABLE `ctthe_loai`
  MODIFY `MaTheLoai` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT cho bảng `dau_sach`
--
ALTER TABLE `dau_sach`
  MODIFY `MaDauSach` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT cho bảng `doc_gia`
--
ALTER TABLE `doc_gia`
  MODIFY `MADG` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT cho bảng `nha_cung_cap`
--
ALTER TABLE `nha_cung_cap`
  MODIFY `MANCC` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT cho bảng `nha_xuat_ban`
--
ALTER TABLE `nha_xuat_ban`
  MODIFY `MaNXB` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT cho bảng `phieu_muon`
--
ALTER TABLE `phieu_muon`
  MODIFY `MaPhieuMuon` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT cho bảng `phieu_phat`
--
ALTER TABLE `phieu_phat`
  MODIFY `MaPhieuPhat` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=33;

--
-- AUTO_INCREMENT cho bảng `phieu_tra`
--
ALTER TABLE `phieu_tra`
  MODIFY `MaPhieuTra` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT cho bảng `sach`
--
ALTER TABLE `sach`
  MODIFY `MaSach` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT cho bảng `tac_gia`
--
ALTER TABLE `tac_gia`
  MODIFY `MaTacGia` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- Các ràng buộc cho các bảng đã đổ
--

--
-- Các ràng buộc cho bảng `chucnang_nhomquyen`
--
ALTER TABLE `chucnang_nhomquyen`
  ADD CONSTRAINT `chucnang_nhomquyen_ibfk_1` FOREIGN KEY (`MaChucNang`) REFERENCES `chuc_nang` (`MACN`),
  ADD CONSTRAINT `chucnang_nhomquyen_ibfk_2` FOREIGN KEY (`MaNhomQuyen`) REFERENCES `nhom_quyen` (`MANQ`);

--
-- Các ràng buộc cho bảng `ctphieu_muon`
--
ALTER TABLE `ctphieu_muon`
  ADD CONSTRAINT `ctphieu_muon_ibfk_1` FOREIGN KEY (`MaPhieuMuon`) REFERENCES `phieu_muon` (`MaPhieuMuon`),
  ADD CONSTRAINT `ctphieu_muon_ibfk_2` FOREIGN KEY (`MaSach`) REFERENCES `sach` (`MaSach`);

--
-- Các ràng buộc cho bảng `ctphieu_nhap`
--
ALTER TABLE `ctphieu_nhap`
  ADD CONSTRAINT `ctphieu_nhap_ibfk_1` FOREIGN KEY (`MaDauSach`) REFERENCES `dau_sach` (`MaDauSach`),
  ADD CONSTRAINT `ctphieu_nhap_ibfk_2` FOREIGN KEY (`MaPhieuNhap`) REFERENCES `phieu_nhap` (`MaPhieuNhap`);

--
-- Các ràng buộc cho bảng `ctphieu_phat`
--
ALTER TABLE `ctphieu_phat`
  ADD CONSTRAINT `ctphieu_phat_ibfk_1` FOREIGN KEY (`MaPhieuPhat`) REFERENCES `phieu_phat` (`MaPhieuPhat`),
  ADD CONSTRAINT `ctphieu_phat_ibfk_2` FOREIGN KEY (`MaSach`) REFERENCES `sach` (`MaSach`);

--
-- Các ràng buộc cho bảng `ctphieu_tra`
--
ALTER TABLE `ctphieu_tra`
  ADD CONSTRAINT `fk_maPhieuTra` FOREIGN KEY (`MaPhieuTra`) REFERENCES `phieu_tra` (`MaPhieuTra`);

--
-- Các ràng buộc cho bảng `nhan_vien`
--
ALTER TABLE `nhan_vien`
  ADD CONSTRAINT `fk_maNhomQuyen` FOREIGN KEY (`MaNhomQuyen`) REFERENCES `nhom_quyen` (`MANQ`);

--
-- Các ràng buộc cho bảng `phieu_muon`
--
ALTER TABLE `phieu_muon`
  ADD CONSTRAINT `phieu_muon_ibfk_1` FOREIGN KEY (`MaNhanVien`) REFERENCES `nhan_vien` (`MANV`),
  ADD CONSTRAINT `phieu_muon_ibfk_2` FOREIGN KEY (`MaDocGia`) REFERENCES `doc_gia` (`MADG`);

--
-- Các ràng buộc cho bảng `phieu_nhap`
--
ALTER TABLE `phieu_nhap`
  ADD CONSTRAINT `phieu_nhap_ibfk_1` FOREIGN KEY (`MaNCC`) REFERENCES `nha_cung_cap` (`MANCC`),
  ADD CONSTRAINT `phieu_nhap_ibfk_2` FOREIGN KEY (`MaNV`) REFERENCES `nhan_vien` (`MANV`);

--
-- Các ràng buộc cho bảng `phieu_phat`
--
ALTER TABLE `phieu_phat`
  ADD CONSTRAINT `phieu_phat_ibfk_2` FOREIGN KEY (`MaCTPhieuTra`) REFERENCES `ctphieu_tra` (`MaCTPhieuTra`),
  ADD CONSTRAINT `phieu_phat_ibfk_3` FOREIGN KEY (`MaDG`) REFERENCES `doc_gia` (`MADG`);

--
-- Các ràng buộc cho bảng `phieu_tra`
--
ALTER TABLE `phieu_tra`
  ADD CONSTRAINT `phieu_tra_ibfk_1` FOREIGN KEY (`MaNV`) REFERENCES `nhan_vien` (`MANV`),
  ADD CONSTRAINT `phieu_tra_ibfk_3` FOREIGN KEY (`MaPhieuMuon`) REFERENCES `phieu_muon` (`MaPhieuMuon`),
  ADD CONSTRAINT `phieu_tra_ibfk_4` FOREIGN KEY (`MaDG`) REFERENCES `doc_gia` (`MADG`);

--
-- Các ràng buộc cho bảng `sach`
--
ALTER TABLE `sach`
  ADD CONSTRAINT `sach_ibfk_1` FOREIGN KEY (`MaDauSach`) REFERENCES `dau_sach` (`MaDauSach`);

--
-- Các ràng buộc cho bảng `tacgia_dausach`
--
ALTER TABLE `tacgia_dausach`
  ADD CONSTRAINT `tacgia_dausach_ibfk_1` FOREIGN KEY (`MaDauSach`) REFERENCES `dau_sach` (`MaDauSach`),
  ADD CONSTRAINT `tacgia_dausach_ibfk_2` FOREIGN KEY (`MaTacGia`) REFERENCES `tac_gia` (`MaTacGia`);

--
-- Các ràng buộc cho bảng `the_loai`
--
ALTER TABLE `the_loai`
  ADD CONSTRAINT `the_loai_ibfk_1` FOREIGN KEY (`MaDauSach`) REFERENCES `dau_sach` (`MaDauSach`),
  ADD CONSTRAINT `the_loai_ibfk_2` FOREIGN KEY (`MaTheLoai`) REFERENCES `ctthe_loai` (`MaTheLoai`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
