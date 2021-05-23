-- phpMyAdmin SQL Dump
-- version 5.1.0
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 23-05-2021 a las 16:00:02
-- Versión del servidor: 10.4.18-MariaDB
-- Versión de PHP: 8.0.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `proyectoprog`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `clientes`
--

CREATE TABLE `clientes` (
  `nombre` varchar(60) COLLATE utf8mb4_spanish2_ci NOT NULL,
  `apellidos` varchar(120) COLLATE utf8mb4_spanish2_ci DEFAULT NULL,
  `email` varchar(90) COLLATE utf8mb4_spanish2_ci DEFAULT NULL,
  `tlf` varchar(20) COLLATE utf8mb4_spanish2_ci DEFAULT NULL,
  `dni_pasaporte` varchar(9) COLLATE utf8mb4_spanish2_ci NOT NULL,
  `pais` varchar(80) COLLATE utf8mb4_spanish2_ci DEFAULT NULL,
  `direccion` varchar(150) COLLATE utf8mb4_spanish2_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish2_ci;

--
-- Volcado de datos para la tabla `clientes`
--

INSERT INTO `clientes` (`nombre`, `apellidos`, `email`, `tlf`, `dni_pasaporte`, `pais`, `direccion`) VALUES
('Cliente 1', 'Apellido1 Apellido2', '', '9876534531', '12345678A', 'España', '');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `empleados`
--

CREATE TABLE `empleados` (
  `dni` varchar(9) COLLATE utf8mb4_spanish2_ci NOT NULL,
  `nombre` varchar(60) COLLATE utf8mb4_spanish2_ci NOT NULL,
  `apellidos` varchar(120) COLLATE utf8mb4_spanish2_ci NOT NULL,
  `salario` int(11) NOT NULL,
  `direccion` varchar(90) COLLATE utf8mb4_spanish2_ci NOT NULL,
  `tlf` varchar(20) COLLATE utf8mb4_spanish2_ci NOT NULL,
  `email` varchar(90) COLLATE utf8mb4_spanish2_ci NOT NULL,
  `turno` varchar(15) COLLATE utf8mb4_spanish2_ci NOT NULL,
  `tipo` varchar(30) COLLATE utf8mb4_spanish2_ci NOT NULL,
  `acceso` mediumtext COLLATE utf8mb4_spanish2_ci DEFAULT 'block'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish2_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `habitaciones`
--

CREATE TABLE `habitaciones` (
  `cod` varchar(4) COLLATE utf8mb4_spanish2_ci NOT NULL,
  `camas` int(11) NOT NULL,
  `max_huesped` int(11) DEFAULT NULL,
  `planta` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish2_ci;

--
-- Volcado de datos para la tabla `habitaciones`
--

INSERT INTO `habitaciones` (`cod`, `camas`, `max_huesped`, `planta`) VALUES
('0A01', 2, 2, 1),
('0A02', 2, 2, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `plan_ventas`
--

CREATE TABLE `plan_ventas` (
  `tipo` varchar(30) COLLATE utf8mb4_spanish2_ci NOT NULL,
  `comidas` varchar(2) COLLATE utf8mb4_spanish2_ci DEFAULT NULL,
  `temporada` varchar(30) COLLATE utf8mb4_spanish2_ci DEFAULT NULL,
  `precio_por_noche` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish2_ci;

--
-- Volcado de datos para la tabla `plan_ventas`
--

INSERT INTO `plan_ventas` (`tipo`, `comidas`, `temporada`, `precio_por_noche`) VALUES
('Doble', '', '', 55);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `reservas`
--

CREATE TABLE `reservas` (
  `cod_rva` int(11) NOT NULL,
  `dni_emp` varchar(9) COLLATE utf8mb4_spanish2_ci NOT NULL,
  `dni_cli` varchar(9) COLLATE utf8mb4_spanish2_ci NOT NULL,
  `cod_hab` varchar(4) COLLATE utf8mb4_spanish2_ci NOT NULL,
  `tpo_vnt` varchar(30) COLLATE utf8mb4_spanish2_ci NOT NULL,
  `fch_rva` date NOT NULL,
  `fch_ent` date NOT NULL,
  `fch_sal` date NOT NULL,
  `origen` varchar(30) COLLATE utf8mb4_spanish2_ci DEFAULT NULL,
  `prc_desc` float DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish2_ci;

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `clientes`
--
ALTER TABLE `clientes`
  ADD PRIMARY KEY (`dni_pasaporte`);

--
-- Indices de la tabla `empleados`
--
ALTER TABLE `empleados`
  ADD PRIMARY KEY (`dni`);

--
-- Indices de la tabla `habitaciones`
--
ALTER TABLE `habitaciones`
  ADD PRIMARY KEY (`cod`);

--
-- Indices de la tabla `plan_ventas`
--
ALTER TABLE `plan_ventas`
  ADD PRIMARY KEY (`tipo`);

--
-- Indices de la tabla `reservas`
--
ALTER TABLE `reservas`
  ADD PRIMARY KEY (`cod_rva`),
  ADD UNIQUE KEY `uk_reservas` (`cod_hab`,`dni_cli`,`dni_emp`,`tpo_vnt`,`fch_ent`,`fch_sal`) USING BTREE,
  ADD KEY `dni_emp` (`dni_emp`),
  ADD KEY `dni_cli` (`dni_cli`),
  ADD KEY `tpo_vnt` (`tpo_vnt`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `reservas`
--
ALTER TABLE `reservas`
  MODIFY `cod_rva` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=1;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `reservas`
--
ALTER TABLE `reservas`
  ADD CONSTRAINT `reservas_ibfk_1` FOREIGN KEY (`dni_emp`) REFERENCES `empleados` (`dni`),
  ADD CONSTRAINT `reservas_ibfk_2` FOREIGN KEY (`dni_cli`) REFERENCES `clientes` (`dni_pasaporte`),
  ADD CONSTRAINT `reservas_ibfk_3` FOREIGN KEY (`cod_hab`) REFERENCES `habitaciones` (`cod`),
  ADD CONSTRAINT `reservas_ibfk_4` FOREIGN KEY (`tpo_vnt`) REFERENCES `plan_ventas` (`tipo`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
