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
    }
}
