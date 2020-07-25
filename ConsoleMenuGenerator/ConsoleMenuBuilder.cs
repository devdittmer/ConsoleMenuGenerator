using ConsoleMenuGenerator.Contracts;
using ConsoleMenuGenerator.MenuItems;
using System;

namespace ConsoleMenuGenerator
{
    public class ConsoleMenuBuilder
    {
        private MenuItem _rootMenu;

        public ConsoleMenuBuilder()
        {
            Console.CursorVisible = false;
            _rootMenu = new MenuItem();
        }

        public MenuItem CreateRootMenu()
        {
            return _rootMenu;
        }

        public void Build()
        {
            _rootMenu.Invoke();
        }
    }
}
