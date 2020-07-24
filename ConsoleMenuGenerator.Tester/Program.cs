using System;

namespace ConsoleMenuGenerator.Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            var consoleMenu = new ConsoleMenu();
            var firsRootItem = consoleMenu.AddRooItem("First", () =>
            {
                Console.WriteLine("Hello World!");
            });
            var secondRootItem = consoleMenu.AddRooItem("Second");
            var thirdRooItem = consoleMenu.AddRooItem("Third");


            consoleMenu.Render();
            Console.ReadLine();
        }
    }
}
