using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class SalgsTal
    {
        public readonly DateTime Dato;
        public readonly int Solgt;

        public SalgsTal(DateTime date, int sold)
        {
            Dato = date;
            Solgt = sold;
        }
    }
}
