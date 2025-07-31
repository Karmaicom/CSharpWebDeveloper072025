namespace Aula05_AtendenteVirtual;

public class Program
{
    public static void Main(string[] args)
    {
        var atendimentoController = new Controllers.AtendimentoController();

        atendimentoController.RealizarAtendimento();
    }
}

