namespace CrudSqlServerDapper.Entities
{
    /// <summary>
    /// Modelo de dados para a entidade Cliente.
    /// </summary>
    public class Client
    {

        #region Properties

        public Guid Id{ get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }

        #endregion

    }
}
