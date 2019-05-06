﻿using DomainLayer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer
{
    public class Controller
    {
        public static Controller Instance { get; }
        static Controller()
        {
            Instance = new Controller();
        }
        private Controller() { }

        public IEnumerable<string> GetSalNavne()
        {
            List<string> result = new List<string>();
            IEnumerator enumerator = SalRepository.Instance.GetEnumerator();
            while (enumerator.MoveNext())
            {
                result.Add(enumerator.Current.ToString());
            }
            return result;
        }

        public IEnumerable<string> GetKategoriNavne()
        {
            List<string> result = new List<string>();
            IEnumerator enumerator = KategoriRepository.Instance.GetEnumerator();
            while (enumerator.MoveNext())
            {
                result.Add(enumerator.Current.ToString());
            }
            return result;
        }

        public int IndskrivNavnOgDato(string name, IEnumerable<DateTime> dates)
        {
            ODEONEvent Making = new ODEONEvent(name);
            foreach (DateTime item in dates)
            {
                Making.Afviklinger.Add(new Afvikling(item));
            }
            return Making.ID;
        }

        public void IndskrivSal(int IDEvent, string SalNavn)
        {
            ODEONEvent ODEON = ODEONEventRepository.Instance.GetItem(IDEvent);
            Sal sal = SalRepository.Instance.GetSal(SalNavn);
            foreach (Afvikling item in ODEON.Afviklinger)
            {
                item.Sal = sal;
            }
        }

        public void IndskrivKategori(int IDEvent, IEnumerable<string> Kats)
        {
            ODEONEvent ODEON = ODEONEventRepository.Instance.GetItem(IDEvent);
            foreach (string item in Kats)
            {
                Kategori kategori = KategoriRepository.Instance.GetKategori(item);
                ODEON.Kategorier.Add(kategori);
            }
        }

        public void IndskrivOmkostninger(int IDEvent, decimal marked, double KODA, decimal garantiSum, double split)
        {
            Omkostninger omkostninger = new Omkostninger();
            omkostninger.MarkedsFøring = marked;
            omkostninger.KODA = KODA;
            omkostninger.Garantisum = garantiSum;
            omkostninger.ArtistSplit = split;
            ODEONEventRepository.Instance.GetItem(IDEvent).Omkostninger = omkostninger;
        }

        public void IndskrivVariable(int IDEvent, decimal Omkost, decimal Indtægt, string omkostNoter, string indtægtNoter)
        {
            ODEONEvent ODEON = ODEONEventRepository.Instance.GetItem(IDEvent);
            ODEON.Omkostninger.VariableOmkostninger = Omkost;
            ODEON.Omkostninger.Note = omkostNoter;
            VariableIndtjening indtjening = new VariableIndtjening();
            indtjening.Beløb = Indtægt;
            indtjening.Note = indtægtNoter;
            ODEON.VariableIndtjening = indtjening;
        }

        public void IndskrivBilletTyper(int IDEvent, IEnumerable<Tuple<int, decimal>> typer)
        {
            IEnumerable<Afvikling> afviklings = ODEONEventRepository.Instance.GetItem(IDEvent).Afviklinger;
            foreach (Tuple<int, decimal> tuple in typer)
            {
                foreach (Afvikling afvikling in afviklings)
                {
                    afvikling.BilletTyper.Add(new BilletType(tuple.Item1, tuple.Item2));
                }
            }
        }
    }
}
