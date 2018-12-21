using JogoDaVelhaConsole.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaVelhaConsole.Classes
{
    public class Jogador
    {
        public NomeJogador Nome { get; private set; }
        public Peca Peca { get; private set; }

        public Jogador(NomeJogador nome, Peca peca)
        {
            Nome = nome;
            Peca = peca;
        }

        public Peca SelecionaOutraPeca()
        { 
            return this.Peca.Equals(Peca.X) ?  Peca.O : Peca.X;
        }
    }
}
