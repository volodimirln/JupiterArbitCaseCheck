-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: Jun 11, 2024 at 11:11 AM
-- Server version: 8.0.30
-- PHP Version: 8.1.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `Jupiter`
--

-- --------------------------------------------------------

--
-- Table structure for table `Cities`
--

CREATE TABLE `Cities` (
  `Id` int NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Court` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Description` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `Cities`
--

INSERT INTO `Cities` (`Id`, `Name`, `Court`, `Description`) VALUES
(1, 'KRASNODAR', 'АС Краснодарского края', NULL),
(2, 'ROSTOV', 'АС Ростовской области', NULL),
(3, 'STAVROPOL', 'АС Ставропольского края', NULL),
(4, 'KRYM', 'АС Республики Крым', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `FavorieCases`
--

CREATE TABLE `FavorieCases` (
  `Id` int NOT NULL,
  `Date` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Judge` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Court` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `CaseNumber` varchar(255) NOT NULL,
  `Plaintiff` varchar(255) NOT NULL,
  `Respondent` varchar(255) NOT NULL,
  `СaseLink` varchar(255) NOT NULL,
  `UserId` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `FavorieCases`
--

INSERT INTO `FavorieCases` (`Id`, `Date`, `Judge`, `Court`, `CaseNumber`, `Plaintiff`, `Respondent`, `СaseLink`, `UserId`) VALUES
(15, '10.06.2024', 'Лигерман А. Ф.', 'АС города Севастополя', 'А84-4814/2024', 'ООО \"Научно-производственное объединение Консультант\"\r\n295006, Россия, Республика Крым, г. Севастополь, ул. Володарского, д. 3, офис 2\r\n\r\nИНН: 526041859', 'Болгарина Ирина Николаевна\r\nДанные скрыты\r\n\r\nИНН: 91021062060', 'https://kad.arbitr.ru/Card/3ef1ce5e-71b1-49cf-860b-6a27ab3d7049', ''),
(16, '10.06.2024', 'Погадаев Н. Н.', 'Суд по интеллектуальным правам', 'СИП-635/2024', 'uot;МАКФА\"\r\n123001, Россия, Москва, Москва, Офис 1, Вспольный переулок, д. 5 строение 1\r\n\r\nИНН: 743801588', '\r\nТоварищество с ограниченной ответственностью \"Компания FRIENDS\"\r\n041609, Россия, Республика Казахстан, Талгарский район, с. Бесагаш, офис 212, ул. Байтурсынова, д. ', 'https://kad.arbitr.ru/Card/d6016d48-c048-4a1d-9a0b-445e3f1d339d', ''),
(17, '10.06.2024', 'Борисова Ю. В.', 'Суд по интеллектуальным правам', 'СИП-639/2024', 'ООО \"САНДИ-ЕВПАТОРИЯ\"\r\n297402, РОССИЯ, РЕСПУБЛИКА КРЫМ, Г. ЕВПАТОРИЯ, УЛ. СИМФЕРОПОЛЬСКАЯ, Д. 94В\r\n\r\nИНН: 911008891', 'Липатов Андрей Владимирович\r\nДанные скрыт', 'https://kad.arbitr.ru/Card/90d780df-2d0d-416e-93f7-aff24479d7ff', ''),
(18, '10.06.2024', 'Погребняк А. С.', 'АС города Севастополя', 'А84-4810/2024', '\r\nДепартамент по имущественным и земельным отношениям города Севастополя\r\n299011, Россия, г. Севастополь, г. Севастополь, ул. Советская, д. 9\r\n\r\nИНН: 920400211', 'О \"Два Лео\"\r\n299804, Россия, г. Севастополь, пгт Кача, ул. Первомайская, д. 1А\r\n\r\nИНН: 920300632', 'https://kad.arbitr.ru/Card/18980d32-1301-443e-9dff-372cc7ef67d2', ''),
(19, '10.06.2024', 'Погребняк А. С.', 'АС города Севастополя', 'А84-4810/2024', '\r\nДепартамент по имущественным и земельным отношениям города Севастополя\r\n299011, Россия, г. Севастополь, г. Севастополь, ул. Советская, д. 9\r\n\r\nИНН: 920400211', 'О \"Два Лео\"\r\n299804, Россия, г. Севастополь, пгт Кача, ул. Первомайская, д. 1А\r\n\r\nИНН: 920300632', 'https://kad.arbitr.ru/Card/18980d32-1301-443e-9dff-372cc7ef67d2', ''),
(25, '10.06.2024', 'Можарова М. Е.', 'АС Республики Крым', 'А83-11323/2024', 'ГУП РЕСПУБЛИКИ КРЫМ \"КРЫМЭНЕРГО\"\r\n295034, Россия, Республика Крым, г. Симферополь, ул. Киевская, д. 74/6\r\n\r\nИНН: 910200287', '\r\nООО \"РЕМОНТНО-ЭКСПЛУАТАЦИОННОЕ УПРАВЛЕНИЕ \"НОВЫЙ ГОРОД\"\r\n296108, Россия, Республика Крым, г. Джанкой, ул. Нестерова, д. 31, кв. 53\r\n\r\nИНН: 910227062', 'https://kad.arbitr.ru/Card/af8e4b9b-8787-4ff9-934f-3cdec09d0929', '13'),
(26, '10.06.2024', 'Можарова М. Е.', 'АС Республики Крым', 'А83-11322/2024', 'ГУП РЕСПУБЛИКИ КРЫМ \"КРЫМЭНЕРГО\"\r\n295034, Россия, Республика Крым, г. Симферополь, ул. Киевская, д. 74/6\r\n\r\nИНН: 910200287', '\r\nООО \"РЕМОНТНО-ЭКСПЛУАТАЦИОННОЕ УПРАВЛЕНИЕ \"НОВЫЙ ГОРОД\"\r\n296108, Россия, Республика Крым, г. Джанкой, ул. Нестерова, д. 31, кв. 53\r\n\r\nИНН: 910227062', 'https://kad.arbitr.ru/Card/00bd91cd-5fb5-40c1-b759-e20bbd564a2f', '13'),
(27, '10.06.2024', 'Можарова М. Е.', 'АС Республики Крым', 'А83-11329/2024', 'ГУП РЕСПУБЛИКИ КРЫМ \"КРЫМЭНЕРГО\"\r\n295034, Россия, Республика Крым, г. Симферополь, ул. Киевская, д. 74/6\r\n\r\nИНН: 910200287', '\r\nМУП МУНИЦИПАЛЬНОГО ОБРАЗОВАНИЯ ГОРОДСКОЙ ОКРУГ СИМФЕРОПОЛЬ РЕСПУБЛИКИ КРЫМ &#171;АВАНГРАД&#187;\r\n295013, РОССИЯ, РЕСПУБЛИКА КРЫМ, Г. СИМФЕРОПОЛЬ, УЛ. КРЫМСКИХ ПАРТИЗАН, Д. 5\r\n\r\nИНН: 910206430', 'https://kad.arbitr.ru/Card/7c5edf9a-cf2a-494b-bae2-e3c2cfd0fcbf', '13'),
(28, '10.06.2024', 'Батурин В. А.', 'АС Ставропольского края', 'А63-10966/2024', 'ГУП СТАВРОПОЛЬСКОГО КРАЯ \"КРАЙТРАНС\"\r\n355037, Россия, КРАЙ. СТАВРОПОЛЬСКИЙ, г. СТАВРОПОЛЬ, ул. ДОВАТОРЦЕВ, д. 30\r\n\r\nИНН: 263300151', 'ООО \"ТЕЛЕКОМ ТЗ\"\r\n125130, Россия, Москва, г. Москва, переулок 2-Й НОВОПОДМОСКОВНЫЙ, д. 4А, ЭТ 2 К 12\r\n\r\nИНН: 771038337', 'https://kad.arbitr.ru/Card/df2cd310-0745-4bd1-b096-be4f0d20fb56', '13');

-- --------------------------------------------------------

--
-- Table structure for table `Passwords`
--

CREATE TABLE `Passwords` (
  `Id` int NOT NULL,
  `UserId` int NOT NULL,
  `HashPassword` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Status` tinyint(1) NOT NULL,
  `DateAdd` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `Passwords`
--

INSERT INTO `Passwords` (`Id`, `UserId`, `HashPassword`, `Status`, `DateAdd`) VALUES
(1, 1, 'c39efea9b37436adb92d5971676f233f', 1, '2024-04-25'),
(2, 2, 'c39efea9b37436adb92d5971676f233f', 1, '2024-04-25'),
(3, 3, 'c39efea9b37436adb92d5971676f233f', 1, '2024-04-25'),
(4, 4, 'c39efea9b37436adb92d5971676f233f', 1, '2024-04-25'),
(5, 5, 'c39efea9b37436adb92d5971676f233f', 0, '2024-04-25'),
(6, 8, 'c39efea9b37436adb92d5971676f233f', 0, '2024-04-25'),
(14, 5, 'c39efea9b37436adb92d5971676f233f', 1, '2024-04-28'),
(15, 12, 'c39efea9b37436adb92d5971676f233f', 1, '2024-04-28'),
(16, 15, 'bcfa0fcfbadfba1b1a30b3898e6d3f31', 1, '2024-06-11'),
(17, 16, '6950eba7007a8f4d18232bbd68425fa7', 1, '2024-06-11');

-- --------------------------------------------------------

--
-- Table structure for table `Roles`
--

CREATE TABLE `Roles` (
  `Id` int NOT NULL,
  `Title` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Description` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `Roles`
--

INSERT INTO `Roles` (`Id`, `Title`, `Description`) VALUES
(1, 'Aдминистратор', NULL),
(2, 'Менеджер', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `Users`
--

CREATE TABLE `Users` (
  `Id` int NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Surname` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Patronymic` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Email` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Phone` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `RoleId` int NOT NULL,
  `DateRegistration` date DEFAULT NULL,
  `DataChange` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `Users`
--

INSERT INTO `Users` (`Id`, `Name`, `Surname`, `Patronymic`, `Email`, `Phone`, `RoleId`, `DateRegistration`, `DataChange`) VALUES
(1, 'Олеся', 'Мартынова', 'Егоровна', 'martinova@jupiter.com', '78570374758', 1, '2024-04-25', '2024-04-25'),
(2, 'Виолетта', 'Шаповалова', 'Данииловна', 'shapavola@jupiter.com', '78570372540', 2, '2024-04-25', '2024-04-25'),
(3, 'Василиса', 'Бычкова', 'Тимофеевна', 'bikovaa@jupiter.com', '78570379510', 1, '2024-04-25', '2024-04-25'),
(4, 'Тимур', 'Шилов', 'Александрович', 'shilov@jupiter.com', '78570370653', 2, '2024-04-25', '2024-04-25'),
(5, 'Арина', 'Балашова', 'Константиновна', 'balashova@jupiter.com', '78570373754', 1, '2024-04-25', '2024-04-25'),
(6, 'string', 'string', 'string', 'string', 'string', 1, '2024-04-27', '2024-04-27'),
(7, 'string', 'string', 'string', 'string', 'string', 2, '2024-04-28', '2024-04-28'),
(8, 'string', 'string', 'string', 'string', 'string', 2, '2024-04-28', '2024-04-28'),
(9, 'dfgdfg', 'dfgdfg', 'dfgdg', 'dfgdf@fsdf.sdf', 'dfgdfg', 2, '2024-04-28', '2024-04-28'),
(10, 'апвап', 'вапапв', 'вапвап', '34345@kdfg.dfg', 'вапвп', 2, '2024-04-28', '2024-04-28'),
(11, 'dfgdsg', 'gfdg', 'sdfgsdfg', 'sdfgdfg@sfdsd.sdf', 'sdfgfdgs', 2, '2024-04-28', '2024-04-28'),
(12, 'dfvdfv', 'dgbdfv', 'dfgsdg', 'dfvfd@sdfsd.df', 'vdsfvdfv', 2, '2024-04-28', '2024-04-28'),
(13, 'admin', 'admin', 'admin', 'admin', 'admin', 1, '2024-05-21', '2024-05-21'),
(14, 'chyrka', 'chyrka', 'chyrka', 'chyrka@chyrka.ru', '1332412', 2, '2024-05-21', '2024-05-21'),
(15, 'test1', 'test1', 'test1', 'test1@fd.fd', 'test1', 2, '2024-06-11', '2024-06-11'),
(16, 'test1', 'test1', 'test1', 'test1@sd.re', 'test1', 2, '2024-06-11', '2024-06-11');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `Cities`
--
ALTER TABLE `Cities`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `FavorieCases`
--
ALTER TABLE `FavorieCases`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `Passwords`
--
ALTER TABLE `Passwords`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `Roles`
--
ALTER TABLE `Roles`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `Users`
--
ALTER TABLE `Users`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `RoleId` (`RoleId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `Cities`
--
ALTER TABLE `Cities`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `FavorieCases`
--
ALTER TABLE `FavorieCases`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=29;

--
-- AUTO_INCREMENT for table `Passwords`
--
ALTER TABLE `Passwords`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;

--
-- AUTO_INCREMENT for table `Roles`
--
ALTER TABLE `Roles`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `Users`
--
ALTER TABLE `Users`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `Users`
--
ALTER TABLE `Users`
  ADD CONSTRAINT `users_ibfk_1` FOREIGN KEY (`RoleId`) REFERENCES `Roles` (`Id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
