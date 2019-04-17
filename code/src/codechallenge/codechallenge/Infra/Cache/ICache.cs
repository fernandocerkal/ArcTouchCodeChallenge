namespace codechallenge.Infra.Cache
{
    public interface ICache<T> where T : class
    {
        T[] List();
        void Push(T item);
    }
}