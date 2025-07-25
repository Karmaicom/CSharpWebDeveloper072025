using Aula04_ConsultaCep.Controllers;

namespace Aula04_ConsultaCep
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cepController = new CepController();
            cepController.RealizarConsulta();

        }
    }
}
