using Programtervezési_minták_2.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programtervezési_minták_2.Entities
{
    class CarFactory : Label, IToyFactory
    {
        public Toy CreateNew()
        {
            return new Car();
        }
    }
}
