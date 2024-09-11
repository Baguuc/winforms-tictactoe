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
            tableLayoutPanel1 = new TableLayoutPanel();
            TopLeft = new Button();
            TopCenter = new Button();
            TopRight = new Button();
            CenterLeft = new Button();
            CenterCenter = new Button();
            CenterRight = new Button();
            BottomLeft = new Button();
            BottomCenter = new Button();
            BottomRight = new Button();
            ActivePlayerLabel = new Label();
            Reset = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tableLayoutPanel1.Controls.Add(TopLeft, 0, 1);
            tableLayoutPanel1.Controls.Add(TopCenter, 1, 1);
            tableLayoutPanel1.Controls.Add(TopRight, 2, 1);
            tableLayoutPanel1.Controls.Add(CenterLeft, 0, 2);
            tableLayoutPanel1.Controls.Add(CenterCenter, 1, 2);
            tableLayoutPanel1.Controls.Add(CenterRight, 2, 2);
            tableLayoutPanel1.Controls.Add(BottomLeft, 0, 3);
            tableLayoutPanel1.Controls.Add(BottomCenter, 1, 3);
            tableLayoutPanel1.Controls.Add(BottomRight, 2, 3);
            tableLayoutPanel1.Controls.Add(ActivePlayerLabel, 1, 0);
            tableLayoutPanel1.Controls.Add(Reset, 2, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Size = new Size(537, 521);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // TopLeft
            // 
            TopLeft.Dock = DockStyle.Fill;
            TopLeft.Location = new Point(3, 43);
            TopLeft.Name = "TopLeft";
            TopLeft.Size = new Size(172, 154);
            TopLeft.TabIndex = 0;
            TopLeft.UseVisualStyleBackColor = true;
            TopLeft.Click += GameButtonClick;
            // 
            // TopCenter
            // 
            TopCenter.Dock = DockStyle.Fill;
            TopCenter.Location = new Point(181, 43);
            TopCenter.Name = "TopCenter";
            TopCenter.Size = new Size(173, 154);
            TopCenter.TabIndex = 1;
            TopCenter.UseVisualStyleBackColor = true;
            TopCenter.Click += GameButtonClick;
            // 
            // TopRight
            // 
            TopRight.Dock = DockStyle.Fill;
            TopRight.Location = new Point(360, 43);
            TopRight.Name = "TopRight";
            TopRight.Size = new Size(174, 154);
            TopRight.TabIndex = 2;
            TopRight.UseVisualStyleBackColor = true;
            TopRight.Click += GameButtonClick;
            // 
            // CenterLeft
            // 
            CenterLeft.Dock = DockStyle.Fill;
            CenterLeft.Location = new Point(3, 203);
            CenterLeft.Name = "CenterLeft";
            CenterLeft.Size = new Size(172, 154);
            CenterLeft.TabIndex = 3;
            CenterLeft.UseVisualStyleBackColor = true;
            CenterLeft.Click += GameButtonClick;
            // 
            // CenterCenter
            // 
            CenterCenter.Dock = DockStyle.Fill;
            CenterCenter.Location = new Point(181, 203);
            CenterCenter.Name = "CenterCenter";
            CenterCenter.Size = new Size(173, 154);
            CenterCenter.TabIndex = 4;
            CenterCenter.UseVisualStyleBackColor = true;
            CenterCenter.Click += GameButtonClick;
            // 
            // CenterRight
            // 
            CenterRight.Dock = DockStyle.Fill;
            CenterRight.Location = new Point(360, 203);
            CenterRight.Name = "CenterRight";
            CenterRight.Size = new Size(174, 154);
            CenterRight.TabIndex = 5;
            CenterRight.UseVisualStyleBackColor = true;
            CenterRight.Click += GameButtonClick;
            // 
            // BottomLeft
            // 
            BottomLeft.Dock = DockStyle.Fill;
            BottomLeft.Location = new Point(3, 363);
            BottomLeft.Name = "BottomLeft";
            BottomLeft.Size = new Size(172, 155);
            BottomLeft.TabIndex = 6;
            BottomLeft.UseVisualStyleBackColor = true;
            BottomLeft.Click += GameButtonClick;
            // 
            // BottomCenter
            // 
            BottomCenter.Dock = DockStyle.Fill;
            BottomCenter.Location = new Point(181, 363);
            BottomCenter.Name = "BottomCenter";
            BottomCenter.Size = new Size(173, 155);
            BottomCenter.TabIndex = 7;
            BottomCenter.UseVisualStyleBackColor = true;
            BottomCenter.Click += GameButtonClick;
            // 
            // BottomRight
            // 
            BottomRight.Dock = DockStyle.Fill;
            BottomRight.Location = new Point(360, 363);
            BottomRight.Name = "BottomRight";
            BottomRight.Size = new Size(174, 155);
            BottomRight.TabIndex = 8;
            BottomRight.UseVisualStyleBackColor = true;
            BottomRight.Click += GameButtonClick;
            // 
            // ActivePlayerLabel
            // 
            ActivePlayerLabel.AutoSize = true;
            ActivePlayerLabel.Dock = DockStyle.Fill;
            ActivePlayerLabel.Location = new Point(181, 0);
            ActivePlayerLabel.Name = "ActivePlayerLabel";
            ActivePlayerLabel.Size = new Size(173, 40);
            ActivePlayerLabel.TabIndex = 9;
            ActivePlayerLabel.Text = "Aktywny gracz:";
            ActivePlayerLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Reset
            // 
            Reset.Location = new Point(360, 3);
            Reset.Name = "Reset";
            Reset.Size = new Size(75, 23);
            Reset.TabIndex = 10;
            Reset.Text = "Reset";
            Reset.UseVisualStyleBackColor = true;
            Reset.Click += ResetButtonClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(537, 521);
            Controls.Add(tableLayoutPanel1);
            Name = "Form1";
            Text = "Form1";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button TopLeft;
        private Button TopCenter;
        private Button TopRight;
        private Button CenterLeft;
        private Button CenterCenter;
        private Button CenterRight;
        private Button BottomLeft;
        private Button BottomCenter;
        private Button BottomRight;
        private Label ActivePlayerLabel;
        private Button Reset;
    }
}
