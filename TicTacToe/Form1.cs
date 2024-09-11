using System.Windows.Forms;

namespace TicTacToe
{
    public partial class RootForm : Form
    {
        //aktywny gracz - zaczynaj¹ kó³ka
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
            //zmieñ aktywnego gracza
            if (_switch)
            {
                this.activePlayer.SwitchPlayer();
            }

            //zmodyfikuj labelkê pokazuj¹c¹ aktywnego gracza
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
            //sprawdzamy czy ktoœ wygra³
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

        public void CheckResult()
        {
            // Wiersze -------


            // sprawdzamy kombinacje górnego wiersza
            if (CheckCombination(this.TopLeft, TopCenter, TopRight))
            {
                // Informujemy kto wygra³, nie jest wa¿ne sk¹d weŸmiemy znak wygranego
                // wa¿ne aby to pole by³o czêœci¹ tej kombinacji
                EndGame("Wygra³ gracz: " + TopLeft.Text);
                return;
            }

            // sprawdzamy kombinacje œrodkowego wiersza
            if (CheckCombination(CenterLeft, CenterCenter, CenterRight))
            {
                EndGame("Wygra³ gracz: " + CenterLeft.Text);
                return;
            }

            // sprawdzamy kombinacje dolnego wiersza
            if (CheckCombination(BottomLeft, BottomCenter, BottomRight))
            {
                EndGame("Wygra³ gracz: " + BottomLeft.Text);
                return;
            }


            // Kolumny -------


            // sprawdzamy kombinacje lewej kolumny
            if (CheckCombination(TopLeft, CenterLeft, BottomLeft))
            {
                EndGame("Wygra³ gracz: " + TopLeft.Text);
                return;
            }

            // sprawdzamy kombinacje œrodkowej kolumny
            if (CheckCombination(TopCenter, CenterCenter, BottomCenter))
            {
                EndGame("Wygra³ gracz: " + TopCenter.Text);
                return;
            }

            // sprawdzamy kombinacje prawej kolumny
            if (CheckCombination(TopRight, CenterRight, BottomRight))
            {
                EndGame("Wygra³ gracz: " + TopRight.Text);
                return;
            }


            // Skosy -------


            // sprawdzamy kombinacje skosu spadaj¹cego
            if (CheckCombination(TopLeft, CenterCenter, BottomRight))
            {
                EndGame("Wygra³ gracz: " + TopLeft.Text);
                return;
            }

            // sprawdzamy kombinacje skosu wzrastaj¹cego
            if (CheckCombination(BottomLeft, CenterCenter, TopRight))
            {
                EndGame("Wygra³ gracz: " + TopRight.Text);
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
                //stwórz obiekt klasy button i rzutuj do niego zawartoœæ sender
                Button self = (Button)sender;

                //jeœli na guziku jest ju¿ jakiœ napis to zakoñcz funkcjê
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
