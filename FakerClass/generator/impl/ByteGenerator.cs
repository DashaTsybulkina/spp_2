using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerClass.generator.impl
{
    public class ByteGenerator : IGenerator
    {
        public object Generate()
        {
            Random random = new Random();
            var result = new byte[1];
            random.NextBytes(result);
            return result[0];
        }

        public Type GetGenType()
        {
            return typeof(byte);
        }
    }
}
