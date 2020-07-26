using ConsoleMenuGenerator.Contracts;
using ConsoleMenuGenerator.Exceptions;
using ConsoleMenuGenerator.Extensions;
using ConsoleMenuGenerator.Navigations.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleMenuGenerator.Navigations
{
    public class BasicMenu : MenuNavigation, IBasicMenu
    {
        internal IList<NavigationBase> _navigations = new List<NavigationBase>();

        internal bool _isRootMenu;

        public BasicMenu() : base()
        {
            _isRootMenu = true;
        }

        public BasicMenu(NavigationBase navigationParent, string displayText) : base(navigationParent, displayText)
        {
            _isRootMenu = false;
        }

        public IBasicMenu AddBasicMenu(string displayText)
        {
            return _navigations.AddAndReturn(new BasicMenu(this, displayText)) as BasicMenu;
        }

        public void AddFunctionItem(string displayText, Func<string> onNavigate)
        {
            _navigations.Add(new FunctionItem(this, displayText, onNavigate));
        }

        public void AddObjectItem<T>(string displayText, T obj, params string[] displayProperties)
        {
            _navigations.Add(new ObjectItem<T>(this, displayText, obj, displayProperties));
        }

        public void AddObjectMenu<T>(string displayProperty, IList<T> objs, string objectDisplayProperty, params string[] displayProperties)
        {
            _navigations.Add(new ObjectMenu<T>(this, displayProperty, objs, objectDisplayProperty, displayProperties));
        }

        internal override void Invoke()
        {
            Console.Clear();

            if (_navigations.Count == 0)
            {
                throw new ZeroRootItemsException();
            }

            StartKeyCapturing(
                () => ProcessUpArrowKeyPress(),
                () => ProcessDownArrowKeyPress(_navigations),
                () => _navigations[_choosenItem].Invoke(),
                () =>
                {
                    if (!_isRootMenu) InvokeParent();
                }
            );
        }

        internal override void RenderMenuItems()
        {
            for (var i = 0; i < _navigations.Count; i++)
            {
                if (i == _choosenItem)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("> ");
                    Console.ResetColor();
                    Console.WriteLine(_navigations[i].DisplayText);
                }
                else
                {
                    Console.WriteLine(_navigations[i].DisplayText);
                }
            }
        }
    }
}
