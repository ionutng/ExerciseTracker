namespace ExerciseTracker.Services;

internal class Validation
{
    internal static bool IsDateValid(DateOnly date)
    {
        DateTime currentDate = DateTime.Now;

        if (string.IsNullOrEmpty(date.ToString()))
            return false;

        if (date.CompareTo(DateOnly.FromDateTime(currentDate)) == 1)
            return false;

        return true;
    }

    internal static bool IsTimeValid(TimeOnly time, DateOnly date)
    {
        DateTime currentTime = DateTime.Now;

        if (string.IsNullOrEmpty(time.ToString()))
            return false;

        if (time.CompareTo(TimeOnly.FromDateTime(currentTime)) == 1 && date == DateOnly.FromDateTime(DateTime.Now))
            return false;

        return true;
    }

    internal static bool AreTimesValid(TimeOnly startTime, TimeOnly endTime, DateOnly startDate, DateOnly endDate)
    {
        if (startDate == endDate && startTime > endTime)
            return false;

        return true;
    }
}
