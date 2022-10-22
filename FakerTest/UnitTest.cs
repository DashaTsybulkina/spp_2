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


    }
}