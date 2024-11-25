-- Criação do banco de dados
DROP DATABASE odasu
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
mensagem VARCHAR(200),
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


-- TABELA tb_usuario (40 registros)
INSERT INTO tb_usuario (nome_usuario, sobrenome_usuario, cpf_usuario, nasc_usuario, cel_usuario, email_usuario, senha_usuario, status_usuario, tipo_conta)
VALUES
('João', 'Silva', '12345678914', '01/01/1990', '(14) 12345-6789', 'joao.silva@email.com', 'senha123', 'ONLINE', 'CLIENT'),
('Maria', 'Oliveira', '12345678915', '02/02/1985', '(15) 22345-6789', 'maria.oliveira@email.com', 'senha456', 'OFFLINE', 'CLIENT'),
('Carlos', 'Pereira', '12345678916', '03/03/1980', '(16) 32345-6789', 'carlos.pereira@email.com', 'senha789', 'ONLINE', 'CLIENT'),
('Ana', 'Santos', '12345678917', '04/04/1975', '(17) 42345-6789', 'ana.santos@email.com', 'senha012', 'ONLINE', 'CLIENT'),
('Paula', 'Costa', '12345678918', '05/05/1992', '(18) 52345-6789', 'paula.costa@email.com', 'senha345', 'OFFLINE', 'CLIENT'),
('Felipe', 'Lima', '12345678919', '06/06/1988', '(19) 62345-6789', 'felipe.lima@email.com', 'senha678', 'ONLINE', 'CLIENT'),
('Juliana', 'Souza', '12345678920', '07/07/1993', '(20) 72345-6789', 'juliana.souza@email.com', 'senha901', 'OFFLINE', 'CLIENT'),
('Ricardo', 'Martins', '12345678921', '08/08/1982', '(21) 82345-6789', 'ricardo.martins@email.com', 'senha234', 'ONLINE', 'CLIENT'),
('Fernanda', 'Rodrigues', '12345678922', '09/09/1979', '(22) 92345-6789', 'fernanda.rodrigues@email.com', 'senha567', 'ONLINE', 'CLIENT'),
('Roberto', 'Alves', '12345678923', '10/10/1986', '(23) 22345-6780', 'roberto.alves@email.com', 'senha890', 'OFFLINE', 'CLIENT'),
('Lucas', 'Gomes', '12345678924', '11/11/1991', '(24) 32345-6780', 'lucas.gomes@email.com', 'senha1234', 'ONLINE', 'CLIENT'),
('Camila', 'Ramos', '12345678925', '12/12/1984', '(25) 42345-6780', 'camila.ramos@email.com', 'senha5678', 'OFFLINE', 'CLIENT'),
('André', 'Barbosa', '12345678926', '13/01/1995', '(26) 52345-6780', 'andre.barbosa@email.com', 'senha9012', 'ONLINE', 'CLIENT'),
('Tatiana', 'Nascimento', '12345678927', '14/02/1987', '(27) 62345-6780', 'tatiana.nascimento@email.com', 'senha3456', 'OFFLINE', 'CLIENT'),
('Eduardo', 'Freitas', '12345678928', '15/03/1994', '(28) 72345-6780', 'eduardo.freitas@email.com', 'senha7890', 'ONLINE', 'CLIENT'),
('Cristiane', 'Moreira', '12345678929', '16/04/1983', '(29) 82345-6780', 'cristiane.moreira@email.com', 'senha2345', 'OFFLINE', 'CLIENT'),
('Pedro', 'Teixeira', '12345678930', '17/05/1989', '(30) 92345-6780', 'pedro.teixeira@email.com', 'senha6789', 'ONLINE', 'CLIENT'),
('Daniela', 'Fernandes', '12345678931', '18/06/1992', '(31) 12345-6781', 'daniela.fernandes@email.com', 'senha0123', 'OFFLINE', 'CLIENT'),
('Rafael', 'Castro', '12345678932', '19/07/1990', '(32) 22345-6781', 'rafael.castro@email.com', 'senha4567', 'ONLINE', 'CLIENT'),
('Renata', 'Dias', '12345678933', '20/08/1986', '(33) 32345-6781', 'renata.dias@email.com', 'senha8901', 'OFFLINE', 'CLIENT'),
('Henrique', 'Mendes', '12345678934', '21/09/1988', '(34) 42345-6781', 'henrique.mendes@email.com', 'senha2346', 'ONLINE', 'CLIENT'),
('Flávia', 'Carvalho', '12345678935', '22/10/1991', '(35) 52345-6781', 'flavia.carvalho@email.com', 'senha5679', 'OFFLINE', 'CLIENT'),
('Gustavo', 'Vieira', '12345678936', '23/11/1985', '(36) 62345-6781', 'gustavo.vieira@email.com', 'senha8902', 'ONLINE', 'CLIENT'),
('Lara', 'Campos', '12345678937', '24/12/1993', '(37) 72345-6781', 'lara.campos@email.com', 'senha1230', 'OFFLINE', 'CLIENT'),
('Vinícius', 'Silveira', '12345678938', '25/01/1980', '(38) 82345-6781', 'vinicius.silveira@email.com', 'senha4568', 'ONLINE', 'CLIENT'),
('Carolina', 'Rezende', '12345678939', '26/02/1984', '(39) 92345-6781', 'carolina.rezende@email.com', 'senha8903', 'OFFLINE', 'CLIENT'),
('Alex', 'Pinto', '12345678940', '27/03/1982', '(40) 12345-6782', 'alex.pinto@email.com', 'senha2347', 'ONLINE', 'CLIENT'),
('Patrícia', 'Arantes', '12345678941', '28/04/1990', '(41) 22345-6782', 'patricia.arantes@email.com', 'senha5670', 'OFFLINE', 'CLIENT'),
('Marcelo', 'Lopes', '12345678942', '29/05/1988', '(42) 32345-6782', 'marcelo.lopes@email.com', 'senha8904', 'ONLINE', 'CLIENT'),
('Sílvia', 'Silva', '12345678943', '30/06/1986', '(43) 42345-6782', 'silvia.silva@email.com', 'senha2348', 'OFFLINE', 'CLIENT'),
('Bruno', 'Santos', '12345678944', '01/07/1983', '(44) 52345-6782', 'bruno.santos@email.com', 'senha5671', 'ONLINE', 'CLIENT'),
('Letícia', 'Costa', '12345678945', '02/08/1981', '(45) 62345-6782', 'leticia.costa@email.com', 'senha8905', 'OFFLINE', 'CLIENT'),
('Fabio', 'Gonçalves', '12345678946', '03/09/1990', '(46) 72345-6782', 'fabio.goncalves@email.com', 'senha1231', 'ONLINE', 'CLIENT'),
('Daniel', 'Assis', '12345678947', '04/10/1987', '(47) 82345-6782', 'daniel.assis@email.com', 'senha4569', 'OFFLINE', 'CLIENT'),
('Amanda', 'Almeida', '12345678948', '05/11/1993', '(48) 92345-6782', 'amanda.almeida@email.com', 'senha8906', 'ONLINE', 'CLIENT'),
('Igor', 'Fonseca', '12345678949', '06/12/1989', '(49) 12345-6783', 'igor.fonseca@email.com', 'senha2349', 'OFFLINE', 'CLIENT'),
('Alice', 'Braga', '12345678950', '07/01/1985', '(50) 22345-6783', 'alice.braga@email.com', 'senha5672', 'ONLINE', 'CLIENT'),
('Rodrigo', 'Farias', '12345678951', '08/02/1992', '(51) 32345-6783', 'rodrigo.farias@email.com', 'senha8907', 'OFFLINE', 'CLIENT'),
('Beatriz', 'Ribeiro', '12345678952', '09/03/1995', '(52) 42345-6783', 'beatriz.ribeiro@email.com', 'senha3450', 'ONLINE', 'ADM');


INSERT INTO tb_produto (cod_usuario_produto, cod_categoria_produto, nome_produto, descricao_produto, preco_produto, status_produto, local_produto)
VALUES
(1, 1, 'Cadeira de Cabeleireiro', 'Cadeira confortável e ajustável, ideal para salões', 750.00, 'ATIVO', 'ZONA NORTE'),
(2, 2, 'Secador de Cabelo', 'Secador profissional, alta potência', 250.00, 'ATIVO', 'ZONA SUL'),
(3, 3, 'Esmalte Gel', 'Esmalte de longa duração, diversas cores', 20.00, 'ATIVO', 'ZONA LESTE'),
(4, 4, 'Alicate de Cutícula', 'Alicate de aço inoxidável, alta precisão', 30.00, 'ATIVO', 'ZONA OESTE'),
(5, 1, 'Espelho de Parede', 'Espelho grande para salão de beleza', 500.00, 'ATIVO', 'ZONA NORTE'),
(6, 2, 'Prancha Alisadora', 'Prancha com controle de temperatura ajustável', 180.00, 'ATIVO', 'ZONA SUL'),
(7, 3, 'Creme para Massagem', 'Creme relaxante para massagens corporais', 50.00, 'INATIVO', 'ZONA LESTE'),
(8, 4, 'Toalhas para Salão', 'Kit com 10 toalhas de alta absorção', 100.00, 'ATIVO', 'ZONA OESTE'),
(9, 1, 'Carrinho Auxiliar', 'Carrinho com gavetas para organização de produtos', 350.00, 'ATIVO', 'ZONA NORTE'),
(10, 2, 'Lavatório de Cabelo', 'Lavatório com encosto ergonômico e pia acoplada', 1200.00, 'ATIVO', 'ZONA SUL'),
(11, 3, 'Pó Descolorante', 'Pó para descoloração capilar, uso profissional', 80.00, 'ATIVO', 'ZONA LESTE'),
(12, 4, 'Tinta para Cabelo', 'Tinta permanente para cabelos, várias cores', 40.00, 'INATIVO', 'ZONA OESTE'),
(13, 1, 'Organizador de Maquiagem', 'Caixa organizadora para produtos de maquiagem', 150.00, 'ATIVO', 'ZONA NORTE'),
(14, 2, 'Aspirador de Cabelos', 'Aspirador portátil para limpeza de cabelos cortados', 300.00, 'ATIVO', 'ZONA SUL'),
(15, 3, 'Shampoo Profissional', 'Shampoo de uso profissional, alta qualidade', 90.00, 'ATIVO', 'ZONA LESTE'),
(16, 4, 'Touca Térmica', 'Touca térmica para tratamentos capilares', 120.00, 'ATIVO', 'ZONA OESTE'),
(17, 1, 'Poltrona de Manicure', 'Poltrona confortável para atendimentos de manicure', 600.00, 'ATIVO', 'ZONA NORTE'),
(18, 2, 'Luminária de Mesa', 'Luminária com luz branca para precisão', 80.00, 'ATIVO', 'ZONA SUL'),
(19, 3, 'Escova de Cabelo', 'Escova profissional com cerdas naturais', 35.00, 'ATIVO', 'ZONA LESTE'),
(20, 4, 'Luvas Descartáveis', 'Pacote com 100 luvas descartáveis', 50.00, 'ATIVO', 'ZONA OESTE');


-- Outros registros para as tabelas tb_categoria, tb_produto, tb_pedido, tb_detalhe_pedido e tb_chat serão inseridos de forma semelhante.
-- Complementei a tabela tb_usuario. Se desejar, posso prosseguir com o restante.

-- TABELA tb_categoria (4 registros já foram inseridos; não são necessários mais registros conforme a especificação inicial).

-- TABELA tb_produto (40 registros)
-- Usando IDs de usuários e categorias existentes.
INSERT INTO tb_produto (cod_usuario_produto, cod_categoria_produto, nome_produto, descricao_produto, preco_produto, status_produto, local_produto)
VALUES
(1, 1, 'Mesa de Jantar', 'Mesa com 6 cadeiras, madeira maciça', 750.00, 'ATIVO', 'ZONA NORTE'),
(2, 2, 'Liquidificador', 'Liquidificador novo, 3 velocidades', 150.00, 'ATIVO', 'ZONA SUL'),
(3, 3, 'Perfume Frutado', 'Perfume cítrico, pouco usado', 200.00, 'INATIVO', 'ZONA LESTE'),
(4, 4, 'Relógio de Pulso', 'Relógio esportivo à prova dágua', 320.00, 'ATIVO', 'ZONA OESTE'),
(5, 1, 'Cama Queen Size', 'Cama com colchão semi-novo', 900.00, 'INATIVO', 'ZONA SUL'),
(6, 2, 'Fogão 4 bocas', 'Fogão novo com forno', 1200.00, 'ATIVO', 'ZONA NORTE'),
(7, 3, 'Creme Hidratante', 'Hidratante para pele seca', 50.00, 'INATIVO', 'ZONA OESTE'),
(8, 4, 'Óculos de Sol', 'Óculos com proteção UV', 280.00, 'ATIVO', 'ZONA LESTE'),
(9, 1, 'Poltrona', 'Poltrona reclinável confortável', 480.00, 'ATIVO', 'ZONA NORTE'),
(10, 2, 'Máquina de Lavar', 'Lavadora 10kg, nova', 1900.00, 'INATIVO', 'ZONA SUL'),
(11, 3, 'Perfume Amadeirado', 'Perfume masculino, pouco uso', 180.00, 'ATIVO', 'ZONA LESTE'),
(12, 4, 'Anel de Ouro', 'Anel de ouro 18k', 950.00, 'INATIVO', 'ZONA OESTE'),
(13, 1, 'Estante', 'Estante para livros e decoração', 340.00, 'ATIVO', 'ZONA NORTE'),
(14, 2, 'Aspirador de Pó', 'Aspirador novo, potente', 400.00, 'INATIVO', 'ZONA SUL'),
(15, 3, 'Shampoo Importado', 'Shampoo para cabelos secos', 80.00, 'ATIVO', 'ZONA LESTE'),
(16, 4, 'Brinco de Prata', 'Brinco delicado, estilo minimalista', 150.00, 'INATIVO', 'ZONA OESTE'),
(17, 1, 'Sofá 2 Lugares', 'Sofá confortável, tecido liso', 650.00, 'ATIVO', 'ZONA NORTE'),
(18, 2, 'Ventilador de Teto', 'Ventilador silencioso, novo', 350.00, 'INATIVO', 'ZONA SUL'),
(19, 3, 'Perfume Feminino', 'Fragrância floral, novo', 220.00, 'ATIVO', 'ZONA LESTE'),
(20, 4, 'Colar de Pérolas', 'Colar clássico de pérolas', 700.00, 'INATIVO', 'ZONA OESTE'),
(21, 1, 'Cadeira de Escritório', 'Cadeira giratória com rodízios', 240.00, 'ATIVO', 'ZONA NORTE'),
(22, 2, 'Micro-ondas', 'Micro-ondas novo, 30 litros', 600.00, 'INATIVO', 'ZONA SUL'),
(23, 3, 'Condicionador', 'Condicionador para cabelos cacheados', 70.00, 'ATIVO', 'ZONA LESTE'),
(24, 4, 'Pulseira de Prata', 'Pulseira trabalhada, nova', 120.00, 'INATIVO', 'ZONA OESTE'),
(25, 1, 'Estante para TV', 'Estante com prateleiras, madeira', 400.00, 'ATIVO', 'ZONA NORTE'),
(26, 2, 'Ferro de Passar', 'Ferro com regulagem de temperatura', 120.00, 'INATIVO', 'ZONA SUL'),
(27, 3, 'Perfume Fresh', 'Perfume unissex, aroma leve', 150.00, 'ATIVO', 'ZONA LESTE'),
(28, 4, 'Bolsa Feminina', 'Bolsa em couro legítimo', 450.00, 'INATIVO', 'ZONA OESTE'),
(29, 1, 'Mesa de Centro', 'Mesa moderna para sala', 290.00, 'ATIVO', 'ZONA NORTE'),
(30, 2, 'Purificador de Água', 'Purificador com filtro de carvão', 320.00, 'INATIVO', 'ZONA SUL'),
(31, 3, 'Creme para Mãos', 'Hidratante para pele sensível', 35.00, 'ATIVO', 'ZONA LESTE'),
(32, 4, 'Relógio de Bolso', 'Relógio vintage, edição especial', 500.00, 'INATIVO', 'ZONA OESTE'),
(33, 1, 'Rack para TV', 'Rack em MDF, cor preta', 380.00, 'ATIVO', 'ZONA NORTE'),
(34, 2, 'Lava-louças', 'Lava-louças automática', 2000.00, 'INATIVO', 'ZONA SUL'),
(35, 3, 'Creme Anti-idade', 'Creme anti-idade, uso diário', 220.00, 'ATIVO', 'ZONA LESTE'),
(36, 4, 'Anel de Ouro', 'Anel com pedras preciosas', 850.00, 'INATIVO', 'ZONA OESTE'),
(37, 1, 'Mesa de Escritório', 'Mesa com gavetas', 580.00, 'ATIVO', 'ZONA NORTE'),
(38, 2, 'Secador de Cabelo', 'Secador com difusor', 180.00, 'INATIVO', 'ZONA SUL'),
(39, 3, 'Loção Corporal', 'Loção hidratante, aroma suave', 45.00, 'ATIVO', 'ZONA LESTE'),
(40, 4, 'Brinco de Ouro', 'Brinco delicado, design moderno', 980.00, 'INATIVO', 'ZONA OESTE');

-- TABELA tb_pedido (40 registros)
-- Relacionando pedidos aos produtos e usuários de forma consistente
INSERT INTO tb_pedido (cod_produto_pedido, cod_usuario_pedido)
VALUES
(1, 1), (2, 2), (3, 3), (4, 4), (5, 5),
(6, 6), (7, 7), (8, 8), (9, 9), (10, 10),
(11, 11), (12, 12), (13, 13), (14, 14), (15, 15),
(16, 16), (17, 17), (18, 18), (19, 19), (20, 20),
(21, 21), (22, 22), (23, 23), (24, 24), (25, 25),
(26, 26), (27, 27), (28, 28), (29, 29), (30, 30),
(31, 31), (32, 32), (33, 33), (34, 34), (35, 35),
(36, 36), (37, 37), (38, 38), (39, 39), (40, 40);


-- TABELA tb_detalhe_pedido (40 registros)
-- Cada detalhe de pedido referenciando os pedidos e produtos
INSERT INTO tb_detalhe_pedido (cod_pedido_detalheped, cod_produto_detalheped)
VALUES
(1, 1), (2, 2), (3, 3), (4, 4), (5, 5),
(6, 6), (7, 7), (8, 8), (9, 9), (10, 10),
(11, 11), (12, 12), (13, 13), (14, 14), (15, 15),
(16, 16), (17, 17), (18, 18), (19, 19), (20, 20),
(21, 21), (22, 22), (23, 23), (24, 24), (25, 25),
(26, 26), (27, 27), (28, 28), (29, 29), (30, 30),
(31, 31), (32, 32), (33, 33), (34, 34), (35, 35),
(36, 36), (37, 37), (38, 38), (39, 39), (40, 40);

-- Continuando a tabela tb_chat para completar 40 registros
INSERT INTO tb_chat (cod_usuario_remetente, cod_usuario_destinatario, mensagem)
VALUES
(6, 7, 'Qual a condição do produto?'),
(7, 8, 'Está em ótimo estado, quase novo!'),
(8, 9, 'Aceita negociar o preço?'),
(9, 10, 'Podemos conversar, qual seria sua oferta?'),
(10, 11, 'Ainda está disponível?'),
(11, 12, 'Sim, disponível e pronto para envio.'),
(12, 13, 'Qual o prazo de entrega?'),
(13, 14, 'Depende da região, geralmente de 3 a 5 dias.'),
(14, 15, 'Aceita trocar por outro item?'),
(15, 16, 'Não no momento, apenas venda.'),
(16, 17, 'Você tem mais fotos do produto?'),
(17, 18, 'Sim, posso enviar mais algumas se precisar.'),
(18, 19, 'Qual a forma de pagamento?'),
(19, 20, 'Aceito transferência e cartão de crédito.'),
(20, 21, 'Esse produto tem garantia?'),
(21, 22, 'Sim, garantia de 6 meses do fabricante.'),
(22, 23, 'É possível retirar em mãos?'),
(23, 24, 'Sim, em horário combinado na Zona Norte.'),
(24, 25, 'Pode fazer um desconto para pagamento à vista?'),
(25, 26, 'Posso ver isso, me faça uma oferta.'),
(26, 27, 'Ainda está interessado no produto?'),
(27, 28, 'Sim, desculpe a demora, podemos fechar a compra.'),
(28, 29, 'Qual o valor do frete?'),
(29, 30, 'Vai depender do seu CEP, posso calcular para você.'),
(30, 31, 'Qual a cor do produto?'),
(31, 32, 'É preto, como nas fotos.'),
(32, 33, 'Você envia para fora do estado?'),
(33, 34, 'Sim, envio para todo o país.'),
(34, 35, 'O produto é original?'),
(35, 36, 'Sim, totalmente original e com nota fiscal.'),
(36, 37, 'Posso ver o produto antes de comprar?'),
(37, 38, 'Sim, podemos marcar uma visita.'),
(38, 39, 'Há algum risco de defeito?'),
(39, 40, 'Não, está em perfeito estado.'),
(40, 1, 'Obrigado pelo atendimento, vamos fechar o pedido.');

-- Inserções adicionais para tb_categoria, completando 40 registros
-- Como já havia 4 registros na tabela `tb_categoria`, iremos adicionar 36 registros adicionais.
INSERT INTO tb_categoria (nome_categoria, desc_categoria)
VALUES
('MOVEIS', 'Sofás, poltronas, cadeiras, entre outros móveis de sala.'),
('MOVEIS', 'Mesas de jantar, mesas de centro, escrivaninhas.'),
('MOVEIS', 'Guarda-roupas e armários para quarto e cozinha.'),
('MOVEIS', 'Estantes e prateleiras para organização de espaços.'),
('MOVEIS', 'Conjuntos de móveis planejados para escritório.'),
('MOVEIS', 'Camas box, beliches e camas de casal.'),
('MOVEIS', 'Aparadores e móveis decorativos.'),
('MOVEIS', 'Mesas de cabeceira e criados-mudos.'),
('ELETRODOMESTICOS', 'Aparelhos de cozinha como liquidificadores e batedeiras.'),
('ELETRODOMESTICOS', 'Forno elétrico e fogões de alta performance.'),
('ELETRODOMESTICOS', 'Geladeiras de última geração e freezers.'),
('ELETRODOMESTICOS', 'Máquinas de lavar roupas e secadoras.'),
('ELETRODOMESTICOS', 'Aspiradores de pó e outros produtos de limpeza.'),
('ELETRODOMESTICOS', 'Ventiladores de teto, portáteis e de mesa.'),
('ELETRODOMESTICOS', 'Purificadores de água e filtros de alta qualidade.'),
('ELETRODOMESTICOS', 'Ar-condicionado e aquecedores portáteis.'),
('ELETRODOMESTICOS', 'Cafeteiras automáticas e chaleiras elétricas.'),
('ELETRODOMESTICOS', 'Secadores e pranchas de cabelo.'),
('ELETRODOMESTICOS', 'Ferro de passar roupas a vapor.'),
('ELETRODOMESTICOS', 'Aparelhos de som e rádios portáteis.'),
('PERFUMARIA', 'Perfumes importados para uso diário.'),
('PERFUMARIA', 'Desodorantes e antitranspirantes.'),
('PERFUMARIA', 'Hidratantes e cremes corporais.'),
('PERFUMARIA', 'Perfumes masculinos e femininos de grife.'),
('PERFUMARIA', 'Loções pós-barba e produtos de barbear.'),
('PERFUMARIA', 'Óleos corporais e esfoliantes de pele.'),
('PERFUMARIA', 'Aromatizantes e fragrâncias para ambientes.'),
('PERFUMARIA', 'Produtos naturais e veganos para pele.'),
('ACESSORIOS', 'Relógios masculinos e femininos de várias marcas.'),
('ACESSORIOS', 'Bolsas de couro, mochilas e carteiras.'),
('ACESSORIOS', 'Bijuterias e semijoias, como brincos e pulseiras.'),
('ACESSORIOS', 'Óculos de sol e armações para óculos.'),
('ACESSORIOS', 'Cintos de couro e tecidos.'),
('ACESSORIOS', 'Chapéus, bonés e acessórios de cabelo.'),
('ACESSORIOS', 'Lenços e echarpes para várias ocasiões.'),
('ACESSORIOS', 'Itens de moda para compor looks.'),
('ACESSORIOS', 'Joias de ouro e prata, anéis e colares.');

--ALTERAR DATAS DE CRIAÇÃO TORNANDO ALEATÓRIO
-- Variáveis para controle
DECLARE @Mes INT = 1;
DECLARE @Ano INT = 2024;
DECLARE @Contador INT;

--Loop para cada mês do ano
WHILE @Mes <= 12
BEGIN
    -- Reinicia o contador de dias dentro do mês
    SET @Contador = 1;
    --Atualiza 10 registros com datas únicas para o mês
    WHILE @Contador <= 40
    BEGIN
        UPDATE TOP (1) tb_produto
        SET data_produto = DATEADD(DAY, @Contador - 1, DATEFROMPARTS(@Ano, @Mes, 1))
        WHERE MONTH(data_produto) <> @Mes OR YEAR(data_produto) <> @Ano;
        SET @Contador = @Contador + 1;
    END;
    -- Passa para o próximo mês
    SET @Mes = @Mes + 1;
END;




-- Atualizar a data de criação para datas especificas por código passado
UPDATE tb_pedido
SET data_criacao_pedido = '2024-03-10'
WHERE num_pedido BETWEEN 91 AND 100;




-- Passo 1: Contar o número atual de pedidos
SELECT COUNT(*) AS total_pedidos FROM tb_pedido;
-- Passo 2: Contar os usuários existentes
SELECT COUNT(DISTINCT cod_usuario_pedido) AS total_usuarios FROM tb_pedido;
-- Passo 3: Inserir novos pedidos até atingir o total de 120
-- Supondo que cada pedido adicionado terá um produto aleatório, um valor e uma categoria.
DECLARE @total_atual INT;
DECLARE @faltantes INT;
-- Contar pedidos atuais
SELECT @total_atual = COUNT(*) FROM tb_pedido;
-- Calcular quantos pedidos faltam para chegar a 120
SET @faltantes = 120 - @total_atual;
-- Inserir novos pedidos
WHILE @faltantes > 0
BEGIN
    -- Escolher aleatoriamente um usuário existente
    DECLARE @codigo_usuario INT;
    SELECT TOP 1 @codigo_usuario = cod_usuario 
    FROM tb_usuario 
    ORDER BY NEWID();
    -- Escolher aleatoriamente um produto existente
    DECLARE @codigo_produto INT;
    SELECT TOP 1 @codigo_produto = cod_produto 
    FROM tb_produto
    WHERE status_produto = 'ATIVO'
    ORDER BY NEWID();
    -- Inserir um novo pedido para o usuário escolhido
    INSERT INTO tb_pedido (cod_produto_pedido, cod_usuario_pedido)
    VALUES (@codigo_produto, @codigo_usuario);
    -- Atualizar o contador de pedidos faltantes
    SET @faltantes = @faltantes - 1;
END;
-- Verificar o total final
SELECT COUNT(*) AS total_pedidos_final FROM tb_pedido;


SELECT * FROM tb_usuario 
SELECT cod_usuario, email_usuario, senha_usuario FROM tb_usuario
SELECT * FROM tb_produto
SELECT * FROM tb_categoria

SELECT * FROM tb_detalhe_pedido
SELECT * FROM tb_pedido
SELECT * FROM tb_chat

