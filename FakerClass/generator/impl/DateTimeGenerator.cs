using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerClass.generator.impl
{
    public class DateTimeGenerator : IGenerator
    {
        public object Generate()
        {
            Random random = new Random();
            var year = random.Next(1, 1999);
            var month = random.Next(1, 12);
            var day = random.Next(1, DateTime.DaysInMonth(year, month));

            return new DateTime(year, month, day);
        }

        public Type GetGenType()
        {
            return typeof(DateTime);
        }
    }
}
