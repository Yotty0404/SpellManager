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

namespace SpellManager
{
    public partial class Form1 : Form
    {
        //マウスのクリック位置を記憶
        private Point mousePoint;

        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Opacity = 0.8;
            this.MinimumSize = new Size(0, 0);
            this.Size = new Size(100, 250);

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

            SetLabelSetting(btnS1, lblS1);
            SetLabelSetting(btnS2, lblS2);
            SetLabelSetting(btnS3, lblS3);
            SetLabelSetting(btnS4, lblS4);
            SetLabelSetting(btnS5, lblS5);
        }

        private void SetLabelSetting(Button btn, Label lbl)
        {
            btn.Controls.Add(lbl);
            lbl.BackColor = Color.FromArgb(200, Color.Gray);
            lbl.Top = lbl.Top - btn.Top;
            lbl.Left = lbl.Left - btn.Left;
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
        private void SetTimer(Label lbl)
        {
            lbl.Visible = true;

            // タイマーの間隔(ミリ秒)
            var timer = new System.Timers.Timer(1000);
            //var time = new DateTime(2000, 1, 1, 0, 0, 3, 0);
            var time = new DateTime(2000, 1, 1, 0, 5, 0, 0);
            lbl.Text = time.ToString("m:ss");

            // タイマーの処理
            timer.Elapsed += (s, ee) =>
            {
                time = time.AddSeconds(-1);
                lbl.Text = time.ToString("m:ss");
                if (time.Minute == 0 && time.Second == 0)
                {
                    timer.Stop();
                    lbl.Visible = false;
                }
            };

            // タイマーを開始する
            timer.Start();
        }

        private void btnS1_Click(object sender, EventArgs e)
        {
            SetTimer(lblS1);
        }

        private void btnS2_Click(object sender, EventArgs e)
        {
            SetTimer(lblS2);
        }

        private void btnS3_Click(object sender, EventArgs e)
        {
            SetTimer(lblS3);
        }

        private void btnS4_Click(object sender, EventArgs e)
        {
            SetTimer(lblS4);
        }

        private void btnS5_Click(object sender, EventArgs e)
        {
            SetTimer(lblS5);
        }
    }
}
