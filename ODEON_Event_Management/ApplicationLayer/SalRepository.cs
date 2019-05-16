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
        public SalRepository() : base()
        {
            //stub data
            //Items.Add(new Sal("Sal 1", 1, 500, 700));
            //Items.Add(new Sal("Sal 2", 2, 600, 800));
            //Items.Add(new Sal("Sal 3", 3, 400, 600));
            //Items.Add(new Sal("Sal 4", 4, 300, 500));
            //Items.Add(new Sal("Sal 5", 5, 200, 400));
        }
        public Sal GetItem(string name)
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
