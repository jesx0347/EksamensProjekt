using System;
using DomainLayer;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ApplicationLayer
{
    public abstract class AbstractRepository<TContent> : IEnumerable where TContent : IHaveID
    {
        protected List<TContent> Items;

        protected AbstractRepository()
        {
            Items = new List<TContent>();
        }

        public virtual void AddItem(TContent item)
        {
            Items.Add(item);
        }

        public TContent GetItem(int ID)
        {
            foreach (TContent item in Items)
            {
                if (item.ID == ID)
                {
                    return item;
                }
            }
            throw new ArgumentException($"{typeof(TContent).Name} med ID {ID} findes ikke");
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)Items).GetEnumerator();
        }
    }
}
