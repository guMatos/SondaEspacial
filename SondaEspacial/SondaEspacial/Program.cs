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
            var random = new Random();
            var malha = new Malha(10, 10);
            var sonda1 = new Sonda(1, 1, 2);
            var sonda2 = new Sonda(2, 3, 3);
            var controle = new Controle(malha);           

            Console.ReadKey();
        }
    }
}
