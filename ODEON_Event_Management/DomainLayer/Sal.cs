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
        public int ID => throw new NotImplementedException();
        public override string ToString()
        {
            return Navn;
        }
    }
}
