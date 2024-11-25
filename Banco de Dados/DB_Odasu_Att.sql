-- Criação do banco de dados
CREATE DATABASE odasu
GO
-- Configurando formato da data para DIA/MES/ANO
SET DATEFORMAT DMY 
GO
-- Usando o banco
USE odasu
GO
-- Criando Tabelas
CREATE TABLE tb_usuario(
cod_usuario BIGINT NOT NULL IDENTITY PRIMARY KEY,
nome_usuario VARCHAR(100) NOT NULL,
sobrenome_usuario VARCHAR(100) NOT NULL,
cpf_usuario VARCHAR(11) UNIQUE NOT NULL,
nasc_usuario DATE NOT NULL,
cel_usuario VARCHAR(15) UNIQUE NOT NULL,
email_usuario VARCHAR(100) UNIQUE NOT NULL,
senha_usuario VARCHAR(255) NOT NULL,
status_usuario VARCHAR(50) NOT NULL CHECK(UPPER (status_usuario) = 'OFFLINE' OR UPPER (status_usuario) = 'ONLINE'),
tipo_conta VARCHAR(50) NOT NULL CHECK(UPPER (tipo_conta) = 'CLIENT' OR UPPER (tipo_conta) = 'ADM' OR UPPER (tipo_conta) = 'INATIVO'),
-- O valor padrão GETDATE() faz com que a coluna data_cadastro receba automaticamente a data e hora atuais no momento da inserção do registro.
data_cadastro DATETIME DEFAULT GETDATE()
);
GO
CREATE TABLE tb_categoria(
cod_categoria BIGINT IDENTITY PRIMARY KEY,
nome_categoria VARCHAR(50) NOT NULL CHECK(UPPER (nome_categoria) = 'MOVEIS' OR UPPER (nome_categoria) = 'ELETRODOMESTICOS' OR UPPER (nome_categoria) = 'PERFUMARIA' OR UPPER (nome_categoria) = 'ACESSORIOS'),
desc_categoria VARCHAR(200),
data_criacao_categoria DATETIME DEFAULT GETDATE()
);
GO
CREATE TABLE tb_produto(
cod_produto BIGINT IDENTITY PRIMARY KEY,
cod_usuario_produto BIGINT FOREIGN KEY REFERENCES tb_usuario (cod_usuario),
cod_categoria_produto BIGINT FOREIGN KEY REFERENCES tb_categoria (cod_categoria),
nome_produto VARCHAR(80) NOT NULL,
descricao_produto VARCHAR(200) NOT NULL,
preco_produto DECIMAL(10,2) NOT NULL,
imagem1_produto VARBINARY(MAX),
imagem2_produto VARBINARY(MAX),
imagem3_produto VARBINARY(MAX),
imagem4_produto VARBINARY(MAX),
status_produto VARCHAR(10) NOT NULL CHECK(UPPER (status_produto) = 'INATIVO' OR UPPER (status_produto) = 'ATIVO'),
local_produto VARCHAR(20) NOT NULL CHECK(UPPER (local_produto) = 'ZONA NORTE' OR UPPER (local_produto) = 'ZONA SUL' OR UPPER (local_produto) = 'ZONA LESTE' OR UPPER (local_produto) = 'ZONA OESTE') ,
data_produto DATETIME DEFAULT GETDATE()
);
GO
CREATE TABLE tb_pedido(
num_pedido BIGINT IDENTITY PRIMARY KEY,
cod_produto_pedido BIGINT FOREIGN KEY REFERENCES tb_produto(cod_produto),
cod_usuario_pedido BIGINT FOREIGN KEY REFERENCES tb_usuario (cod_usuario),
data_criacao_pedido DATETIME DEFAULT GETDATE()
);
GO
CREATE TABLE tb_detalhe_pedido(
cod_detalheped BIGINT IDENTITY PRIMARY KEY,
cod_pedido_detalheped BIGINT FOREIGN KEY REFERENCES tb_pedido (num_pedido),
cod_produto_detalheped BIGINT FOREIGN KEY REFERENCES tb_produto (cod_produto)
);
GO
CREATE TABLE tb_chat(
cod_chat BIGINT IDENTITY PRIMARY KEY,
cod_usuario_remetente BIGINT FOREIGN KEY REFERENCES tb_usuario (cod_usuario),
cod_usuario_destinatario BIGINT FOREIGN KEY REFERENCES tb_usuario (cod_usuario),
mensagem VARCHAR(300),
data_chat DATETIME DEFAULT GETDATE()
);

-- FIM

-- INSERINDO DADOS

-- TABELA USUARIO
INSERT INTO tb_usuario(nome_usuario,sobrenome_usuario,cpf_usuario,nasc_usuario,cel_usuario,email_usuario,senha_usuario, status_usuario, tipo_conta)
VALUES('Alcimar', 'Reis', '12345678911', '10/10/1900', '(11) 12345-6789', 'email@email.com', '123456', 'OFFLINE', 'CLIENT');
INSERT INTO tb_usuario(nome_usuario,sobrenome_usuario,cpf_usuario,nasc_usuario,cel_usuario,email_usuario,senha_usuario, status_usuario, tipo_conta)
VALUES('Luiz', 'Ricardo', '12345678912', '10/10/1901', '(12) 22345-6789', 'email2@email.com', '1234567', 'ONLINE', 'CLIENT');
INSERT INTO tb_usuario(nome_usuario,sobrenome_usuario,cpf_usuario,nasc_usuario,cel_usuario,email_usuario,senha_usuario, status_usuario, tipo_conta)
VALUES('ADMIN', 'ADMIN', '12345678913', '10/10/2000', '(13) 33345-6789', 'adm@adm.com', '987654321', 'ONLINE', 'ADM');

-- TABELA CATEGORIA
INSERT INTO tb_categoria(nome_categoria,desc_categoria)
VALUES('MOVEIS','Cadeira, Mesa...'),
('ELETRODOMESTICOS','Geladeira, Fogão...'),
('PERFUMARIA','Shampoo, BodySplash...'),
('ACESSORIOS','Brinco, Colar, Relogio...');

-- TABELA PRODUTO
INSERT INTO tb_produto(cod_usuario_produto, cod_categoria_produto, nome_produto, descricao_produto, preco_produto, status_produto, local_produto)
VALUES(1, 1,'Cadeira de jantar', 'Cadeira com pequenos arranhoes', 120.80, 'ATIVO', 'ZONA NORTE'),
(2,4,'Brinco de ouro', 'brinco novo usado uma vez', 1000.50, 'INATIVO', 'ZONA SUL');


SELECT * FROM tb_usuario 
SELECT * FROM tb_categoria
SELECT * FROM tb_produto

SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'tb_detalhe_pedido'

ALTER TABLE tb_produto ALTER COLUMN imagem1_produto VARBINARY(MAX);


-- CRIPTOGRAFIA DE SENHA USANDO HASH

-- Criar procedimento para inserir usuário com senha criptografada (usando SHA-256)
CREATE PROCEDURE sp_insert_usuario
    @nome_usuario VARCHAR(100),
    @sobrenome_usuario VARCHAR(100),
    @cpf_usuario VARCHAR(11),
    @nasc_usuario DATE,
    @cel_usuario VARCHAR(15),
    @email_usuario VARCHAR(100),
    @senha_usuario VARCHAR(255),  -- Senha fornecida pelo usuário
    @status_usuario VARCHAR(50),
    @tipo_conta VARCHAR(50)
AS
BEGIN
    DECLARE @senha_hash VARBINARY(64);  -- O hash da senha

    -- Gerar o hash da senha usando o algoritmo SHA-256
    SET @senha_hash = HASHBYTES('SHA2_256', @senha_usuario);

    -- Inserir o usuário na tabela com a senha criptografada
    INSERT INTO tb_usuario (nome_usuario, sobrenome_usuario, cpf_usuario, nasc_usuario, cel_usuario, email_usuario, senha_usuario, status_usuario, tipo_conta)
    VALUES (@nome_usuario, @sobrenome_usuario, @cpf_usuario, @nasc_usuario, @cel_usuario, @email_usuario, @senha_hash, @status_usuario, @tipo_conta);
END;



-- VERIFICAÇÃO DE SENHA NO LOGIN

-- Criar procedimento para verificar a senha no login
CREATE PROCEDURE sp_verificar_senha
    @cpf_usuario VARCHAR(11),
    @senha_usuario VARCHAR(255)  -- Senha fornecida pelo usuário
AS
BEGIN
    DECLARE @senha_hash VARBINARY(64);  -- O hash da senha fornecida
    DECLARE @senha_armazenada VARBINARY(64);  -- O hash da senha armazenado

    -- Gerar o hash da senha fornecida pelo usuário
    SET @senha_hash = HASHBYTES('SHA2_256', @senha_usuario);

    -- Obter o hash da senha armazenada no banco de dados
    SELECT @senha_armazenada = CONVERT(VARBINARY(64), senha_usuario)
    FROM tb_usuario
    WHERE cpf_usuario = @cpf_usuario;

    -- Comparar o hash gerado com o hash armazenado
    IF @senha_hash = @senha_armazenada
    BEGIN
        PRINT 'Login bem-sucedido!';
    END
    ELSE
    BEGIN
        PRINT 'Credenciais inválidas!';
    END
END;



-- CHAMANDO OS PROCEDIMENTOS

EXEC sp_insert_usuario
    @nome_usuario = 'João',
    @sobrenome_usuario = 'Silva',
    @cpf_usuario = '12345678900',
    @nasc_usuario = '1990-01-01',
    @cel_usuario = '11987654321',
    @email_usuario = 'joao.silva@example.com',
    @senha_usuario = 'minhasenha123',  -- Senha fornecida em texto claro
    @status_usuario = 'ONLINE',
    @tipo_conta = 'CLIENT';


-- Exemplo de chamada para verificar a senha
EXEC sp_verificar_senha
    @cpf_usuario = '12345678900',
    @senha_usuario = 'minhasenha123';  -- Senha fornecida em texto claro