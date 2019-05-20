using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class UnderskudsGodtgørelse : IHaveID
    {
        public double Godtgørelse;
        public DateTime UdløbsDato;

        public int ID
        {
            get
            {
                return (int)UdløbsDato.Ticks;
            }
        }
    }
}
