using System.IO;
using System.Windows.Forms;

namespace BallPysichs
{
    public partial class Game : Form
    {
        System.Windows.Forms.Timer mainTimer = null;

        private int horVelocity = 2;
        private int verVelocity = 2;

        private int playerSpeed = 5;
        private int aiSpeed = 5;

        public Game()
        {
            KeyDown += Game_KeyDown;


            InitializeComponent();
            InitalizeMainTimer();

            InitializeGame();
            InitalizeBall();
            InitalizePlayer();

        }

        public void InitializeGame()
        {
            this.DoubleBuffered = true;

            this.BackColor = Color.Black;

            this.Width = 1080;
            this.Height = 820;

            this.Text = "Bouncing ball";

        }

        public void InitalizeBall()
        {

            Ball.Width = 20;
            Ball.Height = 20;

            Ball.Left = 190;
            Ball.Top = 190;

            Ball.BackColor = Color.White;
        }

        public void InitalizePlayer()
        {
            player.BackColor = Color.White;
            aiPlayer.BackColor = Color.White;

            player.Width = 20;
            player.Height = 100;

            aiPlayer.Width = 20;
            aiPlayer.Height = 100;


        }

        private void InitalizeMainTimer()
        {
            mainTimer = new System.Windows.Forms.Timer();
            mainTimer.Interval = 20;
            mainTimer.Tick += MainTimer_Tick;
            mainTimer.Start();
        }

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            Ball.Left += horVelocity;
            Ball.Top += verVelocity;

            // When the ball touches right or left wall
            if (Ball.Left <= 0 || Ball.Left + Ball.Width >= ClientRectangle.Width)
            {
                mainTimer.Stop();
                MessageBox.Show("Game over ");
                SetBallLocationToStart();
                verVelocity = 2;
                horVelocity = 2;
                mainTimer.Start();
            }
            else if (Ball.Top <= 0 || Ball.Top + Ball.Height >= ClientRectangle.Height)
            {
                verVelocity *= -1;
            }

            BallPlayer1Collison();
            BallaiPlayerCollison();

            // ai
            if (horVelocity > 0)
            {
                if (Ball.Top + Ball.Height / 2 > aiPlayer.Bottom)
                {
                    aiPlayer.Top += aiSpeed;
                }
                else
                {
                    aiPlayer.Top -= aiSpeed;
                }
            }
        }

        private void SetBallLocationToStart()
        {
            int x = 190;
            int y = 190;

            Point newLocation = new Point(x, y);

            Ball.Location = newLocation;
        }

        private void BallaiPlayerCollison()
        {
            if (Ball.Bounds.IntersectsWith(aiPlayer.Bounds))
            {
                // Change direction when collision occurs
                horVelocity *= -1;
                verVelocity *= -1;
                verVelocity += -2;
                horVelocity += -2;
            }

            // Add boundary checking logic if needed
            // Example: Reverse direction when hitting form boundaries
            if (Ball.Left <= 0 || aiPlayer.Right >= ClientSize.Width)
            {
                horVelocity *= -1;
            }

            if (Ball.Top <= 0 || aiPlayer.Bottom >= ClientSize.Height)
            {
                verVelocity *= -1;
            }
        }

        private void BallPlayer1Collison()
        {
            if (Ball.Bounds.IntersectsWith(player.Bounds))
            {
                // Change direction when collision occurs
                horVelocity *= -1;
                verVelocity *= -1;
                verVelocity += 2;
                horVelocity += 2;
            }

            // Add boundary checking logic if needed
            // Example: Reverse direction when hitting form boundaries
            if (Ball.Left <= 0 || player.Right >= ClientSize.Width)
            {
                horVelocity += -5;
            }

            if (Ball.Top <= 0 || player.Bottom >= ClientSize.Height)
            {
                verVelocity *= -1;
            }
        }

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            // Move the PictureBox up
            if (e.KeyCode == Keys.Up)
            {
                player.Top -= playerSpeed;
            }

            // Move the PictureBox down
            if (e.KeyCode == Keys.Down)
            {
                player.Top += playerSpeed;
            }

            // Update the PictureBox's location
            player.Location = new Point(player.Left, Math.Max(0, Math.Min(ClientSize.Height - player.Height, player.Top)));
        }
    }
}
    

