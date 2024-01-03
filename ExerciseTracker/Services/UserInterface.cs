using ExerciseTracker.Models;
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

    static internal Running UpdateRunInfoInput(Running run)
    {
        if (AnsiConsole.Confirm("Update start date?"))
        {
            var date = AnsiConsole.Ask<DateOnly>("New start date (Format: MM-dd-yyyy):");
            var time = AnsiConsole.Ask<TimeOnly>("New start time (Format: HH:mm:ss):");
            run.DateStart = new DateTime(date, time);
        }

        if (AnsiConsole.Confirm("Update end date?"))
        {
            var date = AnsiConsole.Ask<DateOnly>("New end date (Format: MM-dd-yyyy):");
            var time = AnsiConsole.Ask<TimeOnly>("New end time (Format: HH:mm:ss):");
            run.DateEnd = new DateTime(date, time);
        }

        run.Duration = run.DateEnd - run.DateStart;

        run.Distance = AnsiConsole.Confirm("Update distance?")
            ? run.Distance = AnsiConsole.Ask<float>("New distance:")
            : run.Distance;

        run.Comments = AnsiConsole.Confirm("Update comments?")
            ? run.Comments = AnsiConsole.Ask<string>("Comments:")
            : run.Comments;

        return run;
    }

    static internal Running AskRunInfoInput()
    {
        var run = new Running();
        DateOnly startDate, endDate;
        TimeOnly startTime, endTime;

        do
        {
            startDate = AnsiConsole.Ask<DateOnly>("Date start (Format: MM-dd-yyyy):");
        } while (!Validation.IsDateValid(startDate));

        do
        {
            endDate = AnsiConsole.Ask<DateOnly>("Date end (Format: MM-dd-yyyy):");
        } while (!Validation.IsDateValid(endDate));

        do
        {
            startTime = AnsiConsole.Ask<TimeOnly>("Time start (Format: HH:mm:ss):");
        } while (!Validation.IsTimeValid(startTime, startDate));

        do
        {
            endTime = AnsiConsole.Ask<TimeOnly>("Time end (Format: HH:mm:ss):");
        } while (!Validation.IsTimeValid(endTime, endDate));

        if (!Validation.AreTimesValid(startTime, endTime, startDate, endDate))
        {
            Console.Clear();
            Console.WriteLine("Invalid time!\n");
            Menu();
        }

        run.DateStart = new DateTime(startDate, startTime);
        run.DateEnd = new DateTime(endDate, endTime);

        run.Duration = run.DateEnd - run.DateStart;

        run.Distance = AnsiConsole.Ask<float>("Distance:");

        run.Comments = AnsiConsole.Ask<string>("Comments:");

        return run;
    }

    static internal int GetRunId()
    {
        return AnsiConsole.Ask<int>("Enter the ID of the run:");
    }
}
