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
        private DataBaseController DataBase;
        public DataBaseController DBC { get => DataBase; }
        private static Controller _singleton;
        public static Controller Singleton
        {
            get
            {
                if (_singleton == null)
                {
                    _singleton = new Controller();
                }
                return _singleton;
            }
        } 

        private readonly SalRepository SalRepo;
        private readonly KategoriRepository KatRepo;
        private readonly ODEONEventRepository OERepo;
        private readonly GodtGørelsesRepository GGRepo;

        //public UnderskudsGodtgørelse Godtgørelse { get; set; }
        //static Controller()
        //{
        //    _singleton = new Controller();
        //}
        private Controller()
        {
            SalRepo = new SalRepository();
            KatRepo = new KategoriRepository();
            OERepo = new ODEONEventRepository();
            GGRepo = new GodtGørelsesRepository();

            DataBase = new DataBaseController(SalRepo, KatRepo, OERepo, GGRepo);

            DataBase.StartUp();
        }

        public Controller(SalRepository SR, KategoriRepository KR, ODEONEventRepository OER, GodtGørelsesRepository GGR)
        {
            SalRepo = SR;
            KatRepo = KR;
            OERepo = OER;
            GGRepo = GGR;

            DataBase = new DataBaseController(SalRepo, KatRepo, OERepo, GGRepo);

            //_singleton = this;
        }

        public IEnumerable<Tuple<int, string>> GetEventListing()
        {
            List<Tuple<int, string>> result = new List<Tuple<int, string>>();
            foreach (ODEONEvent item in OERepo)
            {
                Tuple<int, string> tuple = new Tuple<int, string>(item.ID, item.Navn);
                result.Add(tuple);
            }
            return result;
        }

        public IEnumerable<string> GetSalNavne()
        {
            List<string> result = new List<string>();
            IEnumerator enumerator = SalRepo.GetEnumerator();
            while (enumerator.MoveNext())
            {
                result.Add(enumerator.Current.ToString());
            }
            return result;
        }

        public IEnumerable<string> GetKategoriNavne()
        {
            List<string> result = new List<string>();
            IEnumerator enumerator = KatRepo.GetEnumerator();
            while (enumerator.MoveNext())
            {
                result.Add(enumerator.Current.ToString());
            }
            return result;
        }

        public int IndskrivNavnOgDato(string name, IEnumerable<DateTime> dates)
        {
            ODEONEvent Making = new ODEONEvent(name);
            DateTime lastDate = new DateTime();
            foreach (DateTime item in dates)
            {
                Making.Afviklinger.Add(new Afvikling(item));
                lastDate = item;
            }
            foreach (UnderskudsGodtgørelse godtgørelse in GGRepo)
            {
                if (lastDate.CompareTo(godtgørelse.UdløbsDato) < 1)
                {
                    Making.Godtgørelse = godtgørelse;
                    break;
                }
            }
            OERepo.AddItem(Making);
            return Making.ID;
        }

        public void VælgSal(int IDEvent, string SalNavn)
        {
            ODEONEvent ODEON = OERepo.GetItem(IDEvent);
            Sal sal = SalRepo.GetItem(SalNavn);
            foreach (Afvikling item in ODEON.Afviklinger)
            {
                item.Sal = sal;
            }
        }

        public void VælgKategori(int IDEvent, IEnumerable<string> Kats)
        {
            ODEONEvent ODEON = OERepo.GetItem(IDEvent);
            foreach (string item in Kats)
            {
                Kategori kategori = KatRepo.GetKategori(item);
                ODEON.Kategorier.Add(kategori);
            }
        }

        public void IndskrivOmkostninger(int IDEvent, decimal marked, double KODA, decimal garantiSum, double split)
        {
            Omkostninger omkostninger = new Omkostninger(marked, KODA, garantiSum, split);
            OERepo.GetItem(IDEvent).Omkostninger = omkostninger;
        }

        public void IndskrivVariable(int IDEvent, decimal Omkost, decimal Indtægt, string omkostNoter, string indtægtNoter)
        {
            ODEONEvent ODEON = OERepo.GetItem(IDEvent);
            ODEON.Omkostninger.VariableOmkostninger = Omkost;
            ODEON.Omkostninger.Note = omkostNoter;
            VariableIndtægter indtjening = new VariableIndtægter();
            indtjening.Beløb = Indtægt;
            indtjening.Note = indtægtNoter;
            ODEON.VariableIndtjening = indtjening;
        }

        public void IndskrivBilletTyper(int IDEvent, IEnumerable<Tuple<int, decimal>> typer)
        {
            IEnumerable<Afvikling> afviklings = OERepo.GetItem(IDEvent).Afviklinger;
            foreach (Tuple<int, decimal> tuple in typer)
            {
                foreach (Afvikling afvikling in afviklings)
                {
                    afvikling.BilletTyper.Add(new BilletType(tuple.Item1, tuple.Item2));
                }
            }
        }

        public void UploadEvent(int ID)
        {
            DataBase.UploadEvent(OERepo.GetItem(ID));
        }

        private Tuple<decimal, decimal> GetBreakEven(ODEONEvent OE)
        {
            return new Tuple<decimal, decimal> (OE.BreakEven, OE.Sales);
        }

        public Tuple<decimal, decimal> GetBreakEven(int ID)
        {
            ODEONEvent OE = OERepo.GetItem(ID);
            return GetBreakEven(OE);
        }

        public Tuple<decimal, decimal> GetBreakEven(string Navn)
        {
            return GetBreakEven(OERepo.GetItem(Navn));
        }

        private IEnumerable<Tuple<DateTime, decimal>> GetBilleter(ODEONEvent OE)
        {
            List<Tuple<DateTime, decimal>> result = new List<Tuple<DateTime, decimal>>();
            foreach (Afvikling afvik in OE.Afviklinger)
            {
                foreach (BilletType billet in afvik.BilletTyper)
                {
                    result.Add(new Tuple<DateTime, decimal>(afvik.Dato, billet.Pris));
                }
            }
            return result;
        }

        public IEnumerable<Tuple<DateTime, decimal>> GetBilleter(string navn)
        {
            return GetBilleter(OERepo.GetItem(navn));
        }

        public IEnumerable<Tuple<DateTime, decimal>> GetBilleter(int ID)
        {
            return GetBilleter(OERepo.GetItem(ID));
        }

        private bool IsEventFullyLoaded(ODEONEvent OE)
        {
            if (OE.Omkostninger == null)
            {
                DataBase.DownloadHeleEvent(OE);
            }
            return true;
        }

        public bool IsEventFullyLoaded(int ID)
        {
            return IsEventFullyLoaded(OERepo.GetItem(ID));
        }

        public bool IsEventFullyLoaded(string Navn)
        {
            return IsEventFullyLoaded(OERepo.GetItem(Navn));
        }

        //public IDisposable SubcribeToEventRepo(IObserver<Tuple<int, string>> observer)
        //{
        //    return OERepo.Subscribe(observer);
        //}
    }
}
