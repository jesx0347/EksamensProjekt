using System;
using DomainLayer;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer
{
    public class SalRepository : AbstractRepository<Sal>
    {
        public SalRepository() : base() { }
        public Sal GetSal(string name)
        {
            foreach (Sal item in Items)
            {
                if (name == item.Navn)
                {
                    return item;
                }
            }
            throw new ArgumentException($"Sal med navn '{name}' findes ikke");
        }
    }
}
