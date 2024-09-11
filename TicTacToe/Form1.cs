namespace TicTacToe
{
    public partial class Form1 : Form
    {
        //aktywny gracz - zaczynaj� k�ka
        char activePlayer = 'O';

        public Form1()
        {
            InitializeComponent();
        }

        void SwitchPlayer()
        {
            //zmie� aktywnego gracza
            activePlayer = (activePlayer == 'O') ? 'X' : 'O';
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
    }
}
