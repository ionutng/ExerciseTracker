using Spectre.Console;
using static ExerciseTracker.Models.Enums;

namespace ExerciseTracker.Services;

static internal class UserInterface
{
    static internal void Menu()
    {
        while (true)
        {
            Console.Clear();
            var option = AnsiConsole.Prompt(
                new SelectionPrompt<MenuOptions>()
                .Title("What would you like to do?")
                .AddChoices(
                    MenuOptions.ViewRuns,
                    MenuOptions.AddRun,
                    MenuOptions.UpdateRun,
                    MenuOptions.DeleteRun,
                    MenuOptions.Quit));

            switch (option)
            {
                case MenuOptions.ViewRuns:
                    ExerciseService.GetRuns();
                    break;
                case MenuOptions.AddRun:
                    ExerciseService.AddRun();
                    break;
                case MenuOptions.Quit:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
