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
    }
}
