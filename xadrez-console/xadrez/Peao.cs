using tabuleiro;

namespace xadrez
{
    class Peao : Peca
    {
        private PartidaDeXadrez partida;

        public Peao(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor)
        {
            this.partida = partida;
        }

        public override string ToString()
        {
            return "P";
        }

        private bool existeInimigo(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p != null && p.cor != cor;
        }

        private bool posicaoLivre(Posicao pos)
        {
            return tab.peca(pos) == null;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];
            Posicao posMov = new Posicao(0, 0);

            if (cor == Cor.Branca)
            {
                posMov.definirValores(posicao.linha - 1, posicao.coluna);
                if (tab.posicaoValida(posMov) && posicaoLivre(posMov))
                {
                    mat[posMov.linha, posMov.coluna] = true;
                }
                posMov.definirValores(posicao.linha - 2, posicao.coluna);
                if (tab.posicaoValida(posMov) && posicaoLivre(posMov) && qtdeMovimentos == 0)
                {
                    mat[posMov.linha, posMov.coluna] = true;
                }
                posMov.definirValores(posicao.linha - 1, posicao.coluna - 1);
                if (tab.posicaoValida(posMov) && existeInimigo(posMov))
                {
                    mat[posMov.linha, posMov.coluna] = true;
                }
                posMov.definirValores(posicao.linha - 1, posicao.coluna + 1);
                if (tab.posicaoValida(posMov) && existeInimigo(posMov))
                {
                    mat[posMov.linha, posMov.coluna] = true;
                }

                // #jogadaespecial en passant
                if (posicao.linha == 3)
                {
                    Posicao posEsquerdaBr = new Posicao(posicao.linha, posicao.coluna - 1);
                    if (tab.posicaoValida(posEsquerdaBr) && existeInimigo(posEsquerdaBr) && tab.peca(posEsquerdaBr) == partida.vulneravelEnPassant)
                    {
                        mat[posEsquerdaBr.linha - 1, posEsquerdaBr.coluna] = true;
                    }
                    Posicao posDireitaBr = new Posicao(posicao.linha, posicao.coluna + 1);
                    if (tab.posicaoValida(posDireitaBr) && existeInimigo(posDireitaBr) && tab.peca(posDireitaBr) == partida.vulneravelEnPassant)
                    {
                        mat[posDireitaBr.linha - 1,posDireitaBr.coluna] = true;
                    }
                }
            }
            else
            {
                posMov.definirValores(posicao.linha + 1, posicao.coluna);
                if (tab.posicaoValida(posMov) && posicaoLivre(posMov))
                {
                    mat[posMov.linha, posMov.coluna] = true;
                }
                posMov.definirValores(posicao.linha + 2, posicao.coluna);
                if (tab.posicaoValida(posMov) && posicaoLivre(posMov) && qtdeMovimentos == 0)
                {
                    mat[posMov.linha, posMov.coluna] = true;
                }
                posMov.definirValores(posicao.linha + 1, posicao.coluna - 1);
                if (tab.posicaoValida(posMov) && existeInimigo(posMov))
                {
                    mat[posMov.linha, posMov.coluna] = true;
                }
                posMov.definirValores(posicao.linha + 1, posicao.coluna + 1);
                if (tab.posicaoValida(posMov) && existeInimigo(posMov))
                {
                    mat[posMov.linha, posMov.coluna] = true;
                }

                // #jogadaespecial en passant
                if (posicao.linha == 4)
                {
                    Posicao posEsquerdaPt = new Posicao(posicao.linha, posicao.coluna - 1);
                    if (tab.posicaoValida(posEsquerdaPt) && existeInimigo(posEsquerdaPt) && tab.peca(posEsquerdaPt) == partida.vulneravelEnPassant)
                    {
                        mat[posEsquerdaPt.linha + 1, posEsquerdaPt.coluna] = true;
                    }
                    Posicao posDireitaPt = new Posicao(posicao.linha, posicao.coluna + 1);
                    if (tab.posicaoValida(posDireitaPt) && existeInimigo(posDireitaPt) && tab.peca(posDireitaPt) == partida.vulneravelEnPassant)
                    {
                        mat[posDireitaPt.linha + 1, posDireitaPt.coluna] = true;
                    }
                }
                
            }

            return mat;
        }
    }
}
