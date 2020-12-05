using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedisOpLibrary
{
    public class RedisContext : RedisOp
    {
        private static RedisContext Context = null;

        private RedisContext(string redishost, int? db) : base(redishost, db)
        {

        }

        private static object obj = new object();

        public static RedisContext GetContext(string redisHost, int? db)
        {
            if (Context == null)
            {
                lock (obj)
                {
                    if (Context == null)
                    {
                        Context = new RedisContext(redisHost, db);
                    }
                }
            }
            return Context;
        }
    }
}
