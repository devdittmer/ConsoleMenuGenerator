using ConsoleMenuGenerator.Contracts;
using ConsoleMenuGenerator.Entities;
using ConsoleMenuGenerator.Exceptions;
using ConsoleMenuGenerator.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleMenuGenerator
{
    public class ConsoleMenuBuilder
    {
        private IConsoleMenu _rootMenu;

        public ConsoleMenuBuilder()
        {
            Console.CursorVisible = false;
            _rootMenu = new ConsoleMenu();
        }

        public IConsoleMenu AddRooItem(string displayText)
        {
            return _rootMenu.AddItem(displayText);
        }

        public IConsoleMenu AddRooItem(string displayText, Action onNavigate)
        {
            return _rootMenu.AddItem(displayText, onNavigate);
        }

        public void Build()
        {
            _rootMenu.Render();
        }
    }
}
