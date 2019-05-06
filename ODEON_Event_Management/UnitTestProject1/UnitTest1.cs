using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApplicationLayer;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestInharetedSingleton()
        {
            KategoriRepository Repository = KategoriRepository.Instance;
            Repository = new KategoriRepository();
        }
    }
}
