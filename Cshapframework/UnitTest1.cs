using NUnit.Framework;

namespace Csharpframework
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
        [TearDown]
        public void quit()
        {

        } 
    }
}