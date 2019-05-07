using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class ODEONEvent : IHaveID
    {
        private static int _GetNextID;
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
        public VariableIndtjening VariableIndtjening;
        public List<Afvikling> Afviklinger = new List<Afvikling>();
        public List<Kategori> Kategorier = new List<Kategori>();
        public UnderskudsGodtgørelse Godtgørelse;
        public decimal BreakEven
        {
            get
            {
                throw new NotImplementedException();
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
