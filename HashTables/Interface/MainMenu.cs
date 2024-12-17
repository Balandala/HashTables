using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTables.Interface
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
        public static void DisplayMenu(string[] options, Delegate[] methods, string title)
        {
            var option = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title(title)
            .PageSize(10)
            .AddChoices(options));
        }
    }
}
