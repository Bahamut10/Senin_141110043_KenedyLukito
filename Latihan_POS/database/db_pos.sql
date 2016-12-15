-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Dec 15, 2016 at 10:03 AM
-- Server version: 10.1.16-MariaDB
-- PHP Version: 7.0.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `db_pos`
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
(4, '20', 'barang bagus', 10, '20.00', '30.00', '2016-12-15 14:48:59', '2016-12-15 14:48:59');

-- --------------------------------------------------------

--
-- Table structure for table `pos_customer`
--

CREATE TABLE `pos_customer` (
  `ID` int(11) NOT NULL,
  `Kode` varchar(20) DEFAULT NULL,
  `Nama` varchar(100) DEFAULT NULL,
  `Alamat` varchar(400) DEFAULT NULL,
  `Created_at` datetime DEFAULT NULL,
  `Updated_at` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `pos_customer`
--

INSERT INTO `pos_customer` (`ID`, `Kode`, `Nama`, `Alamat`, `Created_at`, `Updated_at`) VALUES
(3, '11', 'cust', 'jalan jalan', '2016-12-15 00:01:36', '2016-12-15 00:01:36');

-- --------------------------------------------------------

--
-- Table structure for table `pos_supplier`
--

CREATE TABLE `pos_supplier` (
  `ID` int(11) NOT NULL,
  `Kode` varchar(20) DEFAULT NULL,
  `Nama` varchar(100) DEFAULT NULL,
  `Alamat` varchar(300) DEFAULT NULL,
  `Created_at` datetime DEFAULT NULL,
  `Updated_at` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `pos_supplier`
--

INSERT INTO `pos_supplier` (`ID`, `Kode`, `Nama`, `Alamat`, `Created_at`, `Updated_at`) VALUES
(2, '23', 'supp', 'jalan jalans', '2016-12-15 00:01:53', '2016-12-15 00:01:53'),
(3, '111', 'Lukito', 'jalan jalan', '2016-12-15 15:11:12', '2016-12-15 15:11:12');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `pos_barang`
--
ALTER TABLE `pos_barang`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `pos_customer`
--
ALTER TABLE `pos_customer`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `pos_supplier`
--
ALTER TABLE `pos_supplier`
  ADD PRIMARY KEY (`ID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `pos_barang`
--
ALTER TABLE `pos_barang`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT for table `pos_customer`
--
ALTER TABLE `pos_customer`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT for table `pos_supplier`
--
ALTER TABLE `pos_supplier`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
