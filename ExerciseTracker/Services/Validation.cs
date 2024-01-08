namespace ExerciseTracker.Services;

public class Validation
{
    public static bool IsDateValid(DateOnly date)
    {
        DateTime currentDate = DateTime.Now;

        if (date.CompareTo(DateOnly.FromDateTime(currentDate)) == 1)
            return false;

        return true;
    }

    public static bool AreDatesValid(DateOnly startDate, DateOnly endDate)
    {
        if (startDate.CompareTo(endDate) > 0)
            return false;

        return true;
    }

    public static bool IsTimeValid(TimeOnly time, DateOnly date)
    {
        DateTime currentTime = DateTime.Now;

        if (time.CompareTo(TimeOnly.FromDateTime(currentTime)) == 1 && date == DateOnly.FromDateTime(DateTime.Now))
            return false;

        return true;
    }

    public static bool AreTimesValid(TimeOnly startTime, TimeOnly endTime, DateOnly startDate, DateOnly endDate)
    {
        if (startDate == endDate && startTime > endTime)
            return false;

        return true;
    }
}
