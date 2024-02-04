using Newtonsoft.Json;
using StackExchange.Redis;
using System;

namespace SmartHome.Application.Services
{
    public class RedisRepository<T> : IDisposable
    {
        private static readonly Lazy<ConnectionMultiplexer> LazyConnection = new Lazy<ConnectionMultiplexer>(() =>
        {
            var configurationOptions = ConfigurationOptions.Parse("localhost:6379,abortConnect=false");
            configurationOptions.KeepAlive = 1800;
            return ConnectionMultiplexer.Connect(configurationOptions);
        });

        private readonly IDatabase _db;

        private RedisRepository()
        {
            _db = LazyConnection.Value.GetDatabase();
        }

        public static RedisRepository<T> Instance { get; } = new RedisRepository<T>();

        public void Add(string key, T value)
        {
            var serializerSettings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            var serializedValue = JsonConvert.SerializeObject(value, serializerSettings);
            _db.StringSet(key, serializedValue);
        }

        public T Get(string key)
        {
            var serializedValue = _db.StringGet(key);
            return !serializedValue.HasValue ? default : JsonConvert.DeserializeObject<T>(serializedValue);
        }

        public bool Update(string key, T value)
        {
            if (!_db.KeyExists(key))
                return false;

            var serializedValue = JsonConvert.SerializeObject(value);
            _db.StringSet(key, serializedValue);
            return true;
        }

        public bool Delete(string key)
        {
            return _db.KeyDelete(key);
        }

        public bool DeleteAll()
        {
            var endpoints = LazyConnection.Value.GetEndPoints();
            foreach (var endpoint in endpoints)
            {
                var server = LazyConnection.Value.GetServer(endpoint);
                var keys = server.Keys(pattern: "*");
                foreach (var key in keys)
                {
                    Delete(key);
                }
            }
            return true;
        }

        public bool DeleteAllUserProperty(string id)
        {
            var endpoints = LazyConnection.Value.GetEndPoints();
            foreach (var endpoint in endpoints)
            {
                var server = LazyConnection.Value.GetServer(endpoint);
                var keys = server.Keys(pattern: $"property/{id}/*");
                foreach (var key in keys)
                {
                    Delete(key);
                }
            }
            return true;
        }

        public void Dispose()
        {
            // Dispose logic, if needed
        }
    }
}
