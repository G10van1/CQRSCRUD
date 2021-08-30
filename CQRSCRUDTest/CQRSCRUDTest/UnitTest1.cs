using NUnit.Framework;

namespace CQRSCRUDTest
{
    public class Tests
    {
        string baseUrl;
        string reg;
        string razaoSocial;
        string cnpj;
        string data;

        [SetUp]
        public void Setup()
        {
            baseUrl = "https://localhost:5001/";
            reg = "1";
            razaoSocial = "Google";
            cnpj = "01.001.001/0001-01";
            data = "28/08/2021";
        }

        [Test]
        public void Test1()
        {
            Assert.AreEqual(10 + 20, 30);
        }

        [Test]
        public void Test2()
        {
            Assert.AreNotEqual(10 + 20, 20);
        }
    }
}