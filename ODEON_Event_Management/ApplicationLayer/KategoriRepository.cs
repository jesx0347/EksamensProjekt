﻿using System;
using DomainLayer;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer
{
    public class KategoriRepository : AbstractRepository<Kategori, KategoriRepository>
    {
        public KategoriRepository() : base() { }

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
