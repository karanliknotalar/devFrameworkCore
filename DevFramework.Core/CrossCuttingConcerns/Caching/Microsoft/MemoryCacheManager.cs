using System;
using System.Linq;
using System.Runtime.Caching;
using System.Text.RegularExpressions;

namespace DevFramework.Core.CrossCuttingConcerns.Caching.Microsoft
{
    public class MemoryCacheManager : ICacheManager
    {
        protected ObjectCache Caches => MemoryCache.Default;

        public T Get<T>(string key)
        {
            return (T)Caches[key];
        }

        public void Add(string key, object data, int cacheTime = 60)
        {
            if (data is null) return;

            var policy = new CacheItemPolicy
            {
                AbsoluteExpiration = DateTimeOffset.Now + TimeSpan.FromMinutes(cacheTime),
            };
            Caches.Add(new CacheItem(key, data), policy);
        }

        public bool IsAdd(string key)
        {
            return Caches.Contains(key);
        }

        public void Remove(string key)
        {
            Caches.Remove(key);
        }

        public void RemoveByPattern(string pattern)
        {
            var regex = new Regex(pattern,
                RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase
            );
            var keysToRemove = Caches
                .Where(c => regex.IsMatch(c.Key))
                .Select(c => c.Key)
                .ToList();

            foreach (var key in keysToRemove)
            {
                Caches.Remove(key);
            }
        }

        public void Clear()
        {
            foreach (var cache in Caches)
            {
                Caches.Remove(cache.Key);
            }
        }
    }
}