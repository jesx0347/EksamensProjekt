using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class Omkostninger
    {
        public decimal MarkedsFøring { get; set; }
        public double KODA { get; set; }   
        public decimal Garantisum { get; set; }
        public double ArtistSplit { get; set; }
        public decimal VariableOmkostninger { get; set; }
        public string Note { get; set; }

        public Omkostninger(decimal markedsFøring, double koda, decimal garantisum, double artistSplit)
        {
            MarkedsFøring = markedsFøring;
            KODA = koda;
            Garantisum = garantisum;
            ArtistSplit = artistSplit;
        }
    }
}
