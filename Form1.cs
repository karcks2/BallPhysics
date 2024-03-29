using BallPhysicsEngine;

namespace BallPysichs
{
    public partial class Form1 : Form
    {
        System.Windows.Forms.Timer mainTimer = null;
        private Random r = new Random();
        private List<Ball> allBalls = new List<Ball>();

        public Form1()
        {
            InitializeComponent();
            InitializeComponent();
            InitializeGame();
            InitalizeMainTimer();
        }

        public void InitializeGame()
        {
            this.DoubleBuffered = true;
            this.BackColor = Color.Black;
            this.Width = 400;
            this.Height = 400;
            this.Text = "Bouncing ball";

            SpawnBalls(3);
        }

        public void SpawnBalls(int numbers)
        {
            for (int i = 0; i < numbers; i++)
            {
                var newBall = new Ball();
                newBall.Left = 190;
                newBall.Top = 190;
                newBall.horVelocity = r.Next(1, 10);
                newBall.vertVelocity = r.Next(1, 10);
                allBalls.Add(newBall);
                this.Controls.Add(newBall);
            }
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
            foreach (var ball in allBalls)
            {
                ball.Left += ball.horVelocity;
                ball.Top += ball.vertVelocity;
            }

            BallBorderCollision();
        }

        private void BallBorderCollision()
        {

            foreach (var ball in allBalls)
            {
                if (ball.Left <= 0 || ball.Left + ball.Width >= ClientRectangle.Width)
                {
                    ball.horVelocity *= -1;
                }
                else if (ball.Top <= 0 || ball.Top + ball.Height >= ClientRectangle.Height)
                {
                    ball.vertVelocity *= -1;
                }
            }
        }

    }
}
    

