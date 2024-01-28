using System.IO;
using System.Windows.Forms;

namespace BallPysichs
{
    public partial class Form1 : Form
    {
        System.Windows.Forms.Timer mainTimer = null;

        private int horVelocity = 2;
        private int verVelocity = 0;

        public Form1()
        {
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

            this.Width = 820;
            this.Height = 620;

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
            player1.BackColor = Color.White;
            player2.BackColor = Color.White;

            player1.Width = 20;
            player1.Height = 100;

            player2.Width = 20;
            player2.Height = 100;


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

            BallBorderCollision();
            BallPlayer1Collison();
            BallPlayer2Collison();
        }

        private void BallBorderCollision()
        {

            if (Ball.Left <= 0 || Ball.Left + Ball.Width >= ClientRectangle.Width)
            {
                mainTimer.Stop();
                MessageBox.Show("Game over press space to start again");
                SetBallLocationToStart();
                verVelocity = 0;
                horVelocity = 2;
                mainTimer.Start();
            }
            else if (Ball.Top <= 0 || Ball.Top + Ball.Height >= ClientRectangle.Height)
            {
                verVelocity *= -1;
            }
        }

        private void SetBallLocationToStart()
        {
            int x = 190;
            int y = 190;

            Point newLocation = new Point(x, y);

            Ball.Location = newLocation;
        }

        private void BallPlayer2Collison()
        {
            if (Ball.Bounds.IntersectsWith(player2.Bounds))
            {
                // Change direction when collision occurs
                horVelocity *= -1;
                verVelocity *= -1;
                verVelocity += 0;
                horVelocity += -2;
            }

            // Add boundary checking logic if needed
            // Example: Reverse direction when hitting form boundaries
            if (Ball.Left <= 0 || player2.Right >= ClientSize.Width)
            {
                horVelocity *= -1;
            }

            if (Ball.Top <= 0 || player2.Bottom >= ClientSize.Height)
            {
                verVelocity *= -1;
            }
        }

        private void BallPlayer1Collison()
        {
            if (Ball.Bounds.IntersectsWith(player1.Bounds))
            {
                // Change direction when collision occurs
                horVelocity *= -1;
                verVelocity *= -1;
                verVelocity += 0;
                horVelocity += 2;
            }

            // Add boundary checking logic if needed
            // Example: Reverse direction when hitting form boundaries
            if (Ball.Left <= 0 || player1.Right >= ClientSize.Width)
            {
                horVelocity += -5;
            }

            if (Ball.Top <= 0 || player1.Bottom >= ClientSize.Height)
            {
                verVelocity *= -1;
            }
        }
    }
}
    

