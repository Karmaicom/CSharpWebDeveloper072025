namespace CrudSqlServerDapper.Settings
{
    public class AppSettings
    {

        public string ConnectionString
        {
            get
            {
                return "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DBClients;Integrated Security=True;";
            }
        }
    }
}
