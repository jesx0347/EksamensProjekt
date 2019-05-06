using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class Kategori : IHaveID
    {
        public int ID => throw new NotImplementedException();
        public string name;
    }
}
