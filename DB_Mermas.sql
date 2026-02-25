-- Script de creación de tablas para el módulo Mermas de Hologramas en Envasados

CREATE TABLE IF NOT EXISTS `mermas_hologramas` (
  `id_merma` int(11) NOT NULL AUTO_INCREMENT,
  `no_cliente` varchar(50) DEFAULT NULL,
  `id_marca` varchar(50) DEFAULT NULL,
  `motivo` varchar(200) DEFAULT NULL,
  `total_mermas` int(11) DEFAULT NULL,
  `observaciones` text,
  `es_maquila` tinyint(1) DEFAULT '0',
  `ruta_evidencia` varchar(255) DEFAULT NULL,
  `fecha_registro` datetime DEFAULT NULL,
  `id_usuario` int(11) DEFAULT NULL,
  PRIMARY KEY (`id_merma`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE IF NOT EXISTS `mermas_hologramas_folios` (
  `id_folio` int(11) NOT NULL AUTO_INCREMENT,
  `id_merma` int(11) DEFAULT NULL,
  `folio_inicial` varchar(50) DEFAULT NULL,
  `folio_final` varchar(50) DEFAULT NULL,
  `cantidad` int(11) DEFAULT NULL,
  PRIMARY KEY (`id_folio`),
  KEY `fk_merma_folios` (`id_merma`),
  CONSTRAINT `fk_merma_folios` FOREIGN KEY (`id_merma`) REFERENCES `mermas_hologramas` (`id_merma`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
