using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programtervezési_minták.Entites
{
    public class Balls : Label
    {
        public Balls()
            {
            AutoSize = false;
            Width = Height = 50;
            Paint += Balls_Paint;
            }

        private void Balls_Paint(object sender, PaintEventArgs e)
        {
            DrawImage(e.Graphics);
        }

        private void DrawImage(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Red), 0, 0, Width, Height);
        }

        public void MoveBall()
        {
            Left++;
        }
    }
}
