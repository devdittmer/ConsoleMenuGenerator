using ConsoleMenuGenerator.Contracts;
using ConsoleMenuGenerator.Extensions;
using ConsoleMenuGenerator.Navigations.Base;
using System;

namespace ConsoleMenuGenerator.Navigations
{
    public class FunctionNavigation : Navigation
    {
        private Func<string> _onNavigate;

        public FunctionNavigation(Navigation navigationParent, string displayText, Func<string> onNavigate) : base(navigationParent, displayText)
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

        // Todo: Async FunctionItem?

        private void StartKeyCapturing()
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
