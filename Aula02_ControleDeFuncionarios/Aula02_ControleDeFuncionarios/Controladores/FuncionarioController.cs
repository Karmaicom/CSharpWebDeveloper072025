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

        public ObterFuncionarioResponse ObterFuncionarios()
        {
            try
            {
                var funcionarios = _repositorio.ObterFuncionarios();

                // Construindo objeto ObterFuncionarioResponse
                if (funcionarios.Any())
                {
                    return new ObterFuncionarioResponse
                    {
                        Funcionarios = funcionarios,
                        StatusCode = System.Net.HttpStatusCode.OK,
                        Mensagem = "Empresas obtidas com sucesso."
                    };
                }
                else
                {
                    return new ObterFuncionarioResponse
                    {
                        Funcionarios = new List<Funcionario>(),
                        StatusCode = System.Net.HttpStatusCode.NotFound,
                        Mensagem = "Nenhum funcionário encontrado."
                    };
                }
            }
            catch (Exception ex)
            {
                return new ObterFuncionarioResponse
                {
                    Funcionarios = new List<Funcionario>(),
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                    Mensagem = $"Ocorreu um erro ao obter os funcionários: {ex.Message}"
                };
            }
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
