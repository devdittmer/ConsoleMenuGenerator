using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleMenuGenerator.Navigations.Base
{
    public abstract class MenuNavigation : NavigationBase
    {
        internal int _choosenItem;

        internal bool _refreshConsole;

        public MenuNavigation() : base()
        {
        }

        public MenuNavigation(NavigationBase parent, string displayText) : base(parent, displayText)
        {
        }

        internal void StartKeyCapturing(Action onKeyUp, Action onKeyDown,  Action onEnter, Action onBackspace)
        {
            ConsoleKeyInfo pressedKey;
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

                pressedKey = Console.ReadKey(true);
                switch (pressedKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        onKeyUp();
                        break;
                    case ConsoleKey.DownArrow:
                        onKeyDown();
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        onEnter();
                        break;
                    case ConsoleKey.Backspace:
                        onBackspace();
                        break;
                }
            }
            while (true);
        }

        internal abstract void RenderMenuItems();

        internal void ProcessUpArrowKeyPress()
        {
            var change = _choosenItem - 1;
            if (change > -1)
            {
                _choosenItem = change;
                _refreshConsole = true;
            }
        }

        internal void ProcessDownArrowKeyPress<T>(IEnumerable<T> items)
        {
            var change = _choosenItem + 1;
            if (change < items.Count())
            {
                _choosenItem = change;
                _refreshConsole = true;
            }
        }
    }
}
