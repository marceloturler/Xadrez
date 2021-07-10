using System;
using xadrez;
using tabuleiro;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleColor aux = Console.ForegroundColor;

            try
            {
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.terminada)
                {
                    Tela.exibeMensagens(partida, aux);
                    Tela.imprimirTabuleiro(partida.tab);
                    Tela.exibePossiveisJogadas(partida, aux);
                }
                Console.Clear();
                Tela.exibeMensagens(partida, aux);
                Tela.imprimirTabuleiro(partida.tab);
                if(partida.terminada)
                {
                    Tela.exibeGanhador(partida);
                }
            }
            catch (TabuleiroException tex)
            {
                Console.WriteLine(tex.Message);
            }

            Console.ReadLine();
        }
    }
}
