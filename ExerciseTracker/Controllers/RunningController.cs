using ExerciseTracker.Repositories;
using Spectre.Console;

namespace ExerciseTracker.Controllers;

internal class RunningController(IRunningRepository runningRepository)
{
    private readonly IRunningRepository _runningRepository = runningRepository;

    public void GetRunnings()
    {
        var runnings = _runningRepository.GetRunnings();
        
        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Start Date");
        table.AddColumn("End Date");
        table.AddColumn("Duration");
        table.AddColumn("Distance");
        table.AddColumn("Comments");

        foreach (var run in runnings)
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
}
