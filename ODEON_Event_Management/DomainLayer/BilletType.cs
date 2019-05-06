using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class BilletType
    {
        public int Udbud;
        public decimal Pris;
        public List<SalgsTal> SamledeSalgsTal = new List<SalgsTal>();
    }
}
