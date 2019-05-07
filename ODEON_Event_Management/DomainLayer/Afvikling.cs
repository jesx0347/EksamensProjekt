using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class Afvikling
    {
        public int ID;
        public DateTime Dato;
        public Sal Sal;
        public List<BilletType> BilletTyper = new List<BilletType>();

        public Afvikling(DateTime date)
        {
            Dato = date;
        }
    }
}
