using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleMenuGenerator.Contracts
{
    public interface INavigationItem
    {
        string DisplayText { get; set; }

        INavigationItem AddItem(string displayText);
        
        INavigationItem AddItem(string displayTest, Action onNavigate);

        abstract void Invoke();
    }
}
