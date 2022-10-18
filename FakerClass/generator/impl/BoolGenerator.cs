using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerClass.generator.impl
{
    public class BoolGenerator:IGenerator
    {
        public object Generate()
        {
            Random random = new Random();
            return Convert.ToBoolean(random.Next(0, 1));
        }

        public Type GetGenType()
        {
            return typeof(bool);
        }
    }
}
