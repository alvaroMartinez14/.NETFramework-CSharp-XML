-- phpMyAdmin SQL Dump
-- version 3.5.1
-- http://www.phpmyadmin.net
--
-- Servidor: localhost
-- Tiempo de generación: 26-02-2021 a las 09:10:37
-- Versión del servidor: 5.5.24-log
-- Versión de PHP: 5.4.3

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Base de datos: `martineza`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cliente`
--

CREATE TABLE IF NOT EXISTS `cliente` (
  `id_cli` int(10) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) NOT NULL,
  `dni` varchar(20) NOT NULL,
  `num_cuenta` varchar(50) NOT NULL,
  `pais` varchar(50) NOT NULL,
  `direccion` varchar(50) NOT NULL,
  `telefono` int(20) NOT NULL,
  `email` varchar(50) NOT NULL,
  PRIMARY KEY (`id_cli`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=3 ;

--
-- Volcado de datos para la tabla `cliente`
--

INSERT INTO `cliente` (`id_cli`, `nombre`, `dni`, `num_cuenta`, `pais`, `direccion`, `telefono`, `email`) VALUES
(1, 'Jacobo', '67890645D', 'ES245678768576', 'España', 'Abrantes', 654324567, 'jacobo@gmail.com'),
(2, 'Pedro', '34546768P', 'ES245374463', 'Portugal', 'Coimbra', 654789087, 'pedro@gmail.com');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `logueo`
--

CREATE TABLE IF NOT EXISTS `logueo` (
  `usuario` varchar(50) NOT NULL,
  `password` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `logueo`
--

INSERT INTO `logueo` (`usuario`, `password`) VALUES
('alvaro', 'd44b121fc3524fe5cdc4f3feb31ceb78'),
('juan', '70b783251225354e883a5bef3c011843'),
('david', '1145cbf42070c6704b66d6ac75347726'),
('pedro', '90f077d7759d0d4d21e6867727d4b2bd');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `producto`
--

CREATE TABLE IF NOT EXISTS `producto` (
  `id_producto` int(10) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) NOT NULL,
  `categoria` varchar(50) NOT NULL,
  `cantidad` int(10) NOT NULL,
  `precio` int(10) NOT NULL,
  `iva` int(10) NOT NULL,
  PRIMARY KEY (`id_producto`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=11 ;

--
-- Volcado de datos para la tabla `producto`
--

INSERT INTO `producto` (`id_producto`, `nombre`, `categoria`, `cantidad`, `precio`, `iva`) VALUES
(1, 'Radiador', 'Climatizacion', 6, 120, 21),
(2, 'Lampara', 'Iluminacion', 10, 20, 15),
(5, 'Cama', 'Comfort', 4, 230, 21);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `proveedor`
--

CREATE TABLE IF NOT EXISTS `proveedor` (
  `id` int(10) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) NOT NULL,
  `cif` varchar(50) NOT NULL,
  `direccion` varchar(50) NOT NULL,
  `provincia` varchar(50) NOT NULL,
  `localidad` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=10 ;

--
-- Volcado de datos para la tabla `proveedor`
--

INSERT INTO `proveedor` (`id`, `nombre`, `cif`, `direccion`, `provincia`, `localidad`) VALUES
(1, 'Lurca', 'G34637 ', 'Abrantes', 'Madrid', 'Madrid'),
(5, 'Unosa', 'B56789', 'Oporto', 'Madrid', 'Madrid'),
(7, 'Famosa', 'K65432', 'Chimbo', 'Madrid', 'Madrid'),
(9, 'Ruinosa', 'E34521', 'Lusitana', 'Madrid', 'Madrid');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
