using System;
using System.Collections.Generic;

namespace RefaceCore.Modularization
{
    /// <summary>
    /// 类型扩展方法
    /// </summary>
    public static class TypeExtension
    {
        private readonly static Type TYPE_OBJ = typeof(object);

        /// <summary>
        /// 获取一个类型的所有基类，object 会出现在结果集中的最后一个
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static IEnumerable<Type> GetAllBaseTypes(this Type type)
        {
            ICollection<Type> result = new List<Type>();
            Type _type = type;
            do
            {
                _type = _type.BaseType;
                result.Add(_type);
            } while (_type != TYPE_OBJ);
            return result;
        }
    }
}
