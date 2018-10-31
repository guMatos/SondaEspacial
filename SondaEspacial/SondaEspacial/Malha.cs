using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SondaEspacial
{
    public class Malha
    {
        public Malha(int coordenadaMaxX, int coordenadaMaxY)
        {
            if (coordenadaMaxX < 1) { throw new ArgumentException("Coordenada X não pode ser menor que 1"); }
            else if (coordenadaMaxY < 1) { throw new ArgumentException("Coordenada Y não pode ser menor que 1"); }

            this.CoordenadaMaxX = coordenadaMaxX;
            this.CoordenadaMaxY = coordenadaMaxY;
            Posicoes = new Coordenada[coordenadaMaxX, coordenadaMaxY];

            for (int i = 0; i <= CoordenadaMaxX; i++)
            {
                for (int j = 0; j <= CoordenadaMaxY; j++)
                {
                    Posicoes[i, j] = new Coordenada(i, j);
                }
            }
        }
        private Coordenada[,] Posicoes { get; set; }
        public int CoordenadaMaxX { get; private set; }
        public int CoordenadaMaxY { get; private set; }

        public bool PosicaoEstaVazia(int coordenadaX, int coordenadaY)
        {
            bool estaVazia = true;
            for (int i = 0; i <= CoordenadaMaxX; i++)
            {
                for (int j = 0; j <= CoordenadaMaxY; j++)
                {
                    if (Posicoes[i, j].EstaOcupado) { estaVazia = false; }
                }
            }
            return estaVazia;
        }

        public void AdicionaSonda(Sonda sonda)
        {
            if (PosicaoEstaVazia(sonda.PosicaoX, sonda.PosicaoY))
            {
                Posicoes[sonda.PosicaoX, sonda.PosicaoY].Sonda = sonda;
            }
        }
    }
}