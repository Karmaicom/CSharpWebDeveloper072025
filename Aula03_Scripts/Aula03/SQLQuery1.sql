use DBClients;

create table client (
	id			uniqueidentifier	not null primary key,
	name		nvarchar(150)		not null,
	email		nvarchar(50)		not null,
	birthdate	date			not null	
);
Go


insert into client(id, name, email, birthdate)
values
	(NEWID(), 'Fulano Silva', 'fulano@gmail.com', '2000-01-15'),
	(NEWID(), 'Ciclano Moura', 'ciclano@gmail.com', '2005-10-04');
Go

select * from client;

drop table client;	