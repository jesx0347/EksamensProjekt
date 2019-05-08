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
            repo = new SalRepository();

            s1 = new Sal("Store Sal", 1, (decimal)50000.00, 1740);
            s2 = new Sal("Sidescenen", 2, (decimal)37500.00, 600);
            repo.AddItem(s1);
            repo.AddItem(s2);
        }

        [TestMethod]
        public void TestSalConstructor1()
        {
            Assert.AreEqual("Store Sal", s1.Navn);
            Assert.AreEqual(1, s1.ID);
            Assert.AreEqual((decimal)50000.00, s1.Leje);
            Assert.AreEqual(1740, s1.Kapacitet);

            Assert.AreEqual("Sidescenen", s2.Navn);
            Assert.AreEqual(2, s2.ID);
            Assert.AreEqual((decimal)37500.00, s2.Leje);
            Assert.AreEqual(600, s2.Kapacitet);
        }

        [TestMethod]
        public void TestSalConstructor2()
        {
            Assert.AreNotEqual("Store Sal", s2.Navn);
            Assert.AreNotEqual(1, s2.ID);
            Assert.AreNotEqual((decimal)50000.00, s2.Leje);
            Assert.AreNotEqual(1740, s2.Kapacitet);

            Assert.AreNotEqual("Sidescene", s1.Navn);
            Assert.AreNotEqual(2, s1.ID);
            Assert.AreNotEqual((decimal)37500.00, s1.Leje);
            Assert.AreNotEqual(600, s1.Kapacitet);
        }

        [TestMethod]
        public void TestSetProperties()
        {
            s1.Navn = "Extrascene";
            s1.ID = 3;
            s1.Leje = (decimal)45500.00;
            s1.Kapacitet = 700;

            Assert.AreEqual("Extrascene", s1.Navn);
            //Assert.AreEqual("Navn: Store Sal, ID: 1, Leje: 50000.00, Kapacitet: 1740", s1.ToString());
        }
    }
}
