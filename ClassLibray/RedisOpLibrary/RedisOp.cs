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
            return Database.StringSet(key, value.ToString());
        }

        public bool String_SetIfNotExisis<T>(string key, T value)
        {
            if (Database.StringGet(key).IsNull)
            {
                return Database.StringSet(key, value.ToString());
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

        public bool List_RPush<T>(string key, T value)
        {
            if (Database.ListRightPush(key, value.ToString()) >= 1)
            {
                return true;
            }
            return false;
        }

        public bool List_Insert<T>(string key, ListInsertEnum listInsertEnum, T proValue, T insertValue)
        {
            long result = -100;
            try
            {
                if (listInsertEnum == ListInsertEnum.before)
                {
                    result = Database.ListInsertBefore(key, proValue.ToString(), insertValue.ToString());
                }
                else
                {
                    result = Database.ListInsertAfter(key, proValue.ToString(), insertValue.ToString());
                }
                if (result >= 1)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool List_RPush<T>(string key, params T[] values)
        {
            List<RedisValue> redisValues = new List<RedisValue>();
            foreach (var item in values)
            {
                redisValues.Add(new RedisValue(item.ToString()));
            }
            if (Database.ListRightPush(key, redisValues.ToArray()) > 0)
            {
                return true;
            }
            return false;
        }

        public string List_LPop(string key)
        {
            return Database.ListLeftPop(key);
        }

        public string List_RPop(string key)
        {
            return Database.ListRightPop(key);
        }

        public List<string> List_Range(string key, long start, long end)
        {
            var result = Database.ListRange(key, start, end);
            if (result != null && result.Length > 0)
            {
                var values = new List<string>();
                foreach (var item in result)
                {
                    if (!item.IsNull)
                    {
                        values.Add(item);
                    }
                }
                return values;
            }
            else
            {
                return new List<string>();
            }
        }

        public string List_GetByIndex(string key, int index)
        {
            return Database.ListGetByIndex(key, index);
        }

        public int List_GetLength(string key)
        {
            return (int)Database.ListLength(key);
        }
    }
}
