using ConsoleMenuGenerator.Contracts;
using ConsoleMenuGenerator.Exceptions;
using ConsoleMenuGenerator.Extensions;
using ConsoleMenuGenerator.Navigations.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleMenuGenerator.Navigations
{
    public class MenuNavigation : Navigation
    {
        internal IList<Navigation> _navigations = new List<Navigation>();

        internal int _choosenItem;

        internal bool _refreshConsole;

        internal bool _isRootMenu;

        public MenuNavigation() : base()
        {
            _isRootMenu = true;
        }

        public MenuNavigation(Navigation navigationParent, string displayText) : base(navigationParent, displayText)
        {
            _isRootMenu = false;
        }

        public MenuNavigation AddMenuNavigation(string displayText)
        {
            return _navigations.AddAndReturn(new MenuNavigation(this, displayText)) as MenuNavigation;
        }

        public void AddFunctionNavigation(string displayText, Func<string> onNavigate)
        {
            _navigations.Add(new FunctionNavigation(this, displayText, onNavigate));
        }

        public void AddObjectNavigation<T>(string displayText, T obj, params string[] displayProperties)
        {
            _navigations.Add(new ObjectNavigation<T>(this, displayText, obj, displayProperties));
        }

        public void AddEnumerableObjectNavigation<T>(string displayProperty, IList<T> objs, string objectDisplayProperty, params string[] displayProperties)
        {
            _navigations.Add(new EnumerableObjectNavigation<T>(this, displayProperty, objs, objectDisplayProperty, displayProperties));
        }

        public override void Invoke()
        {
            if (_navigations.Count == 0)
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
                        _navigations[_choosenItem].Invoke();
                        break;
                    case ConsoleKey.Backspace:
                        if (!_isRootMenu) InvokeParent();
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
            if (change < _navigations.Count)
            {
                _choosenItem = change;
                _refreshConsole = true;
            }
        }

        internal void RenderMenuItems()
        {
            for (var i = 0; i < _navigations.Count; i++)
            {
                if (i == _choosenItem)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("> ");
                    Console.ResetColor();
                    Console.WriteLine(_navigations[i].DisplayText);
                }
                else
                {
                    Console.WriteLine(_navigations[i].DisplayText);
                }
            }
        }
    }
}
