using ExerciseTracker.Services;

namespace ExerciseTracker.UnitTests;

[TestClass]
public class ValidationTests
{
    [TestMethod]
    public void IsDateValid_FutureDate_ReturnsFalse()
    {
        var futureDate = DateOnly.MaxValue;

        var result = Validation.IsDateValid(futureDate);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void IsDateValid_PastOrPresentDate_ReturnsTrue()
    {
        var currentDate = DateOnly.FromDateTime(DateTime.Now);

        var result = Validation.IsDateValid(currentDate); 
        
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void AreDatesValid_StartDateIsLaterThanEndDate_ReturnsFalse()
    {
        var startDate = DateOnly.FromDateTime(DateTime.MaxValue);
        var endDate = DateOnly.FromDateTime(DateTime.Now);

        var result = Validation.AreDatesValid(startDate, endDate);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void AreDatesValid_StartDateIsEarlierThanEndDate_ReturnsTrue()
    {
        var startDate = DateOnly.FromDateTime(DateTime.Now);
        var endDate = DateOnly.FromDateTime(DateTime.MaxValue);

        var result = Validation.AreDatesValid(startDate, endDate);

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void IsTimeValid_FutureTimeForPastOrCurrentDate_ReturnsFalse()
    {
        var currentDate = DateOnly.FromDateTime(DateTime.Now);
        var futureTime = TimeOnly.MaxValue;

        var result = Validation.IsTimeValid(futureTime, currentDate);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void IsTimeValid_PastOrPresentTimeForPastOrPresentDate_ReturnsTrue()
    {
        var currentDate = DateOnly.FromDateTime(DateTime.Now);
        var currentTime = TimeOnly.FromDateTime(DateTime.Now);

        var result = Validation.IsTimeValid(currentTime, currentDate);

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void AreTimesValid_StartTimeIsLaterThanEndTimeForCurrentDate_ReturnsFalse()
    {
        var startTime = TimeOnly.FromDateTime(DateTime.MaxValue);
        var endTime = TimeOnly.FromDateTime(DateTime.Now);
        var startDate = DateOnly.FromDateTime(DateTime.Now);
        var endDate = DateOnly.FromDateTime(DateTime.Now);


        var result = Validation.AreTimesValid(startTime, endTime, startDate, endDate);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void AreTimesValid_StartTimeIsEarlierThanEndTimeForCurrentDate_ReturnsTrue()
    {
        var startTime = TimeOnly.FromDateTime(DateTime.Now);
        var endTime = TimeOnly.FromDateTime(DateTime.MaxValue);
        var startDate = DateOnly.FromDateTime(DateTime.Now);
        var endDate = DateOnly.FromDateTime(DateTime.Now);

        var result = Validation.AreTimesValid(startTime, endTime, startDate, endDate);

        Assert.IsTrue(result);
    }
}