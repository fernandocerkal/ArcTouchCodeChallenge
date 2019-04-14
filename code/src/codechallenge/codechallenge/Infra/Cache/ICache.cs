using System.Collections.Generic;

namespace codechallenge.Infra.Cache
{
    public interface ICache<T> where T : class, new()
    {
        List<T> List();
        bool Push(T item);
        bool Remove(T item);
    }
}
