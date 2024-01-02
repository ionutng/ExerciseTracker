using ExerciseTracker.Models;

namespace ExerciseTracker.Repositories;

internal class RunningRepository(ExerciseContext context) : IRunningRepository
{
    private readonly ExerciseContext _context = context;

    public ICollection<Running> GetRuns()
    {
        return _context.Running.OrderBy(r => r.RunningId).ToList();
    }

    public Running GetRunById(int id)
    {
        return _context.Running.Find(id);
    }

    public void AddRun(Running run)
    {
        _context.Running.Add(run);
        _context.SaveChanges();
    }

    public void UpdateRun(Running run)
    {
        _context.Running.Update(run);
        _context.SaveChanges();
    }
}
