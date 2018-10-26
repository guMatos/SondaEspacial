using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SondaEspacial
{

    public class Sonda
    {
        public EnumEstrelaVentos.EstrelaVentos FrenteDaSonda { get; private set; }

        public int PosicaoX { get; private set; }
        public int PosicaoY { get; private set; }

        public Malha Malha { get; private set; }

        public Sonda(int frenteDaSonda, int posicaoX, int posicaoY, Malha malha)
        {
            if (frenteDaSonda < 1) { throw new ArgumentException("1 - 4"); }
            else if (frenteDaSonda > 4) { throw new ArgumentException("1 - 4"); }
            else if (posicaoX < 0 || posicaoX > malha.CoordenadaMaxX) { throw new ArgumentException("Posição X fora da malha"); }
            else if (posicaoY < 0 || posicaoY > malha.CoordenadaMaxY) { throw new ArgumentException("Posição Y fora da malha"); }

            this.FrenteDaSonda = (EnumEstrelaVentos.EstrelaVentos)frenteDaSonda;
            this.PosicaoX = posicaoX;
            this.PosicaoY = posicaoY;
            this.Malha = malha;
        }

        public void MoveSonda()
        {
            switch (this.FrenteDaSonda)
            {
                case EnumEstrelaVentos.EstrelaVentos.North:
                    if (!(Malha.CoordenadaMaxY < PosicaoY + 1)) { PosicaoY++; }
                    else { Console.WriteLine("Fim da Malha"); }
                    break;
                case EnumEstrelaVentos.EstrelaVentos.East:
                    if (!(Malha.CoordenadaMaxX < PosicaoX + 1)) { PosicaoX++; }
                    else { Console.WriteLine("Fim da Malha"); }
                    break;
                case EnumEstrelaVentos.EstrelaVentos.South:
                    if (!(PosicaoY < 1)) { PosicaoY--; }
                    else { Console.WriteLine("Fim da Malha"); }
                    break;
                case EnumEstrelaVentos.EstrelaVentos.West:
                    if (!(PosicaoX < 1)) { PosicaoX--; }
                    else { Console.WriteLine("Fim da Malha"); }
                    break;
            }
        }

        public void ViraSonda(char command)
        {
            if (command == 'R')
            {
                switch (this.FrenteDaSonda)
                {
                    case EnumEstrelaVentos.EstrelaVentos.North:
                        this.FrenteDaSonda = EnumEstrelaVentos.EstrelaVentos.East;
                        break;
                    case EnumEstrelaVentos.EstrelaVentos.East:
                        this.FrenteDaSonda = EnumEstrelaVentos.EstrelaVentos.South;
                        break;
                    case EnumEstrelaVentos.EstrelaVentos.South:
                        this.FrenteDaSonda = EnumEstrelaVentos.EstrelaVentos.West;
                        break;
                    case EnumEstrelaVentos.EstrelaVentos.West:
                        this.FrenteDaSonda = EnumEstrelaVentos.EstrelaVentos.North;
                        break;
                }
            }
            else if (command == 'L')
            {
                switch (this.FrenteDaSonda)
                {
                    case EnumEstrelaVentos.EstrelaVentos.North:
                        this.FrenteDaSonda = EnumEstrelaVentos.EstrelaVentos.West;
                        break;
                    case EnumEstrelaVentos.EstrelaVentos.East:
                        this.FrenteDaSonda = EnumEstrelaVentos.EstrelaVentos.North;
                        break;
                    case EnumEstrelaVentos.EstrelaVentos.South:
                        this.FrenteDaSonda = EnumEstrelaVentos.EstrelaVentos.East;
                        break;
                    case EnumEstrelaVentos.EstrelaVentos.West:
                        this.FrenteDaSonda = EnumEstrelaVentos.EstrelaVentos.South;
                        break;
                }
            }
            else { throw new ArgumentException("Comando inválido"); }
        }
    }
}
