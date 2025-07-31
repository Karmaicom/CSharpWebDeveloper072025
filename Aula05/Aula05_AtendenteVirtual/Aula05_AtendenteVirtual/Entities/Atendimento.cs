namespace Aula05_AtendenteVirtual.Entities
{
    /// <summary>
    /// Modelo de dados da entidade Atendimento.
    /// </summary>
    public class Atendimento
    {

        public Guid Id { get; set; } = Guid.NewGuid();
        public string NomeUsuario { get; set; } = string.Empty;
        public DateTime DataHora { get; set; } = DateTime.Now;
        public string Pergunta { get; set; } = string.Empty;
        public string Resposta { get; set; } = string.Empty;

    }
}
