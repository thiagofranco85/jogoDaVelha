
using System;

namespace JogoDaVelhaConsole.Classes
{
    public class Jogada
    {
        public Jogador Jogador { get; set; }
        public Peca Peca { get; set; }
        public Tabuleiro Tabuleiro { get; set; }
        public int PosicaoLinha { get; set; }
        public int PosicaoColuna { get; set; }

        public Jogada( Jogador jogador,Tabuleiro tabuleiro )
        {
            Jogador = jogador;
            Peca = jogador.Peca;
            Tabuleiro = tabuleiro;           
        }

        public void Jogar( int posicaoLinha, int posicaoColuna )
        {
            bool posicaoLivre = this.Tabuleiro.VerificarPosicaoLivre(posicaoLinha, posicaoColuna);

            if( ! posicaoLivre)
            {
                throw new Exception("Posição já foi jogada. Observe o tabuleiro e tente novamente.");
            }

            this.Tabuleiro.Casas[posicaoLinha, posicaoColuna] = Jogador.Peca;
            
        }


    }
}