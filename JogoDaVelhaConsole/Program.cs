using JogoDaVelhaConsole.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaVelhaConsole
{
    class Program
    { 
        static void Main(string[] args)
        { 
            Console.WriteLine("Escolha a peça (x ou o) do jogador 1:");
            string strPeca = Console.ReadLine();

            Peca peca = (strPeca == "X" || strPeca == "x") ? Peca.X : Peca.O;
            Jogador j1 = new Jogador(NomeJogador.Jogador1, peca);
            Jogador j2 = new Jogador(NomeJogador.Jogador2, j1.SelecionaOutraPeca());
            
            Console.WriteLine("Jogador 1: " + j1.Peca);
            Console.WriteLine("Jogador 2: " + j2.Peca);

            var tab = new Tabuleiro(); 

            for (int i=0; i<9; i++)
            {
                Jogador jogadorDaVez = i % 2 == 0 ? j1 : j2;

                Console.WriteLine("\n\nJogada do "+ jogadorDaVez.Nome + ":\nSelecione a posicao (x,y) da peça " + jogadorDaVez.Peca);
                
                string strPosicoes = Console.ReadLine();

                Jogada jogada = new Jogada(jogadorDaVez, tab);
                try
                {
                    jogada.Jogar(int.Parse(strPosicoes.Split(',')[0]), int.Parse(strPosicoes.Split(',')[1]));
                    bool venceu = tab.VerificarVencedor();

                    if( venceu )
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine(jogadorDaVez.Nome + " VENCEU!!!");
                        Console.ResetColor();

                        break;
                    }
                }catch(Exception e)
                {
                    //decrementa o i para voltar a vez 
                    i--;
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine(e.Message);
                    Console.ResetColor();
                }              

                Console.Write(tab.Renderizar());
            }
             
            
            Console.ReadKey();
        }
    }
}
