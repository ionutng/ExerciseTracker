using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ExerciseTracker.Models;

internal class ExerciseContext : DbContext
{
    public DbSet<Running> Running { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfigurationBuilder configurationBuilder = new ConfigurationBuilder().AddJsonFile("appSettings.json");
        IConfigurationRoot configuration = configurationBuilder.Build();

        optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString"));
    }
}
