-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Mar 11, 2025 at 07:03 AM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.0.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `products`
--

-- --------------------------------------------------------

--
-- Table structure for table `products`
--

CREATE TABLE `products` (
  `p_id` int(255) NOT NULL,
  `productName` text NOT NULL,
  `productPrice` text NOT NULL,
  `productDescription` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `products`
--

INSERT INTO `products` (`p_id`, `productName`, `productPrice`, `productDescription`) VALUES
(75, 'asin', '5', 'tamiss'),
(76, 'car', '223', 'toy lang'),
(77, 'aso', '22', 'buang'),
(78, 'aswang', '54', 'mabit'),
(79, 'nhadine', '10000', 'sabog na siya'),
(80, 'mind', '234', 'sabog naaa'),
(81, 'utak na hmm', '3000', 'overthinker kaya di nakatulog'),
(82, 'soul', '3232', 'lumulutang'),
(83, 'kakaka', '12', 'ss'),
(84, 'mangoshakey', '69', 'lasang mangga');

--
-- Triggers `products`
--
DELIMITER $$
CREATE TRIGGER `limit_product_rows` BEFORE INSERT ON `products` FOR EACH ROW BEGIN
    DECLARE total_rows INT;
    SELECT COUNT(*) INTO total_rows FROM products;
    
    IF total_rows >= 10 THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Insert failed: Maximum row limit (10) reached!';
    END IF;
END
$$
DELIMITER ;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`p_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `products`
--
ALTER TABLE `products`
  MODIFY `p_id` int(255) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=85;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
