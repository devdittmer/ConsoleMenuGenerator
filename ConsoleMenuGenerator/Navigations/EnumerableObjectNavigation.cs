using ConsoleMenuGenerator.Navigations.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleMenuGenerator.Navigations
{
    public class EnumerableObjectNavigation<T> : Navigation
    {
        private IList<ObjectNavigation<T>> _objs;

        internal int _choosenItem;

        internal bool _refreshConsole;

        public EnumerableObjectNavigation(Navigation navigationParent, string displayTextProperty, IList<T> objs, string objectDisplayProperty, params string[] displayProperties) :
            base(navigationParent, displayTextProperty)
        {
            _objs = new List<ObjectNavigation<T>>();
            foreach (var obj in objs)
            {
                _objs.Add(new ObjectNavigation<T>(this, objectDisplayProperty, obj, displayProperties));
            }
        }

        public override void Invoke()
        {
            StartKeyCapturing();
        }

        internal void StartKeyCapturing()
        {
            ConsoleKeyInfo pressedKey;
            _refreshConsole = true;
            _choosenItem = 0;

            do
            {
                if (_refreshConsole)
                {
                    Console.Clear();
                    RenderObjectDisplayText();
                }

                _refreshConsole = false;

                pressedKey = Console.ReadKey(true);
                switch (pressedKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        ProcessUpArrowKeyPress();
                        break;
                    case ConsoleKey.DownArrow:
                        ProcessDownArrowKeyPress();
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        _objs[_choosenItem].Invoke();
                        break;
                    case ConsoleKey.Backspace:
                        InvokeParent();
                        break;
                }
            }
            while (true);
        }

        internal void ProcessUpArrowKeyPress()
        {
            var change = _choosenItem - 1;
            if (change > -1)
            {
                _choosenItem = change;
                _refreshConsole = true;
            }
        }

        internal void ProcessDownArrowKeyPress()
        {
            var change = _choosenItem + 1;
            if (change < _objs.Count)
            {
                _choosenItem = change;
                _refreshConsole = true;
            }
        }

        internal void RenderObjectDisplayText()
        {
            for (var i = 0; i < _objs.Count; i++)
            {
                var displayText = _objs[i].GetDisplayPropertyValueAsString();

                if (i == _choosenItem)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("> ");
                    Console.ResetColor();
                    Console.WriteLine(displayText);
                }
                else
                {
                    Console.WriteLine(displayText);
                }
            }
        }
    }
}
