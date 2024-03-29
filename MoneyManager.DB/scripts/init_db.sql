USE moneymanager_db;

-- Criação da tabela "Categoria"
CREATE TABLE Categoria (
  CategoriaID INT PRIMARY KEY AUTO_INCREMENT,
  Nome VARCHAR(255) NOT NULL,
  Descricao VARCHAR(255),
  Tipo ENUM('Despesa', 'Receita') NOT NULL
);

-- Criação da tabela "Transacao"
CREATE TABLE Transacao (
  TransacaoID INT PRIMARY KEY AUTO_INCREMENT,
  Nome VARCHAR(255) NOT NULL,
  Descricao VARCHAR(255),
  Valor DECIMAL(10, 2) NOT NULL,
  CategoriaID INT,
  Data DATE,
  FOREIGN KEY (CategoriaID) REFERENCES Categoria(CategoriaID)
);

-- Inserção de dados na tabela "Categoria"
INSERT INTO Categoria (Nome, Descricao, Tipo)
VALUES ('Alimentacao', 'Gastos com alimentacao', 'Despesa'),
       ('Transporte', 'Gastos com transporte', 'Despesa'),
       ('Moradia', 'Gastos com moradia', 'Despesa'),
       ('Educacao', 'Gastos com educacao', 'Despesa');

-- Inserção de dados na tabela "Transacao"
INSERT INTO Transacao (Nome, Descricao, Valor, CategoriaID, Data)
VALUES ('Supermercado', 'Compra de mantimentos', 100.00, 1, '2023-06-25'),
       ('Restaurante', 'Jantar fora', 50.00, 1, '2023-06-24'),
       ('Gasolina', 'Abastecimento do veiculo', 80.00, 2, '2023-06-23'),
       ('Aluguel', 'Pagamento mensal do aluguel', 1000.00, 3, '2023-06-22'),
       ('Material escolar', 'Compra de materiais escolares', 50.00, 4, '2023-06-21');
