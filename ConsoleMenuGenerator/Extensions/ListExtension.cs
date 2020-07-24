using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleMenuGenerator.Extensions
{
    public static class IListExtension
    {
        public static T AddAndReturn<T>(this IList<T> list, T item)
        {
            list.Add(item);
            return item;
        }
    }
}
