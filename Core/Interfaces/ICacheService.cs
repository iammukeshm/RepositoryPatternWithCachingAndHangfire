using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface ICacheService
    {
        bool TryGet<T>(string cacheKey, out T value);
        T Set<T>(string cacheKey, T value);
        void Remove(string cacheKey);
    }
}
