using Aula02_ControleDeFuncionarios.Entidades;
using System.Net;

namespace Aula02_ControleDeFuncionarios.Repositorios.Responses
{
    public class ObterEmpresasResponse
    {
        public List<Empresa> Empresas { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string? Mensagem { get; set; }
    }
}
