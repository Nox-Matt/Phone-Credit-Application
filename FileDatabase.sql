-- MySQL dump 10.13  Distrib 8.0.29, for Win64 (x86_64)
--
-- Host: localhost    Database: dbltokopulsa
-- ------------------------------------------------------
-- Server version	5.7.38-log

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
-- Table structure for table `tblpaket`
--

DROP TABLE IF EXISTS `tblpaket`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tblpaket` (
  `ID_Paket` varchar(45) NOT NULL,
  `ID_Provider` int(11) NOT NULL,
  `Nama_Paket` varchar(225) NOT NULL,
  `Jumlah_Pulsa` varchar(45) NOT NULL,
  `ID_Penjual` int(11) NOT NULL,
  `Status` varchar(45) NOT NULL,
  PRIMARY KEY (`ID_Paket`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblpaket`
--

LOCK TABLES `tblpaket` WRITE;
/*!40000 ALTER TABLE `tblpaket` DISABLE KEYS */;
INSERT INTO `tblpaket` VALUES ('20',1,'Loopers','20000',100,'Tersedia'),('21',1,'Sakti','30000',101,'Tersedia'),('22',1,'Mingguan','15000',102,'Tersedia'),('23',1,'OMG','50000',103,'Tidak Tersedia'),('24',2,'Mantap','20000',150,'Tersedia');
/*!40000 ALTER TABLE `tblpaket` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblpenjual`
--

DROP TABLE IF EXISTS `tblpenjual`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tblpenjual` (
  `ID_Penjual` int(11) NOT NULL,
  `First_Name` varchar(45) NOT NULL,
  `Last_Name` varchar(225) NOT NULL,
  `Nomor_HP` varchar(45) NOT NULL,
  `Lokasi_Toko` varchar(45) NOT NULL,
  PRIMARY KEY (`ID_Penjual`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblpenjual`
--

LOCK TABLES `tblpenjual` WRITE;
/*!40000 ALTER TABLE `tblpenjual` DISABLE KEYS */;
INSERT INTO `tblpenjual` VALUES (100,'Ahmad','Danny','+629089696124','Medan'),(101,'Aditya','Mentari','+625908853509','Jakarta Barat'),(102,'Beni','Bamantara','+62397931036014','Jakarta Timur'),(103,'Agung','Baskara','+6249696544403','Tangerang'),(104,'Bagas','Biantara','+622699479911','Bekasi'),(105,'Bimo','Bahuwiraya','+62470560134099','Tambun'),(106,'Cakra','Cahaya','+6244649499447','Bogor'),(107,'Candra','Windrawan','+6238422283985','Tebet'),(108,'Darsa','Santoso','+62273679312645','Bogor');
/*!40000 ALTER TABLE `tblpenjual` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblpesanan`
--

DROP TABLE IF EXISTS `tblpesanan`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tblpesanan` (
  `Nama_Pemesan` varchar(225) NOT NULL,
  `Nama_Paket` varchar(45) NOT NULL,
  `Nomor_HP` int(11) NOT NULL,
  PRIMARY KEY (`Nama_Pemesan`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblpesanan`
--

LOCK TABLES `tblpesanan` WRITE;
/*!40000 ALTER TABLE `tblpesanan` DISABLE KEYS */;
INSERT INTO `tblpesanan` VALUES ('Hanz','Mingguan',23211241);
/*!40000 ALTER TABLE `tblpesanan` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblprovider`
--

DROP TABLE IF EXISTS `tblprovider`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tblprovider` (
  `ID_Provider` int(11) NOT NULL,
  `Name_Provider` varchar(255) NOT NULL,
  `Asal_Provider` varchar(45) NOT NULL,
  PRIMARY KEY (`ID_Provider`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblprovider`
--

LOCK TABLES `tblprovider` WRITE;
/*!40000 ALTER TABLE `tblprovider` DISABLE KEYS */;
INSERT INTO `tblprovider` VALUES (1,'Telkomsel','Indonesia'),(2,'Indosat Ooredoo','Indonesia'),(3,'TRI','Indonesia'),(4,'XL','Indonesia'),(5,'AXIS','Indonesia'),(6,'Smartfren','Indonesia');
/*!40000 ALTER TABLE `tblprovider` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-07-15 12:56:15
