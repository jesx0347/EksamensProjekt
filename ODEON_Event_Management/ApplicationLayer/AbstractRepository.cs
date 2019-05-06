using System;
using DomainLayer;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ApplicationLayer
{
    public abstract class AbstractRepository<TContent, TSingleton> : IEnumerable where TContent : IHaveID where TSingleton : new()
    {
        protected List<TContent> Items;
        private static bool IsInstanceCreated = false;
        private static TSingleton _instance;
        public static TSingleton Instance
        {
            get
            {
                if (!IsInstanceCreated)
                {
                    _instance = new TSingleton();
                }
                return _instance;
            }
        }

        protected AbstractRepository()
        {
            if (IsInstanceCreated)
            {
                throw new InvalidOperationException($"Constructing a {typeof(TSingleton).Name} manually is not allowed, use the Instance property.");
            }
            else
            {
                IsInstanceCreated = true;
            }
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
