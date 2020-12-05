using System;
using System.Collections.Generic;
using System.Text;
using StackExchange.Redis;

namespace RedisOpLibrary
{
    public abstract class RedisOp : IRedisOp
    {
        private IDatabase Database { get; set; }

        protected RedisOp(string redishost, int? db)
        {
            Database = ConnectionMultiplexer.Connect(redishost).GetDatabase(db ?? -1);
        }

        public string String_Get(string key)
        {
            return Database.StringGet(key);
        }

        public long String_GetLength(string key)
        {
            return Database.StringLength(key);
        }

        public string String_GetRange(string key, long start, long end)
        {
            return Database.StringGetRange(key, start, end);
        }

        public List<string> String_MGet(params string[] keys)
        {
            var result = new List<string>();
            var rediskeys = new List<RedisKey>();
            foreach (var key in keys)
            {
                rediskeys.Add(new RedisKey(key));
            }
            foreach (var item in Database.StringGet(rediskeys.ToArray()))
            {
                if (!item.IsNull)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public bool String_Set<T>(string key, T value)
        {
            return Database.StringSet(key,value.ToString());
        }

        public bool String_SetIfNotExisis<T>(string key, T value)
        {
            if (Database.StringGet(key).IsNull)
            {
               return Database.StringSet(key,value.ToString());
            }
            return false;
        }

        public bool String_ExsisKey(string key)
        {
            if (Database.StringGet(key).IsNull)
            {
                return false;
            }
            return true;
        }
    }
}
