using Programtervezési_minták_2.Abstractions;
using Programtervezési_minták_2.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programtervezési_minták_2
{
    public partial class Form1 : Form
    {
        List<Toy> _toys = new List<Toy>();
        private BallFactory myV_factoryar;

        public BallFactory Factory
        {
            get { return myV_factoryar; }
            set { myV_factoryar = value; }
        }

        public Form1()
        {
            InitializeComponent();
            Factory = new BallFactory();
        }

        private void createTimer_Tick(object sender, EventArgs e)
        {
            Ball b = Factory.CreateNew();
            _toys.Add(b);
            b.Left = -b.Width;
            mainPanel.Controls.Add(b);
        }

        private void conveyorTimer_Tick(object sender, EventArgs e)
        {
            if (_toys.Count == 0)
            {
                return;
            }

            Toy lastToy = _toys[0];

            foreach (Ball item in _toys)
            {
                item.MoveToy();
                if (item.Left > lastToy.Left)
                {
                    lastToy = item;
                }
            }

            if (lastToy.Left > 1000)
            {
                _toys.Remove(lastToy);
                mainPanel.Controls.Remove(lastToy);
            }
        }
    }
}
