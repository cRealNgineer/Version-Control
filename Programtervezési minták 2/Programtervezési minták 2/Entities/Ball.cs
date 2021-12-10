using Programtervezési_minták_2.Abstractions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programtervezési_minták_2.Entities
{
    public class Ball : Toy
    {
        public SolidBrush BallBrush { get; private set; }

        public Ball(Color kivalasztottszin)
        {
            BallBrush = new SolidBrush(kivalasztottszin);
        }

        protected override void DrawImage(Graphics g)
        {
            g.FillEllipse(BallBrush, 0, 0, Width, Height);
        }
    }
}
