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
            ActivePlayerLabel.Text = "Aktywny gracz: " + activePlayer;
        }

        void SwitchPlayer()
        {
            //zmie� aktywnego gracza
            activePlayer = (activePlayer == 'O') ? 'X' : 'O';
            //zmodyfikuj labelk� pokazuj�c� aktywnego gracza
            ActivePlayerLabel.Text = "Aktywny gracz: " + activePlayer;
        }

        private void GameButtonClick(object sender, EventArgs e)
        {
            //stw�rz obiekt klasy button i rzutuj do niego zawarto�� sender
            Button button = (Button)sender;

            //je�li na guziku jest ju� jaki� napis to zako�cz funkcj�
            if(button.Text != "")
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
            //button.Enabled = false;
        }
        void CheckResult()
        {
            // Wiersze -------
            
            //sprawdzamy najpierw wiersze
            //sprawdzamy czy �aden z guzik�w w g�rnym wierszu nie jest pusty
            if (TopLeft.Text != String.Empty &&
                TopCenter.Text != String.Empty &&
                TopRight.Text != String.Empty)
            {
                //je�li nie ma pustych sprawdzamy czy lewy i �rodkowy oraz
                // �rodkowy i prawy s� takie same
                if (TopLeft.Text == TopCenter.Text && TopCenter.Text == TopRight.Text)
                {
                    //je�li s� takie same to wygrywa gracz kt�ry ma taki sam znak
                    //nie ma znaczenia z kt�rego guzika pobieramy tekst
                    MessageBox.Show("Wygra� gracz: " + TopLeft.Text);
                }
            }
            //sprawdzamy czy �aden z guzik�w w �rodkowym wierszu nie jest pusty
            if (CenterLeft.Text != String.Empty &&
                CenterCenter.Text != String.Empty &&
                CenterRight.Text != String.Empty)
            {
                //je�li nie ma pustych sprawdzamy czy lewy i �rodkowy oraz
                // �rodkowy i prawy s� takie same
                if (CenterLeft.Text == CenterCenter.Text && CenterCenter.Text == CenterRight.Text)
                {
                    //je�li s� takie same to wygrywa gracz kt�ry ma taki sam znak
                    //nie ma znaczenia z kt�rego guzika pobieramy tekst
                    MessageBox.Show("Wygra� gracz: " + CenterLeft.Text);
                }
            }
            //sprawdzamy czy �aden z guzik�w w dolnym wierszu nie jest pusty
            if (BottomLeft.Text != String.Empty &&
                BottomCenter.Text != String.Empty &&
                BottomRight.Text != String.Empty)
            {
                //je�li nie ma pustych sprawdzamy czy lewy i �rodkowy oraz
                // �rodkowy i prawy s� takie same
                if (BottomLeft.Text == BottomCenter.Text && BottomCenter.Text == BottomRight.Text)
                {
                    //je�li s� takie same to wygrywa gracz kt�ry ma taki sam znak
                    //nie ma znaczenia z kt�rego guzika pobieramy tekst
                    MessageBox.Show("Wygra� gracz: " + BottomLeft.Text);
                }
            }
            
            // Kolumny -------

            if (TopLeft.Text != String.Empty &&
                CenterLeft.Text != String.Empty &&
                BottomLeft.Text != String.Empty)
            {
                if (TopLeft.Text == CenterLeft.Text && CenterLeft.Text == BottomLeft.Text)
                {
                    MessageBox.Show("Wygra� gracz: " + BottomLeft.Text);
                }
            }

            if (TopCenter.Text != String.Empty &&
                CenterCenter.Text != String.Empty &&
                BottomCenter.Text != String.Empty)
            {
                if (TopCenter.Text == CenterCenter.Text && CenterCenter.Text == BottomCenter.Text)
                {
                    MessageBox.Show("Wygra� gracz: " + BottomCenter.Text);
                }
            }

            if (TopRight.Text != String.Empty &&
                CenterRight.Text != String.Empty &&
                BottomRight.Text != String.Empty)
            {
                if (TopRight.Text == CenterRight.Text && CenterRight.Text == BottomRight.Text)
                {
                    MessageBox.Show("Wygra� gracz: " + BottomRight.Text);
                }
            }

            // Skosy -------

            if (TopLeft.Text != String.Empty &&
                CenterCenter.Text != String.Empty &&
                BottomRight.Text != String.Empty)
            {
                if (TopLeft.Text == CenterCenter.Text && CenterCenter.Text == BottomRight.Text)
                {
                    MessageBox.Show("Wygra� gracz: " + BottomRight.Text);
                }
            }

            if (TopRight.Text != String.Empty &&
                CenterCenter.Text != String.Empty &&
                BottomLeft.Text != String.Empty)
            {
                if (TopRight.Text == CenterCenter.Text && CenterCenter.Text == BottomLeft.Text)
                {
                    MessageBox.Show("Wygra� gracz: " + BottomLeft.Text);
                }
            }
        }
    }
}
