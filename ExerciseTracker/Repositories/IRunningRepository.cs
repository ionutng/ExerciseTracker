using ExerciseTracker.Models;

namespace ExerciseTracker.Repositories;

internal interface IRunningRepository
{
    ICollection<Running> GetRuns();
    Running GetRunById(int id);
    void AddRun(Running run);
    void UpdateRun(Running run);
    void DeleteRun(Running run);
}
