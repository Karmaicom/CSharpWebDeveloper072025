namespace Aula02_ControleDeFuncionarios.Entidades
{
    /// <summary>
    /// Modelo de domínio de empresa
    /// </summary>
    public class Empresa
    {
        #region Propriedades

        public Guid Id { get; set; } = Guid.NewGuid();
        public string RazaoSocial { get; set; } = string.Empty;
        public string Cnpj { get; set; } = string.Empty;

        #endregion

        #region Relacionamentos

        public List<Funcionario> Funcionarios { get; set; } = new();

        #endregion
    }
}
