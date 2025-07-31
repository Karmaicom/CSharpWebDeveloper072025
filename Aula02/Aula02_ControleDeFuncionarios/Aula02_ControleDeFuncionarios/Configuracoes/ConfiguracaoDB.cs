namespace Aula02_ControleDeFuncionarios.Configuracoes
{
    public class ConfiguracaoDB
    {

        public string ConnectioString
        {
            get
            {
                return "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DBFuncionarios;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            }
        }

    }
}
