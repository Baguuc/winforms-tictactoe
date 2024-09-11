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
        void CheckResult()
        {
            // Wiersze -------

            //sprawdzamy najpierw wiersze
            //sprawdzamy czy ¿aden z guzików w górnym wierszu nie jest pusty
            if (TopLeft.Text != String.Empty &&
                TopCenter.Text != String.Empty &&
                TopRight.Text != String.Empty)
            {
                //jeœli nie ma pustych sprawdzamy czy lewy i œrodkowy oraz
                // œrodkowy i prawy s¹ takie same
                if (TopLeft.Text == TopCenter.Text && TopCenter.Text == TopRight.Text)
                {
                    //jeœli s¹ takie same to wygrywa gracz który ma taki sam znak
                    //nie ma znaczenia z którego guzika pobieramy tekst
                    MessageBox.Show("Wygra³ gracz: " + TopLeft.Text);

                    // zwracamy aby nie kontynuowaæ funkcji gdy¿ wygrany jest ju¿ znany
                    return;
                }
            }
            //sprawdzamy czy ¿aden z guzików w œrodkowym wierszu nie jest pusty
            if (CenterLeft.Text != String.Empty &&
                CenterCenter.Text != String.Empty &&
                CenterRight.Text != String.Empty)
            {
                //jeœli nie ma pustych sprawdzamy czy lewy i œrodkowy oraz
                // œrodkowy i prawy s¹ takie same
                if (CenterLeft.Text == CenterCenter.Text && CenterCenter.Text == CenterRight.Text)
                {
                    //jeœli s¹ takie same to wygrywa gracz który ma taki sam znak
                    //nie ma znaczenia z którego guzika pobieramy tekst
                    MessageBox.Show("Wygra³ gracz: " + CenterLeft.Text);

                    return;
                }
            }
            //sprawdzamy czy ¿aden z guzików w dolnym wierszu nie jest pusty
            if (BottomLeft.Text != String.Empty &&
                BottomCenter.Text != String.Empty &&
                BottomRight.Text != String.Empty)
            {
                //jeœli nie ma pustych sprawdzamy czy lewy i œrodkowy oraz
                // œrodkowy i prawy s¹ takie same
                if (BottomLeft.Text == BottomCenter.Text && BottomCenter.Text == BottomRight.Text)
                {
                    //jeœli s¹ takie same to wygrywa gracz który ma taki sam znak
                    //nie ma znaczenia z którego guzika pobieramy tekst
                    MessageBox.Show("Wygra³ gracz: " + BottomLeft.Text);

                    return;
                }
            }

            // Kolumny -------

            if (TopLeft.Text != String.Empty &&
                CenterLeft.Text != String.Empty &&
                BottomLeft.Text != String.Empty)
            {
                if (TopLeft.Text == CenterLeft.Text && CenterLeft.Text == BottomLeft.Text)
                {
                    MessageBox.Show("Wygra³ gracz: " + BottomLeft.Text);

                    return;
                }
            }

            if (TopCenter.Text != String.Empty &&
                CenterCenter.Text != String.Empty &&
                BottomCenter.Text != String.Empty)
            {
                if (TopCenter.Text == CenterCenter.Text && CenterCenter.Text == BottomCenter.Text)
                {
                    MessageBox.Show("Wygra³ gracz: " + BottomCenter.Text);

                    return;
                }
            }

            if (TopRight.Text != String.Empty &&
                CenterRight.Text != String.Empty &&
                BottomRight.Text != String.Empty)
            {
                if (TopRight.Text == CenterRight.Text && CenterRight.Text == BottomRight.Text)
                {
                    MessageBox.Show("Wygra³ gracz: " + BottomRight.Text);

                    return;
                }
            }

            // Skosy -------

            if (TopLeft.Text != String.Empty &&
                CenterCenter.Text != String.Empty &&
                BottomRight.Text != String.Empty)
            {
                if (TopLeft.Text == CenterCenter.Text && CenterCenter.Text == BottomRight.Text)
                {
                    MessageBox.Show("Wygra³ gracz: " + BottomRight.Text);

                    return;
                }
            }

            if (TopRight.Text != String.Empty &&
                CenterCenter.Text != String.Empty &&
                BottomLeft.Text != String.Empty)
            {
                if (TopRight.Text == CenterCenter.Text && CenterCenter.Text == BottomLeft.Text)
                {
                    MessageBox.Show("Wygra³ gracz: " + BottomLeft.Text);

                    return;
                }
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
