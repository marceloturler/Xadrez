using System;
using xadrez;
using tabuleiro;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            PosicaoXadrez posX = new PosicaoXadrez('c', 7);

            Console.WriteLine(posX);

            Console.WriteLine(posX.toPosicao());
        }
    }
}
