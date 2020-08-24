using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheSnakeGame
{
    class Food:PictureBox
    {
        public Food()
        {
            InitalizeFood();
        }
        private void InitalizeFood()
        {
            this.Width = 20;
            this.Height= 20;
            this.BackColor = Color.Green;
        }
    }
}
