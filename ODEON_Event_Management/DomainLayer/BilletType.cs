using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class BilletType
    {
        public int ID;
        public int Udbud;
        public decimal Pris;
        public List<SalgsTal> SamledeSalgsTal = new List<SalgsTal>();
        public int TotalSold
        {
            get
            {
                int result = 0;
                foreach (SalgsTal item in SamledeSalgsTal)
                {
                    result += item.Solgt;
                }
                return result;
            }
        }
        public BilletType(int udbud, decimal pris)
        {
            Udbud = udbud;
            Pris = pris;
        }
    }
}
