using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class ODEONEvent : IHaveID
    {
        public int ID { get; }
        public Omkostninger Omkostninger;
        public List<Afvikling> Afviklinger = new List<Afvikling>();
        public List<Kategori> Kategorier = new List<Kategori>();
        public decimal BreakEven
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
