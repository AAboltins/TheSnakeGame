using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheSnakeGame
{
    class Snake
    {
        public int HorizontalVelocity { get; set; } = 1;
        public int VerVelocity { get; set; } = 0;
        public int Step { get; set; } = 20;
        int i  = 0;
        public List<PictureBox> snakePixels = new List<PictureBox>();
        public Snake()
        {
            InitializeSnake();
        }
        private void InitializeSnake()
        {
            AddPixel(200, 200);
            AddPixel(200, 220);
            AddPixel(200, 230);
        }
        public void AddPixel(int Left, int Top)
        {
            //i++;
            PictureBox snakePixel;
            snakePixel = new PictureBox();
            snakePixel.BackColor = Color.Blue;
            snakePixel.Height = 20;
            snakePixel.Width = 20;
            snakePixel.Left = Left;
            snakePixel.Top = Top;
            //snakePixel.Name = "button" + i;
            snakePixels.Add(snakePixel);
        }
        public void Render(Form form) 
        {
            foreach (var sp in snakePixels)
            {
                form.Controls.Add(sp);
                sp.BringToFront();
            }
        }
        public void fd()
        {
            InitializeSnake();
        }
        private void InitializeSnakeTexture()
        {
            snakePixels[1].BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("pixelSnakeBodyX");
            snakePixels[0].BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("pixelSnakeHeadLeft");
            snakePixels[snakePixels.Count-1].BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("pixelSnakeTaleLeft");
        }
        public void RenderSnakePixelHead(string headirection)
        {
            snakePixels[0].Image = (Image)Properties.Resources.ResourceManager.GetObject($"pixelSnakeHead{headirection}");
        }
        private void RenderSnakePixelBody(int index)
        {
            if(snakePixels[index].Top == snakePixels[index - 1].Top && snakePixels[index].Top == snakePixels[index + 1].Top)
            {
                snakePixels[index].Image = (Image)Properties.Resources.ResourceManager.GetObject($"pixelSnakeBodyX");
            }
            else if(snakePixels[index].Left == snakePixels[index - 1].Left && snakePixels[index].Left == snakePixels[index + 1].Left)
            {
                snakePixels[index].Image = (Image)Properties.Resources.ResourceManager.GetObject($"pixelSnakeBodyY");
            }
        }
        public void Move()
        {
            if (HorizontalVelocity == 0 & VerVelocity == 0) { return; }
            for (int i = snakePixels.Count - 1; i > 0; i--)
            {
                //if (i != snakePixels.Count-1)
                //{
                //     RenderSnakePixelBody(i);
                //}
                snakePixels[i].Location = snakePixels[i - 1].Location;
            }
            snakePixels[0].Left += this.HorizontalVelocity * this.Step;
            snakePixels[0].Top += this.VerVelocity * this.Step;
        }   

    }
}
