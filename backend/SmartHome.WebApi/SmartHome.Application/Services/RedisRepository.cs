﻿using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Application.Services
{
    public class RedisRepository<T> : IDisposable
    {
        private readonly ConnectionMultiplexer _redis;
        private readonly IDatabase _db;

        public RedisRepository()
        {
            _redis = ConnectionMultiplexer.Connect("localhost:6379");
            _db = _redis.GetDatabase();
        }

        public void Add(string key, T value)
        {
            var serializerSettings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            var serializedValue = Newtonsoft.Json.JsonConvert.SerializeObject(value, serializerSettings);
            _db.StringSet(key, serializedValue);
        }

        public T Get(string key)
        {
            var serializedValue = _db.StringGet(key);
            return !serializedValue.HasValue ? default : Newtonsoft.Json.JsonConvert.DeserializeObject<T>(serializedValue);
        }

        public bool Update(string key, T value)
        {
            if (!_db.KeyExists(key))
                return false;

            var serializedValue = Newtonsoft.Json.JsonConvert.SerializeObject(value);
            _db.StringSet(key, serializedValue);
            return true;
        }

        public bool Delete(string key)
        {
            return _db.KeyDelete(key);
        }

        public bool DeleteAll()
        {
            var endpoints = _redis.GetEndPoints();
            foreach (var endpoint in endpoints)
            {
                var server = _redis.GetServer(endpoint);
                var keys = server.Keys(pattern: "*"); // Specify a pattern to match all keys
                foreach (var key in keys)
                {
                    Delete(key);
                }
            }
            return true;
        }
        public bool DeleteAllUserProperty(string id)
        {
            var endpoints = _redis.GetEndPoints();
            foreach (var endpoint in endpoints)
            {
                var server = _redis.GetServer(endpoint);
                var keys = server.Keys(pattern: $"property/{id}/*"); // Specify the pattern to match keys starting with "property/"
                foreach (var key in keys)
                {
                    Delete(key);
                }
            }
            return true;
        }


        public void Dispose()
        {
        }
    }
}
