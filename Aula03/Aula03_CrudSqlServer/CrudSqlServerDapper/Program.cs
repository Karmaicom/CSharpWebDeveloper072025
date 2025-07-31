namespace CrudSqlServerDapper
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var controller = new Controllers.ClienteController();
            controller.Execute();
        }
    }
}
