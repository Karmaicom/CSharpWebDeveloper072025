using Aula02_ControleDeFuncionarios.Entidades;
using Aula02_ControleDeFuncionarios.Repositorios;
using Aula02_ControleDeFuncionarios.Repositorios.Responses;

namespace Aula02_ControleDeFuncionarios.Controladores
{
    public class EmpresaController
    {
        private readonly EmpresaRepositorio _repositorio;

        public EmpresaController()
        {
            _repositorio = new EmpresaRepositorio();
        }

        public ObterEmpresasResponse ObterEmpresas()
        {
            var empresas = _repositorio.ObterEmpresas();

            // Construindo objeto ObterEmpresaResponse
            if (empresas.Any())
            {
                return new ObterEmpresasResponse
                {
                    Empresas = empresas,
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Mensagem = "Empresas obtidas com sucesso."
                };
            }
            else
            {
                return new ObterEmpresasResponse
                {
                    Empresas = new List<Empresa>(),
                    StatusCode = System.Net.HttpStatusCode.NotFound,
                    Mensagem = "Nenhuma empresa encontrada."
                };
            }
        }
}
