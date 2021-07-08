namespace tabuleiro
{
    class Tabuleiro
    {
        public int linhas { get; set; }
        public int colunas { get; set; }
        public Peca[,] pecas;

        public Tabuleiro(int lin, int col)
        {
            this.linhas = lin;
            this.colunas = col;
            pecas = new Peca[linhas, colunas];
        }

        public Peca peca(int lin, int col)
        {
            return pecas[lin, col];
        }

        public void colocarPeca(Peca p, Posicao pos)
        {
            pecas[pos.linha, pos.coluna] = p;
            p.posicao = pos;
        }
    }
}
