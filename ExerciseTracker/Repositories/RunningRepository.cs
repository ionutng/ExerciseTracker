using ExerciseTracker.Models;

namespace ExerciseTracker.Repositories;

internal class RunningRepository(ExerciseContext context) : IRunningRepository
{
    private readonly ExerciseContext _context = context;

    public ICollection<Running> GetRunnings()
    {
        return _context.Running.OrderBy(r => r.RunningId).ToList();
    }
}
