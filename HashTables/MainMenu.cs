using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTables
{
    internal class MainMenu
    {
        private static void DisplayHeader()
        {
            Console.Clear();
            AnsiConsole.Write(
                new FigletText("Main Menu")
                    .Centered()
                    .Color(Color.Gold1));
        }
        public static void DisplayMainMenu()
        {
            DisplayHeader();
            var choise = AnsiConsole.Prompt(
                 new SelectionPrompt<string>()
                 .AddChoices(new[]
                 {"Алгоритмы внутренней сортировки",
                  "Сортировка текста"}
                 ).HighlightStyle(Color.Gold1)
                 );

            if (choise == "Алгоритмы внутренней сортировки")
            {  
            }
            else if (choise == "Внешняя сортировка")
            {
            }
            else if (choise == "Сортировка текста")
            {
            }



        }
    }
}
