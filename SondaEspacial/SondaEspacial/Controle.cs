using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SondaEspacial
{
    public class Controle
    {
        private readonly Malha malha;

        public Controle(Malha malha)
        {
            this.malha = malha ?? throw new ArgumentNullException(nameof(malha));
        }

        public void LeComandos(Sonda sonda, string comandos)
        {
            comandos = comandos.ToUpper();

            foreach (var letra in comandos)
            {
                if (letra == 'M')
                {
                    MoveSonda(sonda);
                } else if (letra == 'R' || letra == 'L')
                {
                    ViraSonda(sonda, letra);
                } else
                {
                    throw new ArgumentException("Comando digitado inválido.", nameof(letra));
                }
            }
        }

        public void MoveSonda(Sonda sonda)
        {
            if (SondaEstaDentroDaMalha(sonda))
            {
                switch (sonda.FrenteDaSonda)
                {
                    case EstrelaVentos.North:
                        if (sonda.PosicaoY < malha.CoordenadaMaxY && malha.PosicaoEstaVazia(sonda.PosicaoX, sonda.PosicaoY + 1)) { sonda.PosicaoY++; }
                        else { MostrarMensagemFimMalha(); }
                        break;
                    case EstrelaVentos.East:
                        if (sonda.PosicaoX < malha.CoordenadaMaxX && malha.PosicaoEstaVazia(sonda.PosicaoX + 1, sonda.PosicaoY)) { sonda.PosicaoX++; }
                        else { MostrarMensagemFimMalha(); }
                        break;
                    case EstrelaVentos.South:
                        if (sonda.PosicaoY >= 0 && malha.PosicaoEstaVazia(sonda.PosicaoX, sonda.PosicaoY - 1)) { sonda.PosicaoY--; }
                        else { MostrarMensagemFimMalha(); }
                        break;
                    case EstrelaVentos.West:
                        if (sonda.PosicaoX >= 0 && malha.PosicaoEstaVazia(sonda.PosicaoX - 1, sonda.PosicaoY)) { sonda.PosicaoX--; }
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

        public string MostraPosicaoSonda(Sonda sonda)
        {
            return "X: " + sonda.PosicaoX + " Y: " + sonda.PosicaoY + " Facing: " + sonda.FrenteDaSonda;
        }
    }
}
