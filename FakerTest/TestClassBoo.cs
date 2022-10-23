using FakerClass.test_class;
using FakerClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerTest
{
    [TestClass]
    internal class TestClassBoo
    {
        private readonly Faker _faker = new Faker();

        [TestMethod]
        public void TestClassBooConstructor()
        {
            var boo = _faker.create<Boo>();
            Console.WriteLine(boo);
            Assert.IsNotNull(boo);
        }

        [TestMethod]
        public void TestClassDataTimeFiledConstructor()
        {
            var boo = _faker.create<Boo>();
            Assert.IsTrue(boo.testDateTime.Equals(null));
        }

        [TestMethod]
        public void TestClassIntArray()
        {
            var boo = _faker.create<Boo>();
            Assert.IsNotNull(boo.IntArray);
        }

        [TestMethod]
        public void TestClassFloatProperty()
        {
            var boo = _faker.create<Boo>();
            Assert.IsTrue(boo.testFloat != 0.0);
        }

        [TestMethod]
        public void TestClassPrivateIntFlied()
        {
            var boo = _faker.create<Boo>();
            Assert.IsTrue(boo.getTestInteger() == 0);
        }
    }
}
