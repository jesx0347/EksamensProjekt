using System;
using DomainLayer;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer
{
    public class KategoriRepository : AbstractRepository<Kategori>
    {
        public KategoriRepository() : base()
        {
            //stub data
            Items.Add(new Kategori("jazz", 1));
            Items.Add(new Kategori("pop & rock", 2));
            Items.Add(new Kategori("Gastronomi", 3));
            Items.Add(new Kategori("comedy", 4));
        }

        public Kategori GetKategori(string navn)
        {
            foreach (Kategori item in Items)
            {
                if (item.Navn == navn)
                {
                    return item;
                }
            }
            throw new ArgumentException($"Kategori med navn '{navn}' findes ikke");
        }
    }
}
