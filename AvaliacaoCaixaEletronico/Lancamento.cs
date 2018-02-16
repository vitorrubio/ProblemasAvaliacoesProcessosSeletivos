using System;
using System.Collections.Generic;
using System.Text;

namespace AvaliacaoCaixaCaixaEletronico
{
    public abstract class Lancamento
    {
        #region propriedades públicas

        public virtual DateTime DataHora { get; set; }

        public virtual double Valor { get; set; }

        #endregion
    }
}
