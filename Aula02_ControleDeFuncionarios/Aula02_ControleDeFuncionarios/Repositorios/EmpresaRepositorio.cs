using Aula02_ControleDeFuncionarios.Entidades;
using Aula02_ControleDeFuncionarios.Repositorios.Responses;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Aula02_ControleDeFuncionarios.Repositorios
{
    public class EmpresaRepositorio
    {
        private readonly string _connectionString;

        public EmpresaRepositorio()
        {
            _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DBFuncionarios;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"; // Defina sua string de conexão aqui
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
