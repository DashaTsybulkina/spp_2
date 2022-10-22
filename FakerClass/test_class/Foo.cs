using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerClass.test_class
{
    public class Foo
    {

        public string sdf;
        public char testChar;
        public int AAA = 123;

        public int a, b;
        public string TestStr = "It's const str";

        public Foo(int a)
        {
            this.a = a;
        }

        public Foo(int a, int b)
        {
            this.a = a;
            this.b = b;
        }


        public Foo()
        {

        }

    }
}
