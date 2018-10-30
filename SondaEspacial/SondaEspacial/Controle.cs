using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SondaEspacial
{
    class Controle
    {
        private readonly Malha malha;

        public Controle(Malha malha)
        {
            this.malha = malha ?? throw new ArgumentNullException(nameof(malha));
        }

        public void MoveSonda(Sonda sonda)
        {
            if (SondaEstaDentroDaMalha(sonda))
            {
                switch (sonda.FrenteDaSonda)
                {
                    case EstrelaVentos.North:
                        if (sonda.PosicaoY < malha.CoordenadaMaxY){ sonda.PosicaoY++; }
                        else { MostrarMensagemFimMalha(); }
                        break;
                    case EstrelaVentos.East:
                        if (sonda.PosicaoX < malha.CoordenadaMaxX) { sonda.PosicaoX++; }
                        else { MostrarMensagemFimMalha(); }
                        break;
                    case EstrelaVentos.South:
                        if (sonda.PosicaoY >= 0) { sonda.PosicaoY--; }
                        else { MostrarMensagemFimMalha(); }
                        break;
                    case EstrelaVentos.West:
                        if (sonda.PosicaoX >= 0) { sonda.PosicaoX--; }
                        else { MostrarMensagemFimMalha(); }
                        break;
                }
            }
            else { throw new ArgumentException("Sonda fora da malha"); }
        }

        private static void MostrarMensagemFimMalha()
        {
            Console.WriteLine("Fim da Malha");
        }

        public void ViraSonda(Sonda sonda, char lado)
        {
            if (SondaEstaDentroDaMalha(sonda))
            {
                if (lado == 'R')
                {
                    if (sonda.FrenteDaSonda == EstrelaVentos.West) { sonda.FrenteDaSonda = EstrelaVentos.North; }
                    else { sonda.FrenteDaSonda++; }
                }
                else if (lado == 'L')
                {
                    if (sonda.FrenteDaSonda == EstrelaVentos.North) { sonda.FrenteDaSonda = EstrelaVentos.West; }
                    else { sonda.FrenteDaSonda--; }
                }
                else { throw new ArgumentException("Comando inválido"); }
            }
            else { throw new ArgumentException("Sonda fora da malha"); }
        }

        private bool SondaEstaDentroDaMalha(Sonda sonda)
        {
            return SondaEstaNaCoordenadaCorreta(sonda.PosicaoX, malha.CoordenadaMaxX) &&
                SondaEstaNaCoordenadaCorreta(sonda.PosicaoY, malha.CoordenadaMaxY);
        }

        private bool SondaEstaNaCoordenadaCorreta(int posicaoSonda, int posicaoMalha)
        {
            return posicaoSonda <= posicaoMalha && posicaoSonda > 0;
        }

        public override string ToString()
        {
            return "X: " + Sonda1.PosicaoX + " Y: " + Sonda1.PosicaoY + " Facing: " + Sonda1.FrenteDaSonda + "\n" +
                "X: " + Sonda2.PosicaoX + " Y: " + Sonda2.PosicaoY + " Facing: " + Sonda2.FrenteDaSonda;
        }
    }
}
