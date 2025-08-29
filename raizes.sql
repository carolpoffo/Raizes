CREATE DATABASE  IF NOT EXISTS `raizes` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `raizes`;
-- MySQL dump 10.13  Distrib 8.0.42, for Win64 (x86_64)
--
-- Host: localhost    Database: raizes
-- ------------------------------------------------------
-- Server version	8.0.42

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
-- Table structure for table `armazenamentocolheita`
--

DROP TABLE IF EXISTS `armazenamentocolheita`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `armazenamentocolheita` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `ColheitaId` int NOT NULL,
  `QuantidadeDisponivel` decimal(10,2) NOT NULL,
  `LocalArmazenamento` varchar(100) NOT NULL,
  `DataEntrada` datetime NOT NULL,
  `DataUltimaAtualizacao` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `Status` enum('Disponivel','Reservado','Vendido') DEFAULT 'Disponivel',
  PRIMARY KEY (`Id`),
  KEY `ColheitaId` (`ColheitaId`),
  CONSTRAINT `ArmazenamentoColheita_ibfk_1` FOREIGN KEY (`ColheitaId`) REFERENCES `colheita` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=41 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `armazenamentocolheita`
--

LOCK TABLES `armazenamentocolheita` WRITE;
/*!40000 ALTER TABLE `armazenamentocolheita` DISABLE KEYS */;
INSERT INTO `armazenamentocolheita` VALUES (21,21,180.00,'Armazém Central - Lote A1','2025-01-28 00:00:00','2025-07-20 22:05:56','Disponivel'),(22,22,95.00,'Silo Oeste - Setor 2','2024-11-09 00:00:00','2025-07-20 22:05:56','Disponivel'),(23,23,520.00,'Galpão Industrial - Zona 3','2025-02-01 00:00:00','2025-07-20 22:05:56','Disponivel'),(24,24,450.00,'Silo Norte - Ala B','2025-01-01 00:00:00','2025-07-20 22:05:56','Disponivel'),(25,25,180.00,'Câmara Fria - Unidade 4','2024-08-14 00:00:00','2025-07-20 22:05:56','Vendido'),(26,26,260.00,'Galpão Municipal - Prédio 5','2024-11-07 00:00:00','2025-07-20 22:05:56','Disponivel'),(27,27,110.00,'Armazém Central - Lote A2','2025-03-29 00:00:00','2025-07-20 22:05:56','Reservado'),(28,28,420.00,'Silo Sul - Zona 1','2025-01-01 00:00:00','2025-07-20 22:05:56','Disponivel'),(29,29,3000.00,'Planta Industrial - Tanque 1','2025-09-27 00:00:00','2025-07-20 22:05:56','Vendido'),(30,30,120.00,'Galpão de Raízes - Setor C','2024-11-01 00:00:00','2025-07-20 22:05:56','Disponivel'),(31,31,210.00,'Depósito Agrícola - Bloco D','2024-12-19 00:00:00','2025-07-20 22:05:56','Disponivel'),(32,32,95.00,'Câmara Fria - Unidade 2','2024-10-14 00:00:00','2025-07-20 22:05:56','Reservado'),(33,33,230.00,'Centro de Distribuição - Ala 1','2025-01-19 00:00:00','2025-07-20 22:05:56','Disponivel'),(34,34,200.00,'Silo Leste - Compartimento 7','2025-02-28 00:00:00','2025-07-20 22:05:56','Disponivel'),(35,35,600.00,'Estoque Externo - Galpão 9','2025-04-09 00:00:00','2025-07-20 22:05:56','Vendido'),(36,36,75.00,'Depósito Experimental - Setor X','2024-12-09 00:00:00','2025-07-20 22:05:56','Disponivel'),(37,37,700.00,'Armazém Central - Lote B1','2025-02-24 00:00:00','2025-07-20 22:05:56','Disponivel'),(38,38,250.00,'Galpão Oeste - Lado 3','2024-11-30 00:00:00','2025-07-20 22:05:56','Reservado'),(39,39,130.00,'Silo Sul - Zona 2','2024-11-24 00:00:00','2025-07-20 22:05:56','Disponivel'),(40,40,210.00,'Depósito Agrícola - Bloco E','2024-10-04 00:00:00','2025-07-20 22:05:56','Vendido');
/*!40000 ALTER TABLE `armazenamentocolheita` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cidade`
--

DROP TABLE IF EXISTS `cidade`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cidade` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Nome` varchar(200) NOT NULL,
  `Estado` varchar(100) NOT NULL,
  `Regiao` varchar(100) NOT NULL,
  `Pais` varchar(100) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cidade`
--

LOCK TABLES `cidade` WRITE;
/*!40000 ALTER TABLE `cidade` DISABLE KEYS */;
INSERT INTO `cidade` VALUES (1,'Blumenau','Santa Catarina','Vale do Itajaí','Brasil'),(2,'Gaspar','Santa Catarina','Vale do Itajaí','Brasil'),(3,'Indaial','Santa Catarina','Vale do Itajaí','Brasil'),(4,'São Paulo','São Paulo','Sudeste','Brasil'),(5,'Rio de Janeiro','Rio de Janeiro','Sudeste','Brasil'),(6,'Belo Horizonte','Minas Gerais','Sudeste','Brasil'),(7,'Curitiba','Paraná','Sul','Brasil'),(8,'Porto Alegre','Rio Grande do Sul','Sul','Brasil'),(9,'Salvador','Bahia','Nordeste','Brasil'),(10,'Fortaleza','Ceará','Nordeste','Brasil'),(11,'Brasília','Distrito Federal','Centro-Oeste','Brasil'),(12,'Manaus','Amazonas','Norte','Brasil'),(13,'Belém','Pará','Norte','Brasil');
/*!40000 ALTER TABLE `cidade` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `colheita`
--

DROP TABLE IF EXISTS `colheita`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `colheita` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `PlantioId` int NOT NULL,
  `DataColheita` datetime NOT NULL,
  `Quantidade` decimal(10,2) NOT NULL,
  `UnidadeMedidaId` int DEFAULT NULL,
  `Observacao` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_Colheita_Plantio` (`PlantioId`),
  KEY `Idx_Colheita_Data` (`DataColheita`),
  KEY `fk_Colheita_UnideadeMedida_Idx` (`UnidadeMedidaId`),
  CONSTRAINT `fk_Colheita_Plantio` FOREIGN KEY (`PlantioId`) REFERENCES `plantio` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_Colheita_UnidadeMedida` FOREIGN KEY (`UnidadeMedidaId`) REFERENCES `unidademedida` (`Id`) ON DELETE SET NULL ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=41 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `colheita`
--

LOCK TABLES `colheita` WRITE;
/*!40000 ALTER TABLE `colheita` DISABLE KEYS */;
INSERT INTO `colheita` VALUES (21,11,'2025-09-20 00:00:00',180.00,1,'Colheita de mangas maduras'),(22,12,'2025-09-20 00:00:00',95.00,1,'Colheita de grãos de café'),(23,13,'2025-09-20 00:00:00',520.00,1,'Colheita mecânica de soja'),(24,14,'2025-09-20 00:00:00',450.00,1,'Colheita de milho seco para ração'),(25,15,'2025-09-20 00:00:00',180.00,1,'Colheita contínua de alface'),(26,16,'2025-09-20 00:00:00',260.00,1,'Colheita de tomates graúdos'),(27,17,'2025-09-20 00:00:00',110.00,1,'Primeira colheita de bananas'),(28,18,'2025-09-20 00:00:00',420.00,1,'Colheita de feijão carioca'),(29,19,'2025-09-20 00:00:00',3000.00,1,'Primeira moagem da cana'),(30,20,'2025-09-20 00:00:00',120.00,1,'Colheita manual de batatas'),(31,21,'2025-12-20 00:00:00',210.00,1,'Colheita de laranjas doces'),(32,22,'2025-12-20 00:00:00',95.00,1,'Colheita de uvas para suco'),(33,23,'2025-12-20 00:00:00',230.00,1,'Colheita de abacaxis maduros'),(34,24,'2025-12-20 00:00:00',200.00,1,'Colheita de sementes de girassol'),(35,25,'2025-12-20 00:00:00',600.00,1,'Coleta de cocos para água'),(36,26,'2025-12-20 00:00:00',75.00,1,'Colheita experimental de alfarroba'),(37,27,'2025-12-20 00:00:00',700.00,1,'Colheita de melancias grandes'),(38,28,'2025-12-20 00:00:00',250.00,1,'Colheita de abóboras moranga'),(39,29,'2025-12-20 00:00:00',130.00,1,'Colheita de cebola roxa'),(40,30,'2025-12-20 00:00:00',210.00,1,'Colheita de ervilhas frescas');
/*!40000 ALTER TABLE `colheita` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `equipamento`
--

DROP TABLE IF EXISTS `equipamento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `equipamento` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Nome` varchar(100) NOT NULL,
  `Tipo` varchar(50) DEFAULT NULL,
  `Descricao` varchar(200) DEFAULT NULL,
  `PrecoUnitario` decimal(14,2) DEFAULT NULL,
  `FornecedorId` int DEFAULT NULL,
  `DataCompra` date DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_Equip_Fornecedor` (`FornecedorId`),
  CONSTRAINT `fk_Equip_Fornecedor` FOREIGN KEY (`FornecedorId`) REFERENCES `fornecedor` (`Id`) ON DELETE SET NULL ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `equipamento`
--

LOCK TABLES `equipamento` WRITE;
/*!40000 ALTER TABLE `equipamento` DISABLE KEYS */;
INSERT INTO `equipamento` VALUES (1,'Trator John Deere 6150M','Trator','Trator agricola de medio porte para preparo de solo e plantio',4000.00,1,'2025-05-15'),(2,'Plantadeira Stara Cinderela','Plantadeira','Plantadeira de 11 linhas para culturas de graos',8000.00,2,'2025-05-20'),(3,'Colheitadeira New Holland CR8.90','Colheitadeira','Colheitadeira axial de alta capacidade para soja e milho',8000.00,6,'2025-06-01'),(4,'Pulverizador Jacto Uniport 3030','Pulverizador','Pulverizador autopropelido com barra de 30 metros',2000.00,3,'2025-06-10'),(5,'Arado de Aiveca','Implemento','Arado para preparo inicial do solo, ideal para areas com vegetacao densa',150.00,4,'2025-06-15'),(6,'Grade Niveladora Baldan','Implemento','Grade de arrasto para destorroamento e nivelamento do solo apos o arado',250.00,5,'2025-06-15'),(7,'Distriuidor de Adubo Vicon','Implemento','Distriuidor de fertilizantes centrifugo de 1000 litros',1800.00,4,'2025-06-20'),(8,'Enfardadora Massey Ferguson','Implemento','Enfardadora para feno e palha, produz fardos retangulares',8500.00,3,'2025-06-25'),(9,'Irrigador de Pivo Central','Irrigacao','Sistema de irrigacao para grandes areas de cultivo',5000.00,2,'2025-07-01'),(10,'Ensiladeira de Forragem','Colheita','Maquina para colheita e picagem de forragem para silagem',1000.00,1,'2025-07-05'),(12,'teste','teste','teste',123.00,6,'0001-01-01'),(13,'teste','teste','',145.00,7,'0001-01-01');
/*!40000 ALTER TABLE `equipamento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `especie`
--

DROP TABLE IF EXISTS `especie`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `especie` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `NomeComum` varchar(100) NOT NULL,
  `NomeCientifico` varchar(100) DEFAULT NULL,
  `Variedade` varchar(100) DEFAULT NULL,
  `EpocaDePlantio` set('Primavera','Verão','Outono','Inverno','Continua') DEFAULT 'Continua',
  `EpocaDeColheita` set('Primavera','Verão','Outono','Inverno','Continua') DEFAULT 'Continua',
  `TempoDeColheita` int DEFAULT NULL,
  `TipoSoloIdealId` int DEFAULT NULL,
  `IdealUmidadeMin` decimal(5,2) DEFAULT NULL,
  `IdealUmidadeMax` decimal(5,2) DEFAULT NULL,
  `Caracteristicas` varchar(300) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `Idx_Especie_TipoSoloIdealId` (`TipoSoloIdealId`),
  KEY `Idx_Especie_NomeComum` (`NomeComum`),
  CONSTRAINT `Fk_Especie_TipoSolo` FOREIGN KEY (`TipoSoloIdealId`) REFERENCES `tiposolo` (`Id`) ON DELETE SET NULL ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `especie`
--

LOCK TABLES `especie` WRITE;
/*!40000 ALTER TABLE `especie` DISABLE KEYS */;
INSERT INTO `especie` VALUES (7,'Manga','Mangifera indica','Tommy Atkins','Primavera,Verão','Verão,Outono',150,2,60.00,80.00,'Fruta tropical doce, árvore de porte médio'),(8,'Café','Coffea arabica','Arábica','Outono,Inverno','Primavera,Verão',180,3,50.00,70.00,'Planta arbustiva, grãos para bebida'),(9,'Soja','Glycine max','BRS 1010','Primavera','Outono',110,1,55.00,75.00,'Leguminosa importante para alimentação e indústria'),(10,'Milho','Zea mays','2ª Safra','Primavera','Verão',120,4,45.00,65.00,'Cereal muito cultivado para alimentação animal e humana'),(11,'Alface','Lactuca sativa','Crespa','Continua','Continua',45,1,65.00,85.00,'Folhosa, cresce rápido e é consumida fresca'),(12,'Tomate','Solanum lycopersicum','Caqui','Primavera,Verão','Verão,Outono',90,3,60.00,80.00,'Fruto suculento, usado em saladas e molhos'),(13,'Banana','Musa spp.','Prata','Primavera','Continua',180,2,70.00,90.00,'Fruta tropical, planta herbácea de grande porte'),(14,'Feijão','Phaseolus vulgaris','Carioca','Primavera','Outono',95,4,50.00,75.00,'Leguminosa consumida amplamente no Brasil'),(15,'Cana-de-açúcar','Saccharum officinarum','RB867515','Primavera,Verão','Outono,Inverno',300,3,60.00,85.00,'Planta para produção de açúcar e etanol'),(16,'Batata','Solanum tuberosum','Ágata','Outono,Inverno','Primavera,Verão',110,1,55.00,75.00,'Tubérculo consumido como alimento'),(17,'Laranja','Citrus sinensis','Valência','Outono','Inverno',180,2,60.00,80.00,'Fruta cítrica rica em vitamina C'),(18,'Uva','Vitis vinifera','Niágara','Primavera','Outono',140,4,55.00,75.00,'Fruta utilizada para consumo e produção de vinho'),(19,'Abacaxi','Ananas comosus','Pérola','Primavera,Verão','Outono',450,3,65.00,85.00,'Fruta tropical de sabor doce e ácido'),(20,'Girassol','Helianthus annuus','Comum','Primavera','Verão',110,1,45.00,65.00,'Planta cultivada para produção de óleo'),(21,'Coco','Cocos nucifera','Anão','Primavera,Verão','Continua',365,2,70.00,90.00,'Fruta tropical rica em água e óleo'),(22,'Alfarroba','Ceratonia siliqua','Comum','Outono','Inverno',200,4,40.00,60.00,'Leguminosa usada como substituto do cacau'),(23,'Melancia','Citrullus lanatus','Crimson Sweet','Primavera,Verão','Verão,Outono',90,3,65.00,85.00,'Fruta refrescante de grande porte'),(24,'Abóbora','Cucurbita pepo','Cabotiá','Primavera','Outono',100,1,55.00,75.00,'Fruta usada em alimentação e decoração'),(25,'Cebola','Allium cepa','Roxa','Outono,Inverno','Primavera,Verão',120,2,50.00,70.00,'Bulbo usado na culinária mundial'),(26,'Ervilha','Pisum sativum','Doce','Primavera','Verão',80,4,55.00,75.00,'Leguminosa rica em proteínas');
/*!40000 ALTER TABLE `especie` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `evento`
--

DROP TABLE IF EXISTS `evento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `evento` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `UsuarioId` int NOT NULL,
  `Titulo` varchar(100) NOT NULL,
  `Local` varchar(200) DEFAULT NULL,
  `DataInicio` datetime NOT NULL,
  `DataFim` datetime DEFAULT NULL,
  `Descricao` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `Fk_Evento_Usuario` (`UsuarioId`),
  CONSTRAINT `Fk_Evento_Usuario` FOREIGN KEY (`UsuarioId`) REFERENCES `usuario` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=38 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `evento`
--

LOCK TABLES `evento` WRITE;
/*!40000 ALTER TABLE `evento` DISABLE KEYS */;
INSERT INTO `evento` VALUES (28,1,'Workshop de Tecnologia','Auditório Municipal','2025-07-19 00:00:00','2025-07-20 00:00:00','Palestras e oficinas sobre inovação tecnológica.'),(30,1,'Encontro de Carros Antigos','Parque de Exposições','2025-07-26 00:00:00','2025-07-28 00:00:00','Exposição de veículos antigos e raros.'),(31,1,'Corrida da Cidade','Avenida Principal','2025-07-29 00:00:00','2025-07-29 00:00:00','Evento esportivo com percursos de 5km e 10km.'),(32,1,'Feira de produto','Pomerode','2025-07-16 00:00:00','2025-07-16 00:00:00','Centro da cidade '),(37,1,'teste','teste','2025-08-25 00:00:00','2025-08-26 00:00:00','teste');
/*!40000 ALTER TABLE `evento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `fornecedor`
--

DROP TABLE IF EXISTS `fornecedor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `fornecedor` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Nome` varchar(100) NOT NULL,
  `CNPJ` varchar(20) DEFAULT NULL,
  `Telefone` varchar(20) DEFAULT NULL,
  `Email` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `fornecedor`
--

LOCK TABLES `fornecedor` WRITE;
/*!40000 ALTER TABLE `fornecedor` DISABLE KEYS */;
INSERT INTO `fornecedor` VALUES (1,'Comercial Andrade Ltda','12345678000199','(11) 98765-4321','contato@andrade.com'),(2,'Distribuidora Silva ME','98765432000155','(21) 99999-8888','vendas@silvame.com'),(3,'Tech Solutions S/A','45678912000133','(31) 98888-7777','suporte@techsolutions.com'),(4,'Alimentos Nobre LTDA','32165487000111','(41) 97777-6666','comercial@nobre.com'),(5,'Construtora Alfa EIRELI','15975362000122','(51) 96666-5555','obras@alfa.com.br'),(6,'Ana','123456','412356','teste01'),(7,'ana julia','123','4123','teste02');
/*!40000 ALTER TABLE `fornecedor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `historicosolo`
--

DROP TABLE IF EXISTS `historicosolo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `historicosolo` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `TipoSoloId` int NOT NULL,
  `DataLeitura` datetime NOT NULL,
  `Umidade` decimal(5,2) DEFAULT NULL,
  `Observacoes` varchar(200) DEFAULT NULL,
  `PropriedadeId` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_hsolo_TipoSolo` (`TipoSoloId`),
  KEY `fk_hsolo_Propriedade` (`PropriedadeId`),
  KEY `Idx_solo_Leitura` (`DataLeitura`),
  CONSTRAINT `fk_hsolo_Propriedade` FOREIGN KEY (`PropriedadeId`) REFERENCES `propriedade` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_hsolo_TipoSolo` FOREIGN KEY (`TipoSoloId`) REFERENCES `tiposolo` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `historicosolo`
--

LOCK TABLES `historicosolo` WRITE;
/*!40000 ALTER TABLE `historicosolo` DISABLE KEYS */;
/*!40000 ALTER TABLE `historicosolo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `insumo`
--

DROP TABLE IF EXISTS `insumo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `insumo` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Nome` varchar(100) NOT NULL,
  `Tipo` varchar(50) DEFAULT NULL,
  `DataDeValidade` date DEFAULT NULL,
  `Descricao` varchar(200) DEFAULT NULL,
  `FornecedorId` int DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_Insumo_Fornecedor` (`FornecedorId`),
  KEY `Idx_Insumo_Nome` (`Nome`),
  CONSTRAINT `fk_Insumo_Fornecedor` FOREIGN KEY (`FornecedorId`) REFERENCES `fornecedor` (`Id`) ON DELETE SET NULL ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `insumo`
--

LOCK TABLES `insumo` WRITE;
/*!40000 ALTER TABLE `insumo` DISABLE KEYS */;
INSERT INTO `insumo` VALUES (1,'Farinha de Trigo','Ingrediente','2025-12-31','Farinha de trigo para panificação',1),(2,'Açúcar Cristal','Ingrediente','2026-06-30','Açúcar cristal branco refinado',2),(3,'Óleo de Soja','Ingrediente','2025-10-15','Óleo de soja para frituras e preparações',3),(4,'Fermento Biológico','Ingrediente','2024-11-20','Fermento seco para panificação',1),(5,'Sal Refinado','Ingrediente','2027-01-01','Sal refinado para uso culinário',4);
/*!40000 ALTER TABLE `insumo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `insumoestoque`
--

DROP TABLE IF EXISTS `insumoestoque`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `insumoestoque` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `PropriedadeId` int NOT NULL,
  `InsumoId` int NOT NULL,
  `Quantidade` int NOT NULL,
  `PrecoUnitario` decimal(14,2) NOT NULL,
  `PrecoTotal` decimal(20,2) GENERATED ALWAYS AS ((`Quantidade` * `PrecoUnitario`)) STORED,
  `DataMovimentacao` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`Id`),
  KEY `Idx_ie_prop_Insumo` (`PropriedadeId`,`InsumoId`),
  KEY `Idx_ie_PrecoTotal` (`PrecoTotal`),
  KEY `Idx_ie_Data_desc` (`InsumoId`,`DataMovimentacao` DESC),
  CONSTRAINT `fk_ie_Insumo` FOREIGN KEY (`InsumoId`) REFERENCES `insumo` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_ie_prop` FOREIGN KEY (`PropriedadeId`) REFERENCES `propriedade` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=42 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `insumoestoque`
--

LOCK TABLES `insumoestoque` WRITE;
/*!40000 ALTER TABLE `insumoestoque` DISABLE KEYS */;
INSERT INTO `insumoestoque` (`Id`, `PropriedadeId`, `InsumoId`, `Quantidade`, `PrecoUnitario`, `DataMovimentacao`) VALUES (31,2,1,10,12.50,'2025-07-19 18:52:25'),(32,2,2,25,8.30,'2025-07-17 18:52:25'),(33,2,3,5,15.00,'2025-07-15 18:52:25'),(34,2,4,40,7.20,'2025-07-13 18:52:25'),(35,2,5,60,5.50,'2025-07-11 18:52:25'),(36,2,1,100,1.50,'2025-08-28 23:29:30'),(37,2,5,100,1.50,'2025-08-28 23:30:29'),(38,2,2,100,1.50,'2025-08-28 23:31:42'),(39,2,5,100,5.00,'2025-08-28 23:32:34'),(40,2,5,1,1.00,'2025-08-28 23:33:31'),(41,2,5,100,1.00,'2025-08-28 23:58:06');
/*!40000 ALTER TABLE `insumoestoque` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `movimentoarmazenamento`
--

DROP TABLE IF EXISTS `movimentoarmazenamento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `movimentoarmazenamento` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `ArmazenamentoId` int NOT NULL,
  `TipoMovimentacao` enum('Venda','Transferencia','Ajuste') NOT NULL,
  `Quantidade` decimal(10,2) NOT NULL,
  `DataMovimentacao` datetime NOT NULL,
  `Observacoes` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `ArmazenamentoId` (`ArmazenamentoId`),
  CONSTRAINT `MovimentoArmazenamento_ibfk_1` FOREIGN KEY (`ArmazenamentoId`) REFERENCES `armazenamentocolheita` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `movimentoarmazenamento`
--

LOCK TABLES `movimentoarmazenamento` WRITE;
/*!40000 ALTER TABLE `movimentoarmazenamento` DISABLE KEYS */;
/*!40000 ALTER TABLE `movimentoarmazenamento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `plantio`
--

DROP TABLE IF EXISTS `plantio`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `plantio` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `EspecieId` int DEFAULT NULL,
  `PropriedadeId` int NOT NULL,
  `DataInicio` date NOT NULL,
  `DataFim` date DEFAULT NULL,
  `AreaPlantada` decimal(10,2) DEFAULT NULL,
  `Mudas` int DEFAULT NULL,
  `Descricao` varchar(200) DEFAULT NULL,
  `UnidadeMedidaId` int DEFAULT NULL,
  `Ativa` tinyint DEFAULT '1',
  PRIMARY KEY (`Id`),
  KEY `Idx_Plantio_DataInicio` (`DataInicio`),
  KEY `Fk_Plantio_Especie` (`EspecieId`),
  KEY `Fk_Plantio_Propriedade` (`PropriedadeId`),
  KEY `Fk_Plantio_UnidadeMedida` (`UnidadeMedidaId`),
  CONSTRAINT `Fk_Plantio_Especie` FOREIGN KEY (`EspecieId`) REFERENCES `especie` (`Id`) ON DELETE SET NULL ON UPDATE CASCADE,
  CONSTRAINT `Fk_Plantio_Propriedade` FOREIGN KEY (`PropriedadeId`) REFERENCES `propriedade` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `Fk_Plantio_UnidadeMedida` FOREIGN KEY (`UnidadeMedidaId`) REFERENCES `unidademedida` (`Id`) ON DELETE SET NULL ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=35 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `plantio`
--

LOCK TABLES `plantio` WRITE;
/*!40000 ALTER TABLE `plantio` DISABLE KEYS */;
INSERT INTO `plantio` VALUES (11,7,2,'2024-09-01','2025-01-29',2.50,150,'Plantio de manga Tommy Atkins',6,0),(12,8,2,'2024-05-10','2024-11-10',1.80,300,'Plantio de café Arábica na encosta',6,0),(13,9,2,'2024-10-15','2025-02-02',3.00,500,'Safra de soja BRS 1010',6,1),(14,10,2,'2024-09-01','2025-01-01',1.20,400,'Plantio de milho para alimentação animal',6,1),(15,11,2,'2024-07-01','2024-08-15',0.30,1000,'Canteiro contínuo de alface',6,1),(16,12,2,'2024-08-10','2024-11-08',0.80,200,'Plantio de tomate caqui para venda em feiras',6,1),(17,13,2,'2024-10-01','2025-03-30',1.10,250,'Início de pomar de banana prata',6,1),(18,14,2,'2024-09-15','2025-01-01',2.20,600,'Plantio de feijão carioca para consumo interno',6,1),(19,15,2,'2024-11-01','2025-09-28',5.00,800,'Lavoura de cana-de-açúcar para fornecimento local',6,1),(20,16,2,'2024-07-15','2024-11-02',0.50,100,'Cultivo de batata Ágata em solo argiloso',6,1),(21,17,2,'2024-08-05','2024-12-20',1.90,220,'Plantio de laranjeiras para venda em mercados locais',6,1),(22,18,2,'2024-06-10','2024-10-15',1.00,120,'Cultivo de uva para produção artesanal de sucos',6,1),(23,19,2,'2024-08-01','2025-01-20',1.60,300,'Plantio de abacaxi pérola em solo arenoso',6,1),(24,20,2,'2024-10-01','2025-03-01',1.40,180,'Cultivo de girassol para extração de óleo',6,1),(25,21,2,'2024-09-05','2025-04-10',3.20,100,'Plantio de coqueiros para produção de água de coco',6,1),(26,22,2,'2024-06-15','2024-12-10',0.70,160,'Plantio de alfarroba em consórcio com abacateiros',6,1),(27,23,2,'2024-11-01','2025-02-25',2.00,500,'Plantio de melancia para a estação de verão',6,1),(28,24,2,'2024-08-20','2024-12-01',1.30,250,'Plantio de abóbora moranga para festividades',6,1),(29,25,2,'2024-09-10','2024-11-25',0.60,300,'Plantio de cebola roxa para colheita rápida',6,1),(30,26,2,'2024-07-05','2024-10-05',0.90,350,'Plantio de ervilha em fileiras duplas',6,1),(31,8,2,'2025-08-12','2025-09-01',10.00,500,'teste01',6,1),(32,7,2,'2025-08-27','2025-08-20',10.00,500,'teste02',6,1),(33,7,2,'2025-08-31','2025-08-31',10.00,500,'teste03',6,1),(34,17,2,'2025-08-12','2025-08-20',10.00,20,'teste04',6,1);
/*!40000 ALTER TABLE `plantio` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `plantioequipamento`
--

DROP TABLE IF EXISTS `plantioequipamento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `plantioequipamento` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `PlantioId` int NOT NULL,
  `EquipamentoId` int NOT NULL,
  `Quantidade` decimal(14,3) NOT NULL,
  `DataAplicacao` datetime NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `Idx_pi_Data` (`DataAplicacao`),
  KEY `Idx_pi_Equipamento_Plantio` (`PlantioId`,`EquipamentoId`),
  KEY `fk_pi_Insumo_EquipamentoPlantio` (`EquipamentoId`),
  CONSTRAINT `fk_pi_Insumo_EquipamentoPlantio` FOREIGN KEY (`EquipamentoId`) REFERENCES `equipamento` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_pi_Plantio_EquipamentoPlantio` FOREIGN KEY (`PlantioId`) REFERENCES `plantio` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `plantioequipamento`
--

LOCK TABLES `plantioequipamento` WRITE;
/*!40000 ALTER TABLE `plantioequipamento` DISABLE KEYS */;
/*!40000 ALTER TABLE `plantioequipamento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `plantioinsumo`
--

DROP TABLE IF EXISTS `plantioinsumo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `plantioinsumo` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `PlantioId` int NOT NULL,
  `InsumoId` int NOT NULL,
  `Quantidade` decimal(14,3) NOT NULL,
  `DataAplicacao` datetime NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `Idx_PlantioInsumo_Data` (`DataAplicacao`),
  KEY `Idx_Plantioinsumo_Plantio_Insumo` (`PlantioId`,`InsumoId`),
  KEY `fk_pi_Insumo` (`InsumoId`),
  CONSTRAINT `fk_pi_Insumo` FOREIGN KEY (`InsumoId`) REFERENCES `insumo` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_pi_Plantio` FOREIGN KEY (`PlantioId`) REFERENCES `plantio` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `plantioinsumo`
--

LOCK TABLES `plantioinsumo` WRITE;
/*!40000 ALTER TABLE `plantioinsumo` DISABLE KEYS */;
/*!40000 ALTER TABLE `plantioinsumo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `propriedade`
--

DROP TABLE IF EXISTS `propriedade`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `propriedade` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Nome` varchar(100) NOT NULL,
  `CidadeId` int DEFAULT NULL,
  `UsuarioId` int NOT NULL,
  `Tamanho` decimal(10,2) NOT NULL,
  `Cultura` enum('Monocultura','Policultura') DEFAULT 'Policultura',
  `UnidadeMedidaId` int DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `Idx_Propriedade_Nome` (`Nome`),
  KEY `Fk_Propriedade_Usuario` (`UsuarioId`),
  KEY `Fk_Propriedade_Cidade` (`CidadeId`),
  KEY `Fk_Propriedade_UnidadeMedida` (`UnidadeMedidaId`),
  CONSTRAINT `Fk_Propriedade_Cidade` FOREIGN KEY (`CidadeId`) REFERENCES `cidade` (`Id`) ON DELETE SET NULL ON UPDATE CASCADE,
  CONSTRAINT `Fk_Propriedade_UnidadeMedida` FOREIGN KEY (`UnidadeMedidaId`) REFERENCES `unidademedida` (`Id`) ON DELETE SET NULL ON UPDATE CASCADE,
  CONSTRAINT `Fk_Propriedade_Usuario` FOREIGN KEY (`UsuarioId`) REFERENCES `usuario` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `propriedade`
--

LOCK TABLES `propriedade` WRITE;
/*!40000 ALTER TABLE `propriedade` DISABLE KEYS */;
INSERT INTO `propriedade` VALUES (2,'Fazenda São Jorge',1,1,1250.75,'Monocultura',6);
/*!40000 ALTER TABLE `propriedade` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tarefa`
--

DROP TABLE IF EXISTS `tarefa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tarefa` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `UsuarioId` int NOT NULL,
  `Titulo` varchar(100) NOT NULL,
  `Descricao` varchar(200) DEFAULT NULL,
  `Status` tinyint NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  KEY `Fk_Tarefa_Usuario` (`UsuarioId`),
  CONSTRAINT `Fk_Tarefa_Usuario` FOREIGN KEY (`UsuarioId`) REFERENCES `usuario` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=47 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tarefa`
--

LOCK TABLES `tarefa` WRITE;
/*!40000 ALTER TABLE `tarefa` DISABLE KEYS */;
INSERT INTO `tarefa` VALUES (1,1,'teste','teste',1),(11,1,'ana','ana',1),(13,1,'Irrigar','Plantação de Milho',1),(14,1,'teste','teste',1),(15,1,'Irrigar','Plantação de tomate',1),(16,1,'Plantar','Milho',1),(17,1,'Plantar','Alface',1),(18,1,'Plantar','Alface',1),(19,1,'Plantar','Alface',1),(20,1,'Plantar','Alface',1),(21,1,'Plantar','Alface',1),(22,1,'Plantar','Alface',1),(23,1,'Plantar','Alface',1),(24,1,'Plantar','Alface',1),(25,1,'Plantar','Alface',1),(26,1,'Plantar','Alface',1),(27,1,'Colher','Repolhos',1),(28,1,'Colher','Batatas',1),(29,1,'Colher','Batatas',1),(30,1,'Colher','Cebolas',1),(31,1,'Colher','Cenouras',1),(32,1,'Colher','Alface',1),(33,1,'Colher','Cebolas',1),(34,1,'Colher','batatas',1),(35,1,'Colher','batatas',1),(36,1,'Colher','batatas',1),(37,1,'Colher','batatas',1),(38,1,'Colher','batatas',1),(39,1,'Colher','batatas',1),(40,1,'Colher','batatas',1),(41,1,'Plantar','batatas',1),(42,1,'Plantar','cenoura',1),(43,1,'Plantar','Milho',1),(44,1,'Plantar','Milho',0),(45,1,'Irrigar','Alface',0),(46,1,'teste','teste',1);
/*!40000 ALTER TABLE `tarefa` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tiposolo`
--

DROP TABLE IF EXISTS `tiposolo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tiposolo` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Nome` varchar(100) NOT NULL,
  `Textura` enum('Arenoso','Argiloso','Medio','Siltoso') DEFAULT NULL,
  `Descricao` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Idx_TipoSolo_Nome` (`Nome`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tiposolo`
--

LOCK TABLES `tiposolo` WRITE;
/*!40000 ALTER TABLE `tiposolo` DISABLE KEYS */;
INSERT INTO `tiposolo` VALUES (1,'Solo Arenoso','Arenoso','Solo com partículas grossas, boa drenagem, baixa retenção de água'),(2,'Solo Argiloso','Argiloso','Solo com partículas finas, alta retenção de água, pobre drenagem'),(3,'Solo Médio','Medio','Solo equilibrado com boa fertilidade e textura média'),(4,'Solo Siltoso','Siltoso','Solo com partículas finas e textura sedosa, alta capacidade de retenção de água');
/*!40000 ALTER TABLE `tiposolo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `unidademedida`
--

DROP TABLE IF EXISTS `unidademedida`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `unidademedida` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Nome` varchar(50) NOT NULL,
  `Sigla` varchar(10) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Sigla` (`Sigla`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `unidademedida`
--

LOCK TABLES `unidademedida` WRITE;
/*!40000 ALTER TABLE `unidademedida` DISABLE KEYS */;
INSERT INTO `unidademedida` VALUES (1,'Quilograma','kg'),(2,'Grama','g'),(3,'Litro','L'),(4,'Metro','m'),(5,'Unidade','un'),(6,'Hectar','hc'),(15,'Centímetro','cm'),(16,'Mililitro','ml'),(17,'Hectare','ha'),(18,'Tonelada','t'),(19,'Metros quadrados','m²');
/*!40000 ALTER TABLE `unidademedida` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuario`
--

DROP TABLE IF EXISTS `usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuario` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Nome` varchar(100) NOT NULL,
  `Sobrenome` varchar(100) NOT NULL,
  `Cpf` varchar(14) DEFAULT NULL,
  `Email` varchar(100) NOT NULL,
  `Senha` varchar(100) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Idx_Usuario_Email` (`Email`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuario`
--

LOCK TABLES `usuario` WRITE;
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
INSERT INTO `usuario` VALUES (1,'Raizes','Raizes','000','raizes@raizes.com','3e5ea2cba02644f79d4d81faa8c5b16eaf6eb9ad9d30a4ebd1b38c1235749211');
/*!40000 ALTER TABLE `usuario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `venda`
--

DROP TABLE IF EXISTS `venda`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `venda` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `ColheitaId` int NOT NULL,
  `Quantidade` decimal(14,3) NOT NULL,
  `PrecoUnitario` decimal(14,2) NOT NULL,
  `PrecoTotal` decimal(20,2) GENERATED ALWAYS AS ((`Quantidade` * `PrecoUnitario`)) STORED,
  `Comprador` varchar(200) DEFAULT NULL,
  `UnidadeMedidaId` int DEFAULT NULL,
  `DataVenda` date NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `Idx_Venda_Data` (`DataVenda`),
  KEY `Idx_Venda_PrecoTotal` (`PrecoTotal`),
  KEY `fk_Venda_Colheita` (`ColheitaId`),
  KEY `fk_Venda_um` (`UnidadeMedidaId`),
  CONSTRAINT `fk_Venda_Colheita` FOREIGN KEY (`ColheitaId`) REFERENCES `colheita` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_Venda_um` FOREIGN KEY (`UnidadeMedidaId`) REFERENCES `unidademedida` (`Id`) ON DELETE SET NULL ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `venda`
--

LOCK TABLES `venda` WRITE;
/*!40000 ALTER TABLE `venda` DISABLE KEYS */;
INSERT INTO `venda` (`Id`, `ColheitaId`, `Quantidade`, `PrecoUnitario`, `Comprador`, `UnidadeMedidaId`, `DataVenda`) VALUES (8,21,100.000,15.50,'João Silva',1,'2025-08-20'),(9,22,250.500,12.30,'Maria Oliveira',2,'2025-08-20'),(10,23,75.750,18.00,'Carlos Souza',1,'2025-08-20'),(11,24,120.000,15.00,'Ana Paula',1,'2025-06-20'),(12,25,300.000,10.00,'Empresa XYZ',3,'2025-06-20'),(13,26,50.000,13.50,'Lucas Pereira',2,'2025-06-20'),(14,27,200.000,17.25,'Fernanda Lima',1,'2025-06-20'),(15,21,3.000,8.00,'Ana Dalmora',1,'2025-08-29');
/*!40000 ALTER TABLE `venda` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-08-29 16:18:51
