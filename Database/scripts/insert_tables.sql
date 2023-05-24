CREATE TABLE IF NOT EXISTS Mesas (
    MesaID INTEGER NOT NULL PRIMARY KEY AUTO_INCREMENT,
    Numero INTEGER NULL,
    Ocupada TEXT NULL,
    HoraAbertura TEXT NULL
);

CREATE TABLE IF NOT EXISTS Garcons (
    GarconID INTEGER NOT NULL PRIMARY KEY AUTO_INCREMENT,
    Nome TEXT NULL,
    Sobrenome TEXT NULL,
    NumIdentificao INTEGER NULL,
    Telefone TEXT NULL
);

CREATE TABLE IF NOT EXISTS Categorias (
    CategoriaID INTEGER NOT NULL PRIMARY KEY AUTO_INCREMENT,
    Nome TEXT NULL,
    Descricao TEXT NULL
);

CREATE TABLE IF NOT EXISTS Atendimentos (
    AtendimentoID INTEGER NOT NULL PRIMARY KEY AUTO_INCREMENT,
    MesaID INTEGER NULL,
    GarconID INTEGER NULL,
    HorarioAtendimento TEXT NULL,
    PrecoTotal REAL NULL,
    CONSTRAINT FK_Atendimentos_Garcons_GarconID FOREIGN KEY (GarconID) REFERENCES Garcons (GarconID),
    CONSTRAINT FK_Atendimentos_Mesas_MesaID FOREIGN KEY (MesaID) REFERENCES Mesas (MesaID)
);

CREATE TABLE IF NOT EXISTS Produtos (
    ProdutoID INTEGER NOT NULL PRIMARY KEY AUTO_INCREMENT,
    Nome TEXT NULL,
    Descricao TEXT NULL,
    Preco REAL NULL,
    CategoriaID INTEGER NULL,
    CONSTRAINT FK_Produtos_Categorias_CategoriaID FOREIGN KEY (CategoriaID) REFERENCES Categorias (CategoriaID)
);

CREATE TABLE IF NOT EXISTS AtendimentoProduto (
    ProdutoID INTEGER NOT NULL,
    AtendimentoID INTEGER NOT NULL,
    Quantidade INTEGER NULL,
    CONSTRAINT PK_AtendimentoProduto PRIMARY KEY (AtendimentoID, ProdutoID),
    CONSTRAINT FK_AtendimentoProduto_Atendimentos_AtendimentoID FOREIGN KEY (AtendimentoID) REFERENCES Atendimentos (AtendimentoID) ON DELETE CASCADE,
    CONSTRAINT FK_AtendimentoProduto_Produtos_ProdutoID FOREIGN KEY (ProdutoID) REFERENCES Produtos (ProdutoID) ON DELETE CASCADE
);

-- MySQL dump 10.13  Distrib 8.0.30, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: restaurante
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
-- Dumping data for table `AtendimentoProduto`
--

LOCK TABLES `AtendimentoProduto` WRITE;
/*!40000 ALTER TABLE `AtendimentoProduto` DISABLE KEYS */;
INSERT INTO `AtendimentoProduto` VALUES (1,1,2),(1,2,1),(2,2,3),(1,5,2),(2,5,3),(2,6,1);
/*!40000 ALTER TABLE `AtendimentoProduto` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `Atendimentos`
--

LOCK TABLES `Atendimentos` WRITE;
/*!40000 ALTER TABLE `Atendimentos` DISABLE KEYS */;
INSERT INTO `Atendimentos` VALUES (1,2,1,'2023-05-22 23:57:13.436209',20.5),(2,3,2,'2023-05-22 23:57:21.624526',88.22),(5,6,2,'2023-05-22 23:58:09.732201',98.47),(6,5,2,'2023-05-22 23:58:20.523068',25.99);
/*!40000 ALTER TABLE `Atendimentos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `Categorias`
--

LOCK TABLES `Categorias` WRITE;
/*!40000 ALTER TABLE `Categorias` DISABLE KEYS */;
INSERT INTO `Categorias` VALUES (2,'Bebidas','Bebidas geladinhas para tomar.'),(3,'Lanches','Os melhores lanches saborosos.');
/*!40000 ALTER TABLE `Categorias` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `Garcons`
--

LOCK TABLES `Garcons` WRITE;
/*!40000 ALTER TABLE `Garcons` DISABLE KEYS */;
INSERT INTO `Garcons` VALUES (1,'Cleiton','Rasta',1,'(45)993145698'),(2,'John','Wick',2,'(55)999315511');
/*!40000 ALTER TABLE `Garcons` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `Mesas`
--

LOCK TABLES `Mesas` WRITE;
/*!40000 ALTER TABLE `Mesas` DISABLE KEYS */;
INSERT INTO `Mesas` VALUES (2,1,'Ocupada','2023-05-22 23:57:13.397814'),(3,2,'Ocupada','2023-05-22 23:57:21.604320'),(4,3,'Livre','2023-05-22 23:52:00.890356'),(5,4,'Ocupada','2023-05-22 23:58:20.506802'),(6,5,'Ocupada','2023-05-22 23:58:09.710004');
/*!40000 ALTER TABLE `Mesas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `Produtos`
--

LOCK TABLES `Produtos` WRITE;
/*!40000 ALTER TABLE `Produtos` DISABLE KEYS */;
INSERT INTO `Produtos` VALUES (1,'Heineken','Cerveja de rico.',10.25,2),(2,'X-Tudo','Com tomate, alface, hambúrguer bovino, e afins.',25.99,3);
/*!40000 ALTER TABLE `Produtos` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-05-22 21:02:08
