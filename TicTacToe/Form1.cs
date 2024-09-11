namespace TicTacToe
{
    public partial class Form1 : Form
    {
        //aktywny gracz - zaczynaj� k�ka
        char activePlayer = 'O';
        
        public Form1()
        {
            InitializeComponent();
            //zainicjuj labelk� pokazuj�c� aktywnego gracza
            SetPlayer('O');
        }

        private void SetPlayer(char playerChar)
        {
            //zmie� aktywnego gracza
            activePlayer = playerChar;
            //zmodyfikuj labelk� pokazuj�c� aktywnego gracza
            ActivePlayerLabel.Text = "Aktywny gracz: " + activePlayer;
        }

        private void SwitchPlayer()
        {
            //zmie� aktywnego gracza
            SetPlayer(activePlayer == 'O' ? 'X' : 'O');
        }

        private void GameButtonClick(object sender, EventArgs e)
        {
            //stw�rz obiekt klasy button i rzutuj do niego zawarto�� sender
            Button button = (Button)sender;

            //je�li na guziku jest ju� jaki� napis to zako�cz funkcj�
            if (button.Text != "")
            {
                return;
            }
            //zapisz do guzika aktywnego gracza 
            button.Text = activePlayer.ToString();
            //sprawdzamy czy kto� wygra�
            CheckResult();
            //zmiana gracza
            SwitchPlayer();
            //zablokuj guzik
        }

        private bool CheckCombination(Button button1, Button button2, Button button3)
        {
            //sprawdzamy czy �aden z guzik�w nie jest pusty
            if (button1.Text != String.Empty &&
                button2.Text != String.Empty &&
                button3.Text != String.Empty)
            {
                // je�li nie ma pustych sprawdzamy czy wszystkie s� takie same
                if (button1.Text == button2.Text && button2.Text == button3.Text)
                {
                    return true;
                }
            }

            return false;
        }

        void CheckResult()
        {
            // Wiersze -------

            
            // sprawdzamy kombinacje g�rnego wiersza
            if (CheckCombination(TopLeft, TopCenter, TopRight))
            {
                // Informujemy kto wygra�, nie jest wa�ne sk�d we�miemy znak wygranego
                // wa�ne aby to pole by�o cz�ci� tej kombinacji
                MessageBox.Show("Wygra� gracz: " + TopLeft.Text);
                return;
            }

            // sprawdzamy kombinacje �rodkowego wiersza
            if (CheckCombination(CenterLeft, CenterCenter, CenterRight))
            {
                MessageBox.Show("Wygra� gracz: " + CenterLeft.Text);
                return;
            }

            // sprawdzamy kombinacje dolnego wiersza
            if (CheckCombination(BottomLeft, BottomCenter, BottomRight))
            {
                MessageBox.Show("Wygra� gracz: " + BottomLeft.Text);
                return;
            }


            // Kolumny -------


            // sprawdzamy kombinacje lewej kolumny
            if (CheckCombination(TopLeft, CenterLeft, BottomLeft))
            {
                MessageBox.Show("Wygra� gracz: " + TopLeft.Text);
                return;
            }

            // sprawdzamy kombinacje �rodkowej kolumny
            if (CheckCombination(TopCenter, CenterCenter, BottomCenter))
            {
                MessageBox.Show("Wygra� gracz: " + TopCenter.Text);
                return;
            }

            // sprawdzamy kombinacje prawej kolumny
            if (CheckCombination(TopRight, CenterRight, BottomRight))
            {
                MessageBox.Show("Wygra� gracz: " + TopRight.Text);
                return;
            }


            // Skosy -------


            // sprawdzamy kombinacje skosu spadaj�cego
            if (CheckCombination(TopLeft, CenterCenter, BottomRight))
            {
                MessageBox.Show("Wygra� gracz: " + TopLeft.Text);
                return;
            }

            // sprawdzamy kombinacje skosu wzrastaj�cego
            if (CheckCombination(BottomLeft, CenterCenter, TopRight))
            {
                MessageBox.Show("Wygra� gracz: " + TopRight.Text);
                return;
            }

            // Remis -------

            // gdy funkcja nie zosta�a zako�czona przez return wcze�niej to oznacza, �e nikt nie wygra�
            // jednak sprawdzamy czy wszystkie pola s� ju� zape�nione �eby upewni� si�, �e �aden ruch nie jest ju� mo�liwy
            if (
                TopRight.Text != String.Empty &&
                CenterRight.Text != String.Empty &&
                BottomRight.Text != String.Empty &&
                TopCenter.Text != String.Empty &&
                CenterCenter.Text != String.Empty &&
                BottomCenter.Text != String.Empty &&
                TopLeft.Text != String.Empty &&
                CenterLeft.Text != String.Empty &&
                BottomLeft.Text != String.Empty
            )
            {
                MessageBox.Show("REMIS!");

                return;
            }
        }

        private void ResetButtonClick(object sender, EventArgs e)
        {
            _Reset();
        }

        private void _Reset()
        {
            Button[] grid = {
                TopRight,
                CenterRight,
                BottomRight,
                TopCenter,
                CenterCenter,
                BottomCenter,
                TopLeft,
                CenterLeft,
                BottomLeft
            };

            foreach (Button button in grid)
            {
                button.Text = "";
            }

            SetPlayer('O');
            
        }
    }
}
