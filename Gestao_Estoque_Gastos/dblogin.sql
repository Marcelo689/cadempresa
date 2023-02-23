-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 02-Dez-2022 às 00:35
-- Versão do servidor: 10.4.24-MariaDB
-- versão do PHP: 8.1.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `dblogin`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `tblempresa`
--

CREATE TABLE `tblempresa` (
  `id` int(11) NOT NULL,
  `CNPJ` decimal(10,0) NOT NULL,
  `Logo` blob DEFAULT NULL,
  `NomeEmpresa` varchar(150) NOT NULL,
  `Rua` varchar(150) DEFAULT NULL,
  `Bairro` varchar(150) DEFAULT NULL,
  `EnderecoNumero` varchar(150) DEFAULT NULL,
  `Complemento` varchar(200) DEFAULT NULL,
  `Email` varchar(200) DEFAULT NULL,
  `Celular` decimal(10,0) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tblingrediente`
--

CREATE TABLE `tblingrediente` (
  `id` int(11) NOT NULL,
  `Nome` varchar(200) DEFAULT NULL,
  `Preco` decimal(10,0) DEFAULT NULL,
  `unidadeMedidaId` int(11) NOT NULL,
  `QuantidadeUnidade` int(11) DEFAULT NULL,
  `PedidoId` int(11) DEFAULT NULL,
  `ReceitaId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tblperfilusuario`
--

CREATE TABLE `tblperfilusuario` (
  `id` int(11) NOT NULL,
  `descricao` varchar(45) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `tblperfilusuario`
--

INSERT INTO `tblperfilusuario` (`id`, `descricao`) VALUES
(1, 'aluno'),
(2, 'professor');

-- --------------------------------------------------------

--
-- Estrutura da tabela `tblunidademedida`
--

CREATE TABLE `tblunidademedida` (
  `id` int(11) NOT NULL,
  `descricao` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tbluser`
--

CREATE TABLE `tbluser` (
  `id` int(11) NOT NULL,
  `usr` varchar(45) NOT NULL,
  `pwd` varchar(45) NOT NULL,
  `idtblPerfilUsuario` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `tbluser`
--

INSERT INTO `tbluser` (`id`, `usr`, `pwd`, `idtblPerfilUsuario`) VALUES
(1, 'marcelo@gmail.com', '@1234', 1),
(7, 'tt', 'tt', 2),
(8, 'tt', 'ttt', 3),
(10, 'gggg', 'tttt', 4),
(11, 'gtttgttttt66666', 'gggg', 5),
(12, 'sdsdafsda', '123', 6),
(13, 'sdfsfdsfda', 'sfdsdfasa', 7),
(14, 'sdafsda', '344', 8),
(15, 'caroline@gmail.com', '@1234', 9),
(16, 'teste1', '12', 1),
(17, 'g', 'g', 1),
(18, 'z', 'z', 2),
(19, 'AAA', 'AAA', 1);

-- --------------------------------------------------------

--
-- Estrutura da tabela `tblusuario`
--

CREATE TABLE `tblusuario` (
  `id` int(11) NOT NULL,
  `Nome` varchar(200) DEFAULT NULL,
  `Senha` varchar(200) DEFAULT NULL,
  `Acesso` enum('1','2') NOT NULL,
  `ManterLogado` tinyint(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Índices para tabelas despejadas
--

--
-- Índices para tabela `tblempresa`
--
ALTER TABLE `tblempresa`
  ADD PRIMARY KEY (`id`);

--
-- Índices para tabela `tblingrediente`
--
ALTER TABLE `tblingrediente`
  ADD PRIMARY KEY (`id`);

--
-- Índices para tabela `tblperfilusuario`
--
ALTER TABLE `tblperfilusuario`
  ADD PRIMARY KEY (`id`);

--
-- Índices para tabela `tblunidademedida`
--
ALTER TABLE `tblunidademedida`
  ADD PRIMARY KEY (`id`);

--
-- Índices para tabela `tbluser`
--
ALTER TABLE `tbluser`
  ADD PRIMARY KEY (`id`);

--
-- Índices para tabela `tblusuario`
--
ALTER TABLE `tblusuario`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT de tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `tblempresa`
--
ALTER TABLE `tblempresa`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `tblingrediente`
--
ALTER TABLE `tblingrediente`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `tblperfilusuario`
--
ALTER TABLE `tblperfilusuario`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de tabela `tblunidademedida`
--
ALTER TABLE `tblunidademedida`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `tbluser`
--
ALTER TABLE `tbluser`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- AUTO_INCREMENT de tabela `tblusuario`
--
ALTER TABLE `tblusuario`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
