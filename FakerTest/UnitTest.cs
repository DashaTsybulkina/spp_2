using FakerClass;
using FakerClass.test_class;

namespace FakerTest
{
    [TestClass]
    public class UnitTest
    {
        private readonly Faker faker = new Faker();

        [TestMethod]
        public void TestClassFoo()
        {
            var foo = faker.create<Foo>();
            Assert.IsNotNull(foo);
        }

        [TestMethod]
        public void TestClassFooConstructor()
        {
            var foo = faker.create<Foo>();
            Assert.IsTrue(foo.a != 0);
            Assert.IsTrue(foo.b != 0);
        }

        [TestMethod]
        public void TestClassBoo()
        {
            var foo = faker.create<Foo>();
            Assert.IsNotNull(foo.testBoo);
        }

        [TestMethod]
        public void TestClassFloatProperty()
        {
            var foo = faker.create<Foo>();
            Assert.IsTrue(foo.testBoo.testFloat != 0);
        }

        [TestMethod]
        public void TestClassBooConstructor()
        {
            var boo = faker.create<Boo>();
            Console.WriteLine(boo);
            Assert.IsNotNull(boo);
        }

        [TestMethod]
        public void TestClassDataTimeFiledConstructor()
        {
            var boo = faker.create<Boo>();
            Assert.IsTrue(!boo.testDateTime.Equals(null));
        }

        [TestMethod]
        public void TestClassIntArray()
        {
            var boo = faker.create<Boo>();
            Assert.IsNotNull(boo.IntArray);
        }

        [TestMethod]
        public void TestClassPrivateIntFlied()
        {
            var boo = faker.create<Boo>();
            Assert.IsTrue(boo.getTestInteger() == 0);
        }

    }
}