using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SondaEspacial
{
    class Controle
    {        
        public Controle(Sonda sonda1, Sonda sonda2, Malha malha)
        {
            if(sonda1.PosicaoX == sonda2.PosicaoX && sonda1.PosicaoY == sonda2.PosicaoY) { throw new ArgumentException("As sondas não podem ter posições iguais"); }
            else if(sonda1.PosicaoX < 1 || sonda1.PosicaoX > malha.CoordenadaMaxX || sonda1.PosicaoY < 1 || sonda1.PosicaoY > malha.CoordenadaMaxY)
            {
                throw new ArgumentException("Sonda 1 está fora da malha");
            }
            else if(sonda2.PosicaoX < 1 || sonda2.PosicaoX > malha.CoordenadaMaxX || sonda2.PosicaoY < 1 || sonda2.PosicaoY > malha.CoordenadaMaxY)
            {
                throw new ArgumentException("Sonda 2 está fora da malha");
            }

            this.Sonda1 = sonda1;
            this.Sonda2 = sonda2;
            this.Malha = malha;
        }

        public Sonda Sonda1 { get; private set; }
        public Sonda Sonda2 { get; private set; }
        public Malha Malha { get; private set; }

        public void ExecutaAmbasSondas(string commandSonda1, string commandSonda2)
        {
            foreach (char commandChar in commandSonda1)
            {
                if (commandChar == 'L' || commandChar == 'R') { Sonda1.ViraSonda(commandChar); }
                else if(commandChar == 'M') { Sonda1.MoveSonda(); }
            }

            if (Sonda1.PosicaoX == Sonda2.PosicaoX && Sonda1.PosicaoY == Sonda2.PosicaoY) { throw new Exception("Não podem ficar na mesma posição"); }

            foreach (char commandChar in commandSonda2)
            {
                if (commandChar == 'L' || commandChar == 'R') { Sonda2.ViraSonda(commandChar); }
                else if (commandChar == 'M') { Sonda2.MoveSonda(); }
            }
            if (Sonda1.PosicaoX == Sonda2.PosicaoX && Sonda1.PosicaoY == Sonda2.PosicaoY) { throw new Exception("Não podem ficar na mesma posição"); }
        }

        public override string ToString()
        {
            return "X: " + Sonda1.PosicaoX + " Y: " + Sonda1.PosicaoY + " Facing: " + Sonda1.FrenteDaSonda + "\n" +
                "X: " + Sonda2.PosicaoX + " Y: " + Sonda2.PosicaoY + " Facing: " + Sonda2.FrenteDaSonda;
        }
    }
}
