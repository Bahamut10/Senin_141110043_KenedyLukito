-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Dec 01, 2016 at 08:25 AM
-- Server version: 10.1.16-MariaDB
-- PHP Version: 7.0.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `db_barang`
--

-- --------------------------------------------------------

--
-- Table structure for table `pos_barang`
--

CREATE TABLE `pos_barang` (
  `ID` int(11) NOT NULL,
  `Kode` varchar(20) DEFAULT NULL,
  `Nama` varchar(100) DEFAULT NULL,
  `Jumlah_Awal` int(10) DEFAULT NULL,
  `Harga_HPP` decimal(16,2) DEFAULT NULL,
  `Harga_Jual` decimal(16,2) DEFAULT NULL,
  `Created_at` datetime DEFAULT NULL,
  `Updated_at` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `pos_barang`
--

INSERT INTO `pos_barang` (`ID`, `Kode`, `Nama`, `Jumlah_Awal`, `Harga_HPP`, `Harga_Jual`, `Created_at`, `Updated_at`) VALUES
(4, 'bbbbb', 'asdasdf', 1, '2999.00', '4000.00', '2016-12-01 14:10:42', '2016-12-01 14:10:42'),
(5, 'aaa', 'werwerwer', 1000, '20000.00', '20001.00', '2016-12-01 14:24:45', '2016-12-01 14:24:45');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `pos_barang`
--
ALTER TABLE `pos_barang`
  ADD PRIMARY KEY (`ID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `pos_barang`
--
ALTER TABLE `pos_barang`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
