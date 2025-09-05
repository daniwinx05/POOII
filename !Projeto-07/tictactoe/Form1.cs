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
        int playerWins = 0;
        int computerWins = 0;

        bool modoUmJogador = true; //nova variável para controlar o modo de jogo

        public Form1()
        {
            InitializeComponent();
            resetGame();
        }

        private void playerClick(object sender, EventArgs e)
        {
            var button = (Button)sender;
            currentPlayer = Player.X;
            button.Text = currentPlayer.ToString();
            button.Enabled = false;
            button.BackColor = System.Drawing.Color.Cyan;
            buttons.Remove(button);
            Check();

            if (modoUmJogador) // Se for 1 jogador, chama a IA
            {
                AImoves.Start();
            }
            else //Se for 2 jogadores, alterna turno
            {
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
                currentPlayer = Player.O;
                buttons[index].Text = currentPlayer.ToString();
                buttons[index].BackColor = System.Drawing.Color.DarkSalmon;
                buttons.RemoveAt(index);
                Check();
                AImoves.Stop();
            }
        }

        private void restartGame(object sender, EventArgs e)
        {
            if (((Button)sender).Tag.ToString() == "1 Jogador")
                modoUmJogador = true;
            else if (((Button)sender).Tag.ToString() == "2 Jogadores")
                modoUmJogador = false;

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
            currentPlayer = Player.X; //sempre começa no X
        }

        private void Check()
        {
            Button[,] tabuleiro = new Button[3, 3]
            {
                { button1, button2, button3 },
                { button4, button5, button6 },
                { button7, button8, button9 }
            };

            if (VerificarVitoria(tabuleiro, "X"))
            {
                AImoves.Stop();
                MessageBox.Show("Player Wins");
                playerWins++;
                label1.Text = "Player Wins- " + playerWins;
                resetGame();
                return;
            }

            if (VerificarVitoria(tabuleiro, "O"))
            {
                AImoves.Stop();
                MessageBox.Show("Computer Wins");
                computerWins++;
                label2.Text = "AI Wins- " + computerWins;
                resetGame();
                return;
            }

            if (VerificarEmpate(tabuleiro))
            {
                AImoves.Stop();
                MessageBox.Show("Empate!");
                resetGame();
            }
        }

        private bool VerificarVitoria(Button[,] tab, string jogador)
        {
            for (int i = 0; i < 3; i++)
                if (tab[i, 0].Text == jogador && tab[i, 1].Text == jogador && tab[i, 2].Text == jogador)
                    return true;

            for (int j = 0; j < 3; j++)
                if (tab[0, j].Text == jogador && tab[1, j].Text == jogador && tab[2, j].Text == jogador)
                    return true;

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