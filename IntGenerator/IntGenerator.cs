using FakerClass.generator;

namespace IntGenerator
{
    public class IntGenerator : IGenerator
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