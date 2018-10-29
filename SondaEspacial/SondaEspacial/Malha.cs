using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SondaEspacial
{
    public class Malha
    {      
        public Malha(int coordenadaX, int coordenadaY)
        {
            if (coordenadaX < 1) { throw new ArgumentException("Coordenada X não pode ser menor que 1"); }
            else if (coordenadaY < 1) { throw new ArgumentException("Coordenada Y não pode ser menor que 1"); }

            this.CoordenadaMaxX = coordenadaX;
            this.CoordenadaMaxY = coordenadaY;
        }

        public int CoordenadaMaxX { get; private set; }
        public int CoordenadaMaxY { get; private set; }
    }
}