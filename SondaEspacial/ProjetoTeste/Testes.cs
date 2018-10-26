using Microsoft.VisualStudio.TestTools.UnitTesting;
using SondaEspacial;

namespace ProjetoTeste
{
    [TestClass]
    public class Testes
    {
        [TestMethod]
        public void TesteCriacaoMalha()
        {
            var malha = new Malha(3, 3);

            Assert.AreEqual(3, malha.CoordenadaMaxX);
            Assert.AreEqual(3, malha.CoordenadaMaxY);
        }

        [TestMethod]
        public void TesteViraSonda()
        {
            var sonda = new Sonda(1, 1, 1, new Malha(5, 5));
            sonda.ViraSonda('R');

            Assert.AreEqual((EnumEstrelaVentos.EstrelaVentos)2, sonda.FrenteDaSonda);
        }

        [TestMethod]
        public void TesteMoveSonda()
        {
            var sonda = new Sonda(1, 1, 1, new Malha(5, 5));
            sonda.MoveSonda();

            Assert.AreEqual(2, sonda.PosicaoY);
        }
    }
}
