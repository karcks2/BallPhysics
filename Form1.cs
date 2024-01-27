namespace BallPysichs
{
    public partial class Form1 : Form
    {
        System.Windows.Forms.Timer mainTimer = null;

        private int horVelocity = 2;
        private int verVelocity = 2;

        public Form1()
        {
            InitializeComponent();
            InitializeGame();
            InitalizeMainTimer();
        }

        public void InitializeGame()
        {
            this.DoubleBuffered = true;

            this.BackColor = Color.Black;

            this.Width = 820;
            this.Height = 620;

            this.Text = "Bouncing ball";


            Ball.Width = 20;
            Ball.Height = 20;

            Ball.Left = 190;
            Ball.Top = 190;

            Ball.BackColor = Color.White;
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
        }

        private void BallBorderCollision()
        {

            if (Ball.Left <= 0 || Ball.Left + Ball.Width >= ClientRectangle.Width)
            {
                horVelocity *= -1;
                horVelocity += 2;

            }
            else if (Ball.Right <= 0 || Ball.Right + Ball.Width >= ClientRectangle.Width)
            {
                horVelocity *= -1;
                horVelocity += -2;
            }

            else if (Ball.Top <= 0 || Ball.Top + Ball.Height >= ClientRectangle.Height)
            {
                verVelocity *= -1;
            }
        }
    }
}
    

