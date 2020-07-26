using ConsoleMenuGenerator.Helper;
using ConsoleMenuGenerator.Navigations.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleMenuGenerator.Navigations
{
    public class ObjectMenu<T> : MenuNavigation
    {
        private readonly IList<ObjectItem<T>> _objs;

        public ObjectMenu(NavigationBase parent, string displayTextProperty, IList<T> objs, string objectsDisplayProperty, params string[] displayProperties) :
            base(parent, displayTextProperty)
        {
            _objs = new List<ObjectItem<T>>();
            foreach (var obj in objs)
            {
                _objs.Add(new ObjectItem<T>(this, objectsDisplayProperty, obj, displayProperties));
            }
        }

        internal override void Invoke()
        {
            Console.Clear();

            StartKeyCapturing(
                () => ProcessUpArrowKeyPress(),
                () => ProcessDownArrowKeyPress(_objs),
                () => _objs[_choosenItem].Invoke(),
                () => InvokeParent());
        }

        internal override void RenderMenuItems()
        {
            for (var i = 0; i < _objs.Count; i++)
            {
                var displayText = ReflectionHelper.GetPropertyValueAsString(_objs[i]._obj, _objs[i].DisplayText);

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
