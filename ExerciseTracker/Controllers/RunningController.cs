using ExerciseTracker.Models;
using ExerciseTracker.Repositories;
using Spectre.Console;

namespace ExerciseTracker.Controllers;

internal class RunningController(IRunningRepository runningRepository)
{
    private readonly IRunningRepository _runningRepository = runningRepository;

    public void GetRuns()
    {
        var runs = _runningRepository.GetRuns();
        
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

        Console.WriteLine("Press any key to go back to the Menu.");
        Console.ReadKey();
        Console.Clear();
    }

    public void AddRun()
    {
        var run = new Running();

        var startDate = AnsiConsole.Ask<DateOnly>("Date start (Format: MM-dd-yyyy):");
        var endDate = AnsiConsole.Ask<DateOnly>("Date end (Format: MM-dd-yyyy):");
        var startTime = AnsiConsole.Ask<TimeOnly>("Time start (Format: HH:mm:ss):");
        var endTime = AnsiConsole.Ask<TimeOnly>("Time end (Format: HH:mm:ss):");

        run.DateStart = new DateTime(startDate, startTime);
        run.DateEnd = new DateTime(endDate, endTime);

        run.Duration = run.DateEnd - run.DateStart;

        run.Distance = AnsiConsole.Ask<float>("Distance:");

        run.Comments = AnsiConsole.Ask<string>("Comments:");

        _runningRepository.AddRun(run);
    }
}
