using ConsoleMenuGenerator.Navigations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleMenuGenerator.Contracts
{
    public interface IConsoleMenuBuilder
    {
        public IBasicMenu CreateRootMenu();
        public void Build();
    }
}
