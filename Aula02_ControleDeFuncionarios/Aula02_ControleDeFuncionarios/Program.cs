using System.Net;

namespace Aula02_ControleDeFuncionarios
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var empresaController = new Controladores.EmpresaController();
            var obterEmpresasResponse = empresaController.ObterEmpresas();
            /*
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
            */

            var funcionarioController = new Controladores.FuncionarioController();
            var funcionario = new Entidades.Funcionario
            {
                Nome = "João da Silva",
                Cpf = "12345678901",
                DataAdmissao = DateTime.Now,
                Matricula = "123456",
                EmpresaId = obterEmpresasResponse.Empresas.Where(x => x.RazaoSocial.Contains("A")).FirstOrDefault().Id,
                Empresa = obterEmpresasResponse.Empresas.Where(x => x.RazaoSocial.Contains("A")).FirstOrDefault()
            };
            var inserirFuncionarioResponse = funcionarioController.CadastrarFuncionario(funcionario);

            if (inserirFuncionarioResponse.StatusCode.Equals(HttpStatusCode.OK))
            {
                Console.WriteLine($"Mensagem: {inserirFuncionarioResponse.Mensagem}\n");
                Console.WriteLine($"ID: {inserirFuncionarioResponse.Funcionario.Id}, " +
                                  $"Nome: {inserirFuncionarioResponse.Funcionario.Nome}, " +
                                  $"Cpf: {inserirFuncionarioResponse.Funcionario.Cpf}, " +
                                  $"Matricula: {inserirFuncionarioResponse.Funcionario.Matricula}, " +
                                  $"Data de Admissão: {inserirFuncionarioResponse.Funcionario.DataAdmissao}, " +
                                  $"Empresa: {inserirFuncionarioResponse.Funcionario.Empresa.RazaoSocial}\n");
            }
            else
            {
                Console.WriteLine(inserirFuncionarioResponse.Mensagem);
            }
        }
    }
}
