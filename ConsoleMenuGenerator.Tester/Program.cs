using System;

namespace ConsoleMenuGenerator.Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            var consoleMenuBuilder = new ConsoleMenuBuilder();
            var rootMenu = consoleMenuBuilder.CreateRootMenu();

            rootMenu.AddFunctionItem("Function1", () =>
            {
                return "Hello World!";
            });

            var secondMenu = rootMenu.AddMenuItem("Menu1");
            secondMenu.AddFunctionItem("Menu1 Hello1", () =>
            {
                return "Menu1 Hello World";
            });

            var thirdMenu = secondMenu.AddMenuItem("Third Menu");

            secondMenu.AddFunctionItem("Menu1 Hello2", () => "Hello World Menu2" );

            consoleMenuBuilder.Build();
        }
    }
}
