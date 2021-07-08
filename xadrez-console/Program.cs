using System;
using xadrez;
using tabuleiro;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Tabuleiro tab = new Tabuleiro(8, 8);

                tab.colocarPeca(new Torre(tab, Cor.Azul), new Posicao(0, 0));
                tab.colocarPeca(new Torre(tab, Cor.Amarela), new Posicao(1, 3));
                tab.colocarPeca(new Rei(tab, Cor.Amarela), new Posicao(0, 0));

                Tela.imprimirTabuleiro(tab);
            }
            catch (TabuleiroException tex)
            {

                Console.WriteLine(tex.Message);
            }
            
        }
    }
}
