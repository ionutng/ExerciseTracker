using ExerciseTracker.Models;

namespace ExerciseTracker.Repositories;

internal interface IRunningRepository
{
    ICollection<Running> GetRunnings();
}
