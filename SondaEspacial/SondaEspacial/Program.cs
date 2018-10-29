using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SondaEspacial
{
    class Program
    {
        static void Main(string[] args)
        {
            var malha = new Malha(10, 10);
            var sonda1 = new Sonda(1, 1, 2, malha);
            var sonda2 = new Sonda(2, 3, 3, malha);
            var controle = new Controle(sonda1, sonda2, malha);

            controle.ExecutaAmbasSondas("MRM", "MLM");

            Console.WriteLine(controle.ToString());

            Console.ReadKey();
        }
    }
}
