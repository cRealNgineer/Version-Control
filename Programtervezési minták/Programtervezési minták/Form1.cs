using Programtervezési_minták.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programtervezési_minták
{
    public partial class Form1 : Form
    {
        List<Balls> _balls = new List<Balls>();
        private BallFactory ballFactory;

        public BallFactory Factory
        {
            get { return ballFactory; }
            set { ballFactory = value; }
        }

        public Form1()
        {
            InitializeComponent();
            Factory = new BallFactory();
        }

        private void createTimer_Tick(object sender, EventArgs e)
        {
            Balls b = Factory.CreateNew();
            _balls.Add(b);
            b.Left = -b.Width;
            mainPanel.Controls.Add(b);
        }

        private void conveyorTimer_Tick(object sender, EventArgs e)
        {
            foreach (Balls item in _balls)
            {
                item.MoveBall();
            }
        }
    }
}
