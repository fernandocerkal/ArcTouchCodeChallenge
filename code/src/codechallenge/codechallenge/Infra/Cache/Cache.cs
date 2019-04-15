using System;
using System.Collections.Generic;

namespace codechallenge.Infra.Cache
{
    public class Cache<T> : IDisposable
    {
        private List<T> data;
        private object lckData;

        public Cache()
        {
            data = new List<T>();
            lckData = new object();
        }

        public Cache(List<T> data, object lckData)
        {
            this.data = data;
            this.lckData = lckData;
        }

        public T[] List() => data?.ToArray();

        public void Push(T item)
        {
            lock (lckData)
            {
                data.Add(item);
            }
        }

        public void AddRange(IEnumerable<T> items)
        {
            if (items != null)
                lock (lckData)
                {
                    data.AddRange(items);
                }
        }

        public void Dispose()
        {
            lock(lckData)
            {
                data.Clear(); 
                data = null;
            }
            lckData = null;
        }
    }
}