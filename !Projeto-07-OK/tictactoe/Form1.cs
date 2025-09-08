namespace tictactoe
{
    public partial class Form1 : Form
    {
        public enum Player
        {
            X, O
        }

        Player currentPlayer;
        List<Button> buttons;
        Random rand = new Random();
        int player1Wins = 0; // Vitórias do Jogador X
        int player2Wins = 0; // Vitórias do Jogador O ou da IA

        bool modoUmJogador = true; // Variável para controlar o modo de jogo

        public Form1()
        {
            InitializeComponent();
            resetGame();
        }

        private void playerClick(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.Text = currentPlayer.ToString();
            button.Enabled = false;

            if (currentPlayer == Player.X)
            {
                button.BackColor = System.Drawing.Color.Cyan;
            }
            else
            {
                button.BackColor = System.Drawing.Color.DarkSalmon;
            }

            buttons.Remove(button);
            Check();

            // A lógica de turno agora depende do modo de jogo
            if (modoUmJogador)
            {
                // Após a jogada do jogador X, a IA joga. Não há alternância de turno manual.
                if (buttons.Count > 0 && !CheckForWinnerOrDraw())
                {
                    AImoves.Start();
                }
            }
            else
            {
                // Em 2 jogadores, basta alternar o turno
                AlternarJogador();
            }
        }

        private void AlternarJogador()
        {
            currentPlayer = (currentPlayer == Player.X) ? Player.O : Player.X;
        }

        private void AImove(object sender, EventArgs e)
        {
            if (buttons.Count > 0)
            {
                int index = rand.Next(buttons.Count);
                buttons[index].Enabled = false;
                buttons[index].Text = Player.O.ToString();
                buttons[index].BackColor = System.Drawing.Color.DarkSalmon;
                buttons.RemoveAt(index);
                AImoves.Stop();
                Check();
            }
        }

        private void restartGame(object sender, EventArgs e)
        {
            if (((Button)sender).Tag.ToString() == "1 Jogador")
            {
                modoUmJogador = true;
                label2.Text = "IA: " + player2Wins;
            }
            else if (((Button)sender).Tag.ToString() == "2 Jogadores")
            {
                modoUmJogador = false;
                label2.Text = "Jogador O: " + player2Wins;
            }

            resetGame();
        }

        private void loadbuttons()
        {
            buttons = new List<Button> { button1, button2, button3, button4, button5, button6, button7, button8, button9 };
        }

        private void resetGame()
        {
            foreach (Control X in this.Controls)
            {
                if (X is Button && X.Tag == "play")
                {
                    ((Button)X).Enabled = true;
                    ((Button)X).Text = "?";
                    ((Button)X).BackColor = default(Color);
                }
            }
            loadbuttons();
            currentPlayer = Player.X; // Sempre começa no X
        }

        private bool CheckForWinnerOrDraw()
        {
            Button[,] tabuleiro = new Button[3, 3]
            {
        { button1, button2, button3 },
        { button4, button5, button6 },
        { button7, button8, button9 }
            };

            if (VerificarVitoria(tabuleiro, "X"))
            {
                MessageBox.Show("Jogador X Vence!");
                player1Wins++;
                label1.Text = "Jogador X: " + player1Wins;
                resetGame();
                return true;
            }

            if (VerificarVitoria(tabuleiro, "O"))
            {
                string vencedor = modoUmJogador ? "IA" : "Jogador O";
                MessageBox.Show(vencedor + " Vence!");
                player2Wins++;
                label2.Text = vencedor + ": " + player2Wins;
                resetGame();
                return true;
            }

            if (VerificarEmpate(tabuleiro))
            {
                MessageBox.Show("Empate!");
                resetGame();
                return true;
            }
            return false;
        }

        private void Check()
        {
            CheckForWinnerOrDraw();
        }

        private bool VerificarVitoria(Button[,] tab, string jogador)
        {
            // Verificação de linhas
            for (int i = 0; i < 3; i++)
                if (tab[i, 0].Text == jogador && tab[i, 1].Text == jogador && tab[i, 2].Text == jogador)
                    return true;

            // Verificação de colunas
            for (int j = 0; j < 3; j++)
                if (tab[0, j].Text == jogador && tab[1, j].Text == jogador && tab[2, j].Text == jogador)
                    return true;

            // Verificação de diagonais
            if (tab[0, 0].Text == jogador && tab[1, 1].Text == jogador && tab[2, 2].Text == jogador)
                return true;

            if (tab[0, 2].Text == jogador && tab[1, 1].Text == jogador && tab[2, 0].Text == jogador)
                return true;

            return false;
        }

        private bool VerificarEmpate(Button[,] tab)
        {
            foreach (Button b in tab)
                if (b.Text == "?" || b.Text == "")
                    return false;
            return true;
        }
    }
}