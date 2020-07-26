using System;
using ConsoleMenuGenerator.Extensions;
using ConsoleMenuGenerator.Contracts;
using System.Collections.Generic;
using System.Text;
using ConsoleMenuGenerator.Exceptions;

namespace ConsoleMenuGenerator.Navigations.Base
{
    public abstract class Navigation
    {
        public string DisplayText { get; set; }

        internal Navigation _parentItem;

        internal Navigation()
        {
        }

        internal Navigation(string displayText)
        {
            DisplayText = displayText;
        }

        internal Navigation(Navigation parentItem, string displayText)
        {
            DisplayText = displayText;
            _parentItem = parentItem;
        }

        public abstract void Invoke();

        public void InvokeParent()
        {
            _parentItem.Invoke();
        }
    }
}
