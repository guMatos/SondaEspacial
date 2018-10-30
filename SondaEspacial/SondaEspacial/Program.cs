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
            var controle = new Controle(malha);

            Console.ReadKey();
        }
    }
}