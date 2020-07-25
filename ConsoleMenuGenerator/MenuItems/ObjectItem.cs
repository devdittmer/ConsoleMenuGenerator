using ConsoleMenuGenerator.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleMenuGenerator.MenuItems
{
    public class ObjectItem : NavigationItem
    {
        public ObjectItem(NavigationItem navigationParent, string displayText, Object obj)
        {
        }

        public override void Invoke()
        {
            throw new NotImplementedException();
        }
    }
}
