using ConsoleMenuGenerator.Contracts;
using ConsoleMenuGenerator.Exceptions;
using ConsoleMenuGenerator.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleMenuGenerator.MenuItems
{
    public class MenuItem : NavigationItem
    {
        internal IList<NavigationItem> _navigationItems = new List<NavigationItem>();

        internal int _choosenItem;

        internal bool _refreshConsole;

        internal bool _isRootMenu;

        public MenuItem() : base()
        {
            _isRootMenu = true;
        }

        public MenuItem(NavigationItem navigationParent, string displayText) : base(navigationParent, displayText)
        {
            _isRootMenu = false;
        }

        public MenuItem AddMenuItem(string displayText)
        {
            return _navigationItems.AddAndReturn(new MenuItem(this, displayText)) as MenuItem;
        }

        public void AddFunctionItem(string displayText, Func<string> onNavigate)
        {
            _navigationItems.Add(new FunctionItem(this, displayText, onNavigate));
        }

        public override void Invoke()
        {
            if (_navigationItems.Count == 0)
            {
                throw new ZeroRootItemsException();
            }

            StartKeyCapturing();
        }

        internal void StartKeyCapturing()
        {
            ConsoleKeyInfo pressKey;
            _refreshConsole = true;
            _choosenItem = 0;

            do
            {
                if (_refreshConsole)
                {
                    Console.Clear();
                    RenderMenuItems();
                }

                _refreshConsole = false;

                pressKey = Console.ReadKey(true);
                switch (pressKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        ProcessUpArrowKeyPress();
                        break;
                    case ConsoleKey.DownArrow:
                        ProcessDownArrowKeyPress();
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        _navigationItems[_choosenItem].Invoke();
                        break;
                    case ConsoleKey.Backspace:
                        if (!_isRootMenu) _parentItem.Invoke();
                        break;
                }
            }
            while (true);
        }

        internal void ProcessUpArrowKeyPress()
        {
            var change = _choosenItem - 1;
            if (change > -1)
            {
                _choosenItem = change;
                _refreshConsole = true;
            }
        }

        internal void ProcessDownArrowKeyPress()
        {
            var change = _choosenItem + 1;
            if (change < _navigationItems.Count)
            {
                _choosenItem = change;
                _refreshConsole = true;
            }
        }

        internal void RenderMenuItems()
        {
            for (var i = 0; i < _navigationItems.Count; i++)
            {
                if (i == _choosenItem)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("> ");
                    Console.ResetColor();
                    Console.WriteLine(_navigationItems[i].DisplayText);
                }
                else
                {
                    Console.WriteLine(_navigationItems[i].DisplayText);
                }
            }
        }
    }
}
