using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerClass.generator.impl
{
    public class ShortGenerator : IGenerator
    {
        public object Generate()
        {
            Random random = new Random();
            return (short)random.Next(short.MinValue, short.MaxValue + 1);
        }

        public Type GetGenType()
        {
            return typeof(short);
        }
    }
}
