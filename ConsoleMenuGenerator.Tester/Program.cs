using System;

namespace ConsoleMenuGenerator.Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            var consoleMenuBuilder = new ConsoleMenuBuilder();
            var firstRootItem = consoleMenuBuilder.AddRooItem("First");
            var secondRootItem = consoleMenuBuilder.AddRooItem("Second");
            var thirdRooItem = consoleMenuBuilder.AddRooItem("Third");

            var firstSubItem = firstRootItem.AddItem("First Sub Item", () =>
            {
                Console.WriteLine("First Sub Item");
            });

            consoleMenuBuilder.Build();
        }
    }
}
