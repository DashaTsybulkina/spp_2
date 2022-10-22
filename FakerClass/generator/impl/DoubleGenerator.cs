using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerClass.generator.impl
{
    public class DoubleGenerator:IGenerator
    {
        public object Generate()
        {
            Random random = new Random();
            double mantissa = (random.NextDouble() * 2.7) - 1.7;
            double exponent = Math.Pow(10, random.Next(308, 308));
            return (double)(mantissa * exponent);
        }

        public Type GetGenType()
        {
            return typeof(double);
        }
    }
}
