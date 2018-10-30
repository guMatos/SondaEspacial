using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SondaEspacial
{
    public class Sonda
    {        
        public Sonda(int frenteDaSonda, int posicaoX, int posicaoY)
        {
            if (frenteDaSonda < 1) { throw new ArgumentException("1 - 4"); }
            else if (frenteDaSonda > 4) { throw new ArgumentException("1 - 4"); }

            this.FrenteDaSonda = (EstrelaVentos)frenteDaSonda;
            this.PosicaoX = posicaoX;
            this.PosicaoY = posicaoY;
        }

        public int PosicaoX { get; set; }
        public int PosicaoY { get; set; }
        public EstrelaVentos FrenteDaSonda { get; set; }
    }
}