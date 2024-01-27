using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallPhysicsEngine
{
    internal class Ball : PictureBox
    {
        public int horVelocity = 1;
        public int vertVelocity = 1;

        public Ball()
        {
            this.Width = 20;
            this.Height = 20;
            this.BackColor = Color.White;

        }

    }
}
