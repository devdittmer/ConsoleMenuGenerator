using ConsoleMenuGenerator.Contracts;
using ConsoleMenuGenerator.Exceptions;
using ConsoleMenuGenerator.Navigations;
using System;

namespace ConsoleMenuGenerator
{
    public class ConsoleMenuBuilder : IConsoleMenuBuilder
    {
        private BasicMenu _rootMenu;

        public ConsoleMenuBuilder()
        {
            Console.CursorVisible = false;
        }

        public IBasicMenu CreateRootMenu()
        {
            _rootMenu = _rootMenu == null ?
                new BasicMenu() :
                throw new MultipleRootMenuException();

            return _rootMenu;
        }

        public void Build()
        {
            _rootMenu.Invoke();
        }
    }
}
