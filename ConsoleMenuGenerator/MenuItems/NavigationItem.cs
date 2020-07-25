using System;
using ConsoleMenuGenerator.Extensions;
using ConsoleMenuGenerator.Contracts;
using System.Collections.Generic;
using System.Text;
using ConsoleMenuGenerator.Exceptions;

namespace ConsoleMenuGenerator.MenuItems
{
    public abstract class NavigationItem
    {
        public string DisplayText { get; set; }

        internal NavigationItem _parentItem;

        internal NavigationItem()
        {
        }

        internal NavigationItem(string displayText)
        {
            DisplayText = displayText;
        }

        internal NavigationItem(NavigationItem parentItem, string displayText)
        {
            _parentItem = parentItem;
            DisplayText = displayText;
        }

        public abstract void Invoke();
    }
}
