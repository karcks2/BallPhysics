using System.IO;
using System.Windows.Forms;

namespace BallPysichs
{
    public partial class Game : Form
    {
        System.Windows.Forms.Timer mainTimer = null;

        private int ballx = 2;
        private int bally = -2;

        private int playerSpeed = 5;
        private int aiSpeed = 3;

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

            this.Text = "Ping-Pong";
            
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
            player.Height = 120;

            aiPlayer.Width = 20;
            aiPlayer.Height = 120;


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
            Ball.Left += ballx;
            Ball.Top += bally;

            // When the ball touches right or left wall
            if (Ball.Left <= 0 || Ball.Left + Ball.Width >= ClientRectangle.Width)
            {
                mainTimer.Stop();
                MessageBox.Show("Ai won");
                SetBallLocationToStart();
                bally = 2;
                ballx = 2;
                mainTimer.Start();
            }
            if (Ball.Right <= 0 || Ball.Right + Ball.Width >= ClientRectangle.Width)
            {
                mainTimer.Stop();
                MessageBox.Show("You won");
                SetBallLocationToStart();
                bally = 2;
                ballx = 2;
                mainTimer.Start();
            }
            else if (Ball.Top <= 0 || Ball.Top + Ball.Height >= ClientRectangle.Height)
            {
                bally *= -1;
            }

            BallPlayer1Collison();
            BallaiPlayerCollison();

            // ai
            if (ballx > 0)
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
                int aiPlayerMidpoint = aiPlayer.Top + aiPlayer.Height / 2;

                if (Ball.Top < aiPlayerMidpoint)
                {
                    // Make the ball go upwards if the ball touches the upper part
                    bally = -Math.Abs(bally); 
                }
                else
                {
                    bally = Math.Abs(bally); 
                }

                ballx *= -1;

            }

            if (Ball.Left <= 0 || aiPlayer.Right >= ClientSize.Width)
            {
                ballx *= -1;
                ballx += 2;
            }

            if (Ball.Top <= 0 || aiPlayer.Bottom >= ClientSize.Height)
            {
                bally *= -1;
                bally += 2;
            }
        }

        private void BallPlayer1Collison()
        {
            if (Ball.Bounds.IntersectsWith(player.Bounds))
            {
                int playerMidpoint = player.Top + player.Height / 2;

                if (Ball.Top < playerMidpoint)
                {
                    // Make the ball go upwards when the it touches the upper part
                    bally = -Math.Abs(bally); 
                }
                else
                {
                    bally = Math.Abs(bally); 
                }

                // Change direction in the x-axis
                ballx *= -1;
            }

            // Add boundary checking logic if needed
            // Example: Reverse direction when hitting form boundaries
            if (Ball.Left <= 0 || player.Right >= ClientSize.Width)
            {
                ballx *= -1;
                ballx += 2;
            }

            if (Ball.Top <= 0 || player.Bottom >= ClientSize.Height)
            {
                bally *= -1;
                bally += 2;
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
    

