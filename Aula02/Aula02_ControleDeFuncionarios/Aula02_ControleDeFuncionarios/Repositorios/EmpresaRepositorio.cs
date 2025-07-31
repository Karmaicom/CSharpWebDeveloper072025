using Aula02_ControleDeFuncionarios.Entidades;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Aula02_ControleDeFuncionarios.Repositorios
{
    public class EmpresaRepositorio
    {
        private readonly string _connectionString;

        public EmpresaRepositorio()
        {
            _connectionString = new Configuracoes.ConfiguracaoDB().ConnectioString;
        }

        public List<Empresa> ObterEmpresas()
        {
            var query = "SELECT * FROM empresa order by razaosocial";

            var empresas = new List<Empresa>();

            // Abrindo conexão com o banco de dados
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Empresa>(query).ToList();
            }            
        }

    }
}
