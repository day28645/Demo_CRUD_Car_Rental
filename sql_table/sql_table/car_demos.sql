CREATE DATABASE  IF NOT EXISTS `car_demos` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `car_demos`;
-- MySQL dump 10.13  Distrib 8.0.31, for Win64 (x86_64)
--
-- Host: localhost    Database: car_demos
-- ------------------------------------------------------
-- Server version	8.0.31

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
-- Table structure for table `booking`
--

DROP TABLE IF EXISTS `booking`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `booking` (
  `Book_Id` int NOT NULL AUTO_INCREMENT,
  `book_status` varchar(50) DEFAULT NULL,
  `pick_datetime` datetime NOT NULL,
  `return_datetime` datetime NOT NULL,
  `total_price` float(10,2) DEFAULT NULL,
  `cancel_fee` float(10,2) DEFAULT NULL,
  `duration` int NOT NULL,
  `Pick_Id` int NOT NULL,
  `Return_Id` int NOT NULL,
  PRIMARY KEY (`Book_Id`)
) ENGINE=InnoDB AUTO_INCREMENT=132 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `booking`
--

LOCK TABLES `booking` WRITE;
/*!40000 ALTER TABLE `booking` DISABLE KEYS */;
INSERT INTO `booking` VALUES (108,'cancel completed','2024-11-09 04:33:00','2024-11-09 20:33:00',1000.00,500.00,1,2,2),(109,'paid','2024-11-10 04:33:00','2024-11-10 21:33:00',1000.00,500.00,1,6,6),(110,'paid','2024-11-07 04:34:00','2024-11-07 21:34:00',1000.00,500.00,1,7,7),(113,'return','2024-11-08 04:48:00','2024-11-08 10:48:00',1000.00,0.00,1,1,1),(115,'paid','2024-11-08 14:48:00','2024-11-08 20:48:00',1000.00,500.00,1,1,1),(117,'pick','2024-11-08 20:50:00','2024-11-08 23:29:00',1000.00,0.00,1,1,1),(123,'paid','2024-11-07 11:55:00','2024-11-07 23:55:00',1000.00,500.00,1,1,1),(124,'paid','2024-11-08 11:55:00','2024-11-08 23:55:00',1000.00,500.00,1,1,1),(125,'paid','2024-11-09 08:56:00','2024-11-09 20:56:00',1000.00,500.00,1,2,2),(126,'paid','2024-11-10 07:56:00','2024-11-10 21:56:00',1000.00,500.00,1,6,6),(127,'paid','2024-11-07 00:12:00','2024-11-07 22:12:00',1000.00,500.00,1,2,6),(128,'paid','2024-11-08 09:12:00','2024-11-08 21:12:00',1000.00,500.00,1,6,1),(129,'cancel completed','2024-11-09 09:13:00','2024-11-09 22:13:00',2000.00,1000.00,1,3,9),(130,'paid','2024-11-10 10:13:00','2024-11-10 21:14:00',2000.00,1000.00,1,3,7),(131,'paid','2024-11-11 06:14:00','2024-11-11 21:14:00',2000.00,1000.00,1,9,1);
/*!40000 ALTER TABLE `booking` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cancel_booking`
--

DROP TABLE IF EXISTS `cancel_booking`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cancel_booking` (
  `Id_Card` int NOT NULL,
  `Book_Id` int NOT NULL,
  `Chassis_No` varchar(17) NOT NULL,
  `cancel_datetime` datetime NOT NULL,
  PRIMARY KEY (`Id_Card`,`Book_Id`,`Chassis_No`),
  KEY `Book_Id` (`Book_Id`),
  KEY `Chassis_No` (`Chassis_No`),
  CONSTRAINT `cancel_booking_ibfk_1` FOREIGN KEY (`Id_Card`) REFERENCES `users` (`Id_Card`),
  CONSTRAINT `cancel_booking_ibfk_2` FOREIGN KEY (`Book_Id`) REFERENCES `booking` (`Book_Id`),
  CONSTRAINT `cancel_booking_ibfk_3` FOREIGN KEY (`Chassis_No`) REFERENCES `car` (`Chassis_No`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cancel_booking`
--

LOCK TABLES `cancel_booking` WRITE;
/*!40000 ALTER TABLE `cancel_booking` DISABLE KEYS */;
INSERT INTO `cancel_booking` VALUES (14,108,'B1','2024-11-06 19:37:45'),(14,129,'Y001','2024-11-07 13:34:40');
/*!40000 ALTER TABLE `cancel_booking` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `car`
--

DROP TABLE IF EXISTS `car`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `car` (
  `Chassis_No` varchar(17) NOT NULL,
  `brand` varchar(255) NOT NULL,
  `model` varchar(255) NOT NULL,
  `car_type` varchar(255) NOT NULL,
  `color` varchar(50) NOT NULL,
  `fuel` varchar(50) NOT NULL,
  `image` varchar(255) NOT NULL,
  `rent_price` float(10,2) NOT NULL,
  `car_book_no` varchar(255) NOT NULL,
  `price` float(10,2) NOT NULL,
  `car_status` varchar(50) NOT NULL,
  `register_datetime` datetime NOT NULL,
  `regis_no` varchar(50) NOT NULL,
  `regis_date` date NOT NULL,
  `car_owner` varchar(50) NOT NULL,
  `Id_Card` int NOT NULL,
  PRIMARY KEY (`Chassis_No`),
  KEY `Id_Card` (`Id_Card`),
  CONSTRAINT `car_ibfk_1` FOREIGN KEY (`Id_Card`) REFERENCES `users` (`Id_Card`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `car`
--

LOCK TABLES `car` WRITE;
/*!40000 ALTER TABLE `car` DISABLE KEYS */;
INSERT INTO `car` VALUES ('A1','Toyota','A1','Sedan','Black','Diesel','~/Images/capybara.jpg',1000.00,'A1',10000.00,'Reserved','2024-11-06 13:45:05','A1','2024-11-07','A1',12),('aaa001','Honda','aaa01','Sedan','White','Diesel','~/Images/Baby_penguin.jpg',1000.00,'aaa01',10000.00,'Ready','2024-11-01 15:23:19','aaa','2024-11-01','aaa01',12),('B1','Honda','B1','Sport','Grey','EV','~/Images/catty.jpg',1000.00,'B1',20000.00,'Ready','2024-11-06 13:45:37','B1','2024-10-31','B1',12),('bbb001','Benz','bbb01','Sport','Black','Benzin','~/Images/chicken.jpg',1000.00,'bbb01',10000.00,'Ready','2024-11-01 15:23:52','bbb','2024-11-07','bbb001',12),('C1','Benz','C1','SUV','Black','Diesel','~/Images/monkey.jpg',1000.00,'C1',10000.00,'Ready','2024-11-06 13:46:05','C1','2024-11-09','C1',12),('ccc0001','Honda','ccc001','SUV','Grey','Diesel','~/Images/shiba.jpg',1000.00,'ccc01',10000.00,'Ready','2024-11-01 15:24:20','ccc','2024-11-05','ccc01',12),('D1','Toyota','D1','Sport','Grey','Diesel','~/Images/moo_deng.jpg',1000.00,'D1',10000.00,'Ready','2024-11-06 13:46:36','D1','2024-09-12','D1',12),('ddd001','Toyota','ddd01','Sport','Grey','Benzin','~/Images/catty.jpg',1000.00,'ddd01',10000.00,'Ready','2024-11-01 15:24:53','ddd','2024-11-01','ddd01',12),('E1','Toyota','E1','SUV','White','Diesel','~/Images/Baby_penguin.jpg',1000.00,'E1',10000.00,'Ready','2024-11-06 13:47:05','E1','2024-08-08','E1',12),('eee0001','BMW','eee01','Sedan','Grey','Benzin','~/Images/monkey.jpg',1000.00,'eee01',10000.00,'Ready','2024-11-01 15:25:19','eee','2024-11-09','eee01',12),('K001','Benz','K001','SUV','Black','Diesel','~/Images/trump.jpg',1000.00,'K001',10000.00,'Ready','2024-11-07 12:07:33','K001','2024-10-31','K001',12),('W001','Toyota','W001','Sport','Black','Diesel','~/Images/trump.jpg',2000.00,'W001',20000.00,'Ready','2024-11-07 12:10:44','W001','2024-10-17','W001',12),('X001','Honda','X001','Sedan','Grey','Diesel','~/Images/trump.jpg',1000.00,'X001',10000.00,'Ready','2024-11-07 12:08:08','X001','2024-11-08','X001',12),('Y001','BMW','Y001','Sport','White','Benzin','~/Images/trump.jpg',2000.00,'Y001',30000.00,'Ready','2024-11-07 12:09:34','Y001','2024-11-10','Y001',12),('Z001','Benz','Z001','Sport','White','Diesel','~/Images/trump.jpg',2000.00,'Z001',20000.00,'Ready','2024-11-07 12:10:13','Z001','2024-10-30','Z001',12);
/*!40000 ALTER TABLE `car` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `car_history`
--

DROP TABLE IF EXISTS `car_history`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `car_history` (
  `History_Id` int NOT NULL AUTO_INCREMENT,
  `regis_no` varchar(50) DEFAULT NULL,
  `car_owner` varchar(50) DEFAULT NULL,
  `car_status` varchar(50) DEFAULT NULL,
  `rent_price` float(10,2) DEFAULT NULL,
  `history_datetime` datetime NOT NULL,
  `Id_Card` int NOT NULL,
  `Chassis_No` varchar(17) NOT NULL,
  PRIMARY KEY (`History_Id`),
  KEY `Id_Card` (`Id_Card`),
  KEY `Chassis_No` (`Chassis_No`),
  CONSTRAINT `car_history_ibfk_1` FOREIGN KEY (`Id_Card`) REFERENCES `users` (`Id_Card`),
  CONSTRAINT `car_history_ibfk_2` FOREIGN KEY (`Chassis_No`) REFERENCES `car` (`Chassis_No`)
) ENGINE=InnoDB AUTO_INCREMENT=47 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `car_history`
--

LOCK TABLES `car_history` WRITE;
/*!40000 ALTER TABLE `car_history` DISABLE KEYS */;
/*!40000 ALTER TABLE `car_history` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `create_booking`
--

DROP TABLE IF EXISTS `create_booking`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `create_booking` (
  `Id_Card` int NOT NULL,
  `Book_Id` int NOT NULL,
  `Chassis_No` varchar(17) NOT NULL,
  `book_datetime` datetime NOT NULL,
  `checkin_datetime` datetime DEFAULT NULL,
  `checkout_datetime` datetime DEFAULT NULL,
  PRIMARY KEY (`Id_Card`,`Book_Id`,`Chassis_No`),
  KEY `Book_Id` (`Book_Id`),
  KEY `Chassis_No` (`Chassis_No`),
  CONSTRAINT `create_booking_ibfk_1` FOREIGN KEY (`Id_Card`) REFERENCES `users` (`Id_Card`),
  CONSTRAINT `create_booking_ibfk_2` FOREIGN KEY (`Book_Id`) REFERENCES `booking` (`Book_Id`),
  CONSTRAINT `create_booking_ibfk_3` FOREIGN KEY (`Chassis_No`) REFERENCES `car` (`Chassis_No`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `create_booking`
--

LOCK TABLES `create_booking` WRITE;
/*!40000 ALTER TABLE `create_booking` DISABLE KEYS */;
INSERT INTO `create_booking` VALUES (11,109,'D1','2024-11-06 16:34:04',NULL,NULL),(11,110,'E1','2024-11-06 16:34:29',NULL,NULL),(11,113,'A1','2024-11-06 16:48:24','2024-11-06 16:50:31','2024-11-06 19:34:30'),(11,115,'A1','2024-11-06 16:49:02',NULL,NULL),(11,117,'A1','2024-11-06 19:29:30','2024-11-06 19:34:56',NULL),(11,123,'aaa001','2024-11-07 11:55:26',NULL,NULL),(11,124,'aaa001','2024-11-07 11:56:00',NULL,NULL),(11,125,'bbb001','2024-11-07 11:56:40',NULL,NULL),(11,126,'ddd001','2024-11-07 11:57:21',NULL,NULL),(11,127,'K001','2024-11-07 12:12:30',NULL,NULL),(11,128,'X001','2024-11-07 12:13:03',NULL,NULL),(11,130,'W001','2024-11-07 12:14:14',NULL,NULL),(11,131,'W001','2024-11-07 12:14:42',NULL,NULL);
/*!40000 ALTER TABLE `create_booking` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `location`
--

DROP TABLE IF EXISTS `location`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `location` (
  `Location_Id` int NOT NULL AUTO_INCREMENT,
  `location_name` varchar(255) NOT NULL,
  `location_address` varchar(255) NOT NULL,
  `add_loc_datetime` datetime NOT NULL,
  `Id_Card` int NOT NULL,
  PRIMARY KEY (`Location_Id`),
  KEY `Id_Card` (`Id_Card`),
  CONSTRAINT `location_ibfk_1` FOREIGN KEY (`Id_Card`) REFERENCES `users` (`Id_Card`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `location`
--

LOCK TABLES `location` WRITE;
/*!40000 ALTER TABLE `location` DISABLE KEYS */;
INSERT INTO `location` VALUES (1,'aaa','aa 123','2024-10-24 13:09:22',12),(2,'bbb','bb 123','2024-10-24 13:09:54',12),(3,'ccc','cc 123','2024-10-24 13:09:59',12),(6,'ddd','dd 123','2024-11-01 13:30:49',12),(7,'eee','ee 123','2024-11-01 13:31:02',12),(8,'fff','ff 123','2024-11-01 13:31:08',12),(9,'ggg','gg 123','2024-11-01 15:02:31',12);
/*!40000 ALTER TABLE `location` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `login`
--

DROP TABLE IF EXISTS `login`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `login` (
  `Login_Id` int NOT NULL AUTO_INCREMENT,
  `login_time` datetime DEFAULT NULL,
  `logout_time` datetime DEFAULT NULL,
  `Id_Card` int NOT NULL,
  PRIMARY KEY (`Login_Id`),
  KEY `Id_Card` (`Id_Card`),
  CONSTRAINT `login_ibfk_1` FOREIGN KEY (`Id_Card`) REFERENCES `users` (`Id_Card`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `login`
--

LOCK TABLES `login` WRITE;
/*!40000 ALTER TABLE `login` DISABLE KEYS */;
/*!40000 ALTER TABLE `login` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `positions`
--

DROP TABLE IF EXISTS `positions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `positions` (
  `Position_Id` int NOT NULL AUTO_INCREMENT,
  `title` varchar(20) NOT NULL,
  PRIMARY KEY (`Position_Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `positions`
--

LOCK TABLES `positions` WRITE;
/*!40000 ALTER TABLE `positions` DISABLE KEYS */;
INSERT INTO `positions` VALUES (1,'client'),(2,'manager'),(3,'officer'),(4,'admin');
/*!40000 ALTER TABLE `positions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `Id_Card` int NOT NULL,
  `passwords` varchar(8) DEFAULT NULL,
  `firstname` varchar(255) DEFAULT NULL,
  `lastname` varchar(255) DEFAULT NULL,
  `email` varchar(255) DEFAULT NULL,
  `address` varchar(255) DEFAULT NULL,
  `phone` varchar(10) DEFAULT NULL,
  `Position_Id` int DEFAULT NULL,
  PRIMARY KEY (`Id_Card`),
  KEY `Position_Id` (`Position_Id`),
  CONSTRAINT `users_ibfk_1` FOREIGN KEY (`Position_Id`) REFERENCES `positions` (`Position_Id`),
  CONSTRAINT `users_chk_1` CHECK (regexp_like(`phone`,_utf8mb4'^[0-9]{10}$'))
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (11,'11','client1','client11','client1@mail.com','client1','0298745631',1),(12,'12','manager1','manager11','manager1@mail.com','manager1','0123456789',2),(13,'13','officer1','officer11','officer1@mail.com','officer1','0958713652',3),(14,'14','admin1','admin11','admin1@mail.com','admin1','0789632545',4),(123,'123','pp','pp','a@mail.com','ss','1234567890',1),(212,'212','zzz','zzz','zzz@mail.com','212 add','0123456789',1),(789,'789','xxx','yyy','789@mail.com','789 xx yyy','0659987758',1),(1150,'1150','pizza ','company','pizza@mail.com','pizza 1150','0602451555',1),(4311,'4311','hhhh','gggg','4311@mail.com','4311 hh gg','0607571617',1),(7788,'7788','tttt','rrrr','7788@mail.com','7788 tt rrr','0604758165',1),(35705,'35705','bbbb','vvvvv','35705@mail.com','35705 bb vv','0357061423',1),(63749,'63749','wwwww','yyyyyy','63749@mail.com','63749 ww yy','0688099339',1),(98157,'98157','kkkkk','sssss','98157@mail.com','98157 kk ss','0652598175',1);
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-11-07 15:03:19
