using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleMenuGenerator.Navigations.Base
{
    public abstract class ItemNavigation : NavigationBase
    {
        public ItemNavigation(NavigationBase parent, string displayText) : base(parent, displayText)
        {
        }

        internal void StartKeyCapturing()
        {
            ConsoleKeyInfo pressedKey;

            do
            {
                pressedKey = Console.ReadKey(true);
            }
            while (pressedKey.Key != ConsoleKey.Backspace);

            InvokeParent();
        }
    }
}
