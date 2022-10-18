using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerClass.generator.impl
{
    public class IntGenerator:IGenerator
    {
        public object Generate()
        {
            Random random = new Random();
            return random.Next(int.MinValue, int.MaxValue);
        }

        public Type GetGenType()
        {
            return typeof(int);
        }
    }
}
