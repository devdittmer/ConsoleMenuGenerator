using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleMenuGenerator.Contracts
{
    public interface IBasicMenu
    {
        public IBasicMenu AddBasicMenu(string displayText);

        public void AddFunctionItem(string displayText, Func<string> onNavigate);
        
        public void AddObjectItem<T>(string displayText, T obj, params string[] displayProperties);

        public void AddObjectMenu<T>(string displayProperty, IList<T> objs, string objectDisplayProperty, params string[] displayProperties);
    }
}
