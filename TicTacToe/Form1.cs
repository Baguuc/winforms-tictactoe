using System.Windows.Forms;

namespace TicTacToe
{
    public partial class RootForm : Form
    {
        //aktywny gracz - zaczynaj� k�ka
        ActivePlayer activePlayer;


        public RootForm()
        {
            Reset();
        }

        public ActivePlayer GetActivePlayer()
        {
            return this.activePlayer;
        }


        public void RefreshPlayer(bool _switch)
        {
            //zmie� aktywnego gracza
            if (_switch)
            {
                this.activePlayer.SwitchPlayer();
            }

            //zmodyfikuj labelk� pokazuj�c� aktywnego gracza
            this.ActivePlayerLabel.Text = "Aktywny gracz: " + this.activePlayer.GetPlayerChar();
        }


        public void RefreshGameGrid()
        {
            this._GameGrid.Refresh();
        }


        public void Reset()
        {
            this.Controls.Clear();
            this.InitializeComponent();

            this.activePlayer = new ActivePlayer();
            RefreshPlayer(false);
        }
    }


    public enum PlayerChar
    {
        Circle,
        Cross
    }


    public class ActivePlayer
    {
        private PlayerChar playerChar;

        public ActivePlayer()
        {
            this.playerChar = PlayerChar.Circle;
        }


        public char GetPlayerChar()
        {
            return this.playerChar switch
            {
                PlayerChar.Circle => 'O',
                PlayerChar.Cross => 'X'
            };
        }


        public void SwitchPlayer()
        {
            this.playerChar = this.playerChar switch
            {
                PlayerChar.Circle => PlayerChar.Cross,
                PlayerChar.Cross => PlayerChar.Circle
            };
        }


        public void SetPlayer(PlayerChar playerChar)
        {
            this.playerChar = playerChar;
        }
    }


    public class GameGrid : TableLayoutPanel
    {
        private RootForm Root;

        private GameButton TopLeft;
        private GameButton TopCenter;
        private GameButton TopRight;
        private GameButton CenterLeft;
        private GameButton CenterCenter;
        private GameButton CenterRight;
        private GameButton BottomLeft;
        private GameButton BottomCenter;
        private GameButton BottomRight;


        public GameGrid(RootForm root)
        {
            // Inicjalizacja -----------
            this.Root = root;

            // Style -----------
            this.ColumnCount = 3;
            this.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            this.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            this.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            this.Dock = DockStyle.Fill;
            this.Location = new Point(0, 0);
            this.Name = "tableLayoutPanel1";
            this.RowCount = 4;
            this.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            this.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            this.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            this.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            this.Size = new Size(537, 521);
            this.TabIndex = 0;


            // Komponenty -----------
            this.TopLeft = new GameButton(this.Root);
            this.Controls.Add(this.TopLeft, 0, 1);

            this.TopCenter = new GameButton(this.Root);
            this.Controls.Add(this.TopCenter, 1, 1);

            this.TopRight = new GameButton(this.Root);
            this.Controls.Add(this.TopRight, 2, 1);

            this.CenterLeft = new GameButton(this.Root);
            this.Controls.Add(this.CenterLeft, 0, 2);

            this.CenterCenter = new GameButton(this.Root);
            this.Controls.Add(this.CenterCenter, 1, 2);

            this.CenterRight = new GameButton(this.Root);
            this.Controls.Add(this.CenterRight, 2, 2);

            this.BottomLeft = new GameButton(this.Root);
            this.Controls.Add(this.BottomLeft, 0, 3);

            this.BottomCenter = new GameButton(this.Root);
            this.Controls.Add(this.BottomCenter, 1, 3);

            this.BottomRight = new GameButton(this.Root);
            this.Controls.Add(this.BottomRight, 2, 3);
        }

        public void Refresh()
        {
            //sprawdzamy czy kto� wygra�
            this.CheckResult();
            //zmiana gracza
            this.Root.RefreshPlayer(true);
            //zablokuj guzik
        }

        public void EndGame(string message)
        {

            this.Controls.Clear();

            Label EndLabel = new Label();
            EndLabel.Text = message;
            EndLabel.Dock = DockStyle.Fill;
            EndLabel.TextAlign = ContentAlignment.MiddleCenter;
            EndLabel.Font = new Font("Arial", 21, FontStyle.Bold);

            this.Controls.Add(EndLabel, 1, 1);

            Button ContinueButton = new Button();
            ContinueButton.Text = "Kontynuuj";
            ContinueButton.Anchor = AnchorStyles.None;
            ContinueButton.Click += (object sender, EventArgs e) => this.Root.Reset();
            
            this.Controls.Add(ContinueButton, 1, 2);
        }


        public bool CheckCombination(GameButton button1, GameButton button2, GameButton button3)
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

        public void CheckResult()
        {
            // Wiersze -------


            // sprawdzamy kombinacje g�rnego wiersza
            if (CheckCombination(this.TopLeft, TopCenter, TopRight))
            {
                // Informujemy kto wygra�, nie jest wa�ne sk�d we�miemy znak wygranego
                // wa�ne aby to pole by�o cz�ci� tej kombinacji
                EndGame("Wygra� gracz: " + TopLeft.Text);
                return;
            }

            // sprawdzamy kombinacje �rodkowego wiersza
            if (CheckCombination(CenterLeft, CenterCenter, CenterRight))
            {
                EndGame("Wygra� gracz: " + CenterLeft.Text);
                return;
            }

            // sprawdzamy kombinacje dolnego wiersza
            if (CheckCombination(BottomLeft, BottomCenter, BottomRight))
            {
                EndGame("Wygra� gracz: " + BottomLeft.Text);
                return;
            }


            // Kolumny -------


            // sprawdzamy kombinacje lewej kolumny
            if (CheckCombination(TopLeft, CenterLeft, BottomLeft))
            {
                EndGame("Wygra� gracz: " + TopLeft.Text);
                return;
            }

            // sprawdzamy kombinacje �rodkowej kolumny
            if (CheckCombination(TopCenter, CenterCenter, BottomCenter))
            {
                EndGame("Wygra� gracz: " + TopCenter.Text);
                return;
            }

            // sprawdzamy kombinacje prawej kolumny
            if (CheckCombination(TopRight, CenterRight, BottomRight))
            {
                EndGame("Wygra� gracz: " + TopRight.Text);
                return;
            }


            // Skosy -------


            // sprawdzamy kombinacje skosu spadaj�cego
            if (CheckCombination(TopLeft, CenterCenter, BottomRight))
            {
                EndGame("Wygra� gracz: " + TopLeft.Text);
                return;
            }

            // sprawdzamy kombinacje skosu wzrastaj�cego
            if (CheckCombination(BottomLeft, CenterCenter, TopRight))
            {
                EndGame("Wygra� gracz: " + TopRight.Text);
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


        public class GameButton : Button
        {
            private RootForm Root;

            public GameButton(RootForm root)
            {
                this.Dock = DockStyle.Fill;
                this.Location = new Point(3, 43);
                this.Size = new Size(172, 154);
                this.UseVisualStyleBackColor = true;
                this.Click += this.HandleClick;


                this.Root = root;
            }


            public void HandleClick(object sender, EventArgs e)
            {
                //stw�rz obiekt klasy button i rzutuj do niego zawarto�� sender
                Button self = (Button)sender;

                //je�li na guziku jest ju� jaki� napis to zako�cz funkcj�
                if (self.Text != "")
                {
                    return;
                }

                this.Text = this.Root.GetActivePlayer().GetPlayerChar().ToString();
                this.Root.RefreshGameGrid();
            }
        }
    }
}
