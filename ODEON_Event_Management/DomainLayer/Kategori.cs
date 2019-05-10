using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class Kategori : IHaveID
    {
        public int ID { get; set; }
        public string Navn;

        public Kategori(string navn, int id)
        {
            Navn = navn;
            ID = id;
        }

        public Kategori()
        {
        }

        public override string ToString()
        {
            return Navn;
        }
    }
}
