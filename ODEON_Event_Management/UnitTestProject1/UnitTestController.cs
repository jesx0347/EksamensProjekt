﻿using System;
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
            Salrepo.AddItem(sale);

            int IDEvent = OErepo.GetItem(1).ID;
            string SalNavn = "Store Sal";

            control.IndskrivSal(IDEvent, SalNavn);

            Assert.AreEqual("Store Sal", Salrepo.GetItem(1).Navn);
        }

        //[TestMethod]
        //public void TestIndskrivKategori()
        //{
        //    List<Kategori> kats = new List<Kategori>();
        //    kats.Add(new Kategori(""))

        //}
    }
}
