using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheSnakeGame
{
    class ScoreBoardControls
    {
        PictureBox infoboard;
        public Label score;
        Label textscore;
        public ScoreBoardControls()
        {
            //InitializeScoreBoard();S
        }
        public void InitializeScoreBoard(Form form)
        {
            //creating scoreboardfoundation------------------
            infoboard = new PictureBox();
            infoboard.Name = "infoboard";
            infoboard.Size = new Size(1605, 39);
            infoboard.Location = new Point(0, 0);
            infoboard.BackColor = Color.FromArgb(44, 44, 44);
            form.Controls.Add(infoboard);
            //adding scoreboard details---------------------
            score = new Label();
            score.Name = "score";
            score.Location = new Point(89, 9);
            score.Font = new Font("ArcadeClassic", 15);
            score.ForeColor = Color.Yellow;
            score.BackColor = Color.FromArgb(30, 30, 30);
            form.Controls.Add(score);
            score.Text = "00000";
            score.BorderStyle =  BorderStyle.Fixed3D;
            score.BringToFront();
            //62; 18(Size)
            //12; 9
            textscore = new Label();
            textscore.Name = "textscore";
            textscore.Location = new Point(15, 9);
            textscore.Font = new Font("ArcadeClassic", 15);
            textscore.ForeColor = Color.Yellow;
            textscore.BackColor = Color.FromArgb(44, 44, 44);
            textscore.BringToFront();
            textscore.Size = new Size(68, 18);
            textscore.Text = "score:";
            form.Controls.Add(textscore);
            textscore.BringToFront();
        }
        public void UpdateScore(int points)
        {
            score.Text = points.ToString("00000");
        }
    }
}
