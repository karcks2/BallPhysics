namespace BallPysichs
{
    partial class Form1
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
            Ball = new PictureBox();
            player2 = new PictureBox();
            player1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)Ball).BeginInit();
            ((System.ComponentModel.ISupportInitialize)player2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)player1).BeginInit();
            SuspendLayout();
            // 
            // Ball
            // 
            Ball.Location = new Point(367, 195);
            Ball.Name = "Ball";
            Ball.Size = new Size(38, 40);
            Ball.TabIndex = 0;
            Ball.TabStop = false;
            // 
            // player2
            // 
            player2.Location = new Point(750, 138);
            player2.Name = "player2";
            player2.Size = new Size(38, 191);
            player2.TabIndex = 1;
            player2.TabStop = false;
            // 
            // player1
            // 
            player1.Location = new Point(12, 138);
            player1.Name = "player1";
            player1.Size = new Size(38, 172);
            player1.TabIndex = 2;
            player1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(player1);
            Controls.Add(player2);
            Controls.Add(Ball);
            Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)Ball).EndInit();
            ((System.ComponentModel.ISupportInitialize)player2).EndInit();
            ((System.ComponentModel.ISupportInitialize)player1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox Ball;
        private PictureBox player2;
        private PictureBox player1;
    }
}
