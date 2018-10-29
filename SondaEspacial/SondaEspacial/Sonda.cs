using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SondaEspacial
{
    public class Sonda
    {        
        public Sonda(int frenteDaSonda, int posicaoX, int posicaoY, Malha malha)
        {
            if (frenteDaSonda < 1) { throw new ArgumentException("1 - 4"); }
            else if (frenteDaSonda > 4) { throw new ArgumentException("1 - 4"); }
            else if (posicaoX < 0 || posicaoX > malha.CoordenadaMaxX) { throw new ArgumentException("Posição X fora da malha"); }
            else if (posicaoY < 0 || posicaoY > malha.CoordenadaMaxY) { throw new ArgumentException("Posição Y fora da malha"); }

            this.FrenteDaSonda = (EstrelaVentos)frenteDaSonda;
            this.PosicaoX = posicaoX;
            this.PosicaoY = posicaoY;
            this.Malha = malha;
        }

        public EstrelaVentos FrenteDaSonda { get; private set; }

        public int PosicaoX { get; private set; }
        public int PosicaoY { get; private set; }

        public Malha Malha { get; private set; }


        public void MoveSonda()
        {
            switch (this.FrenteDaSonda)
            {
                case EstrelaVentos.North:
                    if (!(Malha.CoordenadaMaxY < PosicaoY + 1)) { PosicaoY++; }
                    else { Console.WriteLine("Fim da Malha"); }
                    break;
                case EstrelaVentos.East:
                    if (!(Malha.CoordenadaMaxX < PosicaoX + 1)) { PosicaoX++; }
                    else { Console.WriteLine("Fim da Malha"); }
                    break;
                case EstrelaVentos.South:
                    if (!(PosicaoY < 1)) { PosicaoY--; }
                    else { Console.WriteLine("Fim da Malha"); }
                    break;
                case EstrelaVentos.West:
                    if (!(PosicaoX < 1)) { PosicaoX--; }
                    else { Console.WriteLine("Fim da Malha"); }
                    break;
            }
        }

        public void ViraSonda(char command)
        {
            if (command == 'R')
            {
                if(FrenteDaSonda == EstrelaVentos.West) { FrenteDaSonda = EstrelaVentos.North; }
                else { FrenteDaSonda++; }                
            }
            else if (command == 'L')
            {
                if(FrenteDaSonda == EstrelaVentos.North) { FrenteDaSonda = EstrelaVentos.West; }
                else { FrenteDaSonda--; }                
            }
            else { throw new ArgumentException("Comando inválido"); }
        }
    }
}