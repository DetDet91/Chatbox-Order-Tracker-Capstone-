-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: localhost    Database: printshopordersinfo
-- ------------------------------------------------------
-- Server version	8.2.0

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
-- Table structure for table `customesprintorder`
--

DROP TABLE IF EXISTS `customesprintorder`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `customesprintorder` (
  `CustomerID` int NOT NULL AUTO_INCREMENT,
  `CustomerName` varchar(45) NOT NULL,
  `Location` varchar(45) NOT NULL,
  `PrintStatus` varchar(45) NOT NULL,
  `OrderNumber` int NOT NULL,
  PRIMARY KEY (`CustomerID`,`Location`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customesprintorder`
--

LOCK TABLES `customesprintorder` WRITE;
/*!40000 ALTER TABLE `customesprintorder` DISABLE KEYS */;
INSERT INTO `customesprintorder` VALUES (1,'Christy Pallen','Florence(Main)','Queue',90577),(2,'Marcus Times','Darlington','Shipped',90545),(3,'Pete Griffin','PrintShop','Pickup',90875),(4,'T\'Challa','Florence','Printing',90878),(5,'Bruce Wayne','Cheraw','Finishing',90448),(6,'Clark Kent','Dillon','Ready to Ship',90215),(7,'Shuri','Loris','Shipped',90778),(8,'Nakia','Seacoast','Queue',90556);
/*!40000 ALTER TABLE `customesprintorder` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `driversinfo`
--

DROP TABLE IF EXISTS `driversinfo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `driversinfo` (
  `idDriversInfo` int NOT NULL,
  `DriversName` varchar(45) NOT NULL,
  `DriversNumber` int NOT NULL,
  `Location` varchar(45) NOT NULL,
  PRIMARY KEY (`Location`,`idDriversInfo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `driversinfo`
--

LOCK TABLES `driversinfo` WRITE;
/*!40000 ALTER TABLE `driversinfo` DISABLE KEYS */;
INSERT INTO `driversinfo` VALUES (3,'Mark',3333,'Cheraw'),(7,'Marcus',7777,'Darlington'),(5,'Homer',5555,'Dillon'),(2,'Brent',2222,'Florence'),(1,'James',1111,'Florence(Main)'),(4,'Keith',4444,'Loris'),(8,'PrintShop',2979,'PrintShop'),(6,'Ty',6666,'Seacoast');
/*!40000 ALTER TABLE `driversinfo` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-11-30 13:47:49
