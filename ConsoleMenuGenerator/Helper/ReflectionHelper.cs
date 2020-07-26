using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleMenuGenerator.Helper
{
    public static class ReflectionHelper
    {
        internal static string GetPropertyValueAsString(object obj, string propertyName)
        {
            return obj.GetType().GetProperty(propertyName).GetValue(obj).ToString();
        }
    }
}
