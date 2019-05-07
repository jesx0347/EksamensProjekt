using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApplicationLayer;
using DomainLayer;

namespace UnitTestProject1
{

    [TestClass]
    public class UnitTest2
    {
        Sal s1, s2;

        SalRepository repo;

        [TestInitialize]
        public void Init()
        {
            repo = SalRepository.Instance;

            s1 = new Sal("Store Sal", 1, (decimal)50000.00, 1740);
            s2 = new Sal("Sidescenen", 2, (decimal)37500.00, 600);
            SalRepository.Instance.AddItem(s1);
            SalRepository.Instance.AddItem(s2);
        }

        [TestMethod]
        public void TestSalConstructor()
        {
            Assert.AreEqual("Store Sal", s1.Navn);
        }

        [TestMethod]
        public void TestSetProperties()
        {
            s1.Navn = "Store Sal";
            s1.ID = 1;
            s1.Leje = (decimal)50000.00;
            s1.Kapacitet = 1740;

            Assert.AreEqual("Store Sal", s1.Navn);
            //Assert.AreEqual("Navn: Store Sal, ID: 1, Leje: 50000.00, Kapacitet: 1740", s1.ToString());
        }
    }
}
