using System;
using tabuleiro;

namespace xadrez_console
{
    class Tela
    {
        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.WriteLine("                    ");
            for (int i = 0; i < tab.linhas; i++)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(8 - i);
                Console.Write(" ");
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.Write("  ");
                for (int j = 0; j < tab.colunas; j++)
                {
                    if (j == i || ( j % 2 == 0 && i % 2 == 0 ) || (j % 2 != 0 && i % 2 != 0) ) {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        if (tab.peca(i, j) == null)
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write("- ");
                        }
                        else
                        {
                            Tela.imprimirPeca(tab.peca(i, j));
                            Console.Write(" ");
                        }
                    }
                    else 
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        if (tab.peca(i, j) == null)
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write("- ");
                        }
                        else
                        {
                            Tela.imprimirPeca(tab.peca(i, j));
                            Console.Write(" ");
                        }
                    }
                }
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.Write("  ");
                Console.WriteLine();
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.WriteLine("                    ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("    A B C D E F G H");
        }

        public static void imprimirPeca(Peca peca)
        {
            if (peca.cor == Cor.Branca)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(peca);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(peca);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
