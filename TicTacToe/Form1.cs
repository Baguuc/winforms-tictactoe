namespace TicTacToe
{
    public partial class Form1 : Form
    {
        //aktywny gracz - zaczynaj¹ kó³ka
        char activePlayer = 'O';
        
        public Form1()
        {
            InitializeComponent();
            //zainicjuj labelkê pokazuj¹c¹ aktywnego gracza
            SetPlayer('O');
        }

        private void SetPlayer(char playerChar)
        {
            //zmieñ aktywnego gracza
            activePlayer = playerChar;
            //zmodyfikuj labelkê pokazuj¹c¹ aktywnego gracza
            ActivePlayerLabel.Text = "Aktywny gracz: " + activePlayer;
        }

        private void SwitchPlayer()
        {
            //zmieñ aktywnego gracza
            SetPlayer(activePlayer == 'O' ? 'X' : 'O');
        }

        private void GameButtonClick(object sender, EventArgs e)
        {
            //stwórz obiekt klasy button i rzutuj do niego zawartoœæ sender
            Button button = (Button)sender;

            //jeœli na guziku jest ju¿ jakiœ napis to zakoñcz funkcjê
            if (button.Text != "")
            {
                return;
            }
            //zapisz do guzika aktywnego gracza 
            button.Text = activePlayer.ToString();
            //sprawdzamy czy ktoœ wygra³
            CheckResult();
            //zmiana gracza
            SwitchPlayer();
            //zablokuj guzik
        }

        private bool CheckCombination(Button button1, Button button2, Button button3)
        {
            //sprawdzamy czy ¿aden z guzików nie jest pusty
            if (button1.Text != String.Empty &&
                button2.Text != String.Empty &&
                button3.Text != String.Empty)
            {
                // jeœli nie ma pustych sprawdzamy czy wszystkie s¹ takie same
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

            
            // sprawdzamy kombinacje górnego wiersza
            if (CheckCombination(TopLeft, TopCenter, TopRight))
            {
                // Informujemy kto wygra³, nie jest wa¿ne sk¹d weŸmiemy znak wygranego
                // wa¿ne aby to pole by³o czêœci¹ tej kombinacji
                MessageBox.Show("Wygra³ gracz: " + TopLeft.Text);
                return;
            }

            // sprawdzamy kombinacje œrodkowego wiersza
            if (CheckCombination(CenterLeft, CenterCenter, CenterRight))
            {
                MessageBox.Show("Wygra³ gracz: " + CenterLeft.Text);
                return;
            }

            // sprawdzamy kombinacje dolnego wiersza
            if (CheckCombination(BottomLeft, BottomCenter, BottomRight))
            {
                MessageBox.Show("Wygra³ gracz: " + BottomLeft.Text);
                return;
            }


            // Kolumny -------


            // sprawdzamy kombinacje lewej kolumny
            if (CheckCombination(TopLeft, CenterLeft, BottomLeft))
            {
                MessageBox.Show("Wygra³ gracz: " + TopLeft.Text);
                return;
            }

            // sprawdzamy kombinacje œrodkowej kolumny
            if (CheckCombination(TopCenter, CenterCenter, BottomCenter))
            {
                MessageBox.Show("Wygra³ gracz: " + TopCenter.Text);
                return;
            }

            // sprawdzamy kombinacje prawej kolumny
            if (CheckCombination(TopRight, CenterRight, BottomRight))
            {
                MessageBox.Show("Wygra³ gracz: " + TopRight.Text);
                return;
            }


            // Skosy -------


            // sprawdzamy kombinacje skosu spadaj¹cego
            if (CheckCombination(TopLeft, CenterCenter, BottomRight))
            {
                MessageBox.Show("Wygra³ gracz: " + TopLeft.Text);
                return;
            }

            // sprawdzamy kombinacje skosu wzrastaj¹cego
            if (CheckCombination(BottomLeft, CenterCenter, TopRight))
            {
                MessageBox.Show("Wygra³ gracz: " + TopRight.Text);
                return;
            }

            // Remis -------

            // gdy funkcja nie zosta³a zakoñczona przez return wczeœniej to oznacza, ¿e nikt nie wygra³
            // jednak sprawdzamy czy wszystkie pola s¹ ju¿ zape³nione ¿eby upewniæ siê, ¿e ¿aden ruch nie jest ju¿ mo¿liwy
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
