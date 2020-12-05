using System;
using RedisOpLibrary;

namespace RedisTest
{
    class Program
    {
        static string redisString = "192.168.137.120:6379,password=123456,abortConnect=false";

        static int dbIndex = 0;

        static void Main(string[] args)
        {
            var context = RedisContext.GetContext(redisString, dbIndex);
            TString svalue = 1;
            context.String_Set<TString>("a",svalue);
            svalue = 3.0;
            context.String_Set<TString>("b", svalue);

            Console.WriteLine(context.String_Get("a"));
            Console.WriteLine(context.String_Get("v"));

            var temp = context.String_MGet("a", "b", "v");
            Console.WriteLine(temp);

            Console.WriteLine(context.String_GetLength("b"));
            Console.WriteLine(context.String_GetRange("b", 0, 2));
            Console.WriteLine(context.String_SetIfNotExisis<TString>("v", svalue));


            Console.ReadKey();
        }
    }
}
