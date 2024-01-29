namespace BallPysichs
{
    partial class Game
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
            aiPlayer = new PictureBox();
            player = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)Ball).BeginInit();
            ((System.ComponentModel.ISupportInitialize)aiPlayer).BeginInit();
            ((System.ComponentModel.ISupportInitialize)player).BeginInit();
            SuspendLayout();
            // 
            // Ball
            // 
            Ball.Location = new Point(477, 290);
            Ball.Name = "Ball";
            Ball.Size = new Size(38, 40);
            Ball.TabIndex = 0;
            Ball.TabStop = false;
            // 
            // aiPlayer
            // 
            aiPlayer.Location = new Point(1006, 248);
            aiPlayer.Name = "aiPlayer";
            aiPlayer.Size = new Size(38, 191);
            aiPlayer.TabIndex = 1;
            aiPlayer.TabStop = false;
            // 
            // player
            // 
            player.Location = new Point(12, 138);
            player.Name = "player";
            player.Size = new Size(38, 172);
            player.TabIndex = 2;
            player.TabStop = false;
            // 
            // Game
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1056, 756);
            Controls.Add(player);
            Controls.Add(aiPlayer);
            Controls.Add(Ball);
            Name = "Game";
            ((System.ComponentModel.ISupportInitialize)Ball).EndInit();
            ((System.ComponentModel.ISupportInitialize)aiPlayer).EndInit();
            ((System.ComponentModel.ISupportInitialize)player).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox Ball;
        private PictureBox aiPlayer;
        private PictureBox player;
    }
}
