using AvaliacaoCaixaCaixaEletronico;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AvaliacaoCaixaEletronico.Test
{
    [TestClass]
    public class CaixaEletronicoTest
    {
        [TestMethod]
        public void ExibirSaldoTest()
        {
            CaixaEletronico caixa = new CaixaEletronico(10, 10, 100, 100);
            caixa.ExibirSaldo();
        }

        [TestMethod]
        public void GetSaldoCelulaTest()
        {
            CaixaEletronico caixa = new CaixaEletronico(1000, 1000, 100, 100);
            caixa.ExibirExtrato();
        }

        [TestMethod]
        public void RealizarDepositoTest()
        {
            CaixaEletronico caixa = new CaixaEletronico(50, 50, 50, 50);
            caixa.RealizarDeposito(10);
            caixa.ExibirExtrato();
        }

        [TestMethod]
        public void RealizarSaqueTest()
        {
            CaixaEletronico caixa = new CaixaEletronico(20, 20, 20, 20);
            
            caixa.RealizarSaque(1230);
            caixa.ExibirExtrato();
            caixa.ExibirSaldo();
        }
    }
}
