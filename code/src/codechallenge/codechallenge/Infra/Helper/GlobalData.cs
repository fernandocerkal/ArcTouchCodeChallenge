using System;
using codechallenge.Application.Genre;
using codechallenge.Infra.Cache;

namespace codechallenge.Infra.Helper
{
    public sealed class GlobalData : IDisposable
    {
        public Cache<GenreModel> GenreCache { get; set; } = new Cache<GenreModel>();

        private static GlobalData instance;

        public static GlobalData GetInstance()
        {
            if (instance == null) instance = new GlobalData();
            return instance;
        }

        public void Dispose()
        {
            GenreCache?.Dispose();
            GenreCache = null;
        }
    }
}