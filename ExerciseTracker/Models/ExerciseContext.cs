using Microsoft.EntityFrameworkCore;

namespace ExerciseTracker.Models;

internal class ExerciseContext(DbContextOptions<ExerciseContext> options) : DbContext(options)
{
    public DbSet<Running> Running { get; set; }
}
