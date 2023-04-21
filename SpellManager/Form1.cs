using System;
using System.Drawing;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace SpellManager
{
    public partial class Form1 : Form
    {
        //キーボードフッククラスのインスタンス生成
        KeyboardHook _hook = new KeyboardHook();

        //マウスのクリック位置を記憶
        private Point mousePoint;
        private Timer timer1 = new Timer(1000);
        private Timer timer2 = new Timer(1000);
        private Timer timer3 = new Timer(1000);
        private Timer timer4 = new Timer(1000);
        private Timer timer5 = new Timer(1000);

        private bool PressingShiftKey = false;
        private bool PressingControlKey = false;

        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Opacity = 0.6;
            this.MinimumSize = new Size(0, 0);
            this.Size = new Size(96, 240);
            this.KeyPreview = true;

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

        private void pictureBox1_Click(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) != MouseButtons.Left) return;
            StartTimer(lblS1, timer1);
        }

        private void picS2_Click(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) != MouseButtons.Left) return;
            StartTimer(lblS2, timer2);
        }

        private void picS3_Click(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) != MouseButtons.Left) return;
            StartTimer(lblS3, timer3);
        }

        private void picS4_Click(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) != MouseButtons.Left) return;
            StartTimer(lblS4, timer4);
        }

        private void picS5_Click(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) != MouseButtons.Left) return;
            StartTimer(lblS5, timer5);
        }

        private void picReset_Click(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) != MouseButtons.Left) return;
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

        private void picS1Up_Click(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) != MouseButtons.Left) return;
            var time = DateTime.Parse("0:" + lblS1.Text).AddSeconds(5);
            lblS1.Text = time.ToString("m:ss");
        }

        private void picS1Down_Click(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) != MouseButtons.Left) return;
            var time = DateTime.Parse("0:" + lblS1.Text).AddSeconds(-5);
            lblS1.Text = time.ToString("m:ss");
        }

        private void picS2Up_Click(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) != MouseButtons.Left) return;
            var time = DateTime.Parse("0:" + lblS2.Text).AddSeconds(5);
            lblS2.Text = time.ToString("m:ss");
        }

        private void picS2Down_Click(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) != MouseButtons.Left) return;
            var time = DateTime.Parse("0:" + lblS2.Text).AddSeconds(-5);
            lblS2.Text = time.ToString("m:ss");
        }

        private void picS3Up_Click(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) != MouseButtons.Left) return;
            var time = DateTime.Parse("0:" + lblS3.Text).AddSeconds(5);
            lblS3.Text = time.ToString("m:ss");
        }

        private void picS3Down_Click(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) != MouseButtons.Left) return;
            var time = DateTime.Parse("0:" + lblS3.Text).AddSeconds(-5);
            lblS3.Text = time.ToString("m:ss");
        }

        private void picS4Up_Click(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) != MouseButtons.Left) return;
            var time = DateTime.Parse("0:" + lblS4.Text).AddSeconds(5);
            lblS4.Text = time.ToString("m:ss");
        }

        private void picS4Down_Click(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) != MouseButtons.Left) return;
            var time = DateTime.Parse("0:" + lblS4.Text).AddSeconds(-5);
            lblS4.Text = time.ToString("m:ss");
        }

        private void picS5Up_Click(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) != MouseButtons.Left) return;
            var time = DateTime.Parse("0:" + lblS5.Text).AddSeconds(5);
            lblS5.Text = time.ToString("m:ss");
        }

        private void picS5Down_Click(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) != MouseButtons.Left) return;
            var time = DateTime.Parse("0:" + lblS5.Text).AddSeconds(-5);
            lblS5.Text = time.ToString("m:ss");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //キーボードが押された時のイベントハンドラを登録
            _hook.OnKeyDown += (s, ea) =>
            {
                ea.RetCode = 1;

                switch (ea.Key)
                {
                    case Keys.F8:
                        PressedFunctionKey(lblS1, timer1);
                        break;
                    case Keys.F9:
                        PressedFunctionKey(lblS2, timer2);
                        break;
                    case Keys.F10:
                        PressedFunctionKey(lblS3, timer3);
                        break;
                    case Keys.F11:
                        PressedFunctionKey(lblS4, timer4);
                        break;
                    case Keys.F12:
                        PressedFunctionKey(lblS5, timer5);
                        break;
                    case Keys.LShiftKey:
                    case Keys.RShiftKey:
                        PressingShiftKey = true;
                        ea.RetCode = 0;
                        break;
                    case Keys.LControlKey:
                    case Keys.RControlKey:
                        PressingControlKey = true;
                        ea.RetCode = 0;
                        break;
                    default:
                        ea.RetCode = 0;
                        break;
                }
            };

            _hook.OnKeyUp += (s, ea) =>
            {
                if (ea.Key == Keys.LShiftKey || ea.Key == Keys.RShiftKey)
                {
                    PressingShiftKey = false;
                }
                else if (ea.Key == Keys.LControlKey || ea.Key == Keys.RControlKey)
                {
                    PressingControlKey = false;
                }
            };

            //キーボードフックの開始
            _hook.Hook();
        }

        private void PressedFunctionKey(Label lbl, Timer timer)
        {
            if (lbl.Visible)
            {
                if (PressingControlKey)
                {
                    lbl.Visible = false;
                    timer.Stop();
                }
                else if (PressingShiftKey)
                {
                    var time = DateTime.Parse("0:" + lbl.Text).AddSeconds(5);
                    lbl.Text = time.ToString("m:ss");
                }
                else
                {
                    var time = DateTime.Parse("0:" + lbl.Text).AddSeconds(-5);
                    lbl.Text = time.ToString("m:ss");
                }
            }
            else
            {
                if (PressingControlKey) return;
                StartTimer(lbl, timer);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //キーボードフックの終了
            _hook.UnHook();
        }
    }
}
