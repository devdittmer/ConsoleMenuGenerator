using ConsoleMenuGenerator.Extensions;
using ConsoleMenuGenerator.Navigations.Base;
using System;

namespace ConsoleMenuGenerator.Navigations
{
    public class FunctionItem : ItemNavigation
    {
        private readonly Func<string> _onNavigate;

        public FunctionItem(NavigationBase parent, string displayText, Func<string> onNavigate) : base(parent, displayText)
        {
            _onNavigate = onNavigate;
        }

        internal override void Invoke()
        {
            Console.Clear();

            if (_onNavigate == null)
            {
                throw new Exception();
            }

            Console.WriteLine(_onNavigate.Invoke());
            StartKeyCapturing();
        }
    }
}
