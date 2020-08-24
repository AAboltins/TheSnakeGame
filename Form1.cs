﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheSnakeGame
{
    public partial class Game : Form
    {

        Area area = new Area();
        Snake snake = new Snake();
        Timer mainTimer = new Timer();
        Food food = new Food();
        Random rand = new Random();
        public int score = 0;

        public Game()
        {
            InitializeComponent();
            InitializeGame();
            InitalizeTimer();
        }
        private void InitalizeTimer()
        {
            mainTimer.Interval = 100;
            mainTimer.Tick += (MainTimer_Tick);
            mainTimer.Start();
        }
        private void MainTimer_Tick(object sender, EventArgs e)
        {
            snake.Move();
            SnakeFoodCollision();
            SnakeBorderCollision();
            SnakeSelfCollision();
        }
        private void InitializeGame()
        {
            //form properties-----------
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            this.BackColor = Color.Black;
            //Add area------------------
            area.Location = new Point(100, 100);
            this.Controls.Add(area);
            //Add Food------------
            RandomizeFoodLocation();
            this.Controls.Add(food);
            food.BringToFront();
            //Adding KeyDown Event------
            this.KeyDown += (Game_KeyDown);
            //Adding snake
            snake.Render(this);
        }
        
        public void RandomizeFoodLocation()
        {
            bool breakloop = false;
            while (breakloop == false)
            {
                breakloop = true;
                food.Top = (rand.Next(1, (area.Height) / 20)) * 20 +120;
                food.Left = (rand.Next(1, (area.Width) / 20)) * 20 +120;

                foreach (var snakepixel in snake.snakePixels)
                {
                    if (snakepixel.Location == food.Location) { breakloop = false; break;}
                }
            }
            food.BringToFront();
        }
        private void SnakeFoodCollision()
        {
            if (snake.snakePixels[0].Bounds.IntersectsWith(food.Bounds))
            {
                //Make snake longer and "Regenerate food"
                RandomizeFoodLocation();
                score += 10;
                int left = snake.snakePixels[snake.snakePixels.Count - 1].Left;
                int top = snake.snakePixels[snake.snakePixels.Count - 1].Top;
                snake.AddPixel(top, left);
                snake.Render(this);
                //Incrising speed...
                if (mainTimer.Interval >= 20){mainTimer.Interval -= 3;}
            }
        }
        private void SnakeBorderCollision()
        {
            if (!snake.snakePixels[0].Bounds.IntersectsWith(area.Bounds))
            {
                GameOver();
                mainTimer.Stop();
            }
        }
        private void SnakeSelfCollision()
        {
            for (int i = 1; i < snake.snakePixels.Count; i++)
            {
                if(snake.snakePixels[0].Bounds.IntersectsWith(snake.snakePixels[i].Bounds))
                {
                    GameOver();
                }
            }
        }
        private void GameOver()
        {
            mainTimer.Stop();
            snake.snakePixels[0].BackColor = Color.Red;
            snake.snakePixels[0].BringToFront();
            MessageBox.Show($"Game over!You score: {score}");
        }
        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                    if (snake.HorizontalVelocity != -1)
                    {
                        snake.HorizontalVelocity = 1;
                        snake.VerVelocity = 0;
                        //snake.RenderSnakePixelHead("Right");
                    }
                    break;
                case Keys.Up:
                    if (snake.VerVelocity != 1)
                    {
                        snake.HorizontalVelocity = 0;
                        snake.VerVelocity = -1;
                        //snake.RenderSnakePixelHead("Top");
                    }
                    break;
                case Keys.Down:
                    if (snake.VerVelocity != -1)
                    {
                        snake.HorizontalVelocity = 0;
                        snake.VerVelocity = 1;
                        //snake.RenderSnakePixelHead("Bottom");
                    }
                    break;
                case Keys.Left:
                    if (snake.HorizontalVelocity != 1)
                    {
                        snake.HorizontalVelocity = -1;
                        snake.VerVelocity = 0;
                        //snake.RenderSnakePixelHead("Left");
                    }
                    break;
            }
        }
    }
}