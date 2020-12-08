using StackExchange.Redis;
using System;
using System.Collections;
using System.Collections.Generic;

namespace RedisOpLibrary
{
    public interface IRedisOp
    {
        #region 字符串

        /// <summary>
        /// 字符串设置指定key指定的值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        bool String_Set<T>(string key, T value);

        /// <summary>
        /// 当指定的key不存在时，为key设置指定的值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        bool String_SetIfNotExisis<T>(string key, T value);

        /// <summary>
        /// 字符串获取指定key的对应的值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string String_Get(string key);

        /// <summary>
        /// 字符串获取指定key的子字符串
        /// </summary>
        /// <param name="key"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        string String_GetRange(string key, long start, long end);

        /// <summary>
        /// 字符串获取一个或者多个指定key的值的数组
        /// 如果指定的key不存在，则对应的值为null
        /// 如果指定的key存在，但是值不存在，则返回值为空字符串
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        List<string> String_MGet(params string[] keys);

        /// <summary>
        /// 获取指定key所对应的值长度
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        long String_GetLength(string key);

        /// <summary>
        /// 字符串判断指定key是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool String_ExsisKey(string key);

        #endregion

        #region 列表

        /// <summary>
        /// 列表中向指定的key，从右边推入指定的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        bool List_RPush<T>(string key, T value);

        /// <summary>
        /// 列表中指定key中，在指定值的前面或者后面插入值
        /// 如果指定key不存在，返回-1，列表中指定的值不存在返回0
        /// 命令执行成功，返回当前列表的元素个数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="listInsertEnum"></param>
        /// <param name="proValue"></param>
        /// <param name="insertValue"></param>
        /// <returns></returns>
        bool List_Insert<T>(string key, ListInsertEnum listInsertEnum, T proValue, T insertValue);

        /// <summary>
        /// 列表中指定key从右边插入一个或者多个值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        bool List_RPush<T>(string key, params T[] values);

        /// <summary>
        /// 列表中移除指定key的第一个元素
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string List_LPop(string key);

        /// <summary>
        /// 列表中移除指定key的最后一个元素
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string List_RPop(string key);

        /// <summary>
        /// 列表中获取索引范围内的内容列表
        /// 索引默认从0开始，-1代表最后一个元素，-2代表倒数第二个元素
        /// </summary>
        /// <param name="key"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        List<string> List_Range(string key, long start, long end);

        /// <summary>
        /// 列表中获取指定key中对应索引的值
        /// -1代表最后一个值，如果索引不存在则返回null
        /// </summary>
        /// <param name="key"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        string List_GetByIndex(string key, int index);

        /// <summary>
        /// 列表获取指定key中列表的长度
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        int List_GetLength(string key);

        #endregion

        #region 哈希表

        /// <summary>
        /// 将哈希表中的指定的key的字段filed的值设置为value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        bool Hash_SetKeyField<T>(string key, string field, T value);

        /// <summary>
        /// 删除指定key的哈希表中指定字段
        /// </summary>
        /// <param name="key"></param>
        /// <param name="filed"></param>
        /// <returns></returns>
        bool Hash_DeleteKeyField(string key, string filed);

        /// <summary>
        /// 获取指定key哈希表中对应字段的值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        string Hash_GetKeyField(string key, string field);

        /// <summary>
        /// 获取指定key的哈希表中所有值列表
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        List<string> Hash_GetAllValues(string key);

        /// <summary>
        /// 获取指定key的哈希表中所有的字段列表
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        List<string> Hash_GetAllKeys(string key);

        /// <summary>
        /// 获取指定key的哈希表中所有的字段以及值的元组
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        HashEntry[] Hash_GetFieldValues(string key);

        /// <summary>
        /// 判断指定key的哈希表中的指定的字段是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        bool Hash_ExsistField(string key, string field);

        /// <summary>
        /// 获取指定key的哈希表中字段的长度
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        int Hash_Length(string key);



        #endregion
    }

    public enum ListInsertEnum
    {
        before,
        after
    }
}
