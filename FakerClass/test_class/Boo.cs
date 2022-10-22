using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerClass.test_class
{
    public class Boo
    {
        public float testFloat { get; set; }
        public int testInt { get; set; }
        public DateTime testDateTime { get; set; }

        private int testInteger;

        public Boo(DateTime a, int c)
        {
            this.testDateTime = a;
            this.testInteger = c;
        }

    }

}
