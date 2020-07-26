using ConsoleMenuGenerator.Navigations.Base;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using ConsoleMenuGenerator.Helper;

namespace ConsoleMenuGenerator.Navigations
{
    public class ObjectItem<T> : ItemNavigation
    {
        internal readonly T _obj;
        private readonly IEnumerable<string> _displayProperties;

        public ObjectItem(NavigationBase parent, string displayText, T obj, params string[] displayProperties) : 
            base(parent, displayText)
        {
            _obj = obj;
            _displayProperties = displayProperties;
        }

        internal override void Invoke()
        {
            Console.Clear();

            foreach (var property in _displayProperties)
            {
                var value = ReflectionHelper.GetPropertyValueAsString(_obj, property);
                Console.WriteLine($"{property}: {value}");
            }

            StartKeyCapturing();
        }
    }
}
