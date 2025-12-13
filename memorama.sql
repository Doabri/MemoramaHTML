-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: localhost    Database: memorama
-- ------------------------------------------------------
-- Server version	8.1.0

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
-- Table structure for table `conceptos_html`
--

DROP TABLE IF EXISTS `conceptos_html`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `conceptos_html` (
  `id_concepto` int NOT NULL AUTO_INCREMENT,
  `termino` varchar(100) NOT NULL,
  `definicion` text NOT NULL,
  `categoria` varchar(50) NOT NULL,
  `ejemplo` text,
  PRIMARY KEY (`id_concepto`),
  UNIQUE KEY `uk_termino` (`termino`),
  KEY `idx_categoria` (`categoria`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `conceptos_html`
--

LOCK TABLES `conceptos_html` WRITE;
/*!40000 ALTER TABLE `conceptos_html` DISABLE KEYS */;
INSERT INTO `conceptos_html` VALUES (1,'<!DOCTYPE html>','Declaración que especifica la versión de HTML','estructura','<!DOCTYPE html>'),(2,'<html>','Elemento raíz que contiene todo el documento HTML','estructura','<html lang=\"es\">...</html>'),(3,'<head>','Contenedor para metadatos sobre el documento','estructura','<head><title>Mi página</title></head>'),(4,'<body>','Contiene todo el contenido visible de la página','estructura','<body><h1>Hola Mundo</h1></body>'),(5,'<h1> a <h6>','Etiquetas para encabezados','texto','<h1>Título</h1>'),(6,'<p>','Define un párrafo','texto','<p>Texto.</p>'),(7,'<a>','Define un hipervínculo','enlaces','<a href=\"https://ejemplo.com\">Enlace</a>'),(8,'<img>','Inserta una imagen','multimedia','<img src=\"imagen.jpg\" alt=\"Descripción\">'),(9,'<form>','Crea un formulario','formularios','<form action=\"/submit\"></form>'),(10,'<header>','Define una cabecera de sitio','semantica','<header><h1>Mi Sitio</h1></header>');
/*!40000 ALTER TABLE `conceptos_html` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `estadisticas_conceptos`
--

DROP TABLE IF EXISTS `estadisticas_conceptos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `estadisticas_conceptos` (
  `id_estadistica` int NOT NULL AUTO_INCREMENT,
  `id_concepto` int NOT NULL,
  `total_intentos` int DEFAULT '0',
  `total_aciertos` int DEFAULT '0',
  `tiempo_promedio_respuesta` float DEFAULT '0',
  `ultima_respuesta` datetime DEFAULT NULL,
  PRIMARY KEY (`id_estadistica`),
  KEY `idx_concepto` (`id_concepto`),
  KEY `idx_ultima_respuesta` (`ultima_respuesta`),
  CONSTRAINT `fk_concepto_estadistica` FOREIGN KEY (`id_concepto`) REFERENCES `conceptos_html` (`id_concepto`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `estadisticas_conceptos`
--

LOCK TABLES `estadisticas_conceptos` WRITE;
/*!40000 ALTER TABLE `estadisticas_conceptos` DISABLE KEYS */;
/*!40000 ALTER TABLE `estadisticas_conceptos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `partida_conceptos`
--

DROP TABLE IF EXISTS `partida_conceptos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `partida_conceptos` (
  `id_partida_concepto` int NOT NULL AUTO_INCREMENT,
  `id_resultado` int NOT NULL,
  `id_concepto` int NOT NULL,
  PRIMARY KEY (`id_partida_concepto`),
  KEY `idx_resultado_concepto` (`id_resultado`),
  KEY `fk_partida_concepto` (`id_concepto`),
  CONSTRAINT `fk_partida_concepto` FOREIGN KEY (`id_concepto`) REFERENCES `conceptos_html` (`id_concepto`) ON DELETE CASCADE,
  CONSTRAINT `fk_partida_resultado` FOREIGN KEY (`id_resultado`) REFERENCES `resultados_memorama` (`id_resultado`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=49 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `partida_conceptos`
--

LOCK TABLES `partida_conceptos` WRITE;
/*!40000 ALTER TABLE `partida_conceptos` DISABLE KEYS */;
INSERT INTO `partida_conceptos` VALUES (1,1,3),(2,1,5),(3,1,7),(4,1,2),(5,1,10),(6,1,9),(7,2,2),(8,2,6),(9,2,1),(10,2,7),(11,2,8),(12,2,4),(13,3,9),(14,3,3),(15,3,1),(16,3,2),(17,3,7),(18,3,10),(19,4,4),(20,4,3),(21,4,1),(22,4,10),(23,4,5),(24,4,6),(25,5,9),(26,5,7),(27,5,6),(28,5,10),(29,5,2),(30,5,3),(31,6,9),(32,6,1),(33,6,6),(34,6,5),(35,6,4),(36,6,8),(37,7,5),(38,7,2),(39,7,7),(40,7,1),(41,7,6),(42,7,8),(43,8,2),(44,8,10),(45,8,9),(46,8,8),(47,8,3),(48,8,5);
/*!40000 ALTER TABLE `partida_conceptos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `resultados_memorama`
--

DROP TABLE IF EXISTS `resultados_memorama`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `resultados_memorama` (
  `id_resultado` int NOT NULL AUTO_INCREMENT,
  `id_usuario` int DEFAULT NULL,
  `fecha_partida` datetime DEFAULT CURRENT_TIMESTAMP,
  `tiempo_segundos` int NOT NULL,
  `errores` int NOT NULL DEFAULT '0',
  `pares_encontrados` int NOT NULL DEFAULT '0',
  `total_pares` int NOT NULL DEFAULT '0',
  `categoria` varchar(50) DEFAULT NULL,
  `puntuacion` int DEFAULT NULL,
  PRIMARY KEY (`id_resultado`),
  KEY `idx_fecha` (`fecha_partida`),
  KEY `idx_categoria_res` (`categoria`),
  KEY `idx_puntuacion` (`puntuacion`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `resultados_memorama`
--

LOCK TABLES `resultados_memorama` WRITE;
/*!40000 ALTER TABLE `resultados_memorama` DISABLE KEYS */;
INSERT INTO `resultados_memorama` VALUES (1,NULL,'2025-12-10 18:41:28',51,10,6,6,'HTML',NULL),(2,NULL,'2025-12-10 18:43:13',59,10,6,6,'HTML',NULL),(3,NULL,'2025-12-10 22:58:04',65,13,6,6,'HTML',NULL),(4,NULL,'2025-12-11 08:38:34',108,25,6,6,'HTML',NULL),(5,NULL,'2025-12-11 08:40:45',57,13,6,6,'HTML',NULL),(6,NULL,'2025-12-11 09:04:14',44,6,6,6,'HTML',NULL),(7,NULL,'2025-12-11 09:05:21',56,11,6,6,'HTML',NULL),(8,NULL,'2025-12-11 09:27:51',34,6,6,6,'HTML',NULL);
/*!40000 ALTER TABLE `resultados_memorama` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `v_cartas`
--

DROP TABLE IF EXISTS `v_cartas`;
/*!50001 DROP VIEW IF EXISTS `v_cartas`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `v_cartas` AS SELECT 
 1 AS `concept_id`,
 1 AS `card_id`,
 1 AS `tipo`,
 1 AS `contenido`,
 1 AS `categoria`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `v_resultado_resumen`
--

DROP TABLE IF EXISTS `v_resultado_resumen`;
/*!50001 DROP VIEW IF EXISTS `v_resultado_resumen`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `v_resultado_resumen` AS SELECT 
 1 AS `id_resultado`,
 1 AS `id_usuario`,
 1 AS `fecha_partida`,
 1 AS `tiempo_segundos`,
 1 AS `tiempo_hms`,
 1 AS `errores`,
 1 AS `pares_encontrados`,
 1 AS `total_pares`,
 1 AS `tiempo_promedio_por_par_seg`,
 1 AS `eficiencia_pct`,
 1 AS `puntuacion`*/;
SET character_set_client = @saved_cs_client;

--
-- Final view structure for view `v_cartas`
--

/*!50001 DROP VIEW IF EXISTS `v_cartas`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `v_cartas` AS select `conceptos_html`.`id_concepto` AS `concept_id`,concat('T_',`conceptos_html`.`id_concepto`) AS `card_id`,'termino' AS `tipo`,`conceptos_html`.`termino` AS `contenido`,`conceptos_html`.`categoria` AS `categoria` from `conceptos_html` union all select `conceptos_html`.`id_concepto` AS `concept_id`,concat('D_',`conceptos_html`.`id_concepto`) AS `card_id`,'definicion' AS `tipo`,`conceptos_html`.`definicion` AS `contenido`,`conceptos_html`.`categoria` AS `categoria` from `conceptos_html` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `v_resultado_resumen`
--

/*!50001 DROP VIEW IF EXISTS `v_resultado_resumen`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `v_resultado_resumen` AS select `r`.`id_resultado` AS `id_resultado`,`r`.`id_usuario` AS `id_usuario`,`r`.`fecha_partida` AS `fecha_partida`,`r`.`tiempo_segundos` AS `tiempo_segundos`,sec_to_time(`r`.`tiempo_segundos`) AS `tiempo_hms`,`r`.`errores` AS `errores`,`r`.`pares_encontrados` AS `pares_encontrados`,`r`.`total_pares` AS `total_pares`,(case when (`r`.`pares_encontrados` > 0) then round((`r`.`tiempo_segundos` / `r`.`pares_encontrados`),2) else NULL end) AS `tiempo_promedio_por_par_seg`,(case when (`r`.`total_pares` > 0) then round(((100 * `r`.`pares_encontrados`) / `r`.`total_pares`),2) else 0 end) AS `eficiencia_pct`,`r`.`puntuacion` AS `puntuacion` from `resultados_memorama` `r` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-12-12 21:35:04
