﻿namespace Aula02_ControleDeFuncionarios.Entidades
{
    /// <summary>
    /// Modelo de domínio para funcionário
    /// </summary>
    public class Funcionario
    {
        #region Propriedades

        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public string Matricula { get; set; } = string.Empty;
        public DateTime DataAdmissao { get; set; }
        public Guid EmpresaId { get; set; }

        #endregion

        #region Relacionamentos
        public Empresa? Empresa { get; set; }

        #endregion
    }


}
