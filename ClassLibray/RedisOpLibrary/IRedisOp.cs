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
    }
}
