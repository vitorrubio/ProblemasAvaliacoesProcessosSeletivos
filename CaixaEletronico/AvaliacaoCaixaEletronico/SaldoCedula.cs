using System;
using System.Collections.Generic;
using System.Text;

namespace AvaliacaoCaixaCaixaEletronico
{
    /// <summary>
    /// essa classe simulará o dispenser
    /// </summary>
    public class SaldoCedula
    {
        #region membros privados

        private Cedula _cedula;

        #endregion


        #region constructors

        public SaldoCedula(int qtd, Cedula cedula)
        {
            this._cedula = cedula;
            this.QtdCedula = qtd;
        }

        #endregion


        #region propriedades públicas

        public int QtdCedula { get; set; }

        public virtual Cedula Cedula {get{return _cedula;} }

        #endregion


        #region métodos públicos

        public int GetSaldoCelula()
        {
            return this.QtdCedula * this._cedula.Valor;
        }

        #endregion

    }
}
