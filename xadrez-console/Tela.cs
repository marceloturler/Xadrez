using System;
using xadrez;
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
                        Tela.imprimirPeca(tab.peca(i, j));
                    }
                    else 
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Tela.imprimirPeca(tab.peca(i, j));
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

        

        public static void imprimirTabuleiro(Tabuleiro tab, bool[,] posPossiveis)
        {
            ConsoleColor fAlter = ConsoleColor.DarkGray;

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
                    if (checarCoresXadrez(j, i))
                    {
                        if (posPossiveis[i, j])
                        {
                            Console.BackgroundColor = fAlter;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        Tela.imprimirPeca(tab.peca(i, j));
                    }
                    else
                    {
                        if (posPossiveis[i, j])
                        {
                            Console.BackgroundColor = fAlter;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        Tela.imprimirPeca(tab.peca(i, j));
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

            bool checarCoresXadrez(int j, int i)
            {
                if (j == i || (j % 2 == 0 && i % 2 == 0) || (j % 2 != 0 && i % 2 != 0))
                {
                    return true;
                }
                return false;
            }
        }

        public static PosicaoXadrez lerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");

            return new PosicaoXadrez(coluna, linha);
        }

        public static void imprimirPeca(Peca peca)
        {
            if (peca == null )
            {
                if (Console.BackgroundColor == ConsoleColor.DarkGray)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.Write("- ");
            }
            else
            {
                if (peca.cor == Cor.Branca)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(peca);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(peca);
                }
                Console.Write(" ");
            }
            
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
