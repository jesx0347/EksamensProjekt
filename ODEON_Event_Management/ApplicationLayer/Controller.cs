using DomainLayer;
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

        private readonly SalRepository SalRepo;
        private readonly KategoriRepository KatRepo;
        private readonly ODEONEventRepository OERepo;

        public Controller()
        {
            SalRepo = new SalRepository();
            KatRepo = new KategoriRepository();
            OERepo = new ODEONEventRepository();

            DataBase = new DataBaseController(SalRepo, KatRepo, OERepo);
        }

        public Controller(SalRepository SR, KategoriRepository KR, ODEONEventRepository OER)
        {
            SalRepo = SR;
            KatRepo = KR;
            OERepo = OER;
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
            foreach (DateTime item in dates)
            {
                Making.Afviklinger.Add(new Afvikling(item));
            }
            OERepo.AddItem(Making);
            return Making.ID;
        }

        public void IndskrivSal(int IDEvent, string SalNavn)
        {
            ODEONEvent ODEON = OERepo.GetItem(IDEvent);
            Sal sal = SalRepo.GetSal(SalNavn);
            foreach (Afvikling item in ODEON.Afviklinger)
            {
                item.Sal = sal;
            }
        }

        public void IndskrivKategori(int IDEvent, IEnumerable<string> Kats)
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
    }
}
