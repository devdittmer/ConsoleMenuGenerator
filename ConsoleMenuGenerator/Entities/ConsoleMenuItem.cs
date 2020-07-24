using System;
using ConsoleMenuGenerator.Extensions;
using System.Collections.Generic;
using System.Text;

namespace ConsoleMenuGenerator.Entities
{
    public class ConsoleMenuItem
    {
        internal string DisplayText;

        internal Action Action;

        internal Guid _id;

        internal Guid _returnId;

        internal IList<ConsoleMenuItem> _consoleMenuItems = new List<ConsoleMenuItem>();


        public ConsoleMenuItem AddItem(string displayText)
        {
            return _consoleMenuItems.AddAndReturn(new ConsoleMenuItem
            {
                DisplayText = displayText,
                _id = Guid.NewGuid(),
                _returnId = _id
            });
        }

        public ConsoleMenuItem AddItem(string displayText, Action action)
        {
            return _consoleMenuItems.AddAndReturn(new ConsoleMenuItem
            {
                DisplayText = displayText,
                _id = Guid.NewGuid(),
                _returnId = _id,
                Action = action
            });
        }
    }
}
