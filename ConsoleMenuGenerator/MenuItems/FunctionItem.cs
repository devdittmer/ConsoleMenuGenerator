using ConsoleMenuGenerator.Contracts;
using ConsoleMenuGenerator.Extensions;
using System;

namespace ConsoleMenuGenerator.MenuItems
{
    public class FunctionItem : NavigationItem
    {
        private Func<string> _onNavigate;

        public FunctionItem(NavigationItem navigationParent, string displayText, Func<string> onNavigate) : base(navigationParent, displayText)
        {
            _onNavigate = onNavigate;
        }

        public override void Invoke()
        {
            if (_onNavigate == null)
            {
                throw new Exception();
            }

            Console.WriteLine(_onNavigate.Invoke());
            StartKeyCapturing();
        }

        private void StartKeyCapturing()
        {
            ConsoleKeyInfo pressedKey;

            do
            {
                pressedKey = Console.ReadKey(true);
            }
            while (pressedKey.Key != ConsoleKey.Backspace);

            _parentItem.Invoke();
        }
    }
}
