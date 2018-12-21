using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaVelhaConsole.Classes
{
    public class Tabuleiro
    {
        public int NumLinhas { get; private set; }
        public int NumColunas { get; private set; }
        public Peca[,] Casas  { get; private set; }

        public Tabuleiro()
        {
            NumLinhas = 3;
            NumColunas = 3;
            Casas = new Peca[NumLinhas, NumColunas];
        }

        public bool VerificarPosicaoLivre(int linha, int coluna)
        {
            bool retorno = false;
            if( this.Casas[linha, coluna] == Peca._)
            {
                retorno = true;
            }
            return retorno;
        }

        public string Renderizar()
        {
            string tabuleiro = "";
            for (int i = 0; i < this.NumLinhas; i++)
            {
                for (int j = 0; j < this.NumColunas; j++)
                {
                    string quebraLinha = (j == this.NumLinhas - 1) ? "\n" : " ";
                    tabuleiro += this.Casas[i, j] + quebraLinha;
                }
            }

            return tabuleiro + "\n\n\n";
        }

        private bool VerificaTresIguais(Peca[] pecaPosicaoes)
        { 
            for (int i = 0; i < pecaPosicaoes.Length; i++)
            {
                if (pecaPosicaoes[i].Equals(Peca._))
                {
                    return false;
                } 

                for (int j = 0; j < pecaPosicaoes.Length; j++)
                {
                    if(pecaPosicaoes[i].Equals(pecaPosicaoes[j]) == false )
                    {
                        return false;
                    }
                } 
            }

            return true;
        }

        public bool VerificarVencedor()
        {
            bool todosIguaisLinhasVertical, todosIguaisLinhasHorizontal;
            bool todosIguaisDiagonal1;
            bool todosIguaisDiagonal2;
            bool retorno = false;

            Peca[] pecaPosicaoesHorizontal =  new Peca[3];
            Peca[] pecaPosicaoesVertical = new Peca[3];
            for (int i=0; i<NumLinhas; i++)
            {
                for (int j = 0; j < NumColunas; j++)
                {
                     pecaPosicaoesHorizontal[j] = Casas[i,j];
                     pecaPosicaoesVertical[j] = Casas[j, i];

                }

                //verifica se todos sao iguais nas retas horiz. e verticais
                todosIguaisLinhasHorizontal = VerificaTresIguais(pecaPosicaoesHorizontal);
                todosIguaisLinhasVertical = VerificaTresIguais(pecaPosicaoesVertical);

                if (todosIguaisLinhasHorizontal || todosIguaisLinhasVertical)
                {
                    return true;
                }
            }

            Peca[] pecaPosicaoes = new Peca[3];
            //verifica as diagonal 1
            pecaPosicaoes[0] = Casas[0,0];
            pecaPosicaoes[1] = Casas[1,1];
            pecaPosicaoes[2] = Casas[2,2];
            todosIguaisDiagonal1 = VerificaTresIguais(pecaPosicaoes);

            //verifica as diagonal 2
            pecaPosicaoes[0] = Casas[0, 2];
            pecaPosicaoes[1] = Casas[1, 1];
            pecaPosicaoes[2] = Casas[0, 2];
            todosIguaisDiagonal2 = VerificaTresIguais(pecaPosicaoes);

           
            if( todosIguaisDiagonal1 || todosIguaisDiagonal2)
            {
                retorno = true;
            }

            return retorno;
        }
    }
}
