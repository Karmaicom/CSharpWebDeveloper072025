using Aula02_ControleDeFuncionarios.Entidades;
using Aula02_ControleDeFuncionarios.Repositorios;
using Aula02_ControleDeFuncionarios.Repositorios.Responses;

namespace Aula02_ControleDeFuncionarios.Controladores
{
    public class FuncionarioController
    {
        private readonly FuncionarioRepositorio _repositorio;

        public FuncionarioController()
        {
            _repositorio = new FuncionarioRepositorio();
        }

        public InserirFuncionarioResponse CadastrarFuncionario(Funcionario funcionario)
        {
            try
            {
                _repositorio.InserirFuncionario(funcionario);

                // Construindo objeto InserirFuncionarioResponse
                return new InserirFuncionarioResponse
                {
                    Funcionario = funcionario,
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Mensagem = "Empresas obtidas com sucesso."
                };
            }
            catch (Exception ex)
            {
                return new InserirFuncionarioResponse
                {
                    Funcionario = funcionario,
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                    Mensagem = $"Ocorreu um erro ao inserir um funcionario: {ex.Message}"
                };
            }
        }
    }
}
