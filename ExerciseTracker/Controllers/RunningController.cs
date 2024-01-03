using ExerciseTracker.Repositories;
using ExerciseTracker.Services;

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

        var runId = UserInterface.GetRunId();

        var runs = _runningRepository.GetRuns();

        if (!runs.Any(r => r.RunningId == runId))
        {
            UserInterface.Menu();
        }

        var run = _runningRepository.GetRunById(runId);

        UserInterface.ShowRun(run);
    }

    public void AddRun()
    {
        var run = UserInterface.AskRunInfoInput();

        _runningRepository.AddRun(run);
    }

    public void UpdateRun()
    {
        GetRuns();

        var runId = UserInterface.GetRunId();

        var runs = _runningRepository.GetRuns();

        if (!runs.Any(r => r.RunningId == runId))
        {
            UserInterface.Menu();
        }

        var run = _runningRepository.GetRunById(runId);

        UserInterface.UpdateRunInfoInput(run);

        _runningRepository.UpdateRun(run);
    }

    public void DeleteRun()
    {
        GetRuns();

        var runId = UserInterface.GetRunId();

        var runs = _runningRepository.GetRuns();

        if (!runs.Any(r => r.RunningId == runId))
        {
            UserInterface.Menu();
        }

        var run = _runningRepository.GetRunById(runId);

        _runningRepository.DeleteRun(run);
    }
}
