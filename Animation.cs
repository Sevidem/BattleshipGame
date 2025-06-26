using System;
using System.Drawing;
using System.Windows.Forms;

namespace BattleshipGame
{
    public class ExplosionAnimation
    {
        private readonly Timer timer;
        private readonly Panel panel;
        private Point location;
        private int frame;
        private readonly Image[] frames;

        public ExplosionAnimation(Panel panel)
        {
            this.panel = panel;
            timer = new Timer { Interval = 50 };
            timer.Tick += OnTimerTick;

            // Загружаем кадры анимации (можно заменить на свои изображения)
            frames = new Image[5];
            for (int i = 0; i < 5; i++)
            {
                frames[i] = new Bitmap(30, 30);
                using (var g = Graphics.FromImage(frames[i]))
                {
                    g.Clear(Color.Transparent);
                    g.FillEllipse(Brushes.OrangeRed, 5, 5, 20, 20);
                    g.DrawEllipse(new Pen(Color.Yellow, 2), 0, 0, 28, 28);
                }
            }
        }

        public void Play(Point location)
        {
            this.location = location;
            frame = 0;
            timer.Start();
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            frame++;
            if (frame >= frames.Length)
            {
                timer.Stop();
                panel.Invalidate();
                return;
            }

            using (var g = panel.CreateGraphics())
            {
                g.DrawImage(frames[frame], location);
            }
        }
    }
}