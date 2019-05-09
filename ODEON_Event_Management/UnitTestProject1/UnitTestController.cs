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

        [TestMethod]
        public void TestIndskrivSal()
        {
            List<DateTime> dates = new List<DateTime>();
            dates.Add(new DateTime(2019, 5, 8));
            dates.Add(new DateTime(2019, 5, 28));
            dates.Add(new DateTime(2019, 6, 15));
            dates.Add(new DateTime(2019, 6, 20));

            string name = "Nyt Event";
            control.IndskrivNavnOgDato(name, dates);

            //List<ODEONEvent> events = new List<ODEONEvent>();
            //events.Add(new ODEONEvent("Nytårsfest", 1));

            List<Sal> sale = new List<Sal>();
            sale.Add(new Sal("Store Sal", 1, (decimal)50000.00, 1740));
            //Salrepo.AddItem(sale);

            int IDEvent = OErepo.GetItem(1).ID;
            string SalNavn = "Store Sal";

            control.IndskrivSal(IDEvent, SalNavn);

            for (int i = 0; i < dates.Count; i++)
            {
                Assert.AreEqual("Store Sal", OErepo.GetItem(1).Afviklinger[i].Sal);
            }

            //Assert.AreEqual("store Sal", OErepo.GetItem(1).Afviklinger);
            //Assert.AreEqual(OErepo.GetItem(1).Navn, "Ny Event");
        }

        //[TestMethod]
        //public void TestIndskrivKategori()
        //{
        //    List<Kategori> kats = new List<Kategori>();
        //    kats.Add(new Kategori(""))

        //}

        [TestMethod]
        public void TestIndskrivOmkostninger()
        {
            //int IDEvent, decimal marked, double KODA, decimal garantiSum, double split
            List<DateTime> dates = new List<DateTime>();
            dates.Add(new DateTime(2019, 5, 8));
            dates.Add(new DateTime(2019, 5, 28));
            dates.Add(new DateTime(2019, 6, 15));
            dates.Add(new DateTime(2019, 6, 20));

            string name = "Nyt Event";
            control.IndskrivNavnOgDato(name, dates);

            int IDEvent = OErepo.GetItem(1).ID;

            control.IndskrivOmkostninger(IDEvent, (decimal)3400.00, 10, (decimal)3000.00, 70);

            Assert.AreEqual((decimal)3400.00, OErepo.GetItem(1).Omkostninger.MarkedsFøring);
            Assert.AreEqual(10, OErepo.GetItem(1).Omkostninger.KODA);
            Assert.AreEqual((decimal)3000.00, OErepo.GetItem(1).Omkostninger.Garantisum);
            Assert.AreEqual(70, OErepo.GetItem(1).Omkostninger.ArtistSplit);
        }
    }
}
