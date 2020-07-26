using ConsoleMenuGenerator.Contracts;
using ConsoleMenuGenerator.Navigations.Base;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ConsoleMenuGenerator.Navigations
{
    public class ObjectNavigation<T> : Navigation
    {
        private T _obj;
        private IEnumerable<string> _displayProperties;

        public ObjectNavigation(Navigation navigationParent, string displayText, T obj, params string[] displayProperties) : 
            base(navigationParent, displayText)
        {
            _obj = obj;
            _displayProperties = displayProperties;
        }

        public override void Invoke()
        {
            foreach (var property in _displayProperties)
            {
                var value = GetPropertyValueAsString(property);
                Console.WriteLine($"{property}: {value}");
            }

            StartKeyCapturing();
        }

        private void StartKeyCapturing()
        {
            ConsoleKeyInfo pressedKey;

            do
            {
                pressedKey = Console.ReadKey(true);
            }
            while (pressedKey.Key != ConsoleKey.Backspace);

            InvokeParent();
        }

        public string GetDisplayPropertyValueAsString()
        {
            return _obj.GetType().GetProperty(DisplayText).GetValue(_obj).ToString();
        }

        public string GetPropertyValueAsString(string propertyName)
        {
            return _obj.GetType().GetProperty(propertyName).GetValue(_obj).ToString();
        }
    }
}
