using System.Net;

namespace Aula02_ControleDeFuncionarios
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            var empresaController = new Controladores.EmpresaController();
            var obterEmpresasResponse = empresaController.ObterEmpresas();
            
            if (obterEmpresasResponse.StatusCode.Equals(HttpStatusCode.OK))
            {
                Console.WriteLine($"Mensagem: {obterEmpresasResponse.Mensagem}\n");

                foreach (var empresa in obterEmpresasResponse.Empresas)
                {
                    Console.WriteLine($"ID: {empresa.Id}, Razão Social: {empresa.RazaoSocial}, CNPJ: {empresa.Cnpj}\n");
                }
            }
            if (obterEmpresasResponse.StatusCode.Equals(HttpStatusCode.NotFound))
            {
                Console.WriteLine(obterEmpresasResponse.Mensagem);
            }

        }
    }
}
