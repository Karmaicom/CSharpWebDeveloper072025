using CrudSqlServerDapper.Entities;
using CrudSqlServerDapper.Settings;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudSqlServerDapper.Repostiories
{
    /// <summary>
    /// Repositorio de dados para CRUD de clientes
    /// em um banco de dados do SqlServer utilizando Dapper.
    /// </summary>
    public class ClientRepository
    {
        /// <summary>
        /// Atributo privado que contem uma referencia da classe AppSettings
        /// </summary>
        private AppSettings _appSettings = new AppSettings();


        /// <summary>
        /// Método para receber um registro de cliente
        /// e inserir os dados na tabela do banco de dados sqlserver
        /// </summary>
        /// <param name="client"></param>
        public void Insert(Client client)
        {
            var query = @"insert into client(id, name, email, birthdate)
                           values(@Id, @Name, @Email, @Birthdate)";

            using (var connection = new SqlConnection(_appSettings.ConnectionString))
            {
                connection.Execute(query, connection);
            }
        }

        /// <summary>
        /// Método para retornar uma lista com todos os clientes
        /// que estão cadastrados no banco de dados sqlserver
        /// </summary>
        /// <returns></returns>
        public List<Client> GetAll()
        {
            var query = @"select id, name, email, birthdate from client order by name";

            using (var connection = new SqlConnection(_appSettings.ConnectionString))
            {
                return connection.Query<Client>(query).ToList();
            }
        }
    }
}
