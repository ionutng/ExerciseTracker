using ExerciseTracker.Models;
using ExerciseTracker.Repositories;
using ExerciseTracker.Services;
using Spectre.Console;

namespace ExerciseTracker.Controllers;

internal class RunningController(IRunningRepository runningRepository)
{
    private readonly IRunningRepository _runningRepository = runningRepository;

    public void GetRuns()
    {
        var runs = _runningRepository.GetRuns();
        
        UserInterface.ShowRuns(runs);
    }

    public void GetRunById()
    {
        GetRuns();

        int runId = AnsiConsole.Ask<int>("Enter the ID of the run:");
        var run = _runningRepository.GetRunById(runId);

        UserInterface.ShowRun(run);
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

    public void UpdateRun()
    {
        GetRuns();
        
        int runId = AnsiConsole.Ask<int>("Enter the ID of the run:");

        var run = _runningRepository.GetRunById(runId);

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

        _runningRepository.UpdateRun(run);
    }

    public void DeleteRun()
    {
        GetRuns();

        int runId = AnsiConsole.Ask<int>("Enter the ID of the run:");

        var run = _runningRepository.GetRunById(runId);

        _runningRepository.DeleteRun(run);
    }
}
