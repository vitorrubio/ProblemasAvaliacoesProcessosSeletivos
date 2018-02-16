using AvaliacaoCaixaCaixaEletronico;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AvaliacaoCaixaEletronico.Test
{
    [TestClass]
    public class SaldoCedulaTest
    {
        [TestMethod]
        public void GetSaldoCelulaTest()
        {
            SaldoCedula sc = new SaldoCedula(10, new Cedula { Nome = "R$ 20,00", Valor = 20 });
            Assert.AreEqual(sc.Cedula.Valor * sc.QtdCedula, sc.GetSaldoCelula());
        }
    }
}
