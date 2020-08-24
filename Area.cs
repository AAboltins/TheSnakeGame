using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheSnakeGame
{
    class Area : PictureBox
    {
        public Area()
        {
            InitializeArea();
        }
        private void InitializeArea()
        {
            this.Height = 700;
            this.Width = 1400;
            this.Image = (Image)Properties.Resources.ResourceManager.GetObject($"GameZone");
        }
    }
}
