using Aula02_ControleDeFuncionarios.Entidades;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Aula02_ControleDeFuncionarios.Repositorios
{
    public class FuncionarioRepositorio
    {

        private readonly string _connectionString;

        public FuncionarioRepositorio()
        {
            _connectionString = new Configuracoes.ConfiguracaoDB().ConnectioString;
        }

        public List<Funcionario> ObterFuncionarios()
        {
            var query = "SELECT * FROM funcionario order by nome";

            var empresas = new List<Empresa>();

            // Abrindo conexão com o banco de dados
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Funcionario>(query).ToList();
            }
        }

        public void InserirFuncionario(Funcionario funcionario)
        {
            var query = "INSERT INTO funcionario (id, nome, cpf, matricula, dataadmissao, empresaid) " +
                        "VALUES (@Id, @Nome, @Cpf, @Matricula, @DataAdmissao, @EmpresaId)";

            // Abrindo conexão com o banco de dados
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(query, funcionario);
            }

        }
    }
}
