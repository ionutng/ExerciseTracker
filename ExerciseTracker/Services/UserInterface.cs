using ExerciseTracker.Models;
using Spectre.Console;
using System.Text;
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
                    MenuOptions.ViewRun,
                    MenuOptions.AddRun,
                    MenuOptions.UpdateRun,
                    MenuOptions.DeleteRun,
                    MenuOptions.Quit));

            switch (option)
            {
                case MenuOptions.ViewRuns:
                    ExerciseService.GetRuns();
                    break;
                case MenuOptions.ViewRun:
                    ExerciseService.GetRun();
                    break;
                case MenuOptions.AddRun:
                    ExerciseService.AddRun();
                    break;
                case MenuOptions.UpdateRun:
                    ExerciseService.UpdateRun();
                    break;
                case MenuOptions.DeleteRun:
                    ExerciseService.DeleteRun();
                    break;
                case MenuOptions.Quit:
                    Environment.Exit(0);
                    break;
            }
        }
    }

    static internal void ShowRuns(ICollection<Running> runs)
    {
        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Start Date");
        table.AddColumn("End Date");
        table.AddColumn("Duration");
        table.AddColumn("Distance");
        table.AddColumn("Comments");

        foreach (var run in runs)
            table.AddRow(
                run.RunningId.ToString(),
                run.DateStart.ToString(),
                run.DateEnd.ToString(),
                run.Duration.ToString(),
                run.Distance.ToString(),
                run.Comments);

        AnsiConsole.Write(table);

        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
        Console.Clear();
    }

    static internal void ShowRun(Running run)
    {
        var panel = new Panel(
            $"Id: Run #{run.RunningId}" +
            $"\nDate: {run.DateStart} - {run.DateEnd}" +
            $"\nDuration: {run.Duration}" +
            $"\nDistance: {run.Distance}" +
            $"\nComments: {run.Comments}")
        {
            Header = new PanelHeader("Run Info"),
            Padding = new Padding(2, 2, 2, 2)
        };

        AnsiConsole.Write(panel);

        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
        Console.Clear();
    }
}
