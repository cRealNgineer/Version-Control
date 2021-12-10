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
        Toy _nextToy;
        private IToyFactory toyFactory;

        public IToyFactory Factory
        {
            get { return toyFactory; }
            set { 
                toyFactory = value;
                DisplayNext();
                }
        }

        private void DisplayNext()
        {
            if (_nextToy != null)
            {
                Controls.Remove(_nextToy);
            }

            _nextToy = Factory.CreateNew();
            _nextToy.Top = label1.Top + label1.Height + 20;
            _nextToy.Left = label1.Left;
            Controls.Add(_nextToy);
        }

        public Form1()
        {
            InitializeComponent();
            Factory = new BallFactory();
        }

        private void createTimer_Tick(object sender, EventArgs e)
        {
            Toy b = Factory.CreateNew();
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

            foreach (Toy item in _toys)
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

        private void btn_Car_Click(object sender, EventArgs e)
        {
            Factory = new CarFactory();
        }

        private void btn_Ball_Click(object sender, EventArgs e)
        {
            Factory = new BallFactory() {BallColor = btn_BallColor.BackColor};
        }

        private void btn_BallColor_Click(object sender, EventArgs e)
        {
            Button kattintott = (Button)sender;
            ColorDialog cd = new ColorDialog();
            cd.Color = kattintott.BackColor;

            if (cd.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            kattintott.BackColor = cd.Color;
        }
    }
}
