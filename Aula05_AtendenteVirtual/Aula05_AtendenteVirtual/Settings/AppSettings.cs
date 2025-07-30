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
            return "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"; 
        }
    }
}

