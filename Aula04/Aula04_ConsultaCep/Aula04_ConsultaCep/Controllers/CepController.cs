namespace Aula04_ConsultaCep.Controllers
{
    public class CepController
    {
        public void RealizarConsulta()
        {
            Console.Write("Informe o seu Cep: ");
            var cep = Console.ReadLine();

            var cepService = new Services.CepService(); 
            var endereco = cepService.ObterEndereco(cep);
            Console.WriteLine(endereco);
        }

    }
}
