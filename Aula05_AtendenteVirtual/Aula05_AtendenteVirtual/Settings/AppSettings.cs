namespace Aula05_AtendenteVirtual.Settings;

/// <summary>
/// Classe para mapear as configurações globais da aplicação.
/// </summary>
public class AppSettings
{

    public string ConnectionString {
        get
        {
            return "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BDAtendimentos;Integrated Security=True;";
        }     
    }

    public string OpenAIApiKey
    {
        get
        {
            // Coloque aqui sua chave de API da OpenAI
            return "key gerada no dashboard da openai"; 
        }
    }
}

