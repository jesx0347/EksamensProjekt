using System;
using DomainLayer;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer
{
    public class ODEONEventRepository : AbstractRepository<ODEONEvent>/*, IObservable<Tuple<int, string>>*/
    {
        //private List<IObserver<Tuple<int, string>>> Observers;

        //public ODEONEventRepository() : base()
        //{
        //    Observers = new List<IObserver<Tuple<int, string>>>();
        //}

        public ODEONEvent GetItem(string name)
        {
            foreach (ODEONEvent item in Items)
            {
                if(item.Navn == name)
                {
                    return item;
                }
            }
            throw new ArgumentException($"Event med navn '{name}' findes ikke");
        }
        //public IDisposable Subscribe(IObserver<Tuple<int, string>> observer)
        //{
        //    Observers.Add(observer);
        //    return new Unsubscriber(Observers, observer);
        //}

        //private class Unsubscriber : IDisposable
        //{
        //    private List<IObserver<Tuple<int, string>>> _observers;
        //    private IObserver<Tuple<int, string>> _observer;

        //    public Unsubscriber(List<IObserver<Tuple<int, string>>> observers, IObserver<Tuple<int, string>> observer)
        //    {
        //        this._observers = observers;
        //        this._observer = observer;
        //    }

        //    public void Dispose()
        //    {
        //        if (_observer != null && _observers.Contains(_observer))
        //            _observers.Remove(_observer);
        //    }
        //}
    }
}
