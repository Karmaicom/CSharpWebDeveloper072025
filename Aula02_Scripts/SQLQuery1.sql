use DBFuncionarios;

create table empresa (
	id	uniqueidentifier not null primary key,
	razaosocial	varchar(150) not null,
	cnpj	varchar(20) not null unique
);
GO

insert into empresa (id, razaosocial, cnpj) values
	(newid(), 'Empresa A', '12.345.678/0001-90'),
	(newid(), 'Empresa B', '98.765.432/0001-01'),
	(newid(), 'Empresa C', '11.222.333/0001-44');
GO

create table funcionario (
	id	uniqueidentifier not null primary key,
	nome	varchar(100) not null,
	cpf		varchar(14) not null unique,
	matricula varchar(15) not null,
	dataadmissao date not null,
	empresaid	uniqueidentifier not null,
	constraint fk_empresa foreign key (empresaid) references empresa(id)
);
GO

Select * from empresa;