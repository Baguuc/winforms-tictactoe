namespace TicTacToe
{
    partial class RootForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            _GameGrid = new GameGrid(this);

            // ActivePlayerLabel ------------
            
            ActivePlayerLabel = new Label();
            ActivePlayerLabel.AutoSize = true;
            ActivePlayerLabel.Dock = DockStyle.Fill;
            ActivePlayerLabel.Location = new Point(181, 0);
            ActivePlayerLabel.Name = "ActivePlayerLabel";
            ActivePlayerLabel.Size = new Size(173, 40);
            ActivePlayerLabel.TabIndex = 9;
            ActivePlayerLabel.Text = "Aktywny gracz:";
            ActivePlayerLabel.TextAlign = ContentAlignment.MiddleCenter;
            _GameGrid.Controls.Add(ActivePlayerLabel, 1, 0);

            // Reset ------------

            ResetButton = new Button();
            ResetButton.Location = new Point(360, 3);
            ResetButton.Name = "ResetButton";
            ResetButton.Size = new Size(75, 23);
            ResetButton.TabIndex = 10;
            ResetButton.Text = "Reset";
            ResetButton.UseVisualStyleBackColor = true;
            ResetButton.Click += (object sender, EventArgs e) => Reset();
            _GameGrid.Controls.Add(ResetButton, 2, 0);


            // RootForm ------------

            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(537, 521);
            this.Controls.Add(_GameGrid);
            this.Name = "RootForm";
            _GameGrid.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GameGrid _GameGrid;
        private Label ActivePlayerLabel;
        private Button ResetButton;
    }
}
