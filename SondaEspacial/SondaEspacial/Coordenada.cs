using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SondaEspacial
{
    public class Coordenada
    {
        public Coordenada(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; private set; }
        public int Y { get; private set; }
        public Sonda Sonda { get; set; }

        public bool EstaOcupado
        {
            get
            {
                return this.Sonda != null;
            }
        }
    }
}
