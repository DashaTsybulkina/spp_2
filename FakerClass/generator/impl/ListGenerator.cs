using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerClass.generator.impl
{
    internal class ListGenerator<T>:IGenerator
    {
        public object Generate()
        {
            Random random = new Random();
            var size = random.Next(1, 50);
            var type = typeof(T);
            var list = new List<T>();
            var faker = new Faker();
            for (int i = 0; i < size; i++)
            {
                list.Add((T)faker.createByType(typeof(T)));
            }

            return list;
        }

        public Type GetGenType()
        {
            return typeof(List<T>);
        }
    }
}
