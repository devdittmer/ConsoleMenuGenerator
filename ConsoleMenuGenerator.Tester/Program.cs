using ConsoleMenuGenerator.Tester.Entities;
using System;
using System.Collections.Generic;

namespace ConsoleMenuGenerator.Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            var consoleMenuBuilder = new ConsoleMenuBuilder();

            var rootMenu = consoleMenuBuilder.CreateRootMenu();
            rootMenu.AddFunctionNavigation("Menu1 Function1", () => "Hello World!");

            var secondMenu = rootMenu.AddMenuNavigation("Menu2");
            secondMenu.AddFunctionNavigation("Menu2 Function1", () => "Menu2 Function1");
            secondMenu.AddFunctionNavigation("Menu2 Function2", () => "Menu2 Function2");

            var thirdMenu = secondMenu.AddMenuNavigation("Third Menu");
            thirdMenu.AddFunctionNavigation("Menu3 Function1", () => "Menu3 Function1" );
            thirdMenu.AddFunctionNavigation("Menu3 Fcuntion2", () => "Menu3 Function2");

            var x = new Person { Name = "Emily", Age = 14, Address = "Rosengartem" };
            thirdMenu.AddObjectNavigation("Person", x, "Name", "Age", "Address");

            var y = new List<Person>()
            {
                new Person 
                { 
                    Name = "Merten",
                    Address = "Holzhäuserweg 77",
                    Age = 23
                },

                new Person
                {
                    Name = "Rosika",
                    Address = "Alveser Straße 8d",
                    Age = 50
                },

                new Person
                {
                    Name = "Dana Fischer",
                    Address = "Holzhäuserweg",
                    Age = 22
                }
            };
            thirdMenu.AddEnumerableObjectNavigation("Personen", y, "Name", "Age", "Address");

            consoleMenuBuilder.Build();
        }
    }
}
