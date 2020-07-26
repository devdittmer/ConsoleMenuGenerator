using System;
using ConsoleMenuGenerator.Extensions;
using System.Collections.Generic;
using System.Text;
using ConsoleMenuGenerator.Exceptions;

namespace ConsoleMenuGenerator.Navigations.Base
{
    public abstract class NavigationBase
    {
        public string DisplayText { get; set; }

        internal NavigationBase _parent;

        internal NavigationBase()
        {
        }

        internal NavigationBase(string displayText)
        {
            DisplayText = displayText;
        }

        internal NavigationBase(NavigationBase parent, string displayText)
        {
            DisplayText = displayText;
            _parent = parent;
        }

        internal abstract void Invoke();

        internal void InvokeParent()
        {
            _parent.Invoke();
        }
    }
}
