using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.IO;
using System.Timers;
using Timer = System.Timers.Timer;
using System.Threading;

namespace SpellManager
{
    public partial class Form1 : Form
    {
        //マウスのクリック位置を記憶
        private Point mousePoint;
        private Timer timer1 = new Timer(1000);
        private Timer timer2 = new Timer(1000);
        private Timer timer3 = new Timer(1000);
        private Timer timer4 = new Timer(1000);
        private Timer timer5 = new Timer(1000);

        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Opacity = 0.6;
            this.MinimumSize = new Size(0, 0);
            this.Size = new Size(96, 250);

            int radius = 4;
            int diameter = radius * 2;
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();

            // 左上
            gp.AddPie(0, 0, diameter, diameter, 180, 90);
            // 右上
            gp.AddPie(this.Width - diameter, 0, diameter, diameter, 270, 90);
            // 左下
            gp.AddPie(0, this.Height - diameter, diameter, diameter, 90, 90);
            // 右下
            gp.AddPie(this.Width - diameter, this.Height - diameter, diameter, diameter, 0, 90);
            // 中央
            gp.AddRectangle(new Rectangle(radius, 0, this.Width - diameter, this.Height));
            // 左
            gp.AddRectangle(new Rectangle(0, radius, radius, this.Height - diameter));
            // 右
            gp.AddRectangle(new Rectangle(this.Width - radius, radius, radius, this.Height - diameter));

            this.Region = new Region(gp);

            SetLabelSetting(picS1, lblS1);
            SetLabelSetting(picS2, lblS2);
            SetLabelSetting(picS3, lblS3);
            SetLabelSetting(picS4, lblS4);
            SetLabelSetting(picS5, lblS5);

            SetTimer(lblS1, timer1);
            SetTimer(lblS2, timer2);
            SetTimer(lblS3, timer3);
            SetTimer(lblS4, timer4);
            SetTimer(lblS5, timer5);
        }

        private void SetLabelSetting(Button btn, Label lbl)
        {
            btn.Controls.Add(lbl);
            lbl.BackColor = Color.FromArgb(200, Color.Gray);
            lbl.Top = lbl.Top - btn.Top;
            lbl.Left = lbl.Left - btn.Left;
        }

        private void SetLabelSetting(PictureBox pic, Label lbl)
        {
            pic.Controls.Add(lbl);
            lbl.BackColor = Color.FromArgb(200, Color.Gray);
            lbl.Top = lbl.Top - pic.Top;
            lbl.Left = lbl.Left - pic.Left;
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                //位置を記憶する
                mousePoint = new Point(e.X, e.Y);
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                this.Left += e.X - mousePoint.X;
                this.Top += e.Y - mousePoint.Y;
            }
        }

        private void SetTimer(Label lbl, Timer timer)
        {
            // タイマーの処理
            timer.Elapsed += (s, ee) =>
            {
                var time = DateTime.Parse("0:" + lbl.Text).AddSeconds(-1);
                lbl.Text = time.ToString("m:ss");
                if (time.Minute == 0 && time.Second == 0)
                {
                    timer.Stop();
                    lbl.Visible = false;
                }
                else if (time.Minute == 59)
                {
                    timer.Stop();
                    lbl.Visible = false;
                }
            };
        }

        private void StartTimer(Label lbl, Timer timer)
        {
            lbl.Visible = true;

            // タイマーの間隔(ミリ秒)
            //var time = new DateTime(2000, 1, 1, 0, 0, 3, 0);
            var time = new DateTime(2000, 1, 1, 0, 5, 0, 0);
            lbl.Text = time.ToString("m:ss");

            // タイマーを開始する
            timer.Start();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            StartTimer(lblS1, timer1);
        }

        private void picS2_Click(object sender, EventArgs e)
        {
            StartTimer(lblS2, timer2);
        }

        private void picS3_Click(object sender, EventArgs e)
        {
            StartTimer(lblS3, timer3);
        }

        private void picS4_Click(object sender, EventArgs e)
        {
            StartTimer(lblS4, timer4);
        }

        private void picS5_Click(object sender, EventArgs e)
        {
            StartTimer(lblS5, timer5);
        }

        private void picReset_Click(object sender, EventArgs e)
        {
            lblS1.Visible = false;
            timer1.Stop();
            lblS2.Visible = false;
            timer2.Stop();
            lblS3.Visible = false;
            timer3.Stop();
            lblS4.Visible = false;
            timer4.Stop();
            lblS5.Visible = false;
            timer5.Stop();
        }

        private void picS1Up_Click(object sender, EventArgs e)
        {
            var time = DateTime.Parse("0:" + lblS1.Text).AddSeconds(5);
            lblS1.Text = time.ToString("m:ss");
        }

        private void picS1Down_Click(object sender, EventArgs e)
        {
            var time = DateTime.Parse("0:" + lblS1.Text).AddSeconds(-5);
            lblS1.Text = time.ToString("m:ss");
        }

        private void picS2Up_Click(object sender, EventArgs e)
        {
            var time = DateTime.Parse("0:" + lblS2.Text).AddSeconds(5);
            lblS2.Text = time.ToString("m:ss");
        }

        private void picS2Down_Click(object sender, EventArgs e)
        {
            var time = DateTime.Parse("0:" + lblS2.Text).AddSeconds(-5);
            lblS2.Text = time.ToString("m:ss");
        }

        private void picS3Up_Click(object sender, EventArgs e)
        {
            var time = DateTime.Parse("0:" + lblS3.Text).AddSeconds(5);
            lblS3.Text = time.ToString("m:ss");
        }

        private void picS3Down_Click(object sender, EventArgs e)
        {
            var time = DateTime.Parse("0:" + lblS3.Text).AddSeconds(-5);
            lblS3.Text = time.ToString("m:ss");
        }

        private void picS4Up_Click(object sender, EventArgs e)
        {
            var time = DateTime.Parse("0:" + lblS4.Text).AddSeconds(5);
            lblS4.Text = time.ToString("m:ss");
        }

        private void picS4Down_Click(object sender, EventArgs e)
        {
            var time = DateTime.Parse("0:" + lblS4.Text).AddSeconds(-5);
            lblS4.Text = time.ToString("m:ss");
        }

        private void picS5Up_Click(object sender, EventArgs e)
        {
            var time = DateTime.Parse("0:" + lblS5.Text).AddSeconds(5);
            lblS5.Text = time.ToString("m:ss");
        }

        private void picS5Down_Click(object sender, EventArgs e)
        {
            var time = DateTime.Parse("0:" + lblS5.Text).AddSeconds(-5);
            lblS5.Text = time.ToString("m:ss");
        }
    }
}
