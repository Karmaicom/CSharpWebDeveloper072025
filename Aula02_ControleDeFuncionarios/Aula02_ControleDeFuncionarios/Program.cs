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

            /*
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
                                  $"\nNome: {inserirFuncionarioResponse.Funcionario.Nome}, " +
                                  $"\nCpf: {inserirFuncionarioResponse.Funcionario.Cpf}, " +
                                  $"\nMatricula: {inserirFuncionarioResponse.Funcionario.Matricula}, " +
                                  $"\nData de Admissão: {inserirFuncionarioResponse.Funcionario.DataAdmissao.ToString("dd/MM/yyyy")}, " +
                                  $"\nEmpresa: {inserirFuncionarioResponse.Funcionario.Empresa.RazaoSocial}\n");
            }
            else
            {
                Console.WriteLine(inserirFuncionarioResponse.Mensagem);
            }
            */

            var funcionariosResponse = funcionarioController.ObterFuncionarios();

            if (funcionariosResponse.StatusCode.Equals(HttpStatusCode.OK))
            {
                Console.WriteLine($"Mensagem: {funcionariosResponse.Mensagem}\n");
                foreach (var funcionario in funcionariosResponse.Funcionarios)
                {
                    var empresa = obterEmpresasResponse.Empresas.FirstOrDefault(e => e.Id == funcionario.EmpresaId);

                    Console.WriteLine($"ID: {funcionario.Id}, " +
                                      $"\nNome: {funcionario.Nome}, \nCpf: {funcionario.Cpf}, " +
                                      $"\nMatricula: {funcionario.Matricula}, \nData de Admissão: {funcionario.DataAdmissao.ToString("dd/MM/yyyy")}, " +
                                      $"\nEmpresa: {empresa.RazaoSocial}\n");
                }
            }
            else
            {
                Console.WriteLine(funcionariosResponse.Mensagem);
            }
        }
    }
}
