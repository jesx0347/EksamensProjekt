using System;
using DomainLayer;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer
{
    public class ODEONEventRepository : AbstractRepository<ODEONEvent, ODEONEventRepository>
    {
        
        public ODEONEventRepository() : base() { }
        public ODEONEvent GetItem(string name)
        {
            foreach (ODEONEvent item in Items)
            {
                if(item.Navn == name)
                {
                    return item;
                }
            }
            throw new ArgumentException($"Event med navn '{name}' findes ikke");
        }
    }
}
