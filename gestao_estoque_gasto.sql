-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 10-Fev-2023 às 23:58
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
-- Banco de dados: `gestao_estoque_gasto`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `tblcidade`
--

CREATE TABLE `tblcidade` (
  `id` int(11) NOT NULL,
  `descricaoCidade` varchar(100) NOT NULL,
  `idEstado` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tblempresa`
--

CREATE TABLE `tblempresa` (
  `id` int(11) NOT NULL,
  `CNPJ` varchar(18) NOT NULL,
  `razaoSocial` varchar(150) NOT NULL,
  `rua` varchar(150) DEFAULT NULL,
  `bairro` varchar(150) DEFAULT NULL,
  `numeroEndereco` int(11) DEFAULT NULL,
  `complemento` varchar(200) DEFAULT NULL,
  `email` varchar(90) DEFAULT NULL,
  `telefone` varchar(15) DEFAULT NULL,
  `nomeFantasia` varchar(150) NOT NULL,
  `idcidade` int(11) NOT NULL,
  `createEmpresa` timestamp NOT NULL DEFAULT current_timestamp(),
  `updateEmpresa` timestamp NULL DEFAULT NULL,
  `idUsername` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `tblempresa`
--

INSERT INTO `tblempresa` (`id`, `CNPJ`, `razaoSocial`, `rua`, `bairro`, `numeroEndereco`, `complemento`, `email`, `telefone`, `nomeFantasia`, `idcidade`, `createEmpresa`, `updateEmpresa`, `idUsername`) VALUES
(7, '230233434', 'chocolandia', 'marechal', 'centro', 12, 'ao lado da sorveteria', 'choco@onion', '2147483647', 'choco deep898797', 0, '2023-02-04 00:02:07', NULL, 0),
(9, '34234523', 'fvsddsfvsdf', 'dfvdfv', 'dfvfdvdfv', 2, 'sdvdfvdfv', 'sdfdfvfvsdvf', '3452345', 'sdfvsdfvsdf', 0, '2023-02-04 00:02:07', NULL, 0),
(10, '99887799', 'vista real', 'pedro geromel', 'centro', 365, 'ao lado do kanemann', 'vistareal@gmail.com', '2147483647', 'vistoria', 0, '2023-02-04 00:02:07', NULL, 0),
(11, '230233434', 'chocolandia', 'marechal', 'centro', 12, 'ao lado da sorveteria', 'choco@onion', '2147483647', 'choco deep898797', 0, '2023-02-04 00:02:07', NULL, 0),
(12, '9999999999', 'chocolandia', 'marechal', 'centro', 12, 'ao lado da sorveteria', 'choco@onion', '2147483647', 'choco pelvico', 0, '2023-02-04 00:02:07', NULL, 0),
(13, '99.862.0001/14', 'textos Express', 'av geromel', 'centro', 352, 'ao lado do kanemann', 'texto@hotmail.com', '9996557', 'Texto Facil', 7, '2023-02-04 00:04:09', NULL, 1);

-- --------------------------------------------------------

--
-- Estrutura da tabela `tblestado`
--

CREATE TABLE `tblestado` (
  `id` int(11) NOT NULL,
  `descricaoEstado` varchar(100) NOT NULL,
  `idPais` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tblgastovariado`
--

CREATE TABLE `tblgastovariado` (
  `id` int(11) DEFAULT NULL,
  `descricaoGasto` text CHARACTER SET utf8 NOT NULL,
  `valorGasto` float(10,0) NOT NULL,
  `idUnidadeMedidaGasto` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tblingrediente`
--

CREATE TABLE `tblingrediente` (
  `id` int(11) NOT NULL,
  `nomeIngrediente` text CHARACTER SET utf8 NOT NULL,
  `precoIngrediente` float(10,0) NOT NULL,
  `unidadeMedidaId` int(11) NOT NULL,
  `quantidadeUnidade` float(10,0) NOT NULL,
  `empresaId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `tblingrediente`
--

INSERT INTO `tblingrediente` (`id`, `nomeIngrediente`, `precoIngrediente`, `unidadeMedidaId`, `empresaId`) VALUES
(3, 'Ovo (Unidade)', '0.10', 3, 1),
(4, 'Chocolate em pó (Colher de sopa)', '0.30', 7, 1),
(5, 'Manteiga (Colher de sopa)', '0.40', 7, 1),
(6, 'Farinha de trigo (Xícara Chá)', '0.80', 4, 1),
(7, 'Açúcar (Xícara Chá)', '0.50', 4, 1),
(8, 'Fermento (Colher Sopa)', '0.20', 7, 1),
(9, 'Leite (Xícara chá)', '0.40', 4, 1);

-- --------------------------------------------------------

--
-- Estrutura da tabela `tblpais`
--

CREATE TABLE `tblpais` (
  `id` int(11) NOT NULL,
  `descricaoPais` varchar(140) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tblparametros`
--

CREATE TABLE `tblparametros` (
  `id` int(11) NOT NULL ,
  `percentualLucro` float(10,0) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `tblparametros`
--

INSERT INTO `tblparametros` (`id`, `percentualLucro`) VALUES
(1, '0.30');

-- --------------------------------------------------------

--
-- Estrutura da tabela `tblpedido`
--

CREATE TABLE `tblpedido` (
  `id` int(11) NOT NULL,
  `idEmpresa` int(11) NOT NULL,
  `dataPedido` datetime NOT NULL,
  `obsPedido` text CHARACTER SET utf8 NOT NULL,
  `idUsuario` int(11) NOT NULL,
  `valorTotalReceita` float(10,0) NOT NULL,
  `valorMaoDeObra` float(10,0) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tblpedidoreceita`
--

CREATE TABLE `tblpedidoreceita` (
  `id` int(11) NOT NULL,
  `idPedido` int(11) NOT NULL,
  `idReceita` int(11) NOT NULL,
  `quantidadeReceita` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tblreceita`
--

CREATE TABLE `tblreceita` (
  `id` int(11) NOT NULL,
  `nomeReceita` varchar(140) CHARACTER SET utf8 NOT NULL,
  `idEmpresa` int(11) NOT NULL,
  `valorTotalReceita` float(10,0) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `tblreceita`
--

INSERT INTO `tblreceita` (`id`, `nomeReceita`, `idEmpresa`, `total_receita`) VALUES
(2, 'Bolo de Chocolate', 1, '6.50');

-- --------------------------------------------------------

--
-- Estrutura da tabela `tblreceitaingrediente`
--

CREATE TABLE `tblreceitaingrediente` (
  `id` int(11) NOT NULL,
  `idIngrediente` int(11) NOT NULL,
  `idReceita` int(11) NOT NULL,
  `quantidadeIngrediente` int(11) NOT NULL,
  `idGastoVariado` int(11) NOT NULL,
  `qntGastoVariado` float(10,0) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `tblreceitaingrediente`
--

INSERT INTO `tblreceitaingrediente` (`id`, `idIngrediente`, `idReceita`, `quantidadeIngrediente`, `idGastoVariado`, `quantidadeGastoVariado`) VALUES
(1, 3, 2, 3, 0, '0'),
(2, 4, 2, 4, 0, '0'),
(3, 5, 2, 2, 0, '0'),
(4, 6, 2, 3, 0, '0'),
(5, 7, 2, 2, 0, '0'),
(6, 8, 2, 2, 0, '0'),
(7, 9, 2, 1, 0, '0');

-- --------------------------------------------------------

--
-- Estrutura da tabela `tblunidademedidagastovariado`
--

CREATE TABLE `tblunidademedidagastovariado` (
  `id` int(11) NOT NULL,
  `descUnidMedGastoVariado` text CHARACTER SET utf8 NOT NULL,
  `sigla` varchar(5) CHARACTER SET utf8 NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tblunidademedidaingrediente`
--

CREATE TABLE `tblunidademedidaingrediente` (
  `id` int(11) NOT NULL,
  `descUnidMedIngrediente` varchar(200) NOT NULL,
  `sigla` varchar(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `tblunidademedidaingrediente`
--

INSERT INTO `tblunidademedidaingrediente` (`id`, `descUnidMedIngrediente`, `sigla`) VALUES
(2, 'quilos', 'Kg');

-- --------------------------------------------------------

--
-- Estrutura da tabela `tblusuario`
--

CREATE TABLE `tblusuario` (
  `id` int(11) NOT NULL,
  `nome` varchar(200) DEFAULT NULL,
  `username` varchar(150) NOT NULL,
  `senha` varchar(200) DEFAULT NULL,
  `acesso` enum('1','2') NOT NULL,
  `manterLogado` enum('1','2') NOT NULL,
  `empresaId` int(10) NOT NULL,
  `ativo` enum('1','2') NOT NULL DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `tblusuario`
--

INSERT INTO `tblusuario` (`id`, `nome`, `username`, `senha`, `acesso`, `manterLogado`, `empresaId`, `ativo`) VALUES
(1, 'm', 'm', 'm', '1', '1', 7, '1');

--
-- Índices para tabelas despejadas
--

--
-- Índices para tabela `tblcidade`
--
ALTER TABLE `tblcidade`
  ADD PRIMARY KEY (`id`),
  ADD KEY `idEstado` (`idEstado`);

--
-- Índices para tabela `tblempresa`
--
ALTER TABLE `tblempresa`
  ADD PRIMARY KEY (`id`),
  ADD KEY `idcidade` (`idcidade`),
  ADD KEY `idUsername` (`idUsername`);

--
-- Índices para tabela `tblestado`
--
ALTER TABLE `tblestado`
  ADD PRIMARY KEY (`id`),
  ADD KEY `idPais` (`idPais`);

--
-- Índices para tabela `tblgastovariado`
--
ALTER TABLE `tblgastovariado`
  ADD KEY `idUnidadeMedidaGasto` (`idUnidadeMedidaGasto`);

--
-- Índices para tabela `tblingrediente`
--
ALTER TABLE `tblingrediente`
  ADD PRIMARY KEY (`id`),
  ADD KEY `empresaId` (`empresaId`),
  ADD KEY `unidadeMedidaId` (`unidadeMedidaId`);

--
-- Índices para tabela `tblpais`
--
ALTER TABLE `tblpais`
  ADD PRIMARY KEY (`id`);

--
-- Índices para tabela `tblparametros`
--
ALTER TABLE `tblparametros`
  ADD PRIMARY KEY (`id`);

--
-- Índices para tabela `tblpedido`
--
ALTER TABLE `tblpedido`
  ADD PRIMARY KEY (`id`),
  ADD KEY `idUsuario` (`idUsuario`),
  ADD KEY `idEmpresa` (`idEmpresa`);

--
-- Índices para tabela `tblpedidoreceita`
--
ALTER TABLE `tblpedidoreceita`
  ADD PRIMARY KEY (`id`),
  ADD KEY `idPedido` (`idPedido`),
  ADD KEY `idReceita` (`idReceita`);

--
-- Índices para tabela `tblreceita`
--
ALTER TABLE `tblreceita`
  ADD PRIMARY KEY (`id`),
  ADD KEY `idEmpresa` (`idEmpresa`);

--
-- Índices para tabela `tblreceitaingrediente`
--
ALTER TABLE `tblreceitaingrediente`
  ADD PRIMARY KEY (`id`),
  ADD KEY `idIngrediente` (`idIngrediente`),
  ADD KEY `idReceita` (`idReceita`),
  ADD KEY `idGastoVariado` (`idGastoVariado`);

--
-- Índices para tabela `tblunidademedidagastovariado`
--
ALTER TABLE `tblunidademedidagastovariado`
  ADD PRIMARY KEY (`id`);

--
-- Índices para tabela `tblunidademedidaingrediente`
--
ALTER TABLE `tblunidademedidaingrediente`
  ADD PRIMARY KEY (`id`);

--
-- Índices para tabela `tblusuario`
--
ALTER TABLE `tblusuario`
  ADD PRIMARY KEY (`id`),
  ADD KEY `empresaId` (`empresaId`);

--
-- AUTO_INCREMENT de tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `tblcidade`
--
ALTER TABLE `tblcidade`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `tblempresa`
--
ALTER TABLE `tblempresa`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT de tabela `tblestado`
--
ALTER TABLE `tblestado`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `tblingrediente`
--
ALTER TABLE `tblingrediente`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT de tabela `tblpais`
--
ALTER TABLE `tblpais`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `tblpedido`
--
ALTER TABLE `tblpedido`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `tblpedidoreceita`
--
ALTER TABLE `tblpedidoreceita`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `tblreceita`
--
ALTER TABLE `tblreceita`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `tblreceitaingrediente`
--
ALTER TABLE `tblreceitaingrediente`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT de tabela `tblunidademedidagastovariado`
--
ALTER TABLE `tblunidademedidagastovariado`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `tblunidademedidaingrediente`
--
ALTER TABLE `tblunidademedidaingrediente`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de tabela `tblusuario`
--
ALTER TABLE `tblusuario`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
