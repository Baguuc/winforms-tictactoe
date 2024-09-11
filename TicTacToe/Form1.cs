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
            SwitchPlayer();
            //zablokuj guzik
            //button.Enabled = false;
        }
        void CheckResult()
        {
            //sprawdzamy najpierw wiersze
            //sprawdzamy czy �aden z guzik�w w g�rnym wierszu nie jest pusty
            if(TopLeft.Text != String.Empty && 
                TopCenter.Text != String.Empty && 
                TopRight.Text != String.Empty)
            {
                //je�li nie ma pustych sprawdzamy czy lewy i �rodkowy oraz
                // �rodkowy i prawy s� takie same
                if(TopLeft.Text == TopCenter.Text && TopCenter.Text == TopRight.Text)
                {
                    //je�li s� takie same to wygrywa gracz kt�ry ma taki sam znak
                    //nie ma znaczenia z kt�rego guzika pobieramy tekst
                    MessageBox.Show("Wygra� gracz: " + TopLeft.Text);
                }
            }
        }
    }
}
