create table atendimento (
	id				uniqueidentifier not null primary key,
	nomeusuario		varchar(25) not null,
	datahora		datetime not null,
	pergunta		varchar(250) not null,
	resposta		varchar(1000) not null
);
GO


-- PROCEDURE: Inserir Atendimento
create procedure sp_inserir_atendimento
	@id					uniqueidentifier,
	@nomeusuario			varchar(25),
	@datahora			datetime,
	@pergunta			varchar(250),
	@resposta			varchar(1000)
as
begin

	begin transaction;
		insert into atendimento (
			id,
			nomeusuario,
			datahora,
			pergunta,
			resposta
		) values (
			@id,
			@nomeusuario,
			@datahora,
			@pergunta,
			@resposta
		);
	commit;
end;


-- OpenAIApiKe Sérgio
-- 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
