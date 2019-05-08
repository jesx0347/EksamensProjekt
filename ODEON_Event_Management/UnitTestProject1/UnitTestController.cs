using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApplicationLayer;
using DomainLayer;

namespace UnitTestProject1
{

    [TestClass]
    public class UnitTestController
    {
        ODEONEventRepository OErepo;
        SalRepository Salrepo;
        KategoriRepository Katrepo;
        Controller control;

        [TestInitialize]
        public void Init()
        {
            OErepo = new ODEONEventRepository();
            Salrepo = new SalRepository();
            Katrepo = new KategoriRepository();
            control = new Controller(Salrepo, Katrepo, OErepo);
        }

        //string name, IEnumerable<DateTime> dates

        [TestMethod]
        public void TestIndskrivNavnOgDato()
        {
            List<DateTime> dates = new List<DateTime>();
            dates.Add(new DateTime(2019, 5, 8));
            dates.Add(new DateTime(2019, 5, 28));
            dates.Add(new DateTime(2019, 6, 15));
            dates.Add(new DateTime(2019, 6, 20));

            string name = "Nyt Event";
            control.IndskrivNavnOgDato(name, dates);

            Assert.AreEqual("Nyt Event", OErepo.GetItem(1).Navn);
            for (int i = 0; i < dates.Count; i++)
            {
                Assert.AreEqual(dates[i], OErepo.GetItem(1).Afviklinger[i].Dato);
            }
        }
 
    }
}
