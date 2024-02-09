CREATE TABLE CLIENTE(
 
ID                UNIQUEIDENTIFIER            PRIMARY KEY,
NOME              VARCHAR(150)                NOT NULL,
CPF               VARCHAR(11)                 NOT NULL,
TELEFONE          VARCHAR(15)                 NOT NULL,
EMAIL             VARCHAR(50)                 NOT NULL,
DATANASCIMENTO    DATETIME                    NOT NULL,
ATIVO             INT                         NOT NULL DEFAULT 1);
GO