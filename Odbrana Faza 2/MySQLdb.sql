CREATE DATABASE  IF NOT EXISTS `gemsandcrystals` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `gemsandcrystals`;
-- MySQL dump 10.13  Distrib 8.0.18, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: gemsandcrystals
-- ------------------------------------------------------
-- Server version	8.0.18

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
-- Table structure for table `card`
--

DROP TABLE IF EXISTS `card`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `card` (
  `idCard` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NOT NULL,
  `Description` varchar(200) DEFAULT NULL,
  `Effect` tinyint(4) NOT NULL,
  `EffectList` varchar(200) DEFAULT NULL,
  `Spell` tinyint(4) NOT NULL,
  `Attack` int(11) DEFAULT NULL,
  `Health` int(11) DEFAULT NULL,
  `Shield` int(11) DEFAULT NULL,
  `GemsCost` int(11) NOT NULL,
  `CrystalsCost` int(11) NOT NULL,
  PRIMARY KEY (`idCard`),
  UNIQUE KEY `idCard_UNIQUE` (`idCard`),
  UNIQUE KEY `Name_UNIQUE` (`Name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `card`
--

LOCK TABLES `card` WRITE;
/*!40000 ALTER TABLE `card` DISABLE KEYS */;
/*!40000 ALTER TABLE `card` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `deck`
--

DROP TABLE IF EXISTS `deck`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `deck` (
  `idDeck` int(11) NOT NULL AUTO_INCREMENT,
  `idUser` int(11) NOT NULL,
  `Name` varchar(45) NOT NULL,
  `CardList` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`idDeck`),
  UNIQUE KEY `idDeck_UNIQUE` (`idDeck`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `deck`
--

LOCK TABLES `deck` WRITE;
/*!40000 ALTER TABLE `deck` DISABLE KEYS */;
/*!40000 ALTER TABLE `deck` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `game`
--

DROP TABLE IF EXISTS `game`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `game` (
  `idGame` int(11) NOT NULL AUTO_INCREMENT,
  `idP1` int(11) NOT NULL,
  `idP2` int(11) NOT NULL,
  `idP1Deck` int(11) NOT NULL,
  `idP2Deck` int(11) NOT NULL,
  `P1DeckCount` int(11) NOT NULL,
  `P2DeckCount` int(11) NOT NULL,
  `P1LP` int(11) NOT NULL,
  `P2LP` int(11) NOT NULL,
  `P1TableCardsList` varchar(500) DEFAULT NULL,
  `P2TableCardsList` varchar(500) DEFAULT NULL,
  `P1HandCardList` varchar(500) DEFAULT NULL,
  `P2HandCardList` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`idGame`),
  UNIQUE KEY `idGame_UNIQUE` (`idGame`),
  KEY `idP1_idx` (`idP1`),
  KEY `idP2_idx` (`idP2`),
  KEY `idP1Deck_idx` (`idP1Deck`),
  KEY `idP2Deck_idx` (`idP2Deck`),
  CONSTRAINT `idP1` FOREIGN KEY (`idP1`) REFERENCES `user` (`idUser`),
  CONSTRAINT `idP1Deck` FOREIGN KEY (`idP1Deck`) REFERENCES `deck` (`idDeck`),
  CONSTRAINT `idP2` FOREIGN KEY (`idP2`) REFERENCES `user` (`idUser`),
  CONSTRAINT `idP2Deck` FOREIGN KEY (`idP2Deck`) REFERENCES `deck` (`idDeck`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `game`
--

LOCK TABLES `game` WRITE;
/*!40000 ALTER TABLE `game` DISABLE KEYS */;
/*!40000 ALTER TABLE `game` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user` (
  `idUser` int(11) NOT NULL AUTO_INCREMENT,
  `Username` varchar(45) NOT NULL,
  `Password` varchar(45) NOT NULL,
  `Nickname` varchar(45) NOT NULL,
  `Avatar` varchar(45) DEFAULT NULL,
  `WinNo` int(11) NOT NULL,
  `LossNo` int(11) NOT NULL,
  `Rank` varchar(45) NOT NULL,
  `MyDecksList` varchar(500) DEFAULT NULL,
  `OwnedCardsList` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`idUser`),
  UNIQUE KEY `idUser_UNIQUE` (`idUser`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (1,'Kris','kriskris','Krissus','',0,0,'Not Ranked',NULL,NULL);
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'gemsandcrystals'
--

--
-- Dumping routines for database 'gemsandcrystals'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-12-26 19:12:18
