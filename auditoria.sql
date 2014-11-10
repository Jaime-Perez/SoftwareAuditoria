-- phpMyAdmin SQL Dump
-- version 3.5.1
-- http://www.phpmyadmin.net
--
-- Servidor: localhost
-- Tiempo de generación: 27-10-2014 a las 02:57:42
-- Versión del servidor: 5.5.24-log
-- Versión de PHP: 5.4.3

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Base de datos: `auditoria`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `actividades`
--

CREATE TABLE IF NOT EXISTS `actividades` (
  `cod_actividad` int(45) NOT NULL AUTO_INCREMENT,
  `nombre_actividad` varchar(45) NOT NULL,
  `descripcion_actividad` varchar(45) NOT NULL,
  `objetivos_cod_objetivo` int(45) NOT NULL,
  PRIMARY KEY (`cod_actividad`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=3 ;

--
-- Volcado de datos para la tabla `actividades`
--

INSERT INTO `actividades` (`cod_actividad`, `nombre_actividad`, `descripcion_actividad`, `objetivos_cod_objetivo`) VALUES
(2, 'Evaluar', 'dsdasds', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `areas`
--

CREATE TABLE IF NOT EXISTS `areas` (
  `cod_area` int(45) NOT NULL AUTO_INCREMENT,
  `nombre_area` varchar(45) NOT NULL,
  `descripcion_area` varchar(45) NOT NULL,
  PRIMARY KEY (`cod_area`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=3 ;

--
-- Volcado de datos para la tabla `areas`
--

INSERT INTO `areas` (`cod_area`, `nombre_area`, `descripcion_area`) VALUES
(2, 'hjgh', 'fgjo');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `auditoria`
--

CREATE TABLE IF NOT EXISTS `auditoria` (
  `cod_auditoria` int(45) NOT NULL AUTO_INCREMENT,
  `empresa_cod_empresa` int(45) NOT NULL,
  `actividades_cod_actividad` int(45) NOT NULL,
  `responsables_cod_responsa` int(45) NOT NULL,
  `encargado_cod` int(45) NOT NULL,
  `ponderacion` varchar(45) NOT NULL,
  PRIMARY KEY (`cod_auditoria`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=3 ;

--
-- Volcado de datos para la tabla `auditoria`
--

INSERT INTO `auditoria` (`cod_auditoria`, `empresa_cod_empresa`, `actividades_cod_actividad`, `responsables_cod_responsa`, `encargado_cod`, `ponderacion`) VALUES
(1, 25, 2, 0, 2, '2');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `empresa`
--

CREATE TABLE IF NOT EXISTS `empresa` (
  `cod_empresa` int(45) NOT NULL AUTO_INCREMENT,
  `nombre_empresa` varchar(45) NOT NULL,
  `direccion_empresa` varchar(45) NOT NULL,
  `telefono_empresa` varchar(45) NOT NULL,
  `correo_empresa` varchar(45) NOT NULL,
  `nombre_encargado` varchar(45) NOT NULL,
  PRIMARY KEY (`cod_empresa`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=3 ;

--
-- Volcado de datos para la tabla `empresa`
--

INSERT INTO `empresa` (`cod_empresa`, `nombre_empresa`, `direccion_empresa`, `telefono_empresa`, `correo_empresa`, `nombre_encargado`) VALUES
(2, 'ADST', 's', 'asd', 'as', 'fg');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `encargado`
--

CREATE TABLE IF NOT EXISTS `encargado` (
  `cod_encargado` int(45) NOT NULL AUTO_INCREMENT,
  `nombre_encargado` varchar(45) NOT NULL,
  `telefono_encargado` varchar(45) NOT NULL,
  `correo_encargado` varchar(45) NOT NULL,
  `rol_encargado` varchar(45) NOT NULL,
  PRIMARY KEY (`cod_encargado`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=3 ;

--
-- Volcado de datos para la tabla `encargado`
--

INSERT INTO `encargado` (`cod_encargado`, `nombre_encargado`, `telefono_encargado`, `correo_encargado`, `rol_encargado`) VALUES
(2, 'luis', 'dfddsf', 'dsfdsf', 'sd');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `herramientas`
--

CREATE TABLE IF NOT EXISTS `herramientas` (
  `cod_herramientas` int(45) NOT NULL AUTO_INCREMENT,
  `nombre_herramientas` varchar(45) NOT NULL,
  `descripcion_herramientas` varchar(45) NOT NULL,
  PRIMARY KEY (`cod_herramientas`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=4 ;

--
-- Volcado de datos para la tabla `herramientas`
--

INSERT INTO `herramientas` (`cod_herramientas`, `nombre_herramientas`, `descripcion_herramientas`) VALUES
(3, 'Diccionariodsfdf', 'dfdsf');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `herramientas_asignadas`
--

CREATE TABLE IF NOT EXISTS `herramientas_asignadas` (
  `cod_herramientas_asignadas` int(45) NOT NULL AUTO_INCREMENT,
  `herramientas_cod_herramienta` int(45) NOT NULL,
  `actividades_cod_actividad` int(45) NOT NULL,
  PRIMARY KEY (`cod_herramientas_asignadas`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=2 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `normas`
--

CREATE TABLE IF NOT EXISTS `normas` (
  `cod_norma` int(45) NOT NULL AUTO_INCREMENT,
  `nombre_norma` varchar(45) NOT NULL,
  `descripcion_norma` varchar(45) NOT NULL,
  `valoracion_norma` varchar(45) NOT NULL,
  PRIMARY KEY (`cod_norma`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=3 ;

--
-- Volcado de datos para la tabla `normas`
--

INSERT INTO `normas` (`cod_norma`, `nombre_norma`, `descripcion_norma`, `valoracion_norma`) VALUES
(2, 'as', 'ddsf', 'gfh');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `objetivos`
--

CREATE TABLE IF NOT EXISTS `objetivos` (
  `cod_objetivo` int(45) NOT NULL AUTO_INCREMENT,
  `nombre_objetivo` varchar(45) NOT NULL,
  `objetivoscol` varchar(45) NOT NULL,
  `normas_cod_norma` int(45) NOT NULL,
  `areas_cod_area` int(45) NOT NULL,
  PRIMARY KEY (`cod_objetivo`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=2 ;

--
-- Volcado de datos para la tabla `objetivos`
--

INSERT INTO `objetivos` (`cod_objetivo`, `nombre_objetivo`, `objetivoscol`, `normas_cod_norma`, `areas_cod_area`) VALUES
(1, 'qwekk', 'asdll', 2, 2);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `responsables`
--

CREATE TABLE IF NOT EXISTS `responsables` (
  `cod_responsable` int(45) NOT NULL AUTO_INCREMENT,
  `nombre_responsable` varchar(45) NOT NULL,
  `telefono_responsable` varchar(45) NOT NULL,
  `correo_responsable` varchar(45) NOT NULL,
  `rol_responsable` varchar(45) NOT NULL,
  PRIMARY KEY (`cod_responsable`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=3 ;

--
-- Volcado de datos para la tabla `responsables`
--

INSERT INTO `responsables` (`cod_responsable`, `nombre_responsable`, `telefono_responsable`, `correo_responsable`, `rol_responsable`) VALUES
(2, 'Marco', '111', 'dfsd', 'd');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuarios`
--

CREATE TABLE IF NOT EXISTS `usuarios` (
  `id_emple_us` int(45) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(45) NOT NULL,
  `contrasena` varchar(45) NOT NULL,
  PRIMARY KEY (`id_emple_us`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=4 ;

--
-- Volcado de datos para la tabla `usuarios`
--

INSERT INTO `usuarios` (`id_emple_us`, `nombre`, `contrasena`) VALUES
(1, 'mario', '123'),
(2, 'adst', '789');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
