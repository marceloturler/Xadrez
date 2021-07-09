using System;
using xadrez;
using tabuleiro;
using System.Collections.Generic;

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

        public static void exibeMensagens(PartidaDeXadrez partida, ConsoleColor aux)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.Write("AS PEÇAS BRANCAS SERÃO: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("     VERDES ");
            Console.WriteLine();
            Console.ForegroundColor = aux;
            Console.Write("AS PEÇAS PRETAS SERÃO: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("     VERMELHAS ");
            Console.ForegroundColor = aux;
            Console.WriteLine();
            imprimirPecasJogador(partida);
        }

        public static void imprimirPecasJogador(PartidaDeXadrez partida)
        {
            Console.WriteLine();
            Console.WriteLine("==========================================================");
            
            imprimirPecasCapturadas(partida);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("==========================================================");
            Console.WriteLine();

        }

        private static void imprimirPecasCapturadas(PartidaDeXadrez partida)
        {
            checaJogador(partida);
            Console.Write("Peças capturadas - Jogador " + partida.jogadorAtual);
            imprimirConjunto(partida.pecasCapturadas(partida.jogadorAtual));
            Console.WriteLine();
        }

        private static void imprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[");
            foreach (Peca x in conjunto)
            {
                Console.Write(x + " ");
            }
            Console.Write("]");
        }

        public static void exibeTurno(PartidaDeXadrez partida)
        {
            Console.WriteLine();
            Console.WriteLine("Turno: " + partida.turno);
            Console.WriteLine("--------");
            Console.WriteLine();
        }

        private static void checaJogador(PartidaDeXadrez partida)
        {
            if (partida.jogadorAtual == Cor.Branca)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
        }

        public static void exibePossiveisJogadas(PartidaDeXadrez partida, ConsoleColor aux)
        {
            try
            {
                exibeTurno(partida);
                checaJogador(partida);
                Console.WriteLine("Aguardando jogada: " + partida.jogadorAtual);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Origem: ");
                Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                partida.validarPosicaoDeOrigem(origem);
                bool[,] posicoesPossiveis = partida.tab.peca(origem).movimentosPossiveis();

                exibeMensagens(partida, aux);
                imprimirTabuleiro(partida.tab, posicoesPossiveis);
                aguardaJogada(partida, origem);
                exibeMensagens(partida, aux);
                imprimirTabuleiro(partida.tab, posicoesPossiveis);
            }
            catch (TabuleiroException tex)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(tex.Message);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Aperte novamente enter para continuar...");
                Console.ReadLine();
            }
            
        }

        public static void aguardaJogada(PartidaDeXadrez partida, Posicao origem)
        {
            exibeTurno(partida);
            checaJogador(partida);
            Console.WriteLine("Aguardando jogada: " + partida.jogadorAtual);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Destino: ");
            Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
            partida.validarPosicaoDeDestino(origem, destino);
            partida.realizaJogada(origem, destino);
        }
    }
}
