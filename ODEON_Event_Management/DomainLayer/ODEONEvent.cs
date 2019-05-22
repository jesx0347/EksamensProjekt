using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class ODEONEvent : IHaveID
    {
        private static int _GetNextID = 0;
        private static int GetNextID
        {
            get
            {
                _GetNextID++;
                return _GetNextID;
            }
        }

        public string Navn;
        public int ID { get; }
        public Omkostninger Omkostninger;
        public VariableIndtægter VariableIndtjening;
        public List<Afvikling> Afviklinger = new List<Afvikling>();
        public List<Kategori> Kategorier = new List<Kategori>();
        public UnderskudsGodtgørelse Godtgørelse;
        public decimal BreakEven
        {
            get
            {
                decimal result = 0;
                result += Omkostninger.MarkedsFøring;
                result += Omkostninger.Garantisum;
                //result += Omkostninger.KODA;
                result += Omkostninger.VariableOmkostninger;
                result -= VariableIndtjening.Beløb;
                foreach (Afvikling afvikling in Afviklinger)
                {
                    result += afvikling.Sal.Leje;
                }
                return result;
            }
        }
        public decimal Sales 
        {
            get 
            {
                decimal result = 0;
                foreach (Afvikling item in Afviklinger)
                {
                    foreach (BilletType billet in item.BilletTyper)
                    {
                        result += billet.Pris * billet.TotalSold;
                    }
                }
                return result;
            }
        }

        public ODEONEvent(string name, int ID)
        {
            Navn = name;
            if (ID > _GetNextID)
            {
                _GetNextID = ID;
            }
            this.ID = ID;
        }
        public ODEONEvent(string name) : this(name, GetNextID) { }
    }
}
