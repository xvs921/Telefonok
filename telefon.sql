-- phpMyAdmin SQL Dump
-- version 4.9.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2020. Jan 11. 21:19
-- Kiszolgáló verziója: 10.4.8-MariaDB
-- PHP verzió: 7.3.11

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `telefonok`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `telefon`
--

CREATE TABLE `telefon` (
  `id` int(11) NOT NULL,
  `marka` varchar(30) COLLATE utf8_hungarian_ci NOT NULL,
  `tipus` varchar(30) COLLATE utf8_hungarian_ci NOT NULL,
  `ar` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `telefon`
--

INSERT INTO `telefon` (`id`, `marka`, `tipus`, `ar`) VALUES
(1, 'Samsung', 'Galaxy Fold', 890000),
(2, 'Samsung', 'Galaxy A50', 90000),
(3, 'Samsung', 'Galaxy s10', 340000),
(4, 'Huawei', 'P30 Pro', 320000),
(5, 'iPhone', '11 Pro', 380000),
(6, 'Xiaomi', 'Mi 9', 160000);

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `telefon`
--
ALTER TABLE `telefon`
  ADD PRIMARY KEY (`id`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `telefon`
--
ALTER TABLE `telefon`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
