CREATE DATABASE bd_corretora
    WITH
    OWNER = postgres
    ENCODING = 'UTF8'
    CONNECTION LIMIT = -1
    IS_TEMPLATE = False;
	
CREATE TABLE imoveis_tb(
    IdImovel serial not null primary key,
	Tipo varchar(200),
    Descricao varchar (500),
	DataPublicacao timestamp,
	ValorImovel decimal,
	ValorEstimadoDocumentacao decimal,
	AceitaFinanciamento varchar(200),
	Observacao varchar (500),
	Cep varchar (100),
	Logadouro varchar(100),
	Numero varchar (100),
	Bairro varchar (100),
	Cidade varchar (100),
	UF varchar (50)
);
create table anexo_imovel_tb(
		IdIAnexo serial not null primary key,
		IdImovel integer not null,
		AnexoBase64 varchar not null,
		ExtensaoArquivo varchar(10),
		constraint IdImovel_FK foreign key(IdImovel)
		references imoveis_tb(IdImovel)
);

create table contato_tb(
    IdContato serial not null primary key,
	IdImovel integer,
	Nome varchar (100),
	Celular varchar(100),
	Email varchar(100),
	Messagem varchar(500),
    CONSTRAINT IdImovel_fk FOREIGN key(IdImovel)
    REFERENCES imoveis_tb(IdImovel)
);
select * from imoveis_tb
select * from anexo_imovel_tb
