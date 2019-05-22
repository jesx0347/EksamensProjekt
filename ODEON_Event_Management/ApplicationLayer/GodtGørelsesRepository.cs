using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer;

namespace ApplicationLayer
{
    public class GodtGørelsesRepository : AbstractRepository<UnderskudsGodtgørelse>
    {
        private class GodtGørelseComparer : IComparer<UnderskudsGodtgørelse>
        {
            public int Compare(UnderskudsGodtgørelse x, UnderskudsGodtgørelse y)
            {
                return x.UdløbsDato.CompareTo(y.UdløbsDato);
            }
        }

        public override void AddItem(UnderskudsGodtgørelse item)
        {
            base.AddItem(item);
            Items.Sort(new GodtGørelseComparer());
        }
    }
}
