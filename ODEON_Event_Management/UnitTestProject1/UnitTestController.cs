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
        GodtGørelsesRepository GGRepo;

        List<DateTime> dates = new List<DateTime>();
        string name = "Nyt Event";
        //int IDEvent;

        [TestInitialize]
        public void Init()
        {
            OErepo = new ODEONEventRepository();
            Salrepo = new SalRepository();
            Katrepo = new KategoriRepository();
            GGRepo = new GodtGørelsesRepository();
            control = new Controller(Salrepo, Katrepo, OErepo, GGRepo);

            dates.Add(new DateTime(2019, 5, 8));
            dates.Add(new DateTime(2019, 5, 28));
            dates.Add(new DateTime(2019, 6, 15));
            dates.Add(new DateTime(2019, 6, 20));

            //int IDEvent = control.IndskrivNavnOgDato(name, dates);
        }

        [TestMethod]
        public void TestIndskrivNavnOgDato()
        {
            int IDEvent = control.IndskrivNavnOgDato(name, dates);

            Assert.AreEqual("Nyt Event", OErepo.GetItem(IDEvent).Navn);
            for (int i = 0; i < dates.Count; i++)
            {
                Assert.AreEqual(dates[i], OErepo.GetItem(IDEvent).Afviklinger[i].Dato);
            }
        }

        [TestMethod]
        public void TestVælgSal()
        {
            //List<ODEONEvent> events = new List<ODEONEvent>();
            //events.Add(new ODEONEvent("Nytårsfest", 1));

            //List<Sal> sale = new List<Sal>();
            //sale.Add(new Sal("Store Sal", 1, (decimal)50000.00, 1740));
            int IDEvent = control.IndskrivNavnOgDato(name, dates);

            Salrepo.AddItem(new Sal("Store Sal", 1, (decimal)50000.00, 1740));

            string SalNavn = Salrepo.GetItem("Store Sal").ToString();

            control.VælgSal(IDEvent, SalNavn);

            for (int i = 0; i < dates.Count; i++)
            {
                Assert.AreEqual("Store Sal", OErepo.GetItem(IDEvent).Afviklinger[i].Sal.ToString());
            }
        }

        [TestMethod]
        public void TestVælgKategori()
        {
            int IDEvent = control.IndskrivNavnOgDato(name, dates);

            Katrepo.AddItem(new Kategori("Rock", 1));
            Katrepo.AddItem(new Kategori("Gastronomi", 2));
            Katrepo.AddItem(new Kategori("Jazz", 3));

            List<string> kats = new List<string>();
            kats.Add("Rock");
            kats.Add("Gastronomi");
            kats.Add("Jazz");

            control.VælgKategori(IDEvent, kats);

            for (int i = 0; i < kats.Count; i++)
            {
                Assert.AreEqual(kats[i], OErepo.GetItem(IDEvent).Kategorier[i].Navn);
            }

        }

        [TestMethod]
        public void TestIndskrivOmkostninger()
        {
            int IDEvent = control.IndskrivNavnOgDato(name, dates);

            control.IndskrivOmkostninger(IDEvent, (decimal)3400.00, 10, (decimal)3000.00, 70);

            Assert.AreEqual((decimal)3400.00, OErepo.GetItem(IDEvent).Omkostninger.MarkedsFøring);
            Assert.AreEqual(10, OErepo.GetItem(IDEvent).Omkostninger.KODA);
            Assert.AreEqual((decimal)3000.00, OErepo.GetItem(IDEvent).Omkostninger.Garantisum);
            Assert.AreEqual(70, OErepo.GetItem(IDEvent).Omkostninger.ArtistSplit);
        }

        [TestMethod]
        public void TestIndskrivVariable()
        {
            int IDEvent = control.IndskrivNavnOgDato(name, dates);

            control.IndskrivOmkostninger(IDEvent, (decimal)3400.00, 10, (decimal)3000.00, 70);

            control.IndskrivVariable(IDEvent, (decimal)340.00, (decimal)300, "Extra lys: 340kr", "Dækning af lyst: 300kr");

            Assert.AreEqual((decimal)340.00, OErepo.GetItem(IDEvent).Omkostninger.VariableOmkostninger);
        }

        [TestMethod]
        public void TestIndskrivBilletTyper()
        {
            int IDEvent = control.IndskrivNavnOgDato(name, dates);

            List<Tuple<int, decimal>> type = new List<Tuple<int, decimal>>();
            type.Add(new Tuple<int, decimal>(500, (decimal)200));

            control.IndskrivBilletTyper(IDEvent, type);

            for (int i = 0; i < type.Count; i++)
            {
                Assert.AreEqual(type[i].Item1, OErepo.GetItem(IDEvent).Afviklinger[i].BilletTyper[i].Udbud);
                Assert.AreEqual(type[i].Item2, OErepo.GetItem(IDEvent).Afviklinger[i].BilletTyper[i].Pris);

            }
        }
        [TestMethod]
        public void TestEmbededResource()
        {
            string test = control.DBC.ToString();
            Assert.AreEqual(" Server=EALSQL1.eal.local; Database=B_DB13_2018; User Id=B_STUDENT13; Password=B_OPENDB13;", test);
        }
    }
}
