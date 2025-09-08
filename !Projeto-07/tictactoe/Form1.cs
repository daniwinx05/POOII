
namespace tictactoe
{
    public partial class Form1 : Form
    {

        // below is the player class which has two value
        // X and O
        // by doing this we can control the player and AI symbols
        public enum Player
        {
            X, O
        }

        Player currentPlayer; // calling the player class 

        List<Button> buttons; // creating a LIST or array of buttons
        Random rand = new Random(); // importing the random number generator class
        /*int playerWins = 0; // set the player win integer to 0
        int computerWins = 0; // set the computer win integer to 0*/
        //Adicionados
        int player1Wins = 0; // Contagem de vitórias para o Jogador 1 (X)
        int player2Wins = 0; // Contagem de vitórias para o Jogador 2 (O)

        bool modoUmJogador = true; //variável para controlar o modo de jogo

        public Form1()
        {
            InitializeComponent();
            resetGame();
        }
        
        private void playerClick(object sender, EventArgs e)
        {
            /*
            var button = (Button)sender; // find which button was clicked
            currentPlayer = Player.X; // set the player to X
            button.Text = currentPlayer.ToString(); // change the button text to player X
            button.Enabled = false; // disable the button
            button.BackColor = System.Drawing.Color.Cyan; // change the player colour to Cyan
            buttons.Remove(button); //remove the button from the list buttons so the AI can't click it either
            Check(); // check if the player won
            AImoves.Start(); // start the AI timer*/

            //Adicionados para ter até 2 jogadores
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
                if (buttons.Count > 0 && !Check())
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

        //Método para alternar os jogadores
        private void AlternarJogador()
        {
            currentPlayer = (currentPlayer == Player.X) ? Player.O : Player.X;
        }

        private void AImove(object sender, EventArgs e)
        {
            // THE CPU will randomly choose a button from the list to click. 
            // While the array is greater than 0 the cpu will operate in the game
            // if the array is less than 0 it will stop playing
            if (buttons.Count > 0)
            {
                int index = rand.Next(buttons.Count); // generate a random number within the number of buttons available
                buttons[index].Enabled = false; // assign the number to the button
                // when the random number is generated then we will look into the list
                // for what that number is we select that button
                // for example if the number is 8
                // then we select the 8th button in the list

                /*currentPlayer = Player.O; // set the AI with O
                buttons[index].Text = currentPlayer.ToString(); // show O on the button*/
                buttons[index].Text = Player.O.ToString();
                buttons[index].BackColor = System.Drawing.Color.DarkSalmon; // change the background of the button dark salmon colour
                buttons.RemoveAt(index); // remove that button from the list
                Check(); // check if the AI won anything
                AImoves.Stop(); // stop the AI timer
            }
        }

        //Método para mudança de jogador
        private void restartGame(object sender, EventArgs e)
        {
            // this function is linked with the reset button
            // when the reset button is clicked then
            // this function will run the reset game function

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
            // this the custom function which will load all the buttons from the form to the buttons list
            buttons = new List<Button> { button1, button2, button3, button4, button5, button6, button7, button8, button9 };
            
        }

        private void resetGame()
        {
            //check each of the button with a tag of play
            foreach (Control X in this.Controls)
            {
                if (X is Button && X.Tag == "play")
                {
                    ((Button)X).Enabled = true; // change them all back to enabled or clickable
                    ((Button)X).Text = "?"; // set the text to question mark
                    ((Button)X).BackColor = default(Color); // change the background colour to default button colors
                }
            }

            loadbuttons(); // run the load buttons function so all the buttons are inserted back in the array
            currentPlayer = Player.X; // Para começar sempre começa no X
        }


        private bool Check()
        {
            /*
            //in this function we will check if the player or the AI has won
            // we have two very large if statements with the winning possibilities
            if (button1.Text == "X" && button2.Text == "X" && button3.Text == "X"
               || button4.Text == "X" && button5.Text == "X" && button6.Text == "X"
               || button7.Text == "X" && button9.Text == "X" && button8.Text == "X"
               || button1.Text == "X" && button4.Text == "X" && button7.Text == "X"
               || button2.Text == "X" && button5.Text == "X" && button8.Text == "X"
               || button3.Text == "X" && button6.Text == "X" && button9.Text == "X"
               || button1.Text == "X" && button5.Text == "X" && button9.Text == "X"
               || button3.Text == "X" && button5.Text == "X" && button7.Text == "X")
            {
                // if any of the above conditions are met
                AImoves.Stop(); //stop the timer
                MessageBox.Show("Player Wins"); // show a message to the player
                playerWins++; // increase the player wins 
                label1.Text = "Player Wins- " + playerWins; // update player label
                resetGame(); // run the reset game function
            }
            // below if statement is for when the AI wins the game
            else if (button1.Text == "O" && button2.Text == "O" && button3.Text == "O"
            || button4.Text == "O" && button5.Text == "O" && button6.Text == "O"
            || button7.Text == "O" && button9.Text == "O" && button8.Text == "O"
            || button1.Text == "O" && button4.Text == "O" && button7.Text == "O"
            || button2.Text == "O" && button5.Text == "O" && button8.Text == "O"
            || button3.Text == "O" && button6.Text == "O" && button9.Text == "O"
            || button1.Text == "O" && button5.Text == "O" && button9.Text == "O"
            || button3.Text == "O" && button5.Text == "O" && button7.Text == "O")
            {

                // if any of the conditions are met above then we will do the following
                // this code will run when the AI wins the game
                AImoves.Stop(); // stop the timer
                MessageBox.Show("Computer Wins"); // show a message box to say computer won
                computerWins++; // increase the computer wins score number
                label2.Text = "AI Wins- " + computerWins; // update the label 2 for computer wins
                resetGame(); // run the reset game

            }*/

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

        //Método criado para verificar vitória (verificação em matrizes)
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

        private void panelGame_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
