using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerClass.generator.impl
{
    public class LongGenerator:IGenerator
    {
        public object Generate()
        {
            Random random = new Random();
            long result = unchecked((long)(random.NextDouble() * ulong.MaxValue));
            return result;
        }

        public Type GetGenType()
        {
            return typeof(int);
        }
    }
}
