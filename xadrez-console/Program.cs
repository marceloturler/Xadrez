using System;
using xadrez;
using tabuleiro;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            var aux = Console.ForegroundColor;
            Console.WriteLine("AS PEÇAS BRANCAS SERÃO: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.Write("     VERDES ");
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = aux;
            Console.WriteLine("AS PEÇAS PRETAS SERÃO: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.Write("     VERMELHAS ");
            Console.ForegroundColor = aux;
            Console.WriteLine();
            Console.WriteLine();
            try
            {
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.terminada)
                {
                    Console.Clear();
                    Tela.imprimirTabuleiro(partida.tab);

                    Console.WriteLine();
                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Posicao origem = Tela.lerPosicaoXadrez().toPosicao();

                    bool[,] posicoesPossiveis = partida.tab.peca(origem).movimentosPossiveis();

                    Console.Clear();
                    Tela.imprimirTabuleiro(partida.tab, posicoesPossiveis);

                    Console.WriteLine();
                    Console.WriteLine();
                    Console.Write("Destino: ");
                    Posicao destino = Tela.lerPosicaoXadrez().toPosicao();

                    partida.executaMovimento(origem, destino);
                }

                Tela.imprimirTabuleiro(partida.tab);
            }
            catch (TabuleiroException tex)
            {
                Console.WriteLine(tex.Message);
            }

            Console.ReadLine();
        }
    }
}
