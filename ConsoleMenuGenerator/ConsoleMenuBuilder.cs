using ConsoleMenuGenerator.Contracts;
using ConsoleMenuGenerator.Exceptions;
using ConsoleMenuGenerator.Navigations;
using System;

namespace ConsoleMenuGenerator
{
    public class ConsoleMenuBuilder
    {
        private MenuNavigation _rootMenu;

        public ConsoleMenuBuilder()
        {
            Console.CursorVisible = false;
        }

        public MenuNavigation CreateRootMenu()
        {
            _rootMenu = _rootMenu == null ?
                new MenuNavigation() :
                throw new MultipleRootMenuException();

            return _rootMenu;
        }

        public void Build()
        {
            _rootMenu.Invoke();
        }
    }
}
