using ExerciseTracker.Controllers;
using ExerciseTracker.Models;
using ExerciseTracker.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace ExerciseTracker.Services;

internal class ExerciseService
{
    internal static Container RunApplication()
    {
        var container = new Container();
        container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

        container.Register(() =>
        {
            var options = new DbContextOptionsBuilder<ExerciseContext>()
            .UseSqlServer(GetConnectionString())
            .Options;

            return new ExerciseContext(options);
        }, Lifestyle.Scoped);

        container.Register<IRunningRepository, RunningRepository>(Lifestyle.Scoped);

        container.Register<RunningController>(Lifestyle.Transient);

        container.Verify();

        return container;
    }

    static string GetConnectionString()
    {
        IConfigurationBuilder configurationBuilder = new ConfigurationBuilder().AddJsonFile("appSettings.json");
        IConfigurationRoot configuration = configurationBuilder.Build();

        return configuration.GetConnectionString("DefaultConnectionString");
    }

    internal static void GetRuns()
    {
        var container = RunApplication();
        using (AsyncScopedLifestyle.BeginScope(container))
        {
            var runningController = container.GetInstance<RunningController>();
            runningController.GetRuns();
        }
    }

    internal static void GetRun()
    {
        var container = RunApplication();
        using (AsyncScopedLifestyle.BeginScope(container))
        {
            var runningController = container.GetInstance<RunningController>();
            runningController.GetRunById();
        }
    }

    internal static void AddRun()
    {
        var container = RunApplication();
        using (AsyncScopedLifestyle.BeginScope(container))
        {
            var runningController = container.GetInstance<RunningController>();
            runningController.AddRun();
        }
    }

    internal static void UpdateRun()
    {
        var container = RunApplication();
        using (AsyncScopedLifestyle.BeginScope(container))
        {
            var runningController = container.GetInstance<RunningController>();
            runningController.UpdateRun();
        }
    }

    internal static void DeleteRun()
    {
        var container = RunApplication();
        using (AsyncScopedLifestyle.BeginScope(container))
        {
            var runningController = container.GetInstance<RunningController>();
            runningController.DeleteRun();
        }
    }
}
