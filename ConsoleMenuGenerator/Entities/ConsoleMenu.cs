using System;
using ConsoleMenuGenerator.Extensions;
using ConsoleMenuGenerator.Contracts;
using System.Collections.Generic;
using System.Text;
using ConsoleMenuGenerator.Exceptions;

namespace ConsoleMenuGenerator.Entities
{
    public class ConsoleMenu : IConsoleMenu
    {
        public string DisplayText { get; set; }
        
        public Action OnNavigate { get; set; }

        public IList<IConsoleMenu> SubMenus { get; set; } = new List<IConsoleMenu>();
        
        internal IConsoleMenu _parentMenu;

        private int _choosenItem;

        private bool _refreshConsole;

        private bool _isRootMenu;

        internal ConsoleMenu()
        {
            _isRootMenu = true;
        }

        private ConsoleMenu(IConsoleMenu parentMenu, string displayText)
        {
            DisplayText = displayText;
            _parentMenu = parentMenu;
            _isRootMenu = false;
        }

        private ConsoleMenu(IConsoleMenu parentMenu, string displayText, Action onNavigate) {
            DisplayText = displayText;
            OnNavigate = onNavigate;
            _parentMenu = parentMenu;
            _isRootMenu = false;
        }   

        public IConsoleMenu AddItem(string displayText)
        {
            return SubMenus.AddAndReturn(new ConsoleMenu(this, displayText));
        }

        public IConsoleMenu AddItem(string displayText, Action onNavigate)
        {
            return SubMenus.AddAndReturn(new ConsoleMenu(this, displayText, onNavigate));
        }

        public void Render()
        {
            if (SubMenus.Count == 0)
            {
                throw new ZeroRootItemsException();
            }

            _choosenItem = 0;
            StartKeyCapturing();
        }

        internal void StartKeyCapturing()
        {
            ConsoleKeyInfo pressKey;
            _refreshConsole = true;

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
                        SubMenus[_choosenItem].Render();
                        break;
                    case ConsoleKey.Backspace:
                        if (!_isRootMenu) _parentMenu.Render();
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
            if (change < SubMenus.Count)
            {
                _choosenItem = change;
                _refreshConsole = true;
            }
        }

        internal void RenderMenuItems()
        {
            for (var i = 0; i < SubMenus.Count; i++)
            {
                if (i == _choosenItem)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("> ");
                    Console.ResetColor();
                    Console.WriteLine(SubMenus[i].DisplayText);
                }
                else
                {
                    Console.WriteLine(SubMenus[i].DisplayText);
                }
            }
        }
    }
}
