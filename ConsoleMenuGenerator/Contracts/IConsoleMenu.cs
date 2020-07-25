using System;
using System.Collections.Generic;
using System.Text;
using ConsoleMenuGenerator.Entities;
using ConsoleMenuGenerator.Extensions;

namespace ConsoleMenuGenerator.Contracts
{
    public interface IConsoleMenu
    {
        string DisplayText { get; set; }

        Action OnNavigate { get; set; }

        IList<IConsoleMenu> SubMenus { get; set; }

        IConsoleMenu AddItem(string displayText);
        
        IConsoleMenu AddItem(string displayTest, Action onNavigate);

        void Render();
    }
}
