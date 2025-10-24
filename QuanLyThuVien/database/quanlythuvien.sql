-- MySQL dump 10.13  Distrib 8.0.36, for Win64 (x86_64)
--
-- Host: localhost    Database: qltv
-- ------------------------------------------------------
-- Server version	8.0.37

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `chuc_nang`
--

DROP TABLE IF EXISTS `chuc_nang`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `chuc_nang` (
  `MACN` int NOT NULL,
  `TENCN` varchar(100) COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`MACN`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `chuc_nang`
--

LOCK TABLES `chuc_nang` WRITE;
/*!40000 ALTER TABLE `chuc_nang` DISABLE KEYS */;
INSERT INTO `chuc_nang` VALUES (1,'them nv');
/*!40000 ALTER TABLE `chuc_nang` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ctphieu_muon`
--

DROP TABLE IF EXISTS `ctphieu_muon`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ctphieu_muon` (
  `MaPhieuMuon` int NOT NULL,
  `MaSach` int NOT NULL,
  PRIMARY KEY (`MaPhieuMuon`,`MaSach`),
  KEY `MaSach` (`MaSach`),
  CONSTRAINT `ctphieu_muon_ibfk_1` FOREIGN KEY (`MaPhieuMuon`) REFERENCES `phieu_muon` (`MaPhieuMuon`),
  CONSTRAINT `ctphieu_muon_ibfk_2` FOREIGN KEY (`MaSach`) REFERENCES `sach` (`MaSach`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ctphieu_muon`
--

LOCK TABLES `ctphieu_muon` WRITE;
/*!40000 ALTER TABLE `ctphieu_muon` DISABLE KEYS */;
/*!40000 ALTER TABLE `ctphieu_muon` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ctphieu_nhap`
--

DROP TABLE IF EXISTS `ctphieu_nhap`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ctphieu_nhap` (
  `MaPhieuNhap` int NOT NULL,
  `MaDauSach` int NOT NULL,
  `SoLuong` int NOT NULL,
  PRIMARY KEY (`MaPhieuNhap`,`MaDauSach`),
  KEY `MaDauSach` (`MaDauSach`),
  CONSTRAINT `ctphieu_nhap_ibfk_1` FOREIGN KEY (`MaDauSach`) REFERENCES `dau_sach` (`MaDauSach`),
  CONSTRAINT `ctphieu_nhap_ibfk_2` FOREIGN KEY (`MaPhieuNhap`) REFERENCES `phieu_nhap` (`MaPhieuNhap`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ctphieu_nhap`
--

LOCK TABLES `ctphieu_nhap` WRITE;
/*!40000 ALTER TABLE `ctphieu_nhap` DISABLE KEYS */;
/*!40000 ALTER TABLE `ctphieu_nhap` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ctphieu_tra`
--

DROP TABLE IF EXISTS `ctphieu_tra`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ctphieu_tra` (
  `MaCTPhieuTra` int NOT NULL,
  `TrangThai` int NOT NULL,
  `MaPhieuTra` int NOT NULL,
  `MaSach` int NOT NULL,
  PRIMARY KEY (`MaCTPhieuTra`),
  KEY `fk_maPhieuTra_idx` (`MaPhieuTra`),
  CONSTRAINT `fk_maPhieuTra` FOREIGN KEY (`MaPhieuTra`) REFERENCES `phieu_tra` (`MaPhieuTra`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ctphieu_tra`
--

LOCK TABLES `ctphieu_tra` WRITE;
/*!40000 ALTER TABLE `ctphieu_tra` DISABLE KEYS */;
/*!40000 ALTER TABLE `ctphieu_tra` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ctthe_loai`
--

DROP TABLE IF EXISTS `ctthe_loai`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ctthe_loai` (
  `MaTheLoai` int NOT NULL,
  `TenTheLoai` varchar(100) COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`MaTheLoai`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ctthe_loai`
--

LOCK TABLES `ctthe_loai` WRITE;
/*!40000 ALTER TABLE `ctthe_loai` DISABLE KEYS */;
/*!40000 ALTER TABLE `ctthe_loai` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `dau_sach`
--

DROP TABLE IF EXISTS `dau_sach`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `dau_sach` (
  `MaDauSach` int NOT NULL,
  `TenDauSach` varchar(100) COLLATE utf8mb4_general_ci NOT NULL,
  `HinhAnh` varchar(200) COLLATE utf8mb4_general_ci NOT NULL,
  `NhaXuatBan` varchar(100) COLLATE utf8mb4_general_ci NOT NULL,
  `NamXuatBan` varchar(100) COLLATE utf8mb4_general_ci NOT NULL,
  `NgonNgu` varchar(100) COLLATE utf8mb4_general_ci NOT NULL,
  `SoLuong` int NOT NULL,
  PRIMARY KEY (`MaDauSach`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dau_sach`
--

LOCK TABLES `dau_sach` WRITE;
/*!40000 ALTER TABLE `dau_sach` DISABLE KEYS */;
/*!40000 ALTER TABLE `dau_sach` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `doc_gia`
--

DROP TABLE IF EXISTS `doc_gia`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `doc_gia` (
  `MADG` int NOT NULL,
  `TENDG` varchar(100) COLLATE utf8mb4_general_ci NOT NULL,
  `SDT` varchar(15) COLLATE utf8mb4_general_ci NOT NULL,
  `DIACHI` varchar(150) COLLATE utf8mb4_general_ci NOT NULL,
  `TRANGTHAI` int NOT NULL,
  PRIMARY KEY (`MADG`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `doc_gia`
--

LOCK TABLES `doc_gia` WRITE;
/*!40000 ALTER TABLE `doc_gia` DISABLE KEYS */;
/*!40000 ALTER TABLE `doc_gia` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `nha_cung_cap`
--

DROP TABLE IF EXISTS `nha_cung_cap`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `nha_cung_cap` (
  `MANCC` int NOT NULL,
  `TENCC` varchar(100) COLLATE utf8mb4_general_ci NOT NULL,
  `DIACHI` varchar(100) COLLATE utf8mb4_general_ci NOT NULL,
  `EMAIL` varchar(100) COLLATE utf8mb4_general_ci NOT NULL,
  `SDT` varchar(100) COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`MANCC`),
  UNIQUE KEY `EMAIL` (`EMAIL`),
  UNIQUE KEY `SDT` (`SDT`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `nha_cung_cap`
--

LOCK TABLES `nha_cung_cap` WRITE;
/*!40000 ALTER TABLE `nha_cung_cap` DISABLE KEYS */;
/*!40000 ALTER TABLE `nha_cung_cap` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `nhan_vien`
--

DROP TABLE IF EXISTS `nhan_vien`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `nhan_vien` (
  `MANV` int NOT NULL,
  `TENNV` varchar(100) COLLATE utf8mb4_general_ci NOT NULL,
  `GIOITINH` tinyint(1) NOT NULL,
  `NGAYSINH` date NOT NULL,
  `SDT` varchar(100) COLLATE utf8mb4_general_ci NOT NULL,
  `TenDangNhap` varchar(100) COLLATE utf8mb4_general_ci NOT NULL,
  `MatKhau` varchar(100) COLLATE utf8mb4_general_ci NOT NULL,
  `TrangThai` int NOT NULL,
  `Email` varchar(100) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `MaNhomQuyen` int DEFAULT NULL,
  PRIMARY KEY (`MANV`),
  UNIQUE KEY `SDT` (`SDT`),
  UNIQUE KEY `TenDangNhap_UNIQUE` (`TenDangNhap`),
  KEY `abc_idx` (`MaNhomQuyen`),
  CONSTRAINT `fk_maNhomQuyen` FOREIGN KEY (`MaNhomQuyen`) REFERENCES `nhom_quyen` (`MANQ`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `nhan_vien`
--

LOCK TABLES `nhan_vien` WRITE;
/*!40000 ALTER TABLE `nhan_vien` DISABLE KEYS */;
INSERT INTO `nhan_vien` VALUES (0,'admin',0,'2000-10-10','0987654321','ad','1',1,'abc@gmail.com',0);
/*!40000 ALTER TABLE `nhan_vien` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `nhom_quyen`
--

DROP TABLE IF EXISTS `nhom_quyen`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `nhom_quyen` (
  `MANQ` int NOT NULL,
  `TENNQ` varchar(100) COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`MANQ`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `nhom_quyen`
--

LOCK TABLES `nhom_quyen` WRITE;
/*!40000 ALTER TABLE `nhom_quyen` DISABLE KEYS */;
INSERT INTO `nhom_quyen` VALUES (0,'Admin');
/*!40000 ALTER TABLE `nhom_quyen` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `nhomquyen_chucnang`
--

DROP TABLE IF EXISTS `nhomquyen_chucnang`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `nhomquyen_chucnang` (
  `MaChucNang` int NOT NULL,
  `MaNhomQuyen` int NOT NULL,
  `HanhDong` varchar(100) COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`MaChucNang`,`MaNhomQuyen`),
  KEY `MaNhomQuyen` (`MaNhomQuyen`),
  CONSTRAINT `nhomquyen_chucnang_ibfk_1` FOREIGN KEY (`MaChucNang`) REFERENCES `chuc_nang` (`MACN`),
  CONSTRAINT `nhomquyen_chucnang_ibfk_2` FOREIGN KEY (`MaNhomQuyen`) REFERENCES `nhom_quyen` (`MANQ`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `nhomquyen_chucnang`
--

LOCK TABLES `nhomquyen_chucnang` WRITE;
/*!40000 ALTER TABLE `nhomquyen_chucnang` DISABLE KEYS */;
INSERT INTO `nhomquyen_chucnang` VALUES (1,0,'abc');
/*!40000 ALTER TABLE `nhomquyen_chucnang` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `phieu_muon`
--

DROP TABLE IF EXISTS `phieu_muon`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `phieu_muon` (
  `MaPhieuMuon` int NOT NULL,
  `NgayMuon` date NOT NULL,
  `NgayTraDuKien` date NOT NULL,
  `trangthai` int NOT NULL,
  `MaDocGia` int NOT NULL,
  `MaNhanVien` int NOT NULL,
  PRIMARY KEY (`MaPhieuMuon`),
  KEY `MaNhanVien` (`MaNhanVien`),
  KEY `MaDocGia` (`MaDocGia`),
  CONSTRAINT `phieu_muon_ibfk_1` FOREIGN KEY (`MaNhanVien`) REFERENCES `nhan_vien` (`MANV`),
  CONSTRAINT `phieu_muon_ibfk_2` FOREIGN KEY (`MaDocGia`) REFERENCES `doc_gia` (`MADG`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `phieu_muon`
--

LOCK TABLES `phieu_muon` WRITE;
/*!40000 ALTER TABLE `phieu_muon` DISABLE KEYS */;
/*!40000 ALTER TABLE `phieu_muon` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `phieu_nhap`
--

DROP TABLE IF EXISTS `phieu_nhap`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `phieu_nhap` (
  `MaPhieuNhap` int NOT NULL,
  `ThoiGian` date NOT NULL,
  `MaNV` int NOT NULL,
  `MaNCC` int NOT NULL,
  PRIMARY KEY (`MaPhieuNhap`),
  KEY `MaNCC` (`MaNCC`),
  KEY `MaNV` (`MaNV`),
  CONSTRAINT `phieu_nhap_ibfk_1` FOREIGN KEY (`MaNCC`) REFERENCES `nha_cung_cap` (`MANCC`),
  CONSTRAINT `phieu_nhap_ibfk_2` FOREIGN KEY (`MaNV`) REFERENCES `nhan_vien` (`MANV`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `phieu_nhap`
--

LOCK TABLES `phieu_nhap` WRITE;
/*!40000 ALTER TABLE `phieu_nhap` DISABLE KEYS */;
/*!40000 ALTER TABLE `phieu_nhap` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `phieu_phat`
--

DROP TABLE IF EXISTS `phieu_phat`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `phieu_phat` (
  `MaPhieuPhat` int NOT NULL,
  `TienPhat` int NOT NULL,
  `NgayPhat` date NOT NULL,
  `TrangThai` int NOT NULL,
  `MaCTPhieuTra` int NOT NULL,
  PRIMARY KEY (`MaPhieuPhat`),
  KEY `MaCTPhieuTra` (`MaCTPhieuTra`),
  CONSTRAINT `phieu_phat_ibfk_2` FOREIGN KEY (`MaCTPhieuTra`) REFERENCES `ctphieu_tra` (`MaCTPhieuTra`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `phieu_phat`
--

LOCK TABLES `phieu_phat` WRITE;
/*!40000 ALTER TABLE `phieu_phat` DISABLE KEYS */;
/*!40000 ALTER TABLE `phieu_phat` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `phieu_tra`
--

DROP TABLE IF EXISTS `phieu_tra`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `phieu_tra` (
  `MaPhieuTra` int NOT NULL,
  `NgayTra` date NOT NULL,
  `MaNV` int NOT NULL,
  `MaPhieuMuon` int NOT NULL,
  PRIMARY KEY (`MaPhieuTra`),
  KEY `MaNV` (`MaNV`),
  KEY `MaPhieuMuon` (`MaPhieuMuon`),
  CONSTRAINT `phieu_tra_ibfk_1` FOREIGN KEY (`MaNV`) REFERENCES `nhan_vien` (`MANV`),
  CONSTRAINT `phieu_tra_ibfk_3` FOREIGN KEY (`MaPhieuMuon`) REFERENCES `phieu_muon` (`MaPhieuMuon`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `phieu_tra`
--

LOCK TABLES `phieu_tra` WRITE;
/*!40000 ALTER TABLE `phieu_tra` DISABLE KEYS */;
/*!40000 ALTER TABLE `phieu_tra` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sach`
--

DROP TABLE IF EXISTS `sach`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sach` (
  `MaSach` int NOT NULL,
  `trangthai` int NOT NULL,
  `MaDauSach` int NOT NULL,
  PRIMARY KEY (`MaSach`),
  KEY `MaDauSach` (`MaDauSach`),
  CONSTRAINT `sach_ibfk_1` FOREIGN KEY (`MaDauSach`) REFERENCES `dau_sach` (`MaDauSach`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sach`
--

LOCK TABLES `sach` WRITE;
/*!40000 ALTER TABLE `sach` DISABLE KEYS */;
/*!40000 ALTER TABLE `sach` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tac_gia`
--

DROP TABLE IF EXISTS `tac_gia`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tac_gia` (
  `MaTacGia` varchar(100) COLLATE utf8mb4_general_ci NOT NULL,
  `TenTacGia` int NOT NULL,
  `NamSinh` date NOT NULL,
  `QuocTich` varchar(100) COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`MaTacGia`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tac_gia`
--

LOCK TABLES `tac_gia` WRITE;
/*!40000 ALTER TABLE `tac_gia` DISABLE KEYS */;
/*!40000 ALTER TABLE `tac_gia` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tacgia_dausach`
--

DROP TABLE IF EXISTS `tacgia_dausach`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tacgia_dausach` (
  `MaTacGia` varchar(100) COLLATE utf8mb4_general_ci NOT NULL,
  `MaDauSach` int NOT NULL,
  PRIMARY KEY (`MaTacGia`,`MaDauSach`),
  KEY `MaDauSach` (`MaDauSach`),
  CONSTRAINT `tacgia_dausach_ibfk_1` FOREIGN KEY (`MaDauSach`) REFERENCES `dau_sach` (`MaDauSach`),
  CONSTRAINT `tacgia_dausach_ibfk_2` FOREIGN KEY (`MaTacGia`) REFERENCES `tac_gia` (`MaTacGia`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tacgia_dausach`
--

LOCK TABLES `tacgia_dausach` WRITE;
/*!40000 ALTER TABLE `tacgia_dausach` DISABLE KEYS */;
/*!40000 ALTER TABLE `tacgia_dausach` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `the_loai`
--

DROP TABLE IF EXISTS `the_loai`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `the_loai` (
  `MaDauSach` int NOT NULL,
  `MaTheLoai` int NOT NULL,
  PRIMARY KEY (`MaDauSach`,`MaTheLoai`),
  KEY `MaTheLoai` (`MaTheLoai`),
  CONSTRAINT `the_loai_ibfk_1` FOREIGN KEY (`MaDauSach`) REFERENCES `dau_sach` (`MaDauSach`),
  CONSTRAINT `the_loai_ibfk_2` FOREIGN KEY (`MaTheLoai`) REFERENCES `ctthe_loai` (`MaTheLoai`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `the_loai`
--

LOCK TABLES `the_loai` WRITE;
/*!40000 ALTER TABLE `the_loai` DISABLE KEYS */;
/*!40000 ALTER TABLE `the_loai` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-10-17 16:27:15
