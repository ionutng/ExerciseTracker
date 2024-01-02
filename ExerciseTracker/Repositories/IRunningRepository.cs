using ExerciseTracker.Models;

namespace ExerciseTracker.Repositories;

internal interface IRunningRepository
{
    ICollection<Running> GetRuns();
    void AddRun(Running run);
}
