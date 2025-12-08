-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 08, 2025 at 06:06 AM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `phpmyadmin`
--
CREATE DATABASE IF NOT EXISTS `phpmyadmin` DEFAULT CHARACTER SET utf8 COLLATE utf8_bin;
USE `phpmyadmin`;

-- --------------------------------------------------------

--
-- Table structure for table `pma__bookmark`
--

CREATE TABLE `pma__bookmark` (
  `id` int(10) UNSIGNED NOT NULL,
  `dbase` varchar(255) NOT NULL DEFAULT '',
  `user` varchar(255) NOT NULL DEFAULT '',
  `label` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `query` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='Bookmarks';

-- --------------------------------------------------------

--
-- Table structure for table `pma__central_columns`
--

CREATE TABLE `pma__central_columns` (
  `db_name` varchar(64) NOT NULL,
  `col_name` varchar(64) NOT NULL,
  `col_type` varchar(64) NOT NULL,
  `col_length` text DEFAULT NULL,
  `col_collation` varchar(64) NOT NULL,
  `col_isNull` tinyint(1) NOT NULL,
  `col_extra` varchar(255) DEFAULT '',
  `col_default` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='Central list of columns';

-- --------------------------------------------------------

--
-- Table structure for table `pma__column_info`
--

CREATE TABLE `pma__column_info` (
  `id` int(5) UNSIGNED NOT NULL,
  `db_name` varchar(64) NOT NULL DEFAULT '',
  `table_name` varchar(64) NOT NULL DEFAULT '',
  `column_name` varchar(64) NOT NULL DEFAULT '',
  `comment` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `mimetype` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `transformation` varchar(255) NOT NULL DEFAULT '',
  `transformation_options` varchar(255) NOT NULL DEFAULT '',
  `input_transformation` varchar(255) NOT NULL DEFAULT '',
  `input_transformation_options` varchar(255) NOT NULL DEFAULT ''
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='Column information for phpMyAdmin';

-- --------------------------------------------------------

--
-- Table structure for table `pma__designer_settings`
--

CREATE TABLE `pma__designer_settings` (
  `username` varchar(64) NOT NULL,
  `settings_data` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='Settings related to Designer';

-- --------------------------------------------------------

--
-- Table structure for table `pma__export_templates`
--

CREATE TABLE `pma__export_templates` (
  `id` int(5) UNSIGNED NOT NULL,
  `username` varchar(64) NOT NULL,
  `export_type` varchar(10) NOT NULL,
  `template_name` varchar(64) NOT NULL,
  `template_data` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='Saved export templates';

-- --------------------------------------------------------

--
-- Table structure for table `pma__favorite`
--

CREATE TABLE `pma__favorite` (
  `username` varchar(64) NOT NULL,
  `tables` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='Favorite tables';

-- --------------------------------------------------------

--
-- Table structure for table `pma__history`
--

CREATE TABLE `pma__history` (
  `id` bigint(20) UNSIGNED NOT NULL,
  `username` varchar(64) NOT NULL DEFAULT '',
  `db` varchar(64) NOT NULL DEFAULT '',
  `table` varchar(64) NOT NULL DEFAULT '',
  `timevalue` timestamp NOT NULL DEFAULT current_timestamp(),
  `sqlquery` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='SQL history for phpMyAdmin';

-- --------------------------------------------------------

--
-- Table structure for table `pma__navigationhiding`
--

CREATE TABLE `pma__navigationhiding` (
  `username` varchar(64) NOT NULL,
  `item_name` varchar(64) NOT NULL,
  `item_type` varchar(64) NOT NULL,
  `db_name` varchar(64) NOT NULL,
  `table_name` varchar(64) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='Hidden items of navigation tree';

-- --------------------------------------------------------

--
-- Table structure for table `pma__pdf_pages`
--

CREATE TABLE `pma__pdf_pages` (
  `db_name` varchar(64) NOT NULL DEFAULT '',
  `page_nr` int(10) UNSIGNED NOT NULL,
  `page_descr` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT ''
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='PDF relation pages for phpMyAdmin';

-- --------------------------------------------------------

--
-- Table structure for table `pma__recent`
--

CREATE TABLE `pma__recent` (
  `username` varchar(64) NOT NULL,
  `tables` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='Recently accessed tables';

--
-- Dumping data for table `pma__recent`
--

INSERT INTO `pma__recent` (`username`, `tables`) VALUES
('root', '[{\"db\":\"qlchxm\",\"table\":\"hoadon\"},{\"db\":\"quanlythuvien\",\"table\":\"phieu_phat\"},{\"db\":\"quanlythuvien\",\"table\":\"ctphieu_tra\"},{\"db\":\"quanlythuvien\",\"table\":\"phieu_tra\"},{\"db\":\"quanlythuvien\",\"table\":\"doc_gia\"},{\"db\":\"quanlythuvien\",\"table\":\"ctphieu_phat\"},{\"db\":\"quanlythuvien\",\"table\":\"chucnang_nhomquyen\"},{\"db\":\"quanlythuvien\",\"table\":\"ctphieu_nhap\"}]');

-- --------------------------------------------------------

--
-- Table structure for table `pma__relation`
--

CREATE TABLE `pma__relation` (
  `master_db` varchar(64) NOT NULL DEFAULT '',
  `master_table` varchar(64) NOT NULL DEFAULT '',
  `master_field` varchar(64) NOT NULL DEFAULT '',
  `foreign_db` varchar(64) NOT NULL DEFAULT '',
  `foreign_table` varchar(64) NOT NULL DEFAULT '',
  `foreign_field` varchar(64) NOT NULL DEFAULT ''
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='Relation table';

-- --------------------------------------------------------

--
-- Table structure for table `pma__savedsearches`
--

CREATE TABLE `pma__savedsearches` (
  `id` int(5) UNSIGNED NOT NULL,
  `username` varchar(64) NOT NULL DEFAULT '',
  `db_name` varchar(64) NOT NULL DEFAULT '',
  `search_name` varchar(64) NOT NULL DEFAULT '',
  `search_data` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='Saved searches';

-- --------------------------------------------------------

--
-- Table structure for table `pma__table_coords`
--

CREATE TABLE `pma__table_coords` (
  `db_name` varchar(64) NOT NULL DEFAULT '',
  `table_name` varchar(64) NOT NULL DEFAULT '',
  `pdf_page_number` int(11) NOT NULL DEFAULT 0,
  `x` float UNSIGNED NOT NULL DEFAULT 0,
  `y` float UNSIGNED NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='Table coordinates for phpMyAdmin PDF output';

-- --------------------------------------------------------

--
-- Table structure for table `pma__table_info`
--

CREATE TABLE `pma__table_info` (
  `db_name` varchar(64) NOT NULL DEFAULT '',
  `table_name` varchar(64) NOT NULL DEFAULT '',
  `display_field` varchar(64) NOT NULL DEFAULT ''
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='Table information for phpMyAdmin';

-- --------------------------------------------------------

--
-- Table structure for table `pma__table_uiprefs`
--

CREATE TABLE `pma__table_uiprefs` (
  `username` varchar(64) NOT NULL,
  `db_name` varchar(64) NOT NULL,
  `table_name` varchar(64) NOT NULL,
  `prefs` text NOT NULL,
  `last_update` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='Tables'' UI preferences';

--
-- Dumping data for table `pma__table_uiprefs`
--

INSERT INTO `pma__table_uiprefs` (`username`, `db_name`, `table_name`, `prefs`, `last_update`) VALUES
('root', 'quanlythuvien', 'phieu_phat', '{\"sorted_col\":\"`phieu_phat`.`MaPhieuPhat` ASC\"}', '2025-10-31 07:13:08');

-- --------------------------------------------------------

--
-- Table structure for table `pma__tracking`
--

CREATE TABLE `pma__tracking` (
  `db_name` varchar(64) NOT NULL,
  `table_name` varchar(64) NOT NULL,
  `version` int(10) UNSIGNED NOT NULL,
  `date_created` datetime NOT NULL,
  `date_updated` datetime NOT NULL,
  `schema_snapshot` text NOT NULL,
  `schema_sql` text DEFAULT NULL,
  `data_sql` longtext DEFAULT NULL,
  `tracking` set('UPDATE','REPLACE','INSERT','DELETE','TRUNCATE','CREATE DATABASE','ALTER DATABASE','DROP DATABASE','CREATE TABLE','ALTER TABLE','RENAME TABLE','DROP TABLE','CREATE INDEX','DROP INDEX','CREATE VIEW','ALTER VIEW','DROP VIEW') DEFAULT NULL,
  `tracking_active` int(1) UNSIGNED NOT NULL DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='Database changes tracking for phpMyAdmin';

-- --------------------------------------------------------

--
-- Table structure for table `pma__userconfig`
--

CREATE TABLE `pma__userconfig` (
  `username` varchar(64) NOT NULL,
  `timevalue` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `config_data` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='User preferences storage for phpMyAdmin';

--
-- Dumping data for table `pma__userconfig`
--

INSERT INTO `pma__userconfig` (`username`, `timevalue`, `config_data`) VALUES
('root', '2025-11-16 10:37:02', '{\"Console\\/Mode\":\"collapse\",\"lang\":\"vi\"}');

-- --------------------------------------------------------

--
-- Table structure for table `pma__usergroups`
--

CREATE TABLE `pma__usergroups` (
  `usergroup` varchar(64) NOT NULL,
  `tab` varchar(64) NOT NULL,
  `allowed` enum('Y','N') NOT NULL DEFAULT 'N'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='User groups with configured menu items';

-- --------------------------------------------------------

--
-- Table structure for table `pma__users`
--

CREATE TABLE `pma__users` (
  `username` varchar(64) NOT NULL,
  `usergroup` varchar(64) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='Users and their assignments to user groups';

--
-- Indexes for dumped tables
--

--
-- Indexes for table `pma__bookmark`
--
ALTER TABLE `pma__bookmark`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `pma__central_columns`
--
ALTER TABLE `pma__central_columns`
  ADD PRIMARY KEY (`db_name`,`col_name`);

--
-- Indexes for table `pma__column_info`
--
ALTER TABLE `pma__column_info`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `db_name` (`db_name`,`table_name`,`column_name`);

--
-- Indexes for table `pma__designer_settings`
--
ALTER TABLE `pma__designer_settings`
  ADD PRIMARY KEY (`username`);

--
-- Indexes for table `pma__export_templates`
--
ALTER TABLE `pma__export_templates`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `u_user_type_template` (`username`,`export_type`,`template_name`);

--
-- Indexes for table `pma__favorite`
--
ALTER TABLE `pma__favorite`
  ADD PRIMARY KEY (`username`);

--
-- Indexes for table `pma__history`
--
ALTER TABLE `pma__history`
  ADD PRIMARY KEY (`id`),
  ADD KEY `username` (`username`,`db`,`table`,`timevalue`);

--
-- Indexes for table `pma__navigationhiding`
--
ALTER TABLE `pma__navigationhiding`
  ADD PRIMARY KEY (`username`,`item_name`,`item_type`,`db_name`,`table_name`);

--
-- Indexes for table `pma__pdf_pages`
--
ALTER TABLE `pma__pdf_pages`
  ADD PRIMARY KEY (`page_nr`),
  ADD KEY `db_name` (`db_name`);

--
-- Indexes for table `pma__recent`
--
ALTER TABLE `pma__recent`
  ADD PRIMARY KEY (`username`);

--
-- Indexes for table `pma__relation`
--
ALTER TABLE `pma__relation`
  ADD PRIMARY KEY (`master_db`,`master_table`,`master_field`),
  ADD KEY `foreign_field` (`foreign_db`,`foreign_table`);

--
-- Indexes for table `pma__savedsearches`
--
ALTER TABLE `pma__savedsearches`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `u_savedsearches_username_dbname` (`username`,`db_name`,`search_name`);

--
-- Indexes for table `pma__table_coords`
--
ALTER TABLE `pma__table_coords`
  ADD PRIMARY KEY (`db_name`,`table_name`,`pdf_page_number`);

--
-- Indexes for table `pma__table_info`
--
ALTER TABLE `pma__table_info`
  ADD PRIMARY KEY (`db_name`,`table_name`);

--
-- Indexes for table `pma__table_uiprefs`
--
ALTER TABLE `pma__table_uiprefs`
  ADD PRIMARY KEY (`username`,`db_name`,`table_name`);

--
-- Indexes for table `pma__tracking`
--
ALTER TABLE `pma__tracking`
  ADD PRIMARY KEY (`db_name`,`table_name`,`version`);

--
-- Indexes for table `pma__userconfig`
--
ALTER TABLE `pma__userconfig`
  ADD PRIMARY KEY (`username`);

--
-- Indexes for table `pma__usergroups`
--
ALTER TABLE `pma__usergroups`
  ADD PRIMARY KEY (`usergroup`,`tab`,`allowed`);

--
-- Indexes for table `pma__users`
--
ALTER TABLE `pma__users`
  ADD PRIMARY KEY (`username`,`usergroup`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `pma__bookmark`
--
ALTER TABLE `pma__bookmark`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `pma__column_info`
--
ALTER TABLE `pma__column_info`
  MODIFY `id` int(5) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `pma__export_templates`
--
ALTER TABLE `pma__export_templates`
  MODIFY `id` int(5) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `pma__history`
--
ALTER TABLE `pma__history`
  MODIFY `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `pma__pdf_pages`
--
ALTER TABLE `pma__pdf_pages`
  MODIFY `page_nr` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `pma__savedsearches`
--
ALTER TABLE `pma__savedsearches`
  MODIFY `id` int(5) UNSIGNED NOT NULL AUTO_INCREMENT;
--
-- Database: `qlchxm`
--
CREATE DATABASE IF NOT EXISTS `qlchxm` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `qlchxm`;

-- --------------------------------------------------------

--
-- Table structure for table `chitietdonhang`
--

CREATE TABLE `chitietdonhang` (
  `MADH` int(11) NOT NULL,
  `MAXE` varchar(10) NOT NULL,
  `SOLUONG` int(11) DEFAULT NULL,
  `DONGIA` int(11) DEFAULT NULL,
  `THANHTIEN` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `chitietdonhang`
--

INSERT INTO `chitietdonhang` (`MADH`, `MAXE`, `SOLUONG`, `DONGIA`, `THANHTIEN`) VALUES
(8, 'XM002', 1, 21000000, 21000000),
(9, 'XM003', 2, 35000000, 70000000),
(9, 'XM005', 1, 42000000, 42000000);

-- --------------------------------------------------------

--
-- Table structure for table `chitiethoadon`
--

CREATE TABLE `chitiethoadon` (
  `MAHD` int(11) NOT NULL,
  `MAXE` varchar(10) NOT NULL,
  `SOLUONG` int(11) DEFAULT NULL,
  `DONGIA` int(11) DEFAULT NULL,
  `THANHTIEN` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `chitiethoadon`
--

INSERT INTO `chitiethoadon` (`MAHD`, `MAXE`, `SOLUONG`, `DONGIA`, `THANHTIEN`) VALUES
(3, 'XM002', 1, 21000000, 21000000),
(4, 'XM002', 1, 21000000, 21000000),
(5, 'XM003', 2, 35000000, 70000000),
(5, 'XM005', 1, 42000000, 42000000);

-- --------------------------------------------------------

--
-- Table structure for table `chitietphieunhap`
--

CREATE TABLE `chitietphieunhap` (
  `MAPN` bigint(20) NOT NULL,
  `MAXE` varchar(10) NOT NULL,
  `SOLUONG` int(11) DEFAULT NULL,
  `DONGIA` int(11) DEFAULT NULL,
  `THANHTIEN` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `chitietphieunhap`
--

INSERT INTO `chitietphieunhap` (`MAPN`, `MAXE`, `SOLUONG`, `DONGIA`, `THANHTIEN`) VALUES
(1, 'XM001', 2, 15000000, 30000000),
(6, 'XM002', 2, 100000000, 200000000),
(7, 'XM004', 1, 3000, 3000),
(8, 'XM007', 2, 5000, 10000),
(9, 'XM004', 1, 15000000, 15000000),
(10, 'XM003', 10, 25000000, 250000000),
(11, 'XM008', 12, 1, 12);

-- --------------------------------------------------------

--
-- Table structure for table `donhang`
--

CREATE TABLE `donhang` (
  `MADH` int(11) NOT NULL,
  `NGAYLAP` date DEFAULT NULL,
  `MAKH` varchar(10) NOT NULL,
  `DIACHI` varchar(200) DEFAULT NULL,
  `TONGTIEN` int(11) DEFAULT NULL,
  `TRANGTHAI` varchar(50) DEFAULT NULL,
  `PTTHANHTOAN` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `donhang`
--

INSERT INTO `donhang` (`MADH`, `NGAYLAP`, `MAKH`, `DIACHI`, `TONGTIEN`, `TRANGTHAI`, `PTTHANHTOAN`) VALUES
(8, '2025-05-21', '1', 'Hà Nội', 23100000, 'Đã hoàn thành', 'Tiền mặt khi nhận hàng'),
(9, '2025-05-21', '1', 'Hà Nội', 123200000, 'Đã hoàn thành', 'Tiền mặt khi nhận hàng');

-- --------------------------------------------------------

--
-- Table structure for table `giohang`
--

CREATE TABLE `giohang` (
  `idXe` varchar(10) NOT NULL,
  `soLuong` int(11) DEFAULT 0,
  `idKhachHang` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `hoadon`
--

CREATE TABLE `hoadon` (
  `MAHD` int(11) NOT NULL,
  `NGAYLAP` date DEFAULT NULL,
  `MAKH` varchar(10) NOT NULL,
  `MANV` varchar(10) NOT NULL,
  `TONGTIEN` int(11) DEFAULT NULL,
  `MADH` int(11) DEFAULT NULL,
  `PTTHANHTOAN` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `hoadon`
--

INSERT INTO `hoadon` (`MAHD`, `NGAYLAP`, `MAKH`, `MANV`, `TONGTIEN`, `MADH`, `PTTHANHTOAN`) VALUES
(3, '2025-05-21', '1', 'NV001', 21000000, 8, 'Tiền mặt khi nhận hàng'),
(4, '2025-05-21', '1', 'NV001', 21000000, 8, 'Tiền mặt khi nhận hàng'),
(5, '2025-05-21', '1', 'NV001', 112000000, 9, 'Tiền mặt khi nhận hàng');

-- --------------------------------------------------------

--
-- Table structure for table `khachhang`
--

CREATE TABLE `khachhang` (
  `MAKH` varchar(10) NOT NULL,
  `HOTEN` varchar(100) NOT NULL,
  `SDT` varchar(10) DEFAULT NULL,
  `DIACHI` varchar(200) DEFAULT NULL,
  `TENDANGNHAP` varchar(50) DEFAULT NULL,
  `MATKHAU` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `khachhang`
--

INSERT INTO `khachhang` (`MAKH`, `HOTEN`, `SDT`, `DIACHI`, `TENDANGNHAP`, `MATKHAU`) VALUES
('1', 'Nguyễn Văn A', '0912345678', 'Hà Nội', 'nguyenvana', '1'),
('2', 'Trần Thị B', '0987654321', 'Hồ Chí Minh', 'tranthib', 'abcdef'),
('3', 'Lê Văn C', '0909123456', 'Đà Nẵng', 'levanc', '112233');

-- --------------------------------------------------------

--
-- Table structure for table `nhacungcap`
--

CREATE TABLE `nhacungcap` (
  `MANCC` varchar(10) NOT NULL,
  `TENNCC` varchar(100) NOT NULL,
  `DIACHI` varchar(200) DEFAULT NULL,
  `SODIENTHOAI` varchar(10) DEFAULT NULL,
  `isActive` tinyint(1) DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `nhacungcap`
--

INSERT INTO `nhacungcap` (`MANCC`, `TENNCC`, `DIACHI`, `SODIENTHOAI`, `isActive`) VALUES
('NCC001', 'Công ty Honda Việt Nam', 'Hà Nội', '0123456789', 1),
('NCC002', 'Công ty Yamaha Motor', 'Đà Nẵng', '9876543210', 1),
('NCC003', 'Công ty SYM Việt Nam', 'Bình Dương', '0969764271', 1),
('NCC02', 'abc company', 'adss', '0987654321', 1);

-- --------------------------------------------------------

--
-- Table structure for table `nhanvien`
--

CREATE TABLE `nhanvien` (
  `MANV` varchar(10) NOT NULL,
  `HOTEN` varchar(100) NOT NULL,
  `NGAYSINH` date DEFAULT NULL,
  `GIOITINH` varchar(10) DEFAULT NULL,
  `SODIENTHOAI` varchar(10) DEFAULT NULL,
  `DIACHI` varchar(200) DEFAULT NULL,
  `CHUCVU` varchar(50) DEFAULT NULL,
  `TENDANGNHAP` varchar(50) DEFAULT NULL,
  `MATKHAU` varchar(100) DEFAULT NULL,
  `QUYEN` varchar(20) NOT NULL,
  `isActive` smallint(6) DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `nhanvien`
--

INSERT INTO `nhanvien` (`MANV`, `HOTEN`, `NGAYSINH`, `GIOITINH`, `SODIENTHOAI`, `DIACHI`, `CHUCVU`, `TENDANGNHAP`, `MATKHAU`, `QUYEN`, `isActive`) VALUES
('a', 'a', '2025-05-02', 'Nam', '0123456789', 'a', 'Quản lý', 'a', 'a', 'ADMIN', 1),
('NV001', 'Huỳnh Chí Văn', '2005-05-15', 'Nam', '0911222333', 'Lâm Đồng', 'Quản lý', 'huynhchivan', '123', 'ADMIN', 1),
('NV002', 'Nguyễn Thanh Hiệu', '2005-09-20', 'Nam', '0988111222', 'Hải Phòng', 'Nhân viên bán hàng', 'nguyenthanhieu', '456', 'NHANVIENBANHANG', 1),
('NV003', 'Nguyễn Thanh Văn', '2005-12-01', 'Nam', '0909111222', 'Nam Định', 'Nhân viên kho', 'nguyenthanhvan', '789', 'NHANVIENKHO', 1),
('nv11', 'khang huy', '2005-08-29', 'Nam', '0123456798', 'abc', 'Nhân viên bán hàng', 'huy', 'huy', 'NHANVENBANHANG', 1);

-- --------------------------------------------------------

--
-- Table structure for table `phieunhap`
--

CREATE TABLE `phieunhap` (
  `MAPN` bigint(20) NOT NULL,
  `NGAYNHAP` date DEFAULT NULL,
  `MANV` varchar(10) NOT NULL,
  `MANCC` varchar(10) NOT NULL,
  `TONGTIEN` int(11) DEFAULT NULL,
  `status` varchar(20) NOT NULL DEFAULT 'Đang_Chờ'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `phieunhap`
--

INSERT INTO `phieunhap` (`MAPN`, `NGAYNHAP`, `MANV`, `MANCC`, `TONGTIEN`, `status`) VALUES
(1, '2025-05-20', 'NV001', 'NCC001', 30000000, 'Hoàn_Thành'),
(5, '2025-05-21', 'nv11', 'NCC003', 20000, 'Đang_Chờ'),
(6, '2025-05-21', 'nv11', 'NCC003', 200000000, 'Đang_Chờ'),
(7, '2025-05-21', 'a', 'NCC02', 3000, 'Đang_Chờ'),
(8, '2025-05-21', 'NV001', 'NCC002', 10000, 'Đang_Chờ'),
(9, '2025-05-21', 'NV001', 'NCC02', 15000000, 'Hoàn_Thành'),
(10, '2025-05-21', 'Nv001', 'NCC001', 250000000, 'Hoàn_Thành'),
(11, '2025-05-21', 'a', 'NCC003', 12, 'Hoàn_Thành');

-- --------------------------------------------------------

--
-- Table structure for table `xemay`
--

CREATE TABLE `xemay` (
  `MAXE` varchar(10) NOT NULL,
  `TENXE` varchar(100) NOT NULL,
  `HANGXE` varchar(50) DEFAULT NULL,
  `GIABAN` int(11) DEFAULT NULL,
  `SOLUONG` int(11) DEFAULT NULL,
  `ANH` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `xemay`
--

INSERT INTO `xemay` (`MAXE`, `TENXE`, `HANGXE`, `GIABAN`, `SOLUONG`, `ANH`) VALUES
('XM001', 'Wave Alpha 110cc', 'Honda', 18000000, 26, 'images/xemay1.png'),
('XM002', 'Sirius Fi', 'Yamaha', 21000000, 5, 'xemay2.png'),
('XM003', 'Vision 2023', 'Honda', 35000000, 37, 'xemay3.png'),
('XM004', 'ss', 'Honda', 18000000, 3, 'xemay4.png'),
('XM005', 'Air Blade 125', 'Honda', 42000000, 17, 'xemay5.png'),
('XM006', 'Exciter 155 VVA', 'Yamaha', 47000000, 7, 'xemay6.png'),
('XM007', 'SH Mode 125cc', 'Honda', 60000000, 6, 'xemay7.png'),
('XM008', 'Grande Hybrid', 'Yamaha', 45000000, 12, 'xemay8.png'),
('XM009', 'Janus 2023', 'Yamaha', 31000000, 10, 'xemay9.png'),
('XM010', 'Lead 125', 'Honda', 42000000, 6, 'xemay10.png'),
('XM011', 'Piaggio Liberty 125', 'Piaggio', 56000000, 3, 'xemay11.png'),
('XM012', 'Vespa Primavera', 'Vespa', 80000000, 2, 'xemay12.png'),
('XM013', 'SYM Galaxy 110', 'SYM', 19000000, 5, 'xemay13.png'),
('XM014', 'Kymco Like 125', 'Kymco', 40000000, 4, 'xemay14.png'),
('XM015', 'VinFast Feliz S', 'Vespa', 29000000, 6, 'xemay15.png'),
('XM016', 'Yadea G5', 'SYM', 20000000, 7, 'xemay16.png');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `chitietdonhang`
--
ALTER TABLE `chitietdonhang`
  ADD PRIMARY KEY (`MADH`,`MAXE`),
  ADD KEY `MAXE` (`MAXE`);

--
-- Indexes for table `chitiethoadon`
--
ALTER TABLE `chitiethoadon`
  ADD PRIMARY KEY (`MAHD`,`MAXE`),
  ADD KEY `MAXE` (`MAXE`);

--
-- Indexes for table `chitietphieunhap`
--
ALTER TABLE `chitietphieunhap`
  ADD PRIMARY KEY (`MAPN`,`MAXE`),
  ADD KEY `MAXE` (`MAXE`);

--
-- Indexes for table `donhang`
--
ALTER TABLE `donhang`
  ADD PRIMARY KEY (`MADH`),
  ADD KEY `MAKH` (`MAKH`);

--
-- Indexes for table `giohang`
--
ALTER TABLE `giohang`
  ADD PRIMARY KEY (`idXe`,`idKhachHang`),
  ADD KEY `idKhachHang` (`idKhachHang`);

--
-- Indexes for table `hoadon`
--
ALTER TABLE `hoadon`
  ADD PRIMARY KEY (`MAHD`),
  ADD KEY `MAKH` (`MAKH`),
  ADD KEY `MANV` (`MANV`),
  ADD KEY `MADH` (`MADH`);

--
-- Indexes for table `khachhang`
--
ALTER TABLE `khachhang`
  ADD PRIMARY KEY (`MAKH`),
  ADD UNIQUE KEY `UQ_khachhang_TENDANGNHAP` (`TENDANGNHAP`),
  ADD UNIQUE KEY `UQ_khachhang_SDT` (`SDT`);

--
-- Indexes for table `nhacungcap`
--
ALTER TABLE `nhacungcap`
  ADD PRIMARY KEY (`MANCC`),
  ADD UNIQUE KEY `UQ_nhacungcap_SODIENTHOAI` (`SODIENTHOAI`);

--
-- Indexes for table `nhanvien`
--
ALTER TABLE `nhanvien`
  ADD PRIMARY KEY (`MANV`),
  ADD UNIQUE KEY `UQ_nhanvien_TENDANGNHAP` (`TENDANGNHAP`),
  ADD UNIQUE KEY `UQ_nhanvien_SODIENTHOAI` (`SODIENTHOAI`);

--
-- Indexes for table `phieunhap`
--
ALTER TABLE `phieunhap`
  ADD PRIMARY KEY (`MAPN`),
  ADD KEY `MANV` (`MANV`),
  ADD KEY `MANCC` (`MANCC`);

--
-- Indexes for table `xemay`
--
ALTER TABLE `xemay`
  ADD PRIMARY KEY (`MAXE`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `donhang`
--
ALTER TABLE `donhang`
  MODIFY `MADH` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `hoadon`
--
ALTER TABLE `hoadon`
  MODIFY `MAHD` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `phieunhap`
--
ALTER TABLE `phieunhap`
  MODIFY `MAPN` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `chitietdonhang`
--
ALTER TABLE `chitietdonhang`
  ADD CONSTRAINT `chitietdonhang_ibfk_1` FOREIGN KEY (`MADH`) REFERENCES `donhang` (`MADH`),
  ADD CONSTRAINT `chitietdonhang_ibfk_2` FOREIGN KEY (`MAXE`) REFERENCES `xemay` (`MAXE`);

--
-- Constraints for table `chitiethoadon`
--
ALTER TABLE `chitiethoadon`
  ADD CONSTRAINT `chitiethoadon_ibfk_1` FOREIGN KEY (`MAHD`) REFERENCES `hoadon` (`MAHD`),
  ADD CONSTRAINT `chitiethoadon_ibfk_2` FOREIGN KEY (`MAXE`) REFERENCES `xemay` (`MAXE`);

--
-- Constraints for table `chitietphieunhap`
--
ALTER TABLE `chitietphieunhap`
  ADD CONSTRAINT `chitietphieunhap_ibfk_1` FOREIGN KEY (`MAPN`) REFERENCES `phieunhap` (`MAPN`),
  ADD CONSTRAINT `chitietphieunhap_ibfk_2` FOREIGN KEY (`MAXE`) REFERENCES `xemay` (`MAXE`);

--
-- Constraints for table `donhang`
--
ALTER TABLE `donhang`
  ADD CONSTRAINT `donhang_ibfk_1` FOREIGN KEY (`MAKH`) REFERENCES `khachhang` (`MAKH`);

--
-- Constraints for table `giohang`
--
ALTER TABLE `giohang`
  ADD CONSTRAINT `giohang_ibfk_1` FOREIGN KEY (`idXe`) REFERENCES `xemay` (`MAXE`),
  ADD CONSTRAINT `giohang_ibfk_2` FOREIGN KEY (`idKhachHang`) REFERENCES `khachhang` (`MAKH`);

--
-- Constraints for table `hoadon`
--
ALTER TABLE `hoadon`
  ADD CONSTRAINT `hoadon_ibfk_1` FOREIGN KEY (`MAKH`) REFERENCES `khachhang` (`MAKH`),
  ADD CONSTRAINT `hoadon_ibfk_2` FOREIGN KEY (`MANV`) REFERENCES `nhanvien` (`MANV`),
  ADD CONSTRAINT `hoadon_ibfk_3` FOREIGN KEY (`MADH`) REFERENCES `donhang` (`MADH`);

--
-- Constraints for table `phieunhap`
--
ALTER TABLE `phieunhap`
  ADD CONSTRAINT `phieunhap_ibfk_1` FOREIGN KEY (`MANV`) REFERENCES `nhanvien` (`MANV`),
  ADD CONSTRAINT `phieunhap_ibfk_2` FOREIGN KEY (`MANCC`) REFERENCES `nhacungcap` (`MANCC`);
--
-- Database: `qltv`
--
CREATE DATABASE IF NOT EXISTS `qltv` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `qltv`;

-- --------------------------------------------------------

--
-- Table structure for table `chucnang_nhomquyen`
--

CREATE TABLE `chucnang_nhomquyen` (
  `MaNhomQuyen` int(11) NOT NULL,
  `MaChucNang` int(11) NOT NULL,
  `HanhDong` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `chucnang_nhomquyen`
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
-- Table structure for table `chuc_nang`
--

CREATE TABLE `chuc_nang` (
  `MACN` int(11) NOT NULL,
  `TENCN` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `chuc_nang`
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
-- Table structure for table `ctphieu_muon`
--

CREATE TABLE `ctphieu_muon` (
  `MaPhieuMuon` int(11) NOT NULL,
  `MaSach` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `ctphieu_muon`
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
-- Table structure for table `ctphieu_nhap`
--

CREATE TABLE `ctphieu_nhap` (
  `MaPhieuNhap` int(11) NOT NULL,
  `MaDauSach` int(11) NOT NULL,
  `SoLuong` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `ctphieu_phat`
--

CREATE TABLE `ctphieu_phat` (
  `TienPhat` int(11) NOT NULL,
  `MaSach` int(11) NOT NULL,
  `MaPhieuPhat` int(11) NOT NULL,
  `MaCTPhieuPhat` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `ctphieu_phat`
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
-- Table structure for table `ctphieu_tra`
--

CREATE TABLE `ctphieu_tra` (
  `MaCTPhieuTra` int(11) NOT NULL,
  `TrangThai` int(11) NOT NULL,
  `MaPhieuTra` int(11) NOT NULL,
  `MaSach` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `ctphieu_tra`
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
-- Table structure for table `ctthe_loai`
--

CREATE TABLE `ctthe_loai` (
  `MaTheLoai` int(11) NOT NULL,
  `TenTheLoai` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `ctthe_loai`
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
-- Table structure for table `dau_sach`
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
-- Dumping data for table `dau_sach`
--

INSERT INTO `dau_sach` (`MaDauSach`, `TenDauSach`, `HinhAnh`, `NhaXuatBan`, `NamXuatBan`, `NgonNgu`, `SoLuong`, `Gia`, `TrangThai`) VALUES
(1, 'Tuổi Thơ Dữ Dội', 'tuoithodu_doi.jpg', '1', '1988', 'Tiếng Việt', 50, 50000, 1),
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
-- Table structure for table `doc_gia`
--

CREATE TABLE `doc_gia` (
  `MADG` int(11) NOT NULL,
  `TENDG` varchar(100) NOT NULL,
  `SDT` varchar(15) NOT NULL,
  `DIACHI` varchar(150) NOT NULL,
  `TRANGTHAI` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `doc_gia`
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
-- Table structure for table `nhan_vien`
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
-- Dumping data for table `nhan_vien`
--

INSERT INTO `nhan_vien` (`MANV`, `TENNV`, `GIOITINH`, `NGAYSINH`, `SDT`, `TenDangNhap`, `MatKhau`, `TrangThai`, `Email`, `MaNhomQuyen`) VALUES
(1, 'Lê Quang Hoàng', 1, '2005-08-23', '0364722740', 'ad', '1', 1, 'admin@library.com', 1),
(2, 'Trần Thị B', 0, '1995-09-20', '0987654321', 'thuthu', 'thuthu123', 1, 'thuthu@library.com', 2),
(3, 'Phạm Hữu C', 1, '1990-02-15', '0909123123', 'qlkho', 'qlkho123', 1, 'quanlykho@library.com', 3);

-- --------------------------------------------------------

--
-- Table structure for table `nha_cung_cap`
--

CREATE TABLE `nha_cung_cap` (
  `MANCC` int(11) NOT NULL,
  `TENNCC` varchar(100) NOT NULL,
  `DIACHI` varchar(100) NOT NULL,
  `EMAIL` varchar(100) NOT NULL,
  `SDT` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `nha_cung_cap`
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
-- Table structure for table `nha_xuat_ban`
--

CREATE TABLE `nha_xuat_ban` (
  `MaNXB` int(11) NOT NULL,
  `TenNXB` varchar(100) NOT NULL,
  `Status` int(11) NOT NULL DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `nha_xuat_ban`
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
-- Table structure for table `nhom_quyen`
--

CREATE TABLE `nhom_quyen` (
  `MANQ` int(11) NOT NULL,
  `TENNQ` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `nhom_quyen`
--

INSERT INTO `nhom_quyen` (`MANQ`, `TENNQ`) VALUES
(0, 'Admin'),
(1, 'Admin'),
(2, 'Thủ thư'),
(3, 'Quản lý kho');

-- --------------------------------------------------------

--
-- Table structure for table `phieu_muon`
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
-- Dumping data for table `phieu_muon`
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
-- Table structure for table `phieu_nhap`
--

CREATE TABLE `phieu_nhap` (
  `MaPhieuNhap` int(11) NOT NULL,
  `ThoiGian` date NOT NULL,
  `MaNV` int(11) NOT NULL,
  `MaNCC` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `phieu_phat`
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
-- Dumping data for table `phieu_phat`
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
-- Table structure for table `phieu_tra`
--

CREATE TABLE `phieu_tra` (
  `MaPhieuTra` int(11) NOT NULL,
  `NgayTra` date NOT NULL,
  `MaDG` int(11) NOT NULL,
  `MaNV` int(11) NOT NULL,
  `MaPhieuMuon` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `phieu_tra`
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
-- Table structure for table `sach`
--

CREATE TABLE `sach` (
  `MaSach` int(11) NOT NULL,
  `trangthai` int(11) NOT NULL,
  `MaDauSach` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `sach`
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
-- Table structure for table `tacgia_dausach`
--

CREATE TABLE `tacgia_dausach` (
  `MaTacGia` int(11) NOT NULL,
  `MaDauSach` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tacgia_dausach`
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
-- Table structure for table `tac_gia`
--

CREATE TABLE `tac_gia` (
  `MaTacGia` int(11) NOT NULL,
  `TenTacGia` varchar(100) NOT NULL,
  `NamSinh` date NOT NULL,
  `QuocTich` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tac_gia`
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
-- Table structure for table `the_loai`
--

CREATE TABLE `the_loai` (
  `MaDauSach` int(11) NOT NULL,
  `MaTheLoai` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `the_loai`
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
-- Indexes for dumped tables
--

--
-- Indexes for table `chucnang_nhomquyen`
--
ALTER TABLE `chucnang_nhomquyen`
  ADD KEY `chucnang_nhomquyen_ibfk_1` (`MaChucNang`),
  ADD KEY `chucnang_nhomquyen_ibfk_2` (`MaNhomQuyen`);

--
-- Indexes for table `chuc_nang`
--
ALTER TABLE `chuc_nang`
  ADD PRIMARY KEY (`MACN`);

--
-- Indexes for table `ctphieu_muon`
--
ALTER TABLE `ctphieu_muon`
  ADD PRIMARY KEY (`MaPhieuMuon`,`MaSach`),
  ADD KEY `MaSach` (`MaSach`);

--
-- Indexes for table `ctphieu_nhap`
--
ALTER TABLE `ctphieu_nhap`
  ADD PRIMARY KEY (`MaPhieuNhap`,`MaDauSach`),
  ADD KEY `MaDauSach` (`MaDauSach`);

--
-- Indexes for table `ctphieu_phat`
--
ALTER TABLE `ctphieu_phat`
  ADD PRIMARY KEY (`MaCTPhieuPhat`),
  ADD KEY `MaPhieuPhat` (`MaPhieuPhat`),
  ADD KEY `MaSach` (`MaSach`);

--
-- Indexes for table `ctphieu_tra`
--
ALTER TABLE `ctphieu_tra`
  ADD PRIMARY KEY (`MaCTPhieuTra`),
  ADD KEY `fk_maPhieuTra_idx` (`MaPhieuTra`);

--
-- Indexes for table `ctthe_loai`
--
ALTER TABLE `ctthe_loai`
  ADD PRIMARY KEY (`MaTheLoai`);

--
-- Indexes for table `dau_sach`
--
ALTER TABLE `dau_sach`
  ADD PRIMARY KEY (`MaDauSach`);

--
-- Indexes for table `doc_gia`
--
ALTER TABLE `doc_gia`
  ADD PRIMARY KEY (`MADG`);

--
-- Indexes for table `nhan_vien`
--
ALTER TABLE `nhan_vien`
  ADD PRIMARY KEY (`MANV`),
  ADD UNIQUE KEY `SDT` (`SDT`),
  ADD UNIQUE KEY `TenDangNhap_UNIQUE` (`TenDangNhap`),
  ADD KEY `abc_idx` (`MaNhomQuyen`);

--
-- Indexes for table `nha_cung_cap`
--
ALTER TABLE `nha_cung_cap`
  ADD PRIMARY KEY (`MANCC`),
  ADD UNIQUE KEY `EMAIL` (`EMAIL`),
  ADD UNIQUE KEY `SDT` (`SDT`);

--
-- Indexes for table `nha_xuat_ban`
--
ALTER TABLE `nha_xuat_ban`
  ADD PRIMARY KEY (`MaNXB`);

--
-- Indexes for table `nhom_quyen`
--
ALTER TABLE `nhom_quyen`
  ADD PRIMARY KEY (`MANQ`);

--
-- Indexes for table `phieu_muon`
--
ALTER TABLE `phieu_muon`
  ADD PRIMARY KEY (`MaPhieuMuon`),
  ADD KEY `MaNhanVien` (`MaNhanVien`),
  ADD KEY `MaDocGia` (`MaDocGia`);

--
-- Indexes for table `phieu_nhap`
--
ALTER TABLE `phieu_nhap`
  ADD PRIMARY KEY (`MaPhieuNhap`),
  ADD KEY `MaNCC` (`MaNCC`),
  ADD KEY `MaNV` (`MaNV`);

--
-- Indexes for table `phieu_phat`
--
ALTER TABLE `phieu_phat`
  ADD PRIMARY KEY (`MaPhieuPhat`),
  ADD KEY `MaCTPhieuTra` (`MaCTPhieuTra`),
  ADD KEY `MaDG` (`MaDG`);

--
-- Indexes for table `phieu_tra`
--
ALTER TABLE `phieu_tra`
  ADD PRIMARY KEY (`MaPhieuTra`),
  ADD KEY `MaNV` (`MaNV`),
  ADD KEY `MaPhieuMuon` (`MaPhieuMuon`),
  ADD KEY `MaDG` (`MaDG`);

--
-- Indexes for table `sach`
--
ALTER TABLE `sach`
  ADD PRIMARY KEY (`MaSach`),
  ADD KEY `MaDauSach` (`MaDauSach`);

--
-- Indexes for table `tacgia_dausach`
--
ALTER TABLE `tacgia_dausach`
  ADD PRIMARY KEY (`MaTacGia`,`MaDauSach`),
  ADD KEY `MaDauSach` (`MaDauSach`);

--
-- Indexes for table `tac_gia`
--
ALTER TABLE `tac_gia`
  ADD PRIMARY KEY (`MaTacGia`);

--
-- Indexes for table `the_loai`
--
ALTER TABLE `the_loai`
  ADD PRIMARY KEY (`MaDauSach`,`MaTheLoai`),
  ADD KEY `MaTheLoai` (`MaTheLoai`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `chuc_nang`
--
ALTER TABLE `chuc_nang`
  MODIFY `MACN` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `ctphieu_muon`
--
ALTER TABLE `ctphieu_muon`
  MODIFY `MaPhieuMuon` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `ctphieu_phat`
--
ALTER TABLE `ctphieu_phat`
  MODIFY `MaCTPhieuPhat` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT for table `ctphieu_tra`
--
ALTER TABLE `ctphieu_tra`
  MODIFY `MaCTPhieuTra` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `ctthe_loai`
--
ALTER TABLE `ctthe_loai`
  MODIFY `MaTheLoai` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT for table `dau_sach`
--
ALTER TABLE `dau_sach`
  MODIFY `MaDauSach` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `doc_gia`
--
ALTER TABLE `doc_gia`
  MODIFY `MADG` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `nhan_vien`
--
ALTER TABLE `nhan_vien`
  MODIFY `MANV` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `nha_cung_cap`
--
ALTER TABLE `nha_cung_cap`
  MODIFY `MANCC` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `nha_xuat_ban`
--
ALTER TABLE `nha_xuat_ban`
  MODIFY `MaNXB` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `phieu_muon`
--
ALTER TABLE `phieu_muon`
  MODIFY `MaPhieuMuon` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT for table `phieu_phat`
--
ALTER TABLE `phieu_phat`
  MODIFY `MaPhieuPhat` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=33;

--
-- AUTO_INCREMENT for table `phieu_tra`
--
ALTER TABLE `phieu_tra`
  MODIFY `MaPhieuTra` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `sach`
--
ALTER TABLE `sach`
  MODIFY `MaSach` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `tac_gia`
--
ALTER TABLE `tac_gia`
  MODIFY `MaTacGia` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `chucnang_nhomquyen`
--
ALTER TABLE `chucnang_nhomquyen`
  ADD CONSTRAINT `chucnang_nhomquyen_ibfk_1` FOREIGN KEY (`MaChucNang`) REFERENCES `chuc_nang` (`MACN`),
  ADD CONSTRAINT `chucnang_nhomquyen_ibfk_2` FOREIGN KEY (`MaNhomQuyen`) REFERENCES `nhom_quyen` (`MANQ`);

--
-- Constraints for table `ctphieu_muon`
--
ALTER TABLE `ctphieu_muon`
  ADD CONSTRAINT `ctphieu_muon_ibfk_1` FOREIGN KEY (`MaPhieuMuon`) REFERENCES `phieu_muon` (`MaPhieuMuon`),
  ADD CONSTRAINT `ctphieu_muon_ibfk_2` FOREIGN KEY (`MaSach`) REFERENCES `sach` (`MaSach`);

--
-- Constraints for table `ctphieu_nhap`
--
ALTER TABLE `ctphieu_nhap`
  ADD CONSTRAINT `ctphieu_nhap_ibfk_1` FOREIGN KEY (`MaDauSach`) REFERENCES `dau_sach` (`MaDauSach`),
  ADD CONSTRAINT `ctphieu_nhap_ibfk_2` FOREIGN KEY (`MaPhieuNhap`) REFERENCES `phieu_nhap` (`MaPhieuNhap`);

--
-- Constraints for table `ctphieu_phat`
--
ALTER TABLE `ctphieu_phat`
  ADD CONSTRAINT `ctphieu_phat_ibfk_1` FOREIGN KEY (`MaPhieuPhat`) REFERENCES `phieu_phat` (`MaPhieuPhat`),
  ADD CONSTRAINT `ctphieu_phat_ibfk_2` FOREIGN KEY (`MaSach`) REFERENCES `sach` (`MaSach`);

--
-- Constraints for table `ctphieu_tra`
--
ALTER TABLE `ctphieu_tra`
  ADD CONSTRAINT `fk_maPhieuTra` FOREIGN KEY (`MaPhieuTra`) REFERENCES `phieu_tra` (`MaPhieuTra`);

--
-- Constraints for table `nhan_vien`
--
ALTER TABLE `nhan_vien`
  ADD CONSTRAINT `fk_maNhomQuyen` FOREIGN KEY (`MaNhomQuyen`) REFERENCES `nhom_quyen` (`MANQ`);

--
-- Constraints for table `phieu_muon`
--
ALTER TABLE `phieu_muon`
  ADD CONSTRAINT `phieu_muon_ibfk_1` FOREIGN KEY (`MaNhanVien`) REFERENCES `nhan_vien` (`MANV`),
  ADD CONSTRAINT `phieu_muon_ibfk_2` FOREIGN KEY (`MaDocGia`) REFERENCES `doc_gia` (`MADG`);

--
-- Constraints for table `phieu_nhap`
--
ALTER TABLE `phieu_nhap`
  ADD CONSTRAINT `phieu_nhap_ibfk_1` FOREIGN KEY (`MaNCC`) REFERENCES `nha_cung_cap` (`MANCC`),
  ADD CONSTRAINT `phieu_nhap_ibfk_2` FOREIGN KEY (`MaNV`) REFERENCES `nhan_vien` (`MANV`);

--
-- Constraints for table `phieu_phat`
--
ALTER TABLE `phieu_phat`
  ADD CONSTRAINT `phieu_phat_ibfk_1` FOREIGN KEY (`MaPhieuPhat`) REFERENCES `ctphieu_phat` (`MaPhieuPhat`),
  ADD CONSTRAINT `phieu_phat_ibfk_2` FOREIGN KEY (`MaDG`) REFERENCES `doc_gia` (`MADG`);

--
-- Constraints for table `sach`
--
ALTER TABLE `sach`
  ADD CONSTRAINT `sach_ibfk_1` FOREIGN KEY (`MaDauSach`) REFERENCES `dau_sach` (`MaDauSach`);
--
-- Database: `quanlythuvien`
--
CREATE DATABASE IF NOT EXISTS `quanlythuvien` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `quanlythuvien`;

-- --------------------------------------------------------

--
-- Table structure for table `chucnang_nhomquyen`
--

CREATE TABLE `chucnang_nhomquyen` (
  `MaNhomQuyen` int(11) NOT NULL,
  `MaChucNang` int(11) NOT NULL,
  `HanhDong` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `chucnang_nhomquyen`
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
-- Table structure for table `chuc_nang`
--

CREATE TABLE `chuc_nang` (
  `MACN` int(11) NOT NULL,
  `TENCN` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `chuc_nang`
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
-- Table structure for table `ctphieu_muon`
--

CREATE TABLE `ctphieu_muon` (
  `MaPhieuMuon` int(11) NOT NULL,
  `MaSach` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `ctphieu_muon`
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
-- Table structure for table `ctphieu_nhap`
--

CREATE TABLE `ctphieu_nhap` (
  `MaPhieuNhap` int(11) NOT NULL,
  `MaDauSach` int(11) NOT NULL,
  `SoLuong` int(11) NOT NULL,
  `DonGia` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `ctphieu_nhap`
--

INSERT INTO `ctphieu_nhap` (`MaPhieuNhap`, `MaDauSach`, `SoLuong`, `DonGia`) VALUES
(1, 2, 40, 100000),
(1, 4, 200, 100000),
(1, 6, 10, 100000),
(1, 8, 30, 100000),
(2, 9, 200, 100000);

-- --------------------------------------------------------

--
-- Table structure for table `ctphieu_phat`
--

CREATE TABLE `ctphieu_phat` (
  `TienPhat` int(11) NOT NULL,
  `MaSach` int(11) NOT NULL,
  `MaPhieuPhat` int(11) NOT NULL,
  `MaCTPhieuPhat` int(11) NOT NULL,
  `LyDoPhat` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `ctphieu_phat`
--

INSERT INTO `ctphieu_phat` (`TienPhat`, `MaSach`, `MaPhieuPhat`, `MaCTPhieuPhat`, `LyDoPhat`) VALUES
(10000, 5, 36, 1, 'Trả trễ 2 ngày'),
(10000, 4, 37, 2, 'Trả trễ 2 ngày'),
(55000, 2, 38, 3, 'Trả trễ 1 ngày, Sách hỏng'),
(5000, 1, 39, 4, 'Trả trễ 1 ngày'),
(110000, 8, 40, 5, 'Trả trễ 2 ngày, Làm mất sách'),
(60000, 7, 41, 6, 'Trả trễ 2 ngày, Sách hỏng'),
(5000, 4, 42, 7, 'Trả trễ 1 ngày'),
(55000, 3, 43, 8, 'Trả trễ 1 ngày, Sách hỏng'),
(1635000, 3, 44, 9, 'Trả trễ 327 ngày');

-- --------------------------------------------------------

--
-- Table structure for table `ctphieu_tra`
--

CREATE TABLE `ctphieu_tra` (
  `MaCTPhieuTra` int(11) NOT NULL,
  `TrangThai` int(11) NOT NULL,
  `MaPhieuTra` int(11) NOT NULL,
  `MaSach` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `ctphieu_tra`
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
(10, 3, 10, 5),
(11, 1, 11, 3);

-- --------------------------------------------------------

--
-- Table structure for table `ctthe_loai`
--

CREATE TABLE `ctthe_loai` (
  `MaTheLoai` int(11) NOT NULL,
  `TenTheLoai` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `ctthe_loai`
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
-- Table structure for table `dau_sach`
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
-- Dumping data for table `dau_sach`
--

INSERT INTO `dau_sach` (`MaDauSach`, `TenDauSach`, `HinhAnh`, `NhaXuatBan`, `NamXuatBan`, `NgonNgu`, `SoLuong`, `Gia`, `TrangThai`) VALUES
(1, 'Tuổi Thơ Dữ Dội', 'tuoithodu_doi.jpg', '1', '1988', 'Tiếng Việt', 50, 1000000, 1),
(2, 'Doraemon - Tập 1', 'doraemon_tap1.jpg', '1', '1992', 'Tiếng Việt', 120, 150000, 1),
(3, 'Harry Potter và Hòn Đá Phù Thủy', 'hp1.jpg', '2', '1997', 'Tiếng Anh', 80, 75000, 1),
(4, 'Nhà Giả Kim', 'nha_gia_kim.jpg', '3', '1988', 'Tiếng Việt', 60, 90000, 1),
(5, 'Đắc Nhân Tâm', 'dac_nhan_tam.jpg', '4', '1936', 'Tiếng Việt', 100, 100000, 1),
(6, 'Chí Phèo', 'chi_pheo.jpg', '3', '1941', 'Tiếng Việt', 40, 85000, 1),
(7, 'Sherlock Holmes - Tập 1', 'sherlock1.jpg', '5', '1892', 'Tiếng Anh', 55, 120000, 1),
(8, 'Không Gia Đình', 'khong_gia_dinh.jpg', '1', '1878', 'Tiếng Việt', 70, 80000, 1),
(9, 'One Piece - Tập 1', 'onepiece_tap1.jpg', '1', '1997', 'Tiếng Việt', 150, 70000, 1),
(10, 'Around the World in 80 Days', 'around80days.jpg', '6', '1873', 'Tiếng Anh', 30, 60000, 1);

-- --------------------------------------------------------

--
-- Table structure for table `doc_gia`
--

CREATE TABLE `doc_gia` (
  `MADG` int(11) NOT NULL,
  `TENDG` varchar(100) NOT NULL,
  `SDT` varchar(15) NOT NULL,
  `DIACHI` varchar(150) NOT NULL,
  `TRANGTHAI` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `doc_gia`
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
-- Table structure for table `nhan_vien`
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
-- Dumping data for table `nhan_vien`
--

INSERT INTO `nhan_vien` (`MANV`, `TENNV`, `GIOITINH`, `NGAYSINH`, `SDT`, `TenDangNhap`, `MatKhau`, `TrangThai`, `Email`, `MaNhomQuyen`) VALUES
(1, 'Lê Quang Hoàng', 1, '2005-08-23', '0364722740', 'ad', '1', 1, 'admin@library.com', 1),
(2, 'Trần Thị B', 0, '1995-09-20', '0987654321', 'thuthu', 'thuthu123', 1, 'thuthu@library.com', 2),
(3, 'Phạm Hữu C', 1, '1990-02-15', '0909123123', 'qlkho', 'qlkho123', 1, 'quanlykho@library.com', 3);

-- --------------------------------------------------------

--
-- Table structure for table `nha_cung_cap`
--

CREATE TABLE `nha_cung_cap` (
  `MANCC` int(11) NOT NULL,
  `TENNCC` varchar(100) NOT NULL,
  `DIACHI` varchar(100) NOT NULL,
  `EMAIL` varchar(100) NOT NULL,
  `SDT` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `nha_cung_cap`
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
-- Table structure for table `nha_xuat_ban`
--

CREATE TABLE `nha_xuat_ban` (
  `MaNXB` int(11) NOT NULL,
  `TenNXB` varchar(100) NOT NULL,
  `Status` int(11) NOT NULL DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `nha_xuat_ban`
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
-- Table structure for table `nhom_quyen`
--

CREATE TABLE `nhom_quyen` (
  `MANQ` int(11) NOT NULL,
  `TENNQ` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `nhom_quyen`
--

INSERT INTO `nhom_quyen` (`MANQ`, `TENNQ`) VALUES
(0, 'Admin'),
(1, 'Admin'),
(2, 'Thủ thư'),
(3, 'Quản lý kho');

-- --------------------------------------------------------

--
-- Table structure for table `phieu_muon`
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
-- Dumping data for table `phieu_muon`
--

INSERT INTO `phieu_muon` (`MaPhieuMuon`, `NgayMuon`, `NgayTraDuKien`, `trangthai`, `MaDocGia`, `MaNhanVien`) VALUES
(1, '2025-01-05', '2025-01-12', 1, 1, 2),
(2, '2025-01-07', '2025-01-14', 3, 2, 2),
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
-- Table structure for table `phieu_nhap`
--

CREATE TABLE `phieu_nhap` (
  `MaPhieuNhap` int(11) NOT NULL,
  `ThoiGian` date NOT NULL,
  `MaNV` int(11) NOT NULL,
  `MaNCC` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `phieu_nhap`
--

INSERT INTO `phieu_nhap` (`MaPhieuNhap`, `ThoiGian`, `MaNV`, `MaNCC`) VALUES
(1, '2025-12-11', 3, 7),
(2, '2025-09-25', 1, 4),
(3, '2025-12-24', 3, 4);

-- --------------------------------------------------------

--
-- Table structure for table `phieu_phat`
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
-- Dumping data for table `phieu_phat`
--

INSERT INTO `phieu_phat` (`MaPhieuPhat`, `NgayPhat`, `TrangThai`, `MaCTPhieuTra`, `Ngaytra`, `MaDG`) VALUES
(36, '2025-12-07', 1, 10, '2025-01-26', 10),
(37, '2025-12-07', 1, 9, '2025-01-25', 9),
(38, '2025-12-07', 1, 8, '2025-01-23', 8),
(39, '2025-12-07', 1, 7, '2025-01-22', 7),
(40, '2025-12-07', 1, 5, '2025-01-20', 5),
(41, '2025-12-07', 1, 4, '2025-01-19', 4),
(42, '2025-12-07', 1, 3, '2025-01-16', 3),
(43, '2025-12-07', 1, 2, '2025-01-15', 2),
(44, '2025-12-08', 1, 11, '2025-12-07', 2);

-- --------------------------------------------------------

--
-- Table structure for table `phieu_tra`
--

CREATE TABLE `phieu_tra` (
  `MaPhieuTra` int(11) NOT NULL,
  `NgayTra` date NOT NULL,
  `MaDG` int(11) NOT NULL,
  `MaNV` int(11) NOT NULL,
  `MaPhieuMuon` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `phieu_tra`
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
(10, '2025-01-26', 10, 3, 10),
(11, '2025-12-07', 0, 1, 2);

-- --------------------------------------------------------

--
-- Table structure for table `sach`
--

CREATE TABLE `sach` (
  `MaSach` int(11) NOT NULL,
  `trangthai` int(11) NOT NULL,
  `MaDauSach` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `sach`
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
-- Table structure for table `tacgia_dausach`
--

CREATE TABLE `tacgia_dausach` (
  `MaTacGia` int(11) NOT NULL,
  `MaDauSach` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tacgia_dausach`
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
-- Table structure for table `tac_gia`
--

CREATE TABLE `tac_gia` (
  `MaTacGia` int(11) NOT NULL,
  `TenTacGia` varchar(100) NOT NULL,
  `NamSinh` date NOT NULL,
  `QuocTich` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tac_gia`
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
-- Table structure for table `the_loai`
--

CREATE TABLE `the_loai` (
  `MaDauSach` int(11) NOT NULL,
  `MaTheLoai` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `the_loai`
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
-- Indexes for dumped tables
--

--
-- Indexes for table `chucnang_nhomquyen`
--
ALTER TABLE `chucnang_nhomquyen`
  ADD KEY `chucnang_nhomquyen_ibfk_1` (`MaChucNang`),
  ADD KEY `chucnang_nhomquyen_ibfk_2` (`MaNhomQuyen`);

--
-- Indexes for table `chuc_nang`
--
ALTER TABLE `chuc_nang`
  ADD PRIMARY KEY (`MACN`);

--
-- Indexes for table `ctphieu_muon`
--
ALTER TABLE `ctphieu_muon`
  ADD PRIMARY KEY (`MaPhieuMuon`,`MaSach`),
  ADD KEY `MaSach` (`MaSach`);

--
-- Indexes for table `ctphieu_nhap`
--
ALTER TABLE `ctphieu_nhap`
  ADD PRIMARY KEY (`MaPhieuNhap`,`MaDauSach`),
  ADD KEY `MaDauSach` (`MaDauSach`);

--
-- Indexes for table `ctphieu_phat`
--
ALTER TABLE `ctphieu_phat`
  ADD PRIMARY KEY (`MaCTPhieuPhat`),
  ADD KEY `MaPhieuPhat` (`MaPhieuPhat`),
  ADD KEY `MaSach` (`MaSach`);

--
-- Indexes for table `ctphieu_tra`
--
ALTER TABLE `ctphieu_tra`
  ADD PRIMARY KEY (`MaCTPhieuTra`),
  ADD KEY `fk_maPhieuTra_idx` (`MaPhieuTra`);

--
-- Indexes for table `ctthe_loai`
--
ALTER TABLE `ctthe_loai`
  ADD PRIMARY KEY (`MaTheLoai`);

--
-- Indexes for table `dau_sach`
--
ALTER TABLE `dau_sach`
  ADD PRIMARY KEY (`MaDauSach`);

--
-- Indexes for table `doc_gia`
--
ALTER TABLE `doc_gia`
  ADD PRIMARY KEY (`MADG`);

--
-- Indexes for table `nhan_vien`
--
ALTER TABLE `nhan_vien`
  ADD PRIMARY KEY (`MANV`),
  ADD UNIQUE KEY `SDT` (`SDT`),
  ADD UNIQUE KEY `TenDangNhap_UNIQUE` (`TenDangNhap`),
  ADD KEY `abc_idx` (`MaNhomQuyen`);

--
-- Indexes for table `nha_cung_cap`
--
ALTER TABLE `nha_cung_cap`
  ADD PRIMARY KEY (`MANCC`),
  ADD UNIQUE KEY `EMAIL` (`EMAIL`),
  ADD UNIQUE KEY `SDT` (`SDT`);

--
-- Indexes for table `nha_xuat_ban`
--
ALTER TABLE `nha_xuat_ban`
  ADD PRIMARY KEY (`MaNXB`);

--
-- Indexes for table `nhom_quyen`
--
ALTER TABLE `nhom_quyen`
  ADD PRIMARY KEY (`MANQ`);

--
-- Indexes for table `phieu_muon`
--
ALTER TABLE `phieu_muon`
  ADD PRIMARY KEY (`MaPhieuMuon`),
  ADD KEY `MaNhanVien` (`MaNhanVien`),
  ADD KEY `MaDocGia` (`MaDocGia`);

--
-- Indexes for table `phieu_nhap`
--
ALTER TABLE `phieu_nhap`
  ADD PRIMARY KEY (`MaPhieuNhap`),
  ADD KEY `MaNCC` (`MaNCC`),
  ADD KEY `MaNV` (`MaNV`);

--
-- Indexes for table `phieu_phat`
--
ALTER TABLE `phieu_phat`
  ADD PRIMARY KEY (`MaPhieuPhat`),
  ADD KEY `MaCTPhieuTra` (`MaCTPhieuTra`),
  ADD KEY `MaDG` (`MaDG`);

--
-- Indexes for table `phieu_tra`
--
ALTER TABLE `phieu_tra`
  ADD PRIMARY KEY (`MaPhieuTra`),
  ADD KEY `MaNV` (`MaNV`),
  ADD KEY `MaPhieuMuon` (`MaPhieuMuon`),
  ADD KEY `MaDG` (`MaDG`);

--
-- Indexes for table `sach`
--
ALTER TABLE `sach`
  ADD PRIMARY KEY (`MaSach`),
  ADD KEY `MaDauSach` (`MaDauSach`);

--
-- Indexes for table `tacgia_dausach`
--
ALTER TABLE `tacgia_dausach`
  ADD PRIMARY KEY (`MaTacGia`,`MaDauSach`),
  ADD KEY `MaDauSach` (`MaDauSach`);

--
-- Indexes for table `tac_gia`
--
ALTER TABLE `tac_gia`
  ADD PRIMARY KEY (`MaTacGia`);

--
-- Indexes for table `the_loai`
--
ALTER TABLE `the_loai`
  ADD PRIMARY KEY (`MaDauSach`,`MaTheLoai`),
  ADD KEY `MaTheLoai` (`MaTheLoai`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `chuc_nang`
--
ALTER TABLE `chuc_nang`
  MODIFY `MACN` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `ctphieu_muon`
--
ALTER TABLE `ctphieu_muon`
  MODIFY `MaPhieuMuon` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `ctphieu_phat`
--
ALTER TABLE `ctphieu_phat`
  MODIFY `MaCTPhieuPhat` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `ctphieu_tra`
--
ALTER TABLE `ctphieu_tra`
  MODIFY `MaCTPhieuTra` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT for table `ctthe_loai`
--
ALTER TABLE `ctthe_loai`
  MODIFY `MaTheLoai` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT for table `dau_sach`
--
ALTER TABLE `dau_sach`
  MODIFY `MaDauSach` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `doc_gia`
--
ALTER TABLE `doc_gia`
  MODIFY `MADG` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `nhan_vien`
--
ALTER TABLE `nhan_vien`
  MODIFY `MANV` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `nha_cung_cap`
--
ALTER TABLE `nha_cung_cap`
  MODIFY `MANCC` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `nha_xuat_ban`
--
ALTER TABLE `nha_xuat_ban`
  MODIFY `MaNXB` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `phieu_muon`
--
ALTER TABLE `phieu_muon`
  MODIFY `MaPhieuMuon` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT for table `phieu_nhap`
--
ALTER TABLE `phieu_nhap`
  MODIFY `MaPhieuNhap` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `phieu_phat`
--
ALTER TABLE `phieu_phat`
  MODIFY `MaPhieuPhat` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=45;

--
-- AUTO_INCREMENT for table `phieu_tra`
--
ALTER TABLE `phieu_tra`
  MODIFY `MaPhieuTra` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT for table `sach`
--
ALTER TABLE `sach`
  MODIFY `MaSach` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `tac_gia`
--
ALTER TABLE `tac_gia`
  MODIFY `MaTacGia` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `chucnang_nhomquyen`
--
ALTER TABLE `chucnang_nhomquyen`
  ADD CONSTRAINT `chucnang_nhomquyen_ibfk_1` FOREIGN KEY (`MaChucNang`) REFERENCES `chuc_nang` (`MACN`),
  ADD CONSTRAINT `chucnang_nhomquyen_ibfk_2` FOREIGN KEY (`MaNhomQuyen`) REFERENCES `nhom_quyen` (`MANQ`);

--
-- Constraints for table `ctphieu_muon`
--
ALTER TABLE `ctphieu_muon`
  ADD CONSTRAINT `ctphieu_muon_ibfk_1` FOREIGN KEY (`MaPhieuMuon`) REFERENCES `phieu_muon` (`MaPhieuMuon`),
  ADD CONSTRAINT `ctphieu_muon_ibfk_2` FOREIGN KEY (`MaSach`) REFERENCES `sach` (`MaSach`);

--
-- Constraints for table `ctphieu_nhap`
--
ALTER TABLE `ctphieu_nhap`
  ADD CONSTRAINT `ctphieu_nhap_ibfk_1` FOREIGN KEY (`MaDauSach`) REFERENCES `dau_sach` (`MaDauSach`),
  ADD CONSTRAINT `ctphieu_nhap_ibfk_2` FOREIGN KEY (`MaPhieuNhap`) REFERENCES `phieu_nhap` (`MaPhieuNhap`);

--
-- Constraints for table `ctphieu_phat`
--
ALTER TABLE `ctphieu_phat`
  ADD CONSTRAINT `ctphieu_phat_ibfk_2` FOREIGN KEY (`MaSach`) REFERENCES `sach` (`MaSach`),
  ADD CONSTRAINT `ctphieu_phat_ibfk_3` FOREIGN KEY (`MaPhieuPhat`) REFERENCES `phieu_phat` (`MaPhieuPhat`);

--
-- Constraints for table `ctphieu_tra`
--
ALTER TABLE `ctphieu_tra`
  ADD CONSTRAINT `fk_maPhieuTra` FOREIGN KEY (`MaPhieuTra`) REFERENCES `phieu_tra` (`MaPhieuTra`);

--
-- Constraints for table `nhan_vien`
--
ALTER TABLE `nhan_vien`
  ADD CONSTRAINT `fk_maNhomQuyen` FOREIGN KEY (`MaNhomQuyen`) REFERENCES `nhom_quyen` (`MANQ`);

--
-- Constraints for table `phieu_muon`
--
ALTER TABLE `phieu_muon`
  ADD CONSTRAINT `phieu_muon_ibfk_1` FOREIGN KEY (`MaNhanVien`) REFERENCES `nhan_vien` (`MANV`),
  ADD CONSTRAINT `phieu_muon_ibfk_2` FOREIGN KEY (`MaDocGia`) REFERENCES `doc_gia` (`MADG`);

--
-- Constraints for table `phieu_nhap`
--
ALTER TABLE `phieu_nhap`
  ADD CONSTRAINT `phieu_nhap_ibfk_1` FOREIGN KEY (`MaNCC`) REFERENCES `nha_cung_cap` (`MANCC`),
  ADD CONSTRAINT `phieu_nhap_ibfk_2` FOREIGN KEY (`MaNV`) REFERENCES `nhan_vien` (`MANV`);

--
-- Constraints for table `phieu_phat`
--
ALTER TABLE `phieu_phat`
  ADD CONSTRAINT `phieu_phat_ibfk_2` FOREIGN KEY (`MaDG`) REFERENCES `doc_gia` (`MADG`);
--
-- Database: `test`
--
CREATE DATABASE IF NOT EXISTS `test` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `test`;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
