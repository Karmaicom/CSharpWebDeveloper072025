using Aula05_AtendenteVirtual.Entities;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Aula05_AtendenteVirtual.Repositories;
public class AtendimentoRepository
{
    private readonly string _connectionString;

    public AtendimentoRepository()
    {
        _connectionString = new Settings.AppSettings().ConnectionString;
    }

    public void Inserir(Atendimento atendimento)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Execute("sp_inserir_atendimento", new
                {
                    @Id = atendimento.Id,
                    @NomeUsuario = atendimento.NomeUsuario,
                    @DataHora = atendimento.DataHora,
                    @Pergunta = atendimento.Pergunta,
                    @Resposta = atendimento.Resposta
                },
                commandType: CommandType.StoredProcedure
            );
            
        }
    }

}
