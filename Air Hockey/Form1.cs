using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Air_Hockey
{
    public partial class Form1 : Form
    {
        Pen blackPen = new Pen(Color.Black, 3);
        SolidBrush blackBrush = new SolidBrush(Color.Black);
        Pen pinkPen = new Pen(Color.Pink, 3);
        Pen purplePen = new Pen(Color.Purple, 3);
        SolidBrush pink = new SolidBrush(Color.Pink);
        SolidBrush purple = new SolidBrush(Color.Purple);
        Pen bluePen = new Pen(Color.Blue);
        SolidBrush blueBrush = new SolidBrush(Color.Blue);

        int paddle1X = 230;
        int paddle1Y = 10;
        int player1Score = 0;

        int paddle2X = 230;
        int paddle2Y = 400;
        int player2Score = 0;

        int paddleWidth = 40;
        int paddleHeight = 40;
        int paddleSpeed = 4;

        int ballX = 240;
        int ballY = 215;
        int ballXSpeed = 6;
        int ballYSpeed = 6;
        int ballWidth = 20;
        int ballHeight = 20;

        bool wDown = false;
        bool sDown = false;
        bool upArrowDown = false;
        bool downArrowDown = false;
        bool aDown = false;
        bool dDown = false;
        bool leftArrowDown = false;
        bool rightArrowDown = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.A:
                    aDown = true;
                    break;
                case Keys.D:
                    dDown = true;
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                case Keys.A:
                    aDown = false;
                    break;
                case Keys.D:
                    dDown = false;
                    break;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(blackPen, 50, 0, 50, 450);
            e.Graphics.DrawLine(blackPen, 450, 0, 450, 450);
            e.Graphics.DrawLine(blackPen, 50, 1, 450, 1);
            e.Graphics.DrawLine(blackPen, 50, 448, 450, 448);
            e.Graphics.DrawLine(blackPen, 50, 225, 450, 225);

            e.Graphics.DrawEllipse(pinkPen, paddle1X, paddle1Y, paddleWidth, paddleHeight);
            e.Graphics.DrawEllipse(purplePen, paddle2X, paddle2Y, paddleWidth, paddleHeight);
            e.Graphics.FillEllipse(pink, paddle1X, paddle1Y, paddleWidth, paddleHeight);
            e.Graphics.FillEllipse(purple, paddle2X, paddle2Y, paddleWidth, paddleHeight);

            e.Graphics.DrawRectangle(blackPen, 175, 0, 150, 20);
            e.Graphics.DrawRectangle(blackPen, 175, 430, 150, 20);

            e.Graphics.DrawEllipse(blackPen, 200, 175, 100, 100);

            e.Graphics.DrawEllipse(bluePen, ballX, ballY, ballWidth, ballHeight);
            e.Graphics.FillEllipse(blueBrush, ballX, ballY, ballWidth, ballHeight);

        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            ballX += ballXSpeed;
            ballY += ballYSpeed;

            if (wDown == true && paddle1Y > 0)
            {
                paddle1Y -= paddleSpeed;
            }

            if (sDown == true && paddle1Y < this.Height - paddleHeight)
            {
                paddle1Y += paddleSpeed;
            }
            if (aDown == true && paddle1X > 0)
            {
                paddle1X -= paddleSpeed;
            }

            if (dDown == true && paddle1X < this.Width - paddleWidth)
            {
                paddle1X += paddleSpeed;
            }

            //move player 2 
            if (upArrowDown == true && paddle2Y > 0)
            {
                paddle2Y -= paddleSpeed;
            }

            if (downArrowDown == true && paddle2Y < this.Height - paddleHeight)
            {
                paddle2Y += paddleSpeed;
            }


            //move player 2 on x axis
            if (leftArrowDown == true && paddle2X > 0)
            {
                paddle2X -= paddleSpeed;
            }
            if (rightArrowDown == true && paddle2X < this.Width - paddleWidth)
            {
                paddle2X += paddleSpeed;
            }

            if (ballY < 0 || ballY > this.Height - ballHeight)
            {
                ballYSpeed *= -1;  // or: ballYSpeed = -ballYSpeed; 
            }
            if (ballX < 50 || ballX > 450 - ballWidth)
            {
                ballXSpeed *= -1;
            }

            Rectangle player1Rec = new Rectangle(paddle1X, paddle1Y, paddleWidth, paddleHeight);
            Rectangle player2Rec = new Rectangle(paddle2X, paddle2Y, paddleWidth, paddleHeight);
            Rectangle ballRec = new Rectangle(ballX, ballY, ballWidth, ballHeight);

            if (player1Rec.IntersectsWith(ballRec))
            {
                ballXSpeed *= -1;
                ballX = paddle1X + paddleWidth + 1;
            }
            if (player2Rec.IntersectsWith(ballRec))
            {
                ballXSpeed *= -1;
                ballX = paddle1X + paddleWidth + 1;
            }

            Refresh();

        }
    }
}
