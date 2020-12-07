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
            //TString svalue = 1;
            //context.String_Set<TString>("a",svalue);
            //svalue = 3.0;
            //context.String_Set<TString>("b", svalue);

            //Console.WriteLine(context.String_Get("a"));
            //Console.WriteLine(context.String_Get("v"));

            //var temp = context.String_MGet("a", "b", "v");
            //Console.WriteLine(temp);

            //Console.WriteLine(context.String_GetLength("b"));
            //Console.WriteLine(context.String_GetRange("b", 0, 2));
            //Console.WriteLine(context.String_SetIfNotExisis<TString>("v", svalue));

            var result= context.List_Insert<TString>("list", ListInsertEnum.after, new TString("a"), new TString("b"));
            Console.WriteLine(result);

            context.List_RPush<TString>("list", new TString("c"));
            Console.WriteLine(context.List_GetLength("list"));

            Console.WriteLine(context.List_GetByIndex("list", 0));
            Console.WriteLine(context.List_LPop("list"));
            Console.WriteLine(context.List_Range("list", 0, -1));
            Console.WriteLine(context.List_RPush<TString>("list", new TString("fff")));
            Console.WriteLine(context.List_RPop("list"));

            Console.ReadKey();
        }
    }
}
