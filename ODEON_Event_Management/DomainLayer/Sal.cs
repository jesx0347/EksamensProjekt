using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class Sal : IHaveID
    {
        public string Navn { get; set; }
        public int ID { get; set; }
        public decimal Leje { get; set; }
        public int Kapacitet { get; set; }
        public Sal(string name, int id, decimal cost, int capaceti)
        {
            Navn = name;
            ID = id;
            Leje = cost;
            Kapacitet = capaceti;
        }
        public override string ToString()
        {
            return Navn;
        }
    }
}
