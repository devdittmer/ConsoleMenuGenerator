using ConsoleMenuGenerator.Entities;
using ConsoleMenuGenerator.Exceptions;
using ConsoleMenuGenerator.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleMenuGenerator
{
    public class ConsoleMenu
    {
        private IList<ConsoleMenuItem> _consoleMenuRootItems;
        private Guid _rootId;
        private int _choosenItem;

        public ConsoleMenu()
        {
            _consoleMenuRootItems = new List<ConsoleMenuItem>();
            _rootId = Guid.NewGuid();
        }

        public ConsoleMenuItem AddRooItem(string displayText)
        {
            return _consoleMenuRootItems.AddAndReturn(new ConsoleMenuItem
            {
                DisplayText = displayText,
                _returnId = _rootId,
                _id = Guid.NewGuid()
            });
        }

        public ConsoleMenuItem AddRooItem(string displayText, Action action)
        {
            return _consoleMenuRootItems.AddAndReturn(new ConsoleMenuItem
            {
                DisplayText = displayText,
                _returnId = _rootId,
                _id = Guid.NewGuid(),
                Action = action
            });
        }

        public void Render()
        {
            if (_consoleMenuRootItems.Count == 0)
            {
                throw new ZeroRootItemsException();
            }

            _choosenItem = _consoleMenuRootItems.Count - 1;

            Console.CursorVisible = false;
            StartKeyCapturing();
        }

        private void StartKeyCapturing()
        {
            ConsoleKeyInfo pressKey;

            do
            {
                Console.Clear();

                for (var i = 0; i < _consoleMenuRootItems.Count; i++)
                {
                    if (i == _choosenItem)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(_consoleMenuRootItems[i].DisplayText);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine(_consoleMenuRootItems[i].DisplayText);
                    }
                }

                pressKey = Console.ReadKey(true);
                switch (pressKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        ProcessUpArrowKeyPress();
                        break;
                    case ConsoleKey.DownArrow:
                        ProcessDownArrowKeyPress();
                        break;
                }

                if (pressKey.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    break;
                }
            }
            while (true);

            _consoleMenuRootItems[_choosenItem].Action.Invoke();
        }

        private void ProcessUpArrowKeyPress()
        {
            var change = _choosenItem - 1;
            if (change > -1)
            {
                _choosenItem = change;
            }
        }

        private void ProcessDownArrowKeyPress()
        {
            var change = _choosenItem + 1;
            if (change < _consoleMenuRootItems.Count)
            {
                _choosenItem = change;
            }
        }
    }
}
